'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
' This passthrough class provides a generic level of abstraction.
'
Public MustInherit Class Report
    Inherits ReportADO
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
        MyBase.New()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     #New(guid)
    ' ***********************************************
    '
    Protected Sub New(ByVal anID As Guid)
        MyBase.New(anID)
        '
    End Sub
End Class
