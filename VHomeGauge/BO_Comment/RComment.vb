﻿'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
' This is a named class
'
Public Class RComment
    Inherits RCommentADO
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