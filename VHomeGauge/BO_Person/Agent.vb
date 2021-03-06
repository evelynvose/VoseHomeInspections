﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class Agent
    Inherits Person
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     New() as in virgin
    ' ***********************************************
    '   
    Public Sub New()
        MyBase.New()
        '
        ' Set the PersonType
        '
        PersonType = PersonTypes.Agent
        '
    End Sub
    '
    ' ***********************************************
    ' *****     New(AgentID)
    ' ***********************************************
    '
    Public Sub New(ByVal AgentID As Guid)
        MyBase.New(AgentID, PersonTypes.Agent)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using anID to determine if an Agent record exists. If an existing record
        ' is not found, a new record is seeded. We do this because HGI creates its own GUID.
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(AgentID)" & vbCrLf & "Not a valid Agent type or GUID!")
            '
        End If
        '
        ' Set the PersonType
        '
        PersonType = PersonTypes.Agent
        '
    End Sub
    '
    ' ***********************************************
    ' *****     New(name)
    ' ***********************************************
    '
    Public Sub New(ByVal thefullname As String)
        MyBase.New(thefullname, PersonTypes.Agent)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using theFullName to determine if we have a record. If no record exists
        ' and the name string is not empty or nothing, then a new record is seeded.
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(fullname)" & vbCrLf & "Not a valid two or three part name!")
            '
        End If
        '
        ' Set the PersonType
        '
        PersonType = PersonTypes.Agent
        '
    End Sub



End Class
