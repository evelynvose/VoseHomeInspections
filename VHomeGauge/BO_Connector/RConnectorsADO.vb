'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports SyncfusionWindowsFormsApplication1.vreportsDataSet
Imports SyncfusionWindowsFormsApplication1.vreportsDataSetTableAdapters
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
        m_Repository = New List(Of RConnectorData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of RConnectorData)
    '
    Public Function GetRepos() As IList(Of RConnectorData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of RConnectorData)
        Using ta As New RConnectorsTableAdapter
            Using dt As New RConnectorsDataTable
                Try
                    ta.Fill(dt)
                    For Each row As vreportsDataSet.RConnectorsRow In dt.Rows
                        Dim newObject As New RConnector(row.ID)
                        m_Repository.Add(newObject)
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
    Public Function Find(ByVal theID As Guid) As RConnectorData
        Dim theRConnectorInfo As RConnectorData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As RConnectorData In m_Repository
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
    Public Function Find(ByVal s As String) As RConnectorData
        Dim theRConnectorInfo As RConnectorData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As RConnectorData In m_Repository
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
        Dim bFlag As Boolean
        For Each info As RConnector In m_Repository
            bFlag = info.Update()
            '
        Next
        Return bFlag
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
