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
Public MustInherit Class RCommentsADO
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
    Public Function GetRepos() As IList(Of RComment)
        '
        ' Always generate a database refresh
        '
        Using ta As New CommentsTableAdapter
            Using dt As New CommentsDataTable
                Try
                    ta.Fill(dt)
                    For Each row As CommentsRow In dt.Rows
                        Dim newObject As New RComment(row.ID)
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
    ' *****     +Find(guid):RCommentInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RComment
        For Each rinfo As RComment In Repository
            If rinfo.ID.Equals(theID) Then
                Return rinfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RCommentInfo
    ' ***********************************************
    '
    Public Function Find(ByVal name As String) As RComment
        For Each rowInfo As RComment In Repository
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
        For Each info As RComment In Repository
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
    ' *****     +Remove(RComment):bool
    ' ***********************************************
    '
    Public Function Remove(ByVal key As RComment) As Boolean
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
    Private m_Repository As IList(Of RComment)
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
    Public ReadOnly Property Repository As IList(Of RComment)
        Get
            If IsNothing(m_Repository) Then
                m_Repository = New List(Of RComment)
            End If
            Return m_Repository
            '
        End Get
    End Property

End Class
