Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.ComponentModel

Imports System.Windows.Forms.Layout

Namespace System.Windows.Forms

    <ProvideProperty("SizeDynamic", GetType(Control))> _
    <ProvideProperty("IsFillControl", GetType(Control))> _
    Public Class MultisplitContainer : Inherits FlowLayoutPanel : Implements ISupportInitialize

        Private Const _DefaultExpansionW As Integer = 150
        Private Const _DefaultExpansionH As Integer = 20
        Private _Expansion As Integer = _DefaultExpansionW
        Private _Initing As Boolean
        Private _FillCtl As Control
        Private _Ctl As Control
        Private _MarkupPen As New Pen(Color.Red, 2) With {.Alignment = Drawing2D.PenAlignment.Inset}
        Private _Anchor As Integer = Integer.MinValue
        Private _CanSize As New Dictionary(Of Control, Boolean())

        Private _FillCtlIndex As Integer = Integer.MaxValue
        Private _CtlIndex As Integer

        Public Sub New()
            MyBase.FlowDirection = FlowDirection.TopDown
            MyBase.AutoScroll = True
        End Sub

        Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
            _Initing = True
        End Sub

        Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit
            Me.SuspendLayout()
            For Each ctl As Control In Controls
                CheckSizes(ctl)
            Next
            ApplyExpansion()
            Me.ResumeLayout()
            _Initing = False
        End Sub

        Private Sub CheckSizes(ByRef ctl As Control)
            'set some default-values
            If Not SingleColumnOrRow Then
                Dim sz = ctl.MinimumSize
                If sz.Width < 50 Then sz.Width = 50
                If sz.Height < 20 Then sz.Height = 20
                ctl.MinimumSize = sz
                If ctl.MaximumSize.IsEmpty Then
                    ctl.MaximumSize = New Size(Short.MaxValue, Short.MaxValue)
                End If
            End If
            GetCanSize(ctl)
        End Sub


        Private Sub ApplyExpansion()
            If TopDown Then
                For Each ctl As Control In Me.Controls
                    ctl.Width.Assign(_Expansion)
                Next
            Else
                For Each ctl As Control In Me.Controls
                    ctl.Height.Assign(_Expansion)
                Next
            End If
        End Sub

        <DefaultValue(_DefaultExpansionW)> _
        <Category("Layout")> _
        Public Property Expansion() As Integer
            'in MultiColumn-Mode Expansion tells the Column-Width. 
            Get
                Return _Expansion
            End Get
            Set(ByVal NewValue As Integer)
                If _Expansion = NewValue Then Return
                _Expansion = NewValue
                If _Initing Then Return
                If SingleColumnOrRow Then Return
                Me.SuspendLayout()
                ApplyExpansion()
                Me.ResumeLayout()
            End Set
        End Property

        <Category("Layout")> _
        <DefaultValue(True)> _
        Public Property TopDown() As Boolean
            'reduces the number of the FlowDirection-Opportunities to only two
            Get
                Return MyBase.FlowDirection = FlowDirection.TopDown
            End Get
            Set(ByVal NewValue As Boolean)
                If NewValue = (MyBase.FlowDirection = FlowDirection.TopDown) Then Return
                MyBase.FlowDirection = If(NewValue, FlowDirection.TopDown, FlowDirection.LeftToRight)
            End Set
        End Property

        <EditorBrowsable(EditorBrowsableState.Never)> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        <Browsable(False)> _
        Public Shadows Property FlowDirection() As FlowDirection
            'hide FlowDirection-Property
            Get
                Return MyBase.FlowDirection
            End Get
            Set(ByVal NewValue As FlowDirection)
                MyBase.FlowDirection = NewValue
            End Set
        End Property

        <Category("Layout")> _
        <DefaultValue(False)> _
        Public Property SingleColumnOrRow() As Boolean
            'replace the WrapContents-Prop with an easyer name: WrapContents=False -> SingleColumnOrRow=True
            Get
                Return Not MyBase.WrapContents
            End Get
            Set(ByVal NewValue As Boolean)
                If NewValue <> MyBase.WrapContents Then Return
                MyBase.WrapContents = Not NewValue
            End Set
        End Property

        <EditorBrowsable(EditorBrowsableState.Never)> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        <Browsable(False)> _
        Public Shadows Property WrapContents() As Boolean
            'hide WrapContents-Property
            Get
                Return MyBase.WrapContents
            End Get
            Set(ByVal NewValue As Boolean)
                SingleColumnOrRow = NewValue
            End Set
        End Property

        Public Property MarkupColor() As Color
            'in SingleColumn-Mode there may be set the FillControl, which acts like a control with DockStyle.Fill: it shrinks, if the choosen control grows, and grows, if the choosen one shrinks. So there are always **two** Controls sizing, when SplitBar is used. MarkupColor is the color used to indicate them.
            Get
                Return _MarkupPen.Color
            End Get
            Set(ByVal NewValue As Color)
                If _MarkupPen.Color.ToArgb = NewValue.ToArgb Then Return
                _MarkupPen.Color = NewValue
                InvalidateMarkup()
            End Set
        End Property

        Private Sub InvalidateMarkup()
            If _FillCtl.Null Then Return
            If _Ctl.NotNull Then Invalidate(MarkupRect(_Ctl))
            Invalidate(MarkupRect(_FillCtl))
        End Sub

        Private Function MarkupRect(ByVal ctl As Control) As Rectangle
            With ctl.Bounds
                Return New Rectangle(.X - 2, .Y - 2, .Width + 5, .Height + 5)
            End With
        End Function

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            If _FillCtl.Null Then Return
            If MyDesignMode.True Then
                e.Graphics.DrawRectangle(_MarkupPen, MarkupRect(_FillCtl))
            ElseIf SingleColumnOrRow AndAlso _Anchor <> Integer.MinValue Then
                e.Graphics.DrawRectangle(_MarkupPen, MarkupRect(_FillCtl))
                e.Graphics.DrawRectangle(_MarkupPen, MarkupRect(_Ctl))
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            Cursor = Cursors.Default
            _Anchor = Integer.MinValue
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            InvalidateMarkup()
            _Anchor = Integer.MinValue
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            '_Anchor is the difference between the mouseposition and the height of the sizing control. It can have 4 meanings: X/Y - Dimension, and before/behind the FillControl. If the sizing control is before the FillingControl it grows when mouse.Y grows. But if it is behind the FillingControl it shrinks when mouse.Y grows.
            If Cursor = Cursors.Default Then Return
            If SingleColumnOrRow Then
                'only in SingleColumn-Mode the sizing-Control may be behind the FillControl
                If _CtlIndex > _FillCtlIndex Then
                    _Anchor = If(Cursor = Cursors.HSplit, e.Y + _Ctl.Height, e.X + _Ctl.Width)
                Else
                    _Anchor = If(Cursor = Cursors.HSplit, e.Y - _Ctl.Height, e.X - _Ctl.Width)
                End If
                InvalidateMarkup()
            Else
                _Anchor = If(Cursor = Cursors.HSplit, e.Y - _Ctl.Height, e.X - _Ctl.Width)
            End If
        End Sub

        Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
            MyBase.OnControlAdded(e)
            CheckSizes(e.Control)

            GetCanSize(e.Control)
        End Sub

        Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
            _CanSize.Remove(e.Control)
            MyBase.OnControlRemoved(e)
        End Sub

        Private ReadOnly Property CanSize(ByVal ctl As Control) As Boolean
            Get
                Dim bools As Boolean() = Nothing
                If Not _CanSize.TryGetValue(ctl, bools) Then
                    bools = GetCanSize(ctl)
                End If
                Return bools(If(TopDown, 1, 0))
            End Get
        End Property

        Private Function GetCanSize(ByVal ctl As Control) As Boolean()
            Me.SuspendLayout()
            'some controls are not sizeable in both directions, eg Textbox-singlelined, combobox etc.
            'i simply try it out.
            With ctl
                Dim sz = .Size
                .Size += New Size(100, 100)
                GetCanSize = New Boolean() {.Width > sz.Width, .Height > sz.Height}
                _CanSize(ctl) = GetCanSize
                If Not _Initing Then
                    If TopDown Then
                        sz.Width = _Expansion
                    Else
                        sz.Height = _Expansion
                    End If
                End If
                .Size = sz
            End With
            Me.ResumeLayout()
        End Function

        Private Function GetCursorNoWrap(ByVal pt As Point) As Cursor
            'SingleColumnOrRow-Mode: Figure out wether a control can be sized, and set the appropriate cursor
            If TopDown Then pt.Offset(0, -15) Else pt.Offset(-15, 0)
            _Ctl = Me.GetChildAtPoint(pt, GetChildAtPointSkip.Invisible)
            If _Ctl.Null Then Return Cursors.Default
            _CtlIndex = Controls.GetChildIndex(_Ctl)
            If _FillCtl.NotNull Then _FillCtlIndex = Controls.GetChildIndex(_FillCtl)
            If _CtlIndex >= _FillCtlIndex Then
                _CtlIndex += 1
                If Controls.Count = _CtlIndex Then Return Cursors.Default
                _Ctl = Me.Controls(_CtlIndex)
            End If
            Return If(CanSize(_Ctl), If(TopDown, Cursors.HSplit, Cursors.VSplit), Cursors.Default)
        End Function

        Private Function GetCursorWrappingContents(ByVal pt As Point) As Cursor
            'MultiColumn-Mode: Figure out wether a control can be sized, and set the appropriate cursor
            GetCursorWrappingContents = Cursors.Default
            pt.Offset(0, -15)    'vertical check
            _Ctl = Me.GetChildAtPoint(pt, GetChildAtPointSkip.Invisible)
            If _Ctl.Null Then
                pt.Offset(-15, 15)   'horizontal check
                _Ctl = Me.GetChildAtPoint(pt, GetChildAtPointSkip.Invisible)
                'VSplit either means to size a control in horizontal mode, or (in vertical mode) to size MultiSplitContainers "Expansion": set all controls to same width
                If _Ctl.NotNull AndAlso CanSize(_Ctl) Then Return Cursors.VSplit
            Else
                If TopDown AndAlso CanSize(_Ctl) Then Return Cursors.HSplit
            End If
        End Function


        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    'execute sizing depending on the cursor
                    Dim dlt As Integer      'the amount to change controls height/width
                    Select Case Cursor
                        Case Cursors.HSplit
                            dlt = If(_CtlIndex > _FillCtlIndex, _Anchor - e.Y, e.Y - _Anchor) - _Ctl.Height
                            If _FillCtlIndex <> Integer.MaxValue Then
                                'dlt can be limited by FillControls MinimumSize
                                dlt = Math.Min(dlt, _FillCtl.Height - _FillCtl.MinimumSize.Height)
                            End If
                            'or by _Ctl.MinimumSize
                            dlt = Math.Max(dlt, _Ctl.MinimumSize.Height - _Ctl.Height)
                            InvalidateMarkup()
                            _Ctl.Height += dlt

                        Case Cursors.VSplit
                            dlt = If(_CtlIndex > _FillCtlIndex, _Anchor - e.X, e.X - _Anchor) - _Ctl.Width
                            If SingleColumnOrRow Then
                                If _FillCtlIndex <> Integer.MaxValue Then
                                    'dlt can be limited by FillControls MinimumSize
                                    dlt = Math.Min(dlt, _FillCtl.Width - _FillCtl.MinimumSize.Width)
                                End If
                            Else
                                If TopDown Then
                                    Expansion += dlt     'VSplit in MultiColumn TopDown: sizing Expansion instead
                                    Return
                                End If
                            End If
                            dlt = Math.Max(dlt, _Ctl.MinimumSize.Width - _Ctl.Width)
                            _Ctl.Width += dlt
                    End Select

                Case Windows.Forms.MouseButtons.None
                    Dim pt = e.Location
                    _FillCtlIndex = Integer.MaxValue
                    Cursor = If(SingleColumnOrRow, GetCursorNoWrap(pt), GetCursorWrappingContents(pt))

                Case Else
            End Select
        End Sub


