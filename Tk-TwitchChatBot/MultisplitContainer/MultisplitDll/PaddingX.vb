Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Windows.Forms

Public Module PaddingX
   <Extension()> _
   Public Function Size(ByVal subj As Padding) As Size
      With subj
         Return New Size(.Left + .Right, .Top + .Bottom)
      End With
   End Function
   <Extension()> _
   Public Function Height(ByVal subj As Padding) As Integer
      Return subj.Top + subj.Bottom
   End Function
   <Extension()> _
   Public Function Width(ByVal subj As Padding) As Integer
      Return subj.Left + subj.Right
   End Function
End Module
