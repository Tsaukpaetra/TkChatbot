Imports TkChatBot_Database

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.LogImages = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BotStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainToolstripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.MainTabs = New System.Windows.Forms.TabControl()
        Me.ChatTab = New System.Windows.Forms.TabPage()
        Me.chatTablePanels = New System.Windows.Forms.TableLayoutPanel()
        Me.chatSendButton = New System.Windows.Forms.Button()
        Me.chatSendInput = New System.Windows.Forms.TextBox()
        Me.chatUpper = New System.Windows.Forms.SplitContainer()
        Me.ChatDisplay = New System.Windows.Forms.ListView()
        Me.Level = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Message = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.channelUsers = New System.Windows.Forms.ListBox()
        Me.CommandsTab = New System.Windows.Forms.TabPage()
        Me.CommandsTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CommandsList = New System.Windows.Forms.DataGridView()
        Me.KeywordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnabledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GlobalCDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserCDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinPermissionLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtraPreconditionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommandBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CommandsListAdd = New System.Windows.Forms.Button()
        Me.CommandsListEdit = New System.Windows.Forms.Button()
        Me.CommandsListDelete = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuthenticateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlobalSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowConsoleMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chatUserlistUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.UserPoolViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chatSendTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MainToolstripContainer.BottomToolStripPanel.SuspendLayout()
        Me.MainToolstripContainer.ContentPanel.SuspendLayout()
        Me.MainToolstripContainer.TopToolStripPanel.SuspendLayout()
        Me.MainToolstripContainer.SuspendLayout()
        Me.MainTabs.SuspendLayout()
        Me.ChatTab.SuspendLayout()
        Me.chatTablePanels.SuspendLayout()
        CType(Me.chatUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.chatUpper.Panel1.SuspendLayout()
        Me.chatUpper.Panel2.SuspendLayout()
        Me.chatUpper.SuspendLayout()
        Me.CommandsTab.SuspendLayout()
        Me.CommandsTableLayoutPanel.SuspendLayout()
        CType(Me.CommandsList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UserPoolViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogImages
        '
        Me.LogImages.ImageStream = CType(resources.GetObject("LogImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LogImages.TransparentColor = System.Drawing.Color.Transparent
        Me.LogImages.Images.SetKeyName(0, "023_Tip_16x16_72.png")
        Me.LogImages.Images.SetKeyName(1, "008_Reminder_16x16_72.png")
        Me.LogImages.Images.SetKeyName(2, "1446_envelope_stamp_clsd_32.png")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(424, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BotStatus
        '
        Me.BotStatus.Name = "BotStatus"
        Me.BotStatus.Size = New System.Drawing.Size(86, 17)
        Me.BotStatus.Text = "Not connected"
        '
        'MainToolstripContainer
        '
        '
        'MainToolstripContainer.BottomToolStripPanel
        '
        Me.MainToolstripContainer.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'MainToolstripContainer.ContentPanel
        '
        Me.MainToolstripContainer.ContentPanel.Controls.Add(Me.MainTabs)
        Me.MainToolstripContainer.ContentPanel.Size = New System.Drawing.Size(424, 275)
        Me.MainToolstripContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainToolstripContainer.Location = New System.Drawing.Point(0, 0)
        Me.MainToolstripContainer.Name = "MainToolstripContainer"
        Me.MainToolstripContainer.Size = New System.Drawing.Size(424, 321)
        Me.MainToolstripContainer.TabIndex = 3
        Me.MainToolstripContainer.Text = "ToolStripContainer1"
        '
        'MainToolstripContainer.TopToolStripPanel
        '
        Me.MainToolstripContainer.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'MainTabs
        '
        Me.MainTabs.Controls.Add(Me.ChatTab)
        Me.MainTabs.Controls.Add(Me.CommandsTab)
        Me.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabs.Location = New System.Drawing.Point(0, 0)
        Me.MainTabs.Name = "MainTabs"
        Me.MainTabs.SelectedIndex = 0
        Me.MainTabs.Size = New System.Drawing.Size(424, 275)
        Me.MainTabs.TabIndex = 2
        '
        'ChatTab
        '
        Me.ChatTab.Controls.Add(Me.chatTablePanels)
        Me.ChatTab.Location = New System.Drawing.Point(4, 22)
        Me.ChatTab.Name = "ChatTab"
        Me.ChatTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ChatTab.Size = New System.Drawing.Size(416, 249)
        Me.ChatTab.TabIndex = 0
        Me.ChatTab.Text = "Chat"
        Me.ChatTab.UseVisualStyleBackColor = True
        '
        'chatTablePanels
        '
        Me.chatTablePanels.ColumnCount = 2
        Me.chatTablePanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.chatTablePanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.chatTablePanels.Controls.Add(Me.chatSendButton, 1, 1)
        Me.chatTablePanels.Controls.Add(Me.chatSendInput, 0, 1)
        Me.chatTablePanels.Controls.Add(Me.chatUpper, 0, 0)
        Me.chatTablePanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatTablePanels.Location = New System.Drawing.Point(3, 3)
        Me.chatTablePanels.Name = "chatTablePanels"
        Me.chatTablePanels.RowCount = 2
        Me.chatTablePanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.chatTablePanels.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.chatTablePanels.Size = New System.Drawing.Size(410, 243)
        Me.chatTablePanels.TabIndex = 0
        '
        'chatSendButton
        '
        Me.chatSendButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatSendButton.Enabled = False
        Me.chatSendButton.Location = New System.Drawing.Point(352, 221)
        Me.chatSendButton.Name = "chatSendButton"
        Me.chatSendButton.Size = New System.Drawing.Size(55, 19)
        Me.chatSendButton.TabIndex = 1
        Me.chatSendButton.Text = "Send"
        Me.ToolTip1.SetToolTip(Me.chatSendButton, "Send the message to the chat")
        Me.chatSendButton.UseVisualStyleBackColor = True
        '
        'chatSendInput
        '
        Me.chatSendInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatSendInput.Enabled = False
        Me.chatSendInput.Location = New System.Drawing.Point(3, 221)
        Me.chatSendInput.MaxLength = 500
        Me.chatSendInput.Name = "chatSendInput"
        Me.chatSendInput.Size = New System.Drawing.Size(343, 20)
        Me.chatSendInput.TabIndex = 2
        '
        'chatUpper
        '
        Me.chatTablePanels.SetColumnSpan(Me.chatUpper, 2)
        Me.chatUpper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatUpper.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.chatUpper.Location = New System.Drawing.Point(3, 3)
        Me.chatUpper.Name = "chatUpper"
        '
        'chatUpper.Panel1
        '
        Me.chatUpper.Panel1.Controls.Add(Me.ChatDisplay)
        '
        'chatUpper.Panel2
        '
        Me.chatUpper.Panel2.Controls.Add(Me.channelUsers)
        Me.chatUpper.Size = New System.Drawing.Size(404, 212)
        Me.chatUpper.SplitterDistance = 283
        Me.chatUpper.TabIndex = 3
        '
        'ChatDisplay
        '
        Me.ChatDisplay.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Level, Me.Source, Me.Message})
        Me.ChatDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChatDisplay.FullRowSelect = True
        Me.ChatDisplay.GridLines = True
        Me.ChatDisplay.Location = New System.Drawing.Point(0, 0)
        Me.ChatDisplay.Name = "ChatDisplay"
        Me.ChatDisplay.Size = New System.Drawing.Size(283, 212)
        Me.ChatDisplay.SmallImageList = Me.LogImages
        Me.ChatDisplay.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ChatDisplay, "Hi!")
        Me.ChatDisplay.UseCompatibleStateImageBehavior = False
        Me.ChatDisplay.View = System.Windows.Forms.View.Details
        '
        'Level
        '
        Me.Level.Text = "Log Level"
        Me.Level.Width = 20
        '
        'Source
        '
        Me.Source.Text = "Source"
        '
        'Message
        '
        Me.Message.Text = "Message"
        Me.Message.Width = 300
        '
        'channelUsers
        '
        Me.channelUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.channelUsers.FormattingEnabled = True
        Me.channelUsers.Location = New System.Drawing.Point(0, 0)
        Me.channelUsers.Name = "channelUsers"
        Me.channelUsers.Size = New System.Drawing.Size(117, 212)
        Me.channelUsers.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.channelUsers, "Shows the users currently known at in the chat")
        '
        'CommandsTab
        '
        Me.CommandsTab.Controls.Add(Me.CommandsTableLayoutPanel)
        Me.CommandsTab.Location = New System.Drawing.Point(4, 22)
        Me.CommandsTab.Name = "CommandsTab"
        Me.CommandsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CommandsTab.Size = New System.Drawing.Size(416, 249)
        Me.CommandsTab.TabIndex = 1
        Me.CommandsTab.Text = "Commands"
        Me.CommandsTab.UseVisualStyleBackColor = True
        '
        'CommandsTableLayoutPanel
        '
        Me.CommandsTableLayoutPanel.ColumnCount = 3
        Me.CommandsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.CommandsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.CommandsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.CommandsTableLayoutPanel.Controls.Add(Me.CommandsList, 0, 0)
        Me.CommandsTableLayoutPanel.Controls.Add(Me.CommandsListAdd, 0, 1)
        Me.CommandsTableLayoutPanel.Controls.Add(Me.CommandsListEdit, 1, 1)
        Me.CommandsTableLayoutPanel.Controls.Add(Me.CommandsListDelete, 2, 1)
        Me.CommandsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommandsTableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.CommandsTableLayoutPanel.Name = "CommandsTableLayoutPanel"
        Me.CommandsTableLayoutPanel.RowCount = 2
        Me.CommandsTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CommandsTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.CommandsTableLayoutPanel.Size = New System.Drawing.Size(410, 243)
        Me.CommandsTableLayoutPanel.TabIndex = 1
        '
        'CommandsList
        '
        Me.CommandsList.AllowUserToAddRows = False
        Me.CommandsList.AllowUserToDeleteRows = False
        Me.CommandsList.AutoGenerateColumns = False
        Me.CommandsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CommandsList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KeywordDataGridViewTextBoxColumn, Me.EnabledDataGridViewCheckBoxColumn, Me.GlobalCDDataGridViewTextBoxColumn, Me.UserCDDataGridViewTextBoxColumn, Me.MinPermissionLevelDataGridViewTextBoxColumn, Me.ExtraPreconditionDataGridViewTextBoxColumn, Me.ActionsDataGridViewTextBoxColumn})
        Me.CommandsTableLayoutPanel.SetColumnSpan(Me.CommandsList, 3)
        Me.CommandsList.DataSource = Me.CommandBindingSource
        Me.CommandsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommandsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.CommandsList.Location = New System.Drawing.Point(3, 3)
        Me.CommandsList.Name = "CommandsList"
        Me.CommandsList.RowTemplate.Height = 18
        Me.CommandsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CommandsList.ShowEditingIcon = False
        Me.CommandsList.Size = New System.Drawing.Size(404, 207)
        Me.CommandsList.TabIndex = 0
        '
        'KeywordDataGridViewTextBoxColumn
        '
        Me.KeywordDataGridViewTextBoxColumn.DataPropertyName = "Keyword"
        Me.KeywordDataGridViewTextBoxColumn.HeaderText = "Keyword"
        Me.KeywordDataGridViewTextBoxColumn.Name = "KeywordDataGridViewTextBoxColumn"
        Me.KeywordDataGridViewTextBoxColumn.ToolTipText = "Keyword that will activate this command"
        '
        'EnabledDataGridViewCheckBoxColumn
        '
        Me.EnabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled"
        Me.EnabledDataGridViewCheckBoxColumn.HeaderText = "Enabled"
        Me.EnabledDataGridViewCheckBoxColumn.MinimumWidth = 20
        Me.EnabledDataGridViewCheckBoxColumn.Name = "EnabledDataGridViewCheckBoxColumn"
        Me.EnabledDataGridViewCheckBoxColumn.ToolTipText = "Whether users in chat can use this command"
        Me.EnabledDataGridViewCheckBoxColumn.Width = 60
        '
        'GlobalCDDataGridViewTextBoxColumn
        '
        Me.GlobalCDDataGridViewTextBoxColumn.DataPropertyName = "GlobalCD"
        Me.GlobalCDDataGridViewTextBoxColumn.HeaderText = "Glb CD"
        Me.GlobalCDDataGridViewTextBoxColumn.MinimumWidth = 40
        Me.GlobalCDDataGridViewTextBoxColumn.Name = "GlobalCDDataGridViewTextBoxColumn"
        Me.GlobalCDDataGridViewTextBoxColumn.ToolTipText = "Global Cooldown"
        Me.GlobalCDDataGridViewTextBoxColumn.Width = 65
        '
        'UserCDDataGridViewTextBoxColumn
        '
        Me.UserCDDataGridViewTextBoxColumn.DataPropertyName = "UserCD"
        Me.UserCDDataGridViewTextBoxColumn.HeaderText = "Usr CD"
        Me.UserCDDataGridViewTextBoxColumn.MinimumWidth = 40
        Me.UserCDDataGridViewTextBoxColumn.Name = "UserCDDataGridViewTextBoxColumn"
        Me.UserCDDataGridViewTextBoxColumn.ToolTipText = "User Cooldown"
        Me.UserCDDataGridViewTextBoxColumn.Width = 65
        '
        'MinPermissionLevelDataGridViewTextBoxColumn
        '
        Me.MinPermissionLevelDataGridViewTextBoxColumn.DataPropertyName = "MinPermissionLevel"
        Me.MinPermissionLevelDataGridViewTextBoxColumn.HeaderText = "Perm"
        Me.MinPermissionLevelDataGridViewTextBoxColumn.Name = "MinPermissionLevelDataGridViewTextBoxColumn"
        Me.MinPermissionLevelDataGridViewTextBoxColumn.ToolTipText = "Minimum Permission Level"
        Me.MinPermissionLevelDataGridViewTextBoxColumn.Width = 60
        '
        'ExtraPreconditionDataGridViewTextBoxColumn
        '
        Me.ExtraPreconditionDataGridViewTextBoxColumn.DataPropertyName = "ExtraPrecondition"
        Me.ExtraPreconditionDataGridViewTextBoxColumn.HeaderText = "Precond"
        Me.ExtraPreconditionDataGridViewTextBoxColumn.Name = "ExtraPreconditionDataGridViewTextBoxColumn"
        Me.ExtraPreconditionDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExtraPreconditionDataGridViewTextBoxColumn.ToolTipText = "Extra Precondition"
        Me.ExtraPreconditionDataGridViewTextBoxColumn.Width = 20
        '
        'ActionsDataGridViewTextBoxColumn
        '
        Me.ActionsDataGridViewTextBoxColumn.DataPropertyName = "Actions"
        Me.ActionsDataGridViewTextBoxColumn.FillWeight = 2.0!
        Me.ActionsDataGridViewTextBoxColumn.HeaderText = "Actions"
        Me.ActionsDataGridViewTextBoxColumn.Name = "ActionsDataGridViewTextBoxColumn"
        Me.ActionsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CommandBindingSource
        '
        Me.CommandBindingSource.AllowNew = False
        Me.CommandBindingSource.DataSource = GetType(TkChatBot_Database.Command)
        '
        'CommandsListAdd
        '
        Me.CommandsListAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommandsListAdd.Location = New System.Drawing.Point(3, 216)
        Me.CommandsListAdd.Name = "CommandsListAdd"
        Me.CommandsListAdd.Size = New System.Drawing.Size(130, 24)
        Me.CommandsListAdd.TabIndex = 1
        Me.CommandsListAdd.Text = "Add"
        Me.CommandsListAdd.UseVisualStyleBackColor = True
        '
        'CommandsListEdit
        '
        Me.CommandsListEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommandsListEdit.Location = New System.Drawing.Point(139, 216)
        Me.CommandsListEdit.Name = "CommandsListEdit"
        Me.CommandsListEdit.Size = New System.Drawing.Size(130, 24)
        Me.CommandsListEdit.TabIndex = 2
        Me.CommandsListEdit.Text = "Edit"
        Me.CommandsListEdit.UseVisualStyleBackColor = True
        '
        'CommandsListDelete
        '
        Me.CommandsListDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommandsListDelete.Location = New System.Drawing.Point(275, 216)
        Me.CommandsListDelete.Name = "CommandsListDelete"
        Me.CommandsListDelete.Size = New System.Drawing.Size(132, 24)
        Me.CommandsListDelete.TabIndex = 3
        Me.CommandsListDelete.Text = "Delete"
        Me.CommandsListDelete.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(424, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BotToolStripMenuItem
        '
        Me.BotToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuthenticateToolStripMenuItem, Me.GlobalSettingsToolStripMenuItem, Me.ShowConsoleMenuItem, Me.ExitToolStripMenuItem})
        Me.BotToolStripMenuItem.Name = "BotToolStripMenuItem"
        Me.BotToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.BotToolStripMenuItem.Text = "&Bot"
        '
        'AuthenticateToolStripMenuItem
        '
        Me.AuthenticateToolStripMenuItem.Name = "AuthenticateToolStripMenuItem"
        Me.AuthenticateToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AuthenticateToolStripMenuItem.Text = "&Authenticate"
        '
        'GlobalSettingsToolStripMenuItem
        '
        Me.GlobalSettingsToolStripMenuItem.Name = "GlobalSettingsToolStripMenuItem"
        Me.GlobalSettingsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GlobalSettingsToolStripMenuItem.Text = "Global &Settings"
        '
        'ShowConsoleMenuItem
        '
        Me.ShowConsoleMenuItem.Name = "ShowConsoleMenuItem"
        Me.ShowConsoleMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ShowConsoleMenuItem.Text = "&Console"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'chatUserlistUpdate
        '
        Me.chatUserlistUpdate.Enabled = True
        Me.chatUserlistUpdate.Interval = 3000
        '
        'UserPoolViewBindingSource
        '
        Me.UserPoolViewBindingSource.AllowNew = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.ReshowDelay = 100
        '
        'chatSendTimer
        '
        Me.chatSendTimer.Enabled = True
        Me.chatSendTimer.Interval = Global.Tk_TwitchChatBot.My.MySettings.Default.chat_SendDelay
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 321)
        Me.Controls.Add(Me.MainToolstripContainer)
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Main"
        Me.Text = "Tk-TwitchBot"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MainToolstripContainer.BottomToolStripPanel.ResumeLayout(False)
        Me.MainToolstripContainer.BottomToolStripPanel.PerformLayout()
        Me.MainToolstripContainer.ContentPanel.ResumeLayout(False)
        Me.MainToolstripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.MainToolstripContainer.TopToolStripPanel.PerformLayout()
        Me.MainToolstripContainer.ResumeLayout(False)
        Me.MainToolstripContainer.PerformLayout()
        Me.MainTabs.ResumeLayout(False)
        Me.ChatTab.ResumeLayout(False)
        Me.chatTablePanels.ResumeLayout(False)
        Me.chatTablePanels.PerformLayout()
        Me.chatUpper.Panel1.ResumeLayout(False)
        Me.chatUpper.Panel2.ResumeLayout(False)
        CType(Me.chatUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.chatUpper.ResumeLayout(False)
        Me.CommandsTab.ResumeLayout(False)
        Me.CommandsTableLayoutPanel.ResumeLayout(False)
        CType(Me.CommandsList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UserPoolViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BotStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LogImages As System.Windows.Forms.ImageList
    Friend WithEvents chatSendTimer As System.Windows.Forms.Timer
    Friend WithEvents CommandBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MainToolstripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuthenticateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlobalSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserPoolViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chatUserlistUpdate As System.Windows.Forms.Timer
    Friend WithEvents MainTabs As System.Windows.Forms.TabControl
    Friend WithEvents ChatTab As System.Windows.Forms.TabPage
    Friend WithEvents chatTablePanels As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chatSendButton As System.Windows.Forms.Button
    Friend WithEvents chatSendInput As System.Windows.Forms.TextBox
    Friend WithEvents chatUpper As System.Windows.Forms.SplitContainer
    Friend WithEvents ChatDisplay As System.Windows.Forms.ListView
    Friend WithEvents Level As System.Windows.Forms.ColumnHeader
    Friend WithEvents Source As System.Windows.Forms.ColumnHeader
    Friend WithEvents Message As System.Windows.Forms.ColumnHeader
    Friend WithEvents channelUsers As System.Windows.Forms.ListBox
    Friend WithEvents CommandsTab As System.Windows.Forms.TabPage
    Friend WithEvents CommandsTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CommandsList As System.Windows.Forms.DataGridView
    Friend WithEvents KeywordDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnabledDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GlobalCDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserCDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinPermissionLevelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtraPreconditionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActionsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommandsListAdd As System.Windows.Forms.Button
    Friend WithEvents CommandsListEdit As System.Windows.Forms.Button
    Friend WithEvents CommandsListDelete As System.Windows.Forms.Button
    Friend WithEvents ShowConsoleMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
