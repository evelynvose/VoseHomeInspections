'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
' This class hijacks MsgBox from non-UI objects and raises an event
'      in its place.  VEvent args contains a flag, that if set instructs the UI
'      to display the message.
'      A local flag, when set, will cause the object to display a standard message box.
'      This flag has a lifetime of the object. It is useful for debugging subclassed objects.
'
Public MustInherit Class VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Protected Sub New()
        ' Do nothing on purpose!
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '
    '
    ' ***********************************************
    ' *****     +MsgBox(string, bool):object
    ' ***********************************************
    '
    ' Sets a flag in VEventArgs for the UI to show the message
    '      to the user.
    '
    Public Sub MsgBox(ByVal message As String, ByVal showme As Boolean)
        '
        ' Display a traditional MsgBox
        '
        If IsDebugFlag Then
            Interaction.MsgBox(message)
            '
        End If
        '
        ' Write an Event
        '
        If DoLogInEvents Then
            Dim erlog As New VErrorLogger
            erlog.WriteToEventLog(message)
            '
        End If
        '
        ' Write to Error File
        '
        If DoLogInFile Then
            Dim erLog As New VErrorLogger
            Dim stkTrace As New StackTrace
            erLog.WriteToErrorLog(message, stkTrace.ToString, My.Settings.DeveloperAppName)
            '
        End If
        '
        ' Always raise an event
        '
        RaiseVEvent(Me, New VEventArgs(message, showme))
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +MsgBox(object):object
    ' ***********************************************
    '
    Public Sub MsgBox(ByVal e As Exception)
        '
        ' Display a traditional MsgBox
        '
        If IsDebugFlag Then
            Interaction.MsgBox(e.Message)
            '
        End If
        '
        ' Write an Event
        '
        If DoLogInEvents Then
            Dim erlog As New VErrorLogger
            erlog.WriteToEventLog(e.Message)
            '
        End If
        '
        ' Write to Error File
        '
        If DoLogInFile Then
            Dim erLog As New VErrorLogger
            erLog.WriteToErrorLog(e.Message, e.StackTrace, My.Settings.DeveloperAppName)
            '
        End If
        '
        ' Always raise an event
        '
        RaiseVEvent(Me, New VEventArgs(e.Message & vbCrLf & "Stack Trace: " & e.StackTrace))
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +MsgBox(message):object
    ' ***********************************************
    '
    Public Sub MsgBox(ByVal message As String)
        '
        ' Display a traditional MsgBox
        '
        If IsDebugFlag Then
            Interaction.MsgBox(message)
            '
        End If
        '
        ' Write an Event
        '
        If DoLogInEvents Then
            Dim erlog As New VErrorLogger
            erlog.WriteToEventLog(message)
            '
        End If
        '
        ' Write to Error File
        '
        If DoLogInFile Then
            Dim erLog As New VErrorLogger
            Dim stkTrace As New StackTrace
            erLog.WriteToErrorLog(message, stkTrace.ToString, My.Settings.DeveloperAppName)
            '
        End If
        '
        ' Always raise an event
        '
        RaiseVEvent(Me, New VEventArgs(message))
        '
    End Sub
    '
    ' ***********************************************
    ' *****      #RaiseEvent(object, object)
    ' ***********************************************
    ' 
    Protected Sub RaiseVEvent(ByVal sender As Object, ByVal e As VEventArgs)
        RaiseEvent VEvent(sender, e)
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
    Private m_AllEvents As IList(Of VEventArgs) = New List(Of VEventArgs)
    Private m_IsDebugFlag As Boolean
    '
    ' ***********************************************
    ' *****     +IsVerbose(Boolean):Boolean 
    ' ***********************************************
    '
    Public Property IsVerbose As Boolean
        Get
            Return My.Settings.VerboseVEvents
        End Get
        Set(value As Boolean)
            My.Settings.VerboseVEvents = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Message(string):string 
    ' ***********************************************
    '
    ' The last message in the list of VEventArgs
    '
    Public Property Message As String
        Get
            If AllEvents.Count > 0 Then
                Return AllEvents(AllEvents.Count - 1).Message
            End If
            Return ""
        End Get
        Set(value As String)
            AllEvents.Add(New VEventArgs(value))
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +AllEvents(ilist):ilist 
    ' ***********************************************
    '
    ' This is a list of all of the events that occured during the life of this object.
    '      Typically used for debugging purposes.
    '
    Public Property AllEvents As IList(Of VEventArgs)
        Get
            Return m_AllEvents
        End Get
        Set(value As IList(Of VEventArgs))
            m_AllEvents = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +IsLogFile(boolean):boolean 
    ' ***********************************************
    '
    ' If set, the events are written to the log file in the application's launch folder
    '
    Public Property DoLogInFile As Boolean
        Get
            Return My.Settings.LogInErrorFile
        End Get
        Set(value As Boolean)
            My.Settings.LogInErrorFile = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +DoLogEvents(boolean):boolean 
    ' ***********************************************
    '
    ' If set, the events are sent to the application event file in WinOS
    '
    Public Property DoLogInEvents As Boolean
        Get
            Return My.Settings.LogInEventFile
        End Get
        Set(value As Boolean)
            My.Settings.LogInEventFile = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +IsDebugFlag(boolean):boolean 
    ' ***********************************************
    '
    ' If set, the events are displayed as a standard MsgBox
    '
    Public Property IsDebugFlag As Boolean
        Get
            Return m_IsDebugFlag
        End Get
        Set(value As Boolean)
            m_IsDebugFlag = value
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
        Me.IsShowMe = False
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +New( string, Boolean )
    ' ***********************************************
    '
    Public Sub New(ByVal message As String, ByVal showme As Boolean)
        Me.Message = message
        Me.IsShowMe = showme
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
    Private m_IsShowMe As Boolean
    '
    ' ***********************************************
    ' *****     +IsVerbose(Boolean):Boolean
    ' ***********************************************
    '
    Public Property IsShowMe As Boolean
        Get
            Return m_IsShowMe
        End Get
        Set(value As Boolean)
            m_IsShowMe = value
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
