﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class CompanyDirectPhone
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
        MyBase.New(PhoneTypes.CompanyDirect)

    End Sub
    '
    ' ***********************************************
    ' *****     New(id)
    ' ***********************************************
    '
    Public Sub New(ByVal aClientID As Guid)
        MyBase.New(aClientID, PhoneTypes.CompanyDirect)
        '
        ' One of three things happened: 1) the record exists, 2) a new record was seeded, or 3) Error
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(id)" & vbCrLf & "The object is in an error condition!")

        End If
    End Sub
    '
End Class
