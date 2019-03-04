Imports System.ComponentModel
Imports Syncfusion.Windows.Forms
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Public Class dlgMainFileProperties
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +dlgMainFileProperties_Load(object, EventArgs)
    ' ***********************************************
    '
    Private Sub dlgMainFileProperties_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        cboxErrorFile.Checked = My.Settings.LogInErrorFile
        cboxLogEvents.Checked = My.Settings.LogInEventFile
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +btnOK_Clicj(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        My.Settings.LogInErrorFile = cboxErrorFile.Checked
        My.Settings.LogInEventFile = cboxLogEvents.Checked
        '
    End Sub
    '
End Class
