Imports System.IO

Public Class DeviceRadonReport

    ' **********************************************
    ' ****
    ' ******    Members
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Open the Report
    ' ****
    ' **********************************************
    ' 
    Public Function OpenReport(ByVal theFileName As String) As Boolean
        If theFileName <> "" Then
            m_Reader = New StreamReader(theFileName, True)
            ProcessDeviceFile()
            Return True

        End If

        Return False

    End Function


    ' **********************************************
    ' ****
    ' ******    Process Device File
    ' ****
    ' **********************************************
    ' 
    Private Sub ProcessDeviceFile()
        ' Set to the beginning of the file
        If m_Reader.BaseStream.Position > 0 Then
            m_Reader.BaseStream.Position = 0

        End If

        ' These statements must occur in the order in which they appear in the file.
        ' It is okay to bypass a line although you'll never fetch that line again without resetting the position of the stream.
        ' A failure to fine a value is a catastrophic failure!

        ' Read Machine Information
        SetDeviceModel(ReadToValue("Continuous Radon Monitor:"))
        SetDeviceSerialNumber(ReadToValue("Serial Number:"))
        CalibrationFactor1 = ReadToValue("Calibration Factor 1:")
        CalibrationFactor2 = ReadToValue("Calibration Factor 2:")
        CalibrationDate = ReadToValue("Calibration Date:")

        ' Read Inspection Company Information
        ReadToValue("Company Name:")
        ReadToValue("Address 1:")
        ReadToValue("Address 2:")
        ReadToValue("City:")
        ReadToValue("State:")
        ReadToValue("Zip:")


        ' Read Customer Information
        ' This model's format is to treat the customer has having both a billing address and an inspection address
        ' Each block of information acts on its own to include customer name and phone number and inspection name and phone number
        ' We will just keep the customer billing information and the inspection address for our purposes
        Customer.Name = ReadToValue("Name:")
        Customer.Address1 = ReadToValue("Address 1:")
        Customer.Address2 = ReadToValue("Address 2:")
        Customer.City = ReadToValue("City:")
        Customer.State = ReadToValue("State:")
        Customer.PostalCode = ReadToValue("Zip:")
        Customer.Phone = ReadToValue("Phone :")

        ' Inspection Property Information
        SubjectProperty.Address1 = ReadToValue("Address 1:")
        SubjectProperty.Address2 = ReadToValue("Address 2:")
        SubjectProperty.City = ReadToValue("City:")

        ' Radon Day data. Should be 3-days under normal circumstances, but could be a few as two days.
        ProcessRadonPoints()


    End Sub





    ' **********************************************
    ' ****
    ' ******    ProcessRadonPoints
    ' ****
    ' **********************************************
    ' 
    Private Sub ProcessRadonPoints()
        Dim theRawPoints As IList = New List(Of String)()

        ' Read the file into the list
        While Not m_Reader.EndOfStream
            theRawPoints.Add(m_Reader.ReadLine)

        End While


        ' Remove column headers and white lines
        For x As Integer = theRawPoints.Count - 1 To 0 Step -1
            Dim RawPoints = theRawPoints(x)

            If Not IsNumeric(Left(RawPoints, 1)) And Not Left(RawPoints, Len("Date:")) = "Date:" Then
                theRawPoints.RemoveAt(x)

            End If
        Next

        ' Pass through the list, extract the dates
        ' Day 1
        For Each s As String In theRawPoints
            If s.IndexOf("Date:") > -1 Then
                If RadDate1 = "" Then
                    RadDate1 = Mid(s, Len("Date:") + 1)

                ElseIf RadDate2 = "" Then
                    RadDate2 = Mid(s, Len("Date:") + 1)

                Else
                    RadDate3 = Mid(s, Len("Date:") + 1)

                End If
            End If
        Next

        ' Insert the dates at the beginning of each line, and remove the date lines
        Dim WorkingDate As String = RadDate3
        Dim BlockCount As Integer = 3
        For x As Integer = theRawPoints.Count - 1 To 0 Step -1
            Dim RawPoints = theRawPoints(x)

            If RawPoints.IndexOf("Date:") > -1 Then
                theRawPoints.RemoveAt(x)

                If BlockCount = 3 Then
                    BlockCount = 2
                    WorkingDate = RadDate2
                    Continue For

                ElseIf BlockCount = 2 Then
                    BlockCount = 1
                    WorkingDate = RadDate1
                    Continue For
                ElseIf BlockCount = 1 Then
                    Continue For

                End If
            End If

            ' Insert the date
            theRawPoints(x) = WorkingDate & vbTab & RawPoints
        Next

        ' Now that we have the perfect list let's make the list of RadonDataPoints
        Dim PCIL As Double
        Dim Splits() As String
        For Each s In theRawPoints
            Splits = s.Split(New String() {ControlChars.Tab}, StringSplitOptions.None)

            ' Calculate the PCIL
            PCIL = 0
            If Double.TryParse(Splits(2), PCIL) Then
                PCIL = PCIL * (1 / CalibrationFactor1)

            End If

            RadonDataPoints.Add(New RadonDataPoint(Splits(0), Splits(1), Splits(2), Splits(3), PCIL))

        Next


    End Sub








    ' **********************************************
    ' ****
    ' ******    Read To Value
    ' ****
    ' **********************************************
    ' 
    Private Function ReadToValue(sValue As String) As String
        Dim sTestLine As String

        While Not m_Reader.EndOfStream
            sTestLine = m_Reader.ReadLine
            If sTestLine.StartsWith(sValue) Then
                sTestLine = sTestLine.Substring(sValue.Length() + 1)
                sTestLine.TrimEnd()
                sTestLine.TrimStart()
                Return sTestLine

            End If


        End While

        Return ""

    End Function



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    ' The heart of this class is its radon report
    Public ReadOnly Property ReportBody As String
        Get
            If m_Reader.BaseStream.Position > 0 Then
                m_Reader.BaseStream.Position = 0

            End If
            Return m_Reader.ReadToEnd

        End Get
    End Property
    Private m_Reader As StreamReader

    ' Equipment Information
    Public ReadOnly Property DeviceModel As String
        Get
            Return m_DeviceModel
        End Get
    End Property
    Private Sub SetDeviceModel(ByVal value As String)
        m_DeviceModel = value
    End Sub
    Private m_DeviceModel As String = ""


    Public ReadOnly Property DeviceSerialNumber As String
        Get
            Return m_DeviceSerialNumber

        End Get
    End Property
    Private Sub SetDeviceSerialNumber(ByVal value As String)
        m_DeviceSerialNumber = value
    End Sub
    Private m_DeviceSerialNumber As String = ""



    ' Customer Information
    Public Property Customer() As Customer
        Get
            Return m_Customer

        End Get
        Set(value As Customer)
            m_Customer = value

        End Set
    End Property
    Private m_Customer As New Customer


    ' Subject Property Infomation
    Public Property SubjectProperty() As SubjectProperty
        Get
            Return m_SubjectProperty

        End Get
        Set(value As SubjectProperty)
            m_SubjectProperty = value

        End Set
    End Property
    Private m_SubjectProperty As SubjectProperty = New SubjectProperty




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
            m_RadDate1 = value.Trim
        End Set
    End Property
    Private m_RadDate1 As String = ""

    Public Property RadDate2 As String
        Get
            If IsNothing(m_RadDate2) Then
                m_RadDate2 = ""
            End If
            Return m_RadDate2
        End Get
        Set(value As String)
            m_RadDate2 = value.Trim
        End Set
    End Property
    Private m_RadDate2 As String = ""

    Public Property RadDate3 As String
        Get
            If IsNothing(m_RadDate3) Then
                m_RadDate3 = ""
            End If
            Return m_RadDate3
        End Get
        Set(value As String)
            m_RadDate3 = value.Trim
        End Set
    End Property
    Private m_RadDate3 As String = ""

    Public Property RadonDataPoints As IList
        Get
            Return m_RadonDataPoints
        End Get
        Set(value As IList)
            m_RadonDataPoints = value
        End Set
    End Property
    Private m_RadonDataPoints As IList = New List(Of RadonDataPoint)

    Public Property CalibrationFactor1 As Double
        Get
            Return m_CalibrationFactor1
        End Get
        Set(value As Double)
            m_CalibrationFactor1 = value
        End Set
    End Property
    Private m_CalibrationFactor1 As Double


    Public Property CalibrationFactor2 As Double
        Get
            Return m_CalibrationFactor2
        End Get
        Set(value As Double)
            m_CalibrationFactor2 = value
        End Set
    End Property
    Private m_CalibrationFactor2 As Double

    Public Property CalibrationDate As Date
        Get
            Return m_CalibrationDate
        End Get
        Set(value As Date)
            m_CalibrationDate = value
        End Set
    End Property
    Private m_CalibrationDate As Date = #04/18/1959#








End Class
