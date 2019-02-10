'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1

Public Class Report
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        Initialize()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Private m_IsInitialized As Boolean
    Private Sub Initialize()
        If m_IsInitialized Then Exit Sub
        m_IsInitialized = True

        m_ClientList = New List(Of ReportClient)()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_ClientList As IList(Of ReportClient)
    Private m_Guid As String = ""


    Public Property ClientList As IList(Of ReportClient)
        Get
            Return m_ClientList
        End Get
        Set(value As IList(Of ReportClient))
            m_ClientList = value
        End Set
    End Property

    Public Property Guid As String
        Get
            Return m_Guid
        End Get
        Set(value As String)
            m_Guid = value
        End Set
    End Property

    '
    ' ***********************************************
    ' *****     Label
    ' ***********************************************
    '

End Class
