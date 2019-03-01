'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class EmailAddressData
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
    Friend Function SetDataFromRow(ByRef row As vreportsDataSet.EmailAddressRow) As ObjectStates

        Try
            With row
                EmailAddressID = .ID
                PersonID = .PersonID
                URL = .URL
                EmailAddressType = .EmailType

            End With
        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & "Error setting the row in Address()!")
            m_ObjectState = ObjectStates.ErrorCondition

        End Try

        Return m_ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Set Row From Data
    ' ***********************************************
    '
    Protected Friend Function SetRowFromData(ByRef row As vreportsDataSet.EmailAddressRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
            With row
                .ID = EmailAddressID
                .PersonID = PersonID
                .URL = URL
                .EmailType = EmailAddressType

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
    '
    '


    '
    ' Encapsulated Data
    '
    Private m_IsDirty As Boolean
    Private m_EmailAddressID As Guid = Guid.Empty
    Private m_EmailAddressType As AddressTypes = "-1"
    '
    ' AddressID, which is the primary key
    '
    Public Property EmailAddressID As Guid
        Get
            Return m_EmailAddressID
        End Get
        Set(value As Guid)
            m_EmailAddressID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address Type, all biz objects using this design pattern have a type, even if it has just one type
    '
    Public Property EmailAddressType As EmailAddressTypes
        Get
            Return m_EmailAddressType
        End Get
        Set(value As EmailAddressTypes)
            m_EmailAddressType = value
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
    Private m_PersonID As Guid = Guid.Empty
    Private m_URL As String = ""
    '
    ' PersonID, this is a GUID that serves as a foreign key tag.
    '
    Protected Friend Property PersonID As Guid
        Get
            Return m_PersonID
        End Get
        Set(value As Guid)
            m_PersonID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Address 1
    '
    Public Property URL As String
        Get
            Return m_URL
        End Get
        Set(value As String)
            m_URL = value
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
Public Enum EmailAddressTypes
    Primary
    Second
    Third

End Enum




