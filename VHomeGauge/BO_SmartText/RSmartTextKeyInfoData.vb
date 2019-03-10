Imports System.ComponentModel
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSet
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public MustInherit Class RSmartTextKeyInfoData
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
    ' ***********************************************
    ' *****     -IEditableObject_BeginEdit(RSmartTextKeysRow)
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
    ' *****     -IEditableObject_EndEdit(RSmartTextKeysRow)
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
    ' *****     -IEditableObject_CancelEdit(RSmartTextKeysRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_CancelEdit() Implements IEditableObject.CancelEdit
        '
        ' Copy the data from stored values (restores original values)
        '
        If Not IsNothing(m_CloneMe) Then
            With m_CloneMe
                ID = .ID
                Key = .Key
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
    Private m_Key As String = ""
    Private m_TS As Date = Date.Now()
    Private m_CloneMe As RSmartTextKeyInfoData
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

