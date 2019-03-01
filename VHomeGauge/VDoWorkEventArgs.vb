'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class VDoWorkEventArgs
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
    ' *****     New (the Message)
    ' ***********************************************
    '
    Public Sub New(ByVal messageType As VDoWorkEventArgTypes, ByVal themessage As String)
        MyBase.New()
        '
        ' Set the globals
        '     Use encapsulated properties in order to enforce error checking
        '        
        EventType = messageType
        Message = themessage
        Time = Date.Now
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties & Data
    ' ****
    ' **********************************************
    '
    Private m_Message As String
    Private m_Time As DateTime
    Private m_EventType As VDoWorkEventArgTypes
    '
    ' ***********************************************
    ' *****      Message
    ' ***********************************************
    ' 
    Public Property Message As String
        Get
            '
            ' Error Checking
            '
            If IsNothing(m_Message) OrElse String.IsNullOrEmpty(m_Message) Then
                m_Message = ""

            End If
            Return m_Message
        End Get
        Set(value As String)
            m_Message = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****      Time
    ' ***********************************************
    ' 
    Public Property Time As Date
        Get
            '
            ' Error Checking
            '
            If IsNothing(m_Time) OrElse String.IsNullOrEmpty(m_Time) Then
                m_Time = Date.Now

            End If
            Return m_Time
        End Get
        Set(value As Date)
            m_Time = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****      Event Type
    ' ***********************************************
    ' 
    Public Property EventType As VDoWorkEventArgTypes
        Get
            Return m_EventType
        End Get
        Set(value As VDoWorkEventArgTypes)
            m_EventType = value
        End Set
    End Property
End Class

Public Enum VDoWorkEventArgTypes
    Informational
    ErrorCondition
    Termination
    '
End Enum
