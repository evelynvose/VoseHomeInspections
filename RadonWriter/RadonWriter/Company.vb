
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'

Public Class Company
    Inherits Customer

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
            m_CompanyName = value

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

    Public ReadOnly Property FullAddress As String
        Get
            Return CompanyName & vbCrLf & Address
        End Get

    End Property

End Class
