'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class EmailAddress
    Inherits EmailAddressADO
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
    Public Sub New(ByVal theemailaddresstype As EmailAddressTypes)
        MyBase.New()

        ' This is what makes this a valid Client Address
        EmailAddressType = theemailaddresstype

    End Sub
    '
    ' ***********************************************
    ' *****     New(id)
    ' ***********************************************
    '
    Public Sub New(ByVal anID As Guid)
        MyBase.New(anID)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using anID to determine what AddressType we have. If New(anID) determined
        ' that the AddressType is other than Residential, this is an invalid object.
        '
        If EmailAddressType <> EmailAddressTypes.Primary Then
            MsgBox("New(anID)" & vbCrLf & "Not a valid AddressType!",, "EmailAddress Class")

        End If
    End Sub
    '
    ' ***********************************************
    ' *****     New(id, type)
    ' ***********************************************
    '
    Public Sub New(ByVal anID As Guid, ByVal emailaddresstype As EmailAddressTypes)
        MyBase.New(anID, emailaddresstype)
        '
        ' The call to myBase.New(anID) goes through the process of
        ' using anID to determine what AddressType we have. If New(anID) determined
        ' that the AddressType is other than Residential, this is an invalid object.
        '
        If emailaddresstype <> EmailAddressTypes.Primary Then
            MsgBox("New(anID, emailaddresstype)" & vbCrLf & "Not a valid AddressType!",, "EmailAddress Class")

        End If
    End Sub



End Class
