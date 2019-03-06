Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid.Events
'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class dlgConnectors
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
    '
    ' ***********************************************
    ' *****     +Cancel_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub sfdgConnectors_RecordDeleting(sender As Object, e As RecordDeletingEventArgs) Handles sfdgConnectors.RecordDeleting
        Dim theConnectorInfo As RConnectorInfo
        theConnectorInfo = CType(e.Items(0), RConnectorInfo)
        Console.WriteLine(String.Format("Row is deleting: {0}, {1}", theConnectorInfo.XValue, theConnectorInfo.ID))
        If MsgBox("Delete this connector?", MsgBoxStyle.YesNo, "Delete Connector") = MsgBoxResult.Yes Then
            '
            ' Do something to the object to delete it.
            '
            theConnectorInfo.IsDeleted = True
            theConnectorInfo.Update()
            '
        Else
            e.Cancel = True
            '
        End If
    End Sub
    '
End Class
