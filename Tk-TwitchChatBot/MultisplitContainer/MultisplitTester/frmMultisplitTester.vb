Public Class frmMultisplitTester
   Public Sub New()
      InitializeComponent()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location

        addForm()
        addForm()
        addForm()
        addForm()
        addForm()
        addForm()


    End Sub
    Sub addForm()
        Dim a As New Form1(), b As New Panel()
        a.TopLevel = False
        a.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        b.Controls.Add(a)
        a.Dock = DockStyle.Fill
        b.Size = a.Size
        b.MinimumSize = a.MinimumSize
        b.MaximumSize = a.MaximumSize
        b.BorderStyle = BorderStyle.Fixed3D
        MultisplitContainer3.Controls.Add(b)
        a.Show()

    End Sub
End Class