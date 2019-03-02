'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class InspectionAddress
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
        AddressType = AddressTypes.JobSite

    End Sub
    '
    ' ***********************************************
    ' *****     New(id)
    ' ***********************************************
    '
    Public Sub New(ByVal aReportID As Guid)
        MyBase.New(aReportID, AddressTypes.JobSite)
        '
        ' The call to myBase.New(anID) determines in a record exists using the PersonID FK. 
        ' There are 3 cases: 1) Exists, 2) Doesn't exist but we can create one, or 3) error
        '
        If ObjectState = ObjectStates.ErrorCondition Then
            MsgBox("New(id)" & vbCrLf & "The object is in an error condition!")

        End If
    End Sub



End Class
