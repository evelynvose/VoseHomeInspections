
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'

Public Class Customer


    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub


    Public Sub New(ByVal name As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal state As String, ByVal postalcode As String, ByVal phone As String)
        name = name
        address1 = address1
        address2 = address2
        city = city
        state = state
        postalcode = postalcode
        phone = phone

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Private Function GetAddress() As String
        Dim s As String
        s = Address1
        s += vbCrLf
        If Address2 <> "" Then
            s += Address2
            s += vbCrLf
        End If
        s += City
        s += ", "
        s += State
        s += "  "
        s += PostalCode

        Return s

    End Function


    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public Overridable Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String = ""

    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value
        End Set
    End Property
    Private m_Address1 As String = ""

    Public Property Address2 As String
        Set(value As String)
            m_Address2 = value
        End Set
        Get
            Return m_Address2
        End Get
    End Property
    Private m_Address2 As String = ""

    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
        End Set
    End Property
    Private m_City As String = ""

    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value
        End Set
    End Property
    Private m_State As String = ""

    Public Property PostalCode As String
        Get
            Return m_PostalCode
        End Get
        Set(value As String)
            m_PostalCode = value
        End Set
    End Property
    Private m_PostalCode As String

    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(value As String)
            m_Phone = value
        End Set
    End Property
    Private m_Phone As String = ""

    Public ReadOnly Property Address As String
        Get
            Return GetAddress()
        End Get
    End Property


End Class
