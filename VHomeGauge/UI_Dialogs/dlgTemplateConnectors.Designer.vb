<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTemplateConnectors
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
        Me.spSlab = New System.Windows.Forms.SplitContainer()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.spFoundation = New System.Windows.Forms.SplitContainer()
        Me.sfdgConnectors = New Syncfusion.WinForms.DataGrid.SfDataGrid()
        Me.btnCancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.spSlab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spSlab.Panel1.SuspendLayout()
        Me.spSlab.Panel2.SuspendLayout()
        Me.spSlab.SuspendLayout()
        CType(Me.spFoundation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spFoundation.Panel1.SuspendLayout()
        Me.spFoundation.Panel2.SuspendLayout()
        Me.spFoundation.SuspendLayout()
        CType(Me.sfdgConnectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spSlab
        '
        Me.spSlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spSlab.Location = New System.Drawing.Point(0, 0)
        Me.spSlab.Name = "spSlab"
        Me.spSlab.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spSlab.Panel1
        '
        Me.spSlab.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.spSlab.Panel1.Controls.Add(Me.txtInstructions)
        Me.spSlab.Panel1MinSize = 33
        '
        'spSlab.Panel2
        '
        Me.spSlab.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.spSlab.Panel2.Controls.Add(Me.spFoundation)
        Me.spSlab.Size = New System.Drawing.Size(269, 433)
        Me.spSlab.SplitterDistance = 51
        Me.spSlab.SplitterWidth = 1
        Me.spSlab.TabIndex = 0
        '
        'txtInstructions
        '
        Me.txtInstructions.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInstructions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInstructions.Location = New System.Drawing.Point(0, 0)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.ReadOnly = True
        Me.txtInstructions.Size = New System.Drawing.Size(269, 51)
        Me.txtInstructions.TabIndex = 3
        Me.txtInstructions.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "List of words used when building comments  to connect sentence fragments togeth" &
    "er."
        '
        'spFoundation
        '
        Me.spFoundation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spFoundation.Location = New System.Drawing.Point(0, 0)
        Me.spFoundation.Name = "spFoundation"
        Me.spFoundation.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spFoundation.Panel1
        '
        Me.spFoundation.Panel1.Controls.Add(Me.sfdgConnectors)
        Me.spFoundation.Panel1.ForeColor = System.Drawing.SystemColors.Window
        '
        'spFoundation.Panel2
        '
        Me.spFoundation.Panel2.Controls.Add(Me.btnCancel)
        Me.spFoundation.Panel2.Controls.Add(Me.btnOK)
        Me.spFoundation.Panel2MinSize = 40
        Me.spFoundation.Size = New System.Drawing.Size(269, 381)
        Me.spFoundation.SplitterDistance = 332
        Me.spFoundation.SplitterWidth = 1
        Me.spFoundation.TabIndex = 0
        '
        'sfdgConnectors
        '
        Me.sfdgConnectors.AccessibleName = "Table"
        Me.sfdgConnectors.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top
        Me.sfdgConnectors.AddNewRowText = "Click here to add a new connector"
        Me.sfdgConnectors.AllowDeleting = True
        Me.sfdgConnectors.AutoGenerateColumns = False
        GridTextColumn1.HeaderText = "Value"
        GridTextColumn1.MappingName = "XValue"
        GridTextColumn1.Width = 269.0R
        Me.sfdgConnectors.Columns.Add(GridTextColumn1)
        Me.sfdgConnectors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sfdgConnectors.Location = New System.Drawing.Point(0, 0)
        Me.sfdgConnectors.Name = "sfdgConnectors"
        Me.sfdgConnectors.Size = New System.Drawing.Size(269, 332)
        Me.sfdgConnectors.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.IsBackStageButton = False
        Me.btnCancel.Location = New System.Drawing.Point(157, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(35, 13)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'dlgTemplateConnectors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CaptionButtonHoverColor = System.Drawing.Color.Red
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CaptionForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(269, 433)
        Me.Controls.Add(Me.spSlab)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MetroColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "dlgTemplateConnectors"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.ShowMouseOver = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Connector List"
        Me.spSlab.Panel1.ResumeLayout(False)
        Me.spSlab.Panel1.PerformLayout()
        Me.spSlab.Panel2.ResumeLayout(False)
        CType(Me.spSlab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSlab.ResumeLayout(False)
        Me.spFoundation.Panel1.ResumeLayout(False)
        Me.spFoundation.Panel2.ResumeLayout(False)
        CType(Me.spFoundation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spFoundation.ResumeLayout(False)
        CType(Me.sfdgConnectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents spSlab As SplitContainer
    Friend WithEvents spFoundation As SplitContainer
    Friend WithEvents sfdgConnectors As Syncfusion.WinForms.DataGrid.SfDataGrid
    Friend WithEvents btnCancel As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtInstructions As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
