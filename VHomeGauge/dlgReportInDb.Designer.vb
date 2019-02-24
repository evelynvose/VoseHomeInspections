Imports Syncfusion.Windows.Forms
'
'
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgReportInDb
    Inherits MetroForm

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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.ckUpdateFromReportFile = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        CType(Me.ckUpdateFromReportFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(308, 114)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'AutoLabel1
        '
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.Location = New System.Drawing.Point(83, 50)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Size = New System.Drawing.Size(270, 25)
        Me.AutoLabel1.TabIndex = 1
        Me.AutoLabel1.Text = "The report is already in the db!"
        '
        'ckUpdateFromReportFile
        '
        Me.ckUpdateFromReportFile.BeforeTouchSize = New System.Drawing.Size(150, 51)
        Me.ckUpdateFromReportFile.Location = New System.Drawing.Point(70, 98)
        Me.ckUpdateFromReportFile.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ckUpdateFromReportFile.Name = "ckUpdateFromReportFile"
        Me.ckUpdateFromReportFile.Size = New System.Drawing.Size(150, 51)
        Me.ckUpdateFromReportFile.TabIndex = 2
        Me.ckUpdateFromReportFile.Text = "Update the dB from the HG report file"
        Me.ckUpdateFromReportFile.ThemesEnabled = False
        '
        'dlgReportInDb
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 165)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.ckUpdateFromReportFile)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgReportInDb"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Browser"
        CType(Me.ckUpdateFromReportFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents ckUpdateFromReportFile As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
End Class
