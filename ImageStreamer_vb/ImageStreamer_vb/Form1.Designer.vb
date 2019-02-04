Imports Syncfusion.Windows

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ImageStreamer1 = New Syncfusion.Windows.Forms.Tools.ImageStreamer()
        Me.SuspendLayout()
        '
        'ImageStreamer1
        '
        Me.ImageStreamer1.AllowDragging = True
        Me.ImageStreamer1.Images.Add(CType(resources.GetObject("ImageStreamer1.Images"), System.Drawing.Image))
        Me.ImageStreamer1.Images.Add(CType(resources.GetObject("ImageStreamer1.Images1"), System.Drawing.Image))
        Me.ImageStreamer1.Images.Add(CType(resources.GetObject("ImageStreamer1.Images2"), System.Drawing.Image))
        Me.ImageStreamer1.ImageStreamDirection = Syncfusion.Windows.Forms.Tools.ImageStreamer.StreamDirection.TopToBottom
        Me.ImageStreamer1.InternalBackColor = System.Drawing.Color.Transparent
        Me.ImageStreamer1.Location = New System.Drawing.Point(194, 93)
        Me.ImageStreamer1.Name = "ImageStreamer1"
        Me.ImageStreamer1.Size = New System.Drawing.Size(207, 198)
        Me.ImageStreamer1.SlideShow = True
        Me.ImageStreamer1.TabIndex = 0
        Me.ImageStreamer1.Text = "ImageStreamer1"
        Me.ImageStreamer1.TextAnimationDirection = Syncfusion.Windows.Forms.Tools.ImageStreamer.TextStreamDirection.TopToBottom
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 413)
        Me.Controls.Add(Me.ImageStreamer1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImageStreamer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageStreamer1 As Syncfusion.Windows.Forms.Tools.ImageStreamer
End Class
