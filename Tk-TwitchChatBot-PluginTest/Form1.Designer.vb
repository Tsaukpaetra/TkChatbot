<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits TkChatBotPlugin_Base.BotPluginTemplate

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PlaySelected = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.WMP = New AxWMPLib.AxWindowsMediaPlayer()
        Me.SoundList = New System.Windows.Forms.DataGridView()
        Me.KeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SongListBinding = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.WMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SongListBinding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlaySelected
        '
        Me.PlaySelected.Location = New System.Drawing.Point(577, 427)
        Me.PlaySelected.Name = "PlaySelected"
        Me.PlaySelected.Size = New System.Drawing.Size(84, 26)
        Me.PlaySelected.TabIndex = 0
        Me.PlaySelected.Text = "Play Selected Sound"
        Me.PlaySelected.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.WMP, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PlaySelected, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.SoundList, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(664, 456)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'WMP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.WMP, 3)
        Me.WMP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WMP.Enabled = True
        Me.WMP.Location = New System.Drawing.Point(3, 3)
        Me.WMP.Name = "WMP"
        Me.WMP.OcxState = CType(resources.GetObject("WMP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WMP.Size = New System.Drawing.Size(658, 44)
        Me.WMP.TabIndex = 1
        '
        'SoundList
        '
        Me.SoundList.AutoGenerateColumns = False
        Me.SoundList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SoundList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KeyDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn})
        Me.TableLayoutPanel1.SetColumnSpan(Me.SoundList, 3)
        Me.SoundList.DataSource = Me.SongListBinding
        Me.SoundList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SoundList.Location = New System.Drawing.Point(3, 53)
        Me.SoundList.Name = "SoundList"
        Me.SoundList.Size = New System.Drawing.Size(658, 368)
        Me.SoundList.TabIndex = 2
        '
        'KeyDataGridViewTextBoxColumn
        '
        Me.KeyDataGridViewTextBoxColumn.DataPropertyName = "Key"
        Me.KeyDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.KeyDataGridViewTextBoxColumn.Name = "KeyDataGridViewTextBoxColumn"
        '
        'ValueDataGridViewTextBoxColumn
        '
        Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
        Me.ValueDataGridViewTextBoxColumn.HeaderText = "File"
        Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
        '
        'SongListBinding
        '
        Me.SongListBinding.DataSource = GetType(TkChatBot_Database.UserAttribute)
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(664, 456)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(240, 130)
        Me.Name = "Form1"
        Me.TabName = "Interactive"
        Me.Text = "Play Sounds"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.WMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SongListBinding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlaySelected As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WMP As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents SoundList As System.Windows.Forms.DataGridView
    Friend WithEvents KeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SongListBinding As System.Windows.Forms.BindingSource


End Class
