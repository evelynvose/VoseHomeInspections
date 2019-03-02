'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     +MsgBox(message, verbose):object
    ' ***********************************************
    '
    ' This function is meant to steer messages to an event or display a message box.
    '         The default is to an event, the desired behavior is that a UI form handles I/O not a VObject class.
    '         However, there are times during debugging where displaying a msgbox from within a VObject class is just plain handy!
    '
    Public Function MsgBox(ByVal message As String, ByVal verbose As Boolean) As MsgBoxResult
        '
        Me.Message = message
        Me.Verbose = verbose
        VMsgBox()
        Return MsgBoxResult
        '
    End Function
    '
    ' ***********************************************
    ' *****     +MsgBox(object):object
    ' ***********************************************
    '
    Public Function MsgBox(ByVal e As Exception) As MsgBoxResult
        '
        Me.Message = e.Message
        Verbose = True
        VMsgBox()
        Return MsgBoxResult
        '
    End Function
    '
    ' ***********************************************
    ' *****     +MsgBox(message):object
    ' ***********************************************
    '
    Public Function MsgBox(ByVal message As String) As MsgBoxResult
        '
        Me.Message = message
        Verbose = True
        VMsgBox()
        Return MsgBoxResult
        '
    End Function
    '
    ' ***********************************************
    ' *****     -VMsgBox() 
    ' ***********************************************
    '
    Private Sub VMsgBox()
        '
        ' The defult result is Ignore since chances are we want to raise an event and don't care about user choices.
        '
        MsgBoxResult = MsgBoxResult.Ignore
        '
        ' So, if the verbose flag is set, then we will show a message box and ask for user input.
        '     Otherwise, we raise an event and let the UI figure it out!
        '
        If Verbose Then
            MsgBoxResult = Interaction.MsgBox(Message,, "VHomeGauge")
            '
        Else
            RaiseEvent VEvent(Me, New VEventArgs(Message))
            '
        End If
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    '
    ' The idea here is to give all subclassed objects an event capability to raise messages for
    ' a UI form to handle and or for the UI to write them to a log file.
    '
    '
    ' ***********************************************
    ' *****     +VEvent(object, object)
    ' ***********************************************
    '
    Public Event VEvent(ByVal sender As Object, ByVal e As VEventArgs)
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_Verbose As Boolean
    Private m_MsgBoxResult As MsgBoxResult
    Private m_Message As String
    '
    ' ***********************************************
    ' *****     +Verbose(Boolean):Boolean 
    ' ***********************************************
    '
    Public Property Verbose As Boolean
        Get
            Return m_Verbose
        End Get
        Set(value As Boolean)
            m_Verbose = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +MsgBoxResult(object):object 
    ' ***********************************************
    '
    Public Property MsgBoxResult As MsgBoxResult
        Get
            Return m_MsgBoxResult
        End Get
        Set(value As MsgBoxResult)
            m_MsgBoxResult = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Message(string):string 
    ' ***********************************************
    '
    Public Property Message As String
        Get
            Return m_Message
        End Get
        Set(value As String)
            m_Message = value
        End Set
    End Property
    '
End Class






'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class VEventArgs
    Inherits EventArgs
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     +New( string )
    ' ***********************************************
    '
    Public Sub New(ByVal message As String)
        Me.Message = message
        Me.Verbose = False
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +New( string, Boolean )
    ' ***********************************************
    '
    Public Sub New(ByVal message As String, ByVal showme As Boolean)
        Me.Message = message
        Me.Verbose = showme
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_Message As String = ""
    Private m_Verbose As Boolean
    '
    ' ***********************************************
    ' *****     +Verbose(Boolean):Boolean
    ' ***********************************************
    '
    Public Property Verbose As Boolean
        Get
            Return m_Verbose
        End Get
        Set(value As Boolean)
            m_Verbose = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Message(string):string
    ' ***********************************************
    '
    Public Property Message As String
        Get
            Return m_Message
        End Get
        Set(value As String)
            m_Message = value
        End Set
    End Property
End Class
