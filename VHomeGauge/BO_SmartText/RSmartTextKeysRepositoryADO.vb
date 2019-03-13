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
        '
        ' Do nothing on purpose!
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Public Function GetRepos() As IList(Of RSmartTextKey)
        '
        ' Always generate a database refresh
        '
        Using ta As New SmartTextKeysTableAdapter
            Using dt As New SmartTextKeysDataTable
                Try
                    ta.Fill(dt)
                    For Each row As SmartTextKeysRow In dt.Rows
                        Dim NewSmartTextKey As New RSmartTextKey(row.ID)
                        Repository.Add(NewSmartTextKey)
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
        Return Repository
    End Function
    ' 
    ' ***********************************************
    ' *****     +Find(guid):RSmartTextKeyInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RSmartTextKey
        For Each rinfo As RSmartTextKey In Repository
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
    Public Function Find(ByVal key As String) As RSmartTextKey
        For Each rowInfo As RSmartTextKey In Repository
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
        For Each info As RSmartTextKey In Repository
            If info.IsDeleted Then
                Remove(info)
                info.Delete()
                '
            Else
                info.Update()
                '
            End If
            '
        Next
        Return bFlag
    End Function
    ' 
    ' ***********************************************
    ' *****     +Remove(RSmartTextKey):bool
    ' ***********************************************
    '
    Public Function Remove(ByVal key As RSmartTextKey) As Boolean
        If IsNothing(key) Then Return False
        For i As Integer = Repository.Count - 1 To 0 Step -1
            If Repository(i).ID = key.ID Then Repository.RemoveAt(i)
            Return True
            '
        Next
        Return False
    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_Repository As IList(Of RSmartTextKey)
    '
    ' ***********************************************
    ' *****     +Count():integer
    ' ***********************************************
    '
    Public ReadOnly Property Count As Integer
        Get
            Return Repository.Count
            '
        End Get
    End Property
    '
    ' ***********************************************
    ' *****     +Count():integer
    ' ***********************************************
    '
    Public ReadOnly Property Repository As IList(Of RSmartTextKey)
        Get
            If IsNothing(m_Repository) Then
                m_Repository = New List(Of RSmartTextKey)
            End If
            Return m_Repository
            '
        End Get
    End Property

End Class
