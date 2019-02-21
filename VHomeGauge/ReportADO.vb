'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class ReportADO
    Inherits ReportData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    ' Use Cases:
    ' Case 1 - virgin report from blank GUID, so we generate a GUID, set the type and return, ObjectStatus = NewReport.
    ' Case 2 - Query the Report Master, and if found, load the data and return ObjectStatus = ExistingReport
    ' Case 3 - Not in the Report Master, but since the GUID is a valid format, we will assume that that the
    '          intent of the instantiation is to create a new report using the provided GUID. Return ObjectStatus = NewReport
    '
    ' Case 1
    '
    Friend Sub New()
        MyBase.New()

        ' All records in the Address table must have a primary key.
        ReportID = Guid.NewGuid()

        ' Tell the world that this is a new record
        ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' Cases 2 & 3
    '
    Friend Sub New(ByVal anID As Guid)
        MyBase.New()
        '
        ' Virgin ID means error condition!
        '
        If anID.Equals(New Guid) Then ' Error condition
            ReportType = -1
            ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Check if this is an existing record by ReportID
        '
        If LoadByID(anID) = ObjectStates.ExistingRecord Then
            ' Success!
            Exit Sub

        End If

        '
        ' Special use case... this is an HGI GUID, so the instantiator is decomposing an HGI report.
        '
        If Not anID.Equals(New Guid) Then
            ReportID = anID
            ReportType = ReportTypes.HomeInspection
            ObjectState = ObjectStates.NewRecord
            Exit Sub
        End If
        '
        ' Our hope now is that anID is a valid foreign key.
        '
        ' Note that this is the typical pattern for this object type,
        ' but since the use case is a bit different than normal, we will ignore this step
        ' If SetTypeByFK(anID) = -1 Then
        ' Exit Sub
        ' End If
        '
        ' If we made it this far we know that anID is a valid foreign key so
        ' we can go ahead and set the Report Data.  The wrapper class will have
        ' to determine if the data is valid for type of wrapper.
        '
        ' Assumes ForeignKey and ReportType has been set. ForeigKey is one of PersonID, ReportID or CompanyID
        '
        If LoadByFkIDAndType() = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        ' We may have had a valid foreign key and ReportType, but there isn't an address record
        ' so we'll assume that the instantiator wanted this to be a virgin address record.
        '
        ReportID = Guid.NewGuid()
        ReportType = ReportTypes.HomeInspection
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
    ' *****     Find By ID
    ' ***********************************************
    '
    Public Shared Function FindByID(ByVal theReportId As Guid) As Boolean
        '
        ' Error checking
        '
        If IsNothing(theReportId) Then theReportId = Guid.Empty
        '
        ' Do the lookup
        '
        Using ta As New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As New vreportsDataSet.ReportMasterDataTable
                Try
                    ta.FillByReportID(dt, theReportId)
                    If dt.Count > 0 Then Return True

                Catch ex As Exception
                    Return False

                End Try


            End Using
        End Using

        Return False

    End Function
    '
    ' ***********************************************
    ' *****     Find By Report Number And Version
    ' ***********************************************
    '
    Public Shared Function FindByID(ByVal theReportNumber As String, theVersion As String) As Boolean
        '
        ' Error Checking
        '
        If IsNothing(theReportNumber) Then theReportNumber = ""
        If IsNothing(theVersion) Then theVersion = ""
        '
        ' Do the lookup
        '
        Using ta As New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As New vreportsDataSet.ReportMasterDataTable
                Try
                    ta.FillByReportID(dt, theReportNumber)
                    If dt.Count > 0 Then Return True

                Catch ex As Exception
                    Return False

                End Try


            End Using
        End Using

        Return False

    End Function
    '
    ' ***********************************************
    ' *****     Set Type by Foreign Key
    ' ***********************************************
    '
    Private Function SetTypeByFK(ByVal anId As Guid) As ReportTypes
        ' 
        ' Bad ID
        '
        If anId.Equals(New Guid) Then Return False
        '
        ' Is there a ReportId record that matches anID?
        '
        Using ta As vreportsDataSetTableAdapters.ReportMasterTableAdapter = New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
                '
                Try
                    ta.FillByReportID(dt, anId)
                    If dt.Count = 1 Then
                        ReportType = ReportTypes.HomeInspection
                        ReportID = anId

                    End If
                Catch ex As Exception
                    MsgBox("SetTypeByFK()" & vbCrLf & "Error in ReportID lookup")

                End Try
            End Using 'dt
        End Using 'ta

        Return ReportType

    End Function
    '
    ' ***********************************************
    ' *****     Load By ID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.ReportMasterTableAdapter = New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByReportID(dt, id)
                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByID()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Load By FK ID and Type
    ' ***********************************************
    '
    Private Function LoadByFkIDAndType() As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.ReportMasterTableAdapter = New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
                '
                'Preset the object's state
                '
                ObjectState = ObjectStates.ErrorCondition
                '
                'Try various load by type
                '
                Try
                    Select Case ReportType
                        Case ReportTypes.HomeInspection
                            ta.FillByReportIDAndReportType(dt, ReportID, ReportType)

                        Case Else
                            MsgBox("LoadByFkAndType()" & vbCrLf & String.Format("There wans't a case for %s", ReportType))
                            ObjectState = ObjectStates.ErrorCondition
                            Return ObjectState

                    End Select

                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndReportType()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Address Rule Check
    ' ***********************************************
    '
    ' An address object in the database is only valid under these conditions:
    ' A. Must not be in an error condition.
    '
    ' 1) It is typed with an ReportType .
    ' 2) It's own primary key must be a valid Guid
    '
    ' As of this writing, a foreign key (fk) is condidered valid if it contains
    ' a Guid with a value other than 0000000000's. There is no rule check to see if the
    ' fk actually exists as a primary key in the table that defines it.  This is a significant
    ' weakness that will be corrected at a later point.
    '
    Private Function AddressRuleCheck() As Boolean
        '
        ' Rule A
        '
        If ObjectState = ObjectStates.ErrorCondition Then Return False
        '
        ' Set the flags 
        '
        Dim bRule_1_Met As Boolean = True
        Dim bRule_2_Met As Boolean = True
        '
        ' Rule 1
        '
        If ReportType = -1 Then
            bRule_1_Met = False

        End If
        '
        ' Rule 2
        '
        If ReportID.Equals(New Guid) Then
            bRule_2_Met = False
        End If
        '
        ' Create the error message
        '
        Dim sMessage As String = "Report Rule Check"
        If Not bRule_1_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Report Type isn't valid."

        End If
        '
        '
        '
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The ReportID isn't a valid primary key."

        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met Then
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
        If Not AddressRuleCheck() Then
            Return False

        End If
        '
        ' Passed the rule check, so update the record
        '
        Using ta As vreportsDataSetTableAdapters.ReportMasterTableAdapter = New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
                Dim row As vreportsDataSet.ReportMasterRow
                ta.FillByReportID(dt, ReportID)
                If dt.Count = 0 Then
                    row = dt.NewReportMasterRow

                Else
                    row = dt.Rows(0)

                End If

                SetRowFromData(row)

                Try
                    If dt.Count = 0 Then dt.AddReportMasterRow(row)
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

End Class
