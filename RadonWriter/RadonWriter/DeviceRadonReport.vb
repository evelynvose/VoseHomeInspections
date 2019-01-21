
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports System.IO

Public Class DeviceRadonReport

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    '



    ' **********************************************
    ' ****
    ' ******    Methods
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

        ' Read Device Information
        With Device
            .Model = (ReadToValue("Continuous Radon Monitor:"))
            .SerialNumber = (ReadToValue("Serial Number:"))
            Double.TryParse(ReadToValue("Calibration Factor 1:"), .CalibrationFactor1)
            Double.TryParse(ReadToValue("Calibration Factor 2:"), .CalibrationFactor2)
            Date.TryParse(ReadToValue("Calibration Date:"), .CalibrationDate)

        End With


        ' Read Inspection Company Information 
        With Company
            .Name = ReadToValue("Company Name:")
            .Address1 = ReadToValue("Address 1:")
            .Address2 = ReadToValue("Address 2:")
            .City = ReadToValue("City:")
            .State = ReadToValue("State:")
            .PostalCode = ReadToValue("Zip:")
        End With

        ' Read Customer Information
        ' This model's format is to treat the customer has having both a billing address and an inspection address
        ' Each block of information acts on its own to include customer name and phone number and inspection name and phone number
        ' We will just keep the customer billing information and the inspection address for our purposes
        With Customer
            .Name = ReadToValue("Name:")
            .Address1 = ReadToValue("Address 1:")
            .Address2 = ReadToValue("Address 2:")
            .City = ReadToValue("City:")
            .State = ReadToValue("State:")
            .PostalCode = ReadToValue("Zip:")
            .Phone = ReadToValue("Phone :")
        End With

        ' Inspection Property Information
        With SubjectProperty
            .Address1 = ReadToValue("Address 1:")
            .Address2 = ReadToValue("Address 2:")
            .City = ReadToValue("City:")
            .State = "NC"
        End With


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
                ' Watch out for that pesky divide by zero thing! :0)
                If Device.CalibrationFactor1 > 0 Then
                    PCIL = PCIL * (1 / Device.CalibrationFactor1)
                End If

            End If

            RadonDataPoints.Add(New RadonDataPoint(Splits(0), Splits(1), Splits(2), Splits(3), PCIL))

        Next


    End Sub




    ' **********************************************
    ' ****
    ' ******    Overall Average
    ' ****
    ' **********************************************
    ' 
    Private Function CalcOverallAverage() As Double
        Dim Total As Double

        For Each point As RadonDataPoint In RadonDataPoints
            Total += point.PCIL

        Next

        If Total = 0 Then Return Total

        ' Catch that pesky divide by zero!
        If RadonDataPoints.Count <= 0 Then Return 0
        Return Total / RadonDataPoints.Count

    End Function




    ' **********************************************
    ' ****
    ' ******    EPA Average
    ' ****
    ' **********************************************
    ' 
    Private Function CalcEpaAverage() As Double

        Dim Total As Double
        Dim i As Integer

        For Each point As RadonDataPoint In RadonDataPoints
            If i > 3 Then
                Total += point.PCIL

            End If

            i += 1

        Next

        ' Catch that pesky divide by zero!
        If RadonDataPoints.Count - 4 <= 0 Then Return 0

        Return Total / (RadonDataPoints.Count - 4)


    End Function






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



    ' Device Information
    Public ReadOnly Property Device As Device
        Get
            Return m_Device
        End Get
    End Property
    Private m_Device As Device = New Device



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


    ' Company Information
    Public ReadOnly Property Company As Company
        Get
            Return m_Company
        End Get
    End Property
    Private m_Company As New Company



    ' Dates
    Public Property StartDate As String
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


    Public ReadOnly Property OverallAverage As Double
        Get
            Return CalcOverallAverage()
        End Get
    End Property

    Public ReadOnly Property EpaAverage As Double
        Get
            Return CalcEpaAverage()
        End Get
    End Property

    Public ReadOnly Property CertificationStamp As String
        Get
            If CalcEpaAverage() > 4 Then
                Return "FAIL"

            End If
            If CalcEpaAverage() >= 2 And CalcEpaAverage() <= 4 Then
                Return "Pass" & vbCrLf & "With Caution"
            End If

            Return "PASS"

        End Get
    End Property

    Public ReadOnly Property Recommendations As String
        Get
            Select Case CertificationStamp
                Case "FAIL"
                    Return "Radon is the second leading cause of lung cancer, after smoking. The US EPA and Surgeon General strongly recommend taking further action when a homes radon test results are 4.0 pCi/l or greater."

                Case "PASS"
                    Return "Radon is the second leading cause of lung cancer, after smoking. The average indoor radon level is estimated to be about 1.3 pCi/l; roughly 0.4 pCi/l of radon is normally found in the outside air. Consider having your home tested one more time in a different season than when this test was done."

            End Select

            Return "Radon is the second leading cause of lung cancer, after smoking. Radon levels less than 4.0 pCi/l still pose some risk and in many cases may be reduced. If the radon level in the home is between 2.0 and 4.0  pCi/l, the EPA still recommends that you consider fixing the home."

        End Get
    End Property

End Class
