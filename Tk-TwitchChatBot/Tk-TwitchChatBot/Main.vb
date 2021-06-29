Imports ChatSharp
Imports VS.Logger
Imports TkChatBotPlugin_Base
Imports TkChatBot_Database
Imports System.Reflection

Public Class Main
    Private WithEvents chatConnection As IrcClient
    Private appLog As Logger
    Private globalSettings As GlobalSettings

    Private Delegate Function PreFilter_Function(ByRef msg As PrivateMessage) As Boolean
    Private PreFilter_Functions As List(Of PreFilter_Function) = New List(Of PreFilter_Function)
    Private cmdInterpreter As CommandInterpreter

    Event UserListRefreshed()
    Event BotStatusUpdated(ByVal status As String)

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Disconnect("Closing client")
        appLog.shutdown()
    End Sub
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        appLog = New Logger(3, "application.log")
        globalSettings = New GlobalSettings()
        cmdInterpreter = New CommandInterpreter()

        'Load up the commands editor
        Using db As DatabaseEntities = New DatabaseEntities()
            CommandBindingSource.DataSource = db.Commands.ToList()
        End Using
        AddHandler cmdInterpreter.DbSaveChanges, AddressOf callDBSaveChanges

        AddLog(1, "Bot", "Bot Started. Please connect.")

        'Load up the UserAttendance panel
        Dim userattendancepanelform As New UserAttendance()
        AddFormToTab(userattendancepanelform)
        LoadPluginEventsAndData(userattendancepanelform)

        'Load up the User Attributes panel
        Dim userattributespanelform As New UserAttributesEditor()
        AddFormToTab(userattributespanelform)
        LoadPluginEventsAndData(userattributespanelform)

        'Load up the Timers panel
        Dim timersform As New Timers()
        timersform.Show()
        AddFormToTab(timersform)
        LoadPluginEventsAndData(timersform)

        'Attach assembly resolver hook
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf pluginDependencyResolver

        'Load up any plugins in the Plugins folder
        LoadPlugins()

        'Execute the startup expressions
        LoadStartupExpressions()
    End Sub

    Sub LoadStartupExpressions()
        For Each se In My.Settings.startupExpressions.Split(vbCrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            Dim eval As TinyExe.Expression = New TinyExe.Expression(se, cmdInterpreter.expressionContextMain)
            If eval.Errors.Count > 0 Then
                AddLog(2, "StartupExpression", String.Join(" :: ", eval.Errors))
            Else
                'AddLog(1, "StartupExpression", eval.Eval().ToString())

            End If

        Next


    End Sub

#Region "Plugin handling"
    Private Sub AddFormToTab(ByRef theform As BotPluginTemplate)
        Dim containingpanel As New Panel()
        Dim theTab As String = theform.TabName
        'Adjust some form properties
        With theform
            .WindowState = FormWindowState.Normal
            '.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ControlBox = False 'Hide the close button
            .Dock = DockStyle.Fill
            .MaximizeBox = False 'Prevent double-click to maximize (maximized forms are not resizable, so it breaks functionality)
            .TopLevel = False
            .Show()
        End With

        'Set up the containing panel
        With containingpanel
            .MinimumSize = New Size(theform.MinimumSize.Width + 20, theform.MinimumSize.Height + 35)
            '.MinimumSize = theform.MinimumSize
            .Size = theform.Size
            .MaximumSize = theform.MaximumSize
            .BorderStyle = BorderStyle.None

        End With

        'Rabbit hole!
        Dim pform As New GroupBox()
        With pform
            .Text = theform.Text
            .BackColor = System.Drawing.SystemColors.ActiveCaption
            .Padding = New Padding(10, 5, 10, 10)
            .Dock = DockStyle.Fill

            .Show()
            .Controls.Add(theform)
        End With
        containingpanel.Controls.Add(pform)

        'containingpanel.Controls.Add(theform)

        'Find the tab we're looking for
        Dim DestinationPage As TabPage = (From a As TabPage In MainTabs.TabPages Where a.Text = theTab).FirstOrDefault()

        'If the tab doesn't exist, make it!
        If DestinationPage Is Nothing Then
            DestinationPage = New TabPage(theTab)
            MainTabs.TabPages.Add(DestinationPage)
            'Add in the multisplitcontainer
            Dim newmsc As New MultisplitContainer()
            DestinationPage.Controls.Add(newmsc)
            'Set up the MSC
            newmsc.Dock = DockStyle.Fill
            newmsc.SingleColumnOrRow = True
        End If

        'Get the MSC to add the panel to
        Dim msc As MultisplitContainer = (From a As TabPage In MainTabs.TabPages Where a.Text = theTab Select (From b As Control In a.Controls Where TypeOf b Is MultisplitContainer).FirstOrDefault()).FirstOrDefault()

        If msc Is Nothing Then
            'Hmm, something went wrong here.
            Throw New Exception("Failed to create or find the Tab or MultiSplitContainer for " & theform.Text & " in tab " & theTab)
        End If

        msc.Controls.Add(containingpanel)
        msc.SingleColumnOrRow = True

        theform.Show()

    End Sub
    Private Sub LoadPluginEventsAndData(ByRef theform As BotPluginTemplate)
        'Event sources
        AddHandler UserListRefreshed, AddressOf theform.UpdateUsersList
        AddHandler BotStatusUpdated, AddressOf theform.BotStatusUpdated

        'Event destinations
        AddHandler theform.DBSaveChanges, AddressOf callDBSaveChanges
        AddHandler theform.SendChatMessage, AddressOf sendMessage

        'Add the preFilter function
        PreFilter_Functions.Add(AddressOf theform.PreFilterMessage)

        'Final setup
        theform.AddToExpressionContext(cmdInterpreter.expressionContextMain)

    End Sub

    Private Sub LoadPlugins()
        Dim pluginBaseDir As String = Application.StartupPath & "\Plugins\"


        For Each pluginFile As String In System.IO.Directory.GetFiles(pluginBaseDir, "*.dll")
            Dim pluginType As Type = Nothing
            'pluginFile = pluginFile.Substring(pluginBaseDir.Length)
            'pluginFile = pluginFile.Substring(0, pluginFile.Length - 4)


            'Lets load up the DLL
            Try
                Dim a1 As Assembly = Nothing
                a1 = Assembly.LoadFile(pluginFile)
                'Check if we loaded it at all
                If Not a1 Is Nothing Then
                    'DirectCast(a1,System.Reflection.RuntimeAssembly).ExportedTypes
                    'Ok, we have our assembly, lets try loading stuff from it!
                    Dim availableTypes As Type() = a1.GetExportedTypes()


                    Dim typeList = From at In availableTypes
                                   Where at.BaseType Is GetType(TkChatBotPlugin_Base.BotPluginTemplate)

                    Dim pluginForm As Type
                    For Each pluginForm In typeList.ToArray()
                        'Okay, we found some plugin forms!
                        'Lets try to instantiate it!
                        Dim plugin As TkChatBotPlugin_Base.BotPluginTemplate = Activator.CreateInstance(pluginForm)

                        'Now that we've loaded it, add it to the app!
                        AddFormToTab(plugin)
                        LoadPluginEventsAndData(plugin)
                    Next


                End If

            Catch ex As Exception

            End Try





        Next


    End Sub

    Private Function pluginDependencyResolver(sender As Object, e As ResolveEventArgs) As Assembly
        'This handler is called only when the common language runtime tries to bind to the assembly and fails.        

            'Build the path of the assembly from where it has to be loaded.
            Dim strTempAssmbPath As String
        strTempAssmbPath = Application.StartupPath & "\Plugins\" & e.Name.Substring(0, e.Name.IndexOf(",")) & ".dll"

        'Look for the assembly names that have raised the "AssemblyResolve" event.
        If (IO.File.Exists(strTempAssmbPath)) Then
            Return [Assembly].LoadFrom(strTempAssmbPath)
        End If

        'Try Interop?
        strTempAssmbPath = Application.StartupPath & "\Plugins\Interop." & e.Name.Substring(0, e.Name.IndexOf(",")) & ".dll"

        'Look for the assembly names that have raised the "AssemblyResolve" event.
        If (IO.File.Exists(strTempAssmbPath)) Then
            'Load it up and give it back
            Return [Assembly].LoadFrom(strTempAssmbPath)
        End If

        Return Nothing
    End Function

#End Region
#Region "Main Menu Items"
    Private Sub AuthenticateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuthenticateToolStripMenuItem.Click
        Dim botAuth As New AuthDialog()
        'Set the action to disconnect if we're currently connected
        If Not chatConnection Is Nothing Then If Not chatConnection.NetworkStream Is Nothing Then botAuth.OkAction.Text = "Disconnect"

        If botAuth.ShowDialog() = DialogResult.OK Then


            updateBotStatus("Authentication set, ready to connect")
            AddLog(2, "connection", "Authentication set, ready to connect")

            If botAuth.OkAction.Text = "Connect" Then
                chatConnection = New IrcClient(My.Settings.Bot_Server, (New IrcUser(My.Settings.Bot_Name, My.Settings.Bot_Name, My.Settings.Bot_OAuth)), My.Settings.Bot_sslEnabled)
                chatConnection.ConnectAsync()
                updateBotStatus("Connecting...")
                AddLog(2, "connection", "Connecting...")
            Else
                'call disconnect
                Disconnect("Re-authenticating")
            End If

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GlobalSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalSettingsToolStripMenuItem.Click
        globalSettings.Show()
    End Sub
    Private Sub ShowConsoleMenuItem_Click(sender As Object, e As EventArgs) Handles ShowConsoleMenuItem.Click
        Dim a As New BotConsole()
        'Set the expressioncontext
        a.cmdPrompt.SetContext(cmdInterpreter.expressionContextMain)
        a.cmdPrompt.promptChar = "="

        a.Show()
        'cmdInterpreter.expressionContextMain()

    End Sub
#End Region



#Region "Main chat, status, and log handlers"
    Private Delegate Sub AddLog_delegate(ByVal logLevel As Integer, ByVal name As String, ByVal message As String)
    Private Sub AddLog(ByVal logLevel As Integer, ByVal name As String, ByVal message As String)
        If Me.ChatDisplay.InvokeRequired Then
            Dim d As New AddLog_delegate(AddressOf AddLog)
            Me.ChatDisplay.BeginInvoke(d, {logLevel, name, message})
        Else
            appLog.log(logLevel, name, message)
            Dim lvi As New ListViewItem(logLevel)
            Try
                lvi.ImageIndex = logLevel - 1

            Catch ex As Exception

            End Try

            lvi.SubItems.Add(name).Tag = DateTime.Now().ToShortTimeString()
            lvi.SubItems.Add(message).Tag = message

            ChatDisplay.Items.AddRange(New ListViewItem() {lvi})
            ChatDisplay.EnsureVisible(ChatDisplay.Items.Count - 1)

            'Remove lines from the top if we're exceeding the limit, applying hysteresis 
            If ChatDisplay.Items.Count > globalSettings.chatMaxLines.Value + 50 Then
                ChatDisplay.BeginUpdate()
                For Each item As ListViewItem In (From a In ChatDisplay.Items Take 50)
                    item.Remove()
                Next
                ChatDisplay.EndUpdate()
            End If

            ChatDisplay.Update()
        End If
    End Sub

    Private Sub chatConnection_ChannelListRecieved(ByVal sender As Object, ByVal e As ChatSharp.Events.ChannelEventArgs) Handles chatConnection.ChannelListRecieved
        UserListNeedsUpdating = True
    End Sub
    Private Sub chatConnection_ChannelMessageRecieved(ByVal sender As Object, ByVal e As ChatSharp.Events.PrivateMessageEventArgs) Handles chatConnection.ChannelMessageRecieved
        'ChatDisplay.Items.Add("Message in [" & e.PrivateMessage.Source & "]: " & e.PrivateMessage.Message)
        AddLog(3, e.PrivateMessage.User.Nick, e.PrivateMessage.Message)

        Dim cancelCommandExecution As Boolean = False
        For Each f As PreFilter_Function In PreFilter_Functions
            cancelCommandExecution = cancelCommandExecution Or f(e.PrivateMessage)
        Next

        'Check if we need to cancel command execution
        If Not cancelCommandExecution Then
            'Execute the command
            Dim response As String = cmdInterpreter.doCommand(e.PrivateMessage)
            If response <> "" Then sendMessage(response)
        End If

    End Sub

    Private Sub chatConnection_PrivateMessageRecieved(sender As Object, e As Events.PrivateMessageEventArgs) Handles chatConnection.PrivateMessageRecieved

        'Don't respond to channel messages here
        If e.PrivateMessage.IsChannelMessage Then Exit Sub
        'Private messages are handled almost identically to channel messages, except any response is directed directly to them and not through the queue
        AddLog(3, "[" & e.PrivateMessage.User.Nick & "]", e.PrivateMessage.Message)

        Dim cancelCommandExecution As Boolean = False
        For Each f As PreFilter_Function In PreFilter_Functions
            cancelCommandExecution = cancelCommandExecution Or f(e.PrivateMessage)
        Next

        'Check if we need to cancel command execution
        If Not cancelCommandExecution Then
            'Execute the command
            Dim response As String = cmdInterpreter.doCommand(e.PrivateMessage)
            If response <> "" Then
                For Each msg In response.Replace(Chr(10), "").Split({Chr(13)}, StringSplitOptions.RemoveEmptyEntries)
                    'Add the private message part if it doesn't exist
                    If msg.IndexOf(Chr(1)) = -1 Then msg = e.PrivateMessage.User.Nick & Chr(1) & msg
                    sendMessage(msg)
                Next
            End If
        End If
    End Sub

    Private Sub chatConnection_OnConnect(ByVal sender As Object, ByVal e As EventArgs) Handles chatConnection.ConnectionComplete
        updateBotStatus("Connected")
        chatConnection.SendRawMessage("CAP REQ :twitch.tv/membership")
        AddLog(1, "connection", "Successfully connected, joining #" & My.Settings.Bot_Channel)
        If Not chatConnection.Channels.Contains("#" & My.Settings.Bot_Channel) Then chatConnection.JoinChannel("#" & My.Settings.Bot_Channel)
        'Set the session start time
        cmdInterpreter.sessionStart = Now
    End Sub

    Private Sub chatConnection_NoticeRecieved(ByVal sender As Object, ByVal e As ChatSharp.Events.IrcNoticeEventArgs) Handles chatConnection.NoticeRecieved
        AddLog(2, "server", e.Notice)
    End Sub



    Private Sub chatConnection_UserJoinedChannel(ByVal sender As Object, ByVal e As ChatSharp.Events.ChannelUserEventArgs) Handles chatConnection.UserJoinedChannel
        AddLog(2, "connection", "Channel [" & e.Channel.Name & "] User Joined: " & e.User.Nick)
        'Refresh the users list
        UserListNeedsUpdating = True


    End Sub
    Private Sub chatConnection_UserPartedChannel(ByVal sender As Object, ByVal e As ChatSharp.Events.ChannelUserEventArgs) Handles chatConnection.UserPartedChannel
        AddLog(2, "connection", "Channel [" & e.Channel.Name & "] User Left: " & e.User.Nick)

        UserListNeedsUpdating = True
    End Sub

    Private Sub chatConnection_UserQuit(ByVal sender As Object, ByVal e As ChatSharp.Events.UserEventArgs) Handles chatConnection.UserQuit
        AddLog(2, "connection", "User Quit: " & e.User.Nick)

        UserListNeedsUpdating = True
    End Sub

    Private Delegate Sub updateBotStatus_delegate(ByVal status As String)
    Private Sub updateBotStatus(ByVal status As String)
        If StatusStrip1.InvokeRequired Then
            Me.StatusStrip1.BeginInvoke(New updateBotStatus_delegate(AddressOf updateBotStatus), {status})
        Else
            BotStatus.Text = status
            Select Case status
                Case "Disconnected"
                    Me.Text = "Tk-Twitchbot (Disconnected)"
                    chatSendButton.Enabled = False
                    chatSendInput.Enabled = False
                Case "Connected"
                    Me.Text = "Tk-Twitchbot - " & My.Settings.Bot_Channel
                    chatSendButton.Enabled = True
                    chatSendInput.Enabled = True
            End Select
        End If
        RaiseEvent BotStatusUpdated(status)
    End Sub

    Private Sub Disconnect(Optional ByVal message As String = "Closing Bot")
        'Check if we need to disconnect
        If Not chatConnection Is Nothing Then
            AddLog(2, "connection", "Disconnecting...")
            If Not chatConnection.NetworkStream Is Nothing Then chatConnection.Quit(message)
            chatConnection = Nothing
        End If
        UserListNeedsUpdating = True
        BotStatus.Text = "Disconnected"
        chatSendButton.Enabled = False
        chatSendInput.Enabled = False
    End Sub
    'Manual chat handling

    Private Sub chatSendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chatSendButton.Click
        chatConnection.SendMessage(chatSendInput.Text, "#" & My.Settings.Bot_Channel)
        AddLog(3, chatConnection.User.Nick, chatSendInput.Text)
        chatSendInput.Text = ""
    End Sub

    Private Sub chatSendInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chatSendInput.KeyPress
        If e.KeyChar = Chr(13) Then
            chatSendButton_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub ChatDisplay_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Check if the message column is smaller than the current width and adjust
        Dim currentWidth, newWidth As Integer
        currentWidth = ChatDisplay.Columns(2).Width
        newWidth = ChatDisplay.Width - ChatDisplay.Columns(0).Width - ChatDisplay.Columns(1).Width
        If newWidth > currentWidth Then ChatDisplay.Columns(2).Width = newWidth
    End Sub

    Private Delegate Sub sendMessage_delegate(ByVal message As String)
    Public Sub sendMessage(ByVal message As String)
        If Me.globalSettings.chatSendQueue.InvokeRequired Then
            Dim d As New sendMessage_delegate(AddressOf sendMessage)
            Me.ChatDisplay.BeginInvoke(d, {message})
        Else
            globalSettings.chatSendQueue.Items.AddRange(message.Replace(Chr(10), "").Split({Chr(13)}, StringSplitOptions.RemoveEmptyEntries))
        End If
    End Sub

    Private Sub chatSendTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chatSendTimer.Tick
        'Check if we have things to send, and send the first in the list
        If globalSettings.chatSendQueue.Items.Count > 0 Then
            With globalSettings.chatSendQueue
                ' Avoid sending blank lines)
                If .Items(0) <> "" Then
                    Dim MessageParts As String()
                    'Split up the message
                    MessageParts = .Items(0).ToString().Split(Chr(1))

                    'Check what type of message we're sending
                    If MessageParts.Length = 1 Then
                        'If there is only one part, it's a normal channel message, so just send it as is
                        AddLog(3, chatConnection.User.Nick, .Items(0))
                        chatConnection.SendMessage(.Items(0), "#" & My.Settings.Bot_Channel)
                    ElseIf MessageParts.Length = 2 Then
                        'Should be a private message, so send it there
                        AddLog(3, "]" & MessageParts(0) & "[", MessageParts(1))
                        chatConnection.SendMessage(MessageParts(1), MessageParts(0))
                    End If

                End If
                .Items.RemoveAt(0)
            End With

        End If
        'Check if the rate has changed
        If chatSendTimer.Interval <> My.Settings.chat_SendDelay Then
            chatSendTimer.Interval = My.Settings.chat_SendDelay
        End If
    End Sub
#End Region


#Region "Commands List"
    Private Sub CommandsList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CommandsList.CellDoubleClick
        'Double-click = edit
        'MsgBox(e.RowIndex)

        'Get the selected item
        Dim SelectedCommand As Command = CommandsList.CurrentRow.DataBoundItem
        editCommand(SelectedCommand)
    End Sub

    Private Sub CommandBindingSource_AddingNew(ByVal sender As System.Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles CommandBindingSource.AddingNew
        Dim newthing As Command = New Command()
        newthing.Keyword = ""
        newthing.Actions = ""
        'Generate a new ID
        Using db As DatabaseEntities = New DatabaseEntities()

            newthing.Id = (From a In db.Commands
                          Order By a.Id Descending
                          Take 1).FirstOrDefault().Id + 1
        End Using


        e.NewObject = newthing

    End Sub
    Private Sub CommandsListAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandsListAdd.Click
        'Create a new command and open the editor for it
        Dim newthing As Command = New Command()
        newthing.Keyword = ""
        newthing.Actions = ""
        'Generate a new ID
        Using db As DatabaseEntities = New DatabaseEntities()
            newthing.Id = (From a In db.Commands
                          Order By a.Id Descending
                          Take 1).FirstOrDefault().Id + 1
            'Enable it
            newthing.Enabled = True
            'Add it to the commands
            db.Commands.Add(newthing)

            db.SaveChanges()
            '
        End Using
        'And call the editor on it
        editCommand(newthing)

        refreshCommandsList()

    End Sub

    Private Sub editCommand(ByRef theCommand As Command)
        Dim n As New CommandEditor(theCommand)

        'Handle the child's closing
        AddHandler n.FormClosed, New FormClosedEventHandler(AddressOf CommandEditor_OnClosed)
        n.Show()
    End Sub

    Public Sub CommandEditor_OnClosed(ByVal sender As CommandEditor, ByVal e As FormClosedEventArgs)
        'Closed a commandEditor window, if successful, save changes
        If sender.DialogResult = DialogResult.OK Then

            Using db As DatabaseEntities = New DatabaseEntities()
                db.Entry(sender.CommandBindingSource.Current).State = Entity.EntityState.Modified
                db.SaveChanges()

            End Using

            'cmdInterpreter.shouldSaveDB = True

            'Also refresh the command list
        End If
        'Refresh the commands list
        refreshCommandsList()
    End Sub

    Private Sub CommandsListEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandsListEdit.Click
        For Each item In CommandsList.SelectedRows
            editCommand(item.DataBoundItem)
        Next
    End Sub

    Private Delegate Sub refreshCommandsList_delegate()
    Private Sub refreshCommandsList()
        If Me.CommandsList.InvokeRequired Then
            Me.CommandsList.BeginInvoke(New refreshCommandsList_delegate(AddressOf refreshCommandsList))
        Else
            'cmdInterpreter.db.ChangeTracker.DetectChanges()
            ''CommandsList.DataSource = Nothing
            Using db As DatabaseEntities = New DatabaseEntities()

                CommandBindingSource.DataSource = db.Commands.ToList()
            End Using
            CommandBindingSource.ResetBindings(False)

        End If
    End Sub
    Private Sub CommandsListDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandsListDelete.Click
        Using db As DatabaseEntities = New DatabaseEntities()
            For Each item As DataGridViewRow In CommandsList.SelectedRows
                Dim theCommand As Command = item.DataBoundItem

                db.Commands.Remove(db.Commands.Find(theCommand.Keyword))
            Next
            db.SaveChanges()
        End Using
        'cmdInterpreter.shouldSaveDB = True
        refreshCommandsList()
    End Sub
    Private Sub CommandsList_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles CommandsList.CellValueChanged
        'If we don't have any object, don't try to update it
        If CommandsList.CurrentRow Is Nothing Then Exit Sub
        Dim updatedCommand As Command = CommandsList.CurrentRow.DataBoundItem
        'Don't try to update if it has an invalid name (i.e. is new)
        If updatedCommand.Keyword = "" Then Exit Sub
        Using db As DatabaseEntities = New DatabaseEntities()
            'Retrieve the matching item
            Dim theCommand As Command = db.Commands.Find(updatedCommand.Id)
            If Not theCommand Is Nothing Then
                'Update the editable parts of the timer
                theCommand.Enabled = updatedCommand.Enabled
                theCommand.GlobalCD = updatedCommand.GlobalCD
                theCommand.UserCD = updatedCommand.UserCD


            End If

            'Save the changes
            db.SaveChanges()
        End Using
    End Sub
#End Region

#Region "Users List"

    Private Delegate Sub refreshUsersList_delegate()
    Private Sub refreshUsersList()
        If Me.channelUsers.InvokeRequired Then
            Dim d As New refreshUsersList_delegate(AddressOf refreshUsersList)
            Me.channelUsers.BeginInvoke(d)
        Else
            'Check if we're connected to a channel
            If Not IsNothing(chatConnection) Then
                Dim channels = chatConnection.Channels
                If channels.Count() > 0 Then
                    Dim channel As IrcChannel = (From c In channels Where c.Name = "#" + My.Settings.Bot_Channel Take 1).FirstOrDefault()
                    Dim onlineUsersQueryList = channel.Users.ToList()
                    Dim OnlineUsers As List(Of String) = (From a In onlineUsersQueryList Where a.Nick <> My.Settings.Bot_Name Select a.Nick).ToList()

                    channelUsers.BeginUpdate()
                    'Get the currently selected user (if any)
                    Dim lastSelectedItem As String = ""
                    If Not channelUsers.SelectedItem Is Nothing Then
                        lastSelectedItem = channelUsers.SelectedItem
                    End If

                    'Reset the graphical list
                    channelUsers.DataSource = Nothing
                    channelUsers.DataSource = OnlineUsers

                    'If we had something selected, re-select it
                    If lastSelectedItem <> "" Then
                        For count As Integer = 0 To channelUsers.Items.Count - 1
                            If channelUsers.Items(count) = lastSelectedItem Then channelUsers.SetSelected(count, True)

                        Next
                    End If

                    channelUsers.EndUpdate()
                    lastUserListRefresh = Now

                    'Also update the users list in the command interpreter
                    cmdInterpreter.UpdateUserData(OnlineUsers)
                    Dim userList As List(Of User)
                    Using db As DatabaseEntities = New DatabaseEntities()
                        userList = db.Users.ToList()
                    End Using
                    RaiseEvent UserListRefreshed()

                End If
            End If
            UserListNeedsUpdating = False
        End If
    End Sub

    Private lastUserListRefresh As DateTime = Now
    Private UserListNeedsUpdating As Boolean = False
    Private Sub chatUserlistUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chatUserlistUpdate.Tick
        'Just an extra timer to update the userlist and keep it fresh

        'Only refresh if it's been a few seconds since the last time
        If lastUserListRefresh.AddSeconds(60) < Now Or UserListNeedsUpdating Or True Then refreshUsersList()
    End Sub
#End Region




    Public Sub callDBSaveChanges()
        'cmdInterpreter.shouldSaveDB = True
        refreshCommandsList()
        refreshUsersList()
    End Sub


    Private Sub ChatDisplay_MouseMove(sender As Object, e As MouseEventArgs) Handles ChatDisplay.MouseMove
        Dim it As ListViewItem = ChatDisplay.GetItemAt(e.X, e.Y)
        'Don't do anything if we're not over an item
        If it Is Nothing Then Exit Sub
        Dim tt As ListViewHitTestInfo = ChatDisplay.HitTest(e.Location)

        'If not pointing at a subitem, reset the tooltop
        If tt.SubItem Is Nothing Then
            'ToolTip1.SetToolTip(ChatDisplay, "")
        Else
            If tt.SubItem.Tag Is Nothing Then Exit Sub
            'If ToolTip1.GetToolTip(Me.ChatDisplay) <> tt.SubItem.Tag.ToString() Then ToolTip1.SetToolTip(Me.ChatDisplay, tt.SubItem.Tag.ToString())
            ToolTip1.SetToolTip(ChatDisplay, Nothing)
            ToolTip1.SetToolTip(ChatDisplay, "Blah blac")
            ToolTip1.Active = False
            'Me.ToolTip1.SetToolTip(Me.ChatDisplay, "Hi! there!")
            If ChatDisplay.InvokeRequired Then
                MsgBox("What am I doing?")
            End If



        End If





    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown


    End Sub

End Class
