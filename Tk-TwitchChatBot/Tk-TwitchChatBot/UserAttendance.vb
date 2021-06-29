Imports TkChatBotPlugin_Base
Imports TkChatBot_Database

Public Class UserAttendance : Inherits BotPluginTemplate
    Private isUpdatingSelection As Boolean = False
    Private lastUserlistUpdate As DateTime
    Public Overrides Sub UpdateUsersList()
        lastUserlistUpdate = Now
        MyBase.UpdateUsersList()
        refreshList()

    End Sub

    Public Overrides Sub AddToExpressionContext(ByRef theContext As TinyExe.Context)
        MyBase.AddToExpressionContext(theContext)
        lastUserlistUpdate = Now
        theContext.Functions.Add("setpermissionlevel", New TinyExe.StaticFunction("SetPermissionLevel", AddressOf _setPermissionLevel, 2, 2, "Sets the permission level of the given user"))
        theContext.Functions.Add("getpermissionlevel", New TinyExe.StaticFunction("GetPermissionLevel", AddressOf _getPermissionLevel, 1, 1, "Gets the permission level of the given user"))
        theContext.Functions.Add("isonline", New TinyExe.StaticFunction("isOnline", AddressOf _isOnline, 1, 1, "Returns the (detected) online status of the given user"))
        theContext.Functions.Add("listusers", New TinyExe.StaticFunction("ListUsers", AddressOf _ListUsers, 0, 3, "[includeOffline = False], [Attribute=none], [Value=""""]. Returns a space-separated list of users, optionally including offline users, optionally filtering to a particular attribute, optionally filtering to a compared value (=, !=, <, <=, >, >= are allowed).", False))

        'While we're at it, refresh the list for the first time
        UpdateUsersList()
    End Sub

    Private Delegate Sub refreshList_Delegate()
    Private Sub refreshList()
        If UserList.InvokeRequired Then
            UserList.BeginInvoke(New refreshList_Delegate(AddressOf refreshList))
        Else

            'Save the currently selected item
            Dim selecteduser As String = Nothing

            If UserList.SelectedItems.Count > 0 Then selecteduser = UserList.SelectedItems(0).Text

            'Clear out list
            UserList.Items.Clear()
            'Should already be updated
            'Using db As New DatabaseEntities()
            '    _Users = db.Users.ToList()
            'End Using
            For Each usr In _Users
                Dim i As New ListViewItem(usr.UserName)
                i.SubItems.Add(usr.PermissionLevel)
                UserList.Items.Add(i)

            Next

            'Restore the selection if selected
            If Not selecteduser Is Nothing Then
                For Each item As ListViewItem In UserList.Items
                    If item.Text = selecteduser Then
                        item.Selected = True
                        item.EnsureVisible()
                    End If

                Next
            End If
        End If

    End Sub

    Private Sub UserList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserList.SelectedIndexChanged
        'Load up the selected item
        If UserList.SelectedItems.Count > 0 Then
            Dim username As String = UserList.SelectedItems(0).Text
            Dim theuser = (From a In _Users Where a.UserName = username).FirstOrDefault()
            isUpdatingSelection = True
            iPermissionLevel.Value = theuser.PermissionLevel
            iFirstSeen.Text = theuser.FirstSeen.ToString("MM/dd/yy" & vbCrLf & "hh:mm:ss tt")
            iFirstSeenToday.Text = theuser.FirstSeenThisSession.ToString("MM/dd/yy" & vbCrLf & "hh:mm:ss tt")
            iLastSeen.Text = theuser.LastSeen.ToString("MM/dd/yy" & vbCrLf & "hh:mm:ss tt")

            isUpdatingSelection = False

        End If
    End Sub

    Private Sub iPermissionLevel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iPermissionLevel.ValueChanged
        'Update the DB with the new value
        If UserList.SelectedItems.Count > 0 And Not isUpdatingSelection Then
            Dim username As String = UserList.SelectedItems(0).Text

            Using db As New DatabaseEntities()

                Dim theuser = (From a In db.Users Where a.UserName = username).FirstOrDefault()

                theuser.PermissionLevel = iPermissionLevel.Value
                db.SaveChanges()
            End Using

            UpdateUsersList()
            'Do_SendChatMessage(username & " now has permission level " & iPermissionLevel.Value)
        End If
    End Sub

    Private Function _setPermissionLevel(ByVal ps As Object())
        Dim userName As String = ps(0)
        Dim db As DatabaseEntities = New DatabaseEntities()

        Dim theuser = (From a In db.Users Where a.UserName.ToLower() = userName.ToLower()).FirstOrDefault()
        'exit out if an invalid user was specified
        'If theuser Is Nothing Then Return Nothing

        'Check if this user is known, add them to the list if not
        If theuser Is Nothing Then
            'Need to create them
            theuser = New User()
            With theuser
                .UserName = userName
                .PermissionLevel = 0
                .FirstSeen = Now

            End With
            'Add them to the DB
            db.Users.Add(theuser)
        End If


        isUpdatingSelection = True

        Integer.TryParse(ps(1), theuser.PermissionLevel)
        db.SaveChanges()
        Do_DBSaveChanges()
        refreshList()
        isUpdatingSelection = False
        Return Nothing
    End Function

    Private Function _getPermissionLevel(ByVal ps As Object())
        Dim userName As String = ps(0)
        Dim theuser = (From a In _Users Where a.UserName.ToLowerInvariant() = userName.ToLowerInvariant()).FirstOrDefault()
        'exit out if an invalid user was specified
        If theuser Is Nothing Then Return Nothing

        Return theuser.PermissionLevel
    End Function

    Private Function _isOnline(ByVal ps As Object())
        Dim foundUser As User
        Dim userName As String = ps(0)
        If _Users Is Nothing Or userName Is Nothing Then Return False
        foundUser = (From a As User In _Users Where a.UserName.ToLower() = userName.ToLower()).FirstOrDefault()

        If foundUser Is Nothing Then Return False
        'For some reason, perfect equality isn't working. database Resolution error maybe?
        Return foundUser.LastSeen >= lastUserlistUpdate.AddSeconds(-1)

    End Function

    Private Function _ListUsers(ByVal ps As Object())
        'List users, space separated
        Dim theUsers As List(Of User)

        'Parameters (All optional):
        Dim offlineToo As Boolean = False
        Dim attribute As String = ""
        Dim value As String = ""
        Dim lastSeenCompare As DateTime = lastUserlistUpdate.AddSeconds(-1)

        If ps.Length > 0 Then Boolean.TryParse(ps(0).ToString(), offlineToo)
        If ps.Length > 1 Then attribute = ps(1).ToString()
        If ps.Length > 2 Then value = ps(0).ToString()

        'Alright, set up the basic search
        Using db As New DatabaseEntities()
            theUsers = (From a As User In db.Users
                           Where offlineToo Or (a.LastSeen >= lastSeenCompare)
                           ).ToList()

            'if we're not searching attributes, don't do anything
            If Len(attribute) > 0 Then
                'Okay, filter the users that have that attribute
                theUsers = (From a In theUsers
                           Join b As UserAttribute In db.UserAttributes On a.UserName Equals b.UserName
                           Where b.Key.ToLower() = attribute.ToLower()
                           Select a).ToList()

                'Now, detect if we're going to compare
                If Len(value) > 0 Then
                    Dim operation As String = ""
                    'Grab up to two operation characters from the beginning of the string
                    For i = 1 To 2
                        If Len(value) > 0 Then
                            'Check for an operator symbol
                            If InStr("=!<>", value(0)) > -1 Then
                                'Cool, found an operator, lets add it to the operation
                                operation += value(0)
                                'Remove that from the value
                                value = Mid(value, 2)
                            End If
                        End If
                    Next

                    'Alright, lets see what we can do!
                    Select Case operation
                        Case "", "="
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value = value Or b.Value Is Nothing And value = "")
                                        Select a
                                        ).ToList()
                        Case "!=", "<>"
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value <> value Or Not b.Value Is Nothing And value = "")
                                        Select a
                                        ).ToList()

                        Case ">"
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value > value Or Not b.Value Is Nothing And value = "")
                                        Select a
                                        ).ToList()

                        Case ">=", "=>"
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value >= value Or Not b.Value Is Nothing And value = "")
                                        Select a
                                        ).ToList()
                        Case "<"
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value < value Or Not b.Value Is Nothing And value = "")
                                        Select a
                                        ).ToList()
                        Case "<=", "=<"
                            theUsers = (From a In theUsers
                                        Join b In db.UserAttributes On a.UserName Equals b.UserName
                                        Where b.Key = attribute And (b.Value <= value)
                                        Select a
                                        ).ToList()

                        Case Else
                            'Huh, specified something not supported, empty the list
                            theUsers = New List(Of User)
                    End Select

                End If

            End If
        End Using

        Dim result As String = ""

        'Alright, lets concatenate our users
        result = String.Join(" ", (From a In theUsers Select a.UserName).ToArray())


        Return result
    End Function

    Private Sub DeleteThisUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisUserToolStripMenuItem.Click
        'Load up the selected item
        If UserList.SelectedItems.Count > 0 Then
            Dim username As String = UserList.SelectedItems(0).Text
            Dim theuser = (From a In _Users Where a.UserName = username).FirstOrDefault()

            If MsgBox("Delete " & username & "?" & vbCrLf & "This will also delete associated attributes!", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Using db As New DatabaseEntities()
                db.Entry((From a In db.Users Where a.UserName = username).FirstOrDefault()).State = Entity.EntityState.Deleted

                For Each attr In From a In db.UserAttributes Where a.UserName = username

                    db.Entry(attr).State = Entity.EntityState.Deleted
                Next
                db.SaveChanges()
                _Users.Remove(theuser)
            End Using
            refreshList()
            Do_DBSaveChanges()
        End If

    End Sub

    Private Sub DeleteAllOfflineUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllOfflineUsersToolStripMenuItem.Click
        'Load up the selected item
        If UserList.SelectedItems.Count > 0 Then
            Using db As New DatabaseEntities()
                Dim foundUser As User()
                Dim compareDate As DateTime = lastUserlistUpdate.AddSeconds(-1)
                foundUser = (From a As User In db.Users Where a.LastSeen < compareDate).ToArray()

                'For some reason, perfect equality isn't working. database Resolution error maybe?


                If MsgBox("Delete " & foundUser.Count() & " Offline users?" & vbCrLf & "This will also delete associated attributes!", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

                For Each usr In foundUser

                    db.Entry(usr).State = Entity.EntityState.Deleted

                    For Each attr In From a In db.UserAttributes Where a.UserName = usr.UserName

                        db.Entry(attr).State = Entity.EntityState.Deleted
                    Next
                    db.SaveChanges()
                    _Users.Remove((From a In _Users Where a.UserName = usr.UserName).FirstOrDefault())
                Next
            End Using
            refreshList()
            Do_DBSaveChanges()
        End If
    End Sub

    Private Sub DeleteALLUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteALLUsersToolStripMenuItem.Click
        'Load up the selected item
        If UserList.SelectedItems.Count > 0 Then
            Using db As New DatabaseEntities()
                Dim foundUser As User()
                Dim compareDate As DateTime = lastUserlistUpdate.AddSeconds(-1)
                foundUser = (From a As User In db.Users).ToArray()

                If MsgBox("Delete ALL " & foundUser.Count() & " users?" & vbCrLf & "This will also delete associated attributes!" & vbCrLf & "Note: Any users currently in Chat will be immediately re-added.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

                For Each usr In foundUser

                    db.Entry(usr).State = Entity.EntityState.Deleted

                    For Each attr In From a In db.UserAttributes Where a.UserName = usr.UserName

                        db.Entry(attr).State = Entity.EntityState.Deleted
                    Next
                    db.SaveChanges()
                    _Users.Remove((From a In _Users Where a.UserName = usr.UserName).FirstOrDefault())
                Next
            End Using
            refreshList()
            Do_DBSaveChanges()
        End If
    End Sub
End Class