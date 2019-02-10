<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkFormOpenReport
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
        Dim GridTextColumn1 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn2 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn3 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn4 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn5 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn6 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn7 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Dim GridTextColumn8 As Syncfusion.WinForms.DataGrid.GridTextColumn = New Syncfusion.WinForms.DataGrid.GridTextColumn()
        Me.scSlab = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scReportGrid = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.labOpenReportInstructions = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.dgReports = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.scReportInfo = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.btnGear = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.bthRefreshDb = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnHelp = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnOpen = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.SplitContainerAdv1 = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.dgReportInfo = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.pbCoverImage = New System.Windows.Forms.PictureBox()
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSlab.Panel1.SuspendLayout()
        Me.scSlab.Panel2.SuspendLayout()
        Me.scSlab.SuspendLayout()
        CType(Me.scReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scReportGrid.Panel1.SuspendLayout()
        Me.scReportGrid.Panel2.SuspendLayout()
        Me.scReportGrid.SuspendLayout()
        CType(Me.dgReports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scReportInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scReportInfo.Panel1.SuspendLayout()
        Me.scReportInfo.Panel2.SuspendLayout()
        Me.scReportInfo.SuspendLayout()
        CType(Me.SplitContainerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerAdv1.Panel1.SuspendLayout()
        Me.SplitContainerAdv1.Panel2.SuspendLayout()
        Me.SplitContainerAdv1.SuspendLayout()
        CType(Me.dgReportInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCoverImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scSlab
        '
        Me.scSlab.BeforeTouchSize = 1
        Me.scSlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSlab.HotExpandLine = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.scSlab.Location = New System.Drawing.Point(0, 0)
        Me.scSlab.Name = "scSlab"
        Me.scSlab.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scSlab.Panel1
        '
        Me.scSlab.Panel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scSlab.Panel1.Controls.Add(Me.scReportGrid)
        '
        'scSlab.Panel2
        '
        Me.scSlab.Panel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scSlab.Panel2.Controls.Add(Me.scReportInfo)
        Me.scSlab.Size = New System.Drawing.Size(705, 578)
        Me.scSlab.SplitterDistance = 286
        Me.scSlab.SplitterWidth = 1
        Me.scSlab.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Metro
        Me.scSlab.TabIndex = 0
        '
        'scReportGrid
        '
        Me.scReportGrid.BeforeTouchSize = 1
        Me.scReportGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scReportGrid.HotExpandLine = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.scReportGrid.Location = New System.Drawing.Point(0, 0)
        Me.scReportGrid.Name = "scReportGrid"
        Me.scReportGrid.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scReportGrid.Panel1
        '
        Me.scReportGrid.Panel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scReportGrid.Panel1.Controls.Add(Me.labOpenReportInstructions)
        '
        'scReportGrid.Panel2
        '
        Me.scReportGrid.Panel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scReportGrid.Panel2.Controls.Add(Me.dgReports)
        Me.scReportGrid.Size = New System.Drawing.Size(705, 286)
        Me.scReportGrid.SplitterDistance = 49
        Me.scReportGrid.SplitterWidth = 1
        Me.scReportGrid.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Metro
        Me.scReportGrid.TabIndex = 0
        '
        'labOpenReportInstructions
        '
        Me.labOpenReportInstructions.AutoSize = False
        Me.labOpenReportInstructions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.labOpenReportInstructions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labOpenReportInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.labOpenReportInstructions.Location = New System.Drawing.Point(0, 0)
        Me.labOpenReportInstructions.Name = "labOpenReportInstructions"
        Me.labOpenReportInstructions.Size = New System.Drawing.Size(705, 49)
        Me.labOpenReportInstructions.TabIndex = 0
        Me.labOpenReportInstructions.Text = "Select A Report to Open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click on a header to sort the reports" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.labOpenReportInstructions.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dgReports
        '
        Me.dgReports.AccessibleName = "Table"
        Me.dgReports.AllowEditing = False
        Me.dgReports.AutoGenerateColumns = False
        GridTextColumn1.AllowEditing = False
        GridTextColumn1.HeaderText = "Report ID"
        GridTextColumn1.MappingName = "ReportId"
        GridTextColumn2.AllowEditing = False
        GridTextColumn2.HeaderText = "Client Name"
        GridTextColumn2.MappingName = "ClientName"
        GridTextColumn3.AllowEditing = False
        GridTextColumn3.HeaderText = "Address"
        GridTextColumn3.MappingName = "Address1"
        GridTextColumn4.AllowEditing = False
        GridTextColumn4.HeaderText = "City"
        GridTextColumn4.MappingName = "City"
        GridTextColumn5.AllowEditing = False
        GridTextColumn5.HeaderText = "Zip Code"
        GridTextColumn5.MappingName = "ZipCode"
        GridTextColumn6.AllowEditing = False
        GridTextColumn6.HeaderText = "Agent"
        GridTextColumn6.MappingName = "AgentName"
        GridTextColumn7.AllowEditing = False
        GridTextColumn7.HeaderText = "Uploaded"
        GridTextColumn7.MappingName = "Uploaded"
        Me.dgReports.Columns.Add(GridTextColumn1)
        Me.dgReports.Columns.Add(GridTextColumn2)
        Me.dgReports.Columns.Add(GridTextColumn3)
        Me.dgReports.Columns.Add(GridTextColumn4)
        Me.dgReports.Columns.Add(GridTextColumn5)
        Me.dgReports.Columns.Add(GridTextColumn6)
        Me.dgReports.Columns.Add(GridTextColumn7)
        Me.dgReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReports.Location = New System.Drawing.Point(0, 0)
        Me.dgReports.Name = "dgReports"
        Me.dgReports.Size = New System.Drawing.Size(705, 236)
        Me.dgReports.TabIndex = 0
        Me.dgReports.Text = "SfDataGrid1"
        '
        'scReportInfo
        '
        Me.scReportInfo.BeforeTouchSize = 1
        Me.scReportInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scReportInfo.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel1
        Me.scReportInfo.Location = New System.Drawing.Point(0, 0)
        Me.scReportInfo.Name = "scReportInfo"
        Me.scReportInfo.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scReportInfo.Panel1
        '
        Me.scReportInfo.Panel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.WhiteSmoke)
        Me.scReportInfo.Panel1.Controls.Add(Me.btnGear)
        Me.scReportInfo.Panel1.Controls.Add(Me.bthRefreshDb)
        Me.scReportInfo.Panel1.Controls.Add(Me.btnHelp)
        Me.scReportInfo.Panel1.Controls.Add(Me.btnCancel)
        Me.scReportInfo.Panel1.Controls.Add(Me.btnOpen)
        '
        'scReportInfo.Panel2
        '
        Me.scReportInfo.Panel2.Controls.Add(Me.SplitContainerAdv1)
        Me.scReportInfo.Size = New System.Drawing.Size(705, 291)
        Me.scReportInfo.SplitterDistance = 45
        Me.scReportInfo.SplitterWidth = 1
        Me.scReportInfo.TabIndex = 0
        '
        'btnGear
        '
        Me.btnGear.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnGear.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnGear.BeforeTouchSize = New System.Drawing.Size(34, 31)
        Me.btnGear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGear.ForeColor = System.Drawing.Color.White
        Me.btnGear.Image = Global.SyncfusionWindowsFormsApplication1.My.Resources.Resources.gear1
        Me.btnGear.IsBackStageButton = False
        Me.btnGear.KeepFocusRectangle = False
        Me.btnGear.Location = New System.Drawing.Point(618, 8)
        Me.btnGear.Name = "btnGear"
        Me.btnGear.Size = New System.Drawing.Size(34, 31)
        Me.btnGear.TabIndex = 4
        Me.btnGear.UseVisualStyle = True
        '
        'bthRefreshDb
        '
        Me.bthRefreshDb.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.bthRefreshDb.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.bthRefreshDb.BeforeTouchSize = New System.Drawing.Size(116, 23)
        Me.bthRefreshDb.ForeColor = System.Drawing.Color.White
        Me.bthRefreshDb.IsBackStageButton = False
        Me.bthRefreshDb.Location = New System.Drawing.Point(437, 12)
        Me.bthRefreshDb.Name = "bthRefreshDb"
        Me.bthRefreshDb.Size = New System.Drawing.Size(116, 23)
        Me.bthRefreshDb.TabIndex = 3
        Me.bthRefreshDb.Text = "Refresh Database"
        Me.bthRefreshDb.UseVisualStyle = True
        '
        'btnHelp
        '
        Me.btnHelp.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnHelp.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnHelp.ForeColor = System.Drawing.Color.White
        Me.btnHelp.IsBackStageButton = False
        Me.btnHelp.Location = New System.Drawing.Point(224, 12)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyle = True
        '
        'btnCancel
        '
        Me.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnCancel.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.IsBackStageButton = False
        Me.btnCancel.Location = New System.Drawing.Point(94, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyle = True
        '
        'btnOpen
        '
        Me.btnOpen.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnOpen.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOpen.ForeColor = System.Drawing.Color.White
        Me.btnOpen.IsBackStageButton = False
        Me.btnOpen.Location = New System.Drawing.Point(12, 12)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyle = True
        '
        'SplitContainerAdv1
        '
        Me.SplitContainerAdv1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.WhiteSmoke)
        Me.SplitContainerAdv1.BeforeTouchSize = 7
        Me.SplitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAdv1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerAdv1.Name = "SplitContainerAdv1"
        '
        'SplitContainerAdv1.Panel1
        '
        Me.SplitContainerAdv1.Panel1.Controls.Add(Me.dgReportInfo)
        '
        'SplitContainerAdv1.Panel2
        '
        Me.SplitContainerAdv1.Panel2.Controls.Add(Me.pbCoverImage)
        Me.SplitContainerAdv1.Size = New System.Drawing.Size(705, 245)
        Me.SplitContainerAdv1.SplitterDistance = 456
        Me.SplitContainerAdv1.TabIndex = 0
        Me.SplitContainerAdv1.Text = "SplitContainerAdv1"
        '
        'dgReportInfo
        '
        Me.dgReportInfo.AccessibleName = "Table"
        Me.dgReportInfo.AutoGenerateColumns = False
        GridTextColumn8.AllowEditing = False
        GridTextColumn8.AllowGrouping = False
        GridTextColumn8.AllowSorting = False
        GridTextColumn8.HeaderText = "Column1"
        GridTextColumn8.MappingName = "ReportInfo"
        GridTextColumn8.Visible = False
        Me.dgReportInfo.Columns.Add(GridTextColumn8)
        Me.dgReportInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReportInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgReportInfo.Name = "dgReportInfo"
        Me.dgReportInfo.Size = New System.Drawing.Size(456, 245)
        Me.dgReportInfo.TabIndex = 0
        '
        'pbCoverImage
        '
        Me.pbCoverImage.BackColor = System.Drawing.Color.Transparent
        Me.pbCoverImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbCoverImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbCoverImage.Location = New System.Drawing.Point(0, 0)
        Me.pbCoverImage.Name = "pbCoverImage"
        Me.pbCoverImage.Size = New System.Drawing.Size(242, 245)
        Me.pbCoverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbCoverImage.TabIndex = 0
        Me.pbCoverImage.TabStop = False
        '
        'WorkFormOpenReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(705, 578)
        Me.Controls.Add(Me.scSlab)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WorkFormOpenReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Reports"
        Me.scSlab.Panel1.ResumeLayout(False)
        Me.scSlab.Panel2.ResumeLayout(False)
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSlab.ResumeLayout(False)
        Me.scReportGrid.Panel1.ResumeLayout(False)
        Me.scReportGrid.Panel2.ResumeLayout(False)
        CType(Me.scReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scReportGrid.ResumeLayout(False)
        CType(Me.dgReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scReportInfo.Panel1.ResumeLayout(False)
        Me.scReportInfo.Panel2.ResumeLayout(False)
        CType(Me.scReportInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scReportInfo.ResumeLayout(False)
        Me.SplitContainerAdv1.Panel1.ResumeLayout(False)
        Me.SplitContainerAdv1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAdv1.ResumeLayout(False)
        CType(Me.dgReportInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCoverImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scSlab As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scReportGrid As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents labOpenReportInstructions As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents dgReports As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents scReportInfo As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents bthRefreshDb As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnHelp As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCancel As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnOpen As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnGear As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents SplitContainerAdv1 As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents dgReportInfo As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents pbCoverImage As PictureBox
End Class
