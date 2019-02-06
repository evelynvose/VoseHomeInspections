' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class SerialNumber
    '
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
    Private Function GetSerialNumber() As String

        Dim serialGuid As Guid = Guid.NewGuid()
        Dim uniqueSerial As String = serialGuid.ToString("N")
        Dim uniqueSerialLength As String = uniqueSerial.Substring(0, 28).ToUpper()

        Dim serialArray As Char() = uniqueSerialLength.ToCharArray()
        Dim finalSerialNumber As String = ""

        Dim j As Integer = 0
        For i As Integer = 0 To 27
            For j = i To 4 + (i - 1)
                finalSerialNumber += serialArray(j)
            Next
            If j = 28 Then
                Exit For
            Else
                i = (j) - 1
                finalSerialNumber += "-"
            End If
        Next

        Return finalSerialNumber

    End Function



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Public ReadOnly Property Generate As String
        Get
            Return GetSerialNumber()
        End Get
    End Property

End Class
