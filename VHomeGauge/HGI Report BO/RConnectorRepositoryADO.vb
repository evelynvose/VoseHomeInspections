'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
' This is a report database controller class. It provides a highly typed interface
' to the database.
'
Public MustInherit Class RConnectorsRepositoryADO
    Inherits VObject    ' everybody inherits VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    Protected Sub New()
        Initialize()
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     -Initialize()
    ' ***********************************************
    '
    Private Sub Initialize()
        m_Repository = New List(Of RConnectorInfoData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of RConnectorInfoData)
    Public Function GetRepos() As IList(Of RConnectorInfoData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of RConnectorInfoData)
        Using ta As New vreportsDataSetTableAdapters.RConnectorsTableAdapter
            Using dt As New vreportsDataSet.RConnectorsDataTable
                Try
                    ta.Fill(dt)
                    For Each row As vreportsDataSet.RConnectorsRow In dt.Rows
                        Dim NewConnector As New RConnectorInfo(row.ID)
                        m_Repository.Add(NewConnector)
                        '
                    Next
                Catch ex As Exception
                    '
                    ' VObject hijacks MsgBox and sends the out put to UI and logs
                    '
                    MsgBox(ex)
                    '
                End Try
                '
            End Using
        End Using
        '
        Return m_Repository
    End Function
    ' 
    ' ***********************************************
    ' *****     +Find(guid):RConnectorInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RConnectorInfoData
        Dim theRConnectorInfo As RConnectorInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As RConnectorInfoData In m_Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RConnectorInfo
    ' ***********************************************
    '
    Public Function Find(ByVal s As String) As RConnectorInfoData
        Dim theRConnectorInfo As RConnectorInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As RConnectorInfoData In m_Repository
            If rinfo.XValue = s Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     +Update():bool
    ' ***********************************************
    '
    Public Function Update() As Boolean
        For Each info As RConnectorInfo In m_Repository
            info.Update()
            '
        Next
    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     Encapsulated Members
    ' ***********************************************
    '
    Public ReadOnly Property Count As Integer
        Get
            If IsNothing(m_Repository) Then Return 0
            Return m_Repository.Count
            '
        End Get
    End Property
End Class
