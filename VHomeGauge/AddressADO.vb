Public MustInherit Class AddressADO
    Inherits AddressData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' Being given an ID is complicated and can be broken down into the following:
    ' We don't know if we're being given an address ID or a foreign key, so we have to guess
    ' by trying each case. There are three possibilities: 1) we find the record by ID, 2) we find it by PersonId/ReportID/CompanyID, or 3) we don't find a record.
    '
    ' Case 1 - set the base data and return.
    ' Case 2 - Query each table (Person, Report and Company) and if the primary key returns results, set the base data, set the AddressType and return.
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
        m_ObjectState = ObjectStates.NewRecord

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
            AddressType = -1
            m_ObjectState = ObjectStates.ErrorCondition
            Exit Sub

        End If
        '
        ' Check if this is an existing record by AddressID
        '
        If LoadByID(anID) = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        ' Our only hope now is that anID is a valid foreign key.
        '
        If SetTypeByFK(anID) = -1 Then Exit Sub
        '
        ' If we made it this far we know that anID is a valid foreign key so
        ' we can go ahead and set the AddressData.  The wrapper class will have
        ' to determine if the data is valid for type of wrapper.
        '
        ' Assumes ForeignKey and AddressType has been set. ForeigKey is one of PersonID, ReportID or CompanyID
        '
        If LoadByFkIDAndType() = ObjectStates.ExistingRecord Then
            Exit Sub

        End If
        '
        ' We may have had a valid foreign key and AddressType, but there isn't an address record
        ' so we'll assume that the instantiator wanted this to be a virgin address record.
        '
        AddressID = Guid.NewGuid()
        m_ObjectState = ObjectStates.NewRecord

    End Sub
    '
    ' ***********************************************
    ' *****     Set Type by Foreign Key
    ' ***********************************************
    '
    Private Function SetTypeByFK(ByVal anId As Guid) As AddressTypes
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
                        AddressType = AddressTypes.Residential
                        PersonID = anId

                    End If
                Catch ex As Exception
                    MsgBox("SetTypeByFK()" & vbCrLf & "Error in PersionID lookup")

                End Try
            End Using 'dt
        End Using 'ta
        '
        ' Is there a CompanyId record that matches anID?
        '
        Using ta As vreportsDataSetTableAdapters.CompanyTableAdapter = New vreportsDataSetTableAdapters.CompanyTableAdapter
            Using dt As vreportsDataSet.CompanyDataTable = New vreportsDataSet.CompanyDataTable
                '
                Try
                    ta.FillByCompanyID(dt, anId)
                    If dt.Count = 1 Then
                        AddressType = AddressTypes.Company
                        CompanyID = anId

                    End If
                Catch ex As Exception
                    MsgBox("SetTypeByFK()" & vbCrLf & "Error in CompanyID lookup")

                End Try
            End Using 'dt
        End Using 'ta
        '
        ' Is there a ReportId record that matches anID?
        '
        Using ta As vreportsDataSetTableAdapters.ReportMasterTableAdapter = New vreportsDataSetTableAdapters.ReportMasterTableAdapter
            Using dt As vreportsDataSet.ReportMasterDataTable = New vreportsDataSet.ReportMasterDataTable
                '
                Try
                    ta.FillByReportID(dt, anId)
                    If dt.Count = 1 Then
                        AddressType = AddressTypes.JobSite
                        ReportID = anId

                    End If
                Catch ex As Exception
                    MsgBox("SetTypeByFK()" & vbCrLf & "Error in CompanyID lookup")

                End Try
            End Using 'dt
        End Using 'ta

        Return AddressType

    End Function
    '
    ' ***********************************************
    ' *****     Load By ID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid) As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                m_ObjectState = ObjectStates.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByID(dt, id)
                    If dt.Count = 1 Then
                        SetDataFromRow(dt)
                        m_ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByID()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return m_ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Load By FK ID and Type
    ' ***********************************************
    '
    Private Function LoadByFkIDAndType() As ObjectStates
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                m_ObjectState = ObjectStates.ErrorCondition
                Try
                    Select Case AddressType
                        Case AddressTypes.Company
                            ta.FillByCompanyIDAndType(dt, CompanyID, AddressType)

                        Case AddressTypes.JobSite
                            ta.FillByReportIDAndType(dt, ReportID, AddressType)

                        Case AddressTypes.Residential
                            ta.FillByPersonIDAndType(dt, PersonID, AddressType)

                        Case Else
                            MsgBox("LoadByFkAndType()" & vbCrLf & String.Format("There wans't a case for %s", AddressType))
                            m_ObjectState = ObjectStates.ErrorCondition
                            Return m_ObjectState

                    End Select

                    If dt.Count = 1 Then
                        SetDataFromRow(dt)
                        m_ObjectState = ObjectStates.ExistingRecord

                    End If

                Catch ex As Exception
                    MsgBox("LoadByIDAndAddressType()" & vbCrLf & ex.Message)

                End Try
            End Using 'dt
        End Using 'ta

        Return m_ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Set Data From Row
    ' ***********************************************
    '
    Private Function SetDataFromRow(ByRef dt As vreportsDataSet.AddressDataTable) As ObjectStates

        Try
            Dim row As vreportsDataSet.AddressRow = dt.Rows(0)
            With row
                AddressID = .ID
                Address1 = .Address1
                Address2 = .Address2
                City = .City
                State = .State
                ZipCode = .ZipCode
                County = .County
                Country = .Country
                PersonID = .PersonId
                ReportID = .ReportID
                CompanyID = .CompanyID
                AddressType = .Type

            End With
        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & "Error setting the row in Address()!")
            m_ObjectState = ObjectStates.ErrorCondition

        End Try

        Return m_ObjectState

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
                With row
                    .ID = AddressID
                    .Address1 = Address1
                    .Address2 = Address2
                    .City = City
                    .State = State
                    .ZipCode = ZipCode
                    .County = County
                    .Country = Country
                    .PersonId = PersonID
                    .ReportID = ReportID
                    .CompanyID = CompanyID
                    .Type = AddressType

                End With

                Try
                    If dt.Count = 0 Then dt.AddAddressRow(row)
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
    Private m_ObjectState As ObjectStates
    Public ReadOnly Property IsNew As Boolean
        Get
            If m_ObjectState = ObjectStates.NewRecord Then Return True

            Return False

        End Get
    End Property
    '
    ' ObjectState
    '
    Public ReadOnly Property ObjectState As ObjectStates
        Get
            Return m_ObjectState

        End Get
    End Property
    '
End Class
