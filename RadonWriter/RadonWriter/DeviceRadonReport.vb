Imports System.IO
Imports RadonWriter

Public Class DeviceRadonReport

    ' The heart of this class is the stream reader
    Private oReader As StreamReader

    ' Machine Information
    Private sSerialNumber As String
    Private sMonitorModel As String
    Private iCalibrationFactor1 As Integer
    Private iCalibrationFactor2 As Integer
    Private dCalibrationDate As Date

    ' Inspection Company Information
    Private sCompanyName As String
    Private sCompanyAddress1 As String
    Private sCompanyAddress2 As String
    Private sCompanyCity As String
    Private sCompanyState As String
    Private sCompanyPostalCode As String
    Private sCompanyLogoPath As String

    ' Customer Information
    Private sCustomerName As String
    Private sCustomerAddress1 As String
    Private sCustomerAddress2 As String
    Private sCustomerCity As String
    Private sCustomerState As String
    Private sCustomerZipCode As String
    Private sCustomerPhone As String

    ' Inspection Property Information
    Private sInspectionAddress1 As String
    Private sInspectionAddress2 As String
    Private sInspectionCity As String

    ' Radon Data Days 
    Private m_RadDate1 As String
    Private m_RadDate2 As String
    Private m_RadDate3 As String

    ' Radon data points by day
    Private m_RadonDataPointsDay1 As IList
    Private m_RadonDataPointsDay2 As IList
    Private m_RadonDataPointsDay3 As IList


    Public Sub New()


    End Sub

    Public Function OpenReport(ByVal theFileName As String) As Boolean
        If theFileName <> "" Then
            oReader = New StreamReader(theFileName, True)
            ProcessRadonFile()
            Return True

        End If

        Return False

    End Function

    Private Sub ProcessRadonFile()
        ' Set to the beginning of the file
        If oReader.BaseStream.Position > 0 Then
            oReader.BaseStream.Position = 0

        End If

        ' These statements must occur in the order in which they appear in the file.
        ' It is okay to bypass a line although you'll never fetch that line again without resetting the position of the stream.
        ' A failure to fine a value is a catastrophic failure!

        ' Read Machine Information
        sMonitorModel = ReadToValue("Continuous Radon Monitor:")
        sSerialNumber = ReadToValue("Serial Number:")
        iCalibrationFactor1 = ReadToValue("Calibration Factor 1:")
        iCalibrationFactor2 = ReadToValue("Calibration Factor 2:")
        dCalibrationDate = ReadToValue("Calibration Date:")

        ' Read Inspection Company Information
        sCompanyName = ReadToValue("Company Name:")
        sCompanyAddress1 = ReadToValue("Address 1:")
        sCompanyAddress2 = ReadToValue("Address 2:")
        sCompanyCity = ReadToValue("City:")
        sCompanyState = ReadToValue("State:")
        sCompanyPostalCode = ReadToValue("Zip:")
        sCompanyLogoPath = "ThePath"

        ' Read Inspector Information
        ' Note that this model does not store inspector information so we're going to take a liberty here!
        ' sInspectorPhone = ReadToValue("Phone:")
        ' sInspectorLicense = ReadToValue("License Number:")


        ' Read Customer Information
        ' This model's format is to treat the customer has having both a billing address and an inspection address
        ' Each block of information acts on its own to include customer name and phone number and inspection name and phone number
        ' We will just keep the customer billing information and the inspection address for our purposes
        sCustomerName = ReadToValue("Name:")
        sCustomerAddress1 = ReadToValue("Address 1:")
        sCustomerAddress2 = ReadToValue("Address 2:")
        sCustomerCity = ReadToValue("City:")
        sCustomerState = ReadToValue("State:")
        sCustomerZipCode = ReadToValue("Zip:")
        sCustomerPhone = ReadToValue("Phone :")

        ' Inspection Property Information
        sInspectionAddress1 = ReadToValue("Address 1:")
        sInspectionAddress2 = ReadToValue("Address 2:")
        sInspectionCity = ReadToValue("City:")

        ' Radon Day data. Should be 3-days under normal circumstances, but could be a few as two days.
        SetRadonDataPoints()


    End Sub

    Private Sub SetRadonDataPoints()
        Dim sTestLine As String


        m_RadDate1 = ReadToValue("Date:").Trim()
        sTestLine = oReader.ReadLine
        sTestLine = oReader.ReadLine

        ' Day 1
        'sTestLine = oReader.ReadLine
        m_RadonDataPointsDay1 = New List(Of RadonDataPoints)()
        sTestLine = oReader.ReadLine
        Do
            m_RadonDataPointsDay1.Add(New RadonDataPoints(Mid(sTestLine, 1, 5).Trim(), Mid(sTestLine, 7, 3).Trim(), Mid(sTestLine, 11).Trim()))
            sTestLine = oReader.ReadLine

        Loop Until oReader.EndOfStream Or sTestLine.StartsWith("Date:")

        ' When we break out of the loop sTestLine should contain "Date" unless it is end of file
        If sTestLine.StartsWith("Date:") Then
            m_RadDate2 = sTestLine.Substring("Date:".Length() + 1).Trim()
            sTestLine = oReader.ReadLine
            sTestLine = oReader.ReadLine

        Else
            Exit Sub

        End If

        ' Day 2
        m_RadonDataPointsDay2 = New List(Of RadonDataPoints)()
        sTestLine = oReader.ReadLine
        Do
            m_RadonDataPointsDay2.Add(New RadonDataPoints(Mid(sTestLine, 1, 5).Trim(), Mid(sTestLine, 7, 3).Trim(), Mid(sTestLine, 11).Trim()))
            sTestLine = oReader.ReadLine

        Loop Until oReader.EndOfStream Or sTestLine.StartsWith("Date:")


        ' When we break out of the loop sTestLine should contain "Date" unless it is end of file
        If sTestLine.StartsWith("Date:") Then
            m_RadDate3 = sTestLine.Substring("Date:".Length() + 1).Trim()
            sTestLine = oReader.ReadLine
            sTestLine = oReader.ReadLine

        Else
            Exit Sub

        End If

        ' Day 3
        m_RadonDataPointsDay3 = New List(Of RadonDataPoints)()
        sTestLine = oReader.ReadLine
        Do
            m_RadonDataPointsDay3.Add(New RadonDataPoints(Mid(sTestLine, 1, 5).Trim(), Mid(sTestLine, 7, 3).Trim(), Mid(sTestLine, 11).Trim()))
            sTestLine = oReader.ReadLine

        Loop Until oReader.EndOfStream Or sTestLine.StartsWith("Date:")

    End Sub

    Private Function ReadToValue(sValue As String) As String
        Dim sTestLine As String

        While Not oReader.EndOfStream
            sTestLine = oReader.ReadLine
            If sTestLine.StartsWith(sValue) Then
                sTestLine = sTestLine.Substring(sValue.Length() + 1)
                sTestLine.TrimEnd()
                sTestLine.TrimStart()
                Return sTestLine

            End If


        End While

        Return ""

    End Function


    ' The heart of this class is its radon report
    Public ReadOnly Property ReportBody As String
        Get
            If oReader.BaseStream.Position > 0 Then
                oReader.BaseStream.Position = 0

            End If
            Return oReader.ReadToEnd

        End Get
    End Property

    ' Equipment Information
    Public ReadOnly Property Model As String
        Get
            Return sMonitorModel
        End Get
    End Property
    Public ReadOnly Property SerialNumber As String
        Get
            Return sSerialNumber

        End Get
    End Property

    ' Inspection Company Information
    Public Property CompanyName() As String
        Get
            Return sCompanyName

        End Get
        Set(ByVal value As String)
            sCompanyName = value

        End Set
    End Property
    Public Property CompanyAddress1() As String
        Get
            Return sCompanyAddress1

        End Get
        Set(value As String)
            sCompanyAddress1 = value

        End Set
    End Property
    Public Property CompanyAddress2() As String
        Get
            Return sCompanyAddress2

        End Get
        Set(value As String)
            sCompanyAddress2 = value

        End Set
    End Property
    Public Property CompanyCity() As String
        Get
            Return sCompanyCity

        End Get
        Set(value As String)
            sCompanyCity = value

        End Set
    End Property
    Public Property CompanyState() As String
        Get
            Return sCompanyState

        End Get
        Set(value As String)
            sCompanyState = value.Substring(0, 2)

        End Set
    End Property
    Public Property CompanyZipCode() As String
        Get
            Return sCompanyPostalCode

        End Get
        Set(value As String)
            sCompanyPostalCode = value.Substring(0, 10)

        End Set
    End Property

    ' Customer Information
    Public Property CustomerName() As String
        Get
            Return sCustomerName

        End Get
        Set(value As String)
            sCustomerName = value

        End Set
    End Property
    Public Property CustomerAddress1() As String
        Get
            Return sCustomerAddress1

        End Get
        Set(value As String)
            sCustomerAddress1 = value

        End Set
    End Property
    Public Property CustomerAddress2() As String
        Get
            Return sCustomerAddress2

        End Get
        Set(value As String)
            sCustomerAddress2 = value

        End Set
    End Property
    Public Property CustomerCity() As String
        Get
            Return sCustomerCity

        End Get
        Set(value As String)
            sCustomerCity = value

        End Set
    End Property
    Public Property CustomerState() As String
        Get
            Return sCustomerState

        End Get
        Set(value As String)
            sCustomerState = value.Substring(0, 2)

        End Set
    End Property
    Public Property CustomerZipCode() As String
        Get
            Return sCustomerZipCode

        End Get
        Set(value As String)
            sCustomerZipCode = value.Substring(0, 10)

        End Set
    End Property
    Public Property CustomerPhone() As String
        Get
            Return sCustomerPhone

        End Get
        Set(value As String)
            sCustomerPhone = value

        End Set
    End Property


    ' Inspection Site Infomation
    Public Property InspectionAddess1() As String
        Get
            Return sInspectionAddress1

        End Get
        Set(value As String)
            sInspectionAddress1 = value

        End Set
    End Property
    Public Property InspectionAddess2() As String
        Get
            Return sInspectionAddress2

        End Get
        Set(value As String)
            sInspectionAddress2 = value

        End Set
    End Property
    Public Property InspectionCity() As String
        Get
            Return sInspectionCity

        End Get
        Set(value As String)
            sInspectionCity = value

        End Set
    End Property


    ' Radon Data Points
    Public ReadOnly Property RadonDataPointsDay1 As List(Of RadonDataPoints)
        Get
            Return m_RadonDataPointsDay1
        End Get
    End Property

    Public ReadOnly Property RadonDataPointsDay2 As List(Of RadonDataPoints)
        Get
            Return m_RadonDataPointsDay2
        End Get
    End Property

    Public ReadOnly Property RadonDataPointsDay3 As List(Of RadonDataPoints)
        Get
            Return m_RadonDataPointsDay3
        End Get
    End Property

    ' dates
    Public Property TestStartDate As String
        Get
            Return RadDate1
        End Get
        Set(value As String)
            RadDate1 = value
        End Set
    End Property

    Public Property RadDate1 As String
        Get
            Return m_RadDate1
        End Get
        Set(value As String)
            m_RadDate1 = value
        End Set
    End Property

    Public Property RadDate2 As String
        Get
            Return m_RadDate2
        End Get
        Set(value As String)
            m_RadDate2 = value
        End Set
    End Property

    Public Property RadDate3 As String
        Get
            Return m_RadDate3
        End Get
        Set(value As String)
            m_RadDate3 = value
        End Set
    End Property
End Class
