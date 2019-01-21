<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProperties
    Inherits System.Windows.Forms.Form

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
        Me.lblLogoFilePath = New System.Windows.Forms.Label()
        Me.btnBrowseLogoFile = New System.Windows.Forms.Button()
        Me.pbCompanyLogo = New System.Windows.Forms.PictureBox()
        Me.lblInspectorsName = New System.Windows.Forms.Label()
        Me.tbInspectorsName = New System.Windows.Forms.TextBox()
        Me.tbInspectorsLicense = New System.Windows.Forms.TextBox()
        Me.lblInspectorsLicense = New System.Windows.Forms.Label()
        Me.tbInspectorsPhone = New System.Windows.Forms.TextBox()
        Me.lblInspectorsPhone = New System.Windows.Forms.Label()
        Me.gbInspector = New System.Windows.Forms.GroupBox()
        Me.gbCompany = New System.Windows.Forms.GroupBox()
        Me.tbCompanyAddress2 = New System.Windows.Forms.TextBox()
        Me.tbCompanyZipCode = New System.Windows.Forms.TextBox()
        Me.tbCompanyState = New System.Windows.Forms.TextBox()
        Me.tbCompanyCity = New System.Windows.Forms.TextBox()
        Me.tbCompanyAddress1 = New System.Windows.Forms.TextBox()
        Me.tbCompanyName = New System.Windows.Forms.TextBox()
        Me.lblCompanyZipCode = New System.Windows.Forms.Label()
        Me.lblCompanyState = New System.Windows.Forms.Label()
        Me.lblCompanyCity = New System.Windows.Forms.Label()
        Me.lblCompanyAddress2 = New System.Windows.Forms.Label()
        Me.lblCompanyAddress1 = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.gbReportTemplate = New System.Windows.Forms.GroupBox()
        Me.btnBrowseTemplateFile = New System.Windows.Forms.Button()
        Me.tbTemplatePath = New System.Windows.Forms.TextBox()
        Me.tbTemplateName = New System.Windows.Forms.TextBox()
        Me.lblTemplatePath = New System.Windows.Forms.Label()
        Me.lblTemplateName = New System.Windows.Forms.Label()
        Me.lblCompanyPhone = New System.Windows.Forms.Label()
        Me.tbCompanyPhone = New System.Windows.Forms.TextBox()
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInspector.SuspendLayout()
        Me.gbCompany.SuspendLayout()
        Me.gbReportTemplate.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLogoFilePath
        '
        Me.lblLogoFilePath.AutoSize = True
        Me.lblLogoFilePath.Location = New System.Drawing.Point(30, 13)
        Me.lblLogoFilePath.Name = "lblLogoFilePath"
        Me.lblLogoFilePath.Size = New System.Drawing.Size(53, 13)
        Me.lblLogoFilePath.TabIndex = 0
        Me.lblLogoFilePath.Text = "Logo File:"
        '
        'btnBrowseLogoFile
        '
        Me.btnBrowseLogoFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseLogoFile.Location = New System.Drawing.Point(237, 10)
        Me.btnBrowseLogoFile.Name = "btnBrowseLogoFile"
        Me.btnBrowseLogoFile.Size = New System.Drawing.Size(34, 23)
        Me.btnBrowseLogoFile.TabIndex = 2
        Me.btnBrowseLogoFile.Text = "..."
        Me.btnBrowseLogoFile.UseVisualStyleBackColor = True
        '
        'pbCompanyLogo
        '
        Me.pbCompanyLogo.Location = New System.Drawing.Point(89, 10)
        Me.pbCompanyLogo.Name = "pbCompanyLogo"
        Me.pbCompanyLogo.Size = New System.Drawing.Size(142, 106)
        Me.pbCompanyLogo.TabIndex = 3
        Me.pbCompanyLogo.TabStop = False
        '
        'lblInspectorsName
        '
        Me.lblInspectorsName.AutoSize = True
        Me.lblInspectorsName.Location = New System.Drawing.Point(12, 23)
        Me.lblInspectorsName.Name = "lblInspectorsName"
        Me.lblInspectorsName.Size = New System.Drawing.Size(38, 13)
        Me.lblInspectorsName.TabIndex = 4
        Me.lblInspectorsName.Text = "Name:"
        '
        'tbInspectorsName
        '
        Me.tbInspectorsName.Location = New System.Drawing.Point(86, 19)
        Me.tbInspectorsName.Name = "tbInspectorsName"
        Me.tbInspectorsName.Size = New System.Drawing.Size(139, 20)
        Me.tbInspectorsName.TabIndex = 5
        '
        'tbInspectorsLicense
        '
        Me.tbInspectorsLicense.Location = New System.Drawing.Point(86, 45)
        Me.tbInspectorsLicense.Name = "tbInspectorsLicense"
        Me.tbInspectorsLicense.Size = New System.Drawing.Size(139, 20)
        Me.tbInspectorsLicense.TabIndex = 7
        '
        'lblInspectorsLicense
        '
        Me.lblInspectorsLicense.AutoSize = True
        Me.lblInspectorsLicense.Location = New System.Drawing.Point(12, 49)
        Me.lblInspectorsLicense.Name = "lblInspectorsLicense"
        Me.lblInspectorsLicense.Size = New System.Drawing.Size(47, 13)
        Me.lblInspectorsLicense.TabIndex = 6
        Me.lblInspectorsLicense.Text = "License:"
        '
        'tbInspectorsPhone
        '
        Me.tbInspectorsPhone.Location = New System.Drawing.Point(86, 71)
        Me.tbInspectorsPhone.Name = "tbInspectorsPhone"
        Me.tbInspectorsPhone.Size = New System.Drawing.Size(139, 20)
        Me.tbInspectorsPhone.TabIndex = 9
        '
        'lblInspectorsPhone
        '
        Me.lblInspectorsPhone.AutoSize = True
        Me.lblInspectorsPhone.Location = New System.Drawing.Point(12, 75)
        Me.lblInspectorsPhone.Name = "lblInspectorsPhone"
        Me.lblInspectorsPhone.Size = New System.Drawing.Size(41, 13)
        Me.lblInspectorsPhone.TabIndex = 8
        Me.lblInspectorsPhone.Text = "Phone:"
        '
        'gbInspector
        '
        Me.gbInspector.Controls.Add(Me.tbInspectorsName)
        Me.gbInspector.Controls.Add(Me.tbInspectorsPhone)
        Me.gbInspector.Controls.Add(Me.lblInspectorsName)
        Me.gbInspector.Controls.Add(Me.lblInspectorsPhone)
        Me.gbInspector.Controls.Add(Me.lblInspectorsLicense)
        Me.gbInspector.Controls.Add(Me.tbInspectorsLicense)
        Me.gbInspector.Location = New System.Drawing.Point(33, 132)
        Me.gbInspector.Name = "gbInspector"
        Me.gbInspector.Size = New System.Drawing.Size(249, 105)
        Me.gbInspector.TabIndex = 10
        Me.gbInspector.TabStop = False
        Me.gbInspector.Text = "Inspector's Information"
        '
        'gbCompany
        '
        Me.gbCompany.Controls.Add(Me.tbCompanyPhone)
        Me.gbCompany.Controls.Add(Me.lblCompanyPhone)
        Me.gbCompany.Controls.Add(Me.tbCompanyAddress2)
        Me.gbCompany.Controls.Add(Me.tbCompanyZipCode)
        Me.gbCompany.Controls.Add(Me.tbCompanyState)
        Me.gbCompany.Controls.Add(Me.tbCompanyCity)
        Me.gbCompany.Controls.Add(Me.tbCompanyAddress1)
        Me.gbCompany.Controls.Add(Me.tbCompanyName)
        Me.gbCompany.Controls.Add(Me.lblCompanyZipCode)
        Me.gbCompany.Controls.Add(Me.lblCompanyState)
        Me.gbCompany.Controls.Add(Me.lblCompanyCity)
        Me.gbCompany.Controls.Add(Me.lblCompanyAddress2)
        Me.gbCompany.Controls.Add(Me.lblCompanyAddress1)
        Me.gbCompany.Controls.Add(Me.lblCompanyName)
        Me.gbCompany.Location = New System.Drawing.Point(33, 252)
        Me.gbCompany.Name = "gbCompany"
        Me.gbCompany.Size = New System.Drawing.Size(249, 224)
        Me.gbCompany.TabIndex = 11
        Me.gbCompany.TabStop = False
        Me.gbCompany.Text = "Company Information"
        '
        'tbCompanyAddress2
        '
        Me.tbCompanyAddress2.Location = New System.Drawing.Point(86, 83)
        Me.tbCompanyAddress2.Name = "tbCompanyAddress2"
        Me.tbCompanyAddress2.Size = New System.Drawing.Size(139, 20)
        Me.tbCompanyAddress2.TabIndex = 8
        '
        'tbCompanyZipCode
        '
        Me.tbCompanyZipCode.Location = New System.Drawing.Point(86, 164)
        Me.tbCompanyZipCode.Name = "tbCompanyZipCode"
        Me.tbCompanyZipCode.Size = New System.Drawing.Size(66, 20)
        Me.tbCompanyZipCode.TabIndex = 11
        '
        'tbCompanyState
        '
        Me.tbCompanyState.Location = New System.Drawing.Point(86, 138)
        Me.tbCompanyState.Name = "tbCompanyState"
        Me.tbCompanyState.Size = New System.Drawing.Size(35, 20)
        Me.tbCompanyState.TabIndex = 10
        '
        'tbCompanyCity
        '
        Me.tbCompanyCity.Location = New System.Drawing.Point(86, 112)
        Me.tbCompanyCity.Name = "tbCompanyCity"
        Me.tbCompanyCity.Size = New System.Drawing.Size(83, 20)
        Me.tbCompanyCity.TabIndex = 9
        '
        'tbCompanyAddress1
        '
        Me.tbCompanyAddress1.Location = New System.Drawing.Point(86, 56)
        Me.tbCompanyAddress1.Name = "tbCompanyAddress1"
        Me.tbCompanyAddress1.Size = New System.Drawing.Size(139, 20)
        Me.tbCompanyAddress1.TabIndex = 7
        '
        'tbCompanyName
        '
        Me.tbCompanyName.Location = New System.Drawing.Point(86, 30)
        Me.tbCompanyName.Name = "tbCompanyName"
        Me.tbCompanyName.Size = New System.Drawing.Size(139, 20)
        Me.tbCompanyName.TabIndex = 6
        '
        'lblCompanyZipCode
        '
        Me.lblCompanyZipCode.AutoSize = True
        Me.lblCompanyZipCode.Location = New System.Drawing.Point(12, 168)
        Me.lblCompanyZipCode.Name = "lblCompanyZipCode"
        Me.lblCompanyZipCode.Size = New System.Drawing.Size(53, 13)
        Me.lblCompanyZipCode.TabIndex = 5
        Me.lblCompanyZipCode.Text = "Zip Code:"
        '
        'lblCompanyState
        '
        Me.lblCompanyState.AutoSize = True
        Me.lblCompanyState.Location = New System.Drawing.Point(12, 142)
        Me.lblCompanyState.Name = "lblCompanyState"
        Me.lblCompanyState.Size = New System.Drawing.Size(35, 13)
        Me.lblCompanyState.TabIndex = 4
        Me.lblCompanyState.Text = "State:"
        '
        'lblCompanyCity
        '
        Me.lblCompanyCity.AutoSize = True
        Me.lblCompanyCity.Location = New System.Drawing.Point(12, 115)
        Me.lblCompanyCity.Name = "lblCompanyCity"
        Me.lblCompanyCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCompanyCity.TabIndex = 3
        Me.lblCompanyCity.Text = "City:"
        '
        'lblCompanyAddress2
        '
        Me.lblCompanyAddress2.AutoSize = True
        Me.lblCompanyAddress2.Location = New System.Drawing.Point(12, 86)
        Me.lblCompanyAddress2.Name = "lblCompanyAddress2"
        Me.lblCompanyAddress2.Size = New System.Drawing.Size(57, 13)
        Me.lblCompanyAddress2.TabIndex = 2
        Me.lblCompanyAddress2.Text = "Address 2:"
        '
        'lblCompanyAddress1
        '
        Me.lblCompanyAddress1.AutoSize = True
        Me.lblCompanyAddress1.Location = New System.Drawing.Point(12, 59)
        Me.lblCompanyAddress1.Name = "lblCompanyAddress1"
        Me.lblCompanyAddress1.Size = New System.Drawing.Size(57, 13)
        Me.lblCompanyAddress1.TabIndex = 1
        Me.lblCompanyAddress1.Text = "Address 1:"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(12, 32)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(38, 13)
        Me.lblCompanyName.TabIndex = 0
        Me.lblCompanyName.Text = "Name:"
        '
        'gbReportTemplate
        '
        Me.gbReportTemplate.Controls.Add(Me.btnBrowseTemplateFile)
        Me.gbReportTemplate.Controls.Add(Me.tbTemplatePath)
        Me.gbReportTemplate.Controls.Add(Me.tbTemplateName)
        Me.gbReportTemplate.Controls.Add(Me.lblTemplatePath)
        Me.gbReportTemplate.Controls.Add(Me.lblTemplateName)
        Me.gbReportTemplate.Location = New System.Drawing.Point(301, 132)
        Me.gbReportTemplate.Name = "gbReportTemplate"
        Me.gbReportTemplate.Size = New System.Drawing.Size(238, 100)
        Me.gbReportTemplate.TabIndex = 12
        Me.gbReportTemplate.TabStop = False
        Me.gbReportTemplate.Text = "Report Template"
        '
        'btnBrowseTemplateFile
        '
        Me.btnBrowseTemplateFile.Location = New System.Drawing.Point(64, 71)
        Me.btnBrowseTemplateFile.Name = "btnBrowseTemplateFile"
        Me.btnBrowseTemplateFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseTemplateFile.TabIndex = 4
        Me.btnBrowseTemplateFile.Text = "Browse"
        Me.btnBrowseTemplateFile.UseVisualStyleBackColor = True
        '
        'tbTemplatePath
        '
        Me.tbTemplatePath.Location = New System.Drawing.Point(64, 45)
        Me.tbTemplatePath.Name = "tbTemplatePath"
        Me.tbTemplatePath.Size = New System.Drawing.Size(161, 20)
        Me.tbTemplatePath.TabIndex = 3
        '
        'tbTemplateName
        '
        Me.tbTemplateName.Location = New System.Drawing.Point(64, 19)
        Me.tbTemplateName.Name = "tbTemplateName"
        Me.tbTemplateName.ReadOnly = True
        Me.tbTemplateName.Size = New System.Drawing.Size(139, 20)
        Me.tbTemplateName.TabIndex = 2
        '
        'lblTemplatePath
        '
        Me.lblTemplatePath.AutoSize = True
        Me.lblTemplatePath.Location = New System.Drawing.Point(7, 49)
        Me.lblTemplatePath.Name = "lblTemplatePath"
        Me.lblTemplatePath.Size = New System.Drawing.Size(51, 13)
        Me.lblTemplatePath.TabIndex = 1
        Me.lblTemplatePath.Text = "File Path:"
        '
        'lblTemplateName
        '
        Me.lblTemplateName.AutoSize = True
        Me.lblTemplateName.Location = New System.Drawing.Point(7, 23)
        Me.lblTemplateName.Name = "lblTemplateName"
        Me.lblTemplateName.Size = New System.Drawing.Size(38, 13)
        Me.lblTemplateName.TabIndex = 0
        Me.lblTemplateName.Text = "Name:"
        '
        'lblCompanyPhone
        '
        Me.lblCompanyPhone.AutoSize = True
        Me.lblCompanyPhone.Location = New System.Drawing.Point(12, 195)
        Me.lblCompanyPhone.Name = "lblCompanyPhone"
        Me.lblCompanyPhone.Size = New System.Drawing.Size(41, 13)
        Me.lblCompanyPhone.TabIndex = 12
        Me.lblCompanyPhone.Text = "Phone:"
        '
        'tbCompanyPhone
        '
        Me.tbCompanyPhone.Location = New System.Drawing.Point(86, 191)
        Me.tbCompanyPhone.Name = "tbCompanyPhone"
        Me.tbCompanyPhone.Size = New System.Drawing.Size(100, 20)
        Me.tbCompanyPhone.TabIndex = 13
        '
        'frmProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 497)
        Me.Controls.Add(Me.gbReportTemplate)
        Me.Controls.Add(Me.gbCompany)
        Me.Controls.Add(Me.gbInspector)
        Me.Controls.Add(Me.pbCompanyLogo)
        Me.Controls.Add(Me.btnBrowseLogoFile)
        Me.Controls.Add(Me.lblLogoFilePath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInspector.ResumeLayout(False)
        Me.gbInspector.PerformLayout()
        Me.gbCompany.ResumeLayout(False)
        Me.gbCompany.PerformLayout()
        Me.gbReportTemplate.ResumeLayout(False)
        Me.gbReportTemplate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLogoFilePath As Label
    Friend WithEvents btnBrowseLogoFile As Button
    Friend WithEvents pbCompanyLogo As PictureBox
    Friend WithEvents lblInspectorsName As Label
    Friend WithEvents tbInspectorsName As TextBox
    Friend WithEvents tbInspectorsLicense As TextBox
    Friend WithEvents lblInspectorsLicense As Label
    Friend WithEvents tbInspectorsPhone As TextBox
    Friend WithEvents lblInspectorsPhone As Label
    Friend WithEvents gbInspector As GroupBox
    Friend WithEvents gbCompany As GroupBox
    Friend WithEvents tbCompanyAddress2 As TextBox
    Friend WithEvents tbCompanyZipCode As TextBox
    Friend WithEvents tbCompanyState As TextBox
    Friend WithEvents tbCompanyCity As TextBox
    Friend WithEvents tbCompanyAddress1 As TextBox
    Friend WithEvents tbCompanyName As TextBox
    Friend WithEvents lblCompanyZipCode As Label
    Friend WithEvents lblCompanyState As Label
    Friend WithEvents lblCompanyCity As Label
    Friend WithEvents lblCompanyAddress2 As Label
    Friend WithEvents lblCompanyAddress1 As Label
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents gbReportTemplate As GroupBox
    Friend WithEvents lblTemplatePath As Label
    Friend WithEvents lblTemplateName As Label
    Friend WithEvents btnBrowseTemplateFile As Button
    Friend WithEvents tbTemplatePath As TextBox
    Friend WithEvents tbTemplateName As TextBox
    Friend WithEvents tbCompanyPhone As TextBox
    Friend WithEvents lblCompanyPhone As Label
End Class
