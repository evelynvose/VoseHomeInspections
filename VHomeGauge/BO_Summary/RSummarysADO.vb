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
Imports SyncfusionWindowsFormsApplication1.vreportsDataSet
Imports SyncfusionWindowsFormsApplication1.vreportsDataSetTableAdapters
'
Public MustInherit Class RSummarysADO
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
        MyBase.New()
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
    Public Function GetRepos() As IList(Of RSummary)
        '
        ' Always generate a database refresh
        '
        Using ta As New SummaryTableAdapter
            Using dt As New SummaryDataTable
                Try
                    ta.Fill(dt)
                    For Each row As SummaryRow In dt.Rows
                        Dim newObject As New RSummary(row.ID)
                        Repository.Add(newObject)
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
    ' *****     +Find(guid):RSummaryInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RSummary
        For Each rinfo As RSummary In Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RSummaryInfo
    ' ***********************************************
    '
    Public Function Find(ByVal name As String) As RSummary
        For Each rowInfo As RSummary In Repository
            If rowInfo.Name = name Then
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
        For Each info As RSummary In Repository
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
    ' *****     +Remove(RSummary):bool
    ' ***********************************************
    '
    Public Function Remove(ByVal key As RSummary) As Boolean
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
    Private m_Repository As IList(Of RSummary)
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
    Public ReadOnly Property Repository As IList(Of RSummary)
        Get
            If IsNothing(m_Repository) Then
                m_Repository = New List(Of RSummary)
            End If
            Return m_Repository
            '
        End Get
    End Property

End Class
