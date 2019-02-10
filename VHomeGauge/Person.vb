
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class Person
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()

    End Sub
    '
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
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     Last Name
    ' ***********************************************
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
    '
    ' ***********************************************
    ' *****     First Name
    ' ***********************************************
    '
    Public Property FirstName As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value.Trim("""")
        End Set
    End Property
    Private Property m_FirstName As String = ""
    '
    ' ***********************************************
    ' *****     Company Name
    ' ***********************************************
    '
    Public Property CompanyName As String
        Get
            Return m_CompanyName
        End Get
        Set(value As String)
            m_CompanyName = value.Trim("""")
        End Set
    End Property
    Private m_CompanyName As String = ""
    '
    ' ***********************************************
    ' *****     Address 1
    ' ***********************************************
    '
    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value.Trim("""")
        End Set
    End Property
    Private m_Address1 As String = ""
    '
    ' ***********************************************
    ' *****     Address 2
    ' ***********************************************
    '
    Public Property Address2 As String
        Set(value As String)
            m_Address2 = value.Trim("""")
        End Set
        Get
            Return m_Address2
        End Get
    End Property
    Private m_Address2 As String = ""
    '
    ' ***********************************************
    ' *****     City
    ' ***********************************************
    '
    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value.Trim("""")
        End Set
    End Property
    Private m_City As String = ""
    '
    ' ***********************************************
    ' *****     State
    ' ***********************************************
    '
    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value.Trim("""")
        End Set
    End Property
    Private m_State As String = ""
    '
    ' ***********************************************
    ' *****     Postal Code
    ' ***********************************************
    '
    Public Property PostalCode As String
        Get
            Return m_PostalCode
        End Get
        Set(value As String)
            m_PostalCode = value.Trim("""")
        End Set
    End Property
    Private m_PostalCode As String
    '
    ' ***********************************************
    ' *****     eMail 1
    ' ***********************************************
    '
    Public Property eMail As String
        Get
            Return m_eMail
        End Get
        Set(value As String)
            m_eMail = value.Trim("""")
        End Set
    End Property
    Private m_eMail As String = ""
    '
    ' ***********************************************
    ' *****     eMail 2
    ' ***********************************************
    '
    Public Property eMail2 As String
        Get
            Return m_eMail2
        End Get
        Set(value As String)
            m_eMail2 = value.Trim("""")
        End Set
    End Property
    Private m_eMail2 As String = ""

    Public Property eMail3 As String
        Get
            Return m_eMail3
        End Get
        Set(value As String)
            m_eMail3 = value.Trim("""")
        End Set
    End Property
    Private m_eMail3 As String = ""
    '
    ' ***********************************************
    ' *****     eMail 3
    ' ***********************************************
    '
    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(value As String)
            m_Phone = value.Trim("""")
        End Set
    End Property
    Private m_Phone As String = ""
    '
    ' ***********************************************
    ' *****     Address
    ' ***********************************************
    '
    Public ReadOnly Property Address As String
        Get
            Return GetAddress()
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     Type
    ' ***********************************************
    '
    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)
            m_Type = value.Trim("""")
        End Set
    End Property
    Private m_Type As String = ""
    '
    ' ***********************************************
    ' *****     Note
    ' ***********************************************
    '
    Public Property Note As String
        Get
            Return m_Note
        End Get
        Set(value As String)
            m_Note = value.Trim("""")
        End Set
    End Property
    Private m_Note As String = ""
    '
    '
    ' ***********************************************
    ' *****     HG User Name
    ' ***********************************************
    '
    Public Property HGUserName As String
        Get
            Return m_HGUserName
        End Get
        Set(value As String)
            m_HGUserName = value.Trim("""")
        End Set
    End Property
    Private m_HGUserName As String = ""
    '
    ' ***********************************************
    ' *****     Website
    ' ***********************************************
    '
    Public Property Website As String
        Get
            Return m_Website
        End Get
        Set(value As String)
            m_Website = value.Trim("""")
        End Set
    End Property
    Private m_Website As String = ""
    '
    ' ***********************************************
    ' *****     GUID
    ' ***********************************************
    '
    Public Property GUID As String
        Get
            Return m_GUID
        End Get
        Set(value As String)
            ' MsgBox("Can't set GUID - Home Gauge only!")
            m_GUID = value.Trim("""")
        End Set
    End Property
    Private m_GUID As String = ""
End Class
