﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'

Public Class ClientAddress
    Inherits AddressADO
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

        ' This is what makes this a valid Client Address
        AddressType = AddressTypes.Residential

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
        If AddressType <> AddressTypes.Residential Then
            MsgBox("Class ClientAddress" & vbCrLf & "Not a valid AddressType!")

        End If


    End Sub



End Class
