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
    Private Enum TVIcons
        Folders = 0
        ClosedFolder
        OpenFolder
        Comment
        '
    End Enum
    '
    Private Sub dlgSmartText_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        ' The image list contains the icons for the tree
        '   0 - Folders
        '   1 - Closed Folder
        '   2 - Open folder
        '   3 - Notebook (comment/DDID)
        '
        tvCatalogTree.LeftImageList = tvImageList
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
                .Expanded = True,
                .LeftImageIndices = New Integer() {TVIcons.Folders}
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
                .Expanded = False,
                .LeftImageIndices = New Integer() {TVIcons.ClosedFolder}
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
    '
    ' ***********************************************
    ' *****     -tvCatalogTree_BeforeExpand(object, TreeViewAdvCancelableNodeEventArgs)
    ' ***********************************************
    '
    Private Sub tvCatalogTree_BeforeExpand(sender As Object, e As TreeViewAdvCancelableNodeEventArgs) Handles tvCatalogTree.BeforeExpand
        '
        ' There are three conditions possible prior to expanding:
        '   1) The one child is a token, in which case we remove the token, load from the dB, and expand.
        '   2) The one child is a Catalog Item or RComment, in which case we just go ahead and expand (no dB load).
        '   3) There are many children, so just expand (no dB load).
        '
        If e.Node.Nodes.Count = 0 Then  ' This should never happen!
            e.Cancel = True
            Return
            '
        End If
        '
        ' Case 3
        '
        If e.Node.Nodes.Count > 1 Then Return
        '
        ' Cases 1 and 2, Just one node so what is it?
        '
        If e.Node.Nodes.Item(0).Tag IsNot Nothing Then Return  ' Case 2
        '
        ' By process of elimination, the node has to be a token.
        '
        e.Node.Nodes.Clear()
        '
        ' Ok - if we made it here we can go ahead and load from the dB
        '
        Cursor = Cursors.WaitCursor
        Try
            '
            ' Create a collection of CatalogMaster items from the parent
            '
            Dim newCatalogMasters As New CatalogMasters(TryCast(e.Node.Tag, CatalogMaster))
            For Each item As CatalogMaster In newCatalogMasters.GetRepos
                Dim node As New TreeNodeAdv With {
                        .Text = item.Name,
                        .Tag = item,
                        .ShowPlusMinus = True,
                        .Expanded = False,
                        .LeftImageIndices = New Integer() {TVIcons.ClosedFolder}
                }
                '
                Dim i As Integer = e.Node.Nodes.Add(node)
                e.Node.Nodes.Item(i).Nodes.Add(New TreeNodeAdv("..."))
                '
            Next
            '
            ' Create a collection of RComments items from the parent
            '
            Dim newComments As New RComments
            For Each item As RComment In newComments.GetRepos(TryCast(e.Node.Tag, CatalogMaster))
                Dim node As New TreeNodeAdv With {
                        .Text = item.Name,
                        .Tag = item,
                        .ShowPlusMinus = True,
                        .Expanded = False,
                        .LeftImageIndices = New Integer() {TVIcons.Comment}
                }
                '
                e.Node.Nodes.Add(node)
                '
            Next
            '
        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
            '
        Finally
            Cursor = Cursors.Default
            '
        End Try

    End Sub
    '
    ' ***********************************************
    ' *****     -tvCatalogTree_Click(object, TreeViewAdvCancelableNodeEventArgs)
    ' ***********************************************
    '
    'Private Sub tvCatalogTree_Click(sender As Object, e As EventArgs) Handles tvCatalogTree.Click
    '    '
    '    '  Error checking and other conditions where we abort this method
    '    '
    '    Dim node As TreeNodeAdv = tvCatalogTree.SelectedNode
    '    If node Is Nothing Then Return
    '    If TypeOf node.Tag IsNot RComment Then Return
    '    '
    '    ' Load the comment object and set the text
    '    '
    '    Try
    '        Cursor = Cursors.WaitCursor
    '        Dim theComment As RComment
    '        theComment = TryCast(node.Tag, RComment)
    '        If theComment Is Nothing Then Return
    '        rtCommentEditor.Text = theComment.Text
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.Message,, "Error")
    '        '
    '    Finally
    '        Cursor = Cursors.Default
    '        '
    '    End Try
    '    '
    'End Sub

    Private Sub tvCatalogTree_AfterSelect(sender As Object, e As EventArgs) Handles tvCatalogTree.AfterSelect
        '
        '  Error checking and other conditions where we abort this method
        '
        Dim node As TreeNodeAdv = tvCatalogTree.SelectedNode
        If node Is Nothing Then Return
        If TypeOf node.Tag IsNot RComment Then Return
        '
        ' Load the comment object and set the text
        '
        Try
            Cursor = Cursors.WaitCursor
            Dim theComment As RComment
            theComment = TryCast(node.Tag, RComment)
            If theComment Is Nothing Then Return
            rtCommentEditor.Text = theComment.Text
            '
        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
            '
        Finally
            Cursor = Cursors.Default
            '
        End Try
    End Sub



    '
End Class
