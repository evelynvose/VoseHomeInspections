

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
    ' ******    Global Declarations
    ' ****
    ' **********************************************
    ' 
    Private _oRadonReport As DeviceRadonReport
    Private _sTemplatePath As String
    Private _oExcelEngine As ExcelEngine
    Private WithEvents _oWorkbook As IWorkbook
    Private _oSheetCetrificate As IWorksheet
    Private _oSheetData As IWorksheet


    Public Sub New(ByRef theRadonReport As DeviceRadonReport, ByVal TemplatePath As String)

        ' Make sure that theRadonReport is valid!

        If TypeOf theRadonReport Is DeviceRadonReport AndAlso IsNothing(theRadonReport) Then
            Throw New SystemException("RadonReport is null reference. Can't instantiate ExcelRadonReport class.")

        End If

        ' Set the radon report pointer
        _oRadonReport = theRadonReport

        ' Make sure that the template path is valid!
        If TypeOf TemplatePath Is String AndAlso String.IsNullOrEmpty(TemplatePath) OrElse String.IsNullOrWhiteSpace(TemplatePath) Then
            Throw New SystemException("Template path is empty. Can't instantiate ExcelRadonReport class.")

        End If

        ' Set the template path
        _sTemplatePath = TemplatePath

        ' Instantiate an ExcelEngine object
        _oExcelEngine = New ExcelEngine

        ' Set the workbook and sheet pointers
        Dim bErrorFlag As Boolean
        Try
            _oWorkbook = _oExcelEngine.Excel.Workbooks.Open(_sTemplatePath)

        Catch ex As Exception
            MsgBox(ex.Message)
            bErrorFlag = True
        End Try

        If bErrorFlag Then Return

        _oSheetCetrificate = _oWorkbook.Worksheets(0)
        _oSheetData = _oWorkbook.Worksheets(1)



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

            'Create Template Marker Processor
            Dim marker As ITemplateMarkersProcessor = _oWorkbook.CreateTemplateMarkersProcessor()

            'Insert Radon Array Vertically, which is the default

            ' Add the radon points to the template
            Dim points As IList(Of RadonDataPoints) = GetRadonDataPoints()
            marker.AddVariable("Radon", points)

            'Dim reports As IList(Of Report) = GetSalesReports()
            'marker.AddVariable("Reports", reports)

            'Process the markers in the template
            marker.ApplyMarkers(UnknownVariableAction.Skip)


            ' Set the version and save the workbook
            _oWorkbook.Version = ExcelVersion.Excel2013

            Try
                _oWorkbook.SaveAs("C:\Users\Evelyn\Documents\Test_TemplateMarker.xlsx")

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End Using
    End Sub

    ' Catch the Workbook File Saved Exception
    Private Sub Workbook_OnFileSaved(sender As Object, e As EventArgs) Handles _oWorkbook.OnFileSaved
        MsgBox("Saved!")

    End Sub

    'Gets a list of Radon Data Points
    Private Function GetRadonDataPoints() As List(Of RadonDataPoints)
        Dim points As New List(Of RadonDataPoints)()

        ' Load Day 1 
        For Each radonpoint As RadonDataPoints In _oRadonReport.RadonDataPointsDay1
            points.Add(radonpoint)

        Next
        points.RemoveAt(points.Count - 1)

        ' Load Day 2 
        For Each radonpoint As RadonDataPoints In _oRadonReport.RadonDataPointsDay2
            points.Add(radonpoint)

        Next
        points.RemoveAt(points.Count - 1)

        ' Load Day 3 
        For Each radonpoint As RadonDataPoints In _oRadonReport.RadonDataPointsDay3
            points.Add(radonpoint)

        Next
        'points.RemoveAt(points.Count - 1)

        Return points

    End Function



End Class





