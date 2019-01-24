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
    Private m_DeviceTemperatureReport As DeviceDataLogger


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

        If Not IsNothing(My.Settings.CompanyLogoPath) And My.Settings.CompanyLogoPath <> "" Then
            pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

        End If

        Dim foundationTypes As IList = New List(Of FoundationType)()
        With foundationTypes
            .Add(New FoundationType("1", ""))
            .Add(New FoundationType("2", "Basement"))
            .Add(New FoundationType("3", "Closed Crawl Space"))
            .Add(New FoundationType("4", "Open Crawl Space"))
            .Add(New FoundationType("5", "Slab On Grade"))
        End With
        cbSubjectPropertyFoundation.DataSource = foundationTypes
        cbSubjectPropertyFoundation.DisplayMember = "Type"

        Dim weatherConditions As IList = New List(Of WeatherCondition)()
        With weatherConditions
            .Add(New WeatherCondition("1", ""))
            .Add(New WeatherCondition("2", "Clear"))
            .Add(New WeatherCondition("3", "Rain"))
            .Add(New WeatherCondition("4", "Snow"))
            .Add(New WeatherCondition("5", "Mix"))
        End With

        cbSubjectPropertyWeather.DataSource = weatherConditions
        cbSubjectPropertyWeather.DisplayMember = "Condition"

        ' For debugging
        tbSubjectPropertyYearBuilt.Text = "1989"
        tbSubjectPropertySqFt.Text = "2025"
        tbSubjectPropertyLocation.Text = "Living Room"
        cbSubjectPropertyFoundation.SelectedIndex = 1
        cbSubjectPropertyWeather.SelectedIndex = 1
        tbSubjectPropertyOrderID.Text = "123456"

    End Sub


    ' **********************************************
    ' ****
    ' ******    OPEN FILE Methods
    ' ****
    ' **********************************************
    ' 
    Private Sub OpenRadonFile()

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

            If m_DeviceRadonReport.Open(OpenFileDialog1.FileName) Then

                FillTheForm()

            End If

        End If

    End Sub

    Private Sub OpenTemperatureFile()

        ' The heart of this app is the radon report and sometimes the temperature report
        m_DeviceTemperatureReport = New DeviceDataLogger

        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "csv",
            .FileName = "",
            .Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
            .Multiselect = False
        }

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim deviceTemps As New DeviceDataLogger

            If deviceTemps.Open(OpenFileDialog1.FileName) Then
                If Not IsNothing(m_DeviceRadonReport) Then
                    deviceTemps.AlignToRadonTime(m_DeviceRadonReport)

                End If
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
    Private Const constExcel = 0    ' Excel Spreadsheet 
    Private Const constPDF = 1      ' PDF rendition of the Excel spreadsheet

    Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcelToolStripMenuItem.Click
        SaveAs(constExcel)

    End Sub

    Private Sub PDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToolStripMenuItem.Click
        SaveAs(constPDF)
    End Sub


    Private Sub SaveAs(ByVal saveId As Integer)

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
        If tbSubjectPropertySqFt.Text = "" Or tbSubjectPropertyYearBuilt.Text = "" Or tbSubjectPropertyLocation.Text = "" Or cbSubjectPropertyWeather.Text = "" Or cbSubjectPropertyFoundation.Text = "" Then
            MsgBox("One or more of the site conditions is not set.")
            Return

        End If

        ' Add the user supplied subject property information
        With m_DeviceRadonReport.SubjectProperty
            .YearBuilt = tbSubjectPropertyYearBuilt.Text
            .Location = tbSubjectPropertyLocation.Text
            .SqFt = Convert.ToInt32(tbSubjectPropertySqFt.Text)
            .Foundation = cbSubjectPropertyFoundation.Text
            .Weather = cbSubjectPropertyWeather.Text
            .OrderID = tbSubjectPropertyOrderID.Text

        End With

        Dim excelRadonReport As New ExcelRadonReport(m_DeviceRadonReport, My.Settings.ReportTemplate, Inspector, Company)

        Dim FileDialog As FolderBrowserDialog = New FolderBrowserDialog()

        FileDialog.ShowNewFolderButton = True
        If FileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim filePath As String = FileDialog.SelectedPath & "\" & excelRadonReport.SubjectProperty.Address1 & ", " & excelRadonReport.SubjectProperty.City
            If Not excelRadonReport.SaveAsExcel(filePath) Then
                MsgBox("Excel Not Saved!")

            Else
                If saveId = constPDF Then
                    If Not excelRadonReport.SaveAsPDF(filePath) Then
                        MsgBox("PDF Not Saved!")

                    End If
                End If
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
    Private Sub RadonDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RadonDataToolStripMenuItem.Click
        OpenRadonFile()

    End Sub

    Private Sub TemperatureDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TemperatureDataToolStripMenuItem.Click
        OpenTemperatureFile()

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


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        tbSubjectPropertyLocation.Text = ""
        tbSubjectPropertyOrderID.Text = ""
        tbSubjectPropertySqFt.Text = ""
        tbSubjectPropertyYearBuilt.Text = ""
        cbSubjectPropertyFoundation.Text = ""
        cbSubjectPropertyWeather.Text = ""



    End Sub






    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
End Class
