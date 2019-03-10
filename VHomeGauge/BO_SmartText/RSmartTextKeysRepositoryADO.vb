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
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSet
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSetTableAdapters

Public MustInherit Class RSmartTextKeysRepositoryADO
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
        m_Repository = New List(Of RSmartTextKeyInfoData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of RSmartTextKeyInfoData)
    Public Function GetRepos() As IList(Of RSmartTextKeyInfoData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of RSmartTextKeyInfoData)
        Using ta As New SmartTextKeysTableAdapter
            Using dt As New SmartTextKeysDataTable
                Try
                    ta.Fill(dt)
                    For Each row As SmartTextKeysRow In dt.Rows
                        Dim NewSmartTextKey As New RSmartTextKey(row.ID)
                        m_Repository.Add(NewSmartTextKey)
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
    ' *****     +Find(guid):RSmartTextKeyInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RSmartTextKeyInfoData
        Dim theRSmartTextKeyInfo As RSmartTextKeyInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rinfo As RSmartTextKeyInfoData In m_Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RSmartTextKeyInfo
    ' ***********************************************
    '
    Public Function Find(ByVal key As String) As RSmartTextKeyInfoData
        Dim theRSmartTextKeyInfo As RSmartTextKeyInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rowInfo As RSmartTextKeyInfoData In m_Repository
            If rowInfo.Key = key Then
                Return rowInfo
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
        For Each info As RSmartTextKey In m_Repository
            info.Update()
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
