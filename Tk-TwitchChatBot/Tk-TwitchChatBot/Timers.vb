Imports TkChatBot_Database

Public Class Timers
    'Dim db As DatabaseEntities = New DatabaseEntities()
    Dim timerEnabled As Boolean = False
    Private expressionContextMain As TinyExe.Context

    Private Sub Timers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TabName = "Timers"
        Using db As DatabaseEntities = New DatabaseEntities()
            TimerBindingSource.DataSource = db.Timers.ToList()

        End Using
    End Sub

    Private Delegate Sub refreshGrid_Delegate(ByVal saveChanges As Boolean)
    Private Sub refreshGrid(Optional ByVal saveChanges As Boolean = False)
        'Don't do this if we're currently editing
        'If DataGridView1.IsCurrentRowDirty Then Exit Sub

        If DataGridView1.InvokeRequired Then
            DataGridView1.BeginInvoke(New refreshGrid_Delegate(AddressOf refreshGrid), {saveChanges})
        Else

            'Suspend layout of the thing
            DataGridView1.SuspendLayout()
            DataGridView1.DataSource = Nothing
            Using db As DatabaseEntities = New DatabaseEntities()
                If saveChanges Then db.SaveChanges()
                'db.Entry(db.Timers).Reload()
                TimerBindingSource.DataSource = db.Timers.ToList()
            End Using
            DataGridView1.DataSource = TimerBindingSource


            'resume layout of the thing
            DataGridView1.ResumeLayout()

        End If
    End Sub

    Private Delegate Function removeItem_delegate(ByVal name As String)
    Private Function removeItem(ByVal name As String)

        If DataGridView1.InvokeRequired Then
            Return DataGridView1.Invoke(New removeItem_delegate(AddressOf removeItem), {name})
        Else
            Dim theRow As DataGridViewRow
            If name = "" Then
                theRow = DataGridView1.CurrentRow
            Else
                theRow = (From a As DataGridViewRow In DataGridView1.Rows Where a.Cells(0).Value = name).FirstOrDefault()
            End If

            'Check if we got anything
            If theRow Is Nothing Then Return False
            Using db As DatabaseEntities = New DatabaseEntities()

                db.Timers.Remove(db.Timers.Find(name))
                db.SaveChanges()
                refreshGrid()
            End Using

            Return True

        End If

    End Function
    Private Delegate Function AddItem_delegate( _
         ByVal tName As String _
        , ByVal tDelay As Nullable(Of Integer) _
        , ByVal tAction As String _
        , ByVal tRepeat As Nullable(Of Integer) _
        , ByVal tEnable As Nullable(Of Boolean) _
    )
    Private Function addItem( _
        Optional ByVal tName As String = "" _
        , Optional ByVal tDelay As Nullable(Of Integer) = 0 _
        , Optional ByVal tAction As String = "" _
        , Optional ByVal tRepeat As Nullable(Of Integer) = 0 _
        , Optional ByVal tEnable As Nullable(Of Boolean) = True _
    )
        Dim result As Boolean = True
        If DataGridView1.InvokeRequired Then
            result = DataGridView1.Invoke(New AddItem_delegate(AddressOf addItem), {tName, tDelay, tAction, tRepeat, tEnable})
        Else
            'Sanity check: Is our name even valid?
            If tName Is Nothing Or tName.Length > 25 Or tName.Length = 0 Then Return False



            Using db As DatabaseEntities = New DatabaseEntities()

                'Try to find the timer
                Dim theTimer As Timer = (From a As Timer In db.Timers Where a.Name = tName).FirstOrDefault()

                If theTimer Is Nothing Then
                    theTimer = New Timer()

                    'set defaults
                    theTimer.Name = tName
                    theTimer.Enabled = True
                    theTimer.Repeat = 1
                    theTimer.RepeatSeconds = 0
                    theTimer.NextTrigger = Now
                    theTimer.Action = ""
                    db.Timers.Add(theTimer)

                    'TimerBindingSource.Add(theTimer)

                End If

                'Set the new values
                If Not tDelay Is Nothing Then theTimer.RepeatSeconds = tDelay
                If Not tAction Is Nothing Then theTimer.Action = tAction
                If Not tRepeat Is Nothing Then theTimer.Repeat = tRepeat
                If Not tEnable Is Nothing Then theTimer.Enabled = tEnable

                'Update the Next Trigger
                theTimer.NextTrigger = Now.AddSeconds(theTimer.RepeatSeconds)

                'Now try to save the value
                Try
                    TimerBindingSource.EndEdit()
                    'db.Entry(theTimer).State = Entity.EntityState.Modified
                    db.SaveChanges()

                Catch ex As Exception
                    Return False
                End Try

            End Using
            refreshGrid()
            'Seems we made it to the end!
            Return True


        End If
        Return result
    End Function
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        ' Clear the row error in case the user presses ESC.   
        DataGridView1.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        'Validate the entry according to the column we're editing
        'Get the editing column
        Dim column As DataGridViewColumn = DataGridView1.Columns(e.ColumnIndex)
        If Not DataGridView1.IsCurrentCellInEditMode Then Exit Sub
        Select Case column.DataPropertyName
            Case "Name"
                'Search for timers that have the same name
                Dim name As String = e.FormattedValue
                Dim countThreshhold As Integer = 0
                'increase the threshold if we're not editing a new record
                If e.RowIndex <> DataGridView1.NewRowIndex Then countThreshhold += 1
                Dim hasSameName As Boolean = False
                Using db As DatabaseEntities = New DatabaseEntities()
                    hasSameName = (From a In db.Timers Where a.Name = name).ToList().Count > countThreshhold

                End Using
                If hasSameName Then
                    e.Cancel = True
                    DataGridView1.Rows(e.RowIndex).ErrorText = "Timer Name must be Unique"
                End If
        End Select
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim updatedTimer As Timer = DataGridView1.CurrentRow.DataBoundItem
        If updatedTimer.Name = "" Then Exit Sub
        Using db As DatabaseEntities = New DatabaseEntities()
            'Retrieve the matching item
            Dim theTimer As Timer = db.Timers.Find(updatedTimer.Name)
            If Not theTimer Is Nothing Then
                'Update the editable parts of the timer
                'Check if it was the Enabled flag that was updated. If so, update the trigger time
                If theTimer.Enabled <> updatedTimer.Enabled Then theTimer.NextTrigger = DateTime.Now.AddSeconds(updatedTimer.RepeatSeconds)
                theTimer.Enabled = updatedTimer.Enabled
                theTimer.Repeat = updatedTimer.Repeat
                theTimer.RepeatSeconds = updatedTimer.RepeatSeconds
                theTimer.Action = updatedTimer.Action
            End If

            'Save the changes
            db.SaveChanges()
        End Using
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        If DataGridView1.SelectedRows.Count = 0 Or Not DataGridView1.Focused Then Exit Sub
        'TimerBindingSource.Position = DataGridView1.SelectedRows(0).Index
        If DataGridView1.SelectedRows(0).IsNewRow Then
            'DataGridView1.CurrentCell = DataGridView1.Item(0, DataGridView1.NewRowIndex)
            If Not DataGridView1.CurrentCell Is Nothing Then
                If DataGridView1.CurrentCell.ColumnIndex = 0 Then
                    DataGridView1.BeginEdit(False)
                End If
            End If


        Else
            'Don't do anything if there isn't a specific cell selected
            If DataGridView1.CurrentCell Is Nothing Then Exit Sub
            'Check if this cell is one that we allow direct editing
            Select Case DataGridView1.CurrentCell.OwningColumn.DataPropertyName
                Case "Enabled", "Repeat", "RepeatSeconds"
                    DataGridView1.BeginEdit(False)
            End Select
        End If
        Using db As DatabaseEntities = New DatabaseEntities()
            db.SaveChanges()

        End Using
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        'Fill in the default Timer info
        With e.Row
            .Cells(1).Value = False
            .Cells(2).Value = 1
            .Cells(3).Value = 0
            .Cells(4).Value = Now
            .Cells(5).Value = ""

        End With
    End Sub

    Public Overrides Sub BotStatusUpdated(ByVal status As String)
        'We don't want timers to run while not connected

        Select Case status
            Case "Connected"
                timerEnabled = True
            Case "Disconnected"
                timerEnabled = False
        End Select
    End Sub



    Public Overrides Sub AddToExpressionContext(ByRef theContext As TinyExe.Context)
        expressionContextMain = theContext
        expressionContextMain.Functions.Add("addtimer", New TinyExe.StaticFunction("addTimer", AddressOf _AddTimer, 3, 5, "Name, {Delay=0}, Action, {Repeat=0}, {Enable=true}. Adds (or updates) a timer called Name that will trigger in Delay seconds with Action, repeating Repeat times if Enabled."))
        expressionContextMain.Functions.Add("deltimer", New TinyExe.StaticFunction("delTimer", AddressOf _deleteTimer, 1, 1, "Name. Deletes timer called Name."))


    End Sub


    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not timerEnabled Then Exit Sub
        'Each tick, we check if we need to trigger an action
        Dim triggeredEvents As List(Of Timer)
        Using db As DatabaseEntities = New DatabaseEntities()
            triggeredEvents = (From a In db.Timers Where a.Enabled And a.NextTrigger < Now And a.Repeat >= -1).ToList()
            'Re-filter the events in case the DB Backend is being stupid
            triggeredEvents = (From a In triggeredEvents Where a.NextTrigger < Now).ToList()

            'First, lets see if we even got any
            If triggeredEvents.Count = 0 Then Exit Sub

            'Do all the triggered events
            For Each item As Timer In triggeredEvents

                'Ripped from CommandInterpreter
                'Note that since timers aren't invoked by a chat user, local variables such as $num and $arg and $user
                'will NOT be populated!

                expressionContextMain.PushScope(expressionContextMain.getScope(-1))

                'Prepare to execute actions
                Dim Actions As String = item.Action, Result As String = ""

                If Actions Is Nothing Then Actions = ""

                'Do the Actions
                For Each Action In Actions.Replace(Chr(10), "").Split(Chr(13))

                    If Action.StartsWith("=") Then
                        Dim eval As New TinyExe.Expression(Action.Substring(1), expressionContextMain)
                        If eval.Errors.Count > 0 Then
                            Result += ("Error in expression: " & eval.Errors(0).Message)
                        Else
                            Dim resultTemp = eval.Eval()
                            If Not resultTemp Is Nothing Then
                                Result += (resultTemp.ToString()) + vbCrLf
                            End If

                        End If
                    Else
                        Result += Action + vbCrLf
                    End If

                Next
                expressionContextMain.PopScope()
                Do_SendChatMessage(Result)

                ' Okay, now update the timer

                'Decrease the repeat count if > 0
                If item.Repeat > 0 Then item.Repeat -= 1

                'If Repeat = 0, then disable
                If item.Repeat = 0 Then item.Enabled = False

                'If item still has repeats, is indefinitely repeating (-1) and is still enabled, schedule the next repeat
                If item.Enabled And item.Repeat <> 0 And item.RepeatSeconds > 0 Then item.NextTrigger = Now.AddSeconds(item.RepeatSeconds)



            Next
            db.SaveChanges()


        End Using
        refreshGrid()
    End Sub

    'Add/Edit a timer command. Returns true on success, false on fail
    Public Function _AddTimer(ByVal ps As Object())
        'Parameters, in order:
        Dim tName As String = ""
        Dim tDelay As Nullable(Of Integer) = 0
        Dim tAction As String = ""
        Dim tRepeat As Nullable(Of Integer) = 0
        Dim tEnable As Nullable(Of Boolean) = True

        'At minimum we need a name, and preferably an action
        'We're guarenteed to have been passed at least a 3-long array (due to settings), so:
        tName = ps(0)
        If Not ps(1) Is Nothing Then Integer.TryParse(ps(1).ToString(), tDelay)
        tAction = ps(2)

        If ps.Count() > 3 Then Integer.TryParse(ps(3).ToString(), tRepeat)
        If ps.Count() > 4 Then tEnable = ps(4)

        Return addItem(tName, tDelay, tAction, tRepeat, tEnable)

    End Function


    Public Function _deleteTimer(ByVal ps As Object())

        Dim tName As String = ps(0)

        'Sanity check: Is our name even valid?
        If tName Is Nothing Or tName.Length > 25 Or tName.Length = 0 Then Return False

        'Try to find the timer
        'Dim theTimer As Timer = (From a In db.Timers Where a.Name = tName).FirstOrDefault()

        'if it doesn't exist, succeed, since we can't delete what's not there
        'If theTimer Is Nothing Then Return True

        Try
            removeItem(tName)
            'db.DeleteObject(theTimer)
            'TimerBindingSource.Remove(theTimer)
            'Save the deletion
            'db.SaveChanges()
            'refreshGrid(True)
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function





    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        removeItem(DataGridView1.SelectedRows(0).DataBoundItem.Name)
    End Sub


End Class
