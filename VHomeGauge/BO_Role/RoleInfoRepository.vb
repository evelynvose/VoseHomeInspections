'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class RoleInfoRepository
    Inherits VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    Public Sub New()
        Initialize()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    '
    ' ***********************************************
    ' *****     -Initialize()
    ' ***********************************************
    '
    Private Sub Initialize()
        Using ta As New vreportsDataSetTableAdapters.RoleInfoTableAdapter
            Using dt As New vreportsDataSet.RoleInfoDataTable
                Try
                    ta.Fill(dt)
                    For Each row As vreportsDataSet.RoleInfoRow In dt.Rows
                        Dim newRoleInfo As New RoleInfoData
                        With newRoleInfo
                            .RoleInfoID = row.ID
                            .PersonID = row.PersonID
                            .ReportID = row.ReportID
                            .RoleLutID = row.RoleLutID
                            '
                        End With
                        RoleInfoRepos.Add(newRoleInfo)
                        '
                    Next
                Catch ex As Exception
                    MsgBox(ex)
                    '
                End Try
            End Using
        End Using
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_RoleInfoRepos As IList(Of RoleInfoData) = New List(Of RoleInfoData)
    Private m_RoleName As String = “”
    '
    ' ***********************************************
    ' *****     +RoleName(string):string
    ' ***********************************************
    '
    Public Property RoleName As String
        Get
            Return m_RoleName
        End Get
        Set(value As String)
            m_RoleName = value
            'm_IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     RoleInfoRepps():object
    ' ***********************************************
    '
    Public ReadOnly Property RoleInfoRepos As IList(Of RoleInfoData)
        Get
            Return m_RoleInfoRepos
        End Get
    End Property
End Class
