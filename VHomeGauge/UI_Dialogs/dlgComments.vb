'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
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
    ' *****     -PictureBox1_MouseUp(object, MouseEventArgs)
    ' ***********************************************
    '
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button <> MouseButtons.Left Then Return
        msImport.Show(PictureBox1, e.Location)
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -tsCatalog_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsCatalog_Click(sender As Object, e As EventArgs) Handles tsCatalog.Click
        '
        ' Get the template file
        '
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
            '
            ' Import Summary items first
            '
            With thePB
                .StartPosition = FormStartPosition.CenterParent
                .SetDoWorkClass(New HGICatalogImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Catalog"
                .AnnouncementVisible = True
                .RunningStatusVisible = True
                .OKButtonVisible = True
                .OKButtonText = "Cancel"
                .LaunchDoWork()
                .ShowDialog()
                '
            End With
        End If
    End Sub
    '
    ' ***********************************************
    ' *****     -tsComments_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsComments_Click(sender As Object, e As EventArgs) Handles tsComments.Click
        '
        ' It is important to import the Summary Sections befor the comments
        '
        If MsgBox("Did you import the Summary Sections?", MsgBoxStyle.YesNo, "Comment Import") = MsgBoxResult.No Then Return
        '
        ' Get template file
        '
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
            '
            ' Import the comments
            '
            thePB = New dlgVProgressBar
            With thePB
                .StartPosition = FormStartPosition.CenterParent
                .SetDoWorkClass(New HGICommentImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Comments"
                .AnnouncementVisible = True
                .RunningStatusVisible = True
                .OKButtonVisible = True
                .OKButtonText = "Cancel"
                .LaunchDoWork()
                .ShowDialog()
                '
            End With
        End If
    End Sub
    '
    ' ***********************************************
    ' *****     -tsSummarySections_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsSummarySections_Click(sender As Object, e As EventArgs) Handles tsSummarySections.Click
        '
        ' Get the template file
        '
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
            '
            ' Import Summary items first
            '
            With thePB
                .StartPosition = FormStartPosition.CenterParent
                .SetDoWorkClass(New HGISummaryImport(New FileInfo(OpenFileDialog1.FileName)))
                .Text = "Import Summary"
                .AnnouncementVisible = True
                .RunningStatusVisible = True
                .OKButtonVisible = True
                .OKButtonText = "Cancel"
                .LaunchDoWork()
                .ShowDialog()
                '
            End With
        End If
    End Sub
End Class
