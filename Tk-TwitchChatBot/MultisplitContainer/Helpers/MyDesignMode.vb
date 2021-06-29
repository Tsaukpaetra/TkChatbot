Namespace System.ComponentModel
   ''' <summary>System.ComponentModel.Component.DesignMode is buggy</summary>
   Public Class MyDesignMode

      Private _DesignMode As Boolean = Application.StartupPath.EndsWith("\Common7\IDE")

      Private Shared Singleton As New MyDesignMode

      Private Sub New()
         AddHandler Application.ApplicationExit, AddressOf ApplicationExit
      End Sub

      Private Sub ApplicationExit(ByVal Sender As Object, ByVal e As EventArgs)
         _DesignMode = True
      End Sub

      Public Shared ReadOnly Property [True]() As Boolean
         Get
            Return Singleton._DesignMode
         End Get
      End Property

      Public Shared ReadOnly Property [False]() As Boolean
         Get
            Return Not Singleton._DesignMode
         End Get
      End Property

   End Class 'MyDesignMode

End Namespace
