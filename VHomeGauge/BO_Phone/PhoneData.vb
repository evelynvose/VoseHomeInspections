'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class PhoneData
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
    Friend Function SetDataFromRow(ByRef row As vreportsDataSet.PhoneRow) As ObjectStates

        Try
            With row
                PhoneID = .ID
                Number = .Number
                PersonID = .PersonID
                CompanyID = .CompanyID
                PhoneType = .PhoneType

            End With
        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & "Error setting the row in Phone()!")
            m_ObjectState = ObjectStates.ErrorCondition

        End Try

        Return m_ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Set Row From Data
    ' ***********************************************
    '
    Protected Friend Function SetRowFromData(ByRef row As vreportsDataSet.PhoneRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
            With row
                .ID = PhoneID
                .Number = Number
                .PersonID = PersonID
                .CompanyID = CompanyID
                .PhoneType = PhoneType

            End With

        Catch ex As Exception
            MsgBox("SetRowFromData()" & vbCrLf & ex.Message)
            bFlag = False

        End Try

        Return bFlag

    End Function
    '
    ' ***********************************************
    ' *****     Numerals Only
    ' ***********************************************
    '  
    Private Function NumeralsOnly(ByVal sIn As String) As String
        Dim sNew As String = ""
        For x = 0 To sIn.Length - 1
            If IsNumeric(sIn.Chars(x)) Then
                sNew &= sIn.Chars(x)

            End If
        Next
        Return sNew
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

    End Enum
    '
    ' Encapsulated Data
    '
    Private m_IsDirty As Boolean
    Private m_PhoneID As Guid = Guid.Empty
    Private m_PhoneType As PhoneTypes = "-1"
    '
    ' PhoneID, which is the primary key
    '
    Public Property PhoneID As Guid
        Get
            Return m_PhoneID
        End Get
        Set(value As Guid)
            m_PhoneID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Phone Type, all biz objects using this design pattern have a type, even if it has just one type
    '
    Public Property PhoneType As PhoneTypes
        Get
            Return m_PhoneType
        End Get
        Set(value As PhoneTypes)
            m_PhoneType = value
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
    Private m_CompanyID As Guid = Guid.Empty
    Private m_Number As String = ""
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
    ' Number, as in only numbers!
    '
    Public Property Number As String
        Get
            Return m_Number
        End Get
        Set(value As String)
            m_Number = NumeralsOnly(value)
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
Public Enum PhoneTypes
    PersonMobile
    PersonHome
    PersonWork
    PersonFax
    CompanyMobile
    CompanyMain
    CompanyDirect
    CompanyFax

End Enum




