Partial Class frmMain

    ' **********************************************
    ' ****
    ' ******    FILL from radon machine's file
    ' ****
    ' **********************************************
    ' 
    Private Sub FillTheForm()

        ' Put up the logo
        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

        With m_DeviceRadonReport

            ' the heart of this app is the radon report


            ' Machine Information
            tbModel.Text = .Model
            tbSerialNo.Text = .SerialNumber

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
            'Specifying row count
            gcDay1.RowCount = 26

            ' Day 1
            Me.tabDay1.Text = .RadDate1
            For i As Integer = 0 To .RadonDataPointsDay1.Count - 1
                gcDay1.Model(i + 1, 1).CellValue = .RadonDataPointsDay1.Item(i).Time
                gcDay1.Model(i + 1, 2).CellValue = .RadonDataPointsDay1.Item(i).Count
                gcDay1.Model(i + 1, 3).CellValue = .RadonDataPointsDay1.Item(i).Flag

            Next

            ' Day 2
            Me.tabDay2.Text = .RadDate2
            For i = 0 To .RadonDataPointsDay2.Count - 1
                gcDay2.Model(i + 1, 1).CellValue = .RadonDataPointsDay2.Item(i).Time
                gcDay2.Model(i + 1, 2).CellValue = .RadonDataPointsDay2.Item(i).Count
                gcDay2.Model(i + 1, 3).CellValue = .RadonDataPointsDay2.Item(i).Flag

            Next

            ' Day 3
            Me.tabDay3.Text = .RadDate3
            For i = 0 To .RadonDataPointsDay3.Count - 1
                gcDay3.Model(i + 1, 1).CellValue = .RadonDataPointsDay3.Item(i).Time
                gcDay3.Model(i + 1, 2).CellValue = .RadonDataPointsDay3.Item(i).Count
                gcDay3.Model(i + 1, 3).CellValue = .RadonDataPointsDay3.Item(i).Flag

            Next

        End With
    End Sub


    ' **********************************************
    ' ****
    ' ******    FILL COMPANY INFORMATION
    ' ****
    ' **********************************************
    ' 
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
End Class