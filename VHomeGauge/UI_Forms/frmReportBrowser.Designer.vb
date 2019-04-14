<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBrowser
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
        Me.tbFileSelectInstructions = New System.Windows.Forms.TextBox()
        Me.dgReports = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.btnOpenHG = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnGear = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.bthRefreshDb = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnOpenDb = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnImport = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSlab.Panel1.SuspendLayout()
        Me.scSlab.Panel2.SuspendLayout()
        Me.scSlab.SuspendLayout()
        CType(Me.scReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scReportGrid.Panel1.SuspendLayout()
        Me.scReportGrid.Panel2.SuspendLayout()
        Me.scReportGrid.SuspendLayout()
        CType(Me.dgReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scSlab
        '
        Me.scSlab.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scSlab.BeforeTouchSize = 1
        Me.scSlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSlab.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel2
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
        Me.scSlab.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scSlab.Panel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scSlab.Panel2.Controls.Add(Me.btnOpenHG)
        Me.scSlab.Panel2.Controls.Add(Me.btnGear)
        Me.scSlab.Panel2.Controls.Add(Me.bthRefreshDb)
        Me.scSlab.Panel2.Controls.Add(Me.btnOpenDb)
        Me.scSlab.Panel2.Controls.Add(Me.btnImport)
        Me.scSlab.Size = New System.Drawing.Size(705, 578)
        Me.scSlab.SplitterDistance = 525
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
        Me.scReportGrid.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.scReportGrid.Panel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scReportGrid.Panel1.Controls.Add(Me.tbFileSelectInstructions)
        '
        'scReportGrid.Panel2
        '
        Me.scReportGrid.Panel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.scReportGrid.Panel2.Controls.Add(Me.dgReports)
        Me.scReportGrid.Size = New System.Drawing.Size(705, 525)
        Me.scReportGrid.SplitterDistance = 44
        Me.scReportGrid.SplitterWidth = 1
        Me.scReportGrid.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Metro
        Me.scReportGrid.TabIndex = 0
        '
        'tbFileSelectInstructions
        '
        Me.tbFileSelectInstructions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbFileSelectInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbFileSelectInstructions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFileSelectInstructions.Location = New System.Drawing.Point(0, 0)
        Me.tbFileSelectInstructions.Multiline = True
        Me.tbFileSelectInstructions.Name = "tbFileSelectInstructions"
        Me.tbFileSelectInstructions.ReadOnly = True
        Me.tbFileSelectInstructions.Size = New System.Drawing.Size(705, 44)
        Me.tbFileSelectInstructions.TabIndex = 0
        Me.tbFileSelectInstructions.Text = "Select a row to open." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click a header to sort."
        '
        'dgReports
        '
        Me.dgReports.AccessibleName = "Table"
        Me.dgReports.AllowEditing = False
        Me.dgReports.AllowResizingColumns = True
        Me.dgReports.AutoGenerateColumns = False
        GridTextColumn1.AllowEditing = False
        GridTextColumn1.AllowResizing = True
        GridTextColumn1.HeaderText = "Report ID"
        GridTextColumn1.MappingName = "ReportNumber"
        GridTextColumn2.AllowEditing = False
        GridTextColumn2.AllowResizing = True
        GridTextColumn2.HeaderText = "Version"
        GridTextColumn2.MappingName = "Version"
        GridTextColumn3.AllowEditing = False
        GridTextColumn3.AllowResizing = True
        GridTextColumn3.HeaderText = "Client Name"
        GridTextColumn3.MappingName = "ClientName"
        GridTextColumn4.AllowEditing = False
        GridTextColumn4.AllowResizing = True
        GridTextColumn4.HeaderText = "Address"
        GridTextColumn4.MappingName = "Address"
        GridTextColumn5.AllowEditing = False
        GridTextColumn5.AllowResizing = True
        GridTextColumn5.HeaderText = "City"
        GridTextColumn5.MappingName = "City"
        GridTextColumn6.AllowEditing = False
        GridTextColumn6.AllowResizing = True
        GridTextColumn6.HeaderText = "Zip Code"
        GridTextColumn6.MappingName = "ZipCode"
        GridTextColumn7.AllowEditing = False
        GridTextColumn7.AllowResizing = True
        GridTextColumn7.HeaderText = "Agent"
        GridTextColumn7.MappingName = "AgentName"
        GridTextColumn8.AllowEditing = False
        GridTextColumn8.AllowResizing = True
        GridTextColumn8.HeaderText = "Uploaded"
        GridTextColumn8.MappingName = "Uploaded"
        Me.dgReports.Columns.Add(GridTextColumn1)
        Me.dgReports.Columns.Add(GridTextColumn2)
        Me.dgReports.Columns.Add(GridTextColumn3)
        Me.dgReports.Columns.Add(GridTextColumn4)
        Me.dgReports.Columns.Add(GridTextColumn5)
        Me.dgReports.Columns.Add(GridTextColumn6)
        Me.dgReports.Columns.Add(GridTextColumn7)
        Me.dgReports.Columns.Add(GridTextColumn8)
        Me.dgReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReports.Location = New System.Drawing.Point(0, 0)
        Me.dgReports.Name = "dgReports"
        Me.dgReports.Size = New System.Drawing.Size(705, 480)
        Me.dgReports.Style.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dgReports.TabIndex = 0
        Me.dgReports.Text = "SfDataGrid1"
        '
        'btnOpenHG
        '
        Me.btnOpenHG.BackColor = System.Drawing.Color.White
        Me.btnOpenHG.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOpenHG.IsBackStageButton = False
        Me.btnOpenHG.Location = New System.Drawing.Point(195, 15)
        Me.btnOpenHG.Name = "btnOpenHG"
        Me.btnOpenHG.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenHG.TabIndex = 10
        Me.btnOpenHG.Text = "Open HG"
        Me.btnOpenHG.UseVisualStyle = False
        '
        'btnGear
        '
        Me.btnGear.BackColor = System.Drawing.Color.White
        Me.btnGear.BeforeTouchSize = New System.Drawing.Size(34, 31)
        Me.btnGear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGear.Image = Global.VHIHomeGaugeApplication.My.Resources.Resources.gear1
        Me.btnGear.IsBackStageButton = False
        Me.btnGear.KeepFocusRectangle = False
        Me.btnGear.Location = New System.Drawing.Point(638, 11)
        Me.btnGear.Name = "btnGear"
        Me.btnGear.Size = New System.Drawing.Size(34, 31)
        Me.btnGear.TabIndex = 9
        Me.btnGear.UseVisualStyle = True
        '
        'bthRefreshDb
        '
        Me.bthRefreshDb.BackColor = System.Drawing.Color.White
        Me.bthRefreshDb.BeforeTouchSize = New System.Drawing.Size(116, 23)
        Me.bthRefreshDb.IsBackStageButton = False
        Me.bthRefreshDb.Location = New System.Drawing.Point(457, 15)
        Me.bthRefreshDb.Name = "bthRefreshDb"
        Me.bthRefreshDb.Size = New System.Drawing.Size(116, 23)
        Me.bthRefreshDb.TabIndex = 8
        Me.bthRefreshDb.Text = "Refresh The Grid"
        Me.bthRefreshDb.UseVisualStyle = False
        '
        'btnOpenDb
        '
        Me.btnOpenDb.BackColor = System.Drawing.Color.White
        Me.btnOpenDb.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOpenDb.IsBackStageButton = False
        Me.btnOpenDb.Location = New System.Drawing.Point(114, 15)
        Me.btnOpenDb.Name = "btnOpenDb"
        Me.btnOpenDb.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenDb.TabIndex = 7
        Me.btnOpenDb.Text = "Open dB"
        Me.btnOpenDb.UseVisualStyle = False
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.White
        Me.btnImport.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnImport.IsBackStageButton = False
        Me.btnImport.Location = New System.Drawing.Point(32, 15)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyle = False
        '
        'frmReportBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(705, 578)
        Me.Controls.Add(Me.scSlab)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReportBrowser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Reports"
        Me.scSlab.Panel1.ResumeLayout(False)
        Me.scSlab.Panel2.ResumeLayout(False)
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSlab.ResumeLayout(False)
        Me.scReportGrid.Panel1.ResumeLayout(False)
        Me.scReportGrid.Panel1.PerformLayout()
        Me.scReportGrid.Panel2.ResumeLayout(False)
        CType(Me.scReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scReportGrid.ResumeLayout(False)
        CType(Me.dgReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scSlab As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scReportGrid As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents dgReports As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents btnOpenHG As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnGear As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents bthRefreshDb As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnOpenDb As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnImport As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents tbFileSelectInstructions As TextBox
End Class
