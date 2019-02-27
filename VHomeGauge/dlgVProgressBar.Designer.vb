<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgVProgressBar
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
        Me.ProgressBarAdv1 = New Syncfusion.Windows.Forms.Tools.ProgressBarAdv()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnOK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lblAnnouncement = New Syncfusion.Windows.Forms.Tools.GradientLabel()
        Me.tbStatus = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.ProgressBarAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ProgressBarAdv1.Location = New System.Drawing.Point(17, 16)
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
        'BackgroundWorker1
        '
        '
        'btnOK
        '
        Me.btnOK.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btnOK.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Flat
        Me.btnOK.IsBackStageButton = False
        Me.btnOK.Location = New System.Drawing.Point(145, 59)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyle = False
        '
        'lblAnnouncement
        '
        Me.lblAnnouncement.BackgroundColor = New Syncfusion.Drawing.BrushInfo()
        Me.lblAnnouncement.BeforeTouchSize = New System.Drawing.Size(289, 36)
        Me.lblAnnouncement.BorderAppearance = System.Windows.Forms.BorderStyle.None
        Me.lblAnnouncement.BorderColor = System.Drawing.Color.Transparent
        Me.lblAnnouncement.BorderSides = CType(((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
            Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom) _
            Or System.Windows.Forms.Border3DSide.Middle), System.Windows.Forms.Border3DSide)
        Me.lblAnnouncement.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnouncement.Location = New System.Drawing.Point(38, 9)
        Me.lblAnnouncement.Name = "lblAnnouncement"
        Me.lblAnnouncement.Size = New System.Drawing.Size(289, 36)
        Me.lblAnnouncement.TabIndex = 2
        Me.lblAnnouncement.Text = "Success!"
        Me.lblAnnouncement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAnnouncement.Visible = False
        '
        'tbStatus
        '
        Me.tbStatus.BeforeTouchSize = New System.Drawing.Size(330, 23)
        Me.tbStatus.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.tbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbStatus.Location = New System.Drawing.Point(17, 59)
        Me.tbStatus.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(330, 23)
        Me.tbStatus.TabIndex = 3
        Me.tbStatus.Text = "Status"
        Me.tbStatus.Visible = False
        '
        'dlgVProgressBar
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(365, 94)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblAnnouncement)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.ProgressBarAdv1)
        Me.Controls.Add(Me.tbStatus)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgVProgressBar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Title"
        CType(Me.ProgressBarAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBarAdv1 As Syncfusion.Windows.Forms.Tools.ProgressBarAdv
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnOK As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblAnnouncement As Syncfusion.Windows.Forms.Tools.GradientLabel
    Friend WithEvents tbStatus As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class
