'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports VHIHomeGaugeApplication.VRepCatalog
Imports VHIHomeGaugeApplication.VRepCatalogTableAdapters
'
' This is a report database controller class. It provides a highly typed interface
' to the database.
'
Public MustInherit Class CatalogLinkListsADO
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
        m_Repository = New List(Of CatalogLinkListData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of CatalogLinkListData)
    '
    Public Function GetRepos() As IList(Of CatalogLinkListData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of CatalogLinkListData)
        Using ta As New CatalogLinkListTableAdapter
            Using dt As New CatalogLinkListDataTable
                Try
                    ta.Fill(dt)
                    For Each row As CatalogLinkListRow In dt.Rows
                        Dim newObject As New CatalogLinkList(row.ID)
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
    ' *****     +Find(vguid):CatalogLinkList
    ' ***********************************************
    '
    Public Function Find(ByVal theID As VGuid) As CatalogLinkListData
        Dim theRCatalogInfo As CatalogLinkListData = Nothing
        '
        If m_Repository Is Nothing Then Return Nothing
        For Each rinfo As CatalogLinkListData In m_Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(vguid, vguid):CatalogLinkList
    ' ***********************************************
    '
    Public Function Find(ByVal theParent As CatalogMaster, ByVal thechild As CatalogMaster) As CatalogLinkListData
        Dim theRCatalogInfo As CatalogLinkListData = Nothing
        '
        If m_Repository Is Nothing Then Return Nothing
        For Each rinfo As CatalogLinkListData In m_Repository
            If rinfo.FK_Parent.Equals(theParent) AndAlso rinfo.FK_Child.Equals(thechild) Then
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
        For Each info As CatalogLinkList In m_Repository
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
