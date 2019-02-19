'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1

Public MustInherit Class ReportData
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
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
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
    Protected Friend Function SetDataFromRow(ByRef row As vreportsDataSet.ReportMasterRow) As ObjectStates

        Try
            With row
                ReportID = .ID
                InspectionDate = .InspectionDate
                ReportNumber = .ReportNumber
                ReportVersion = .Version
                StartTime = .StartTime
                EndTime = .EndTime
                SpecialNotes = .SpecialNotes
                AppointmentID = .AppointmentID
                ReportType = .ReportType

            End With

        Catch ex As Exception
            MsgBox("SetDataFromRow()" & vbCrLf & ex.Message,, "Report Data Class")
            ObjectState = ObjectStates.ErrorCondition

        End Try

        Return ObjectState

    End Function
    '
    ' ***********************************************
    ' *****     Set Row From Data
    ' ***********************************************
    '
    Protected Friend Function SetRowFromData(ByRef row As vreportsDataSet.ReportMasterRow) As Boolean
        Dim bFlag As Boolean = True
        '
        Try
            With row
                .ID = ReportID
                .InspectionDate = InspectionDate
                .ReportNumber = ReportNumber
                .Version = ReportVersion
                .StartTime = StartTime
                .EndTime = EndTime
                .SpecialNotes = SpecialNotes
                .AppointmentID = AppointmentID
                .ReportType = ReportType

            End With

        Catch ex As Exception
            MsgBox("SetRowFromData()" & vbCrLf & ex.Message,, "ReportData Class")
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

    End Enum
    '
    ' Encapsulated Data
    '
    Private m_IsDirty As Boolean
    Private m_ReportID As Guid = Guid.Empty
    Private m_ReportType As AddressTypes = "-1"
    Private m_ObjectState As ObjectStates = ObjectStates.NewRecord
    '
    ' ReportID, which is the primary key
    '
    Protected Friend Property ReportID As Guid
        Get
            Return m_ReportID
        End Get
        Set(value As Guid)
            m_ReportID = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Report Type, all biz objects using this design pattern have a type, even if it has just one type
    '
    Public Property ReportType As ReportTypes
        Get
            Return m_ReportType
        End Get
        Set(value As ReportTypes)
            m_ReportType = value
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
    Public Property ObjectState As ObjectStates
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
    Private m_InspectionDate As Date
    Private m_ReportNumber As String = ""
    Private m_ReportVersion As String = ""
    Private m_StartTime As String = ""
    Private m_EndTime As String = ""
    Private m_SpecialNotes As String = ""
    Private m_AppointmentID As Guid = New Guid
    '
    ' Inspection Date, critical for legal requirements.  Not to be confused with published date, a
    '                  different legal requirement. Published Date is not implemented at the time
    '                  of this writing.
    '
    Public Property InspectionDate As Date
        Get
            Return m_InspectionDate
        End Get
        Set(value As Date)
            m_InspectionDate = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ReportNumber, User assigned report identifier.  VHI uses this identifier, gets it from ISN, and appends
    '               a version number.  Since HGI is not capable of versioning, this is a manual process. It is a goal
    '               of VHomeGauge to implement a versioning system. 
    '
    Public Property ReportNumber As String
        Get
            Return m_ReportNumber
        End Get
        Set(value As String)
            m_ReportNumber = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ReportVersion, See above comment about ReportNumber. The first pass of this app will strip the version number
    '                from the HGI ReportNumber string, and store it in this dB field. Later, this will become a major
    '                feature of this app.
    '
    Public Property ReportVersion As String
        Get
            Return m_ReportVersion
        End Get
        Set(value As String)
            m_ReportVersion = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' StartTime, when the job was planned to start.  Home inspector can change this in the Companion App, in time accounting
    '            fashion; however, VHI does not presently implement time accounting. Still, we will capture the information
    '            when we decompose a HGI report - just in case we want to implement time accounting!
    '
    Public Property StartTime As String
        Get
            Return m_StartTime
        End Get
        Set(value As String)
            m_StartTime = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' End Time, see start time comments above.
    '
    Public Property EndTime As String
        Get
            Return m_EndTime
        End Get
        Set(value As String)
            m_EndTime = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' Special Notes, this text glob contains field data that is useful to VHI. Unfortunately, it comes across
    '                the ISN interface as a text glob, or HGI concatenates it into a text glob. This app will
    '                decompose the text glob into field data at a later date.
    '
    Public Property SpecialNotes As String
        Get
            Return m_SpecialNotes
        End Get
        Set(value As String)
            m_SpecialNotes = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' AppoitmentID, this GUID is captured by HGI in the report file.  I suspect it is the appointment ID from 
    '               HGI's job scheduling system.  Unverified as of this writing. Although it has no value to this app,
    '               it will be captured until it can be verified that it has no utility or importance.
    '
    Public Property AppointmentID As Guid
        Get
            Return m_AppointmentID
        End Get
        Set(value As Guid)
            m_AppointmentID = value
            m_IsDirty = True
        End Set
    End Property

End Class
' /////////////////////////////////////// END OF CLASS ///////////////////////////////////////////////
'
' **********************************************
' ****
' ******    Globals
' ****
' ****
Public Enum ReportTypes
    HomeInspection

End Enum

