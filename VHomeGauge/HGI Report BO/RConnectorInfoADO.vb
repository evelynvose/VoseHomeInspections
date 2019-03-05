'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class RConnectorInfoADO
    Inherits RConnectorInfoData
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
    Public Sub New()
        ' Do Nothing on purpose!
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     #New(guid)
    ' ***********************************************
    '
    Protected Sub New(ByVal theID As Guid)
        If IsNothing(theID) Then theID = Guid.Empty
        Load(theID)
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
    ' *****     #Load(guid):bool
    ' ***********************************************
    '
    Protected Sub Load(ByVal theID As Guid)
        If IsNothing(theID) Then theID = Guid.Empty
        Using ta As New vreportsDataSetTableAdapters.RConnectorsTableAdapter
            Using dt As New vreportsDataSet.RConnectorsDataTable
                Try
                    ta.FillByID(dt, theID)
                    If dt.Rows.Count > 0 Then
                        LoadDataFromRow(dt.Rows(0))
                        IsDirty = False ' Info properties always set dirty flag so reset it.
                        '
                    End If
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
    End Sub
    '
    ' ***********************************************
    ' *****     +Find(guid):bool
    ' ***********************************************
    '
    Public Shared Function Find(ByVal theID As Guid) As Boolean
        Using ta As New vreportsDataSetTableAdapters.RConnectorsTableAdapter
            Using dt As New vreportsDataSet.RConnectorsDataTable
                Try
                    If IsNothing(theID) Then theID = Guid.NewGuid()
                    ta.FillByID(dt, theID)
                    If dt.Rows.Count > 0 Then
                        Return True
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return False
                    '
                End Try
                '
            End Using
        End Using
        Return False
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(string):bool
    ' ***********************************************
    '
    Public Shared Function Find(ByVal s As String) As Boolean
        Using ta As New vreportsDataSetTableAdapters.RConnectorsTableAdapter
            Using dt As New vreportsDataSet.RConnectorsDataTable
                Try
                    If IsNothing(s) Then s = ""
                    ta.FillByID(dt, s)
                    If dt.Rows.Count > 0 Then
                        Return True
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return False
                    '
                End Try
                '
            End Using
        End Using
        Return False
    End Function
    '
    ' ***********************************************
    ' *****     -RuleCheck():bool
    ' ***********************************************
    '
    ' This row in the database is only valid under these conditions:
    '
    ' 1) It has a primary key and that key is guid.
    ' 2) All fields contain values.
    ' 3) The XValue field cannot be "" or Nothing
    '
    Private Function RuleCheck() As Boolean
        '
        ' Rule 1
        '
        Dim sMessage As String = "Rule Check"
        Dim bRule_1_Met As Boolean = True
        If IsNothing(ID) OrElse ID.Equals(Guid.Empty) Then
            sMessage &= vbCrLf
            sMessage &= "PK is not valid."
            bRule_1_Met = False
            '
        End If
        '
        ' Rule 2
        '
        Dim bRule_2_Met As Boolean = True
        If IsNothing(XNode) OrElse IsNothing(XValue) OrElse IsNothing(XParentNode) Then
            sMessage &= vbCrLf
            sMessage &= "One or more fields are not valid."
            bRule_2_Met = False
            '
        End If
        '
        ' Rule 3
        '
        Dim bRule_3_Met As Boolean = True
        If XValue = "" Then
            sMessage &= vbCrLf
            sMessage &= "XValue can't be empty."
            bRule_3_Met = False
            '
        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met OrElse Not bRule_3_Met Then
            MsgBox(sMessage)
            Return False
            '
        End If
        '
        ' Success!
        '
        Return True
        '
    End Function
    '
    ' ***********************************************
    ' *****     +Update():bool
    ' ***********************************************
    '
    Public Function Update() As Boolean
        If Not IsDirty Then Return IsDirty ' nothing to save or update
        '
        ' Run the rule check
        '
        If Not RuleCheck() Then
            Return False

        End If
        '
        ' Passed the rule check, so update the record
        '
        Using ta = New vreportsDataSetTableAdapters.RConnectorsTableAdapter
            Using dt = New vreportsDataSet.RConnectorsDataTable
                Dim row As vreportsDataSet.RConnectorsRow
                ta.FillByID(dt, ID)
                If dt.Count = 0 Then
                    row = dt.NewRConnectorsRow
                    '
                Else
                    row = dt.Rows(0)
                    '
                End If
                '
                LoadRowFromData(row)
                '
                Try
                    If dt.Count = 0 Then dt.AddRConnectorsRow(row)
                    ta.Update(dt)
                    IsDirty = False
                    '
                Catch ex As Exception
                    MsgBox("Update()" & vbCrLf & ex.Message)
                    '
                End Try
                '
            End Using 'ta
        End Using ' dt
        '
        Return IsDirty
        '
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
End Class
