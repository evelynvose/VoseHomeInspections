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
        ' Set up the tree view with the first level.
        ' Expand the nodes for just the first level.
        '
        Dim topCatalogItem As CatalogMaster
        topCatalogItem = CatalogMaster.Find("Catalog")
        If topCatalogItem IsNot Nothing Then
            Dim treenode As New TreeNodeAdv With {
                .Text = topCatalogItem.Name,
                .Tag = topCatalogItem,
                .ShowPlusMinus = True,
                .Expanded = True
            }
            tvCatalogTree.Nodes.Add(treenode)
            '
        Else
            tvCatalogTree.Nodes.Add("Place Holder")
            '
        End If
        '
        ' Add first level and expand
        '
        Dim topCatalogList As New CatalogMasters(Nothing)  ' Instantiating as Nothing loads the top node "Catalog"
        For Each catalogItem As CatalogMaster In topCatalogList.GetRepos
            Dim treeNode As New TreeNodeAdv(catalogItem.Name) With {
                .Text = catalogItem.Name,
                .Tag = catalogItem,
                .ShowPlusMinus = True,
                .Expanded = False
            }
            Dim i As Integer = tvCatalogTree.Nodes.Item(0).Nodes.Add(treeNode)
            tvCatalogTree.Nodes.Item(0).Nodes.Item(i).Nodes.Add(New TreeNodeAdv("..."))
            '
        Next
        '
        tvCatalogTree.Text = "Catalog"
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

    Private Sub tvCatalogTree_BeforeExpand(sender As Object, e As TreeViewAdvCancelableNodeEventArgs) Handles tvCatalogTree.BeforeExpand
        If TryCast(e.Node.Nodes.Item(0).Tag, CatalogMaster) Is Nothing Then ' must be triple dots
            '
            ' Remove this node
            '
            e.Node.Nodes.Clear()
            '
            ' Create a collection of CatalogMaster items from the parent
            '
            Dim newCatalogMasters As New CatalogMasters(TryCast(e.Node.Tag, CatalogMaster))
            For Each item As CatalogMaster In newCatalogMasters.GetRepos
                Dim node As New TreeNodeAdv With {
                    .Text = item.Name,
                    .Tag = item,
                    .ShowPlusMinus = True,
                    .Expanded = False
                }
                '
                Dim i As Integer = e.Node.Nodes.Add(node)
                e.Node.Nodes.Item(i).Nodes.Add(New TreeNodeAdv("..."))
                '
            Next
            '
        End If
    End Sub
End Class
