Imports System.IO

' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class AgentRepository
    Inherits PeopleRepository

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        MyBase.New(New FileInfo(My.Settings.People4DataPath), "Rep")

    End Sub

    Public Sub New(ByVal thefilepath As FileInfo)
        MyBase.New(thefilepath, "Rep")

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
            Return "Agent"
        End Get
    End Property
End Class
