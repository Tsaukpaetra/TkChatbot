Imports TkChatBot_Database

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommandEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CommandEditor))
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.bOK = New System.Windows.Forms.Button()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.iActions = New System.Windows.Forms.TextBox()
        Me.CommandBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.iKeyword = New System.Windows.Forms.TextBox()
        Me.TableLayoutCoolDown = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.iEnabled = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.iUserCD = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.iGlobalCD = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPermissionsPreconditions = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.iExtraPrecondition = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.iMinPermissionLevel = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.iCooldownMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.CommandBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutCoolDown.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.iUserCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.iGlobalCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPermissionsPreconditions.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.iMinPermissionLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanelBase
        '
        Me.TableLayoutPanelBase.ColumnCount = 1
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.Controls.Add(Me.TableLayoutPanel3, 0, 5)
        Me.TableLayoutPanelBase.Controls.Add(Me.GroupBox7, 0, 4)
        Me.TableLayoutPanelBase.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanelBase.Controls.Add(Me.TableLayoutCoolDown, 0, 1)
        Me.TableLayoutPanelBase.Controls.Add(Me.TableLayoutPermissionsPreconditions, 0, 3)
        Me.TableLayoutPanelBase.Controls.Add(Me.GroupBox8, 0, 2)
        Me.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelBase.Name = "TableLayoutPanelBase"
        Me.TableLayoutPanelBase.RowCount = 6
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(284, 361)
        Me.TableLayoutPanelBase.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.bOK, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.bCancel, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 328)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(278, 30)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'bOK
        '
        Me.bOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bOK.Location = New System.Drawing.Point(96, 3)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(84, 24)
        Me.bOK.TabIndex = 1
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bCancel.Location = New System.Drawing.Point(186, 3)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(89, 24)
        Me.bCancel.TabIndex = 2
        Me.bCancel.Text = "Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.iActions)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(3, 197)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(278, 125)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Actions"
        '
        'iActions
        '
        Me.iActions.AcceptsReturn = True
        Me.iActions.CausesValidation = False
        Me.iActions.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommandBindingSource, "Actions", True))
        Me.iActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iActions.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iActions.Location = New System.Drawing.Point(3, 16)
        Me.iActions.MaxLength = 4000
        Me.iActions.Multiline = True
        Me.iActions.Name = "iActions"
        Me.iActions.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.iActions.Size = New System.Drawing.Size(272, 106)
        Me.iActions.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.iActions, resources.GetString("iActions.ToolTip"))
        Me.iActions.WordWrap = False
        '
        'CommandBindingSource
        '
        Me.CommandBindingSource.DataSource = GetType(Command)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.iKeyword)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 39)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Command Keyword"
        '
        'iKeyword
        '
        Me.iKeyword.CausesValidation = False
        Me.iKeyword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommandBindingSource, "Keyword", True))
        Me.iKeyword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iKeyword.Location = New System.Drawing.Point(3, 16)
        Me.iKeyword.MaxLength = 60
        Me.iKeyword.Name = "iKeyword"
        Me.iKeyword.Size = New System.Drawing.Size(272, 20)
        Me.iKeyword.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.iKeyword, "Word string used to activate the command." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Recommend starting with a symbol (Like" & _
        " ! ) to prevent accidental activation.")
        '
        'TableLayoutCoolDown
        '
        Me.TableLayoutCoolDown.ColumnCount = 3
        Me.TableLayoutCoolDown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutCoolDown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutCoolDown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutCoolDown.Controls.Add(Me.GroupBox4, 0, 0)
        Me.TableLayoutCoolDown.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutCoolDown.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutCoolDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutCoolDown.Location = New System.Drawing.Point(3, 48)
        Me.TableLayoutCoolDown.Name = "TableLayoutCoolDown"
        Me.TableLayoutCoolDown.RowCount = 1
        Me.TableLayoutCoolDown.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutCoolDown.Size = New System.Drawing.Size(278, 44)
        Me.TableLayoutCoolDown.TabIndex = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.iEnabled)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(221, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(54, 38)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Enabled"
        '
        'iEnabled
        '
        Me.iEnabled.AutoSize = True
        Me.iEnabled.CausesValidation = False
        Me.iEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.iEnabled.Checked = True
        Me.iEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.iEnabled.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.CommandBindingSource, "Enabled", True))
        Me.iEnabled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iEnabled.Location = New System.Drawing.Point(3, 16)
        Me.iEnabled.Name = "iEnabled"
        Me.iEnabled.Size = New System.Drawing.Size(48, 19)
        Me.iEnabled.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.iEnabled, "Allow this command to be called in chat." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note that this does not prevent other c" & _
        "ommands from calling it with docmd()")
        Me.iEnabled.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.iUserCD)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(112, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(103, 38)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "User C/D"
        '
        'iUserCD
        '
        Me.iUserCD.CausesValidation = False
        Me.iUserCD.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CommandBindingSource, "UserCD", True))
        Me.iUserCD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iUserCD.Increment = New Decimal(New Integer() {60, 0, 0, 0})
        Me.iUserCD.Location = New System.Drawing.Point(3, 16)
        Me.iUserCD.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.iUserCD.Name = "iUserCD"
        Me.iUserCD.Size = New System.Drawing.Size(97, 20)
        Me.iUserCD.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.iUserCD, resources.GetString("iUserCD.ToolTip"))
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.iGlobalCD)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 38)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Global C/D"
        '
        'iGlobalCD
        '
        Me.iGlobalCD.CausesValidation = False
        Me.iGlobalCD.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CommandBindingSource, "GlobalCD", True))
        Me.iGlobalCD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iGlobalCD.Increment = New Decimal(New Integer() {60, 0, 0, 0})
        Me.iGlobalCD.Location = New System.Drawing.Point(3, 16)
        Me.iGlobalCD.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.iGlobalCD.Name = "iGlobalCD"
        Me.iGlobalCD.Size = New System.Drawing.Size(97, 20)
        Me.iGlobalCD.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.iGlobalCD, resources.GetString("iGlobalCD.ToolTip"))
        '
        'TableLayoutPermissionsPreconditions
        '
        Me.TableLayoutPermissionsPreconditions.ColumnCount = 2
        Me.TableLayoutPermissionsPreconditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPermissionsPreconditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPermissionsPreconditions.Controls.Add(Me.GroupBox6, 0, 0)
        Me.TableLayoutPermissionsPreconditions.Controls.Add(Me.GroupBox5, 0, 0)
        Me.TableLayoutPermissionsPreconditions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPermissionsPreconditions.Location = New System.Drawing.Point(3, 148)
        Me.TableLayoutPermissionsPreconditions.Name = "TableLayoutPermissionsPreconditions"
        Me.TableLayoutPermissionsPreconditions.RowCount = 1
        Me.TableLayoutPermissionsPreconditions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPermissionsPreconditions.Size = New System.Drawing.Size(278, 43)
        Me.TableLayoutPermissionsPreconditions.TabIndex = 10
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.iExtraPrecondition)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(133, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(142, 37)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Preconditions"
        '
        'iExtraPrecondition
        '
        Me.iExtraPrecondition.CausesValidation = False
        Me.iExtraPrecondition.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommandBindingSource, "ExtraPrecondition", True))
        Me.iExtraPrecondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iExtraPrecondition.Location = New System.Drawing.Point(3, 16)
        Me.iExtraPrecondition.MaxLength = 500
        Me.iExtraPrecondition.Name = "iExtraPrecondition"
        Me.iExtraPrecondition.Size = New System.Drawing.Size(136, 20)
        Me.iExtraPrecondition.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.iExtraPrecondition, resources.GetString("iExtraPrecondition.ToolTip"))
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.iMinPermissionLevel)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(124, 37)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Permission Level"
        '
        'iMinPermissionLevel
        '
        Me.iMinPermissionLevel.CausesValidation = False
        Me.iMinPermissionLevel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommandBindingSource, "MinPermissionLevel", True))
        Me.iMinPermissionLevel.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CommandBindingSource, "MinPermissionLevel", True))
        Me.iMinPermissionLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iMinPermissionLevel.Location = New System.Drawing.Point(3, 16)
        Me.iMinPermissionLevel.Name = "iMinPermissionLevel"
        Me.iMinPermissionLevel.Size = New System.Drawing.Size(118, 20)
        Me.iMinPermissionLevel.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.iMinPermissionLevel, "Minimum permission level needed to execute this command.")
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.iCooldownMessage)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(3, 98)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(278, 44)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Cooldown Message"
        '
        'iCooldownMessage
        '
        Me.iCooldownMessage.CausesValidation = False
        Me.iCooldownMessage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommandBindingSource, "CoolDownMessage", True))
        Me.iCooldownMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iCooldownMessage.Location = New System.Drawing.Point(3, 16)
        Me.iCooldownMessage.MaxLength = 500
        Me.iCooldownMessage.Name = "iCooldownMessage"
        Me.iCooldownMessage.Size = New System.Drawing.Size(272, 20)
        Me.iCooldownMessage.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.iCooldownMessage, resources.GetString("iCooldownMessage.ToolTip"))
        '
        'CommandEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 361)
        Me.Controls.Add(Me.TableLayoutPanelBase)
        Me.MinimumSize = New System.Drawing.Size(300, 400)
        Me.Name = "CommandEditor"
        Me.Text = "CommandEditor"
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.CommandBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutCoolDown.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.iUserCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.iGlobalCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPermissionsPreconditions.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.iMinPermissionLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelBase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents iKeyword As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutCoolDown As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents iEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents iUserCD As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents iGlobalCD As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents bCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents iActions As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPermissionsPreconditions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents iExtraPrecondition As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents iMinPermissionLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents CommandBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents iCooldownMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
