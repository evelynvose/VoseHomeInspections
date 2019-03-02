'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class RoleInfoData
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
        '
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
    ' *****     #SetDataFromRow(object):integer
    ' ***********************************************
    '
    Protected Function SetDataFromRow(ByRef row As vreportsDataSet.RoleInfoRow) As ObjectStates
        Try
            With row
                RoleInfoID = .ID
                PersonID = .PersonID
                ReportID = .ReportID
                RoleLutID = .RoleLutID
                '
            End With
            '
            ' Copying into the properties caused the dirty flag to be set.  Not dirty so reset the flag.
            '
            IsDirty = False
            '
        Catch ex As Exception
            MsgBox(ex)
            m_ObjectState = ObjectStates.ErrorCondition
            '
        End Try
        '
        Return m_ObjectState
        '
    End Function
    '
    ' ***********************************************
    ' *****     #SetRowFromData(object):boolean
    ' ***********************************************
    '
    Protected Function SetRowFromData(ByRef row As vreportsDataSet.RoleInfoRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
            With row
                .ID = RoleInfoID
                .PersonID = PersonID
                .ReportID = ReportID
                .RoleLutID = RoleLutID
                '
            End With

        Catch ex As Exception
            MsgBox(ex)
            bFlag = False

        End Try

        Return bFlag

    End Function
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
        '
    End Enum
    '
    ' Encapsulated Data
    '
    Private m_IsDirty As Boolean
    '
    ' ***********************************************
    ' *****     +IsDirty(boolean):boolean
    ' ***********************************************
    '    '
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
    ' ***********************************************
    ' *****     +IsNew(boolean):boolean
    ' ***********************************************
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
    ' ***********************************************
    ' *****     #ObjectState(integer):integer
    ' ***********************************************
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
    Private m_RoleInfoID As Integer
    Private m_PersonID As Guid = Guid.Empty
    Private m_ReportID As Guid = Guid.Empty
    Private m_RoleLutID As Integer
    Private m_RoleName As String = ""
    '
    ' ***********************************************
    ' *****     +RoleInfoID(integer):integer
    ' ***********************************************
    '
    Public Property RoleInfoID As Integer
        Get
            Return m_RoleInfoID
        End Get
        Set(value As Integer)
            m_RoleInfoID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +RoleLutID(integer):integer
    ' ***********************************************
    '
    Public Property RoleLutID As Integer
        Get
            Return m_RoleLutID
        End Get
        Set(value As Integer)
            m_RoleLutID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +PersonID(struct):struct
    ' ***********************************************
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
    ' ***********************************************
    ' *****     +ReportID(struct):struct
    ' ***********************************************
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
End Class
'///////////////////////////////////////////// END OF CLASS //////////////////////////////////////////////
'
' **********************************************
' ****
' ******    Globals
' ****
' **********************************************
' 
Public Enum RoleTypes As Integer ' Must match database!
    Unassigned = -1
    Null
    Client
    BuyerAgent
    Seller
    ListingAgent
    AgencyCoordinator
    Attorney
    '
End Enum




