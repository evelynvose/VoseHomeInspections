Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid.Events
Imports System.IO
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
    ' *****     -Load(object, EventArgs)
    ' ***********************************************
    '
    Private m_ConnectorsRepos As New RConnectors
    Private Sub dlgTemplateConnectors_Load(sender As Object, e As EventArgs) Handles Me.Load
        sfdgConnectors.DataSource = m_ConnectorsRepos.GetRepos
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -btnOK_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Cursor = Cursors.WaitCursor
        m_ConnectorsRepos.Update()
        Cursor = Cursors.Default
        Close()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -btnCancel_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -sfdgConnectors_RecordDeleting(object, EventArgs)
    ' ***********************************************
    '
    Private Sub sfdgConnectors_RecordDeleting(sender As Object, e As RecordDeletingEventArgs) Handles sfdgConnectors.RecordDeleting
        Dim theInfo As RConnectorInfo
        theInfo = TryCast(e.Items(0), RConnectorInfo)
        If IsNothing(theInfo) Then Exit Sub
        ' Console.WriteLine(String.Format("Row is deleting: {0}, {1}", theConnectorInfo.XValue, theConnectorInfo.ID))
        If MsgBox("Delete this connector?", MsgBoxStyle.YesNo, "Delete Connector") = MsgBoxResult.Yes Then
            '
            ' Do something to the object to delete it.
            '
            ' Cursor = Cursors.WaitCursor
            Try
                theInfo.IsDeleted = True
                theInfo.Delete()
                '
            Catch ex As Exception
                '
            Finally
                Cursor = Cursors.Default
            End Try
            '
        Else
            e.Cancel = True
            '
        End If
    End Sub
    '
    ' ***********************************************
    ' *****     -btnGear_Click(object, EventArgs)
    ' ***********************************************
    '
    ' Browse for the template file
    '
    Private Sub btnGear_Click(sender As Object, e As EventArgs) Handles btnGear.Click
        Dim OpenFileDialog1 = New OpenFileDialog With {
           .CheckFileExists = True,
           .CheckPathExists = True,
           .DefaultExt = "ht5",
           .FileName = "",
           .Filter = "Template Files (*.ht5)|*.ht5|All Files (*.*)|*.*",
           .Multiselect = False
       }
        '
        ' Set up the worker thread and launch the progress bar
        '
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim thePB As New dlgVProgressBar
            With thePB
                .StartPosition = FormStartPosition.CenterParent
                .SetDoWorkClass(New HGIConnectorImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Connectors"
                .AnnouncementVisible = False
                .RunningStatusVisible = True
                .OKButtonVisible = False
                .LaunchDoWork()
                .ShowDialog()
                '
            End With
        End If
        '
        ' reload from the dB
        '
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        m_ConnectorsRepos = New RConnectors
        sfdgConnectors.DataSource = Nothing
        sfdgConnectors.DataSource = m_ConnectorsRepos.GetRepos
        Cursor = Cursors.Default
        '
    End Sub
End Class
