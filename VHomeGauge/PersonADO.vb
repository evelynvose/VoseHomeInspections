'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class PersonADO
    Inherits PersonData
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
    ' Case 2 - Existing person of type determined by wrapper class.
    ' Case 3 - A name, containing first and last, "Evelyn Vose". Fiest, middle and last is also acceptable. The wrapper supplies the type.
    '
    ' In all cases, we set the ObjectState variable to reflect the condition that was found and accomodated.
    '
    '
    ' Case 1
    '
    Friend Sub New()
        MyBase.New()

        ' All records in the Address table must have a primary key.
        PersonID = Guid.NewGuid()

        ' Tell the world that this is a new record
        ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' Case 2
    '
    Friend Sub New(ByVal anID As Guid, ByVal thepersontype As PersonTypes)
        MyBase.New()
        '
        ' Virgin ID means error condition!
        '
        If anID.Equals(New Guid) Then ' Error condition
            PersonType = -1
            ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Check if this is an existing record by PersonID
        '
        If LoadByID(anID, thepersontype) = ObjectStates.ExistingRecord Then
            Exit Sub

        End If

        ' Not existing, but since this is a valid GUID and type, we'll create a record for them.
        PersonType = thepersontype
        PersonID = Guid.NewGuid()
        ObjectState = ObjectStates.NewRecord


    End Sub
    '
    ' Case 2
    '
    Friend Sub New(ByVal thename As String, ByVal thepersontype As PersonTypes)
        MyBase.New()
        '
        ' Virgin name string means error condition!
        '
        If IsNothing(thename) OrElse thepersontype = -1 Then ' Error condition
            PersonType = -1
            ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Set the PersonType
        '
        PersonType = thepersontype
        '
        ' Check if this is an existing record by first and last names and type.
        '
        If LoadByName(thename) = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        ' Not existing, but since this is a valid name and type, we'll create a record for them.
        ' Note: FirstName and LastName were decomposed from the LoadByName method and these properties
        '       have been set by the time we reach this point.
        '
        PersonType = thepersontype
        PersonID = Guid.NewGuid()
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
    ' *****     Set Type by Foreign Key
    ' ***********************************************
    '
    Private Function SetTypeByFK(ByVal anId As Guid) As PersonTypes
        ' 
        ' Bad ID
        '
        If anId.Equals(New Guid) Then Return False
        '
        ' Is there a PersonId record that matches anID?
        '
        Using ta As vreportsDataSetTableAdapters.PersonTableAdapter = New vreportsDataSetTableAdapters.PersonTableAdapter
            Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
                '
                Try
                    ta.FillByPersonID(dt, anId)
                    If dt.Count = 1 Then
                        PersonType = dt.Rows(0).Item("PersonType")
                        PersonID = anId

                    End If
                Catch ex As Exception
                    MsgBox("SetTypeByFK()" & vbCrLf & "Error in PersionID lookup",, "PersonADO Class")

                End Try
            End Using 'dt
        End Using 'ta

        Return PersonType

    End Function
    '
    ' ***********************************************
    ' *****     Load By ID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid, ByVal thepersontype As PersonTypes) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.PersonTableAdapter = New vreportsDataSetTableAdapters.PersonTableAdapter
            Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
                ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByPersonIDAndType(dt, id, thepersontype)
                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByID()" & vbCrLf & ex.Message,, "PersonADO Class")

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
        Using ta As vreportsDataSetTableAdapters.PersonTableAdapter = New vreportsDataSetTableAdapters.PersonTableAdapter
            Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
                ObjectState = ObjectStates.ErrorCondition

                Try
                    ta.FillByPersonIDAndType(dt, PersonID, PersonType)

                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndPersonType()" & vbCrLf & ex.Message,, "PersonADO Class")

                End Try
            End Using 'dt
        End Using 'ta

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Load By Name
    ' ***********************************************
    '
    Private Function LoadByName(ByVal thename As String) As ObjectStates
        '
        ' The Name will have to be split into First and Last parts since it is stored that way in the dB
        '
        Dim NameParts() As String = thename.Split(" ")
        If NameParts.Count = 0 OrElse NameParts.Count = 1 Then

            MsgBox("LoadByName()" & vbCrLf & String.Format("Just one name given where First and Last are needed: %s ", thename),, "PersonADO Class")
            ObjectState = ObjectStates.ErrorCondition
            Return ObjectState

        End If

        If NameParts.Count > 0 Then FirstName = NameParts(0)

        ' the last name is not so easy because there may be a middle name so we have to see
        ' how many elements there are in the array
        If NameParts.Count = 2 Then LastName = NameParts(1)
        If NameParts.Count = 3 Then LastName = NameParts(2)

        Using ta As vreportsDataSetTableAdapters.PersonTableAdapter = New vreportsDataSetTableAdapters.PersonTableAdapter
            Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
                ObjectState = ObjectStates.ErrorCondition

                Try
                    ta.FillByFirstLastNames(dt, FirstName, LastName, PersonType)

                    If dt.Count = 1 Then
                        SetDataFromRow(dt.Rows(0))
                        ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndPersonType()" & vbCrLf & ex.Message,, "PersonADO Class")

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
    ' 1) It is typed with an PersonType .
    ' 
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
        If PersonType = -1 Then
            bRule_1_Met = False
        End If
        '
        ' Rule 3
        '
        If PersonID.Equals(New Guid) Then
            bRule_3_Met = False
        End If
        '
        ' Create the error message
        '
        Dim sMessage As String = "Person Rule Check"
        If Not bRule_1_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Person isn't typed."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Person isn't tagged with at least one valid foreign key."

        End If
        If Not bRule_2_Met Then
            sMessage &= vbCrLf
            sMessage &= "The Person isn't tagged with a valid primary key."

        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met OrElse Not bRule_3_Met Then
            MsgBox(sMessage,, "PersonADO Class")
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
        Using ta As vreportsDataSetTableAdapters.PersonTableAdapter = New vreportsDataSetTableAdapters.PersonTableAdapter
            Using dt As vreportsDataSet.PersonDataTable = New vreportsDataSet.PersonDataTable
                Dim row As vreportsDataSet.PersonRow
                ta.FillByPersonID(dt, PersonID)
                If dt.Count = 0 Then
                    row = dt.NewPersonRow

                Else
                    row = dt.Rows(0)

                End If

                SetRowFromData(row)

                Try
                    If dt.Count = 0 Then dt.AddPersonRow(row)
                    ta.Update(dt)
                    IsDirty = False
                Catch ex As Exception
                    MsgBox("Update()" & vbCrLf & ex.Message,, "PersonADO Class")

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
