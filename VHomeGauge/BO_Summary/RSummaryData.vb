
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.vreportsDataSet
'
Public MustInherit Class RSummaryData
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
    ' *****     #LoadDataFromRow(RSummarysRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As SummaryRow)
        With row
            ID = .ID
            Name = .SName
            Abbreviation = .Abbreviation
            FK_Introduction = .FK_Introduction
            m_FK_Footer = .FK_Footer
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RSummarysRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As SummaryRow)
        With row
            .ID = ID
            .SName = Name
            .Abbreviation = Abbreviation
            .FK_Footer = FK_Footer
            .FK_Introduction = FK_Introduction
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
    Private m_Name As String = ""
    Private m_Abbreviation As String = ""
    Private m_FK_Introduction As Guid = Guid.Empty
    Private m_FK_Footer As Guid = Guid.Empty
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
    ' *****     +Abbreviation(string):string
    ' ***********************************************
    '
    Public Property Abbreviation As String
        Get
            Return m_Abbreviation
        End Get
        Set(value As String)
            m_Abbreviation = value
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
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +FK_Introduction(guid):guid
    ' ***********************************************
    '
    Public Property FK_Introduction As Guid
        Get
            Return m_FK_Introduction
        End Get
        Set(value As Guid)
            m_FK_Introduction = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +FK_Footer(guid):guid
    ' ***********************************************
    '
    Public Property FK_Footer As Guid
        Get
            Return m_FK_Footer
        End Get
        Set(value As Guid)
            m_FK_Footer = value
            IsDirty = True
        End Set
    End Property
    '
End Class

