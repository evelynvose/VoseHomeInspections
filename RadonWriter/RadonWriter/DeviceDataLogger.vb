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
            Reader = New StreamReader(theFileName, True)
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
            If splitArray(0).StartsWith("EasyLog") Then
                m_SerialNumber = splitArray(8)
            Else
                Dim theTemperaturePoint As New TemperaturePoint
                With theTemperaturePoint
                    .DataID = splitArray(0)

                End With
            End If

        End While

    End Sub










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
