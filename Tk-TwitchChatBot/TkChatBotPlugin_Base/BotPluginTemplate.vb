Imports System.ComponentModel
Imports System.Windows.Forms
Imports TkChatBot_Database

Partial Public Class BotPluginTemplate : Inherits Form
    'This is for templating out some common events done in the bot


    Public Event DBSaveChanges() ' Notifies that the GUI should refresh from the database
    Public Event SendChatMessage(ByVal message As String)
    Public _Users As List(Of User)

    Public Property Immobile As Boolean = True
    Private _TabName As String


    <DefaultValue("Plugin")> _
        <Category("Appearance")> _
    Public Property TabName() As String
        'in MultiColumn-Mode Expansion tells the Column-Width. 
        Get
            Return _TabName
        End Get
        Set(value As String)
            _TabName = value
        End Set
    End Property


    Public Overridable Sub UpdateUsersList()
        Using db As New DatabaseEntities()
            _Users = db.Users.ToList()
        End Using


    End Sub
    Public Sub Do_DBSaveChanges()
        RaiseEvent DBSaveChanges()
    End Sub
    Public Sub Do_SendChatMessage(ByVal message As String)
        RaiseEvent SendChatMessage(message)
    End Sub

    Private Sub BotPluginTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Overridable Sub AddToExpressionContext(ByRef theContext As TinyExe.Context)
        'Here is a good place to add to Functions, and Globals
        'It is called with the expressionContext upon plugin loading

    End Sub

    Public Overridable Function PreFilterMessage(ByRef msg As ChatSharp.PrivateMessage) As Boolean
        'Return true if the bot should not process any commands
        Return False
    End Function

    Public Overridable Sub BotStatusUpdated(ByVal status As String)

    End Sub


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BotPluginTemplate
        '
        Me.ClientSize = New System.Drawing.Size(424, 102)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "BotPluginTemplate"
        Me.ResumeLayout(False)

    End Sub

    ' Handle Window process messages
    Protected Overrides Sub WndProc(ByRef m As Message)
        If Immobile Then
            If (m.Msg = &H112) AndAlso (m.WParam.ToInt32() = &HF010) Then
                Return
            End If
            If (m.Msg = &HA1) AndAlso (m.WParam.ToInt32() = &H2) Then
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
End Class
