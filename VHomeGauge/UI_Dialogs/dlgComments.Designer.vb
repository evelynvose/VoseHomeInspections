<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgComments
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNodeAdvStyleInfo1 As Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo = New Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo()
        Dim TreeNodeAdv1 As Syncfusion.Windows.Forms.Tools.TreeNodeAdv = New Syncfusion.Windows.Forms.Tools.TreeNodeAdv()
        Dim TreeNodeAdv2 As Syncfusion.Windows.Forms.Tools.TreeNodeAdv = New Syncfusion.Windows.Forms.Tools.TreeNodeAdv()
        Dim TreeNodeAdv3 As Syncfusion.Windows.Forms.Tools.TreeNodeAdv = New Syncfusion.Windows.Forms.Tools.TreeNodeAdv()
        Dim TreeViewAdvVisualStyle1 As Syncfusion.Windows.Forms.Tools.TreeViewAdvVisualStyle = New Syncfusion.Windows.Forms.Tools.TreeViewAdvVisualStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgComments))
        Me.scOkCancel = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scInstructions = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.txtCategories = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtInstructions = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.scTree = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.tvCatalogTree = New Syncfusion.Windows.Forms.Tools.TreeViewAdv()
        Me.VRichTextBoxExt1 = New WindowsControlLibrary1.vRichTextBoxExt()
        Me.btnCommentSave = New Syncfusion.WinForms.Controls.SfButton()
        Me.dlgImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.msImport = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.tsCatalog = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsComments = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSummarySections = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsImportAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.tvImageList = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        CType(Me.scOkCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scOkCancel.Panel1.SuspendLayout()
        Me.scOkCancel.Panel2.SuspendLayout()
        Me.scOkCancel.SuspendLayout()
        CType(Me.scInstructions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scInstructions.Panel1.SuspendLayout()
        Me.scInstructions.Panel2.SuspendLayout()
        Me.scInstructions.SuspendLayout()
        CType(Me.txtCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstructions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scTree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scTree.Panel1.SuspendLayout()
        Me.scTree.Panel2.SuspendLayout()
        Me.scTree.SuspendLayout()
        CType(Me.tvCatalogTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'scOkCancel
        '
        Me.scOkCancel.BeforeTouchSize = 7
        Me.scOkCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scOkCancel.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel2
        Me.scOkCancel.IsSplitterFixed = True
        Me.scOkCancel.Location = New System.Drawing.Point(0, 0)
        Me.scOkCancel.Name = "scOkCancel"
        Me.scOkCancel.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scOkCancel.Panel1
        '
        Me.scOkCancel.Panel1.Controls.Add(Me.scInstructions)
        '
        'scOkCancel.Panel2
        '
        Me.scOkCancel.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scOkCancel.Panel2.Controls.Add(Me.btnCommentSave)
        Me.scOkCancel.Panel2.Controls.Add(Me.PictureBox1)
        Me.scOkCancel.Panel2.Controls.Add(Me.btnOK)
        Me.scOkCancel.Size = New System.Drawing.Size(990, 604)
        Me.scOkCancel.SplitterDistance = 550
        Me.scOkCancel.TabIndex = 0
        Me.scOkCancel.ThemeName = "None"
        '
        'scInstructions
        '
        Me.scInstructions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scInstructions.BeforeTouchSize = 7
        Me.scInstructions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scInstructions.IsSplitterFixed = True
        Me.scInstructions.Location = New System.Drawing.Point(0, 0)
        Me.scInstructions.Name = "scInstructions"
        Me.scInstructions.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scInstructions.Panel1
        '
        Me.scInstructions.Panel1.Controls.Add(Me.txtCategories)
        Me.scInstructions.Panel1.Controls.Add(Me.txtInstructions)
        '
        'scInstructions.Panel2
        '
        Me.scInstructions.Panel2.Controls.Add(Me.scTree)
        Me.scInstructions.Size = New System.Drawing.Size(990, 550)
        Me.scInstructions.SplitterDistance = 44
        Me.scInstructions.TabIndex = 0
        Me.scInstructions.ThemeName = "None"
        '
        'txtCategories
        '
        Me.txtCategories.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCategories.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCategories.BeforeTouchSize = New System.Drawing.Size(214, 15)
        Me.txtCategories.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtCategories.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCategories.Location = New System.Drawing.Point(2, 25)
        Me.txtCategories.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCategories.Multiline = True
        Me.txtCategories.Name = "txtCategories"
        Me.txtCategories.Size = New System.Drawing.Size(190, 17)
        Me.txtCategories.TabIndex = 1
        Me.txtCategories.Text = "Comment Categories"
        '
        'txtInstructions
        '
        Me.txtInstructions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtInstructions.BeforeTouchSize = New System.Drawing.Size(214, 15)
        Me.txtInstructions.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInstructions.Location = New System.Drawing.Point(4, 7)
        Me.txtInstructions.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(214, 15)
        Me.txtInstructions.TabIndex = 0
        Me.txtInstructions.Text = "List of All comments in the template."
        '
        'scTree
        '
        Me.scTree.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scTree.BeforeTouchSize = 7
        Me.scTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scTree.Location = New System.Drawing.Point(0, 0)
        Me.scTree.Name = "scTree"
        '
        'scTree.Panel1
        '
        Me.scTree.Panel1.Controls.Add(Me.tvCatalogTree)
        '
        'scTree.Panel2
        '
        Me.scTree.Panel2.Controls.Add(Me.VRichTextBoxExt1)
        Me.scTree.Size = New System.Drawing.Size(990, 499)
        Me.scTree.SplitterDistance = 244
        Me.scTree.TabIndex = 0
        Me.scTree.ThemeName = "None"
        '
        'tvCatalogTree
        '
        Me.tvCatalogTree.AccelerateScrolling = Syncfusion.Windows.Forms.AccelerateScrollingBehavior.Immediate
        TreeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = True
        TreeNodeAdvStyleInfo1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.tvCatalogTree.BaseStylePairs.AddRange(New Syncfusion.Windows.Forms.Tools.StyleNamePair() {New Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", TreeNodeAdvStyleInfo1)})
        Me.tvCatalogTree.BeforeTouchSize = New System.Drawing.Size(244, 499)
        Me.tvCatalogTree.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.tvCatalogTree.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCatalogTree.HelpTextControl.Location = New System.Drawing.Point(0, 0)
        Me.tvCatalogTree.HelpTextControl.Name = "helpText"
        Me.tvCatalogTree.HelpTextControl.Size = New System.Drawing.Size(49, 15)
        Me.tvCatalogTree.HelpTextControl.TabIndex = 0
        Me.tvCatalogTree.HelpTextControl.Text = "help text"
        Me.tvCatalogTree.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText
        Me.tvCatalogTree.Location = New System.Drawing.Point(0, 0)
        Me.tvCatalogTree.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tvCatalogTree.Name = "tvCatalogTree"
        TreeNodeAdv1.ChildStyle.CheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv1.ChildStyle.EnsureDefaultOptionedChild = True
        TreeNodeAdv1.ChildStyle.IntermediateCheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv1.ChildStyle.OptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv1.ChildStyle.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        TreeNodeAdv1.EnsureDefaultOptionedChild = True
        TreeNodeAdv1.Expanded = True
        TreeNodeAdv1.MultiLine = True
        TreeNodeAdv2.ChildStyle.CheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv2.ChildStyle.EnsureDefaultOptionedChild = True
        TreeNodeAdv2.ChildStyle.IntermediateCheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv2.ChildStyle.OptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv2.ChildStyle.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        TreeNodeAdv2.EnsureDefaultOptionedChild = True
        TreeNodeAdv2.Expanded = True
        TreeNodeAdv2.MultiLine = True
        TreeNodeAdv2.Optioned = True
        TreeNodeAdv2.ShowLine = True
        TreeNodeAdv2.Text = "Item 1"
        TreeNodeAdv3.ChildStyle.CheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv3.ChildStyle.EnsureDefaultOptionedChild = True
        TreeNodeAdv3.ChildStyle.IntermediateCheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv3.ChildStyle.OptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeNodeAdv3.ChildStyle.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        TreeNodeAdv3.EnsureDefaultOptionedChild = True
        TreeNodeAdv3.MultiLine = True
        TreeNodeAdv3.ShowLine = True
        TreeNodeAdv3.Text = "Item 2"
        TreeNodeAdv1.Nodes.AddRange(New Syncfusion.Windows.Forms.Tools.TreeNodeAdv() {TreeNodeAdv2, TreeNodeAdv3})
        TreeNodeAdv1.ShowLine = True
        TreeNodeAdv1.Text = "Catalog"
        Me.tvCatalogTree.Nodes.AddRange(New Syncfusion.Windows.Forms.Tools.TreeNodeAdv() {TreeNodeAdv1})
        Me.tvCatalogTree.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText
        Me.tvCatalogTree.Size = New System.Drawing.Size(244, 499)
        Me.tvCatalogTree.TabIndex = 0
        TreeViewAdvVisualStyle1.LineColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        TreeViewAdvVisualStyle1.TreeNodeAdvStyle.CheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeViewAdvVisualStyle1.TreeNodeAdvStyle.EnsureDefaultOptionedChild = True
        TreeViewAdvVisualStyle1.TreeNodeAdvStyle.IntermediateCheckColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeViewAdvVisualStyle1.TreeNodeAdvStyle.OptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        TreeViewAdvVisualStyle1.TreeNodeAdvStyle.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.tvCatalogTree.ThemeStyle = TreeViewAdvVisualStyle1
        '
        '
        '
        Me.tvCatalogTree.ToolTipControl.BackColor = System.Drawing.SystemColors.Info
        Me.tvCatalogTree.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCatalogTree.ToolTipControl.Location = New System.Drawing.Point(0, 0)
        Me.tvCatalogTree.ToolTipControl.Name = "toolTip"
        Me.tvCatalogTree.ToolTipControl.Size = New System.Drawing.Size(41, 15)
        Me.tvCatalogTree.ToolTipControl.TabIndex = 1
        Me.tvCatalogTree.ToolTipControl.Text = "toolTip"
        '
        'VRichTextBoxExt1
        '
        Me.VRichTextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VRichTextBoxExt1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VRichTextBoxExt1.Location = New System.Drawing.Point(0, 0)
        Me.VRichTextBoxExt1.Name = "VRichTextBoxExt1"
        Me.VRichTextBoxExt1.Size = New System.Drawing.Size(739, 499)
        Me.VRichTextBoxExt1.TabIndex = 2
        Me.VRichTextBoxExt1.Title = ""
        '
        'btnCommentSave
        '
        Me.btnCommentSave.AccessibleName = "Button"
        Me.btnCommentSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCommentSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnCommentSave.Image = CType(resources.GetObject("btnCommentSave.Image"), System.Drawing.Image)
        Me.btnCommentSave.ImageKey = "disk.bmp"
        Me.btnCommentSave.ImageList = Me.dlgImageList
        Me.btnCommentSave.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnCommentSave.Location = New System.Drawing.Point(685, 14)
        Me.btnCommentSave.Name = "btnCommentSave"
        Me.btnCommentSave.Size = New System.Drawing.Size(114, 23)
        Me.btnCommentSave.TabIndex = 0
        Me.btnCommentSave.Text = "Save Comment"
        '
        'dlgImageList
        '
        Me.dlgImageList.ImageStream = CType(resources.GetObject("dlgImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.dlgImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.dlgImageList.Images.SetKeyName(0, "disk.bmp")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.msImport
        Me.PictureBox1.Image = Global.SyncfusionWindowsFormsApplication1.My.Resources.Resources.gear1
        Me.PictureBox1.Location = New System.Drawing.Point(921, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'msImport
        '
        Me.msImport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCatalog, Me.tsComments, Me.tsSummarySections, Me.tsImportAll, Me.TestToolStripMenuItem})
        Me.msImport.MetroColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.msImport.Name = "ContextMenuStripEx1"
        Me.msImport.Size = New System.Drawing.Size(173, 141)
        Me.msImport.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.[Default]
        Me.msImport.Text = "Import"
        Me.msImport.ThemeName = "Default"
        '
        'tsCatalog
        '
        Me.tsCatalog.Name = "tsCatalog"
        Me.tsCatalog.Size = New System.Drawing.Size(172, 22)
        Me.tsCatalog.Text = "Catalog"
        '
        'tsComments
        '
        Me.tsComments.Name = "tsComments"
        Me.tsComments.Size = New System.Drawing.Size(172, 22)
        Me.tsComments.Text = "Comments"
        '
        'tsSummarySections
        '
        Me.tsSummarySections.Name = "tsSummarySections"
        Me.tsSummarySections.Size = New System.Drawing.Size(172, 22)
        Me.tsSummarySections.Text = "Summary Sections"
        '
        'tsImportAll
        '
        Me.tsImportAll.Name = "tsImportAll"
        Me.tsImportAll.Size = New System.Drawing.Size(172, 22)
        Me.tsImportAll.Text = "All"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(824, 14)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "Close"
        '
        'tvImageList
        '
        Me.tvImageList.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("tvImageList.Images"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images1"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images2"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images3"), System.Drawing.Image)})
        '
        'dlgComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionButtonHoverColor = System.Drawing.Color.Red
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(990, 604)
        Me.Controls.Add(Me.scOkCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MetroColor = System.Drawing.SystemColors.ActiveCaption
        Me.MinimizeBox = False
        Me.Name = "dlgComments"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Comments"
        Me.scOkCancel.Panel1.ResumeLayout(False)
        Me.scOkCancel.Panel2.ResumeLayout(False)
        CType(Me.scOkCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scOkCancel.ResumeLayout(False)
        Me.scInstructions.Panel1.ResumeLayout(False)
        Me.scInstructions.Panel1.PerformLayout()
        Me.scInstructions.Panel2.ResumeLayout(False)
        CType(Me.scInstructions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scInstructions.ResumeLayout(False)
        CType(Me.txtCategories, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstructions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTree.Panel1.ResumeLayout(False)
        Me.scTree.Panel2.ResumeLayout(False)
        CType(Me.scTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTree.ResumeLayout(False)
        CType(Me.tvCatalogTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msImport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scOkCancel As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scInstructions As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents txtCategories As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtInstructions As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scTree As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents tvCatalogTree As Syncfusion.Windows.Forms.Tools.TreeViewAdv
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents msImport As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Friend WithEvents tsCatalog As ToolStripMenuItem
    Friend WithEvents tsComments As ToolStripMenuItem
    Friend WithEvents tsSummarySections As ToolStripMenuItem
    Friend WithEvents tvImageList As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCommentSave As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents tsImportAll As ToolStripMenuItem
    Friend WithEvents dlgImageList As ImageList
    Friend WithEvents VRichTextBoxExt1 As WindowsControlLibrary1.vRichTextBoxExt
End Class
