'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Controls.RichTextBoxAdv
Imports System.IO
Imports System.ComponentModel
'
' This form handles the UI for the Smart Text interface.
'
Public Class dlgComments
    Inherits MetroForm
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
    '
    ' **********************************************
    ' ****
    ' ******    LOAD
    ' ****
    ' **********************************************
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
        LoadTheTree()
        '
        ' tvCatalogTree.Text = "Catalog"
        '
        btnCommentSave.Enabled = False
        ' btnCommentSave.Image = dlgImageList.Images(0)
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     -LoadTheTree()
    ' ***********************************************
    '
    Private Sub LoadTheTree()
        Cursor = Cursors.WaitCursor
        tvCatalogTree.Nodes.Clear()
        '
        ' Set up the tree view with the first level.
        ' Expand the nodes for just the first level.
        '
        Try
            Dim topCatalogItem As CatalogMaster
            topCatalogItem = CatalogMaster.Find("Catalog")
            If topCatalogItem Is Nothing Then
                topCatalogItem = New CatalogMaster()
                With topCatalogItem
                    .ID = New VGuid("CAT", Guid.NewGuid())
                    .Name = "Catalog"
                    .FK_Parent = .ID
                    .Message = "Catalog"
                    .Update()
                End With
            End If
            '
            Dim treenode As New TreeNodeAdv With {
                .Text = topCatalogItem.Name,
                .Tag = topCatalogItem,
                .ShowPlusMinus = True,
                .Expanded = True,
                .LeftImageIndices = New Integer() {TVIcons.Folders}
            }
            tvCatalogTree.Nodes.Add(treenode)
            '
            ' Add first level and expand
            '
            Dim topCatalogList As New CatalogMasters(Nothing)  ' Instantiating as Nothing loads the top node "Catalog"
            For Each catalogItem As CatalogMaster In topCatalogList.GetRepos
                If catalogItem.Name <> topCatalogItem.Name Then
                    treenode = New TreeNodeAdv(catalogItem.Name) With {
                    .Text = catalogItem.Name,
                    .Tag = catalogItem,
                    .ShowPlusMinus = True,
                    .Expanded = False,
                    .LeftImageIndices = New Integer() {TVIcons.ClosedFolder}
                    }
                    Dim i As Integer = tvCatalogTree.Nodes.Item(0).Nodes.Add(treenode)
                    tvCatalogTree.Nodes.Item(0).Nodes.Item(i).Nodes.Add(New TreeNodeAdv("..."))
                    '
                End If
            Next
        Catch ex As Exception
            ' Do nothing
            '
        Finally
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -Import_Summary(FileInfo)
    ' ***********************************************
    '
    Private Sub Import_Summary(ByVal theFile As FileInfo)
        If theFile Is Nothing Then Return
        '
        Dim thePB As New dlgVProgressBar
        '
        ' Import Summary items first
        '
        With thePB
            .StartPosition = FormStartPosition.CenterParent
            .SetDoWorkClass(New HGISummaryImport(theFile))
            .Text = "Import Summary"
            .AnnouncementVisible = True
            .RunningStatusVisible = True
            .OKButtonVisible = True
            .OKButtonText = "Cancel"
            .LaunchDoWork()
            .ShowDialog()
            '
        End With
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -Import_Comments(FileInfo)
    ' ***********************************************
    '
    Private Sub Import_Comments(ByVal theFile As FileInfo)
        If theFile Is Nothing Then Return
        '
        Dim thePB As New dlgVProgressBar
        '
        ' Import the comments
        '
        thePB = New dlgVProgressBar
        With thePB
            .StartPosition = FormStartPosition.CenterParent
            .SetDoWorkClass(New HGICommentImport(theFile))
            .Text = "Import Comments"
            .AnnouncementVisible = True
            .RunningStatusVisible = True
            .OKButtonVisible = True
            .OKButtonText = "Cancel"
            .LaunchDoWork()
            .ShowDialog()
            '
        End With
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -Import_CatalogTitles(FileInfo)
    ' ***********************************************
    '
    Private Sub Import_CatalogTitles(ByVal theFile As FileInfo)
        If theFile Is Nothing Then Return
        '
        ' Set up the worker thread and launch the progress bar
        '

        Dim thePB As New dlgVProgressBar
        ' 
        ' Import Summary items first
        '
        With thePB
            .StartPosition = FormStartPosition.CenterParent
            .SetDoWorkClass(New HGICatalogImport(theFile))
            .Text = "Import Catalog"
            .AnnouncementVisible = True
            .RunningStatusVisible = True
            .OKButtonVisible = True
            .OKButtonText = "Cancel"
            .LaunchDoWork()
            .ShowDialog()
            '
        End With

    End Sub
    '
    ' ***********************************************
    ' *****     -Import_CatalogTitles()
    ' ***********************************************
    '
    Private Function GetTemplateFile() As FileInfo
        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "ht5",
            .FileName = "",
            .Filter = "Template Files (*.ht5)|*.ht5|All Files (*.*)|*.*",
            .Multiselect = False
        }
        '
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Return New FileInfo(OpenFileDialog1.FileName)
        End If
        '
        Return Nothing
    End Function
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
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
        ' Ask the user if s/he wants to save the m_MessageWIP?
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
        Import_CatalogTitles(GetTemplateFile())
        '
        LoadTheTree()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -tsComments_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsComments_Click(sender As Object, e As EventArgs) Handles tsComments.Click
        '
        ' Ask the user if s/he wants to save the m_MessageWIP?
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
        ' It is important to import the Summary Sections befor the comments
        '
        If MsgBox("Did you import the Summary Sections?", MsgBoxStyle.YesNo, "Comment Import") = MsgBoxResult.No Then Return
        '
        Import_Comments(GetTemplateFile())
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -tsSummarySections_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsSummarySections_Click(sender As Object, e As EventArgs) Handles tsSummarySections.Click
        '
        ' Ask the user if s/he wants to save the m_MessageWIP?
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
        Import_Summary(GetTemplateFile())
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -tsImportAll_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub tsImportAll_Click(sender As Object, e As EventArgs) Handles tsImportAll.Click
        '
        ' Ask the user if s/he wants to save the m_MessageWIP?
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
        ' Import a spreadsheet in order of importance
        Dim thefile As FileInfo = GetTemplateFile()
        Import_Summary(thefile)
        Import_Comments(thefile)
        Import_CatalogTitles(thefile)
        '
        LoadTheTree()
        '
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
    ' *****     -tvCatalogTree_AfterSelect(object, EventArgs)
    ' ***********************************************
    '
    Private m_CommentWIP As RComment
    '
    Private Sub tvCatalogTree_AfterSelect(sender As Object, e As EventArgs) Handles tvCatalogTree.AfterSelect
        '
        '  Error checking and other conditions where we abort this method
        '
        Dim node As TreeNodeAdv = tvCatalogTree.SelectedNode
        If node Is Nothing Then Return
        If TypeOf node.Tag IsNot RComment Then Return
        '
        ' If the m_CommentWIP object is instantiated and Dirty, given User a chance to update the object!
        '
        If m_CommentWIP IsNot Nothing AndAlso m_CommentWIP.Dirty Then
            btnCommentSave_Click(Nothing, Nothing)
            '
        End If
        '
        ' Load the comment object and set the text
        '
        Cursor = Cursors.WaitCursor
        Try
            btnCommentSave.Enabled = False
            m_CommentWIP = Nothing
            m_CommentWIP = TryCast(node.Tag, RComment)
            If m_CommentWIP Is Nothing Then Exit Sub
            '
            VRichTextBoxExt1.Text = m_CommentWIP.Text
            VRichTextBoxExt1.Title = m_CommentWIP.Name

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
    ' *****     -btnCommentSave_Click(object, EventArgs)
    ' ***********************************************
    '
    ' Make changes to this method cautiously as there are many methods in this class that
    ' are dependent on its behavior!
    '
    Private Sub btnCommentSave_Click(sender As Object, e As EventArgs) Handles btnCommentSave.Click
        If m_CommentWIP Is Nothing Then Return
        If Not m_CommentWIP.Dirty Then Return
        '
        If MsgBox("Do you want to save?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Return
        '
        ' Update and report back
        '
        Dim sMessage As String = "Sucessfully saved!"
        Cursor = Cursors.WaitCursor
        Try
            m_CommentWIP.Update()
            If m_CommentWIP.Dirty Then
                sMessage = "Oops! Something went wrong. Not saved."
                '
            End If          '
        Catch ex As Exception
            sMessage = ex.Message
            '
        End Try
        '
        Cursor = Cursors.Default
        btnCommentSave.Enabled = m_CommentWIP.Dirty
        MsgBox(sMessage, MsgBoxStyle.OkOnly, "")
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -VRichTextBoxExt1_ContentChanged(object, EventArgs)
    ' ***********************************************
    '
    Private Sub VRichTextBoxExt1_ContentChanged(sender As Object, e As EventArgs) Handles VRichTextBoxExt1.ContentChanged
        If m_CommentWIP Is Nothing Then Return
        '
        ' Capture the changes (if any)
        '
        m_CommentWIP.Name = VRichTextBoxExt1.Title
        m_CommentWIP.Text = VRichTextBoxExt1.Text
        btnCommentSave.Enabled = m_CommentWIP.Dirty
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -TestToolStripMenuItem_Click(object, EventArgs)
    ' ***********************************************
    '
    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        '
        ' Ask the user if s/he wants to save the m_MessageWIP?
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
        ' Setting the text to Nothing will cause the VRichTextBox to display Greek text
        '
        VRichTextBoxExt1.Text = Nothing
        '
    End Sub
    ' 
    ' ***********************************************
    ' *****     -dlgComments_Closing(object, EventArgs)
    ' ***********************************************
    '
    Private Sub dlgComments_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '
        ' Check the m_MessageWIP object and see if the user wants it saved.
        '
        btnCommentSave_Click(Nothing, Nothing)
        '
    End Sub
    '
End Class