#Region "ProvideProperties"
        'FlowLayoutPanel implements ComponentModel.IExtenderProvider, so it provides additional "Properties" to its contained Controls. This is defined by class-Attribute "ProvideProperty" combined with Function-Attribute "DisplayName"
        <Category("Layout")> _
        <DefaultValue(True), DisplayName("SizeDynamic")> _
        Public Function GetSizeDynamic(ByVal control As Control) As Boolean
            Return CanSize(control)
        End Function
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        <DefaultValue(True), DisplayName("SizeDynamic")> _
        Public Sub SetSizeDynamic(ByVal ctl As Control, ByVal value As Boolean)
            'you can lock a control against sizing by set its Mini/Maxi-mumSize. To ease this in Designer you can toggle this bool-Prop "SizeDynamic"
            If CanSize(ctl) = value Then Return
            Dim szMax = New Size(Short.MaxValue, Short.MaxValue)
            Dim szMin = New Size(40, 20)
            With ctl
                If TopDown Then
                    'only change vertical
                    If value Then
                        .MaximumSize = New Size(.MaximumSize.Width, szMax.Height)
                        .MinimumSize = New Size(.MinimumSize.Width, szMin.Height)
                        GetCanSize(ctl)
                    Else
                        .MaximumSize = New Size(.MaximumSize.Width, .Size.Height)
                        .MinimumSize = New Size(.MinimumSize.Width, .Size.Height)
                        _CanSize(ctl) = New Boolean() {_CanSize(ctl)(0), False}
                    End If
                Else
                    'only change horizontal
                    If value Then
                        .MaximumSize = New Size(szMax.Width, .MaximumSize.Height)
                        .MinimumSize = New Size(szMin.Width, .MinimumSize.Height)
                        GetCanSize(ctl)
                    Else
                        .MaximumSize = New Size(.Size.Width, .MaximumSize.Height)
                        .MinimumSize = New Size(.Size.Width, .MinimumSize.Height)
                        _CanSize(ctl) = New Boolean() {False, _CanSize(ctl)(1)}
                    End If
                End If
            End With
        End Sub

        <Category("Layout")> _
        <Description("in MultiSplitter.SingleColumnOrRow-Mode the FillControl is layouted with DockStyle.Fill-Behaviour")> _
        <DefaultValue(False), DisplayName("IsFillControl")> _
        Public Function GetIsFillControl(ByVal control As Control) As Boolean
            Return control Is _FillCtl
        End Function
        <DisplayName("IsFillControl")> _
        Public Sub SetIsFillControl(ByVal control As Control, ByVal value As Boolean)
            If (control Is _FillCtl) = value Then Return
            _FillCtl = If(value, control, Nothing)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Never)> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        <Browsable(False)> _
        Public Shadows Function GetFlowBreak() As Boolean
            'hide FlowBreak-provided-Property
        End Function

