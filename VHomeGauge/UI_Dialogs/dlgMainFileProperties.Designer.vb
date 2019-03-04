<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgMainFileProperties
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboxErrorFile = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.cboxLogEvents = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboxErrorFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboxLogEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboxErrorFile)
        Me.GroupBox1.Controls.Add(Me.cboxLogEvents)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(130, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Debug"
        '
        'cboxErrorFile
        '
        Me.cboxErrorFile.BeforeTouchSize = New System.Drawing.Size(95, 21)
        Me.cboxErrorFile.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.cboxErrorFile.Location = New System.Drawing.Point(16, 58)
        Me.cboxErrorFile.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.cboxErrorFile.Name = "cboxErrorFile"
        Me.cboxErrorFile.Size = New System.Drawing.Size(95, 21)
        Me.cboxErrorFile.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.cboxErrorFile.TabIndex = 1
        Me.cboxErrorFile.Text = "Error File"
        Me.cboxErrorFile.ThemesEnabled = False
        '
        'cboxLogEvents
        '
        Me.cboxLogEvents.BeforeTouchSize = New System.Drawing.Size(95, 21)
        Me.cboxLogEvents.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.cboxLogEvents.Location = New System.Drawing.Point(16, 31)
        Me.cboxLogEvents.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.cboxLogEvents.Name = "cboxLogEvents"
        Me.cboxLogEvents.Size = New System.Drawing.Size(95, 21)
        Me.cboxLogEvents.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.cboxLogEvents.TabIndex = 0
        Me.cboxLogEvents.Text = "Log Events"
        Me.cboxLogEvents.ThemesEnabled = False
        '
        'btnOK
        '
        Me.btnOK.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(12, 135)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'dlgMainFileProperties
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(185, 169)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgMainFileProperties"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cboxErrorFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboxLogEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboxErrorFile As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents cboxLogEvents As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
End Class
