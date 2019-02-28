Imports System.IO
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1

Public Class HGIReportInfoRepository
    Implements IDoWorkWorker
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
    ' *****     DoWork
    ' ***********************************************
    '
    Public Sub DoWork() Implements IDoWorkWorker.DoWork
        '
        ' This method serves solely to expose the report processor method and is
        '      a Vose requirement for vProgressBar.
        '
        BuildReportRepsitory()
        '
        ' Set the terrmination Message
        '
        LastErrorMessage = "Success!"
        RaiseEvent RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Termination, LastErrorMessage))
        '
    End Sub
    '  
    ' ***********************************************    
    ' *****      Build Report Repository
    ' ***********************************************
    '
    Private Sub BuildReportRepsitory()
        '
        m_ReportInfoRepository = New List(Of ReportInfo)
        '
        ' Open ever file that fits the filter: report.hr5.
        ' Because HG stores reports in folders and the filename is always Report.hr5, we have
        '   to filter our superfluous folders such as temporary reports and HG supplied sample reports.
        '
        Try
            For Each f As String In Directory.GetFiles(My.Settings.HomeGaugeReportsPath, "report.hr5", SearchOption.AllDirectories)
                If f.Contains("00000") Then Continue For ' Typical temporary directories start with at least five zeros: 00000
                If f.Contains("sample") Then Continue For ' Sample reports
                If f.Contains("Sample") Then Continue For ' Sample reports
                '
                ' Okay - let's go!
                '
                Dim theReportFile As New ReportInfo
                theReportFile.SetPath(f)        ' set the path, which kicks off an XML file parser to fill the FileInfo's data from the report.
                RaiseEvent RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.Informational, theReportFile.ReportFullName))
                m_ReportInfoRepository.Add(theReportFile)
                '
            Next
        Catch ex As Exception
            LastErrorMessage = "BuildReportRepository()" & vbCrLf & ex.Message
            RaiseEvent RaiseDoWorkEvent(Me, New VDoWorkEventArgs(VDoWorkEventArgTypes.ErrorCondition, LastErrorMessage))
            '
        End Try
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    Public Event RaiseDoWorkEvent(sender As Object, theEventArgs As VDoWorkEventArgs) Implements IDoWorkWorker.RaiseDoWorkEvent
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_LastErrorMessage As String = ""
    Private m_ReportInfoRepository As IList(Of ReportInfo)
    '
    ' ***********************************************
    ' *****     Last Error Message
    ' ***********************************************
    '
    Property LastErrorMessage As String Implements IDoWorkWorker.LastErrorMessage
        Get
            Return m_LastErrorMessage
        End Get
        Set(value As String)
            m_LastErrorMessage = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Report Info Repository
    ' ***********************************************
    '
    Public ReadOnly Property ReportInfoRepository As IList(Of ReportInfo)
        Get
            Return m_ReportInfoRepository
        End Get
    End Property


End Class
