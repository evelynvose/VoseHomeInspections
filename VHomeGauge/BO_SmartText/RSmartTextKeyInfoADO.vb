﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSet
Imports SyncfusionWindowsFormsApplication1.VRepSmartTextDataSetTableAdapters

Public MustInherit Class RSmartTextKeyInfoADO
    Inherits RSmartTextKeyInfoData
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
        Using ta As New SmartTextKeysTableAdapter
            Using dt As New SmartTextKeysDataTable
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
    ' *****     +Find(guid):bool
    ' ***********************************************
    '
    Public Shared Function Find(ByVal theID As Guid) As Boolean
        Using ta As New SmartTextKeysTableAdapter
            Using dt As New SmartTextKeysDataTable
                Try
                    If IsNothing(theID) Then theID = Guid.NewGuid()
                    ta.FillByID(dt, theID)
                    If dt.Rows.Count > 0 Then
                        Return True
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return False
                    '
                End Try
                '
            End Using
        End Using
        Return False
    End Function
    ' 
    ' ***********************************************
    ' *****     -Find(string):bool
    ' ***********************************************
    '
    Public Shared Function Find(ByVal key As String) As Boolean
        Using ta As New SmartTextKeysTableAdapter
            Using dt As New SmartTextKeysDataTable
                Try
                    If IsNothing(key) Then key = ""
                    ta.FillByKey(dt, key)
                    If dt.Rows.Count > 0 Then
                        Return True
                        '
                    End If
                    '
                Catch ex As Exception
                    '
                    Return False
                    '
                End Try
                '
            End Using
        End Using
        Return False
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
                .CommandText = "DELETE FROM SMARTTEXTKEYS WHERE (ID = ?)",
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
                Key = ""
                TS = Date.Now
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
    ' This row in the database is only valid under these conditions:
    '
    ' 1) It has a primary key and that key is guid.
    ' 2) All fields contain values.
    ' 3) The XValue field cannot be "" or Nothing
    '
    Private Function RuleCheck() As Boolean
        '
        ' Rule 1
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
        ' Rule 2
        '
        Dim bRule_2_Met As Boolean = True
        If IsNothing(Key) OrElse IsNothing(TS) Then
            sMessage &= vbCrLf
            sMessage &= "One or more fields are not valid."
            bRule_2_Met = False
            '
        End If
        '
        ' Rule 3
        '
        Dim bRule_3_Met As Boolean = True
        If Key = "" Then
            sMessage &= vbCrLf
            sMessage &= "Key can't be empty."
            bRule_3_Met = False
            '
        End If
        '
        ' Test the flags
        '
        If Not bRule_1_Met OrElse Not bRule_2_Met OrElse Not bRule_3_Met Then
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
        Using ta = New SmartTextKeysTableAdapter
            Using dt = New SmartTextKeysDataTable
                Dim row As SmartTextKeysRow
                If Not IsNew() Then
                    ta.FillByID(dt, ID)
                    If dt.Count = 0 Then
                        row = dt.NewSmartTextKeysRow
                        '
                    Else
                        row = dt.Rows(0)
                        '
                    End If
                Else ' is new connector
                    row = dt.NewSmartTextKeysRow
                    '
                End If
                '
                LoadRowFromData(row)
                '
                Try
                    If dt.Count = 0 Then dt.AddSmartTextKeysRow(row)
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
        Return IsDirty
        '
    End Function
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
