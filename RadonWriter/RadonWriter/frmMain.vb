Imports System.IO



Public Class frmMain

    ' The radon report is the heart of this application!
    Private m_DeviceRadonReport As DeviceRadonReport

    ' **********************************************
    ' ****
    ' ******    LOAD
    ' ****
    ' **********************************************
    ' 
    ' Initialize the form's variables
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load User Settings
        tbInspectorName.Text = My.Settings.InspectorName
        tbInspectorLicense.Text = My.Settings.InspectorLicense
        tbInspectorPhone.Text = My.Settings.InspectorPhone

        FillCompanyInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

    End Sub


    ' **********************************************
    ' ****
    ' ******    OPEN FILE Event
    ' ****
    ' **********************************************
    ' 
    Private Sub OpenFile()

        ' The heart of this app is the radon report
        m_DeviceRadonReport = New DeviceRadonReport

        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "txt",
            .FileName = "",
            .Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .Multiselect = False
        }

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If m_DeviceRadonReport.OpenReport(OpenFileDialog1.FileName) Then

                FillTheForm()

            End If

        End If

    End Sub


    ' **********************************************
    ' ****
    ' ******    MAIN FILE PROPERTIES Event
    ' ****
    ' **********************************************
    '  
    Private Sub msMainFileProperties_Click(sender As Object, e As EventArgs) Handles msMainFileProperties.Click
        Dim fProperties As New frmProperties

        fProperties.ShowDialog()

        ' Load the new values
        tbInspectorName.Text = My.Settings.InspectorName
        tbInspectorLicense.Text = My.Settings.InspectorLicense
        tbInspectorPhone.Text = My.Settings.InspectorPhone

        FillCompanyInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

    End Sub


    ' **********************************************
    ' ****
    ' ******    MAIN FILE SAVE Event
    ' ****
    ' **********************************************
    ' 
    Private Sub msMainFileSave_Click(sender As Object, e As EventArgs) Handles msMainFileSave.Click

        ' Create a new Excel report using a template, but first let's make sure we have what we need!
        If String.IsNullOrEmpty(My.Settings.ReportTemplate) OrElse String.IsNullOrWhiteSpace(My.Settings.ReportTemplate) Then
            MsgBox("Template path is empty. Use Properties to set a template!")
            Exit Sub

        End If

        If IsNothing(m_DeviceRadonReport) Then
            MsgBox("DeviceRadonReport is null reference. Open a Device first!")
            Exit Sub

        End If

        Dim oExcelRadonReport As New ExcelRadonReport(m_DeviceRadonReport, My.Settings.ReportTemplate)





    End Sub


    ' **********************************************
    ' ****
    ' ******    MAIN FILE OPEN Event
    ' ****
    ' **********************************************
    ' 
    Private Sub msMainFileOpen_Click_1(sender As Object, e As EventArgs) Handles msMainFileOpen.Click
        OpenFile()
    End Sub


    ' **********************************************
    ' ****
    ' ******    MAIN FILE EXIT Event
    ' ****
    ' **********************************************
    ' 
    Private Sub msMainFileExit_Click_1(sender As Object, e As EventArgs) Handles msMainFileExit.Click

        Application.Exit()
    End Sub


End Class
