'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class AddressData
    Inherits VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    Protected Sub New()
        Initialize()

    End Sub
    '
    ' ***********************************************
    ' *****     Initialize
    ' ***********************************************
    '
    Private Sub Initialize()

    End Sub
    '
    ' ***********************************************
    ' *****     #SetDataFromRow(object):Integer
    ' ***********************************************
    '
    Protected Function SetDataFromRow(ByRef row As vreportsDataSet.AddressRow) As ObjectStates

        Try
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
                AddressType = .AddressType
                '
            End With
            '
            ' Copying into the properties caused the dirty flag to be set.  Not dirty so reset the flag.
            '
            IsDirty = False
            '
        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & "Error setting the row in Address()!")
            m_ObjectState = ObjectStates.ErrorCondition
            '
        End Try

        Return m_ObjectState
        '
    End Function
    '
    ' ***********************************************
    ' *****     Set Row From Data
    ' ***********************************************
    '
    Protected Function SetRowFromData(ByRef row As vreportsDataSet.AddressRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
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
                .AddressType = AddressType

            End With

        Catch ex As Exception
            MsgBox("SetRowFromData()" & vbCrLf & ex.Message)
            bFlag = False

        End Try

        Return bFlag

    End Function
    '
    '
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    '
    ' ***********************************************
    ' *****     Object Standard
    ' ***********************************************
    '   
    ' Non-encapsulated Data
    '
    Public Enum ObjectStates
        NewRecord
        ExistingRecord
        ErrorCondition

    End Enum
    '
    ' Encapsulated Data
    '
    Private m_IsDirty As Boolean
    Private m_AddressID As Guid = Guid.Empty
    Private m_AddressType As AddressTypes = "-1"
    '
    ' AddressID, which is the primary key
    '
    Public Property AddressID As Guid
        Get
            Return m_AddressID
        End Get
        Set(value As Guid)
            m_AddressID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address Type, all biz objects using this design pattern have a type, even if it has just one type
    '
    Public Property AddressType As AddressTypes
        Get
            Return m_AddressType
        End Get
        Set(value As AddressTypes)
            m_AddressType = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' IsDirty, is a flag that reflects whether or not the Set has been called, meaning (most of the time) that the data has changed.
    '          It is noteworthy that no comparisions are done so the mere call of Set sets this flag to True.
    '
    Public Property IsDirty As Boolean
        Get
            Return m_IsDirty
        End Get
        Set(value As Boolean)
            m_IsDirty = value
        End Set
    End Property
    Private m_ObjectState As ObjectStates
    '
    ' IsNew, is an interpreted flag that let's the caller know if the object has never been saved to the dB
    '
    Public ReadOnly Property IsNew As Boolean
        Get
            If m_ObjectState = ObjectStates.NewRecord Then Return True

            Return False

        End Get
    End Property
    '
    ' ObjectState, is an internal state indicator, that controls program flow depending on state cases.
    '              This property is not exposed, but instead, its states may be exposed by named properties, i.e., IsNew
    '
    Protected Property ObjectState As ObjectStates
        Get
            Return m_ObjectState
        End Get
        Set(value As ObjectStates)
            m_ObjectState = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     Implementation Specific Encapsulated Data
    ' ***********************************************
    '
    Private m_PersonID As Guid = Guid.Empty
    Private m_CompanyID As Guid = Guid.Empty
    Private m_ReportID As Guid = Guid.Empty
    Private m_Address1 As String = ""
    Private m_Address2 As String = ""
    Private m_City As String = ""
    Private m_State As String = ""
    Private m_ZipCode As String = ""
    Private m_County As String = ""
    Private m_Country As String = "US"
    '
    ' PersonID, this is a GUID that serves as a foreign key tag.
    '
    Protected Property PersonID As Guid
        Get
            Return m_PersonID
        End Get
        Set(value As Guid)
            m_PersonID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' CompanyID, this is a GUID that serves as a foreign key tag.
    '
    Public Property CompanyID As Guid
        Get
            Return m_CompanyID
        End Get
        Set(value As Guid)
            m_CompanyID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ReportID, this is a GUID that serves as a foreign key tag.
    '
    Public Property ReportID As Guid
        Get
            Return m_ReportID
        End Get
        Set(value As Guid)
            m_ReportID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address 1
    '
    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address 2
    '
    Public Property Address2 As String
        Get
            Return m_Address2
        End Get
        Set(value As String)
            m_Address2 = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' City
    '
    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' State
    '
    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Zip Code
    '
    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' County
    '
    Public Property County As String
        Get
            Return m_County
        End Get
        Set(value As String)
            m_County = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Country, technically not needed for the pupose of this application, but kept because HGI captures the information.
    '
    Public Property Country As String
        Get
            Return m_Country
        End Get
        Set(value As String)
            m_Country = value
            m_IsDirty = True
        End Set
    End Property


End Class
'///////////////////////////////////////////// END OF CLASS //////////////////////////////////////////////
'
' **********************************************
' ****
' ******    Globals
' ****
' **********************************************
' 
Public Enum AddressTypes As Integer ' Must match database!
    Unassigned = -1
    Null
    Residential
    JobSite
    Company
    '
End Enum




