'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.vreportsDataSet
Imports SyncfusionWindowsFormsApplication1.vreportsDataSetTableAdapters
Imports System.ComponentModel
'
Public MustInherit Class RSummaryADO
    Inherits RSummaryData
    Implements IEditableObject
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     +New()
    ' ***********************************************
    '
    Public Sub New()
        IsNew = True
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     #New(guid)
    ' ***********************************************
    '
    Protected Sub New(ByVal theID As Guid)
        If IsNothing(theID) Then theID = Guid.Empty
        IsNew = True
        Load(theID)
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
    ' *****     #Load(guid):bool
    ' ***********************************************
    '
    Protected Sub Load(ByVal theID As Guid)
        If IsNothing(theID) Then theID = Guid.Empty
        Using ta As New SummaryTableAdapter
            Using dt As New SummaryDataTable
                Try
                    ta.FillByID(dt, theID)
                    If dt.Rows.Count > 0 Then
                        LoadDataFromRow(dt.Rows(0))
                        IsDirty = False ' Info properties always set dirty flag so reset it.
                        IsNew = False   ' We're new only if load is never called
                        '
                    End If
                Catch ex As Exception
                    '
                    ' VObject hijacks MsgBox and sends the out put to UI and logs
                    '
                    MsgBox(ex)
                    '
                End Try
                '
            End Using
        End Using
    End Sub
    '
    ' ***********************************************
    ' *****     +Find(guid):RSummary
    ' ***********************************************
    '
    Public Shared Function Find(ByVal theID As Guid) As RSummary
        Using ta As New SummaryTableAdapter
            Using dt As New SummaryDataTable
                Try
                    If IsNothing(theID) Then theID = Guid.NewGuid()
                    ta.FillByID(dt, theID)
                    If dt.Rows.Count > 0 Then
                        Dim theObject As New RSummary(CType(dt.Rows(0), SummaryRow).ID)
                        Return theObject
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return Nothing
                    '
                End Try
                '
            End Using
        End Using
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(string):RSummary
    ' ***********************************************
    '
    Public Shared Function Find(ByVal name As String) As RSummary
        Using ta As New SummaryTableAdapter
            Using dt As New SummaryDataTable
                Try
                    If IsNothing(name) Then name = ""
                    ta.FillByName(dt, name)
                    If dt.Rows.Count > 0 Then
                        Dim theObject As New RSummary(CType(dt.Rows(0), SummaryRow).ID)
                        Return theObject
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return Nothing
                    '
                End Try
                '
            End Using
        End Using
        Return Nothing
    End Function
    ' 
    ' ***********************************************
    ' *****     +Delete()
    ' ***********************************************
    '
    ' Permanently deletes the row from the dB by ID, and clears the data in this object.
    '   '
    Public Sub Delete()
        '
        ' Set up the parameter
        '      
        Dim theIdParam As New OleDb.OleDbParameter With {
        .DbType = DbType.Guid,
        .ParameterName = "@ID",
        .Value = ID
            }
        '
        ' Build the command
        '
        Dim theCommand As New OleDb.OleDbCommand With {
                .CommandText = "DELETE FROM Summary WHERE (ID = ?)",
                .Connection = New OleDb.OleDbConnection(My.Settings.ConnectionString)
            }
        '
        ' Add the parameter to the command
        '
        theCommand.Parameters.Add(theIdParam)
        '
        ' Execute the query
        '
        Try
            theCommand.Connection.Open()
            '
            If theCommand.ExecuteNonQuery() > 0 Then
                '
                ' Set this object to its virgin state
                '
                ID = Guid.Empty
                Name = ""
                Abbreviation = ""
                FK_Footer = Guid.NewGuid
                FK_Introduction = Guid.NewGuid
                IsDeleted = False
                IsNew = True
                IsDirty = False
                '
            Else
                MsgBox(New Exception(String.Format("The delete operation failed for guid = {0}", ID)))
                '
            End If
            '
        Catch ex As Exception
            MsgBox(ex)
            '
        Finally
            theCommand.Connection.Close()
            '
        End Try
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -RuleCheck():bool
    ' ***********************************************
    '
    Private Function RuleCheck() As Boolean
        '
        ' Rule 1 - It has a primary key and that key is guid.
        '
        Dim sMessage As String = "Rule Check"
        Dim bRule_1_Met As Boolean = True
        If IsNothing(ID) OrElse ID.Equals(Guid.Empty) Then
            sMessage &= vbCrLf
            sMessage &= "ID is not valid."
            bRule_1_Met = False
            '
        End If
        '
        ' Rule 2 - The summary has a name
        '
        Dim bRule_2_Met As Boolean = True
        If IsNothing(Name) Then
            sMessage &= vbCrLf
            sMessage &= "Name field is not valid."
            bRule_2_Met = False
            '
        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met Then
            MsgBox(sMessage)
            Return False
            '
        End If
        '
        ' Success!
        '
        Return True
        '
    End Function
    '
    ' ***********************************************
    ' *****     +Update():bool
    ' ***********************************************
    '
    Public Function Update() As Boolean
        If Not IsDirty AndAlso Not IsDeleted Then Return False ' nothing to save or update
        If IsDeleted Then
            Delete()
            Return True
            '
        End If
        '
        ' Run the rule check
        '
        If IsDirty Then
            If Not RuleCheck() Then
                Return False
                '
            End If
        End If
        '
        ' Passed the rule check, so update the record
        '
        Using ta = New SummaryTableAdapter
            Using dt = New SummaryDataTable
                Dim row As SummaryRow
                If Not IsNew() Then
                    ta.FillByID(dt, ID)
                    If dt.Count = 0 Then
                        row = dt.NewSummaryRow
                        '
                    Else
                        row = dt.Rows(0)
                        '
                    End If
                Else ' is new connector
                    row = dt.NewSummaryRow
                    '
                End If
                '
                LoadRowFromData(row)
                '
                Try
                    If dt.Count = 0 Then dt.AddSummaryRow(row)
                    ta.Update(dt)
                    IsDirty = False
                    '
                Catch ex As Exception
                    MsgBox("Update()" & vbCrLf & ex.Message)
                    '
                End Try
                '
            End Using 'ta
        End Using ' dt
        '
        Return True
        '
    End Function
    ' 
    ' ***********************************************
    ' *****     -IEditableObject_BeginEdit(RSummarysRow)
    ' ***********************************************
    '
    Private m_CloneMe As RSummary
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
    ' *****     -IEditableObject_EndEdit(RSummarysRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_EndEdit() Implements IEditableObject.EndEdit
        '
        ' Clear stored values and commit data
        '        
        m_CloneMe = Nothing     ' Kill the clone
        Update()                  ' Commit data to dB, if IsDirty is set
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -IEditableObject_CancelEdit(RSummarysRow)
    ' ***********************************************
    '
    Private Sub IEditableObject_CancelEdit() Implements IEditableObject.CancelEdit
        '
        ' Copy the data from stored values (restores original values)
        '
        If Not IsNothing(m_CloneMe) Then
            With m_CloneMe
                ID = .ID
                Name = .Name
                Abbreviation = .Abbreviation
                FK_Footer = .FK_Footer
                FK_Introduction = .FK_Introduction
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
    Private m_IsDeleted As Boolean
    Private m_IsNew As Boolean
    '
    ' ***********************************************
    ' *****     +IsDeleted(bool):bool
    ' ***********************************************
    '
    Public Property IsDeleted As Boolean
        Get
            Return m_IsDeleted
        End Get
        Set(value As Boolean)
            m_IsDeleted = value
        End Set
    End Property
    '
    ' ***********************************************
    ' *****     +IsNew(bool):bool
    ' ***********************************************
    '
    Public Property IsNew As Boolean
        Get
            Return m_IsNew
        End Get
        Set(value As Boolean)
            m_IsNew = value
        End Set
    End Property
    '
End Class
