Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Button1.Text = Me.MinimumSize.Width & "," & Me.MinimumSize.Height
        Button2.Text = Me.Size.Width & "," & Me.Size.Height
        Button3.Text = Me.MaximumSize.Width & "," & Me.MaximumSize.Height
    End Sub
End Class