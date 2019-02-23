Imports Syncfusion.Windows.Forms
Imports System.IO
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class frmReportBrowser
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     Refresh (the grid) Click
    ' ***********************************************
    '
    Private Sub bthRefreshDb_Click(sender As Object, e As EventArgs) Handles bthRefreshDb.Click
        dgReports.DataSource = BuildReportRepsitory()

    End Sub
    '
    ' ***********************************************
    ' *****     Import Click
    ' ***********************************************
    '
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        '
        ' Check to see if a report has been selected.
        '
        If IsNothing(dgReports.CurrentItem) Then
            MsgBox("Select a report in the grid!",, "Report Browser")
            Exit Sub
            '
        End If
        '
        ' Attempt to open and read the report into the database.
        '   First, check to see if it is already in the database.
        '
        If InspectionReport.Find(TryCast(dgReports.SelectedItem, ReportInfo).ReportID) Then
            Dim theDialog As New dlgReportInDb
            theDialog.ShowDialog()
            '
            If Not theDialog.UpdateFromReport Then
                Exit Sub
                '
            End If
            '
        End If
        '
        ' OK - rock and roll
        '
        ' Show the Progress Bar
        '
        Dim theProgressBar As New dlgReportImportProgressBar
        theProgressBar.TopMost = True
        theProgressBar.Show(Me)
        '
        ' Process the report
        '
        Dim theHGIReportProcessor As New HGIReportProcessor(TryCast(dgReports.CurrentItem, ReportInfo).ReportFullName)
        theProgressBar.StartTimer()
        If theHGIReportProcessor.ProcessTheReport() Then
            theProgressBar.Hide()
            MsgBox("Report is Imported!",, "Report Processor")

        Else
            theProgressBar.Hide()
            MsgBox("Report is imported, but with errors!", MsgBoxStyle.Critical, "Report Processor")

        End If


        '
    End Sub
    '
    ' ***********************************************
    ' *****     Open HG
    ' ***********************************************
    '
    Private Sub btnOpenHG_Click(sender As Object, e As EventArgs) Handles btnOpenHG.Click
        '
        ' Check to see if a report has been selected.
        '
        If IsNothing(dgReports.CurrentItem) Then
            MsgBox("Select a report from the grid!",, "Report Browser")
            Exit Sub
            '
        End If
        '
        ' Launch HG with the report.
        '
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = TryCast(dgReports.CurrentItem, ReportInfo).ReportFullName
        ' startInfo.Arguments = f
        Process.Start(startInfo)
    End Sub
    '
    ' ***********************************************
    ' *****     Open dB
    ' ***********************************************
    '
    Private Sub btnOpenDb_Click(sender As Object, e As EventArgs) Handles btnOpenDb.Click
        '
        ' Not Implemented
        '
        MsgBox("Feature not yet implemented!",, "Report Browser")
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
    ' *****      Build Report Repository
    ' ***********************************************
    '
    Private Function BuildReportRepsitory() As IList(Of ReportInfo)
        '
        Dim reportRepos As IList(Of ReportInfo) = New List(Of ReportInfo)
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
                reportRepos.Add(theReportFile)
                '
            Next
        Catch ex As Exception
            MsgBox("BuildReportRepository()" & vbCrLf & ex.Message,, "frmOpenReport Class")
            '
        End Try
        '
        Return reportRepos
        '
    End Function
    '
End Class

