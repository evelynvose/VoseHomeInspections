'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class RoleInfoADO
    Inherits RoleInfoData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    Friend Sub New()
        MyBase.New()

        ' Tell the world that this is a new record
        ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' ***********************************************
    ' *****     Finalize
    ' ***********************************************
    '
    Protected Overrides Sub Finalize()
        Update()

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
    ' *****     Load By PhoneID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Integer) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.RoleInfoTableAdapter = New vreportsDataSetTableAdapters.RoleInfoTableAdapter
            Using dt As vreportsDataSet.RoleInfoDataTable = New vreportsDataSet.RoleInfoDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an PhoneRecordID
                    ta.FillByRoleInfoID(dt, id)
                    If dt.Count > 0 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByRoleInfoID()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Phone Rule Check
    ' ***********************************************
    '
    ' An RoleInfo object in the database is only valid under these conditions:
    ' A. Must not be in an error condition.
    '
    ' ////// 1) It has a RoleInfoID ///// Noooooooo..... autonumber.....
    ' 2) It has both a ReportID and a PersonID
    ' 3) It has a RoleLutID
    '
    Private Function RoleRuleCheck() As Boolean
        '
        ' Rule A
        '
        If ObjectState = ObjectStates.ErrorCondition Then Return False
        '
        ' Set the flags 
        '
        Dim bRule_1_Met As Boolean = True
        Dim bRule_2_Met As Boolean = True
        Dim bRule_3_Met As Boolean = True
        '
        ' Rule 1
        '
        If RoleInfoID < 1 Then
            ' bRule_1_Met = False
            '
        End If
        '
        ' Rule 2
        '
        Dim newGuid As Guid
        If PersonID.Equals(newGuid) OrElse ReportID.Equals(newGuid) Then
            bRule_2_Met = False
            '
        End If
        '
        ' Rule 3
        '
        If RoleLutID < 0 Then
            bRule_3_Met = False
            '
        End If
        '
        ' Create the error message
        '
        Dim sMessage As String = "RoleInfo Rule Check"
        If Not bRule_1_Met Then
            sMessage &= vbCrLf
            sMessage &= "The RoleInfoID is invalid."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The RoleInfo isn't tagged with both foreign keys."

        End If
        If Not bRule_3_Met Then
            sMessage &= vbCrLf
            sMessage &= "The RoleLut isn't tagged with a valid foreign key."

        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met OrElse Not bRule_3_Met Then
            MsgBox(sMessage)
            Return False

        End If
        '
        ' Success!
        '
        Return True

    End Function
    '
    ' ***********************************************
    ' *****     Update
    ' ***********************************************
    '
    Public Function Update() As Boolean
        If Not IsDirty Then Return IsDirty ' nothing to save or update
        '
        ' Run the rule check
        '
        If Not RoleRuleCheck() Then
            Return False

        End If
        '
        ' Passed the rule check, so update the record
        '
        Using ta As vreportsDataSetTableAdapters.RoleInfoTableAdapter = New vreportsDataSetTableAdapters.RoleInfoTableAdapter
            Using dt As vreportsDataSet.RoleInfoDataTable = New vreportsDataSet.RoleInfoDataTable
                Dim row As vreportsDataSet.RoleInfoRow
                ta.FillByRoleInfoID(dt, RoleInfoID)
                If dt.Count = 0 Then
                    row = dt.NewRoleInfoRow

                Else
                    row = dt.Rows(0)

                End If

                SetRowFromData(row)

                Try
                    If dt.Count = 0 Then dt.AddRoleInfoRow(row)
                    ta.Update(dt)
                    IsDirty = False
                Catch ex As Exception
                    MsgBox("Update()" & vbCrLf & ex.Message)

                End Try

            End Using 'ta
        End Using ' dt

        Return IsDirty

    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '

    '
End Class
