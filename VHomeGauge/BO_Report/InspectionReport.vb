'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class InspectionReport
    Inherits ReportADO
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' 
    ' ***********************************************
    ' *****     New() as in virgin
    ' ***********************************************
    '   
    Public Sub New()
        MyBase.New()

        ' This makes this a valid report
        ReportType = ReportTypes.HomeInspection

    End Sub
    '
    ' ***********************************************
    ' *****     New(id)
    ' ***********************************************
    '
    Public Sub New(ByVal anID As Guid)
        MyBase.New(anID)
        '
        ' An inspection report has two possible instantiation cases:
        ' 1) It is already in the dB, in which case, we load this biz object, or
        ' 2) it is an HGI report and we use their GUID.
        '
        ' Note that in the future, we may need to instantiate a new inspection report,
        ' especially if we develop our own Companion.  We'll deal with this use case 
        ' when that time comes.
        '
        If ReportType <> ReportTypes.HomeInspection Then
            MsgBox("Class Report" & vbCrLf & "Not a valid Report Type!")

        End If

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public Overloads Property ReportNumber As String
        Get
            Return MyBase.ReportNumber
        End Get
        Set(value As String)
            ' The report number should be broken into two parts, the report number and the version.  More than two parts is not
            ' a recognized format so we'll do the best we can and let the user make corrections.
            Dim reportSplits() As String
            reportSplits = value.Split(" ")
            If reportSplits.Count > 0 AndAlso reportSplits(0) <> "" Then
                MyBase.ReportNumber = reportSplits(0)
                If reportSplits.Count = 1 Then
                    Array.Resize(reportSplits, reportSplits.Length + 1)
                    reportSplits(1) = "1.0"

                End If
                If reportSplits.Count > 1 Then
                    ReportVersion = reportSplits(1).TrimStart("v")
                    ReportVersion = ReportVersion.TrimStart("V")

                End If
            End If
        End Set
    End Property
End Class
