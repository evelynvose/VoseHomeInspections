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
        '
        ' OK - rock and roll
        '     by showing the Vose Progress Bar form. It takes an IDoWorkWorker implemented class and processes the Report
        '
        Dim theHGIReportInfoReposirory As New HGIReportInfoRepository
        Dim theVProgressBar As New dlgVProgressBar
        With theVProgressBar
            .SetDoWorkClass(theHGIReportInfoReposirory)
            .Text = "Build Report Info Repository"
            .AnnouncementVisible = False
            .RunningStatusVisible = True
            .OKButtonVisible = False
            .LaunchDoWork()
            .ShowDialog()
            '
        End With
        dgReports.DataSource = theHGIReportInfoReposirory.ReportInfoRepository

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
        '     by showing the Vose Progress Bar form. It takes an IDoWorkWorker implemented class and processes the Report
        '
        Dim TheHGIReportProcessor As New HGIReportProcessor(New FileInfo(TryCast(dgReports.CurrentItem, ReportInfo).ReportFullName))
        Dim theVProgressBar As New dlgVProgressBar
        With theVProgressBar
            .StartPosition = FormStartPosition.CenterParent
            .SetDoWorkClass(TheHGIReportProcessor)
            .Text = "Import Report"
            .AnnouncementVisible = True
            .RunningStatusVisible = True
            .OKButtonVisible = True
            .LaunchDoWork()
            .ShowDialog()
            '
        End With
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

    Private Sub btnGear_Click(sender As Object, e As EventArgs) Handles btnGear.Click
        Dim newRoleInfoRepository As RoleInfoRepository
        '
        ' This will cause the objects internal Intialize() to be called, thus loading the roleinfo table into memory.
        '
        newRoleInfoRepository = New RoleInfoRepository


    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    '
End Class

