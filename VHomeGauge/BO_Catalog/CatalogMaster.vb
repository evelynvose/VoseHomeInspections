﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
' This is a named class
'
Public Class CatalogMaster
    Inherits CatalogMasterADO
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
        MyBase.New()
        ' Do nothing more on purpose!
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +New(guid)
    ' ***********************************************
    '
    Public Sub New(ByVal theID As Guid)
        MyBase.New(theID)
        '
        ' Do nothing more on purpose!
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
    ' *****     +Initialize()
    ' ***********************************************
    '
    Private Sub Initialize()
        '
        ' Do nothing on purpose!
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     +ToString():string
    ' ***********************************************
    '
    Public Overloads Function ToString() As String
        Return Name
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
    ' ***********************************************
    ' *****     +Property(string):string
    ' ***********************************************
    '


End Class
