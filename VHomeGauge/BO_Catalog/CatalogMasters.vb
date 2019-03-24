Imports System.ComponentModel
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
' This is a named class.  It gives the generic report repository a common name identifier.
'
Public Class CatalogMasters
    Inherits CatalogMastersADO
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
    Public Sub New(ByVal parentcatalogitem As CatalogMaster)
        MyBase.New(parentcatalogitem)
        ' Do nothing on purpose!
    End Sub
    '
End Class
'
'
'
'
'
'
'
'
'

'
'
'
'
'
'
'
'
'


