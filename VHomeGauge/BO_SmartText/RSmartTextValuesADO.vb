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
Imports VHIHomeGaugeApplication.VRepSmartTextDataSet
Imports VHIHomeGaugeApplication.VRepSmartTextDataSetTableAdapters
'
Public MustInherit Class RSmartTextValuesADO
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
    Public Function GetRepos() As IList(Of RSmartTextValue)
        Dim sqlCommand As New OleDb.OleDbCommand With {
            .CommandText = "SELECT * FROM SmartTextValues"
        }
        Return GetRepos(sqlCommand)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     -GetRepos(RSmartTextKey):IList
    ' ***********************************************
    '
    Public Function GetRepos(ByVal key As RSmartTextKey) As IList(Of RSmartTextValue)
        Dim sCommand As String
        sCommand = "SELECT * FROM SmartTextValues WHERE (((SmartTextValues.[FK_KEY])={guid {?}}));"
        sCommand = sCommand.Replace("?", key.ID.ToString)
        Dim sqlCommand As New OleDb.OleDbCommand With {
            .CommandText = sCommand,
            .Connection = New OleDb.OleDbConnection(My.Settings.ConnectionString),
            .CommandType = CommandType.Text
        }
        Return GetRepos(sqlCommand)
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     -GetRepos(OleDbCommand):IList
    ' ***********************************************
    '
    Private Function GetRepos(ByVal myCommand As OleDb.OleDbCommand) As IList(Of RSmartTextValue)
        '
        ' Always generate a database refresh
        '
        Using ta As New SmartTextValuesTableAdapter
            Using dt As New SmartTextValuesDataTable
                Try
                    ta.ClearBeforeFill = True
                    ta.Adapter.SelectCommand = myCommand
                    ta.Adapter.Fill(dt)
                    For Each row As SmartTextValuesRow In dt.Rows
                        Dim newRow As New RSmartTextValue(row.ID)
                        Repository.Add(newRow)
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
    ' *****     +Find(guid):RSmartTextValueInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RSmartTextValue
        '
        For Each rowInfo As RSmartTextValue In Repository
            If rowInfo.ID.Equals(theID) Then
                Return rowInfo
                '
            End If
        Next
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(srting):RSmartTextValueInfo
    ' ***********************************************
    '
    Public Function Find(ByVal value As String) As RSmartTextValue
        '
        For Each rowInfo As RSmartTextValue In Repository
            If rowInfo.Value = value Then
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
        For Each info As RSmartTextValue In Repository
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
    Public Function Remove(ByVal value As RSmartTextValue) As Boolean
        If IsNothing(value) Then Return False
        For i As Integer = Repository.Count - 1 To 0 Step -1
            If Repository(i).ID = value.ID Then Repository.RemoveAt(i)
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
    Private m_Repository As IList(Of RSmartTextValue)
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
    ' *****     +Repository():ilist
    ' ***********************************************
    '
    Public ReadOnly Property Repository As IList(Of RSmartTextValue)
        Get
            If IsNothing(m_Repository) Then
                m_Repository = New List(Of RSmartTextValue)
                '
            End If
            Return m_Repository
            '
        End Get
    End Property

End Class
