Public Class Company
    Inherits Customer


    ' **********************************************
    ' ****
    ' ******    Class
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New(ByVal theCompanyName As String, ByVal theContactName As String, ByVal theAddress1 As String, ByVal theAddress2 As String, ByVal theCity As String, ByVal theState As String, ByVal thePostalCode As String, ByVal thePhone As String)
        MyBase.New(theContactName, theAddress1, theAddress2, theCity, theState, thePostalCode, thePhone)

        CompanyName = theCompanyName

    End Sub

    Public Sub New()
        MyBase.New

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public Property CompanyName As String
        Get
            Return m_CompanyName
        End Get
        Set(value As String)
            m_CompanyName = ""

        End Set
    End Property
    Private m_CompanyName As String = ""

    Public Shadows Property ContactName As String
        Get
            Return MyBase.Name

        End Get
        Set(value As String)
            MyBase.Name = value
        End Set
    End Property


End Class
