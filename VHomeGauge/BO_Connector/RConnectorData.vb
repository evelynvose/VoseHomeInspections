'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 

Public MustInherit Class RConnectorData
    Inherits VObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     #New()
    ' ***********************************************
    '
    Protected Sub New()
        ' Do Nothing on purpose! 
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     #LoadDataFromRow(RConnectorsRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As vreportsDataSet.RConnectorsRow)
        With row
            ID = .ID
            XNode = .XNode
            XValue = .XValue
            XParentNode = .XParentNode
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RConnectorsRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As vreportsDataSet.RConnectorsRow)
        With row
            .ID = ID
            .XNode = XNode
            .XValue = XValue
            .XParentNode = XParentNode
            '
        End With
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     Encapsulated Members
    ' ***********************************************
    '
    Private m_IsDirty As Boolean
    Private m_ID As Guid = Guid.Empty
    Private m_XNode As String = ""
    Private m_XValue As String = ""
    Private m_XParentNode As String = ""
    '
    ' ***********************************************
    ' *****     +XNode(string):string
    ' ***********************************************
    '
    Public Property XNode As String
        Get
            Return m_XNode
        End Get
        Set(value As String)
            m_XNode = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +XValue(string):string
    ' ***********************************************
    '
    Public Property XValue As String
        Get
            Return m_XValue
        End Get
        Set(value As String)
            m_XValue = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +XParentNode(string):string
    ' ***********************************************
    '
    Public Property XParentNode As String
        Get
            Return m_XParentNode
        End Get
        Set(value As String)
            m_XParentNode = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     #IsDirty(string):string
    ' ***********************************************
    '
    Protected Property IsDirty As Boolean
        Get
            Return m_IsDirty
        End Get
        Set(value As Boolean)
            m_IsDirty = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +ID(guid):guid
    ' ***********************************************
    '
    Public Property ID As Guid
        Get
            Return m_ID
        End Get
        Set(value As Guid)
            m_ID = value
        End Set
    End Property
    '
End Class

