Imports Syncfusion.Windows.Forms
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class dlgTemplateConnectors
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    Events
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +Load(object, EventArgs)
    ' ***********************************************
    '
    Private m_ConnectorsRepos As New RConnectors
    Private Sub dlgTemplateConnectors_Load(sender As Object, e As EventArgs) Handles Me.Load
        sfdgConnectors.DataSource = m_ConnectorsRepos.GetRepos
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +OK_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        m_ConnectorsRepos.Update()
        Close()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     +Cancel_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
        '
    End Sub

    Private Sub sfdgConnectors_Click(sender As Object, e As EventArgs) Handles sfdgConnectors.Click

    End Sub
    '
End Class
