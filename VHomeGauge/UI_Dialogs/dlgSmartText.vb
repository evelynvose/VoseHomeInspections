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
    Private m_SmartTextKeys As New RSmartTextKeys
    Private m_SmartTextValues As RSmartTextValues
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
        sfdgSmartTextKeys.DataSource = m_SmartTextKeys.GetRepos
        '
        ' Lock down values and where used grids
        '
        sfdgSmartTextValues.Enabled = False
        sfdgWhereUsed.Enabled = False
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
        ' Cursor = Cursors.WaitCursor
        ' m_SmartTextKeys.Update()
        ' m_SmartTextValues.Update()
        ' Cursor = Cursors.Default
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
        ' We want to  build the Values repository by FK, so we use the overloaded GetRepos() method
        '        
        Cursor = Cursors.WaitCursor
        Dim theSmartTextKey As RSmartTextKey = TryCast(sfdgSmartTextKeys.SelectedItem, RSmartTextKey)
        sfdgSmartTextValues.DataSource = Nothing
        If Not IsNothing(theSmartTextKey) Then
            m_SmartTextValues = New RSmartTextValues
            sfdgSmartTextValues.DataSource = m_SmartTextValues.GetRepos(theSmartTextKey)
            sfdgSmartTextValues.Enabled = True
            '
        End If
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
            Cursor = Cursors.WaitCursor
            Try
                m_SmartTextKeys.Remove(theInfo)
                theInfo.Delete()
                If sfdgSmartTextKeys.RowCount = 0 Then
                    sfdgSmartTextValues.DataSource = Nothing
                    sfdgSmartTextValues.Enabled = False
                    '
                End If
                '
            Catch ex As Exception
                '
            Finally
                Cursor = Cursors.Default
                '
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
                m_SmartTextValues.Remove(theInfo)
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
                .SetDoWorkClass(New HGISmartTextImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Smart Text"
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
        m_SmartTextKeys = New RSmartTextKeys
        sfdgSmartTextKeys.DataSource = m_SmartTextKeys.GetRepos
        sfdgSmartTextValues.DataSource = Nothing
        Cursor = Cursors.Default
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -sfdgSmartTextKeys_RowValidated(object, RowValidatedEventArgs)
    ' ***********************************************
    '
    ' 1) Checks if the object is new and saves it to the dB
    '
    Private Sub sfdgSmartTextKeys_RowValidated(sender As Object, e As RowValidatedEventArgs) Handles sfdgSmartTextKeys.RowValidated
        '
        ' Check for new objects, give them an ID, and put into the dB
        '
        With CType(e.DataRow.RowData, RSmartTextKey)
            If .IsNew AndAlso .ID.Equals(Guid.Empty) Then
                .ID = Guid.NewGuid
                '
            End If
            '
            ' The object should be updated regardless of its new or just editing status
            '
            .Update()
            '
        End With
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -sfdgSmartTextValuess_RowValidated(object, RowValidatedEventArgs)
    ' ***********************************************
    '
    ' 1) Checks if the object is new and saves it to the dB
    '
    Private Sub sfdgSmartTextValues_RowValidated(sender As Object, e As RowValidatedEventArgs) Handles sfdgSmartTextValues.RowValidated
        '
        ' Make sure a Key is selected so we can marry it to the new Value's FK_Key
        '
        Dim oSmarttextKey As RSmartTextKey = TryCast(sfdgSmartTextKeys.SelectedItem, RSmartTextKey)
        If IsNothing(oSmarttextKey) Then
            MsgBox("Can't add a Value if no Key is selected!",, "Smart Text")
            Exit Sub
            '
        End If
        '
        ' Check for new objects, give them an ID, and put into the dB
        '
        With CType(e.DataRow.RowData, RSmartTextValue)
            If .IsNew AndAlso .ID.Equals(Guid.Empty) Then
                .ID = Guid.NewGuid
                .FK_Key = oSmarttextKey.ID
                '
            End If
            '
            ' The object should be updated regardless of its new or just editing status
            '
            .Update()
            '
        End With
        '
    End Sub
    '
End Class
