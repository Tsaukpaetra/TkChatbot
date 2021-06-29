Public Class GlobalSettings

    Private Sub chatSendDelay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chatSendDelay.ValueChanged, chatMaxLines.ValueChanged
        'Don't do anything if visibility is false (i.e. form is loading)
        If Me.Visible = False Then Exit Sub
        My.Settings.chat_SendDelay = chatSendDelay.Value * 1000
        My.Settings.Save()

    End Sub

    Private Sub GlobalSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()

    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        chatSendDelay.Value = My.Settings.chat_SendDelay / 1000
    End Sub
End Class