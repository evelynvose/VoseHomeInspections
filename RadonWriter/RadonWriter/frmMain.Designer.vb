<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.tbSerialNo = New System.Windows.Forms.TextBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.tbModel = New System.Windows.Forms.TextBox()
        Me.gbCustomerInfo = New System.Windows.Forms.GroupBox()
        Me.tbCustomerPhone = New System.Windows.Forms.TextBox()
        Me.lblCustomerPhone = New System.Windows.Forms.Label()
        Me.tbCustomerZipcode = New System.Windows.Forms.TextBox()
        Me.lblCustomerZipcode = New System.Windows.Forms.Label()
        Me.tbCustomerState = New System.Windows.Forms.TextBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.tbCustomerCity = New System.Windows.Forms.TextBox()
        Me.lblCustomerCity = New System.Windows.Forms.Label()
        Me.tbCustomerAddress2 = New System.Windows.Forms.TextBox()
        Me.lblCustomerAddress2 = New System.Windows.Forms.Label()
        Me.tbCustomerAddress1 = New System.Windows.Forms.TextBox()
        Me.lblCustomerAddress1 = New System.Windows.Forms.Label()
        Me.tbCustomerName = New System.Windows.Forms.TextBox()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.gbProperty = New System.Windows.Forms.GroupBox()
        Me.tbPropertyCity = New System.Windows.Forms.TextBox()
        Me.lblPropertyCity = New System.Windows.Forms.Label()
        Me.tbPropertyAddress2 = New System.Windows.Forms.TextBox()
        Me.lblPropertyAddress2 = New System.Windows.Forms.Label()
        Me.tbPropertyAddress1 = New System.Windows.Forms.TextBox()
        Me.lblPropertyAddress1 = New System.Windows.Forms.Label()
        Me.lblInspectorName = New System.Windows.Forms.Label()
        Me.lblInspectorLicenseNumber = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbInspectorPhone = New System.Windows.Forms.TextBox()
        Me.tbInspectorLicense = New System.Windows.Forms.TextBox()
        Me.tbInspectorName = New System.Windows.Forms.TextBox()
        Me.lblInspectorPhone = New System.Windows.Forms.Label()
        Me.pbCompanyLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainFileProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.rtCompanyInformation = New System.Windows.Forms.RichTextBox()
        Me.gbCustomerInfo.SuspendLayout()
        Me.gbProperty.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 247)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(784, 256)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'tbSerialNo
        '
        Me.tbSerialNo.Location = New System.Drawing.Point(669, 49)
        Me.tbSerialNo.Name = "tbSerialNo"
        Me.tbSerialNo.ReadOnly = True
        Me.tbSerialNo.Size = New System.Drawing.Size(61, 20)
        Me.tbSerialNo.TabIndex = 4
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(607, 53)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(56, 13)
        Me.lblSerialNumber.TabIndex = 5
        Me.lblSerialNumber.Text = "Serial No.:"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(607, 79)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(39, 13)
        Me.lblModel.TabIndex = 7
        Me.lblModel.Text = "Model:"
        '
        'tbModel
        '
        Me.tbModel.Location = New System.Drawing.Point(669, 75)
        Me.tbModel.Name = "tbModel"
        Me.tbModel.ReadOnly = True
        Me.tbModel.Size = New System.Drawing.Size(61, 20)
        Me.tbModel.TabIndex = 6
        '
        'gbCustomerInfo
        '
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerPhone)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerPhone)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerZipcode)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerZipcode)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerState)
        Me.gbCustomerInfo.Controls.Add(Me.lblState)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerCity)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerCity)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerAddress2)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerAddress2)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerAddress1)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerAddress1)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerName)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerName)
        Me.gbCustomerInfo.Location = New System.Drawing.Point(175, 34)
        Me.gbCustomerInfo.Name = "gbCustomerInfo"
        Me.gbCustomerInfo.Size = New System.Drawing.Size(207, 195)
        Me.gbCustomerInfo.TabIndex = 8
        Me.gbCustomerInfo.TabStop = False
        Me.gbCustomerInfo.Text = "Customer"
        '
        'tbCustomerPhone
        '
        Me.tbCustomerPhone.Location = New System.Drawing.Point(66, 168)
        Me.tbCustomerPhone.Name = "tbCustomerPhone"
        Me.tbCustomerPhone.Size = New System.Drawing.Size(100, 20)
        Me.tbCustomerPhone.TabIndex = 13
        '
        'lblCustomerPhone
        '
        Me.lblCustomerPhone.AutoSize = True
        Me.lblCustomerPhone.Location = New System.Drawing.Point(6, 172)
        Me.lblCustomerPhone.Name = "lblCustomerPhone"
        Me.lblCustomerPhone.Size = New System.Drawing.Size(41, 13)
        Me.lblCustomerPhone.TabIndex = 12
        Me.lblCustomerPhone.Text = "Phone:"
        '
        'tbCustomerZipcode
        '
        Me.tbCustomerZipcode.Location = New System.Drawing.Point(66, 142)
        Me.tbCustomerZipcode.Name = "tbCustomerZipcode"
        Me.tbCustomerZipcode.Size = New System.Drawing.Size(100, 20)
        Me.tbCustomerZipcode.TabIndex = 11
        '
        'lblCustomerZipcode
        '
        Me.lblCustomerZipcode.AutoSize = True
        Me.lblCustomerZipcode.Location = New System.Drawing.Point(6, 146)
        Me.lblCustomerZipcode.Name = "lblCustomerZipcode"
        Me.lblCustomerZipcode.Size = New System.Drawing.Size(49, 13)
        Me.lblCustomerZipcode.TabIndex = 10
        Me.lblCustomerZipcode.Text = "Zipcode:"
        '
        'tbCustomerState
        '
        Me.tbCustomerState.Location = New System.Drawing.Point(66, 116)
        Me.tbCustomerState.Name = "tbCustomerState"
        Me.tbCustomerState.Size = New System.Drawing.Size(33, 20)
        Me.tbCustomerState.TabIndex = 9
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(6, 120)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 8
        Me.lblState.Text = "State:"
        '
        'tbCustomerCity
        '
        Me.tbCustomerCity.Location = New System.Drawing.Point(66, 92)
        Me.tbCustomerCity.Name = "tbCustomerCity"
        Me.tbCustomerCity.Size = New System.Drawing.Size(60, 20)
        Me.tbCustomerCity.TabIndex = 7
        '
        'lblCustomerCity
        '
        Me.lblCustomerCity.AutoSize = True
        Me.lblCustomerCity.Location = New System.Drawing.Point(6, 96)
        Me.lblCustomerCity.Name = "lblCustomerCity"
        Me.lblCustomerCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCustomerCity.TabIndex = 6
        Me.lblCustomerCity.Text = "City:"
        '
        'tbCustomerAddress2
        '
        Me.tbCustomerAddress2.Location = New System.Drawing.Point(66, 67)
        Me.tbCustomerAddress2.Name = "tbCustomerAddress2"
        Me.tbCustomerAddress2.Size = New System.Drawing.Size(130, 20)
        Me.tbCustomerAddress2.TabIndex = 5
        '
        'lblCustomerAddress2
        '
        Me.lblCustomerAddress2.AutoSize = True
        Me.lblCustomerAddress2.Location = New System.Drawing.Point(6, 71)
        Me.lblCustomerAddress2.Name = "lblCustomerAddress2"
        Me.lblCustomerAddress2.Size = New System.Drawing.Size(57, 13)
        Me.lblCustomerAddress2.TabIndex = 4
        Me.lblCustomerAddress2.Text = "Address 2:"
        '
        'tbCustomerAddress1
        '
        Me.tbCustomerAddress1.Location = New System.Drawing.Point(66, 41)
        Me.tbCustomerAddress1.Name = "tbCustomerAddress1"
        Me.tbCustomerAddress1.Size = New System.Drawing.Size(130, 20)
        Me.tbCustomerAddress1.TabIndex = 3
        '
        'lblCustomerAddress1
        '
        Me.lblCustomerAddress1.AutoSize = True
        Me.lblCustomerAddress1.Location = New System.Drawing.Point(6, 45)
        Me.lblCustomerAddress1.Name = "lblCustomerAddress1"
        Me.lblCustomerAddress1.Size = New System.Drawing.Size(57, 13)
        Me.lblCustomerAddress1.TabIndex = 2
        Me.lblCustomerAddress1.Text = "Address 1:"
        '
        'tbCustomerName
        '
        Me.tbCustomerName.Location = New System.Drawing.Point(66, 15)
        Me.tbCustomerName.Name = "tbCustomerName"
        Me.tbCustomerName.Size = New System.Drawing.Size(130, 20)
        Me.tbCustomerName.TabIndex = 1
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Location = New System.Drawing.Point(6, 19)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(38, 13)
        Me.lblCustomerName.TabIndex = 0
        Me.lblCustomerName.Text = "Name:"
        '
        'gbProperty
        '
        Me.gbProperty.Controls.Add(Me.tbPropertyCity)
        Me.gbProperty.Controls.Add(Me.lblPropertyCity)
        Me.gbProperty.Controls.Add(Me.tbPropertyAddress2)
        Me.gbProperty.Controls.Add(Me.lblPropertyAddress2)
        Me.gbProperty.Controls.Add(Me.tbPropertyAddress1)
        Me.gbProperty.Controls.Add(Me.lblPropertyAddress1)
        Me.gbProperty.Location = New System.Drawing.Point(388, 34)
        Me.gbProperty.Name = "gbProperty"
        Me.gbProperty.Size = New System.Drawing.Size(207, 167)
        Me.gbProperty.TabIndex = 9
        Me.gbProperty.TabStop = False
        Me.gbProperty.Text = "Property"
        '
        'tbPropertyCity
        '
        Me.tbPropertyCity.Location = New System.Drawing.Point(66, 92)
        Me.tbPropertyCity.Name = "tbPropertyCity"
        Me.tbPropertyCity.Size = New System.Drawing.Size(60, 20)
        Me.tbPropertyCity.TabIndex = 19
        '
        'lblPropertyCity
        '
        Me.lblPropertyCity.AutoSize = True
        Me.lblPropertyCity.Location = New System.Drawing.Point(7, 96)
        Me.lblPropertyCity.Name = "lblPropertyCity"
        Me.lblPropertyCity.Size = New System.Drawing.Size(27, 13)
        Me.lblPropertyCity.TabIndex = 18
        Me.lblPropertyCity.Text = "City:"
        '
        'tbPropertyAddress2
        '
        Me.tbPropertyAddress2.Location = New System.Drawing.Point(66, 67)
        Me.tbPropertyAddress2.Name = "tbPropertyAddress2"
        Me.tbPropertyAddress2.Size = New System.Drawing.Size(130, 20)
        Me.tbPropertyAddress2.TabIndex = 17
        '
        'lblPropertyAddress2
        '
        Me.lblPropertyAddress2.AutoSize = True
        Me.lblPropertyAddress2.Location = New System.Drawing.Point(7, 71)
        Me.lblPropertyAddress2.Name = "lblPropertyAddress2"
        Me.lblPropertyAddress2.Size = New System.Drawing.Size(57, 13)
        Me.lblPropertyAddress2.TabIndex = 16
        Me.lblPropertyAddress2.Text = "Address 2:"
        '
        'tbPropertyAddress1
        '
        Me.tbPropertyAddress1.Location = New System.Drawing.Point(66, 41)
        Me.tbPropertyAddress1.Name = "tbPropertyAddress1"
        Me.tbPropertyAddress1.Size = New System.Drawing.Size(130, 20)
        Me.tbPropertyAddress1.TabIndex = 15
        '
        'lblPropertyAddress1
        '
        Me.lblPropertyAddress1.AutoSize = True
        Me.lblPropertyAddress1.Location = New System.Drawing.Point(7, 45)
        Me.lblPropertyAddress1.Name = "lblPropertyAddress1"
        Me.lblPropertyAddress1.Size = New System.Drawing.Size(57, 13)
        Me.lblPropertyAddress1.TabIndex = 14
        Me.lblPropertyAddress1.Text = "Address 1:"
        '
        'lblInspectorName
        '
        Me.lblInspectorName.AutoSize = True
        Me.lblInspectorName.Location = New System.Drawing.Point(6, 24)
        Me.lblInspectorName.Name = "lblInspectorName"
        Me.lblInspectorName.Size = New System.Drawing.Size(38, 13)
        Me.lblInspectorName.TabIndex = 20
        Me.lblInspectorName.Text = "Name:"
        '
        'lblInspectorLicenseNumber
        '
        Me.lblInspectorLicenseNumber.AutoSize = True
        Me.lblInspectorLicenseNumber.Location = New System.Drawing.Point(6, 49)
        Me.lblInspectorLicenseNumber.Name = "lblInspectorLicenseNumber"
        Me.lblInspectorLicenseNumber.Size = New System.Drawing.Size(47, 13)
        Me.lblInspectorLicenseNumber.TabIndex = 22
        Me.lblInspectorLicenseNumber.Text = "License:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbInspectorPhone)
        Me.GroupBox1.Controls.Add(Me.tbInspectorLicense)
        Me.GroupBox1.Controls.Add(Me.tbInspectorName)
        Me.GroupBox1.Controls.Add(Me.lblInspectorPhone)
        Me.GroupBox1.Controls.Add(Me.lblInspectorLicenseNumber)
        Me.GroupBox1.Controls.Add(Me.lblInspectorName)
        Me.GroupBox1.Location = New System.Drawing.Point(601, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 100)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inspector"
        '
        'tbInspectorPhone
        '
        Me.tbInspectorPhone.Location = New System.Drawing.Point(56, 71)
        Me.tbInspectorPhone.Name = "tbInspectorPhone"
        Me.tbInspectorPhone.Size = New System.Drawing.Size(100, 20)
        Me.tbInspectorPhone.TabIndex = 25
        '
        'tbInspectorLicense
        '
        Me.tbInspectorLicense.Location = New System.Drawing.Point(56, 45)
        Me.tbInspectorLicense.Name = "tbInspectorLicense"
        Me.tbInspectorLicense.Size = New System.Drawing.Size(100, 20)
        Me.tbInspectorLicense.TabIndex = 23
        '
        'tbInspectorName
        '
        Me.tbInspectorName.Location = New System.Drawing.Point(56, 20)
        Me.tbInspectorName.Name = "tbInspectorName"
        Me.tbInspectorName.Size = New System.Drawing.Size(100, 20)
        Me.tbInspectorName.TabIndex = 21
        '
        'lblInspectorPhone
        '
        Me.lblInspectorPhone.AutoSize = True
        Me.lblInspectorPhone.Location = New System.Drawing.Point(6, 75)
        Me.lblInspectorPhone.Name = "lblInspectorPhone"
        Me.lblInspectorPhone.Size = New System.Drawing.Size(41, 13)
        Me.lblInspectorPhone.TabIndex = 24
        Me.lblInspectorPhone.Text = "Phone:"
        '
        'pbCompanyLogo
        '
        Me.pbCompanyLogo.Location = New System.Drawing.Point(12, 39)
        Me.pbCompanyLogo.Name = "pbCompanyLogo"
        Me.pbCompanyLogo.Size = New System.Drawing.Size(146, 110)
        Me.pbCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCompanyLogo.TabIndex = 13
        Me.pbCompanyLogo.TabStop = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip2.TabIndex = 15
        Me.MenuStrip2.Text = "msMain"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msMainFileOpen, Me.msMainFileSave, Me.ToolStripMenuItem1, Me.msMainFileProperties, Me.ToolStripMenuItem2, Me.msMainFileExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'msMainFileOpen
        '
        Me.msMainFileOpen.Name = "msMainFileOpen"
        Me.msMainFileOpen.Size = New System.Drawing.Size(180, 22)
        Me.msMainFileOpen.Text = "Open"
        '
        'msMainFileSave
        '
        Me.msMainFileSave.Name = "msMainFileSave"
        Me.msMainFileSave.Size = New System.Drawing.Size(180, 22)
        Me.msMainFileSave.Text = "Save"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'msMainFileProperties
        '
        Me.msMainFileProperties.Name = "msMainFileProperties"
        Me.msMainFileProperties.Size = New System.Drawing.Size(180, 22)
        Me.msMainFileProperties.Text = "Properties"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'msMainFileExit
        '
        Me.msMainFileExit.Name = "msMainFileExit"
        Me.msMainFileExit.Size = New System.Drawing.Size(180, 22)
        Me.msMainFileExit.Text = "Exit"
        '
        'rtCompanyInformation
        '
        Me.rtCompanyInformation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtCompanyInformation.Location = New System.Drawing.Point(12, 172)
        Me.rtCompanyInformation.Name = "rtCompanyInformation"
        Me.rtCompanyInformation.ReadOnly = True
        Me.rtCompanyInformation.Size = New System.Drawing.Size(157, 57)
        Me.rtCompanyInformation.TabIndex = 16
        Me.rtCompanyInformation.Text = ""
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 503)
        Me.Controls.Add(Me.rtCompanyInformation)
        Me.Controls.Add(Me.pbCompanyLogo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbProperty)
        Me.Controls.Add(Me.gbCustomerInfo)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.tbModel)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.tbSerialNo)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MinimumSize = New System.Drawing.Size(800, 490)
        Me.Name = "frmMain"
        Me.Text = "Radon Report Writer"
        Me.gbCustomerInfo.ResumeLayout(False)
        Me.gbCustomerInfo.PerformLayout()
        Me.gbProperty.ResumeLayout(False)
        Me.gbProperty.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents tbSerialNo As TextBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents tbModel As TextBox
    Friend WithEvents gbCustomerInfo As GroupBox
    Friend WithEvents tbCustomerZipcode As TextBox
    Friend WithEvents lblCustomerZipcode As Label
    Friend WithEvents tbCustomerState As TextBox
    Friend WithEvents lblState As Label
    Friend WithEvents tbCustomerCity As TextBox
    Friend WithEvents lblCustomerCity As Label
    Friend WithEvents tbCustomerAddress2 As TextBox
    Friend WithEvents lblCustomerAddress2 As Label
    Friend WithEvents tbCustomerAddress1 As TextBox
    Friend WithEvents lblCustomerAddress1 As Label
    Friend WithEvents tbCustomerName As TextBox
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents gbProperty As GroupBox
    Friend WithEvents tbPropertyCity As TextBox
    Friend WithEvents lblPropertyCity As Label
    Friend WithEvents tbPropertyAddress2 As TextBox
    Friend WithEvents lblPropertyAddress2 As Label
    Friend WithEvents tbPropertyAddress1 As TextBox
    Friend WithEvents lblPropertyAddress1 As Label
    Friend WithEvents lblInspectorName As Label
    Friend WithEvents lblInspectorLicenseNumber As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbInspectorPhone As TextBox
    Friend WithEvents tbInspectorLicense As TextBox
    Friend WithEvents tbInspectorName As TextBox
    Friend WithEvents lblInspectorPhone As Label
    Friend WithEvents pbCompanyLogo As PictureBox
    Friend WithEvents tbCustomerPhone As TextBox
    Friend WithEvents lblCustomerPhone As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents msMainFileOpen As ToolStripMenuItem
    Friend WithEvents msMainFileSave As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents msMainFileProperties As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents msMainFileExit As ToolStripMenuItem
    Friend WithEvents rtCompanyInformation As RichTextBox
End Class
