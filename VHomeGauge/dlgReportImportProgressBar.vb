Imports Syncfusion.Windows.Forms
Imports System.ComponentModel
Imports System.IO
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class dlgReportImportProgressBar
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 

    '
    ' ***********************************************
    ' *****     Load
    ' ***********************************************
    '
    Private m_ReportProcessor As HGIReportProcessor
    Private Sub dlgReportImportProgressBar_Load(sender As Object, e As EventArgs) Handles Me.Load
        ProgressBarAdv1.Value = 0
        m_ReportProcessor = New HGIReportProcessor
        BackgroundWorker1.RunWorkerAsync()
        StartTimer()
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
    '
    ' ***********************************************
    ' *****     Start Timer
    ' ***********************************************
    '
    Public Sub StartTimer()
        Timer1.Enabled = True
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Kill Timer
    ' ***********************************************
    '
    Private Sub KillTimer()
        Timer1.Enabled = False
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
    ' ***********************************************
    ' *****     Timer 1_Tick
    ' ***********************************************
    '
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        '
        ' Stop the timer if the report is imported
        '
        If ReportIsImported Then
            KillTimer()
            ProgressBarAdv1.Visible = False
            StatusLabel.Visible = True
            '
        Else
            If ProgressBarAdv1.Value < 200 Then
                ProgressBarAdv1.Value += 1
                '
            Else
                ProgressBarAdv1.Value = 0
                '
            End If
        End If
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Background Worker 1_DoWork
    ' ***********************************************
    '
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        m_ReportProcessor.ProcessTheReport(m_ReportPath)
        '
    End Sub
    '
    ' ***********************************************
    ' *****     Background Worker 1_RunWorkerCompleted
    ' ***********************************************
    '
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ReportIsImported = True
        '
    End Sub
    '
    ' ***********************************************
    ' *****     btnOK Click
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Private m_ReportPath As FileInfo
    Private m_ReportIsImported As Boolean
    '
    ' ***********************************************
    ' *****     Report Path
    ' ***********************************************
    '
    Public Property ReportPath As FileInfo
        Get
            Return m_ReportPath
        End Get
        Set(value As FileInfo)
            m_ReportPath = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Report Is Imported
    ' ***********************************************
    '
    Public Property ReportIsImported As Boolean
        Get
            Return m_ReportIsImported
        End Get
        Set(value As Boolean)
            m_ReportIsImported = value
        End Set
    End Property
    '
End Class
