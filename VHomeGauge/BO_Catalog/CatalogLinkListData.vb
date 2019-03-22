'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.VRepCatalog

Public MustInherit Class CatalogLinkListData
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
    ' *****     #LoadDataFromRow(RCatalogsRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As CatalogLinkListRow)
        With row
            ID = New VGuid("C", .ID)
            FK_Parent = New VGuid("C", .FK_Parent)
            FK_Child = New VGuid("C", .FK_Parent)
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RCatalogsRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As CatalogLinkListRow)
        With row
            .ID = ID.Guid
            .FK_Parent = FK_Parent.Guid
            .FK_Child = FK_Child.Guid
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
    Private m_ID As VGuid
    Private m_FK_Parent As VGuid
    Private m_FK_Child As VGuid
    '
    ' ***********************************************
    ' *****     +FK_Parent(VGuid):VGuid
    ' ***********************************************
    '
    Public Property FK_Parent As VGuid
        Get
            Return m_FK_Parent
        End Get
        Set(value As VGuid)
            m_FK_Parent = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +FK_Child(VGuid):VGuid
    ' ***********************************************
    '
    Public Property FK_Child As VGuid
        Get
            Return m_FK_Child
        End Get
        Set(value As VGuid)
            m_FK_Child = value
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
    ' *****     +ID(VGuid):VGuid
    ' ***********************************************
    '
    Public Property ID As VGuid
        Get
            Return m_ID
        End Get
        Set(value As VGuid)
            m_ID = value
            m_IsDirty = True
        End Set
    End Property
    '
End Class

