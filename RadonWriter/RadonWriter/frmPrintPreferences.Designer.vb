<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintPreferences
    Inherits System.Windows.Forms.Form

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
        Me.cbIncludeTemperature = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.cbIncludeHumidity = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        CType(Me.cbIncludeTemperature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbIncludeHumidity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbIncludeTemperature
        '
        Me.cbIncludeTemperature.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbIncludeTemperature.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.cbIncludeTemperature.BorderColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cbIncludeTemperature.Checked = True
        Me.cbIncludeTemperature.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIncludeTemperature.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cbIncludeTemperature.HotBorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.cbIncludeTemperature.Location = New System.Drawing.Point(68, 45)
        Me.cbIncludeTemperature.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.cbIncludeTemperature.Name = "cbIncludeTemperature"
        Me.cbIncludeTemperature.Size = New System.Drawing.Size(150, 21)
        Me.cbIncludeTemperature.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2016Colorful
        Me.cbIncludeTemperature.TabIndex = 0
        Me.cbIncludeTemperature.Text = "Include Temperature"
        Me.cbIncludeTemperature.ThemesEnabled = False
        '
        'cbIncludeHumidity
        '
        Me.cbIncludeHumidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbIncludeHumidity.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.cbIncludeHumidity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cbIncludeHumidity.Checked = True
        Me.cbIncludeHumidity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIncludeHumidity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cbIncludeHumidity.HotBorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.cbIncludeHumidity.Location = New System.Drawing.Point(68, 72)
        Me.cbIncludeHumidity.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.cbIncludeHumidity.Name = "cbIncludeHumidity"
        Me.cbIncludeHumidity.Size = New System.Drawing.Size(150, 21)
        Me.cbIncludeHumidity.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2016Colorful
        Me.cbIncludeHumidity.TabIndex = 1
        Me.cbIncludeHumidity.Text = "Include Humidity"
        Me.cbIncludeHumidity.ThemesEnabled = False
        '
        'frmPrintPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 246)
        Me.Controls.Add(Me.cbIncludeHumidity)
        Me.Controls.Add(Me.cbIncludeTemperature)
        Me.Name = "frmPrintPreferences"
        Me.Text = "Form1"
        CType(Me.cbIncludeTemperature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbIncludeHumidity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbIncludeTemperature As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents cbIncludeHumidity As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
End Class
