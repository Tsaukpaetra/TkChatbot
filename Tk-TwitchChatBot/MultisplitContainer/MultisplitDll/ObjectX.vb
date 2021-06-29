Imports System.Runtime.CompilerServices

Namespace System

   Public Module ObjectX

      ''' <summary> testet vor einer Zuweisung, ob der neue Wert überhaupt eine Änderung bringt </summary>
      ''' <remarks>
      ''' nützlich bei Zuweisungen an performance-intensive Properties, 
      ''' oder wenn auf Änderungen reagiert werden muß
      ''' </remarks>
      <Extension()> _
      Public Function Assign(Of T, T2 As T)(ByRef Dest As T, ByVal Src As T2) As Boolean
         If Object.Equals(Dest, Src) Then Return False
         Dest = Src
         Return True
      End Function

      <Extension()> _
      Public Function CloneX(Of T As ICloneable)(ByVal Obj As T) As T
         Return DirectCast(Obj.Clone(), T)
      End Function

      <DebuggerStepThrough()> _
      <Extension()> _
      Public Function Null(Of T As Class)(ByVal Subj As T) As Boolean
         Return Subj Is Nothing
      End Function

      <DebuggerStepThrough()> _
      <Extension()> _
      Public Function NotNull(Of T As Class)(ByVal Subj As T) As Boolean
         Return Subj IsNot Nothing
      End Function

   End Module
End Namespace
