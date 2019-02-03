


' **********************************************
' ****
' ******    This class takes in an Excel template,
' ******    replicates it, and then fills it with
' ******    data from the RadonReport class.
' ****
' **********************************************
' 
Imports RadonWriter
Imports Syncfusion.ExcelChartToImageConverter
Imports Syncfusion.ExcelToPdfConverter
Imports Syncfusion.Pdf
Imports Syncfusion.XlsIO




Public Class ExcelRadonReport

    ' **********************************************
    ' ****
    ' ******    Members
    ' ****
    ' **********************************************
    ' 
    Private m_DeviceRadonReport As DeviceRadonReport
    Private m_TemplatePath As String
    Private m_ExcelEngine As ExcelEngine
    Private WithEvents m_ExcelWorkbook As IWorkbook
    Private m_SheetCertificate As IWorksheet
    Private m_SheetData As IWorksheet
    Private m_RadonChart As IChartShape



    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New(ByRef theRadonReport As DeviceRadonReport, ByRef theDataLogger As DeviceDataLogger, ByVal TemplatePath As String, ByRef inspector As Inspector, ByRef company As Company)

        ' Make sure that theRadonReport is valid!

        If TypeOf theRadonReport Is DeviceRadonReport AndAlso IsNothing(theRadonReport) Then
            Throw New SystemException("RadonReport is null reference. Can't instantiate ExcelRadonReport class.")

        End If

        ' Set the radon report pointer
        m_DeviceRadonReport = theRadonReport

        ' Set the data logger
        m_DeviceDataLogger = theDataLogger

        ' Set the Inspector
        m_Inspector = inspector

        ' Set the Company
        m_Company = company

        ' Make sure that the template path is valid!
        If TypeOf TemplatePath Is String AndAlso String.IsNullOrEmpty(TemplatePath) OrElse String.IsNullOrWhiteSpace(TemplatePath) Then
            Throw New SystemException("Template path is empty. Can't instantiate ExcelRadonReport class.")

        End If

        ' Set the template path
        m_TemplatePath = TemplatePath

        ' Instantiate an ExcelEngine object
        m_ExcelEngine = New ExcelEngine

        ' Set the workbook and sheet pointers
        Dim bErrorFlag As Boolean
        Try
            m_ExcelWorkbook = m_ExcelEngine.Excel.Workbooks.Open(m_TemplatePath)

        Catch ex As Exception
            MsgBox(ex.Message)
            bErrorFlag = True
        End Try

        If bErrorFlag Then Return

        ' Save the sheet and radon chart for future ref
        m_SheetCertificate = m_ExcelWorkbook.Worksheets(0)
        m_SheetData = m_ExcelWorkbook.Worksheets(1)
        m_RadonChart = m_SheetCertificate.Charts(0)

        ' This is where all of the work gets done!
        FillTheExcelTemplate()


    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '     
    ' **********************************************
    ' ****
    ' ******    FILL The Template
    ' ****
    ' **********************************************
    ' 
    Private Sub FillTheExcelTemplate()
        '
        ' Stabilize the Radon Chart (overrides some UI settings)
        SetUpRadonChart()

        ' Create Template Marker Processor and fill the Workbook
        ' Assumes that there are "markers" in the template and that they are formatted and spelled correctly
        Dim marker As ITemplateMarkersProcessor = m_ExcelWorkbook.CreateTemplateMarkersProcessor()

        With m_DeviceRadonReport

            ' Add Customer Information
            marker.AddVariable("Customer", .Customer)

            ' Add subject property information
            marker.AddVariable("SubjectProperty", .SubjectProperty)

            ' Add Inspector Information
            marker.AddVariable("Inspector", Inspector)

            ' Add Company Information
            marker.AddVariable("Company", Company)

            ' Add Device Informationa
            marker.AddVariable("Device", .Device)

            ' Add Averages Information
            marker.AddVariable("EPAAverage", .EpaAverage)
            marker.AddVariable("OverallAverage", .OverallAverage)

            ' Add the Stamp Text
            marker.AddVariable("CertificationStamp", .CertificationStamp)

            ' Add EPA Recommendations
            marker.AddVariable("Recommendations", .Recommendations)

            ' Add Start Date
            marker.AddVariable("StartDate", .StartDate)

            ' Add the radon points to the template
            marker.AddVariable("Radon", .RadonDataPoints)

        End With

        If Not IsNothing(DeviceDataLogger) AndAlso Not IsNothing(DeviceDataLogger.TemperaturePoints) _
            AndAlso DeviceDataLogger.TemperaturePoints.Count <= m_DeviceRadonReport.RadonDataPoints.Count Then
            '
            SetUpTemperatureChart()
            marker.AddVariable("DataLogger", DeviceDataLogger.TemperaturePoints)

        End If

        ' Process the markers in the template. Note that the "Skip" option is supposed to prevent this
        ' function from throwing an exception, but it doesn't where an IList is concerned, so we catch it ourselves
        Try
            marker.ApplyMarkers(UnknownVariableAction.Skip)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub


    ' **********************************************
    ' ****
    ' ******    Set up Radon Chart
    ' ****
    ' **********************************************
    ' 
    Public Sub SetUpRadonChart()

        ' No legend, too confusing with the pass lines
        m_RadonChart.HasLegend = False

        ' Set the radon chart's primary value axis (left side) to contain the maximum plot area
        Dim maxPCil As Double
        For Each radonPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
            If radonPoint.PCIL > maxPCil Then
                maxPCil = radonPoint.PCIL

            End If
        Next

        ' Set the minimum (of the max) or round up to nearest 10
        Dim pvAxis As IChartValueAxis = m_RadonChart.PrimaryValueAxis
        With pvAxis
            If maxPCil <= 10 Then .MaximumValue = 10
            If maxPCil > 10 AndAlso maxPCil <= 15 Then .MaximumValue = 15
            If maxPCil > 15 AndAlso maxPCil <= 20 Then .MaximumValue = 20
            If maxPCil > 20 AndAlso maxPCil <= 30 Then .MaximumValue = 30
            If maxPCil > 30 AndAlso maxPCil <= 40 Then .MaximumValue = 40
            If maxPCil > 40 AndAlso maxPCil <= 50 Then .MaximumValue = 50
            If maxPCil > 50 AndAlso maxPCil <= 60 Then .MaximumValue = 60
            If maxPCil > 60 AndAlso maxPCil <= 70 Then .MaximumValue = 70
            If maxPCil > 70 AndAlso maxPCil <= 80 Then .MaximumValue = 80
            If maxPCil > 80 AndAlso maxPCil <= 90 Then .MaximumValue = 90
            If maxPCil > 90 AndAlso maxPCil <= 100 Then .MaximumValue = 100
            If maxPCil > 100 Then .MaximumValue = 200

        End With

        ' Set the primary category axis to the number of samples
        Try
            m_RadonChart.PrimaryCategoryAxis.MinimumValue = 0
            m_RadonChart.PrimaryCategoryAxis.MaximumValue = m_DeviceRadonReport.RadonDataPoints.Count

            ' Default to 100 hour test
            m_RadonChart.PrimaryCategoryAxis.MinorUnit = 1
            m_RadonChart.PrimaryCategoryAxis.MajorUnit = 5

            ' Readjust if 48 hour test
            If m_DeviceRadonReport.RadonDataPoints.Count <= 48 Then
                m_RadonChart.PrimaryCategoryAxis.MinorUnit = 0.4
                m_RadonChart.PrimaryCategoryAxis.MajorUnit = 2

            End If

        Catch ex As Exception

        End Try




    End Sub




    ' **********************************************
    ' ****
    ' ******    Set up Temperature Chart
    ' ******    (as secondary value axis on the right side)
    ' ****
    ' **********************************************
    ' 
    ' Set the chart type to show two lines with a right side value axis
    ' Find the Temperature serie and put it into the Secondary Value Axis (right side)
    '
    Private Sub SetUpTemperatureChart()

        With m_RadonChart

            ' Turn the user's template chart into a combination chart type
            If .ChartType <> ExcelChartType.Combination_Chart Then
                .ChartType = ExcelChartType.Combination_Chart

            End If

            ' I stuck this in here as an experiment to see why I can't control this
            ' feature reliable in the loop below.  The theory is that deselecting the prinary axis
            ' kicks off a process that enables a secondary axis, and so this needs to be done before 
            ' the series colors are set.
            For Each serie As IChartSerie In .Series
                If serie.Name = "Temperature" Then
                    serie.UsePrimaryAxis = False

                End If
            Next

            For Each serie As IChartSerie In .Series
                ' serie.SerieType = ExcelChartType.Line
                ' serie.UsePrimaryAxis = True

                Select Case serie.Name
                    Case "Temperature"
                        serie.SerieFormat.LineProperties.LineColor = Color.Blue
                        serie.SerieType = ExcelChartType.Scatter_Line
                        ' serie.UsePrimaryAxis = False

                    Case "Radon"
                        serie.SerieFormat.LineProperties.LineColor = Color.Black
                        serie.SerieType = ExcelChartType.Scatter_Line

                    Case "Humidity"
                        serie.SerieType = ExcelChartType.Scatter_Line
                        serie.SerieFormat.LineProperties.LineColor = Color.DarkGreen

                    Case "Pass Line"
                        serie.SerieFormat.LineProperties.LineColor = Color.Yellow
                        serie.SerieType = ExcelChartType.Line

                    Case "Fail Line"
                        serie.SerieFormat.LineProperties.LineColor = Color.Red
                        serie.SerieType = ExcelChartType.Line

                End Select
            Next

            ' Since there is temperature data, we need to turn on the secondary category axis 
            ' and set its label text amd orientation.
            If Not IsNothing(.SecondaryCategoryAxis) Then
                .SecondaryValueAxis.Visible = True
                .SecondaryValueAxis.Title = "Temperature, deg.F"
                .SecondaryValueAxis.TitleArea.TextRotationAngle = 90

            End If

        End With
    End Sub


    ' **********************************************
    ' ****
    ' ******    Save As Excel
    ' ****
    ' **********************************************
    ' 
    Public Function SaveAsExcel(ByVal filePath As String) As Boolean
        Dim docPath As String

        docPath = filePath

        If filePath = "" Then
            Return False

            ' docPath = My.Application.Info.DirectoryPath & m_DeviceRadonReport.SubjectProperty.Address1 & ".xlsx"

        End If

        ' Set the version and save the workbook
        m_ExcelWorkbook.Version = ExcelVersion.Excel2016

        Try
            ' m_ExcelWorkbook.SaveAs(docPath)
            m_ExcelWorkbook.Close(True, docPath & ".xlsx")


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Return True

    End Function



    ' **********************************************
    ' ****
    ' ******    Save As PDF
    ' ****
    ' **********************************************
    ' 
    Public Function SaveAsPDF(ByVal filePath As String) As Boolean
        Using m_ExcelEngine ' excelEngine As ExcelEngine = New ExcelEngine()
            Dim application As IApplication = m_ExcelEngine.Excel ' ExcelEngine.Excel
            application.DefaultVersion = ExcelVersion.Excel2016

            'Instantiating the ChartToImageConverter and assigning the ChartToImageConverter instance of XlsIO application
            application.ChartToImageConverter = New ChartToImageConverter()

            'Tuning chart image quality
            application.ChartToImageConverter.ScalingMode = ScalingMode.Best

            Dim workBook As IWorkbook = application.Workbooks.Open(filePath & ".xlsx")
            Dim workSheet As IWorksheet = workBook.Worksheets(0)

            Dim converter As New ExcelToPdfConverter(workSheet)

            Dim pdfDocument As New PdfDocument()
            pdfDocument = converter.Convert()
            pdfDocument.Save(filePath & ".pdf")

        End Using
        Return True
    End Function




    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    Private m_Inspector As Inspector
    Private m_Company As Company
    Private m_DeviceDataLogger As DeviceDataLogger

    ' 
    Public ReadOnly Property Inspector As Inspector
        Get
            Return m_Inspector
        End Get

    End Property

    Public ReadOnly Property SubjectProperty As SubjectProperty
        Get
            Return m_DeviceRadonReport.SubjectProperty

        End Get
    End Property

    Public ReadOnly Property Company As Company
        Get
            Return m_Company
        End Get
    End Property

    Public ReadOnly Property DeviceDataLogger As DeviceDataLogger
        Get
            Return m_DeviceDataLogger
        End Get

    End Property





    ' **********************************************
    ' ****
    ' ******    Event Handlers
    ' ****
    ' **********************************************
    ' 
    ' Catch the Workbook File Saved Exception
    'Private Sub Workbook_OnFileSaved(sender As Object, e As EventArgs) Handles m_ExcelWorkbook.OnFileSaved
    ' MsgBox("Saved!")

    'End Sub

End Class





