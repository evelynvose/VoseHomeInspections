Imports Syncfusion.Windows.Forms.Grid


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
            tbModel.Text = .DeviceModel
            tbSerialNo.Text = .DeviceSerialNumber

            ' Customer Information
            tbCustomerName.Text = .Customer.Name
            tbCustomerAddress1.Text = .Customer.Address1
            tbCustomerAddress2.Text = .Customer.Address2
            tbCustomerCity.Text = .Customer.City
            tbCustomerState.Text = .Customer.State
            tbCustomerZipcode.Text = .Customer.PostalCode
            tbCustomerPhone.Text = .Customer.Phone

            ' Inspection Property Information
            tbPropertyAddress1.Text = .SubjectProperty.Address1
            tbPropertyAddress2.Text = .SubjectProperty.Address2
            tbPropertyCity.Text = .SubjectProperty.City

            ' Radon Data
            'Specifying row count
            gcDay1.RowCount = 26

            ' Day 1
            Me.tabDay1.Text = .RadDate1

            ' Remove existing columns
            gcDay1.Cols.RemoveRange(1, gcDay1.ColCount)

            ' Put in 4 columns
            gcDay1.Cols.InsertRange(1, 4)

            ' Loop, match date, add row, set data into cells
            Dim row As Integer = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate1 Then
                    gcDay1.Rows.InsertRange(row, 1)
                    gcDay1.Model(row, 1).CellValue = DataPoint.Time
                    gcDay1.Model(row, 2).CellValue = DataPoint.Count
                    gcDay1.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay1.Model(row, 4).CellValue = DataPoint.Flag
                    row += 1

                End If
            Next

            ' Day 2
            Me.tabDay2.Text = .RadDate2

            ' Remove existing columns
            gcDay2.Cols.RemoveRange(1, gcDay2.ColCount)

            ' Put in 4 columns
            gcDay2.Cols.InsertRange(1, 4)

            ' Loop, match date, add row, set data into cells
            row = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate2 Then
                    gcDay2.Rows.InsertRange(row, 1)
                    gcDay2.Model(row, 1).CellValue = DataPoint.Time
                    gcDay2.Model(row, 2).CellValue = DataPoint.Count
                    gcDay2.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay2.Model(row, 4).CellValue = DataPoint.Flag
                    row += 1

                End If
            Next


            ' Day 3
            Me.tabDay3.Text = .RadDate3

            ' Remove existing columns
            gcDay3.Cols.RemoveRange(1, gcDay3.ColCount)

            ' Put in 4 columns
            gcDay3.Cols.InsertRange(1, 4)

            ' Loop, match date, add row, set data into cells
            row = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate3 Then
                    gcDay3.Rows.InsertRange(row, 1)
                    gcDay3.Model(row, 1).CellValue = DataPoint.Time
                    gcDay3.Model(row, 2).CellValue = DataPoint.Count
                    gcDay3.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay3.Model(row, 4).CellValue = DataPoint.Flag
                    row += 1

                End If
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