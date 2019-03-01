'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class AddressADO
    Inherits AddressData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    ' Being given an ID is complicated and can be broken down into the following:
    ' We don't know if we're being given an address ID or a foreign key, so we have to guess
    ' by trying each case. There are three possibilities: 1) we find the record by ID, 2) we find it by PersonId/ReportID/CompanyID, or 3) we don't find a record.
    '
    ' Case 1 - set the base data and return.
    ' Case 2 - We were given one of a ReportID or CompanyID, along with an HGI PersonID or virgin Guid
    ' Case 3 - When called through the New(id) constructor, this is an error condition. Display the error message and exit.  Later we will through an exception.
    '
    ' In all three cases, we set the ObjectState variable to reflect the condition that was found and accomodated.
    '
    '
    ' Case 1
    '
    Friend Sub New()
        MyBase.New()

        ' All records in the Address table must have a primary key.
        AddressID = Guid.NewGuid()

        ' Tell the world that this is a new record
        ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' Cases 2 & 3
    '
    Friend Sub New(ByVal aFkId As Guid, ByVal theAddressType As AddressTypes)
        MyBase.New()
        '
        ' Virgin ID means error condition!
        '
        If aFkId.Equals(New Guid) OrElse theAddressType = -1 Then ' Error condition
            AddressType = -1
            ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Check if this is an existing record by AddressID
        '
        If LoadByID(aFkId) = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        '
        '
        AddressType = theAddressType
        '
        ' Our only hope now is that anID is a valid foreign key.
        '
        If LoadByFkIdAndAddressType(aFkId) = ObjectStates.ExistingRecord Then Exit Sub
        '
        ' We may have had a valid GUID format and AddressType, but there isn't an address record
        ' so we'll assume that the instantiator wanted this to be a new address record.
        '
        AddressID = Guid.NewGuid()
        Select Case theAddressType
            Case AddressTypes.Company
                CompanyID = aFkId

            Case AddressTypes.JobSite
                ReportID = aFkId

            Case AddressTypes.Residential
                PersonID = aFkId

        End Select
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
    ' *****     Load By ID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByID(dt, id)
                    If dt.Count > 0 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByID()" & vbCrLf & ex.Message,, "AddressADO Class")

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Load By FK ID and AddressType
    ' ***********************************************
    '
    Private Function LoadByFkIdAndAddressType(ByVal aFkId As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    Select Case AddressType
                        Case AddressTypes.Company
                            ta.FillByCompanyIDAndType(dt, aFkId, AddressType)

                        Case AddressTypes.JobSite
                            ta.FillByReportIDAndType(dt, aFkId, AddressType)

                        Case AddressTypes.Residential
                            ta.FillByPersonIDAndType(dt, aFkId, AddressType)

                        Case Else
                            MsgBox("LoadByFkAndType()" & vbCrLf & String.Format("There wans't a case for %s", AddressType),, "AddressADO Class")
                            ObjectState = ObjectStates.ErrorCondition
                            Return ObjectState

                    End Select

                    If dt.Count > 0 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndAddressType()" & vbCrLf & ex.Message,, "AddressADO Class")

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
    ' 1) It is typed with an AddressType .
    ' 2) It has one or more valid foreign keys.
    ' 3) It's own primary key must be a valid Guid
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
        Dim bRule_3_Met As Boolean = True
        '
        ' Rule 1
        '
        If AddressType = -1 Then
            bRule_1_Met = False
        End If
        '
        ' Rule 2
        '
        Dim newGuid As Guid

        If PersonID.Equals(newGuid) AndAlso CompanyID.Equals(newGuid) AndAlso ReportID.Equals(newGuid) Then
            bRule_2_Met = False

        End If
        '
        ' Rule 3
        '
        If AddressID.Equals(newGuid) Then
            bRule_3_Met = False
        End If
        '
        ' Create the error message
        '
        Dim sMessage As String = "Address Rule Check"
        If Not bRule_1_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Address isn't typed."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Address isn't tagged with at least one valid foreign key."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Address isn't tagged with a valid primary key."

        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met OrElse Not bRule_3_Met Then
            MsgBox(sMessage,, "AddressADO Class")
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
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                Dim row As vreportsDataSet.AddressRow
                ta.FillByID(dt, AddressID)
                If dt.Count = 0 Then
                    row = dt.NewAddressRow

                Else
                    row = dt.Rows(0)

                End If

                SetRowFromData(row)

                Try
                    If dt.Count = 0 Then dt.AddAddressRow(row)
                    ta.Update(dt)
                    IsDirty = False
                Catch ex As Exception
                    MsgBox("Update()" & vbCrLf & ex.Message,, "AddressADO Class")

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
