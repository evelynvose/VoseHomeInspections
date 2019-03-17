<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgComments
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNodeAdvStyleInfo1 As Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo = New Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo()
        Dim GridTextColumn1 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn2 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn3 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Me.scOkCancel = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scInstructions = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.txtComments = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCategories = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtInstructions = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.scTree = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.tvCommentCategories = New Syncfusion.Windows.Forms.Tools.TreeViewAdv()
        Me.lblWhereUsed = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.scWhereUsed = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.lblAttachments = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.scAttachments = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scCommentGrid = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.sfdgComments = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.txtAdvanced = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtWhereUsed = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnGear = New Syncfusion.Windows.Forms.ButtonAdv()
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
        CType(Me.tvCommentCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scWhereUsed.Panel1.SuspendLayout()
        Me.scWhereUsed.Panel2.SuspendLayout()
        Me.scWhereUsed.SuspendLayout()
        CType(Me.scAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scAttachments.Panel1.SuspendLayout()
        Me.scAttachments.Panel2.SuspendLayout()
        Me.scAttachments.SuspendLayout()
        CType(Me.scCommentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scCommentGrid.Panel1.SuspendLayout()
        Me.scCommentGrid.SuspendLayout()
        CType(Me.sfdgComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanced, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.scOkCancel.Panel2.Controls.Add(Me.btnOK)
        Me.scOkCancel.Panel2.Controls.Add(Me.btnCancel)
        Me.scOkCancel.Panel2.Controls.Add(Me.btnGear)
        Me.scOkCancel.Size = New System.Drawing.Size(740, 604)
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
        Me.scInstructions.Size = New System.Drawing.Size(740, 550)
        Me.scInstructions.SplitterDistance = 44
        Me.scInstructions.TabIndex = 0
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BeforeTouchSize = New System.Drawing.Size(720, 15)
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
        Me.txtCategories.BeforeTouchSize = New System.Drawing.Size(720, 15)
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
        Me.txtInstructions.BeforeTouchSize = New System.Drawing.Size(720, 15)
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
        Me.scTree.Panel1.Controls.Add(Me.tvCommentCategories)
        '
        'scTree.Panel2
        '
        Me.scTree.Panel2.Controls.Add(Me.lblWhereUsed)
        Me.scTree.Panel2.Controls.Add(Me.scWhereUsed)
        Me.scTree.Size = New System.Drawing.Size(740, 499)
        Me.scTree.SplitterDistance = 183
        Me.scTree.TabIndex = 0
        '
        'tvCommentCategories
        '
        TreeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = True
        TreeNodeAdvStyleInfo1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvCommentCategories.BaseStylePairs.AddRange(New Syncfusion.Windows.Forms.Tools.StyleNamePair() {New Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", TreeNodeAdvStyleInfo1)})
        Me.tvCommentCategories.BeforeTouchSize = New System.Drawing.Size(183, 499)
        Me.tvCommentCategories.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.tvCommentCategories.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCommentCategories.HelpTextControl.Location = New System.Drawing.Point(0, 0)
        Me.tvCommentCategories.HelpTextControl.Name = "helpText"
        Me.tvCommentCategories.HelpTextControl.Size = New System.Drawing.Size(49, 15)
        Me.tvCommentCategories.HelpTextControl.TabIndex = 0
        Me.tvCommentCategories.HelpTextControl.Text = "help text"
        Me.tvCommentCategories.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText
        Me.tvCommentCategories.Location = New System.Drawing.Point(0, 0)
        Me.tvCommentCategories.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.tvCommentCategories.Name = "tvCommentCategories"
        Me.tvCommentCategories.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText
        Me.tvCommentCategories.Size = New System.Drawing.Size(183, 499)
        Me.tvCommentCategories.TabIndex = 0
        '
        '
        '
        Me.tvCommentCategories.ToolTipControl.BackColor = System.Drawing.SystemColors.Info
        Me.tvCommentCategories.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvCommentCategories.ToolTipControl.Location = New System.Drawing.Point(0, 0)
        Me.tvCommentCategories.ToolTipControl.Name = "toolTip"
        Me.tvCommentCategories.ToolTipControl.Size = New System.Drawing.Size(41, 15)
        Me.tvCommentCategories.ToolTipControl.TabIndex = 1
        Me.tvCommentCategories.ToolTipControl.Text = "toolTip"
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
        Me.scWhereUsed.Size = New System.Drawing.Size(550, 499)
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
        Me.scAttachments.Size = New System.Drawing.Size(550, 423)
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
        '
        'scCommentGrid.Panel1
        '
        Me.scCommentGrid.Panel1.Controls.Add(Me.sfdgComments)
        Me.scCommentGrid.Size = New System.Drawing.Size(550, 348)
        Me.scCommentGrid.SplitterDistance = 499
        Me.scCommentGrid.TabIndex = 0
        '
        'sfdgComments
        '
        Me.sfdgComments.AccessibleName = "Table"
        Me.sfdgComments.AutoGenerateColumns = False
        GridTextColumn1.HeaderText = "Name"
        GridTextColumn1.MappingName = "Name"
        GridTextColumn2.HeaderText = "Text"
        GridTextColumn2.MappingName = "Text"
        GridTextColumn3.HeaderText = "Summary"
        GridTextColumn3.MappingName = "Summary"
        Me.sfdgComments.Columns.Add(GridTextColumn1)
        Me.sfdgComments.Columns.Add(GridTextColumn2)
        Me.sfdgComments.Columns.Add(GridTextColumn3)
        Me.sfdgComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sfdgComments.Location = New System.Drawing.Point(0, 0)
        Me.sfdgComments.Name = "sfdgComments"
        Me.sfdgComments.Size = New System.Drawing.Size(499, 348)
        Me.sfdgComments.TabIndex = 0
        '
        'txtAdvanced
        '
        Me.txtAdvanced.BeforeTouchSize = New System.Drawing.Size(720, 15)
        Me.txtAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.txtAdvanced.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdvanced.Multiline = True
        Me.txtAdvanced.Name = "txtAdvanced"
        Me.txtAdvanced.Size = New System.Drawing.Size(550, 50)
        Me.txtAdvanced.TabIndex = 0
        '
        'txtWhereUsed
        '
        Me.txtWhereUsed.BeforeTouchSize = New System.Drawing.Size(720, 15)
        Me.txtWhereUsed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWhereUsed.Location = New System.Drawing.Point(0, 0)
        Me.txtWhereUsed.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWhereUsed.Multiline = True
        Me.txtWhereUsed.Name = "txtWhereUsed"
        Me.txtWhereUsed.Size = New System.Drawing.Size(550, 51)
        Me.txtWhereUsed.TabIndex = 0
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
        'btnGear
        '
        Me.btnGear.BeforeTouchSize = New System.Drawing.Size(30, 30)
        Me.btnGear.Image = Global.SyncfusionWindowsFormsApplication1.My.Resources.Resources.gear1
        Me.btnGear.IsBackStageButton = False
        Me.btnGear.Location = New System.Drawing.Point(692, 9)
        Me.btnGear.Name = "btnGear"
        Me.btnGear.Size = New System.Drawing.Size(30, 30)
        Me.btnGear.TabIndex = 10
        '
        'dlgComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionButtonHoverColor = System.Drawing.Color.Red
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(740, 604)
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
        CType(Me.tvCommentCategories, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.scCommentGrid.Panel1.ResumeLayout(False)
        CType(Me.scCommentGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scCommentGrid.ResumeLayout(False)
        CType(Me.sfdgComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanced, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWhereUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scOkCancel As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scInstructions As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents txtComments As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCategories As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtInstructions As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scTree As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents tvCommentCategories As Syncfusion.Windows.Forms.Tools.TreeViewAdv
    Friend WithEvents lblWhereUsed As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents scWhereUsed As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scAttachments As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents txtWhereUsed As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scCommentGrid As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents sfdgComments As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCancel As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnGear As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblAttachments As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents txtAdvanced As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class
