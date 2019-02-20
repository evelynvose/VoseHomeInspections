'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class PersonFaxPhone
    Inherits PhoneADO
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
        MyBase.New(PhoneTypes.PersonFax)

    End Sub
    '
    ' ***********************************************
    ' *****     New(id)
    ' ***********************************************
    '
    Public Sub New(ByVal aClientID As Guid)
        MyBase.New(aClientID, PhoneTypes.PersonFax)
        '
        ' One of three things happened: 1) the record exists, 2) a new record was seeded, or 3) Error
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(id)" & vbCrLf & "The object is in an error condition!",, "PersonFaxPhone Class")

        End If
    End Sub
    '
End Class
