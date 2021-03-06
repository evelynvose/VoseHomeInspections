﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'    
' This passthrough class provides a generic level of abstraction.
' 
Public MustInherit Class Person
    Inherits PersonADO
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
    ' *****     #New(guid, PersonTypes)
    ' ***********************************************
    '   
    Protected Sub New(ByVal AgentID As Guid, ByVal theType As PersonTypes)
        MyBase.New(AgentID, theType)
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     #New(string, PersonTypes)
    ' ***********************************************
    '   
    Protected Sub New(ByVal thefullname As String, ByVal theType As PersonTypes)
        MyBase.New(thefullname, theType)
        '
    End Sub
End Class
