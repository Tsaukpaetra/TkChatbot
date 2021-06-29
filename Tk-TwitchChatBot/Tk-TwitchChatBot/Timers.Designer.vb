Imports TkChatBotPlugin_Base
Imports TkChatBot_Database

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Timers
    Inherits BotPluginTemplate

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnabledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RepeatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepeatSecondsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextTriggerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Enabled = True
        Me.Clock.Interval = 1000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(500, 285)
        Me.SplitContainer1.SplitterDistance = 99
        Me.SplitContainer1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.EnabledDataGridViewCheckBoxColumn, Me.RepeatDataGridViewTextBoxColumn, Me.RepeatSecondsDataGridViewTextBoxColumn, Me.NextTriggerDataGridViewTextBoxColumn, Me.ActionDataGridViewTextBoxColumn})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.DataSource = Me.TimerBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(500, 99)
        Me.DataGridView1.TabIndex = 0
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'EnabledDataGridViewCheckBoxColumn
        '
        Me.EnabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled"
        Me.EnabledDataGridViewCheckBoxColumn.HeaderText = "Enabled"
        Me.EnabledDataGridViewCheckBoxColumn.MinimumWidth = 20
        Me.EnabledDataGridViewCheckBoxColumn.Name = "EnabledDataGridViewCheckBoxColumn"
        Me.EnabledDataGridViewCheckBoxColumn.Width = 50
        '
        'RepeatDataGridViewTextBoxColumn
        '
        Me.RepeatDataGridViewTextBoxColumn.DataPropertyName = "Repeat"
        Me.RepeatDataGridViewTextBoxColumn.HeaderText = "Repeat"
        Me.RepeatDataGridViewTextBoxColumn.MinimumWidth = 20
        Me.RepeatDataGridViewTextBoxColumn.Name = "RepeatDataGridViewTextBoxColumn"
        Me.RepeatDataGridViewTextBoxColumn.Width = 50
        '
        'RepeatSecondsDataGridViewTextBoxColumn
        '
        Me.RepeatSecondsDataGridViewTextBoxColumn.DataPropertyName = "RepeatSeconds"
        Me.RepeatSecondsDataGridViewTextBoxColumn.HeaderText = "Delay"
        Me.RepeatSecondsDataGridViewTextBoxColumn.MinimumWidth = 20
        Me.RepeatSecondsDataGridViewTextBoxColumn.Name = "RepeatSecondsDataGridViewTextBoxColumn"
        Me.RepeatSecondsDataGridViewTextBoxColumn.ToolTipText = "When repeating, how many seconds until the next trigger"
        Me.RepeatSecondsDataGridViewTextBoxColumn.Width = 50
        '
        'NextTriggerDataGridViewTextBoxColumn
        '
        Me.NextTriggerDataGridViewTextBoxColumn.DataPropertyName = "NextTrigger"
        Me.NextTriggerDataGridViewTextBoxColumn.HeaderText = "Next Trigger"
        Me.NextTriggerDataGridViewTextBoxColumn.Name = "NextTriggerDataGridViewTextBoxColumn"
        Me.NextTriggerDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ActionDataGridViewTextBoxColumn
        '
        Me.ActionDataGridViewTextBoxColumn.DataPropertyName = "Action"
        Me.ActionDataGridViewTextBoxColumn.HeaderText = "Action"
        Me.ActionDataGridViewTextBoxColumn.Name = "ActionDataGridViewTextBoxColumn"
        '
        'TimerBindingSource
        '
        Me.TimerBindingSource.DataSource = GetType(TkChatBot_Database.Timer)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(500, 182)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(94, 45)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Repeat"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TimerBindingSource, "Repeat", True))
        Me.NumericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumericUpDown1.Location = New System.Drawing.Point(3, 16)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(88, 20)
        Me.NumericUpDown1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(103, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(94, 45)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Delay"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TimerBindingSource, "RepeatSeconds", True))
        Me.NumericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumericUpDown2.Increment = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDown2.Location = New System.Drawing.Point(3, 16)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(88, 20)
        Me.NumericUpDown2.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(203, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(294, 45)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Next Trigger"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yy hh:mm:ss tt"
        Me.DateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TimerBindingSource, "NextTrigger", True))
        Me.DateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(3, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(288, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox2, 3)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(494, 125)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TimerBindingSource, "Action", True))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.HideSelection = False
        Me.TextBox1.Location = New System.Drawing.Point(3, 16)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(488, 106)
        Me.TextBox1.TabIndex = 0
        '
        'Timers
        '
        Me.ClientSize = New System.Drawing.Size(500, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimumSize = New System.Drawing.Size(400, 250)
        Me.Name = "Timers"
        Me.TabName = "Events"
        Me.Text = "Timers"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TimerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnabledDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RepeatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepeatSecondsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextTriggerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
