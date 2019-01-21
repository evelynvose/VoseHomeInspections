

' **********************************************
' ****
' ******    This class takes in an Excel template,
' ******    replicates it, and then fills it with
' ******    data from the RadonReport class.
' ****
' **********************************************
' 

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



    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New(ByRef theRadonReport As DeviceRadonReport, ByVal TemplatePath As String, ByRef inspector As Inspector, ByRef company As Company)

        ' Make sure that theRadonReport is valid!

        If TypeOf theRadonReport Is DeviceRadonReport AndAlso IsNothing(theRadonReport) Then
            Throw New SystemException("RadonReport is null reference. Can't instantiate ExcelRadonReport class.")

        End If

        ' Set the radon report pointer
        m_DeviceRadonReport = theRadonReport

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

        m_SheetCertificate = m_ExcelWorkbook.Worksheets(0)
        m_SheetData = m_ExcelWorkbook.Worksheets(1)

        ' This is where all of the work gets done!
        FillTheTemplate()


    End Sub



    ' **********************************************
    ' ****
    ' ******    FILL The Template
    ' ****
    ' **********************************************
    ' 
    Private Sub FillTheTemplate()
        Using excelEngine As ExcelEngine = New ExcelEngine()

            ' Create Template Marker Processor
            Dim marker As ITemplateMarkersProcessor = m_ExcelWorkbook.CreateTemplateMarkersProcessor()


            With m_DeviceRadonReport

                ' Add the radon points to the template
                'Dim points As IList(Of RadonDataPoint) = .RadonDataPoints
                marker.AddVariable("Radon", .RadonDataPoints)

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

            End With


            'Process the markers in the template
            Try
                marker.ApplyMarkers(UnknownVariableAction.Skip)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End Using

    End Sub




    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Public Function SaveAs(ByVal filePath As String) As Boolean
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
            m_ExcelWorkbook.Close(True, docPath)


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Return True

    End Function

    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public ReadOnly Property Inspector As Inspector
        Get
            Return m_Inspector
        End Get

    End Property
    Private m_Inspector As Inspector

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
    Private m_Company As Company




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





