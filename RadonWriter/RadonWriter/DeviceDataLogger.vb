Imports System.IO
Imports RadonWriter

Public Class DeviceDataLogger

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
    Public Function Open(ByVal theFileName As String) As Boolean
        If theFileName <> "" Then
            m_reader = New StreamReader(theFileName, True)
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
        If Reader.BaseStream.Position > 0 Then
            Reader.BaseStream.Position = 0

        End If

        While Not Reader.EndOfStream
            Dim splitArray() As String = Reader.ReadLine.Split(",")
            If Not splitArray(0).StartsWith("EasyLog") Then
                Dim theTemperaturePoint As New TemperaturePoint
                If splitArray(8) <> "" Then
                    m_SerialNumber = splitArray(8)

                End If
                Try
                    With theTemperaturePoint
                        .DataID = CType(splitArray(0), Integer)     ' The row number or ID number of the set of data from the logger
                        .Time = CType(splitArray(1), Date)
                        .Temperature = CType(splitArray(2), Double)
                        .HighAlarm = CType(splitArray(3), Double)
                        .LowAlarm = CType(splitArray(4), Double)
                        .RH = CType(splitArray(5), Double)
                        .DewPoint = CType(splitArray(6), Double)
                        .Comment = splitArray(7)

                    End With
                    m_TemperaturePoints.Add(theTemperaturePoint)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End While

    End Sub

    Public Function AlignToRadonTime(ByRef deviceradonmonitor As DeviceRadonReport) As Boolean

        If IsNothing(deviceradonmonitor) Then Return False

        ' Make a new list of temperature point sets that are within 2.5-minutes of a radon sample
        ' and set the time of the temperature point equal to the radon point
        Dim newTemperaturePoints As IList(Of TemperaturePoint) = New List(Of TemperaturePoint)
        Dim timeDiff As Double
        For Each radonDataPoint As RadonDataPoint In deviceradonmonitor.RadonDataPoints
            For Each temperatureDataPoint As TemperaturePoint In m_TemperaturePoints
                timeDiff = (temperatureDataPoint.Time - radonDataPoint.TimeStamp).TotalMinutes
                If timeDiff >= 0 And timeDiff <= 2.5 Then
                    newTemperaturePoints.Add(temperatureDataPoint)
                End If

            Next
        Next
        If newTemperaturePoints.Count > 0 Then
            m_TemperaturePoints = newTemperaturePoints

        End If
        Return True

    End Function








    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Private m_reader As StreamReader
    Private m_TemperaturePoints As IList(Of TemperaturePoint) = New List(Of TemperaturePoint)
    Private m_SerialNumber As String = ""


    Public ReadOnly Property Reader As StreamReader
        Get
            Return m_reader
        End Get
    End Property

    Public ReadOnly Property TemperaturePoints As IList(Of TemperaturePoint)
        Get
            Return m_TemperaturePoints
        End Get
    End Property

    Public ReadOnly Property SerialNumber As String
        Get
            Return m_SerialNumber
        End Get
    End Property
End Class
