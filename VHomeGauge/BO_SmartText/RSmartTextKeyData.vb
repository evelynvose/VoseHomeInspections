
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSet
'
Public MustInherit Class RSmartTextKeyData
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
    ' *****     #LoadDataFromRow(RSmartTextKeysRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As SmartTextKeysRow)
        With row
            ID = .ID
            Key = .Key
            TS = .TS
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(RSmartTextKeysRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As SmartTextKeysRow)
        With row
            .ID = ID
            .Key = Key
            .TS = TS
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
    Private m_Key As String = ""
    Private m_TS As Date = Date.Now()
    '
    ' ***********************************************
    ' *****     +Key(string):string
    ' ***********************************************
    '
    Public Property Key As String
        Get
            Return m_Key
        End Get
        Set(value As String)
            m_Key = value
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
        End Set
    End Property
    '
End Class

