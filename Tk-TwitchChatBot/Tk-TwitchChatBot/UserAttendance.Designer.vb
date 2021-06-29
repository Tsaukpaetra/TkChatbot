Imports TkChatBotPlugin_Base

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAttendance
    Inherits BotPluginTemplate

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
        Me.UserListContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteThisUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllOfflineUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteALLUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.UserList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.iFirstSeen = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.iPermissionLevel = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.iLastSeen = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.iFirstSeenToday = New System.Windows.Forms.TextBox()
        Me.UserListContextMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.iPermissionLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserListContextMenu
        '
        Me.UserListContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteThisUserToolStripMenuItem, Me.DeleteAllOfflineUsersToolStripMenuItem})
        Me.UserListContextMenu.Name = "UserListContextMenu"
        Me.UserListContextMenu.Size = New System.Drawing.Size(202, 48)
        '
        'DeleteThisUserToolStripMenuItem
        '
        Me.DeleteThisUserToolStripMenuItem.Name = "DeleteThisUserToolStripMenuItem"
        Me.DeleteThisUserToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DeleteThisUserToolStripMenuItem.Text = "&Delete This User"
        '
        'DeleteAllOfflineUsersToolStripMenuItem
        '
        Me.DeleteAllOfflineUsersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteALLUsersToolStripMenuItem})
        Me.DeleteAllOfflineUsersToolStripMenuItem.Name = "DeleteAllOfflineUsersToolStripMenuItem"
        Me.DeleteAllOfflineUsersToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DeleteAllOfflineUsersToolStripMenuItem.Text = "Delete &All (Offline) users"
        '
        'DeleteALLUsersToolStripMenuItem
        '
        Me.DeleteALLUsersToolStripMenuItem.Name = "DeleteALLUsersToolStripMenuItem"
        Me.DeleteALLUsersToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DeleteALLUsersToolStripMenuItem.Text = "Delete &ALL users"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UserList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 160)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'UserList
        '
        Me.UserList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.UserList.ContextMenuStrip = Me.UserListContextMenu
        Me.UserList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserList.FullRowSelect = True
        Me.UserList.GridLines = True
        Me.UserList.HideSelection = False
        Me.UserList.Location = New System.Drawing.Point(3, 3)
        Me.UserList.MultiSelect = False
        Me.UserList.Name = "UserList"
        Me.TableLayoutPanel1.SetRowSpan(Me.UserList, 2)
        Me.UserList.Size = New System.Drawing.Size(178, 154)
        Me.UserList.TabIndex = 0
        Me.UserList.UseCompatibleStateImageBehavior = False
        Me.UserList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Username"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Permission Level"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.iFirstSeen)
        Me.GroupBox1.Location = New System.Drawing.Point(187, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(94, 54)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "First Seen"
        '
        'iFirstSeen
        '
        Me.iFirstSeen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iFirstSeen.Location = New System.Drawing.Point(3, 16)
        Me.iFirstSeen.Multiline = True
        Me.iFirstSeen.Name = "iFirstSeen"
        Me.iFirstSeen.ReadOnly = True
        Me.iFirstSeen.Size = New System.Drawing.Size(88, 35)
        Me.iFirstSeen.TabIndex = 0
        Me.iFirstSeen.Text = "mm/dd/yyyy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hh:mm:ss AM"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.iPermissionLevel)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(287, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(94, 94)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Perm Level"
        '
        'iPermissionLevel
        '
        Me.iPermissionLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iPermissionLevel.Location = New System.Drawing.Point(3, 16)
        Me.iPermissionLevel.Maximum = New Decimal(New Integer() {0, 1, 0, 0})
        Me.iPermissionLevel.Minimum = New Decimal(New Integer() {-1, 0, 0, -2147483648})
        Me.iPermissionLevel.Name = "iPermissionLevel"
        Me.iPermissionLevel.Size = New System.Drawing.Size(88, 20)
        Me.iPermissionLevel.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.iLastSeen)
        Me.GroupBox2.Location = New System.Drawing.Point(287, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(94, 54)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Last Seen"
        '
        'iLastSeen
        '
        Me.iLastSeen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iLastSeen.Location = New System.Drawing.Point(3, 16)
        Me.iLastSeen.Multiline = True
        Me.iLastSeen.Name = "iLastSeen"
        Me.iLastSeen.ReadOnly = True
        Me.iLastSeen.Size = New System.Drawing.Size(88, 35)
        Me.iLastSeen.TabIndex = 0
        Me.iLastSeen.Text = "mm/dd/yyyy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hh:mm:ss AM"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.iFirstSeenToday)
        Me.GroupBox4.Location = New System.Drawing.Point(187, 63)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(94, 54)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "1st Seen today"
        '
        'iFirstSeenToday
        '
        Me.iFirstSeenToday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iFirstSeenToday.Location = New System.Drawing.Point(3, 16)
        Me.iFirstSeenToday.Multiline = True
        Me.iFirstSeenToday.Name = "iFirstSeenToday"
        Me.iFirstSeenToday.ReadOnly = True
        Me.iFirstSeenToday.Size = New System.Drawing.Size(88, 35)
        Me.iFirstSeenToday.TabIndex = 0
        Me.iFirstSeenToday.Text = "mm/dd/yyyy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hh:mm:ss AM"
        '
        'UserAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(360, 130)
        Me.Name = "UserAttendance"
        Me.TabName = "Users"
        Me.Text = "User Attendance"
        Me.UserListContextMenu.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.iPermissionLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UserList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents iPermissionLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents iFirstSeen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents iLastSeen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents iFirstSeenToday As System.Windows.Forms.TextBox
    Friend WithEvents UserListContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteThisUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllOfflineUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteALLUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
