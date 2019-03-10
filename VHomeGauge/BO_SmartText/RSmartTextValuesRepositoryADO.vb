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
'
Public MustInherit Class RSmartTextValuesRepositoryADO
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
        m_Repository = New List(Of RSmartTextValueInfoData)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -GetRepos():IList
    ' ***********************************************
    '
    Private m_Repository As IList(Of RSmartTextValueInfoData)
    Public Function GetRepos() As IList(Of RSmartTextValueInfoData)
        '
        ' Always generate a database refresh
        '
        m_Repository = New List(Of RSmartTextValueInfoData)
        Using ta As New SmartTextValuesTableAdapter
            Using dt As New SmartTextValuesDataTable
                Try
                    ta.Fill(dt)
                    For Each row As SmartTextValuesRow In dt.Rows
                        Dim newRow As New RSmartTextValue(row.ID)
                        m_Repository.Add(newRow)
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
    ' *****     +Find(guid):RSmartTextValueInfo
    ' ***********************************************
    '
    Public Function Find(ByVal theID As Guid) As RSmartTextValueInfoData
        ' Dim theInfo As RSmartTextValueInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rowInfo As RSmartTextValueInfoData In m_Repository
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
    Public Function Find(ByVal value As String) As RSmartTextValueInfoData
        ' Dim theRSmartTextValueInfo As RSmartTextValueInfoData = Nothing
        '
        If IsNothing(m_Repository) Then Return Nothing
        For Each rowInfo As RSmartTextValueInfoData In m_Repository
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
        For Each info As RSmartTextValue In m_Repository
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
