'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports Syncfusion.Windows.Forms
'
' This form handles the UI for the Smart Text interface.
'
Public Class dlgSmartText
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    LOAD
    ' ****
    ' **********************************************
    '
    Private Sub dlgSmartText_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     -btnOK_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()

    End Sub
    '
    ' ***********************************************
    ' *****     -btnCancel_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()

    End Sub
    '
    ' ***********************************************
    ' *****     -btnOptions_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        MsgBox("Not Implemented",, "Smart Text Options")
    End Sub
    '
End Class
