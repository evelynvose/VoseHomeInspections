'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports VHIHomeGaugeApplication.VRepSmartTextDataSet
' 
Public MustInherit Class RSmartTextValueData
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
    ' *****     #LoadDataFromRow(SmartTextValuesRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As SmartTextValuesRow)
        With row
            ID = .ID
            Value = .SValue
            FK_Key = .FK_Key
            TS = .TS
            '
        End With
    End Sub
    ' 
    ' ***********************************************
    ' *****     #LoadRowFromData(SmartTextValuesRow)
    ' ***********************************************
    '
    Protected Sub LoadRowFromData(ByRef row As SmartTextValuesRow)
        With row
            .ID = ID
            .SValue = Value
            .FK_Key = FK_Key
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
    Private m_Value As String = ""
    Private m_FK_Key As Guid = Guid.Empty
    Private m_TS As Date = Date.Now()
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
            m_IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +Value(string):string
    ' ***********************************************
    '
    Public Property Value As String
        Get
            Return m_Value
        End Get
        Set(value As String)
            m_Value = value
            m_IsDirty = True
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +FK_Key(guid):guid
    ' ***********************************************
    '
    Public Property FK_Key As Guid
        Get
            Return m_FK_Key
        End Get
        Set(value As Guid)
            m_FK_Key = value
            m_IsDirty = True
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
            m_IsDirty = True
        End Set
    End Property
    '
End Class

