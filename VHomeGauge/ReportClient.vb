Imports System.Xml
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 

Public Class ReportClient
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
    Private m_node As XmlNode
    Public Sub LoadFromNode(ByVal node As XmlNode)
        If IsNothing(node) Then Exit Sub
        m_node = node

        Guid = GetPropertyValue("prop[@name='CGuid']")
        FirstName = GetPropertyValue("prop[@name='CFName1']")
        LastName = GetPropertyValue("prop[@name='CLName1']")
        Phone = GetPropertyValue("prop[@name='CMobilePhone']")
        Email = GetPropertyValue("prop[@name='CEmail']")
        Email2 = GetPropertyValue("prop[@name='CEmail2']")
        Email3 = GetPropertyValue("prop[@name='CEmail3']")
        Address1 = GetPropertyValue("prop[@name='CAddress']")
        Address2 = GetPropertyValue("prop[@name='CAddress2']")
        City = GetPropertyValue("prop[@name='CCity']")
        State = GetPropertyValue("prop[@name='CState']")
        ZipCode = GetPropertyValue("prop[@name='Zip']")
        Country = GetPropertyValue("prop[@name='CCountry']")
        HGUserName = GetPropertyValue("prop[@name='CSHGIName']")

    End Sub
    '
    ' ***********************************************
    ' *****     Get Property Value
    ' ***********************************************
    '
    Private Function GetPropertyValue(ByVal prop As String) As String
        Dim s As String
        Try
            s = m_node.SelectSingleNode(prop).InnerText

        Catch ex As Exception
            s = ""

        End Try

        Return s

    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_CGuid As String = ""
    Private m_FirstName As String = ""
    Private m_LastName As String = ""
    Private m_Phone As String = ""
    Private m_Email As String = ""
    Private m_Email2 As String = ""
    Private m_Email3 As String = ""
    Private m_Address1 As String = ""
    Private m_Address2 As String = ""
    Private m_City As String = ""
    Private m_State As String = ""
    Private m_ZipCode As String = ""
    Private m_Country As String = ""
    Private m_HGUserName As String = ""
    '
    ' ***********************************************
    ' *****     GUID
    ' ***********************************************
    '
    Public Property Guid As String
        Get
            Return m_CGuid
        End Get
        Set(value As String)
            m_CGuid = value
        End Set
    End Property
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
            m_FirstName = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Last Name
    ' ***********************************************
    '
    Public Property LastName As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Phone
    ' ***********************************************
    '
    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(value As String)
            m_Phone = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Email
    ' ***********************************************
    '
    Public Property Email As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Email2
    ' ***********************************************
    '
    Public Property Email2 As String
        Get
            Return m_Email2
        End Get
        Set(value As String)
            m_Email2 = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Email3
    ' ***********************************************
    '
    Public Property Email3 As String
        Get
            Return m_Email3
        End Get
        Set(value As String)
            m_Email3 = value
        End Set
    End Property
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
            m_Address1 = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Address 2
    ' ***********************************************
    '
    Public Property Address2 As String
        Get
            Return m_Address2
        End Get
        Set(value As String)
            m_Address2 = value
        End Set
    End Property
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
            m_City = value
        End Set
    End Property
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
            m_State = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Zip Code
    ' ***********************************************
    '
    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Country
    ' ***********************************************
    '
    Public Property Country As String
        Get
            Return m_Country
        End Get
        Set(value As String)
            m_Country = value
        End Set
    End Property
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
            m_HGUserName = value
        End Set
    End Property
End Class
