Public Class Inspector
    Inherits Customer

    Public Property License As String
        Get
            Return m_License
        End Get
        Set(value As String)
            m_License = value
        End Set
    End Property
    Private m_License As String = ""

End Class
