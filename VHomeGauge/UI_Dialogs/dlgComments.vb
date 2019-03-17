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
Public Class dlgComments
    Inherits MetroForm
    '
    ' **********************************************
    ' ****
    ' ******    LOAD
    ' ****
    ' **********************************************
    '
    Private m_Comments As New RComments
    '
    Private Sub dlgSmartText_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        ' Load the grid.
        '
        sfdgComments.DataSource = m_Comments.GetRepos
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
    ' *****     -btnGear_Click(object, EventArgs)
    ' ***********************************************
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
                .SetDoWorkClass(New HGICommentImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Comments"
                .AnnouncementVisible = False
                .RunningStatusVisible = True
                .OKButtonVisible = False
                .LaunchDoWork()
                .ShowDialog()
                '
            End With
        End If
    End Sub


End Class
