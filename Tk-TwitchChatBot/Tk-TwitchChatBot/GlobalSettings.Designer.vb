<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GlobalSettings
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
        Me.chatSendQueue = New System.Windows.Forms.ListBox()
        Me.chatSendDelay = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chatMaxLines = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.StartupExpressions = New System.Windows.Forms.TextBox()
        CType(Me.chatSendDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.chatMaxLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'chatSendQueue
        '
        Me.chatSendQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatSendQueue.FormattingEnabled = True
        Me.chatSendQueue.Location = New System.Drawing.Point(3, 16)
        Me.chatSendQueue.Name = "chatSendQueue"
        Me.chatSendQueue.Size = New System.Drawing.Size(318, 75)
        Me.chatSendQueue.TabIndex = 1
        '
        'chatSendDelay
        '
        Me.chatSendDelay.DecimalPlaces = 1
        Me.chatSendDelay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatSendDelay.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.chatSendDelay.Location = New System.Drawing.Point(3, 16)
        Me.chatSendDelay.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.chatSendDelay.Minimum = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.chatSendDelay.Name = "chatSendDelay"
        Me.chatSendDelay.Size = New System.Drawing.Size(92, 20)
        Me.chatSendDelay.TabIndex = 0
        Me.chatSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chatSendDelay.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chatSendDelay)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 44)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bot Send Rate"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chatSendQueue)
        Me.GroupBox2.Location = New System.Drawing.Point(116, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 94)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chat Send Queue"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chatMaxLines)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(98, 44)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Max Chat Lines"
        '
        'chatMaxLines
        '
        Me.chatMaxLines.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tk_TwitchChatBot.My.MySettings.Default, "chatMaxLines", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chatMaxLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chatMaxLines.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.chatMaxLines.Location = New System.Drawing.Point(3, 16)
        Me.chatMaxLines.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.chatMaxLines.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.chatMaxLines.Name = "chatMaxLines"
        Me.chatMaxLines.Size = New System.Drawing.Size(92, 20)
        Me.chatMaxLines.TabIndex = 0
        Me.chatMaxLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chatMaxLines.Value = Global.Tk_TwitchChatBot.My.MySettings.Default.chatMaxLines
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.StartupExpressions)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(428, 122)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Startup expressions"
        '
        'StartupExpressions
        '
        Me.StartupExpressions.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tk_TwitchChatBot.My.MySettings.Default, "startupExpressions", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.StartupExpressions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StartupExpressions.Location = New System.Drawing.Point(3, 16)
        Me.StartupExpressions.Multiline = True
        Me.StartupExpressions.Name = "StartupExpressions"
        Me.StartupExpressions.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.StartupExpressions.Size = New System.Drawing.Size(422, 103)
        Me.StartupExpressions.TabIndex = 0
        Me.StartupExpressions.Text = Global.Tk_TwitchChatBot.My.MySettings.Default.startupExpressions
        '
        'GlobalSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 311)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "GlobalSettings"
        Me.Text = "GlobalSettings"
        CType(Me.chatSendDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.chatMaxLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chatSendDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents chatSendQueue As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chatMaxLines As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents StartupExpressions As System.Windows.Forms.TextBox
End Class
