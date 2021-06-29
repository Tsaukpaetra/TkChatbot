Public Class Form1

    Private Sub PlaySelected_Click(sender As Object, e As EventArgs) Handles PlaySelected.Click

        WMP.URL = "C:\Users\Anthony\Music\Awkward Marina - Sombra's Door.mp3"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        WMP.settings.volume = 100
        refreshSongList()
    End Sub

    Sub refreshSongList()
        Using db As TkChatBot_Database.DatabaseEntities = New TkChatBot_Database.DatabaseEntities()
            SongListBinding.DataSource = (From a In db.UserAttributes
                                          Where a.UserName = ".wav").ToList()
        End Using
    End Sub

End Class
