
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'

Public Class Person


    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub


    Public Sub New(ByVal firstname As String, ByVal lastname As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal state As String, ByVal postalcode As String, ByVal phone As String, ByVal email As String)
        Me.FirstName = firstname
        Me.LastName = lastname
        Me.Address1 = address1
        Me.Address2 = address2
        Me.City = city
        Me.State = state
        Me.PostalCode = postalcode
        Me.Phone = phone
        Me.eMail = email

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
    Public Overridable Property LastName As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value.Trim("""")
        End Set
    End Property
    Private m_LastName As String = ""

    Public Property FirstName As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value.Trim("""")
        End Set
    End Property
    Private Property m_FirstName As String = ""


    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value.Trim("""")
        End Set
    End Property
    Private m_Address1 As String = ""

    Public Property Address2 As String
        Set(value As String)
            m_Address2 = value.Trim("""")
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
            m_City = value.Trim("""")
        End Set
    End Property
    Private m_City As String = ""

    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value.Trim("""")
        End Set
    End Property
    Private m_State As String = ""

    Public Property PostalCode As String
        Get
            Return m_PostalCode
        End Get
        Set(value As String)
            m_PostalCode = value.Trim("""")
        End Set
    End Property
    Private m_PostalCode As String

    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(value As String)
            m_Phone = value.Trim("""")
        End Set
    End Property
    Private m_Phone As String = ""

    Public ReadOnly Property Address As String
        Get
            Return GetAddress()
        End Get
    End Property

    Public Property eMail As String
        Get
            Return m_eMail
        End Get
        Set(value As String)
            m_eMail = value.Trim("""")
        End Set
    End Property
    Private m_eMail As String = ""

    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)
            m_Type = value.Trim("""")
        End Set
    End Property
    Private m_Type As String = ""


End Class
