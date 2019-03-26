'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.VRepCatalog

Public MustInherit Class CatalogMasterData
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
    Protected Sub LoadDataFromRow(ByVal row As CatalogMasterRow)
        With row
            ID = New VGuid("CAT", .ID)
            Name = .CatName
            FK_Parent = New VGuid("CAT", .FK_Parent)
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RCatalogsRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As CatalogMasterRow)
        With row
            .ID = ID.Guid
            .CatName = Name
            .FK_Parent = FK_Parent.Guid
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
    Private m_Name As String = ""
    Private m_FK_Parent As VGuid
    '
    ' ***********************************************
    ' *****     +Name(string):string
    ' ***********************************************
    '
    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
            IsDirty = True
        End Set
    End Property
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

