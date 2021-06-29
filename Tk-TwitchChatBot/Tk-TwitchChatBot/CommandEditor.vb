Imports TkChatBot_Database

Public Class CommandEditor
    Private theCommand As Command

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MsgBox("Form Init with no Command, Can't save Info.")
    End Sub
    Public Sub New(ByVal command As Command)

        ' This call is required by the designer.
        InitializeComponent()

        ' Bind the information about the library Item
        'theLibraryItem = LibraryItem

        CommandBindingSource.Add(command)
        CommandBindingSource.MoveFirst()

        'Set the dialog title
        Me.Text = "(" & command.Id & ")  " & command.Keyword
        theCommand = command

    End Sub


    Private Sub bCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancel.Click

        CommandBindingSource.CancelEdit()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()


    End Sub

    Private Sub bOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bOK.Click
        CommandBindingSource.EndEdit()
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub


    Private Sub CommandEditor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = DialogResult.None And e.CloseReason = CloseReason.UserClosing Then
            Select Case MsgBox("Save changes?", vbYesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                    Exit Sub
                Case MsgBoxResult.Yes
                    CommandBindingSource.EndEdit()
                    Me.DialogResult = DialogResult.OK
                Case MsgBoxResult.No
                    CommandBindingSource.CancelEdit()
                    Me.DialogResult = DialogResult.Cancel
            End Select
        End If
    End Sub

    Private Sub iKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iKeyword.TextChanged
        'Validate entry
        iKeyword.Text = iKeyword.Text.Replace(" ", "")

        'Reset text to black
        iKeyword.ForeColor = Color.Black
        'enable OK button
        bOK.Enabled = True

        'Check if the current text matches another command
        Dim db = New DatabaseEntities()

        Dim keyword As String = iKeyword.Text, id As Integer = theCommand.Id
        Dim dupName As Integer = (From a In db.Commands Where a.Keyword = keyword And a.Id <> id).Count()

        If dupName > 0 Then
            iKeyword.ForeColor = Color.Red
            bOK.Enabled = False

        End If

        'Update title
        Me.Text = "(" & theCommand.Id & ") " & iKeyword.Text

    End Sub
End Class