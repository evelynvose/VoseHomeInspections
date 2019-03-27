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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgComments))
        Me.scOkCancel = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scInstructions = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.txtComments = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCategories = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtInstructions = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.scTree = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.tvCatalogTree = New Syncfusion.Windows.Forms.Tools.TreeViewAdv()
        Me.lblWhereUsed = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.scWhereUsed = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.lblAttachments = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.scAttachments = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scCommentGrid = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.txtAdvanced = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtWhereUsed = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.msImport = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.tsCatalog = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsComments = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSummarySections = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.rtCommentEditor = New System.Windows.Forms.RichTextBox()
        Me.tvImageList = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        CType(Me.scOkCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scOkCancel.Panel1.SuspendLayout()
        Me.scOkCancel.Panel2.SuspendLayout()
        Me.scOkCancel.SuspendLayout()
        CType(Me.scInstructions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scInstructions.Panel1.SuspendLayout()
        Me.scInstructions.Panel2.SuspendLayout()
        Me.scInstructions.SuspendLayout()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstructions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scTree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scTree.Panel1.SuspendLayout()
        Me.scTree.Panel2.SuspendLayout()
        Me.scTree.SuspendLayout()
        CType(Me.tvCatalogTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scWhereUsed.Panel1.SuspendLayout()
        Me.scWhereUsed.Panel2.SuspendLayout()
        Me.scWhereUsed.SuspendLayout()
        CType(Me.scAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scAttachments.Panel1.SuspendLayout()
        Me.scAttachments.Panel2.SuspendLayout()
        Me.scAttachments.SuspendLayout()
        CType(Me.scCommentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scCommentGrid.Panel2.SuspendLayout()
        Me.scCommentGrid.SuspendLayout()
        CType(Me.txtAdvanced, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'scOkCancel
        '
        Me.scOkCancel.BeforeTouchSize = 7
        Me.scOkCancel.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.scOkCancel.Panel2.Controls.Add(Me.PictureBox1)
        Me.scOkCancel.Panel2.Controls.Add(Me.btnOK)
        Me.scOkCancel.Panel2.Controls.Add(Me.btnCancel)
        Me.scOkCancel.Size = New System.Drawing.Size(990, 604)
        Me.scOkCancel.SplitterDistance = 550
        Me.scOkCancel.TabIndex = 0
        '
        'scInstructions
        '
        Me.scInstructions.BeforeTouchSize = 7
        Me.scInstructions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scInstructions.Location = New System.Drawing.Point(0, 0)
        Me.scInstructions.Name = "scInstructions"
        Me.scInstructions.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scInstructions.Panel1
        '
        Me.scInstructions.Panel1.Controls.Add(Me.txtComments)
        Me.scInstructions.Panel1.Controls.Add(Me.txtCategories)
        Me.scInstructions.Panel1.Controls.Add(Me.txtInstructions)
        '
        'scInstructions.Panel2
        '
        Me.scInstructions.Panel2.Controls.Add(Me.scTree)
        Me.scInstructions.Size = New System.Drawing.Size(990, 550)
        Me.scInstructions.SplitterDistance = 44
        Me.scInstructions.TabIndex = 0
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BeforeTouchSize = New System.Drawing.Size(739, 50)
        Me.txtComments.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtComments.Location = New System.Drawing.Point(218, 25)
        Me.txtComments.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(521, 17)
        Me.txtComments.TabIndex = 2
        Me.txtComments.Text = "Comments - Use the list at the left side to select and edit the comment below."
        '
        'txtCategories
        '
        Me.txtCategories.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCategories.BeforeTouchSize = New System.Drawing.Size(739, 50)
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
        Me.txtInstructions.BeforeTouchSize = New System.Drawing.Size(739, 50)
        Me.txtInstructions.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInstructions.Location = New System.Drawing.Point(4, 7)
        Me.txtInstructions.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(720, 15)
        Me.txtInstructions.TabIndex = 0
        Me.txtInstructions.Text = "List of All commentsin the template."
        '
        'scTree
        '
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
        Me.scTree.Panel2.Controls.Add(Me.lblWhereUsed)
        Me.scTree.Panel2.Controls.Add(Me.scWhereUsed)
        Me.scTree.Size = New System.Drawing.Size(990, 499)
        Me.scTree.SplitterDistance = 244
        Me.scTree.TabIndex = 0
        '
        'tvCatalogTree
        '
        TreeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = True
        TreeNodeAdvStyleInfo1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.tvCatalogTree.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText
        Me.tvCatalogTree.Size = New System.Drawing.Size(244, 499)
        Me.tvCatalogTree.TabIndex = 0
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
        'lblWhereUsed
        '
        Me.lblWhereUsed.Location = New System.Drawing.Point(0, 429)
        Me.lblWhereUsed.Name = "lblWhereUsed"
        Me.lblWhereUsed.Size = New System.Drawing.Size(152, 13)
        Me.lblWhereUsed.TabIndex = 1
        Me.lblWhereUsed.Text = "Where this comment is used"
        '
        'scWhereUsed
        '
        Me.scWhereUsed.BeforeTouchSize = 25
        Me.scWhereUsed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scWhereUsed.Location = New System.Drawing.Point(0, 0)
        Me.scWhereUsed.Name = "scWhereUsed"
        Me.scWhereUsed.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scWhereUsed.Panel1
        '
        Me.scWhereUsed.Panel1.Controls.Add(Me.lblAttachments)
        Me.scWhereUsed.Panel1.Controls.Add(Me.scAttachments)
        '
        'scWhereUsed.Panel2
        '
        Me.scWhereUsed.Panel2.Controls.Add(Me.txtWhereUsed)
        Me.scWhereUsed.Size = New System.Drawing.Size(739, 499)
        Me.scWhereUsed.SplitterDistance = 423
        Me.scWhereUsed.SplitterWidth = 25
        Me.scWhereUsed.TabIndex = 0
        '
        'lblAttachments
        '
        Me.lblAttachments.Location = New System.Drawing.Point(-1, 354)
        Me.lblAttachments.Name = "lblAttachments"
        Me.lblAttachments.Size = New System.Drawing.Size(304, 13)
        Me.lblAttachments.TabIndex = 1
        Me.lblAttachments.Text = "Attachments/Pictures automatically used for this comment"
        '
        'scAttachments
        '
        Me.scAttachments.BeforeTouchSize = 25
        Me.scAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scAttachments.Location = New System.Drawing.Point(0, 0)
        Me.scAttachments.Name = "scAttachments"
        Me.scAttachments.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scAttachments.Panel1
        '
        Me.scAttachments.Panel1.Controls.Add(Me.scCommentGrid)
        '
        'scAttachments.Panel2
        '
        Me.scAttachments.Panel2.Controls.Add(Me.txtAdvanced)
        Me.scAttachments.Size = New System.Drawing.Size(739, 423)
        Me.scAttachments.SplitterDistance = 348
        Me.scAttachments.SplitterWidth = 25
        Me.scAttachments.TabIndex = 0
        '
        'scCommentGrid
        '
        Me.scCommentGrid.BeforeTouchSize = 7
        Me.scCommentGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scCommentGrid.Location = New System.Drawing.Point(0, 0)
        Me.scCommentGrid.Name = "scCommentGrid"
        Me.scCommentGrid.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scCommentGrid.Panel2
        '
        Me.scCommentGrid.Panel2.Controls.Add(Me.rtCommentEditor)
        Me.scCommentGrid.Size = New System.Drawing.Size(739, 348)
        Me.scCommentGrid.SplitterDistance = 29
        Me.scCommentGrid.TabIndex = 0
        '
        'txtAdvanced
        '
        Me.txtAdvanced.BeforeTouchSize = New System.Drawing.Size(739, 50)
        Me.txtAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.txtAdvanced.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdvanced.Multiline = True
        Me.txtAdvanced.Name = "txtAdvanced"
        Me.txtAdvanced.Size = New System.Drawing.Size(739, 50)
        Me.txtAdvanced.TabIndex = 0
        '
        'txtWhereUsed
        '
        Me.txtWhereUsed.BeforeTouchSize = New System.Drawing.Size(739, 50)
        Me.txtWhereUsed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWhereUsed.Location = New System.Drawing.Point(0, 0)
        Me.txtWhereUsed.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWhereUsed.Multiline = True
        Me.txtWhereUsed.Name = "txtWhereUsed"
        Me.txtWhereUsed.Size = New System.Drawing.Size(739, 51)
        Me.txtWhereUsed.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.ContextMenuStrip = Me.msImport
        Me.PictureBox1.Image = Global.SyncfusionWindowsFormsApplication1.My.Resources.Resources.gear1
        Me.PictureBox1.Location = New System.Drawing.Point(678, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'msImport
        '
        Me.msImport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCatalog, Me.tsComments, Me.tsSummarySections})
        Me.msImport.MetroColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.msImport.Name = "ContextMenuStripEx1"
        Me.msImport.Size = New System.Drawing.Size(173, 97)
        Me.msImport.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.[Default]
        Me.msImport.Text = "Import"
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
        'btnOK
        '
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(217, 14)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnCancel.IsBackStageButton = False
        Me.btnCancel.Location = New System.Drawing.Point(331, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'rtCommentEditor
        '
        Me.rtCommentEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtCommentEditor.Location = New System.Drawing.Point(0, 0)
        Me.rtCommentEditor.Name = "rtCommentEditor"
        Me.rtCommentEditor.Size = New System.Drawing.Size(739, 312)
        Me.rtCommentEditor.TabIndex = 0
        Me.rtCommentEditor.Text = ""
        '
        'tvImageList
        '
        Me.tvImageList.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("tvImageList.Images"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images1"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images2"), System.Drawing.Image), CType(resources.GetObject("tvImageList.Images3"), System.Drawing.Image)})
        '
        'dlgComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionButtonHoverColor = System.Drawing.Color.Red
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(990, 604)
        Me.Controls.Add(Me.scOkCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
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
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategories, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstructions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTree.Panel1.ResumeLayout(False)
        Me.scTree.Panel2.ResumeLayout(False)
        Me.scTree.Panel2.PerformLayout()
        CType(Me.scTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTree.ResumeLayout(False)
        CType(Me.tvCatalogTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scWhereUsed.Panel1.ResumeLayout(False)
        Me.scWhereUsed.Panel1.PerformLayout()
        Me.scWhereUsed.Panel2.ResumeLayout(False)
        Me.scWhereUsed.Panel2.PerformLayout()
        CType(Me.scWhereUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scWhereUsed.ResumeLayout(False)
        Me.scAttachments.Panel1.ResumeLayout(False)
        Me.scAttachments.Panel2.ResumeLayout(False)
        Me.scAttachments.Panel2.PerformLayout()
        CType(Me.scAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scAttachments.ResumeLayout(False)
        Me.scCommentGrid.Panel2.ResumeLayout(False)
        CType(Me.scCommentGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scCommentGrid.ResumeLayout(False)
        CType(Me.txtAdvanced, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWhereUsed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msImport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scOkCancel As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scInstructions As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents txtComments As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCategories As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtInstructions As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scTree As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents tvCatalogTree As Syncfusion.Windows.Forms.Tools.TreeViewAdv
    Friend WithEvents lblWhereUsed As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents scWhereUsed As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scAttachments As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents txtWhereUsed As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scCommentGrid As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCancel As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblAttachments As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents txtAdvanced As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents msImport As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Friend WithEvents tsCatalog As ToolStripMenuItem
    Friend WithEvents tsComments As ToolStripMenuItem
    Friend WithEvents tsSummarySections As ToolStripMenuItem
    Friend WithEvents rtCommentEditor As RichTextBox
    Friend WithEvents tvImageList As Syncfusion.Windows.Forms.Tools.ImageListAdv
End Class
