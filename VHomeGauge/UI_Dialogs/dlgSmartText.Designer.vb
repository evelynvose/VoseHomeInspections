<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSmartText
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
        Me.scSlab = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scFoundation = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.scSearch = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.lblSmartText = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.lblSearch = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.txtSearch = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.scSmartTextKeys = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.sfdgSmartTextKeys = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.scValues = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.lblSmartTextValues = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.scWhereUsed = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.sfdgSmartTextValues = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.scWhereUsed2 = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.lblWhereUsed = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.sfdgWhereUsed = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.btnGear = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSlab.Panel1.SuspendLayout()
        Me.scSlab.SuspendLayout()
        CType(Me.scFoundation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scFoundation.Panel1.SuspendLayout()
        Me.scFoundation.Panel2.SuspendLayout()
        Me.scFoundation.SuspendLayout()
        CType(Me.scSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSearch.Panel1.SuspendLayout()
        Me.scSearch.Panel2.SuspendLayout()
        Me.scSearch.SuspendLayout()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scSmartTextKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSmartTextKeys.Panel1.SuspendLayout()
        Me.scSmartTextKeys.Panel2.SuspendLayout()
        Me.scSmartTextKeys.SuspendLayout()
        CType(Me.sfdgSmartTextKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scValues.Panel1.SuspendLayout()
        Me.scValues.Panel2.SuspendLayout()
        Me.scValues.SuspendLayout()
        CType(Me.scWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scWhereUsed.Panel1.SuspendLayout()
        Me.scWhereUsed.Panel2.SuspendLayout()
        Me.scWhereUsed.SuspendLayout()
        CType(Me.sfdgSmartTextValues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scWhereUsed2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scWhereUsed2.Panel1.SuspendLayout()
        Me.scWhereUsed2.Panel2.SuspendLayout()
        Me.scWhereUsed2.SuspendLayout()
        CType(Me.sfdgWhereUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scSlab
        '
        Me.scSlab.BeforeTouchSize = 1
        Me.scSlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSlab.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel2
        Me.scSlab.Location = New System.Drawing.Point(0, 0)
        Me.scSlab.Name = "scSlab"
        '
        'scSlab.Panel1
        '
        Me.scSlab.Panel1.Controls.Add(Me.scFoundation)
        Me.scSlab.Panel2MinSize = 37
        Me.scSlab.Size = New System.Drawing.Size(850, 581)
        Me.scSlab.SplitterDistance = 802
        Me.scSlab.SplitterWidth = 1
        Me.scSlab.TabIndex = 0
        '
        'scFoundation
        '
        Me.scFoundation.BeforeTouchSize = 1
        Me.scFoundation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scFoundation.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel2
        Me.scFoundation.Location = New System.Drawing.Point(0, 0)
        Me.scFoundation.Name = "scFoundation"
        Me.scFoundation.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scFoundation.Panel1
        '
        Me.scFoundation.Panel1.Controls.Add(Me.scSearch)
        '
        'scFoundation.Panel2
        '
        Me.scFoundation.Panel2.Controls.Add(Me.btnGear)
        Me.scFoundation.Panel2.Controls.Add(Me.btnCancel)
        Me.scFoundation.Panel2.Controls.Add(Me.btnOK)
        Me.scFoundation.Size = New System.Drawing.Size(802, 581)
        Me.scFoundation.SplitterDistance = 537
        Me.scFoundation.SplitterWidth = 1
        Me.scFoundation.TabIndex = 0
        '
        'scSearch
        '
        Me.scSearch.BeforeTouchSize = 1
        Me.scSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSearch.Location = New System.Drawing.Point(0, 0)
        Me.scSearch.Name = "scSearch"
        Me.scSearch.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scSearch.Panel1
        '
        Me.scSearch.Panel1.Controls.Add(Me.lblSmartText)
        Me.scSearch.Panel1.Controls.Add(Me.lblSearch)
        Me.scSearch.Panel1.Controls.Add(Me.txtSearch)
        '
        'scSearch.Panel2
        '
        Me.scSearch.Panel2.Controls.Add(Me.scSmartTextKeys)
        Me.scSearch.Size = New System.Drawing.Size(802, 537)
        Me.scSearch.SplitterDistance = 40
        Me.scSearch.SplitterWidth = 1
        Me.scSearch.TabIndex = 0
        '
        'lblSmartText
        '
        Me.lblSmartText.Location = New System.Drawing.Point(12, 20)
        Me.lblSmartText.Name = "lblSmartText"
        Me.lblSmartText.Size = New System.Drawing.Size(111, 13)
        Me.lblSmartText.TabIndex = 2
        Me.lblSmartText.Text = "All Smart Text Words"
        '
        'lblSearch
        '
        Me.lblSearch.DX = -45
        Me.lblSearch.DY = 3
        Me.lblSearch.LabeledControl = Me.txtSearch
        Me.lblSearch.Location = New System.Drawing.Point(276, 14)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(41, 13)
        Me.lblSearch.TabIndex = 1
        Me.lblSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.BeforeTouchSize = New System.Drawing.Size(217, 22)
        Me.txtSearch.Location = New System.Drawing.Point(321, 11)
        Me.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(217, 22)
        Me.txtSearch.TabIndex = 0
        '
        'scSmartTextKeys
        '
        Me.scSmartTextKeys.BeforeTouchSize = 1
        Me.scSmartTextKeys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSmartTextKeys.Location = New System.Drawing.Point(0, 0)
        Me.scSmartTextKeys.Name = "scSmartTextKeys"
        Me.scSmartTextKeys.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scSmartTextKeys.Panel1
        '
        Me.scSmartTextKeys.Panel1.Controls.Add(Me.sfdgSmartTextKeys)
        '
        'scSmartTextKeys.Panel2
        '
        Me.scSmartTextKeys.Panel2.Controls.Add(Me.scValues)
        Me.scSmartTextKeys.Size = New System.Drawing.Size(802, 496)
        Me.scSmartTextKeys.SplitterDistance = 200
        Me.scSmartTextKeys.SplitterWidth = 1
        Me.scSmartTextKeys.TabIndex = 0
        '
        'sfdgSmartTextKeys
        '
        Me.sfdgSmartTextKeys.AccessibleName = "Table"
        Me.sfdgSmartTextKeys.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top
        Me.sfdgSmartTextKeys.AddNewRowText = "Click here to add a new Key..."
        Me.sfdgSmartTextKeys.AllowDeleting = True
        Me.sfdgSmartTextKeys.AutoGenerateColumns = False
        GridTextColumn1.HeaderText = "Key"
        GridTextColumn1.MappingName = "Key"
        Me.sfdgSmartTextKeys.Columns.Add(GridTextColumn1)
        Me.sfdgSmartTextKeys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sfdgSmartTextKeys.Location = New System.Drawing.Point(0, 0)
        Me.sfdgSmartTextKeys.Name = "sfdgSmartTextKeys"
        Me.sfdgSmartTextKeys.Size = New System.Drawing.Size(802, 200)
        Me.sfdgSmartTextKeys.TabIndex = 0
        '
        'scValues
        '
        Me.scValues.BeforeTouchSize = 1
        Me.scValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scValues.Location = New System.Drawing.Point(0, 0)
        Me.scValues.Name = "scValues"
        Me.scValues.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scValues.Panel1
        '
        Me.scValues.Panel1.Controls.Add(Me.lblSmartTextValues)
        '
        'scValues.Panel2
        '
        Me.scValues.Panel2.Controls.Add(Me.scWhereUsed)
        Me.scValues.Size = New System.Drawing.Size(802, 295)
        Me.scValues.SplitterDistance = 31
        Me.scValues.SplitterWidth = 1
        Me.scValues.TabIndex = 0
        '
        'lblSmartTextValues
        '
        Me.lblSmartTextValues.Location = New System.Drawing.Point(12, 6)
        Me.lblSmartTextValues.Name = "lblSmartTextValues"
        Me.lblSmartTextValues.Size = New System.Drawing.Size(109, 13)
        Me.lblSmartTextValues.TabIndex = 0
        Me.lblSmartTextValues.Text = "Replacement Values"
        '
        'scWhereUsed
        '
        Me.scWhereUsed.BeforeTouchSize = 1
        Me.scWhereUsed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scWhereUsed.Location = New System.Drawing.Point(0, 0)
        Me.scWhereUsed.Name = "scWhereUsed"
        Me.scWhereUsed.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scWhereUsed.Panel1
        '
        Me.scWhereUsed.Panel1.Controls.Add(Me.sfdgSmartTextValues)
        '
        'scWhereUsed.Panel2
        '
        Me.scWhereUsed.Panel2.Controls.Add(Me.scWhereUsed2)
        Me.scWhereUsed.Size = New System.Drawing.Size(802, 263)
        Me.scWhereUsed.SplitterDistance = 156
        Me.scWhereUsed.SplitterWidth = 1
        Me.scWhereUsed.TabIndex = 0
        '
        'sfdgSmartTextValues
        '
        Me.sfdgSmartTextValues.AccessibleName = "Table"
        Me.sfdgSmartTextValues.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top
        Me.sfdgSmartTextValues.AddNewRowText = "Click here to add a new Value..."
        Me.sfdgSmartTextValues.AllowDeleting = True
        Me.sfdgSmartTextValues.AutoGenerateColumns = False
        GridTextColumn2.HeaderText = "Value"
        GridTextColumn2.MappingName = "Value"
        Me.sfdgSmartTextValues.Columns.Add(GridTextColumn2)
        Me.sfdgSmartTextValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sfdgSmartTextValues.Location = New System.Drawing.Point(0, 0)
        Me.sfdgSmartTextValues.Name = "sfdgSmartTextValues"
        Me.sfdgSmartTextValues.Size = New System.Drawing.Size(802, 156)
        Me.sfdgSmartTextValues.TabIndex = 0
        '
        'scWhereUsed2
        '
        Me.scWhereUsed2.BeforeTouchSize = 1
        Me.scWhereUsed2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scWhereUsed2.Location = New System.Drawing.Point(0, 0)
        Me.scWhereUsed2.Name = "scWhereUsed2"
        Me.scWhereUsed2.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scWhereUsed2.Panel1
        '
        Me.scWhereUsed2.Panel1.Controls.Add(Me.lblWhereUsed)
        '
        'scWhereUsed2.Panel2
        '
        Me.scWhereUsed2.Panel2.Controls.Add(Me.sfdgWhereUsed)
        Me.scWhereUsed2.Size = New System.Drawing.Size(802, 106)
        Me.scWhereUsed2.SplitterDistance = 27
        Me.scWhereUsed2.SplitterWidth = 1
        Me.scWhereUsed2.TabIndex = 0
        '
        'lblWhereUsed
        '
        Me.lblWhereUsed.Location = New System.Drawing.Point(12, 6)
        Me.lblWhereUsed.Name = "lblWhereUsed"
        Me.lblWhereUsed.Size = New System.Drawing.Size(70, 13)
        Me.lblWhereUsed.TabIndex = 0
        Me.lblWhereUsed.Text = "Where Used"
        '
        'sfdgWhereUsed
        '
        Me.sfdgWhereUsed.AccessibleName = "Table"
        Me.sfdgWhereUsed.AutoGenerateColumns = False
        GridTextColumn3.HeaderText = "Where Used"
        GridTextColumn3.MappingName = "WhereUsed"
        Me.sfdgWhereUsed.Columns.Add(GridTextColumn3)
        Me.sfdgWhereUsed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sfdgWhereUsed.Location = New System.Drawing.Point(0, 0)
        Me.sfdgWhereUsed.Name = "sfdgWhereUsed"
        Me.sfdgWhereUsed.Size = New System.Drawing.Size(802, 78)
        Me.sfdgWhereUsed.TabIndex = 0
        '
        'btnGear
        '
        Me.btnGear.BeforeTouchSize = New System.Drawing.Size(30, 30)
        Me.btnGear.Image = Global.VHIHomeGaugeApplication.My.Resources.Resources.gear1
        Me.btnGear.IsBackStageButton = False
        Me.btnGear.Location = New System.Drawing.Point(717, 7)
        Me.btnGear.MetroColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnGear.Name = "btnGear"
        Me.btnGear.Size = New System.Drawing.Size(30, 30)
        Me.btnGear.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnCancel.IsBackStageButton = False
        Me.btnCancel.Location = New System.Drawing.Point(242, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(134, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'dlgSmartText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CaptionButtonHoverColor = System.Drawing.Color.Red
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CaptionForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(850, 581)
        Me.Controls.Add(Me.scSlab)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MetroColor = System.Drawing.SystemColors.ActiveCaption
        Me.MinimizeBox = False
        Me.Name = "dlgSmartText"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.ShowMouseOver = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Smart Text"
        Me.scSlab.Panel1.ResumeLayout(False)
        CType(Me.scSlab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSlab.ResumeLayout(False)
        Me.scFoundation.Panel1.ResumeLayout(False)
        Me.scFoundation.Panel2.ResumeLayout(False)
        CType(Me.scFoundation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scFoundation.ResumeLayout(False)
        Me.scSearch.Panel1.ResumeLayout(False)
        Me.scSearch.Panel1.PerformLayout()
        Me.scSearch.Panel2.ResumeLayout(False)
        CType(Me.scSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSearch.ResumeLayout(False)
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSmartTextKeys.Panel1.ResumeLayout(False)
        Me.scSmartTextKeys.Panel2.ResumeLayout(False)
        CType(Me.scSmartTextKeys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSmartTextKeys.ResumeLayout(False)
        CType(Me.sfdgSmartTextKeys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scValues.Panel1.ResumeLayout(False)
        Me.scValues.Panel1.PerformLayout()
        Me.scValues.Panel2.ResumeLayout(False)
        CType(Me.scValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scValues.ResumeLayout(False)
        Me.scWhereUsed.Panel1.ResumeLayout(False)
        Me.scWhereUsed.Panel2.ResumeLayout(False)
        CType(Me.scWhereUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scWhereUsed.ResumeLayout(False)
        CType(Me.sfdgSmartTextValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scWhereUsed2.Panel1.ResumeLayout(False)
        Me.scWhereUsed2.Panel1.PerformLayout()
        Me.scWhereUsed2.Panel2.ResumeLayout(False)
        CType(Me.scWhereUsed2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scWhereUsed2.ResumeLayout(False)
        CType(Me.sfdgWhereUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scSlab As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scFoundation As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents scSearch As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents lblSmartText As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents lblSearch As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents txtSearch As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents scSmartTextKeys As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents sfdgSmartTextKeys As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents scValues As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents lblSmartTextValues As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents scWhereUsed As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents sfdgSmartTextValues As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents scWhereUsed2 As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents lblWhereUsed As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents sfdgWhereUsed As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents btnGear As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCancel As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
End Class
