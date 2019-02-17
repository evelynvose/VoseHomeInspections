'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1

Public MustInherit Class Address
    '
    ' **********************************************
    ' ****
    ' ******    Constructor/Destructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        Initialize()

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
    Public Function Update() As Boolean
        If Not IsDirty Then Return IsDirty ' nothing to save or update

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
    ' ***********************************************
    ' *****     Initialize
    ' ***********************************************
    '
    Private Sub Initialize()

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    ' 
    '
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_AddressID As Guid = Guid.Empty
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
    Private m_AddressType As AddressTypes
    Private m_IsDirty As Boolean


    Public Property AddressID As Guid
        Get
            Return m_AddressID
        End Get
        Set(value As Guid)
            m_AddressID = value
            m_IsDirty = True
        End Set
    End Property

    Public Property PersonID As Guid
        Get
            Return m_PersonID
        End Get
        Set(value As Guid)
            m_PersonID = value
            m_IsDirty = True
        End Set
    End Property

    Public Property CompanyID As Guid
        Get
            Return m_CompanyID
        End Get
        Set(value As Guid)
            m_CompanyID = value
            m_IsDirty = True
        End Set
    End Property

    Public Property ReportID As Guid
        Get
            Return m_ReportID
        End Get
        Set(value As Guid)
            m_ReportID = value
            m_IsDirty = True
        End Set
    End Property

    Public Property Address1 As String
        Get
            Return m_Address1
        End Get
        Set(value As String)
            m_Address1 = value
            m_IsDirty = True
        End Set
    End Property

    Public Property Address2 As String
        Get
            Return m_Address2
        End Get
        Set(value As String)
            m_Address2 = value
            m_IsDirty = True
        End Set
    End Property

    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
            m_IsDirty = True
        End Set
    End Property

    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value
            m_IsDirty = True
        End Set
    End Property

    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
            m_IsDirty = True
        End Set
    End Property

    Public Property County As String
        Get
            Return m_County
        End Get
        Set(value As String)
            m_County = value
            m_IsDirty = True
        End Set
    End Property

    Public Property Country As String
        Get
            Return m_Country
        End Get
        Set(value As String)
            m_Country = value
            m_IsDirty = True
        End Set
    End Property

    Public Property AddressType As AddressTypes
        Get
            Return m_AddressType
        End Get
        Set(value As AddressTypes)
            m_AddressType = value
            m_IsDirty = True
        End Set
    End Property

    Public Property IsDirty As Boolean
        Get
            Return m_IsDirty
        End Get
        Set(value As Boolean)
            m_IsDirty = value
        End Set
    End Property

    Public Enum ObjectState
        NewRecord
        ExistingRecord
        ErrorCondition

    End Enum
End Class




