Public Class DataLogger
    Inherits TemperaturePoints(Of TemperaturePoint)

    Private m_Hour As Date

    Public Sub New(v As String)
        PointsByHour(v)

    End Sub

    Public Function PointsByHour(ByVal theHour As String) As TemperaturePoints(Of TemperaturePoint)

        Dim tmpPoints As New TemperaturePoints(Of TemperaturePoint)

        If IsNothing(theHour) Then theHour = "00.00.00"
        Try
            m_Hour = theHour


        Catch ex As Exception

        End Try



        Return tmpPoints
    End Function


End Class
