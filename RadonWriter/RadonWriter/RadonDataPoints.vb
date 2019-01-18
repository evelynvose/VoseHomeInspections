

' **********************************************
' ****
' ******    Radon Data Class
' ****
' **********************************************
' 
Public Class RadonDataPoints

    Public Property Time() As String
        Get
            Return m_Time
        End Get
        Set(value As String)
            m_Time = value
        End Set
    End Property
    Private m_Time As String

    Public Property Count() As String
        Get
            Return m_Count
        End Get
        Set(value As String)
            m_Count = value
        End Set
    End Property
    Private m_Count As String

    Public Property Flag() As String
        Get
            Return m_Flag
        End Get
        Set(value As String)
            m_Flag = value
        End Set
    End Property
    Private m_Flag As String



    Public Sub New(time As String, count As String, flag As String)
        m_Time = time
        m_Count = count
        m_Flag = flag
    End Sub


End Class

