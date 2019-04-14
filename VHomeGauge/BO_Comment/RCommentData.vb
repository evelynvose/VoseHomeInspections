
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports VHIHomeGaugeApplication.vreportsDataSet
'
Public MustInherit Class RCommentData
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
    ' *****     #LoadDataFromRow(RCommentsRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As CommentsRow)
        With row
            ID = .ID
            Name = .CName
            Text = .CText
            TS = .TS
            FK_SumID = .FK_SumID
            Auto = ._Auto
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RCommentsRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As CommentsRow)
        With row
            .ID = ID
            .CName = Name
            .CText = Text
            .TS = TS
            .FK_SumID = FK_SumID
            ._Auto = Auto
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
    Private m_Text As String = ""
    Private m_TS As Date = Date.Now()
    Private m_FK_SumID As Guid = Guid.Empty
    Private m_Auto As Boolean
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
    ' *****     +Text(string):string
    ' ***********************************************
    '
    Public Property Text As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +TS(date):date
    ' ***********************************************
    '
    Public Property TS As Date
        Get
            Return m_TS
        End Get
        Set(value As Date)
            m_TS = value
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
    ' *****     +FK_SumID(guid):guid
    ' ***********************************************
    '
    Public Property FK_SumID As Guid
        Get
            Return m_FK_SumID
        End Get
        Set(value As Guid)
            m_FK_SumID = value
            IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Auto(bool):bool
    ' ***********************************************
    '
    Public Property Auto As Boolean
        Get
            Return m_Auto
        End Get
        Set(value As Boolean)
            m_Auto = value
            IsDirty = True
        End Set
    End Property
    '
End Class

