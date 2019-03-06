Imports System.ComponentModel
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class RConnectorInfoData
    Inherits VObject
    Implements IEditableObject
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
    ' ***********************************************
    ' *****     -IEditableObject_BeginEdit(RConnectorsRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_BeginEdit() Implements IEditableObject.BeginEdit
        '
        '  Copy all of the data to stored values
        '
        m_CloneMe = Me.MemberwiseClone
        m_CloneMe.IsDirty = IsDirty
        ' 
    End Sub
    ' 
    ' ***********************************************
    ' *****     -IEditableObject_EndEdit(RConnectorsRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_EndEdit() Implements IEditableObject.EndEdit
        '
        ' Clear stored values
        '        
        m_CloneMe = Nothing     ' Kill the clone
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -IEditableObject_CancelEdit(RConnectorsRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_CancelEdit() Implements IEditableObject.CancelEdit
        '
        ' Copy the data from stored values (restores original values)
        '
        If Not IsNothing(m_CloneMe) Then
            With m_CloneMe
                ID = .ID
                XNode = .XNode
                XValue = .XValue
                XParentNode = .XParentNode
                IsDirty = .IsDirty
                '
            End With
        End If
        '
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
    Private m_CloneMe As RConnectorInfoData
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

