Imports System.IO

' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class ClientRepository
    Inherits PeopleRepository

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        MyBase.New(New FileInfo(My.Settings.People4DataPath), "Customer")

    End Sub

    Public Sub New(ByVal thefilepath As FileInfo)
        MyBase.New(thefilepath, "Customer")

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Public Overrides ReadOnly Property PeopleType As String
        Get
            Return "Client"
        End Get
    End Property

End Class
