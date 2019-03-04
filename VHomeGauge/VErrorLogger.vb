Imports System.IO
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class VErrorLogger
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    Public Sub New()
        ' Do nothing on purpose!
    End Sub
    '
    ' ***********************************************
    ' *****     +New(string, string, string)
    ' ***********************************************
    '
    Public Sub New(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        WriteToErrorLog(msg, stkTrace, title)
        '
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
    ' *****     +WriteToErrorLog(string, string, string)
    ' ***********************************************
    '
    ' PURPOSE:       Open or create an error log and submit error message
    ' PARAMETERS:    msg - message to be written to error file
    '                stkTrace - stack trace from error message
    '                title - title of the error file entry
    ' RETURNS:       Nothing
    '*************************************************************
    '
    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        '
        ' Check and make the directory if necessary; this is set to look in 
        ' the Application folder, you may wish to place the error log in 
        ' another location depending upon the user's role and write access to 
        ' different areas of the file system
        '
        If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
            '
        End If
        '
        ' check the file
        '
        Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()
        '
        ' log it
        '
        Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("================================================" & vbCrLf)
        s1.Close()
        fs1.Close()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +WriteToEventLog(string, EventLogEntryType):bool
    ' ***********************************************
    '
    ' PURPOSE:       Write to Event Log
    ' PARAMETERS:    logEntry - Value to Write
    '                EventType - Entry Type, from EventLogEntryType 
    '               
    ' RETURNS:       True if successful
    '*************************************************************
    '
    Public Function WriteToEventLog(ByVal logEntry As String, ByVal eventType As EventLogEntryType) As Boolean
        VEventLogEntryType = eventType
        Return WriteToEventLog(logEntry)
        '
    End Function
    '
    ' ***********************************************
    ' *****     +WriteToEventLog(string):bool
    ' ***********************************************
    '
    Public Function WriteToEventLog(ByVal logEntry As String) As Boolean
        '
        ' AppName - Name of developer for the application. Needed by WinOS, because before writing to event log, you must 
        '           have a named EventLog source. 
        '
        Dim appName As String = My.Settings.DeveloperCompanyName
        '
        ' Name of Log (System, Application - Security is read-only) If you specify a non-existent log, the log will be created.
        '
        Dim logName As String = My.Settings.DeveloperAppName
        Dim objEventLog As New EventLog
        '
        Try
            '
            ' Register the Application as an Event Source
            '
            If Not EventLog.SourceExists(appName) Then
                EventLog.CreateEventSource(appName, logName)
                '
            End If
            '
            ' log the entry
            '
            objEventLog.Source = appName
            objEventLog.WriteEntry(logEntry, VEventLogEntryType)
            '
            Return True
            '
        Catch Ex As Exception
            ' Do Nothing
        End Try
        '
        Return False
        '
    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_EventLogType As EventLogEntryType = EventLogEntryType.Information
    '
    ' ***********************************************
    ' *****     -VEventLogEntryType(EventLogEntryType):EventLogEntryType
    ' ***********************************************
    '
    Private Property VEventLogEntryType As EventLogEntryType
        Get
            Return m_EventLogType
        End Get
        Set(value As EventLogEntryType)
            m_EventLogType = value
        End Set
    End Property
    '
End Class
