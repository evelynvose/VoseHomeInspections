<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCommentsImports
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
        Me.ParentBarItem1 = New Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem()
        Me.SuspendLayout()
        '
        'ParentBarItem1
        '
        Me.ParentBarItem1.BarName = "ParentBarItem1"
        Me.ParentBarItem1.MetroColor = System.Drawing.Color.LightSkyBlue
        Me.ParentBarItem1.ShowToolTipInPopUp = False
        Me.ParentBarItem1.SizeToFit = True
        Me.ParentBarItem1.WrapLength = 20
        '
        'dlgCommentsImports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(113, 139)
        Me.Name = "dlgCommentsImports"
        Me.Text = "MetroForm1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ParentBarItem1 As Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem
End Class
