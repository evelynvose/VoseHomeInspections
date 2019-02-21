<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient
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
        Me.SplitContainerAdv1 = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        CType(Me.SplitContainerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerAdv1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerAdv1
        '
        Me.SplitContainerAdv1.BeforeTouchSize = 7
        Me.SplitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAdv1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerAdv1.Name = "SplitContainerAdv1"
        Me.SplitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.SplitContainerAdv1.Size = New System.Drawing.Size(740, 433)
        Me.SplitContainerAdv1.SplitterDistance = 293
        Me.SplitContainerAdv1.TabIndex = 0
        '
        'WorkFormClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(740, 433)
        Me.Controls.Add(Me.SplitContainerAdv1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WorkFormClient"
        CType(Me.SplitContainerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAdv1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerAdv1 As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
End Class
