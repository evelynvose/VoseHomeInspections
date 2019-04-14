<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vRichTextBoxExt
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.cntlHost = New System.Windows.Forms.Integration.ElementHost()
        Me.SuspendLayout()
        '
        'cntlHost
        '
        Me.cntlHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cntlHost.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cntlHost.Location = New System.Drawing.Point(0, 0)
        Me.cntlHost.Margin = New System.Windows.Forms.Padding(0)
        Me.cntlHost.Name = "cntlHost"
        Me.cntlHost.Size = New System.Drawing.Size(231, 117)
        Me.cntlHost.TabIndex = 0
        Me.cntlHost.Child = Nothing
        '
        'vRichTextBoxExt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cntlHost)
        Me.Name = "vRichTextBoxExt"
        Me.Size = New System.Drawing.Size(231, 117)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cntlHost As Integration.ElementHost


End Class
