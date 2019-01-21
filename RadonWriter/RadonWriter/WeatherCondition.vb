Public Class WeatherCondition

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
    Public Sub New()
        m_Condition = ""
        m_ID = ""

    End Sub

    Public Sub New(ByVal id As String, condition As String)
        m_ID = id
        m_Condition = condition

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
    Public Property Condition As String
        Get
            Return m_Condition
        End Get
        Set(value As String)
            m_Condition = value

        End Set
    End Property
    Private m_Condition As String = ""

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
