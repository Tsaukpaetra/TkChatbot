Imports TkChatBotPlugin_Base
Imports TkChatBot_Database

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAttributesEditor
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.UserList = New System.Windows.Forms.ListBox()
        Me.UserAttributeDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserAttributeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UserListContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UserAttributeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserAttributeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserListContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.UserList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.UserAttributeDataGridView)
        Me.SplitContainer1.Size = New System.Drawing.Size(424, 221)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 0
        '
        'UserList
        '
        Me.UserList.ContextMenuStrip = Me.UserListContextMenuStrip
        Me.UserList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserList.FormattingEnabled = True
        Me.UserList.Location = New System.Drawing.Point(0, 0)
        Me.UserList.Name = "UserList"
        Me.UserList.Size = New System.Drawing.Size(94, 221)
        Me.UserList.TabIndex = 0
        '
        'UserAttributeDataGridView
        '
        Me.UserAttributeDataGridView.AutoGenerateColumns = False
        Me.UserAttributeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UserAttributeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.UserAttributeDataGridView.DataSource = Me.UserAttributeBindingSource
        Me.UserAttributeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserAttributeDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.UserAttributeDataGridView.Name = "UserAttributeDataGridView"
        Me.UserAttributeDataGridView.Size = New System.Drawing.Size(326, 221)
        Me.UserAttributeDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Key"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Attribute"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Value"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'UserAttributeBindingSource
        '
        Me.UserAttributeBindingSource.DataSource = GetType(TkChatBot_Database.UserAttribute)
        '
        'UserListContextMenuStrip
        '
        Me.UserListContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowAllToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.UserListContextMenuStrip.Name = "UserListContextMenuStrip"
        Me.UserListContextMenuStrip.Size = New System.Drawing.Size(153, 70)
        '
        'ShowAllToolStripMenuItem
        '
        Me.ShowAllToolStripMenuItem.CheckOnClick = True
        Me.ShowAllToolStripMenuItem.Name = "ShowAllToolStripMenuItem"
        Me.ShowAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShowAllToolStripMenuItem.Text = "Show All"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'UserAttributesEditor
        '
        Me.ClientSize = New System.Drawing.Size(424, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(360, 120)
        Me.Name = "UserAttributesEditor"
        Me.TabName = "Users"
        Me.Text = "User Attributes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UserAttributeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserAttributeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserListContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UserList As System.Windows.Forms.ListBox
    Friend WithEvents UserAttributeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserAttributeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserListContextMenuStrip As ContextMenuStrip
    Friend WithEvents ShowAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
End Class
