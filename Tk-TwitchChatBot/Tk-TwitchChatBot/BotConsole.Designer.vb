<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotConsole
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
        Me.cmdPrompt = New TinyExe.CommandPrompt()
        Me.SuspendLayout()
        '
        'cmdPrompt
        '
        Me.cmdPrompt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdPrompt.Location = New System.Drawing.Point(0, 0)
        Me.cmdPrompt.Name = "cmdPrompt"
        Me.cmdPrompt.Size = New System.Drawing.Size(284, 261)
        Me.cmdPrompt.TabIndex = 0
        Me.cmdPrompt.Text = "Bot Console (Type ""help()"" for help)" & Global.Microsoft.VisualBasic.ChrW(10) & "="
        Me.cmdPrompt.WordWrap = False
        '
        'BotConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.cmdPrompt)
        Me.Name = "BotConsole"
        Me.Text = "Bot Console"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrompt As TinyExe.CommandPrompt
End Class
