
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class VEditorEventArgs
    Inherits EventArgs
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        MyBase.New()
        '
    End Sub

    Public Sub New(ByVal ex As Exception)
        MyBase.New()
        Exception = ex
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +Exception(Exception):Exception
    ' ***********************************************
    '
    Private m_Exception As Exception
    Public Property Exception As Exception
        Get
            Return m_Exception
        End Get
        Set(value As Exception)
            m_Exception = value
        End Set
    End Property
End Class
