'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports SyncfusionWindowsFormsApplication1.VRepCatalog
Imports SyncfusionWindowsFormsApplication1.VRepCatalogTableAdapters
'
' This is a report database controller class. It provides a highly typed interface
' to the database.
'
Public MustInherit Class CatalogMastersADO
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
        m_Repository = New List(Of CatalogMasterData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of CatalogMasterData)
    '
    Public Function GetRepos() As IList(Of CatalogMasterData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of CatalogMasterData)
        Using ta As New CatalogMasterTableAdapter
            Using dt As New CatalogMasterDataTable
                Try
                    ta.Fill(dt)
                    For Each row As CatalogMasterRow In dt.Rows
                        Dim newObject As New CatalogMaster(row.ID)
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
    ' *****     +Find(guid):RCatalogInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As VGuid) As CatalogMasterData
        Dim theRCatalogInfo As CatalogMasterData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As CatalogMasterData In m_Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RCatalogInfo
    ' ***********************************************
    '
    Public Function Find(ByVal s As String) As CatalogMasterData
        Dim theRCatalogInfo As CatalogMasterData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As CatalogMasterData In m_Repository
            If rinfo.Name = s Then
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
        For Each info As CatalogMaster In m_Repository
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
