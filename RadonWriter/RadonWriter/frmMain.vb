' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports System.IO



Public Class frmMain

    ' **********************************************
    ' ****
    ' ******    Members
    ' ****
    ' **********************************************
    '
    ' The radon report is the heart of this application!
    Private m_DeviceRadonReport As DeviceRadonReport





    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '
    ' **********************************************
    ' ****
    ' ******    LOAD
    ' ****
    ' **********************************************
    ' 
    ' Initialize the form's variables
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load User Settings

        FillInspectorInformation()

        FillCompanyInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

        Dim foundationTypes As IList = New List(Of FoundationType)()
        With foundationTypes
            .Add(New FoundationType("1", ""))
            .Add(New FoundationType("2", "Basement"))
            .Add(New FoundationType("3", "Closed Crawl Space"))
            .Add(New FoundationType("4", "Open Crawl Space"))
            .Add(New FoundationType("5", "Slab On Grade"))
        End With
        cbFoundation.DataSource = foundationTypes
        cbFoundation.DisplayMember = "Type"

        Dim weatherConditions As IList = New List(Of WeatherCondition)()
        With weatherConditions
            .Add(New WeatherCondition("1", ""))
            .Add(New WeatherCondition("2", "Clear"))
            .Add(New WeatherCondition("3", "Rain"))
            .Add(New WeatherCondition("4", "Snow"))
            .Add(New WeatherCondition("5", "Mix"))
        End With

        cbWeather.DataSource = weatherConditions
        cbWeather.DisplayMember = "Condition"

        ' For debugging
        tbYearBuilt.Text = "1989"
        tbSqFt.Text = "2025"
        tbLocation.Text = "Living Room"
        cbFoundation.SelectedIndex = 1
        cbWeather.SelectedIndex = 1

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
    ' ******    PROPERTIES Event
    ' ****
    ' **********************************************
    '  
    Private Sub msMainFileProperties_Click(sender As Object, e As EventArgs) Handles msMainFileProperties.Click
        Dim fProperties As New frmProperties

        fProperties.ShowDialog()

        ' Load the new values

        FillCompanyInformation()

        FillInspectorInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

    End Sub


    ' **********************************************
    ' ****
    ' ******     FILE SAVE Event
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

        ' Set up the site conditions
        If tbSqFt.Text = "" Or tbYearBuilt.Text = "" Or tbLocation.Text = "" Or cbWeather.Text = "" Or cbFoundation.Text = "" Then
            MsgBox("One or more of the site conditions is not set.")
            Return

        End If

        ' Add the user supplied subject property information
        With m_DeviceRadonReport.SubjectProperty
            .YearBuilt = tbYearBuilt.Text
            .Location = tbLocation.Text
            .SqFt = Convert.ToInt32(tbSqFt.Text)
            .Foundation = cbFoundation.Text
            .Weather = cbWeather.Text
        End With

        Dim excelRadonReport As New ExcelRadonReport(m_DeviceRadonReport, My.Settings.ReportTemplate, Inspector, Company)

        Dim FileDialog As FolderBrowserDialog = New FolderBrowserDialog()

        FileDialog.ShowNewFolderButton = True
        ' FileDialog.RootFolder = My.Application.Info.DirectoryPath
        If FileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not excelRadonReport.SaveAs(FileDialog.SelectedPath & "\" & excelRadonReport.SubjectProperty.Address1 & ", " & excelRadonReport.SubjectProperty.City & ".xlsx") Then
                MsgBox("Not Saved!")

            End If
            MsgBox("Saved!")

        Else
            MsgBox("File save operation canceled.")

        End If


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





    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
End Class
