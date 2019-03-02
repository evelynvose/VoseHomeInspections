'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class PhoneADO
    Inherits PhoneData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    ' Being given an ID is complicated and can be broken down into the following:
    ' We don't know if we're being given an Phone ID or a foreign key, so we have to guess
    ' by trying each case. There are three possibilities: 1) we find the record by ID, 2) we find it by PersonId/CompanyID, or 3) we don't find a record.
    '
    ' Case 1 - set the base data and return.
    ' Case 2 - We were given one of a PersonID or CompanyID FK
    ' Case 3 - When called through the New(id) constructor, this is an error condition. Display the error message and exit.  Later we will through an exception.
    '
    ' In all three cases, we set the ObjectState variable to reflect the condition that was found and accomodated.
    '
    '
    ' Case 1
    '
    Friend Sub New(ByVal thePhoneType As PhoneTypes)
        MyBase.New()

        Select Case thePhoneType
            Case PhoneTypes.PersonMobile, PhoneTypes.PersonHome, PhoneTypes.PersonWork, PhoneTypes.PersonFax, PhoneTypes.CompanyDirect
                PersonID = Guid.NewGuid

            Case PhoneTypes.CompanyMobile, PhoneTypes.CompanyMain, PhoneTypes.CompanyFax
                CompanyID = Guid.NewGuid

            Case Else
                ObjectState = ObjectStates.ErrorCondition
                Exit Sub

        End Select

        ' Tell the world that this is a new record
        ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' Cases 2 & 3
    '
    Friend Sub New(ByVal aFkId As Guid, ByVal thePhoneType As PhoneTypes)
        MyBase.New()
        '
        ' Virgin ID means error condition!
        '
        If aFkId.Equals(New Guid) OrElse thePhoneType = -1 Then ' Error condition
            PhoneType = -1
            ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Check if this is an existing record by PhoneID
        '
        If LoadByID(aFkId) = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        ' Our hope now is that anID is a valid foreign key of the correct type.
        '
        PhoneType = thePhoneType
        If LoadByFkIdAndPhoneType(aFkId) = ObjectStates.ExistingRecord Then Exit Sub
        '
        ' We may have had a valid GUID format and PhoneType, but there isn't an Phone record
        ' so we'll assume that the instantiator wanted this to be a new Phone record.
        '
        PhoneID = Guid.NewGuid()
        Select Case thePhoneType
            Case PhoneTypes.PersonMobile, PhoneTypes.PersonHome, PhoneTypes.PersonWork, PhoneTypes.PersonFax, PhoneTypes.CompanyDirect
                PersonID = aFkId

            Case PhoneTypes.CompanyMobile, PhoneTypes.CompanyMain, PhoneTypes.CompanyFax
                CompanyID = aFkId

            Case Else
                ObjectState = ObjectStates.ErrorCondition
                Exit Sub
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
    ' *****     Load By PhoneID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.PhoneTableAdapter = New vreportsDataSetTableAdapters.PhoneTableAdapter
            Using dt As vreportsDataSet.PhoneDataTable = New vreportsDataSet.PhoneDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an PhoneRecordID
                    ta.FillByPhoneID(dt, id)
                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByPhoneID()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Load By FK ID and PhoneType
    ' ***********************************************
    '
    Private Function LoadByFkIdAndPhoneType(ByVal aFkId As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.PhoneTableAdapter = New vreportsDataSetTableAdapters.PhoneTableAdapter
            Using dt As vreportsDataSet.PhoneDataTable = New vreportsDataSet.PhoneDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    Select Case PhoneType
                        Case PhoneTypes.CompanyFax, PhoneTypes.CompanyMain, PhoneTypes.CompanyMobile
                            ta.FillByCompanyIDAndPhoneType(dt, aFkId, PhoneType)

                        Case PhoneTypes.CompanyDirect, PhoneTypes.PersonFax, PhoneTypes.PersonHome, PhoneTypes.PersonMobile, PhoneTypes.PersonWork
                            ta.FillByPersonIDAndPhoneType(dt, aFkId, PhoneType)

                        Case Else
                            MsgBox("LoadByFkAndPhoneType()" & vbCrLf & String.Format("There wans't a case for {0}", PhoneType))
                            ObjectState = ObjectStates.ErrorCondition
                            Return ObjectState

                    End Select

                    If dt.Count > 0 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndPhoneType()" & vbCrLf & ex.Message)

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
    ' An Phone object in the database is only valid under these conditions:
    ' A. Must not be in an error condition.
    '
    ' 1) It is typed with an PhoneType .
    ' 2) It has one or more valid foreign keys.
    ' 3) It's own primary key must be a valid Guid
    '
    ' As of this writing, a foreign key (fk) is condidered valid if it contains
    ' a Guid with a value other than 0000000000's. There is no rule check to see if the
    ' fk actually exists as a primary key in the table that defines it.  This is a significant
    ' weakness that will be corrected at a later point.
    '
    Private Function PhoneRuleCheck() As Boolean
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
        If PhoneType = -1 Then
            bRule_1_Met = False
        End If
        '
        ' Rule 2
        '
        Dim newGuid As Guid

        If PersonID.Equals(newGuid) AndAlso CompanyID.Equals(newGuid) Then
            bRule_2_Met = False

        End If
        '
        ' Rule 3
        '
        If PhoneID.Equals(newGuid) Then
            bRule_3_Met = False
        End If
        '
        ' Create the error message
        '
        Dim sMessage As String = "Phone Rule Check"
        If Not bRule_1_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Phone isn't typed."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Phone isn't tagged with at least one valid foreign key."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Phone isn't tagged with a valid primary key."

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
        If Not PhoneRuleCheck() Then
            Return False

        End If
        '
        ' Passed the rule check, so update the record
        '
        Using ta As vreportsDataSetTableAdapters.PhoneTableAdapter = New vreportsDataSetTableAdapters.PhoneTableAdapter
            Using dt As vreportsDataSet.PhoneDataTable = New vreportsDataSet.PhoneDataTable
                Dim row As vreportsDataSet.PhoneRow
                ta.FillByPhoneID(dt, PhoneID)
                If dt.Count = 0 Then
                    row = dt.NewPhoneRow

                Else
                    row = dt.Rows(0)

                End If

                SetRowFromData(row)

                Try
                    If dt.Count = 0 Then dt.AddPhoneRow(row)
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
