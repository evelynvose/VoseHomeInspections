'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports System.ComponentModel
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSet
' 
Public MustInherit Class RSmartTextValueInfoData
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
    ' *****     #LoadDataFromRow(SmartTextValuesRow)
    ' ***********************************************
    '
    Protected Sub LoadDataFromRow(ByVal row As SmartTextValuesRow)
        With row
            ID = .ID
            Value = .SValue
            FK_key = .FK_Key
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
    ' ***********************************************
    ' *****     -IEditableObject_BeginEdit(SmartTextValuesRow)
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
    ' *****     -IEditableObject_EndEdit(SmartTextValuesRow)
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
    ' *****     -IEditableObject_CancelEdit(SmartTextValuesRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_CancelEdit() Implements IEditableObject.CancelEdit
        '
        ' Copy the data from stored values (restores original values)
        '
        If Not IsNothing(m_CloneMe) Then
            With m_CloneMe
                ID = .ID
                Value = .Value
                FK_key = .FK_key
                TS = .TS
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
    Private m_Value As String = ""
    Private m_FK_Key As Guid = Guid.Empty
    Private m_TS As Date = Date.Now()
    Private m_CloneMe As RSmartTextValueInfoData
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

