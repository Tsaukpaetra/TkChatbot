<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuthDialog
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bot_Username = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bot_Oauth = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.bot_channel = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bot_server = New System.Windows.Forms.TextBox()
        Me.OkAction = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.bot_sslEnabled = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bot_Username)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(260, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bot Username"
        '
        'bot_Username
        '
        Me.bot_Username.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tk_TwitchChatBot.My.MySettings.Default, "Bot_Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.bot_Username.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bot_Username.Location = New System.Drawing.Point(6, 16)
        Me.bot_Username.Name = "bot_Username"
        Me.bot_Username.Size = New System.Drawing.Size(248, 20)
        Me.bot_Username.TabIndex = 0
        Me.bot_Username.Text = Global.Tk_TwitchChatBot.My.MySettings.Default.Bot_Name
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bot_Oauth)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(260, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OAuth Key"
        '
        'bot_Oauth
        '
        Me.bot_Oauth.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tk_TwitchChatBot.My.MySettings.Default, "Bot_OAuth", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.bot_Oauth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bot_Oauth.Location = New System.Drawing.Point(6, 16)
        Me.bot_Oauth.Name = "bot_Oauth"
        Me.bot_Oauth.Size = New System.Drawing.Size(248, 20)
        Me.bot_Oauth.TabIndex = 0
        Me.bot_Oauth.Text = Global.Tk_TwitchChatBot.My.MySettings.Default.Bot_OAuth
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.bot_channel)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.GroupBox3.Size = New System.Drawing.Size(260, 45)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Channel"
        '
        'bot_channel
        '
        Me.bot_channel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tk_TwitchChatBot.My.MySettings.Default, "Bot_Channel", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.bot_channel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bot_channel.Location = New System.Drawing.Point(6, 16)
        Me.bot_channel.Name = "bot_channel"
        Me.bot_channel.Size = New System.Drawing.Size(248, 20)
        Me.bot_channel.TabIndex = 0
        Me.bot_channel.Text = Global.Tk_TwitchChatBot.My.MySettings.Default.Bot_Channel
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bot_server)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 165)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.GroupBox4.Size = New System.Drawing.Size(195, 45)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Server"
        '
        'bot_server
        '
        Me.bot_server.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tk_TwitchChatBot.My.MySettings.Default, "Bot_Server", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.bot_server.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bot_server.Location = New System.Drawing.Point(6, 16)
        Me.bot_server.Name = "bot_server"
        Me.bot_server.Size = New System.Drawing.Size(183, 20)
        Me.bot_server.TabIndex = 0
        Me.bot_server.Text = Global.Tk_TwitchChatBot.My.MySettings.Default.Bot_Server
        '
        'OkAction
        '
        Me.OkAction.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkAction.Location = New System.Drawing.Point(13, 217)
        Me.OkAction.Name = "OkAction"
        Me.OkAction.Size = New System.Drawing.Size(259, 32)
        Me.OkAction.TabIndex = 5
        Me.OkAction.Text = "Connect"
        Me.OkAction.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.bot_sslEnabled)
        Me.GroupBox5.Location = New System.Drawing.Point(218, 165)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(48, 38)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "SSL"
        '
        'bot_sslEnabled
        '
        Me.bot_sslEnabled.AutoSize = True
        Me.bot_sslEnabled.Checked = Global.Tk_TwitchChatBot.My.MySettings.Default.Bot_sslEnabled
        Me.bot_sslEnabled.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tk_TwitchChatBot.My.MySettings.Default, "Bot_sslEnabled", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.bot_sslEnabled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bot_sslEnabled.Location = New System.Drawing.Point(3, 16)
        Me.bot_sslEnabled.Name = "bot_sslEnabled"
        Me.bot_sslEnabled.Size = New System.Drawing.Size(42, 19)
        Me.bot_sslEnabled.TabIndex = 0
        Me.bot_sslEnabled.UseVisualStyleBackColor = True
        '
        'AuthDialog
        '
        Me.AcceptButton = Me.OkAction
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.OkAction)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AuthDialog"
        Me.Text = "AuthDialog"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bot_Username As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bot_Oauth As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents bot_channel As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents bot_server As System.Windows.Forms.TextBox
    Friend WithEvents OkAction As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents bot_sslEnabled As CheckBox
End Class
