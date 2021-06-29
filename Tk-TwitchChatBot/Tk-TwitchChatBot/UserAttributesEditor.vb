Imports TkChatBot_Database

Public Class UserAttributesEditor

    Private DisplayAll As Boolean = False
    Public Overrides Sub UpdateUsersList()

        MyBase.UpdateUsersList()
        refreshList()

    End Sub

    Public Overrides Sub AddToExpressionContext(ByRef theContext As TinyExe.Context)
        MyBase.AddToExpressionContext(theContext)

        'While we're at it, refresh the list for the first time
        UpdateUsersList()
    End Sub

    Private Delegate Sub refreshList_Delegate()
    Private Sub refreshList()
        'Don't update the list if we're currently editing
        If UserAttributeDataGridView.IsCurrentCellInEditMode Then Exit Sub
        If UserList.InvokeRequired Then
            UserList.BeginInvoke(New refreshList_Delegate(AddressOf refreshList))
        Else

            'Save the currently selected item
            Dim selecteduser As String = Nothing
            Dim selectedAC_Column As Integer = -1
            Dim selectedAC_Row As Integer = -1

            'Try to save positions of things
            If UserList.SelectedItems.Count > 0 Then selecteduser = UserList.SelectedItems(0)
            If Not UserAttributeDataGridView.CurrentCell Is Nothing Then
                selectedAC_Column = UserAttributeDataGridView.CurrentCell.ColumnIndex
                selectedAC_Row = UserAttributeDataGridView.CurrentCell.RowIndex
            End If


            'Clear out list
            UserList.Items.Clear()
            'Should already be updated

            'Determine which method of listing to use. By default we use the Users list, but if ShowAll is checked, we'll use the whole UserAttributes table
            If DisplayAll Then

                Using db As New DatabaseEntities()
                    For Each usr In From a In db.UserAttributes Select a.UserName Distinct
                        UserList.Items.Add(usr)
                    Next
                End Using
            Else
                For Each usr In _Users
                    UserList.Items.Add(usr.UserName)

                Next

            End If

            'Restore the selection if selected
            If Not selecteduser Is Nothing Then
                UserList.SelectedItem = selecteduser
            End If
            If selectedAC_Column > -1 And UserAttributeDataGridView.Rows.Count > selectedAC_Row Then
                Try
                    UserAttributeDataGridView.CurrentCell = UserAttributeDataGridView.Rows(selectedAC_Row).Cells(selectedAC_Column)
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub
    Private Sub UserList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UserList.SelectedIndexChanged
        Using db As DatabaseEntities = New DatabaseEntities()
            'db.Entry(db.Timers).Reload()
            UserAttributeBindingSource.DataSource = (From a In db.UserAttributes.ToList()
                                                     Where a.UserName = UserList.SelectedItem).ToList()
        End Using
    End Sub

    Private Sub UserAttributeDataGridView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles UserAttributeDataGridView.CellBeginEdit
        'Can't edit the key once it's been set
        If e.ColumnIndex = 0 And e.RowIndex <> UserAttributeDataGridView.NewRowIndex Then e.Cancel = True
    End Sub

    Private Sub UserAttributeDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles UserAttributeDataGridView.CellEndEdit
        'Clear any errors (since apparently we passed validation
        UserAttributeDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        'Don't do anything if we're not dirty
        If Not UserAttributeDataGridView.IsCurrentRowDirty Then Exit Sub
        'Lets save the entry
        Dim theChangedAttribute As UserAttribute


        'First, find the entry
        Dim theAttribute As UserAttribute
        theChangedAttribute = UserAttributeDataGridView.CurrentRow.DataBoundItem
        Dim whatChanged As Integer = e.ColumnIndex
        Dim targetUser As String = UserList.SelectedItem

        'Check if we're in the New Row
        If theChangedAttribute Is Nothing Then Exit Sub

        Using db As New DatabaseEntities()
            theAttribute = (From a In db.UserAttributes
                            Where a.UserName = targetUser _
                            And ((a.Key = theChangedAttribute.Key And whatChanged = 1) _
                            Or (a.Value = theChangedAttribute.Value And whatChanged = 0))).FirstOrDefault()
            'Check if we got anything (if not, create new!)
            If theAttribute Is Nothing Then
                theAttribute = New UserAttribute()
                theAttribute.UserName = targetUser
                db.Entry(theAttribute).State = Entity.EntityState.Added
            End If
            'Update the entry
            theAttribute.Key = theChangedAttribute.Key
            theAttribute.Value = theChangedAttribute.Value

            'Save the change
            db.SaveChanges()
        End Using
    End Sub


    Private Sub UserAttributeDataGridView_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles UserAttributeDataGridView.CellValidating
        'Don't try to validate cells if we're not editing them!
        If Not UserAttributeDataGridView.IsCurrentCellInEditMode Then Exit Sub
        With UserAttributeDataGridView.CurrentRow
            If e.ColumnIndex = 0 And e.FormattedValue = "" Then

                .ErrorText = "Key can't be empty!"
                e.Cancel = True
            End If

            'Check if this key already exists
            Using db As DatabaseEntities = New DatabaseEntities()
                Dim theKey As String = e.FormattedValue
                Dim targetUser As String = UserList.SelectedItem
                If (From a In db.UserAttributes
                                                         Where a.UserName = targetUser _
                                                         And a.Key = theKey).Count > 0 Then
                    .ErrorText = "Cannot duplicate key! This attribute already exists for this user."
                    e.Cancel = True
                End If
            End Using

        End With
    End Sub


    Private Sub UserAttributeDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles UserAttributeDataGridView.SelectionChanged
        'If we don't have anything selected, do nothing
        If UserAttributeDataGridView.CurrentCell Is Nothing Then Exit Sub
        'Check if we're in the new row. If so, select the Key
        If UserAttributeDataGridView.CurrentCell.RowIndex = UserAttributeDataGridView.NewRowIndex Then
            UserAttributeDataGridView.CurrentCell = UserAttributeDataGridView.Rows(UserAttributeDataGridView.NewRowIndex).Cells(0)
        End If
    End Sub

    Private Sub UserAttributeDataGridView_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles UserAttributeDataGridView.UserDeletingRow
        'Okay, requested to delete an attribute
        Using db As DatabaseEntities = New DatabaseEntities()
            Dim theKey As String = e.Row.DataBoundItem.Key
            Dim targetUser As String = e.Row.DataBoundItem.UserName
            Dim targetAttribute = (From a In db.UserAttributes
                                   Where a.UserName = targetUser _
                                   And a.Key = theKey).FirstOrDefault()
            If Not targetAttribute Is Nothing Then
                db.Entry(targetAttribute).State = Entity.EntityState.Deleted
                db.SaveChanges()

            End If
        End Using
        'Update the list just in case
        refreshList()
    End Sub

    Private Sub ShowAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllToolStripMenuItem.Click
        DisplayAll = Not DisplayAll
        refreshList()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        'Just refresh
        refreshList()
    End Sub
End Class
