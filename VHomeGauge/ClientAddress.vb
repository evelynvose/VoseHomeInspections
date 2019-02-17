'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class ClientAddress
    Inherits Address
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' There are two scenarios that this object spports: a) the address ID is new, or b) the address id is not new.
    ' Scenario a) is the simplest to handle. A new address ID is created and a new row is readied for possible insert.
    ' Scenario b) is more complicated and can be broken down into the following:
    ' We don't know if we're being given an address ID or a person ID, so we have to guess
    ' by trying each case. There are three possibilities: 1) we find the record by ID, 2) we find it by PersonId and Type, or 3) we don't find a record.
    '
    ' Cases 1 and 2 - set the row and return.
    ' Case 3 - set a virgin row to be delt with by the caller.
    '
    ' In all three cases, we set the rowstate to reflect the condition that was found and accomodated.
    '
    Public Sub New(ByVal id As Guid)
        MyBase.New()

        ' Virgin ID means set up a new Address Record!
        If id.Equals(New Guid) Then ' start a virgin row
            AddressID = Guid.NewGuid()
            AddressType = AddressTypes.Residential

            ' Tell the world that this is a new record
            m_ObjectState = ObjectState.NewRecord
            Exit Sub

        End If

        ' Check if this is an existing record by AddressID
        If LoadByID(id) = ObjectState.ExistingRecord Then
            Exit Sub

        End If

        ' Check to see if this is a PersonID
        If LoadByPersonIDAndAddressType(id, AddressTypes.Residential) = ObjectState.ExistingRecord Then
            Exit Sub

        End If

        ' Looks like we have a new address to create!
        AddressID = Guid.NewGuid()
        PersonID = id
        AddressType = AddressTypes.Residential
        m_ObjectState = ObjectState.NewRecord

    End Sub
    '
    ' ***********************************************
    ' *****     Load By ID
    ' ***********************************************
    '
    Private Function LoadByID(ByVal id As Guid) As ObjectState
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                m_ObjectState = ObjectState.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByID(dt, id)
                    If dt.Count = 1 Then
                        LoadFromRow(dt)
                        m_ObjectState = ObjectState.ExistingRecord

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
    ' *****     Load By Person ID
    ' ***********************************************
    '
    Private Function LoadByPersonIDAndAddressType(ByVal personid As Guid, ByVal addresstype As AddressTypes) As ObjectState
        '
        Using ta As vreportsDataSetTableAdapters.AddressTableAdapter = New vreportsDataSetTableAdapters.AddressTableAdapter
            Using dt As vreportsDataSet.AddressDataTable = New vreportsDataSet.AddressDataTable
                m_ObjectState = ObjectState.ErrorCondition
                Try
                    ' This call assumes that the GUID is in fact, an AddressRecordID
                    ta.FillByPersonIDAndType(dt, personid, addresstype)
                    If dt.Count = 1 Then
                        LoadFromRow(dt)
                        m_ObjectState = ObjectState.ExistingRecord

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
    ' *****     Load From Row
    ' ***********************************************
    '
    Private Function LoadFromRow(ByRef dt As vreportsDataSet.AddressDataTable) As ObjectState

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
            MsgBox("LoadFromRow()" & vbCrLf & "Error setting the row in Address()!")
            m_ObjectState = ObjectState.ErrorCondition

        End Try

        Return m_ObjectState

    End Function
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_ObjectState As ObjectState
    Public ReadOnly Property IsNew As Boolean
        Get
            If m_ObjectState = ObjectState.NewRecord Then Return True

            Return False

        End Get
    End Property

End Class