#End Region 'ProvideProperties

        Protected Overrides Sub OnLayout(ByVal e As System.Windows.Forms.LayoutEventArgs)
            Dim ctl = e.AffectedControl
            If ctl Is Me And controls.count > 0 Then
                Select Case e.AffectedProperty
                    Case "WrapContents", "FlowDirection"
                        'complete rearranging
                        Dim marginSum = Size.Empty
                        For Each c As Control In Controls
                            marginSum += c.Margin.Size
                        Next
                        If SingleColumnOrRow Then
                            If TopDown Then
                                Dim h = (ClientSize.Height - (marginSum.Height + 20)) \ Controls.Count
                                For Each c As Control In Controls
                                    c.Height.Assign(h)
                                Next
                            Else
                                Dim w = (ClientSize.Width - (marginSum.Width + 20)) \ Controls.Count
                                For Each c As Control In Controls
                                    c.Width.Assign(w)
                                Next
                            End If
                        Else
                            _Expansion = If(TopDown, _DefaultExpansionW, _DefaultExpansionH)
                            ApplyExpansion()
                        End If
                End Select
            End If
            If SingleColumnOrRow Then
                Dim sum = 0
                If Not Controls.Contains(_FillCtl) Then _FillCtl = Nothing
                If MyBase.FlowDirection = FlowDirection.TopDown Then
                    Dim w = ClientSize.Width
                    For Each c As Control In Controls
                        c.Width.Assign(w - c.Margin.Width)
                        sum += c.Height + c.Margin.Height
                    Next
                    With _FillCtl
                        If .NotNull Then .Height.Assign(.Height + ClientSize.Height - sum)
                    End With
                Else
                    Dim h = ClientSize.Height
                    For Each c As Control In Controls
                        c.Height.Assign(h - c.Margin.Height)
                        sum += c.Width + c.Margin.Width
                    Next
                    With _FillCtl
                        If .NotNull Then .Width.Assign(.Width + ClientSize.Width - sum)
                    End With
                End If
                If _FillCtl.NotNull Then InvalidateMarkup()
            End If
            MyBase.OnLayout(e)
        End Sub

    End Class

End Namespace
