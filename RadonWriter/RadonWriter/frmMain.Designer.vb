<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim SpreadsheetCopyPaste2 As Syncfusion.Windows.Forms.Spreadsheet.SpreadsheetCopyPaste = New Syncfusion.Windows.Forms.Spreadsheet.SpreadsheetCopyPaste()
        Dim FormulaRangeSelectionController2 As Syncfusion.Windows.Forms.Spreadsheet.FormulaRangeSelectionController = New Syncfusion.Windows.Forms.Spreadsheet.FormulaRangeSelectionController()
        Me.glRadonData = New Syncfusion.Windows.Forms.Grid.GridListControl()
        Me.xGraph = New Syncfusion.Windows.Forms.Spreadsheet.Spreadsheet()
        Me.scTopBottom = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.gbAverages = New System.Windows.Forms.GroupBox()
        Me.glOverallAverage = New Syncfusion.Windows.Forms.Tools.GradientLabel()
        Me.tbOverallAverage = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.tbEpaAverage = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.glEpaAverage = New Syncfusion.Windows.Forms.Tools.GradientLabel()
        Me.gbDevice = New System.Windows.Forms.GroupBox()
        Me.tbDeviceCalibrationDate = New System.Windows.Forms.TextBox()
        Me.lblCalDate = New System.Windows.Forms.Label()
        Me.tbSerialNo = New System.Windows.Forms.TextBox()
        Me.tbModel = New System.Windows.Forms.TextBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.rtCompanyInformation = New System.Windows.Forms.RichTextBox()
        Me.pbCompanyLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbInspectorPhone = New System.Windows.Forms.TextBox()
        Me.tbInspectorLicense = New System.Windows.Forms.TextBox()
        Me.tbInspectorName = New System.Windows.Forms.TextBox()
        Me.lblInspectorPhone = New System.Windows.Forms.Label()
        Me.lblInspectorLicenseNumber = New System.Windows.Forms.Label()
        Me.lblInspectorName = New System.Windows.Forms.Label()
        Me.gbProperty = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tbPropertyCity = New System.Windows.Forms.TextBox()
        Me.lblPropertyCity = New System.Windows.Forms.Label()
        Me.tbPropertyAddress2 = New System.Windows.Forms.TextBox()
        Me.lblPropertyAddress2 = New System.Windows.Forms.Label()
        Me.tbPropertyAddress1 = New System.Windows.Forms.TextBox()
        Me.lblPropertyAddress1 = New System.Windows.Forms.Label()
        Me.gbCustomerInfo = New System.Windows.Forms.GroupBox()
        Me.tbCustomerAddress2 = New System.Windows.Forms.TextBox()
        Me.tbCustomerPhone = New System.Windows.Forms.TextBox()
        Me.lblCustomerPhone = New System.Windows.Forms.Label()
        Me.tbCustomerZipcode = New System.Windows.Forms.TextBox()
        Me.lblCustomerZipcode = New System.Windows.Forms.Label()
        Me.tbCustomerState = New System.Windows.Forms.TextBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.tbCustomerCity = New System.Windows.Forms.TextBox()
        Me.lblCustomerCity = New System.Windows.Forms.Label()
        Me.lblCustomerAddress2 = New System.Windows.Forms.Label()
        Me.tbCustomerAddress1 = New System.Windows.Forms.TextBox()
        Me.lblCustomerAddress1 = New System.Windows.Forms.Label()
        Me.tbCustomerName = New System.Windows.Forms.TextBox()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainFileProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.scSiteData = New Syncfusion.Windows.Forms.Tools.SplitContainerAdv()
        Me.tcSiteData = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.tabDay1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gcDay1 = New Syncfusion.Windows.Forms.Grid.GridControl()
        Me.tabDay2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gcDay2 = New Syncfusion.Windows.Forms.Grid.GridControl()
        Me.tabDay3 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gcDay3 = New Syncfusion.Windows.Forms.Grid.GridControl()
        Me.gbSiteData = New System.Windows.Forms.GroupBox()
        Me.tbSubjectPropertyOrderID = New System.Windows.Forms.TextBox()
        Me.lblOrderID = New System.Windows.Forms.Label()
        Me.cbSubjectPropertyWeather = New System.Windows.Forms.ComboBox()
        Me.cbSubjectPropertyFoundation = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.tbSubjectPropertyLocation = New System.Windows.Forms.TextBox()
        Me.tbSubjectPropertyYearBuilt = New System.Windows.Forms.TextBox()
        Me.tbSubjectPropertySqFt = New System.Windows.Forms.TextBox()
        Me.lblWeather = New System.Windows.Forms.Label()
        Me.lblFoundation = New System.Windows.Forms.Label()
        Me.lblSqFt = New System.Windows.Forms.Label()
        Me.lblYearBuilt = New System.Windows.Forms.Label()
        CType(Me.glRadonData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scTopBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scTopBottom.Panel1.SuspendLayout()
        Me.scTopBottom.Panel2.SuspendLayout()
        Me.scTopBottom.SuspendLayout()
        Me.gbAverages.SuspendLayout()
        CType(Me.tbOverallAverage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEpaAverage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDevice.SuspendLayout()
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbProperty.SuspendLayout()
        Me.gbCustomerInfo.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.scSiteData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSiteData.Panel1.SuspendLayout()
        Me.scSiteData.Panel2.SuspendLayout()
        Me.scSiteData.SuspendLayout()
        CType(Me.tcSiteData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcSiteData.SuspendLayout()
        Me.tabDay1.SuspendLayout()
        CType(Me.gcDay1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDay2.SuspendLayout()
        CType(Me.gcDay2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDay3.SuspendLayout()
        CType(Me.gcDay3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSiteData.SuspendLayout()
        Me.SuspendLayout()
        '
        'glRadonData
        '
        Me.glRadonData.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.glRadonData.BackColor = System.Drawing.SystemColors.Control
        Me.glRadonData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.glRadonData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2016White
        Me.glRadonData.ItemHeight = 17
        Me.glRadonData.Location = New System.Drawing.Point(3, 0)
        Me.glRadonData.Name = "glRadonData"
        Me.glRadonData.Properties.BackgroundColor = System.Drawing.SystemColors.Window
        Me.glRadonData.Properties.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.glRadonData.SelectedIndex = -1
        Me.glRadonData.Size = New System.Drawing.Size(174, 282)
        Me.glRadonData.TabIndex = 0
        Me.glRadonData.TopIndex = 0
        '
        'xGraph
        '
        Me.xGraph.ActiveSheet = Nothing
        Me.xGraph.AllowCellContextMenu = True
        Me.xGraph.AllowExtendRowColumnCount = True
        Me.xGraph.AllowFormulaRangeSelection = True
        Me.xGraph.AllowTabItemContextMenu = True
        Me.xGraph.AllowZooming = True
        SpreadsheetCopyPaste2.AllowPasteOptionPopup = True
        SpreadsheetCopyPaste2.DefaultPasteOption = Syncfusion.Windows.Forms.Spreadsheet.PasteOptions.Paste
        Me.xGraph.CopyPaste = SpreadsheetCopyPaste2
        Me.xGraph.DefaultColumnCount = 101
        Me.xGraph.DefaultRowCount = 101
        Me.xGraph.DisplayAlerts = True
        Me.xGraph.FileName = "Book1"
        Me.xGraph.FormulaBarVisibility = True
        FormulaRangeSelectionController2.AllowMouseSelection = True
        FormulaRangeSelectionController2.AllowSelectionOnEditing = True
        Me.xGraph.FormulaRangeSelectionController = FormulaRangeSelectionController2
        Me.xGraph.IsCustomTabItemContextMenuEnabled = False
        Me.xGraph.Location = New System.Drawing.Point(0, 0)
        Me.xGraph.Name = "xGraph"
        Me.xGraph.SelectedTabIndex = 0
        Me.xGraph.SelectedTabItem = Nothing
        Me.xGraph.ShowBusyIndicator = True
        Me.xGraph.Size = New System.Drawing.Size(595, 282)
        Me.xGraph.TabIndex = 0
        Me.xGraph.TabItemContextMenu = Nothing
        Me.xGraph.Text = "Spreadsheet1"
        Me.xGraph.ThemeName = "Default"
        '
        'scTopBottom
        '
        Me.scTopBottom.BeforeTouchSize = 13
        Me.scTopBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scTopBottom.FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel.Panel1
        Me.scTopBottom.HotExpandLine = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.scTopBottom.Location = New System.Drawing.Point(0, 0)
        Me.scTopBottom.Name = "scTopBottom"
        Me.scTopBottom.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'scTopBottom.Panel1
        '
        Me.scTopBottom.Panel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
        Me.scTopBottom.Panel1.Controls.Add(Me.gbAverages)
        Me.scTopBottom.Panel1.Controls.Add(Me.gbDevice)
        Me.scTopBottom.Panel1.Controls.Add(Me.rtCompanyInformation)
        Me.scTopBottom.Panel1.Controls.Add(Me.pbCompanyLogo)
        Me.scTopBottom.Panel1.Controls.Add(Me.GroupBox1)
        Me.scTopBottom.Panel1.Controls.Add(Me.gbProperty)
        Me.scTopBottom.Panel1.Controls.Add(Me.gbCustomerInfo)
        Me.scTopBottom.Panel1.Controls.Add(Me.MenuStrip2)
        Me.scTopBottom.Panel1MinSize = 225
        '
        'scTopBottom.Panel2
        '
        Me.scTopBottom.Panel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
        Me.scTopBottom.Panel2.Controls.Add(Me.scSiteData)
        Me.scTopBottom.Size = New System.Drawing.Size(784, 576)
        Me.scTopBottom.SplitterDistance = 225
        Me.scTopBottom.SplitterWidth = 13
        Me.scTopBottom.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Office2016Colorful
        Me.scTopBottom.TabIndex = 17
        Me.scTopBottom.Text = "oSplitCon"
        '
        'gbAverages
        '
        Me.gbAverages.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbAverages.Controls.Add(Me.glOverallAverage)
        Me.gbAverages.Controls.Add(Me.tbOverallAverage)
        Me.gbAverages.Controls.Add(Me.tbEpaAverage)
        Me.gbAverages.Controls.Add(Me.glEpaAverage)
        Me.gbAverages.Location = New System.Drawing.Point(382, 137)
        Me.gbAverages.Name = "gbAverages"
        Me.gbAverages.Size = New System.Drawing.Size(200, 85)
        Me.gbAverages.TabIndex = 32
        Me.gbAverages.TabStop = False
        Me.gbAverages.Text = "Averages"
        '
        'glOverallAverage
        '
        Me.glOverallAverage.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(247, Byte), Integer)), System.Drawing.Color.LightCyan)
        Me.glOverallAverage.BeforeTouchSize = New System.Drawing.Size(91, 23)
        Me.glOverallAverage.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
            Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.glOverallAverage.Location = New System.Drawing.Point(10, 51)
        Me.glOverallAverage.Name = "glOverallAverage"
        Me.glOverallAverage.Size = New System.Drawing.Size(91, 23)
        Me.glOverallAverage.TabIndex = 34
        Me.glOverallAverage.Text = "Overall Average:"
        Me.glOverallAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbOverallAverage
        '
        Me.tbOverallAverage.BeforeTouchSize = New System.Drawing.Size(39, 20)
        Me.tbOverallAverage.DoubleValue = 1.0R
        Me.tbOverallAverage.Location = New System.Drawing.Point(107, 52)
        Me.tbOverallAverage.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.tbOverallAverage.Name = "tbOverallAverage"
        Me.tbOverallAverage.NullString = ""
        Me.tbOverallAverage.Size = New System.Drawing.Size(38, 20)
        Me.tbOverallAverage.TabIndex = 33
        Me.tbOverallAverage.Text = "1.00"
        '
        'tbEpaAverage
        '
        Me.tbEpaAverage.BeforeTouchSize = New System.Drawing.Size(39, 20)
        Me.tbEpaAverage.DoubleValue = 1.0R
        Me.tbEpaAverage.Location = New System.Drawing.Point(107, 19)
        Me.tbEpaAverage.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.tbEpaAverage.Name = "tbEpaAverage"
        Me.tbEpaAverage.NullString = ""
        Me.tbEpaAverage.Size = New System.Drawing.Size(39, 20)
        Me.tbEpaAverage.TabIndex = 32
        Me.tbEpaAverage.Text = "1.00"
        '
        'glEpaAverage
        '
        Me.glEpaAverage.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(247, Byte), Integer)), System.Drawing.Color.LightCyan)
        Me.glEpaAverage.BeforeTouchSize = New System.Drawing.Size(79, 23)
        Me.glEpaAverage.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
            Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.glEpaAverage.Location = New System.Drawing.Point(10, 17)
        Me.glEpaAverage.Name = "glEpaAverage"
        Me.glEpaAverage.Size = New System.Drawing.Size(79, 23)
        Me.glEpaAverage.TabIndex = 31
        Me.glEpaAverage.Text = "EPA Average:"
        Me.glEpaAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbDevice
        '
        Me.gbDevice.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbDevice.Controls.Add(Me.tbDeviceCalibrationDate)
        Me.gbDevice.Controls.Add(Me.lblCalDate)
        Me.gbDevice.Controls.Add(Me.tbSerialNo)
        Me.gbDevice.Controls.Add(Me.tbModel)
        Me.gbDevice.Controls.Add(Me.lblSerialNumber)
        Me.gbDevice.Controls.Add(Me.lblModel)
        Me.gbDevice.Location = New System.Drawing.Point(595, 133)
        Me.gbDevice.Name = "gbDevice"
        Me.gbDevice.Size = New System.Drawing.Size(177, 89)
        Me.gbDevice.TabIndex = 31
        Me.gbDevice.TabStop = False
        Me.gbDevice.Text = "Device"
        '
        'tbDeviceCalibrationDate
        '
        Me.tbDeviceCalibrationDate.Location = New System.Drawing.Point(67, 63)
        Me.tbDeviceCalibrationDate.Name = "tbDeviceCalibrationDate"
        Me.tbDeviceCalibrationDate.ReadOnly = True
        Me.tbDeviceCalibrationDate.Size = New System.Drawing.Size(100, 20)
        Me.tbDeviceCalibrationDate.TabIndex = 22
        '
        'lblCalDate
        '
        Me.lblCalDate.AutoSize = True
        Me.lblCalDate.Location = New System.Drawing.Point(8, 67)
        Me.lblCalDate.Name = "lblCalDate"
        Me.lblCalDate.Size = New System.Drawing.Size(51, 13)
        Me.lblCalDate.TabIndex = 21
        Me.lblCalDate.Text = "Cal Date:"
        '
        'tbSerialNo
        '
        Me.tbSerialNo.Location = New System.Drawing.Point(67, 17)
        Me.tbSerialNo.Name = "tbSerialNo"
        Me.tbSerialNo.ReadOnly = True
        Me.tbSerialNo.Size = New System.Drawing.Size(61, 20)
        Me.tbSerialNo.TabIndex = 17
        '
        'tbModel
        '
        Me.tbModel.Location = New System.Drawing.Point(67, 40)
        Me.tbModel.Name = "tbModel"
        Me.tbModel.ReadOnly = True
        Me.tbModel.Size = New System.Drawing.Size(61, 20)
        Me.tbModel.TabIndex = 19
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSerialNumber.Location = New System.Drawing.Point(5, 21)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(56, 13)
        Me.lblSerialNumber.TabIndex = 18
        Me.lblSerialNumber.Text = "Serial No.:"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblModel.Location = New System.Drawing.Point(8, 44)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(39, 13)
        Me.lblModel.TabIndex = 20
        Me.lblModel.Text = "Model:"
        '
        'rtCompanyInformation
        '
        Me.rtCompanyInformation.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rtCompanyInformation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtCompanyInformation.Location = New System.Drawing.Point(6, 165)
        Me.rtCompanyInformation.Name = "rtCompanyInformation"
        Me.rtCompanyInformation.ReadOnly = True
        Me.rtCompanyInformation.Size = New System.Drawing.Size(157, 57)
        Me.rtCompanyInformation.TabIndex = 26
        Me.rtCompanyInformation.Text = ""
        '
        'pbCompanyLogo
        '
        Me.pbCompanyLogo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pbCompanyLogo.Location = New System.Drawing.Point(6, 32)
        Me.pbCompanyLogo.Name = "pbCompanyLogo"
        Me.pbCompanyLogo.Size = New System.Drawing.Size(146, 110)
        Me.pbCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCompanyLogo.TabIndex = 24
        Me.pbCompanyLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.tbInspectorPhone)
        Me.GroupBox1.Controls.Add(Me.tbInspectorLicense)
        Me.GroupBox1.Controls.Add(Me.tbInspectorName)
        Me.GroupBox1.Controls.Add(Me.lblInspectorPhone)
        Me.GroupBox1.Controls.Add(Me.lblInspectorLicenseNumber)
        Me.GroupBox1.Controls.Add(Me.lblInspectorName)
        Me.GroupBox1.Location = New System.Drawing.Point(595, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 100)
        Me.GroupBox1.TabIndex = 23
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
        'lblInspectorLicenseNumber
        '
        Me.lblInspectorLicenseNumber.AutoSize = True
        Me.lblInspectorLicenseNumber.Location = New System.Drawing.Point(6, 49)
        Me.lblInspectorLicenseNumber.Name = "lblInspectorLicenseNumber"
        Me.lblInspectorLicenseNumber.Size = New System.Drawing.Size(47, 13)
        Me.lblInspectorLicenseNumber.TabIndex = 22
        Me.lblInspectorLicenseNumber.Text = "License:"
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
        'gbProperty
        '
        Me.gbProperty.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbProperty.Controls.Add(Me.TextBox1)
        Me.gbProperty.Controls.Add(Me.tbPropertyCity)
        Me.gbProperty.Controls.Add(Me.lblPropertyCity)
        Me.gbProperty.Controls.Add(Me.tbPropertyAddress2)
        Me.gbProperty.Controls.Add(Me.lblPropertyAddress2)
        Me.gbProperty.Controls.Add(Me.tbPropertyAddress1)
        Me.gbProperty.Controls.Add(Me.lblPropertyAddress1)
        Me.gbProperty.Location = New System.Drawing.Point(382, 27)
        Me.gbProperty.Name = "gbProperty"
        Me.gbProperty.Size = New System.Drawing.Size(207, 104)
        Me.gbProperty.TabIndex = 22
        Me.gbProperty.TabStop = False
        Me.gbProperty.Text = "Property"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(66, 120)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 20
        '
        'tbPropertyCity
        '
        Me.tbPropertyCity.Location = New System.Drawing.Point(66, 67)
        Me.tbPropertyCity.Name = "tbPropertyCity"
        Me.tbPropertyCity.Size = New System.Drawing.Size(60, 20)
        Me.tbPropertyCity.TabIndex = 19
        '
        'lblPropertyCity
        '
        Me.lblPropertyCity.AutoSize = True
        Me.lblPropertyCity.Location = New System.Drawing.Point(7, 71)
        Me.lblPropertyCity.Name = "lblPropertyCity"
        Me.lblPropertyCity.Size = New System.Drawing.Size(27, 13)
        Me.lblPropertyCity.TabIndex = 18
        Me.lblPropertyCity.Text = "City:"
        '
        'tbPropertyAddress2
        '
        Me.tbPropertyAddress2.Location = New System.Drawing.Point(66, 42)
        Me.tbPropertyAddress2.Name = "tbPropertyAddress2"
        Me.tbPropertyAddress2.Size = New System.Drawing.Size(130, 20)
        Me.tbPropertyAddress2.TabIndex = 17
        '
        'lblPropertyAddress2
        '
        Me.lblPropertyAddress2.AutoSize = True
        Me.lblPropertyAddress2.Location = New System.Drawing.Point(7, 46)
        Me.lblPropertyAddress2.Name = "lblPropertyAddress2"
        Me.lblPropertyAddress2.Size = New System.Drawing.Size(57, 13)
        Me.lblPropertyAddress2.TabIndex = 16
        Me.lblPropertyAddress2.Text = "Address 2:"
        '
        'tbPropertyAddress1
        '
        Me.tbPropertyAddress1.Location = New System.Drawing.Point(66, 16)
        Me.tbPropertyAddress1.Name = "tbPropertyAddress1"
        Me.tbPropertyAddress1.Size = New System.Drawing.Size(130, 20)
        Me.tbPropertyAddress1.TabIndex = 15
        '
        'lblPropertyAddress1
        '
        Me.lblPropertyAddress1.AutoSize = True
        Me.lblPropertyAddress1.Location = New System.Drawing.Point(7, 20)
        Me.lblPropertyAddress1.Name = "lblPropertyAddress1"
        Me.lblPropertyAddress1.Size = New System.Drawing.Size(57, 13)
        Me.lblPropertyAddress1.TabIndex = 14
        Me.lblPropertyAddress1.Text = "Address 1:"
        '
        'gbCustomerInfo
        '
        Me.gbCustomerInfo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerAddress2)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerPhone)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerPhone)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerZipcode)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerZipcode)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerState)
        Me.gbCustomerInfo.Controls.Add(Me.lblState)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerCity)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerCity)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerAddress2)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerAddress1)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerAddress1)
        Me.gbCustomerInfo.Controls.Add(Me.tbCustomerName)
        Me.gbCustomerInfo.Controls.Add(Me.lblCustomerName)
        Me.gbCustomerInfo.Location = New System.Drawing.Point(169, 27)
        Me.gbCustomerInfo.Name = "gbCustomerInfo"
        Me.gbCustomerInfo.Size = New System.Drawing.Size(207, 195)
        Me.gbCustomerInfo.TabIndex = 21
        Me.gbCustomerInfo.TabStop = False
        Me.gbCustomerInfo.Text = "Customer"
        '
        'tbCustomerAddress2
        '
        Me.tbCustomerAddress2.Location = New System.Drawing.Point(66, 68)
        Me.tbCustomerAddress2.Name = "tbCustomerAddress2"
        Me.tbCustomerAddress2.Size = New System.Drawing.Size(126, 20)
        Me.tbCustomerAddress2.TabIndex = 14
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
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip2.TabIndex = 25
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
        Me.msMainFileSave.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem})
        Me.msMainFileSave.Name = "msMainFileSave"
        Me.msMainFileSave.Size = New System.Drawing.Size(180, 22)
        Me.msMainFileSave.Text = "Save"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PDFToolStripMenuItem.Text = "PDF"
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
        'scSiteData
        '
        Me.scSiteData.BeforeTouchSize = 7
        Me.scSiteData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSiteData.Location = New System.Drawing.Point(0, 0)
        Me.scSiteData.Name = "scSiteData"
        '
        'scSiteData.Panel1
        '
        Me.scSiteData.Panel1.Controls.Add(Me.tcSiteData)
        '
        'scSiteData.Panel2
        '
        Me.scSiteData.Panel2.Controls.Add(Me.gbSiteData)
        Me.scSiteData.Panel2MinSize = 250
        Me.scSiteData.Size = New System.Drawing.Size(784, 338)
        Me.scSiteData.SplitterDistance = 527
        Me.scSiteData.TabIndex = 0
        Me.scSiteData.Text = "scSiteData"
        '
        'tcSiteData
        '
        Me.tcSiteData.ActiveTabColor = System.Drawing.SystemColors.ControlLightLight
        Me.tcSiteData.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.tcSiteData.BeforeTouchSize = New System.Drawing.Size(527, 338)
        Me.tcSiteData.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.tcSiteData.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.tcSiteData.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.tcSiteData.Controls.Add(Me.tabDay1)
        Me.tcSiteData.Controls.Add(Me.tabDay2)
        Me.tcSiteData.Controls.Add(Me.tabDay3)
        Me.tcSiteData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSiteData.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.tcSiteData.Location = New System.Drawing.Point(0, 0)
        Me.tcSiteData.Name = "tcSiteData"
        Me.tcSiteData.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.tcSiteData.ShowSeparator = False
        Me.tcSiteData.Size = New System.Drawing.Size(527, 338)
        Me.tcSiteData.TabIndex = 1
        Me.tcSiteData.TabPanelBackColor = System.Drawing.SystemColors.ControlLightLight
        '
        'tabDay1
        '
        Me.tabDay1.Controls.Add(Me.gcDay1)
        Me.tabDay1.Image = Nothing
        Me.tabDay1.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabDay1.Location = New System.Drawing.Point(1, 25)
        Me.tabDay1.Name = "tabDay1"
        Me.tabDay1.ShowCloseButton = True
        Me.tabDay1.Size = New System.Drawing.Size(524, 311)
        Me.tabDay1.TabIndex = 1
        Me.tabDay1.Text = "Day 1"
        Me.tabDay1.ThemesEnabled = False
        '
        'gcDay1
        '
        Me.gcDay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDay1.Location = New System.Drawing.Point(0, 0)
        Me.gcDay1.Name = "gcDay1"
        Me.gcDay1.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode
        Me.gcDay1.Size = New System.Drawing.Size(524, 311)
        Me.gcDay1.SmartSizeBox = False
        Me.gcDay1.TabIndex = 0
        Me.gcDay1.Text = "gcDay1"
        Me.gcDay1.UseRightToLeftCompatibleTextBox = True
        '
        'tabDay2
        '
        Me.tabDay2.Controls.Add(Me.gcDay2)
        Me.tabDay2.Image = Nothing
        Me.tabDay2.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabDay2.Location = New System.Drawing.Point(1, 25)
        Me.tabDay2.Name = "tabDay2"
        Me.tabDay2.ShowCloseButton = True
        Me.tabDay2.Size = New System.Drawing.Size(524, 311)
        Me.tabDay2.TabIndex = 2
        Me.tabDay2.Text = "Day 2"
        Me.tabDay2.ThemesEnabled = False
        '
        'gcDay2
        '
        Me.gcDay2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDay2.Location = New System.Drawing.Point(0, 0)
        Me.gcDay2.Name = "gcDay2"
        Me.gcDay2.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode
        Me.gcDay2.Size = New System.Drawing.Size(524, 311)
        Me.gcDay2.SmartSizeBox = False
        Me.gcDay2.TabIndex = 0
        Me.gcDay2.Text = "gcDay2"
        Me.gcDay2.UseRightToLeftCompatibleTextBox = True
        '
        'tabDay3
        '
        Me.tabDay3.Controls.Add(Me.gcDay3)
        Me.tabDay3.Image = Nothing
        Me.tabDay3.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabDay3.Location = New System.Drawing.Point(1, 25)
        Me.tabDay3.Name = "tabDay3"
        Me.tabDay3.ShowCloseButton = True
        Me.tabDay3.Size = New System.Drawing.Size(524, 311)
        Me.tabDay3.TabIndex = 3
        Me.tabDay3.Text = "Day 3"
        Me.tabDay3.ThemesEnabled = False
        '
        'gcDay3
        '
        Me.gcDay3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDay3.Location = New System.Drawing.Point(0, 0)
        Me.gcDay3.Name = "gcDay3"
        Me.gcDay3.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode
        Me.gcDay3.Size = New System.Drawing.Size(524, 311)
        Me.gcDay3.SmartSizeBox = False
        Me.gcDay3.TabIndex = 0
        Me.gcDay3.Text = "gcDay3"
        Me.gcDay3.UseRightToLeftCompatibleTextBox = True
        '
        'gbSiteData
        '
        Me.gbSiteData.Controls.Add(Me.tbSubjectPropertyOrderID)
        Me.gbSiteData.Controls.Add(Me.lblOrderID)
        Me.gbSiteData.Controls.Add(Me.cbSubjectPropertyWeather)
        Me.gbSiteData.Controls.Add(Me.cbSubjectPropertyFoundation)
        Me.gbSiteData.Controls.Add(Me.lblLocation)
        Me.gbSiteData.Controls.Add(Me.tbSubjectPropertyLocation)
        Me.gbSiteData.Controls.Add(Me.tbSubjectPropertyYearBuilt)
        Me.gbSiteData.Controls.Add(Me.tbSubjectPropertySqFt)
        Me.gbSiteData.Controls.Add(Me.lblWeather)
        Me.gbSiteData.Controls.Add(Me.lblFoundation)
        Me.gbSiteData.Controls.Add(Me.lblSqFt)
        Me.gbSiteData.Controls.Add(Me.lblYearBuilt)
        Me.gbSiteData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSiteData.Location = New System.Drawing.Point(0, 0)
        Me.gbSiteData.Name = "gbSiteData"
        Me.gbSiteData.Size = New System.Drawing.Size(250, 338)
        Me.gbSiteData.TabIndex = 0
        Me.gbSiteData.TabStop = False
        Me.gbSiteData.Text = "Site Data"
        '
        'tbSubjectPropertyOrderID
        '
        Me.tbSubjectPropertyOrderID.Location = New System.Drawing.Point(89, 175)
        Me.tbSubjectPropertyOrderID.Name = "tbSubjectPropertyOrderID"
        Me.tbSubjectPropertyOrderID.Size = New System.Drawing.Size(100, 20)
        Me.tbSubjectPropertyOrderID.TabIndex = 18
        '
        'lblOrderID
        '
        Me.lblOrderID.AutoSize = True
        Me.lblOrderID.Location = New System.Drawing.Point(17, 179)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(50, 13)
        Me.lblOrderID.TabIndex = 17
        Me.lblOrderID.Text = "Order ID:"
        '
        'cbSubjectPropertyWeather
        '
        Me.cbSubjectPropertyWeather.FormattingEnabled = True
        Me.cbSubjectPropertyWeather.Location = New System.Drawing.Point(89, 143)
        Me.cbSubjectPropertyWeather.Name = "cbSubjectPropertyWeather"
        Me.cbSubjectPropertyWeather.Size = New System.Drawing.Size(121, 21)
        Me.cbSubjectPropertyWeather.TabIndex = 16
        '
        'cbSubjectPropertyFoundation
        '
        Me.cbSubjectPropertyFoundation.FormattingEnabled = True
        Me.cbSubjectPropertyFoundation.Location = New System.Drawing.Point(89, 87)
        Me.cbSubjectPropertyFoundation.Name = "cbSubjectPropertyFoundation"
        Me.cbSubjectPropertyFoundation.Size = New System.Drawing.Size(121, 21)
        Me.cbSubjectPropertyFoundation.TabIndex = 15
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(12, 117)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(51, 13)
        Me.lblLocation.TabIndex = 14
        Me.lblLocation.Text = "Location:"
        '
        'tbSubjectPropertyLocation
        '
        Me.tbSubjectPropertyLocation.Location = New System.Drawing.Point(89, 113)
        Me.tbSubjectPropertyLocation.Name = "tbSubjectPropertyLocation"
        Me.tbSubjectPropertyLocation.Size = New System.Drawing.Size(121, 20)
        Me.tbSubjectPropertyLocation.TabIndex = 13
        '
        'tbSubjectPropertyYearBuilt
        '
        Me.tbSubjectPropertyYearBuilt.Location = New System.Drawing.Point(89, 34)
        Me.tbSubjectPropertyYearBuilt.Name = "tbSubjectPropertyYearBuilt"
        Me.tbSubjectPropertyYearBuilt.Size = New System.Drawing.Size(41, 20)
        Me.tbSubjectPropertyYearBuilt.TabIndex = 12
        '
        'tbSubjectPropertySqFt
        '
        Me.tbSubjectPropertySqFt.Location = New System.Drawing.Point(89, 60)
        Me.tbSubjectPropertySqFt.Name = "tbSubjectPropertySqFt"
        Me.tbSubjectPropertySqFt.Size = New System.Drawing.Size(41, 20)
        Me.tbSubjectPropertySqFt.TabIndex = 9
        '
        'lblWeather
        '
        Me.lblWeather.AutoSize = True
        Me.lblWeather.Location = New System.Drawing.Point(12, 147)
        Me.lblWeather.Name = "lblWeather"
        Me.lblWeather.Size = New System.Drawing.Size(51, 13)
        Me.lblWeather.TabIndex = 7
        Me.lblWeather.Text = "Weather:"
        '
        'lblFoundation
        '
        Me.lblFoundation.AutoSize = True
        Me.lblFoundation.Location = New System.Drawing.Point(12, 90)
        Me.lblFoundation.Name = "lblFoundation"
        Me.lblFoundation.Size = New System.Drawing.Size(63, 13)
        Me.lblFoundation.TabIndex = 6
        Me.lblFoundation.Text = "Foundation:"
        '
        'lblSqFt
        '
        Me.lblSqFt.AutoSize = True
        Me.lblSqFt.Location = New System.Drawing.Point(12, 64)
        Me.lblSqFt.Name = "lblSqFt"
        Me.lblSqFt.Size = New System.Drawing.Size(35, 13)
        Me.lblSqFt.TabIndex = 5
        Me.lblSqFt.Text = "Sq Ft:"
        '
        'lblYearBuilt
        '
        Me.lblYearBuilt.AutoSize = True
        Me.lblYearBuilt.Location = New System.Drawing.Point(12, 38)
        Me.lblYearBuilt.Name = "lblYearBuilt"
        Me.lblYearBuilt.Size = New System.Drawing.Size(55, 13)
        Me.lblYearBuilt.TabIndex = 4
        Me.lblYearBuilt.Text = "Year Built:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 576)
        Me.Controls.Add(Me.scTopBottom)
        Me.MinimumSize = New System.Drawing.Size(800, 490)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Radon Report Writer"
        CType(Me.glRadonData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTopBottom.Panel1.ResumeLayout(False)
        Me.scTopBottom.Panel1.PerformLayout()
        Me.scTopBottom.Panel2.ResumeLayout(False)
        CType(Me.scTopBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTopBottom.ResumeLayout(False)
        Me.gbAverages.ResumeLayout(False)
        Me.gbAverages.PerformLayout()
        CType(Me.tbOverallAverage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEpaAverage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDevice.ResumeLayout(False)
        Me.gbDevice.PerformLayout()
        CType(Me.pbCompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbProperty.ResumeLayout(False)
        Me.gbProperty.PerformLayout()
        Me.gbCustomerInfo.ResumeLayout(False)
        Me.gbCustomerInfo.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.scSiteData.Panel1.ResumeLayout(False)
        Me.scSiteData.Panel2.ResumeLayout(False)
        CType(Me.scSiteData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSiteData.ResumeLayout(False)
        CType(Me.tcSiteData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcSiteData.ResumeLayout(False)
        Me.tabDay1.ResumeLayout(False)
        CType(Me.gcDay1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDay2.ResumeLayout(False)
        CType(Me.gcDay2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDay3.ResumeLayout(False)
        CType(Me.gcDay3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSiteData.ResumeLayout(False)
        Me.gbSiteData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents glRadonData As Syncfusion.Windows.Forms.Grid.GridListControl
    Friend WithEvents xGraph As Syncfusion.Windows.Forms.Spreadsheet.Spreadsheet
    Friend WithEvents scTopBottom As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents rtCompanyInformation As RichTextBox
    Private WithEvents pbCompanyLogo As PictureBox
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents tbInspectorPhone As TextBox
    Private WithEvents tbInspectorLicense As TextBox
    Private WithEvents tbInspectorName As TextBox
    Private WithEvents lblInspectorPhone As Label
    Private WithEvents lblInspectorLicenseNumber As Label
    Private WithEvents lblInspectorName As Label
    Private WithEvents gbProperty As GroupBox
    Private WithEvents tbPropertyCity As TextBox
    Private WithEvents lblPropertyCity As Label
    Private WithEvents tbPropertyAddress2 As TextBox
    Private WithEvents lblPropertyAddress2 As Label
    Private WithEvents tbPropertyAddress1 As TextBox
    Private WithEvents lblPropertyAddress1 As Label
    Private WithEvents gbCustomerInfo As GroupBox
    Private WithEvents tbCustomerPhone As TextBox
    Private WithEvents lblCustomerPhone As Label
    Private WithEvents tbCustomerZipcode As TextBox
    Private WithEvents lblCustomerZipcode As Label
    Private WithEvents tbCustomerState As TextBox
    Private WithEvents lblState As Label
    Private WithEvents tbCustomerCity As TextBox
    Private WithEvents lblCustomerCity As Label
    Private WithEvents lblCustomerAddress2 As Label
    Private WithEvents tbCustomerAddress1 As TextBox
    Private WithEvents lblCustomerAddress1 As Label
    Private WithEvents tbCustomerName As TextBox
    Private WithEvents lblCustomerName As Label
    Private WithEvents lblModel As Label
    Private WithEvents tbModel As TextBox
    Private WithEvents lblSerialNumber As Label
    Private WithEvents tbSerialNo As TextBox
    Private WithEvents MenuStrip2 As MenuStrip
    Private WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Private WithEvents msMainFileOpen As ToolStripMenuItem
    Private WithEvents msMainFileSave As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Private WithEvents msMainFileProperties As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Private WithEvents msMainFileExit As ToolStripMenuItem
    Friend WithEvents tbCustomerAddress2 As TextBox
    Friend WithEvents scSiteData As Syncfusion.Windows.Forms.Tools.SplitContainerAdv
    Friend WithEvents tcSiteData As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents tabDay1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents tabDay2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents tabDay3 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents gcDay1 As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents gcDay2 As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents gcDay3 As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents gbAverages As GroupBox
    Friend WithEvents glOverallAverage As Syncfusion.Windows.Forms.Tools.GradientLabel
    Friend WithEvents tbOverallAverage As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents tbEpaAverage As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents glEpaAverage As Syncfusion.Windows.Forms.Tools.GradientLabel
    Friend WithEvents gbDevice As GroupBox
    Friend WithEvents tbDeviceCalibrationDate As TextBox
    Friend WithEvents lblCalDate As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents gbSiteData As GroupBox
    Friend WithEvents tbSubjectPropertySqFt As TextBox
    Friend WithEvents lblWeather As Label
    Friend WithEvents lblFoundation As Label
    Friend WithEvents lblSqFt As Label
    Friend WithEvents lblYearBuilt As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents tbSubjectPropertyLocation As TextBox
    Friend WithEvents tbSubjectPropertyYearBuilt As TextBox
    Friend WithEvents cbSubjectPropertyWeather As ComboBox
    Friend WithEvents cbSubjectPropertyFoundation As ComboBox
    Friend WithEvents tbSubjectPropertyOrderID As TextBox
    Friend WithEvents lblOrderID As Label
    Friend WithEvents ExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As ToolStripMenuItem
End Class
