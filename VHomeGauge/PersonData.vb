'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class PersonData
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    Friend Sub New()
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
    ' *****     Set Data From Row
    ' ***********************************************
    '
    Friend Function SetDataFromRow(ByRef row As vreportsDataSet.PersonRow) As ObjectStates

        Try
            With row
                PersonID = .ID
                FirstName = .FirstName
                LastName = .LastName
                UserName = .HGUserName
                Role = .Role
                PersonType = .PersonType

            End With
        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & "Error setting the row!",, "PersonData()")
            m_ObjectState = ObjectStates.ErrorCondition

        End Try

        Return m_ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Set Row From Data
    ' ***********************************************
    '
    Protected Friend Function SetRowFromData(ByRef row As vreportsDataSet.PersonRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
            With row
                .ID = PersonID
                .FirstName = FirstName
                .LastName = LastName
                .HGUserName = UserName
                .Role = Role
                .PersonType = PersonType

            End With

        Catch ex As Exception
            MsgBox("SetRowFromData()" & vbCrLf & ex.Message,, "PersonData()")
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
    Private m_PersonID As Guid = Guid.Empty
    Private m_PersonType As PersonTypes = "-1"
    '
    ' AddressID, which is the primary key
    '
    Public Property PersonID As Guid
        Get
            Return m_PersonID
        End Get
        Set(value As Guid)
            m_PersonID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address Type, all biz objects using this design pattern have a type, even if it has just one type
    '
    Public Property PersonType As PersonTypes
        Get
            Return m_PersonType
        End Get
        Set(value As PersonTypes)
            m_PersonType = value
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
    Protected Friend Property ObjectState As ObjectStates
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
    Private m_FirstName As String = ""
    Private m_LastName As String = ""
    Private m_UserName As String = ""
    Private m_Role As Integer = -1
    '
    ' FirstName
    '
    Public Property FirstName As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value
        End Set
    End Property
    '
    ' LastName
    '

    Public Property LastName As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value
        End Set
    End Property
    '
    ' UserName, for now this is the HGI User Name, but may be a VHI user name in the future
    '
    Public Property UserName As String
        Get
            Return m_UserName
        End Get
        Set(value As String)
            m_UserName = value
        End Set
    End Property
    '
    ' Role, you can think of this as a person subtype
    '
    Public Property Role As Integer
        Get
            Return m_Role
        End Get
        Set(value As Integer)
            m_Role = value
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
Public Enum PersonTypes ' Must match database!
    Client
    Agent
    Inspector

End Enum

Public Enum PersonRoles ' Must match database!
    Client
    BuyerAgent
    SellerAgent
    AgencyCoordinator

End Enum




