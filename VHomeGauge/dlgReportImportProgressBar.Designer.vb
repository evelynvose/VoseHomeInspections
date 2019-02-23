<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgReportImportProgressBar
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
        Me.ProgressBarAdv1 = New Syncfusion.Windows.Forms.Tools.ProgressBarAdv()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ProgressBarAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarAdv1
        '
        Me.ProgressBarAdv1.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient
        Me.ProgressBarAdv1.BackMultipleColors = New System.Drawing.Color() {System.Drawing.Color.Empty}
        Me.ProgressBarAdv1.BackSegments = False
        Me.ProgressBarAdv1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ProgressBarAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgressBarAdv1.CustomText = Nothing
        Me.ProgressBarAdv1.CustomWaitingRender = False
        Me.ProgressBarAdv1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBarAdv1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBarAdv1.ForegroundImage = Nothing
        Me.ProgressBarAdv1.GradientEndColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ProgressBarAdv1.GradientStartColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ProgressBarAdv1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBarAdv1.MultipleColors = New System.Drawing.Color() {System.Drawing.Color.Empty}
        Me.ProgressBarAdv1.Name = "ProgressBarAdv1"
        Me.ProgressBarAdv1.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro
        Me.ProgressBarAdv1.SegmentWidth = 12
        Me.ProgressBarAdv1.Size = New System.Drawing.Size(330, 23)
        Me.ProgressBarAdv1.TabIndex = 0
        Me.ProgressBarAdv1.TextVisible = False
        Me.ProgressBarAdv1.ThemesEnabled = True
        Me.ProgressBarAdv1.WaitingGradientWidth = 400
        '
        'Timer1
        '
        '
        'dlgReportImportProgressBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(354, 56)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBarAdv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgReportImportProgressBar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importing HG Report"
        CType(Me.ProgressBarAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBarAdv1 As Syncfusion.Windows.Forms.Tools.ProgressBarAdv
    Friend WithEvents Timer1 As Timer
End Class
