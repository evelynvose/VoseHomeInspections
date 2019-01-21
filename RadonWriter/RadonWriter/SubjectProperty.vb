
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class SubjectProperty
    Inherits Customer

    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        MyBase.New()

        MyBase.State = "NC"

    End Sub

    'Public Sub New(ByVal name As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal state As String, ByVal postalcode As String, ByVal phone As String)
    'MyBase.New(name, address1, address2, city, state, postalcode, phone)

    'End Sub

    Public Sub New(ByVal name As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal state As String, ByVal postalcode As String, ByVal phone As String, ByVal theOrderID As String)
        MyBase.New(name, address1, address2, city, state, postalcode, phone)

        OrderID = theOrderID


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
    Public Property YearBuilt As String
        Get
            Return m_YearBuilt
        End Get
        Set(value As String)
            m_YearBuilt = value
        End Set
    End Property
    Private m_YearBuilt As String = ""

    Public Property SqFt As Integer
        Get
            Return m_SqFt
        End Get
        Set(value As Integer)
            m_SqFt = value
        End Set
    End Property
    Private m_SqFt As Integer

    Public Property Foundation As String
        Get
            Return m_Foundation
        End Get
        Set(value As String)
            m_Foundation = value
        End Set
    End Property
    Private m_Foundation As String = ""

    Public Property Location As String
        Get
            Return m_Location
        End Get
        Set(value As String)
            m_Location = value
        End Set
    End Property
    Private m_Location As String = ""

    Public Property Weather As String
        Get
            Return m_Weather
        End Get
        Set(value As String)
            m_Weather = value
        End Set
    End Property
    Private m_Weather As String = ""

    Public Property OrderID As String
        Get
            Return m_OrderID
        End Get
        Set(value As String)
            m_OrderID = value
        End Set
    End Property
    Private m_OrderID As String = ""



End Class
