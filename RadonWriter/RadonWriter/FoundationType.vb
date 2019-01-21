Public Class FoundationType
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
    Public Sub New(ByVal id As String, ByVal type As String)
        m_ID = id
        m_Type = type


    End Sub

    Public Sub New()
        m_ID = ""
        m_Type = ""

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
    Public Property Type As String
        Get
            Return m_Type
        End Get
        Set(value As String)

        End Set
    End Property
    Private m_Type As String = ""


    Public Property ID As String
        Get
            Return m_ID
        End Get
        Set(value As String)
            m_ID = value
        End Set
    End Property
    Private m_ID As String = ""

End Class
