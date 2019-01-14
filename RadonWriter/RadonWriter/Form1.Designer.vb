<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.OpenRadonFile = New System.Windows.Forms.Button()
        Me.ProcessFile = New System.Windows.Forms.Button()
        Me.SaveNew = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'OpenRadonFile
        '
        Me.OpenRadonFile.Location = New System.Drawing.Point(12, 12)
        Me.OpenRadonFile.Name = "OpenRadonFile"
        Me.OpenRadonFile.Size = New System.Drawing.Size(140, 23)
        Me.OpenRadonFile.TabIndex = 0
        Me.OpenRadonFile.Text = "Open Radon File"
        Me.OpenRadonFile.UseVisualStyleBackColor = True
        '
        'ProcessFile
        '
        Me.ProcessFile.Location = New System.Drawing.Point(11, 41)
        Me.ProcessFile.Name = "ProcessFile"
        Me.ProcessFile.Size = New System.Drawing.Size(141, 23)
        Me.ProcessFile.TabIndex = 1
        Me.ProcessFile.Text = "Process"
        Me.ProcessFile.UseVisualStyleBackColor = True
        '
        'SaveNew
        '
        Me.SaveNew.Location = New System.Drawing.Point(11, 70)
        Me.SaveNew.Name = "SaveNew"
        Me.SaveNew.Size = New System.Drawing.Size(140, 23)
        Me.SaveNew.TabIndex = 2
        Me.SaveNew.Text = "Save New"
        Me.SaveNew.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(1, 99)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(799, 355)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.SaveNew)
        Me.Controls.Add(Me.ProcessFile)
        Me.Controls.Add(Me.OpenRadonFile)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenRadonFile As Button
    Friend WithEvents ProcessFile As Button
    Friend WithEvents SaveNew As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
