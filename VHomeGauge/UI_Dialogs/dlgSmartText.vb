'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid.Events
Imports System.IO
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
    Private m_SmartTextKeysRepos As New RSmartTextKeys
    Private m_SmartTextValuesRepos As RSmartTextValues
    ' Private m_SmartTextWhereUsedRepos As New RSmartTextWhereUsed
    '
    Private Sub dlgSmartText_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        ' Data grid parameters
        '
        sfdgSmartTextKeys.Columns(0).Width = sfdgSmartTextKeys.Width
        sfdgSmartTextValues.Columns(0).Width = sfdgSmartTextValues.Width
        sfdgWhereUsed.Columns(0).Width = sfdgWhereUsed.Width
        '
        ' Load the Keys grid. The other grids will get loaded when a Key is selected.
        '
        sfdgSmartTextKeys.DataSource = m_SmartTextKeysRepos.GetRepos
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
    ' *****     -btnOK_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        ' 
        '
        Cursor = Cursors.WaitCursor
        m_SmartTextKeysRepos.Update()
        m_SmartTextValuesRepos.Update()
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

    End Sub
    '
    ' ***********************************************
    ' *****     -sfdgSmartTextKeys_SelectionChanged(object, EventArgs)
    ' ***********************************************
    '
    Private Sub sfdgSmartTextKeys_SelectionChanged(sender As Object, e As EventArgs) Handles sfdgSmartTextKeys.SelectionChanged
        '
        ' Get the selected row. It will be the RSmartTextKey object.
        ' We want to  build th Values repository by FK, so we use the overloaded GetRepos() method
        '        
        Cursor = Cursors.WaitCursor
        Dim theSmartTextKey As RSmartTextKey = TryCast(sfdgSmartTextKeys.SelectedItem, RSmartTextKey)
        If IsNothing(theSmartTextKey) Then Exit Sub
        '
        m_SmartTextValuesRepos = New RSmartTextValues
        sfdgSmartTextValues.DataSource = m_SmartTextValuesRepos.GetRepos(theSmartTextKey)
        Cursor = Cursors.Default
    End Sub
    '
    ' ***********************************************
    ' *****     -sfdgSmarttextKeys_RecordDeleting(object, EventArgs)
    ' ***********************************************
    '
    Private Sub sfdgSmarttextKeys_RecordDeleting(sender As Object, e As RecordDeletingEventArgs) Handles sfdgSmartTextKeys.RecordDeleting
        Dim theInfo As RSmartTextKey
        theInfo = TryCast(e.Items(0), RSmartTextKey)
        If IsNothing(theInfo) Then Exit Sub
        ' Console.WriteLine(String.Format("Row is deleting: {0}, {1}", theInfo.ID, theInfo.ID))
        If MsgBox("Delete this Key?", MsgBoxStyle.YesNo, "Delete Key") = MsgBoxResult.Yes Then
            '
            ' Do something to the object to delete it.
            '
            ' Cursor = Cursors.WaitCursor
            Try
                theInfo.IsDeleted = True
                theInfo.Update()
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
    ' *****     -sfdgSmarttextValues_RecordDeleting(object, EventArgs)
    ' ***********************************************
    '
    Private Sub sfdgSmarttextValues_RecordDeleting(sender As Object, e As RecordDeletingEventArgs) Handles sfdgSmartTextValues.RecordDeleting
        Dim theInfo As RSmartTextValue
        theInfo = TryCast(e.Items(0), RSmartTextValue)
        If IsNothing(theInfo) Then Exit Sub
        ' Console.WriteLine(String.Format("Row is deleting: {0}, {1}", theInfo.ID, theInfo.ID))
        If MsgBox("Delete this Value?", MsgBoxStyle.YesNo, "Delete Value") = MsgBoxResult.Yes Then
            '
            ' Do something to the object to delete it.
            '
            ' Cursor = Cursors.WaitCursor
            Try
                theInfo.IsDeleted = True
                theInfo.Update()
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
        MsgBox("Not Implemented",, "Smart Text Options")
        Exit Sub
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
        'm_ConnectorsRepos = New RConnectors
        'sfdgConnectors.DataSource = Nothing
        'sfdgConnectors.DataSource = m_ConnectorsRepos.GetRepos
        Cursor = Cursors.Default
        '
    End Sub
    '
End Class
