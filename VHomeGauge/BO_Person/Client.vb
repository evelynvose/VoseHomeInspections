'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class Client
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
        PersonType = PersonTypes.Client
        '
    End Sub
    '
    ' ***********************************************
    ' *****     New(ClientID)
    ' ***********************************************
    '
    Public Sub New(ByVal ClientID As Guid)
        MyBase.New(ClientID, PersonTypes.Client)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using anID to determine if an Client record exists. If an existing record
        ' is not found, a new record is seeded. We do this because HGI creates its own GUID.
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(ClientID)" & vbCrLf & "Not a valid Client type or GUID!")

        End If
        '
        ' Set the PersonType
        '
        PersonType = PersonTypes.Client
        '
    End Sub
    '
    ' ***********************************************
    ' *****     New(name)
    ' ***********************************************
    '
    Public Sub New(ByVal thefullname As String)
        MyBase.New(thefullname, PersonTypes.Client)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using theFullName to determine if we have a record. If no record exists
        ' and the name string is not empty or nothing, then a new record is seeded.
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(fullname)" & vbCrLf & "Not a valid two or three part name!")

        End If
        '
        ' Set the PersonType
        '
        PersonType = PersonTypes.Client
        '
    End Sub
End Class
