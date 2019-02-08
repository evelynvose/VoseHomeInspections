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
        Const Length As Int64 = 16

        Dim serialGuid As Guid = Guid.NewGuid()
        Dim uniqueSerial As String = serialGuid.ToString("N")
        Dim uniqueSerialLength As String = uniqueSerial.Substring(0, 28).ToUpper()

        Dim serialArray As Char() = uniqueSerialLength.ToCharArray()
        Dim finalSerialNumber As String = ""

        Dim j As Integer = 0
        For i As Integer = 0 To Length - 1
            For j = i To 4 + (i - 1)
                finalSerialNumber += serialArray(j)
            Next
            If j = Length Then
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
