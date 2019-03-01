#Region "Picture Filter Class"
' **********************************************
' ****
' ******    Picture Filter Class
' ****
' **********************************************
' 
Public Class PictureFilter


    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        m_FilterList = New List(Of String)()

    End Sub




    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Public Function IsFiltered(ByVal value As String) As Boolean
        If IsNothing(value) Then value = ""

        For Each testcase As String In m_FilterList
            If value.Contains(testcase) Then
                Return True
            End If
        Next

        Return False

    End Function
    '
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 


    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_FilterList As IList(Of String)
    Public ReadOnly Property FilterList As IList(Of String)
        Get
            Return m_FilterList
        End Get
    End Property
End Class
#End Region


