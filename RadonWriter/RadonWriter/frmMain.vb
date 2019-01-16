Imports System.IO



Public Class frmMain

    ' The radon report is the heart of this application!
    Private theRadonReport As RadonReport

    ' Initialize the form's variables
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load User Settings
        tbInspectorName.Text = My.Settings.InspectorName
        tbInspectorLicense.Text = My.Settings.InspectorLicense
        tbInspectorPhone.Text = My.Settings.InspectorPhone

        FillCompanyInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

    End Sub

    Private Sub FillCompanyInformation()

        rtCompanyInformation.Text = My.Settings.CompanyName
        rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf
        If My.Settings.CompanyAddress1 <> "" Then
            rtCompanyInformation.Text = rtCompanyInformation.Text + My.Settings.CompanyAddress1
            rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf

        End If
        If My.Settings.CompanyAddress2 <> "" Then
            rtCompanyInformation.Text = rtCompanyInformation.Text + My.Settings.CompanyAddress2
            rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf

        End If
        If My.Settings.CompanyCity <> "" Then
            rtCompanyInformation.Text = rtCompanyInformation.Text + My.Settings.CompanyCity


        End If
        If My.Settings.CompanyState <> "" Then
            rtCompanyInformation.Text = rtCompanyInformation.Text + ", " + My.Settings.CompanyState

        End If
        If My.Settings.CompanyZipCode <> "" Then
            rtCompanyInformation.Text = rtCompanyInformation.Text + " " + My.Settings.CompanyZipCode

        End If
    End Sub

    ' Event Handler
    Private Sub OpenFile()

        ' The heart of this app is the radon report
        theRadonReport = New RadonReport

        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "txt",
            .FileName = "",
            .Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            .Multiselect = False
        }

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            RichTextBox1.Text = ""
            If theRadonReport.OpenReport(OpenFileDialog1.FileName) Then

                FillTheForm()

            End If

        End If

    End Sub

    ' Fill the form from the decomosed radon file
    Private Sub FillTheForm()

        ' Put up the logo
        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

        With theRadonReport

            ' the heart of this app is the radon report
            RichTextBox1.Text = theRadonReport.ReportBody

            ' Machine Information
            tbModel.Text = .Model
            tbSerialNo.Text = .SerialNumber

            ' Inspection Company Information
            'tbCompanyName.Text = .CompanyName
            'tbCompanyAddress1.Text = .CompanyAddress1
            'tbCompanyAddress2.Text = .CompanyAddress2
            'tbCompanyCity.Text = .CompanyCity
            'tbCompanyState.Text = .CompanyState
            'tbCompanyZipcode.Text = .CompanyZipCode

            ' Inspector Information
            ' tbInspectorLicense.Text = .InspectorLicense
            ' tbInspectorPhone.Text = .InspectorPhone

            ' Customer Information
            tbCustomerName.Text = .CustomerName
            tbCustomerAddress1.Text = .CustomerAddress1
            tbCustomerAddress2.Text = .CustomerAddress2
            tbCustomerCity.Text = .CustomerCity
            tbCustomerState.Text = .CustomerState
            tbCustomerZipcode.Text = .CustomerZipCode
            tbCustomerPhone.Text = .CustomerPhone

            ' Inspection Property Information
            tbPropertyAddress1.Text = .InspectionAddess1
            tbPropertyAddress2.Text = .InspectionAddess2
            tbPropertyCity.Text = .InspectionCity

            ' Radon Data


        End With
    End Sub

    Private Sub WriteSpreadsheet()
        'Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        'Dim xls As New Microsoft.Office.Interop.Excel.Application

        'Dim resourcesFolder = IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        'Dim fileName = "book1.xlsx"

        'xlsWorkBook = xls.Workbooks.Open(resourcesFolder & fileName)
        'xlsWorkSheet = xlsWorkBook.Sheets("Sheet1")

        'xlsWorkSheet.Cells(1, 1) = TextBox1.Text

        'xlsWorkBook.Close()
        'xls.Quit()

        'MsgBox("file saved to " & resourcesFolder)
    End Sub


    Private Sub msMainFileProperties_Click(sender As Object, e As EventArgs) Handles msMainFileProperties.Click
        Dim fProperties As New frmProperties

        fProperties.ShowDialog()

        ' Load the new values
        tbInspectorName.Text = My.Settings.InspectorName
        tbInspectorLicense.Text = My.Settings.InspectorLicense
        tbInspectorPhone.Text = My.Settings.InspectorPhone

        FillCompanyInformation()

        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

    End Sub

    Private Sub msMainFileOpen_Click(sender As Object, e As EventArgs) Handles msMainFileOpen.Click
        OpenFile()

    End Sub

    Private Sub msMainFileExit_Click(sender As Object, e As EventArgs) Handles msMainFileExit.Click
        Application.Exit()

    End Sub

    Private Sub msMainFileSave_Click(sender As Object, e As EventArgs) Handles msMainFileSave.Click
        WriteSpreadsheet()

    End Sub
End Class
