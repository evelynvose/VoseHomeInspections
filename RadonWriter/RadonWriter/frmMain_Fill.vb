
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports Syncfusion.Windows.Forms.Grid


Partial Class frmMain

    ' **********************************************
    ' ****
    ' ******    Methods Continued
    ' ****
    ' **********************************************
    '
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

            ' Device Information
            tbModel.Text = .Device.Model
            tbSerialNo.Text = .Device.SerialNumber
            tbDeviceCalibrationDate.Text = .Device.CalibrationDate

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
            ' Averages
            tbEpaAverage.Text = .EpaAverage
            tbOverallAverage.Text = .OverallAverage

            ' Do the points
            'Specifying row count
            gcDay1.RowCount = 26

            ' Day 1
            Me.tabDay1.Text = .RadDate1

            ' Remove existing columns
            gcDay1.Cols.RemoveRange(1, gcDay1.ColCount)

            ' Put in 4 columns
            gcDay1.Cols.InsertRange(1, 6)

            ' Loop, match date, add row, set data into cells
            Dim row As Integer = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate1 Then
                    gcDay1.Rows.InsertRange(row, 1)
                    gcDay1.Model(row, 1).CellValue = DataPoint.Time
                    gcDay1.Model(row, 2).CellValue = DataPoint.Count
                    gcDay1.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay1.Model(row, 4).CellValue = DataPoint.Flag
                    gcDay1.Model(row, 5).CellValue = DataPoint.Temperature
                    gcDay1.Model(row, 6).CellValue = DataPoint.Humidity
                    row += 1

                End If
            Next

            ' Day 2
            Me.tabDay2.Text = .RadDate2

            ' Remove existing columns
            gcDay2.Cols.RemoveRange(1, gcDay2.ColCount)

            ' Put in 4 columns
            gcDay2.Cols.InsertRange(1, 6)

            ' Loop, match date, add row, set data into cells
            row = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate2 Then
                    gcDay2.Rows.InsertRange(row, 1)
                    gcDay2.Model(row, 1).CellValue = DataPoint.Time
                    gcDay2.Model(row, 2).CellValue = DataPoint.Count
                    gcDay2.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay2.Model(row, 4).CellValue = DataPoint.Flag
                    gcDay2.Model(row, 5).CellValue = DataPoint.Temperature
                    gcDay2.Model(row, 6).CellValue = DataPoint.Humidity

                    row += 1

                End If
            Next


            ' Day 3
            Me.tabDay3.Text = .RadDate3

            ' Remove existing columns
            gcDay3.Cols.RemoveRange(1, gcDay3.ColCount)

            ' Put in 4 columns
            gcDay3.Cols.InsertRange(1, 6)

            ' Loop, match date, add row, set data into cells
            row = 1
            For Each DataPoint As RadonDataPoint In m_DeviceRadonReport.RadonDataPoints
                If DataPoint.ReadingDate = .RadDate3 Then
                    gcDay3.Rows.InsertRange(row, 1)
                    gcDay3.Model(row, 1).CellValue = DataPoint.Time
                    gcDay3.Model(row, 2).CellValue = DataPoint.Count
                    gcDay3.Model(row, 3).CellValue = DataPoint.PCIL
                    gcDay3.Model(row, 4).CellValue = DataPoint.Flag
                    gcDay3.Model(row, 5).CellValue = DataPoint.Temperature
                    gcDay3.Model(row, 6).CellValue = DataPoint.Humidity

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

        Company = New Company
        With Company
            .Phone = My.Settings.CompanyPhone
            .CompanyName = My.Settings.CompanyName
            .Address1 = My.Settings.CompanyAddress1
            .Address2 = My.Settings.CompanyAddress2
            .City = My.Settings.CompanyCity
            .State = My.Settings.CompanyState
            .PostalCode = My.Settings.CompanyZipCode

            rtCompanyInformation.Text = .Phone
            rtCompanyInformation.Text = .Name
            rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf

            If .Address1 <> "" Then
                rtCompanyInformation.Text = rtCompanyInformation.Text + .Address1
                rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf

            End If
            If .Address2 <> "" Then
                rtCompanyInformation.Text = rtCompanyInformation.Text + .Address2
                rtCompanyInformation.Text = rtCompanyInformation.Text + vbCrLf

            End If
            If .City <> "" Then
                rtCompanyInformation.Text = rtCompanyInformation.Text + .City


            End If
            If .State <> "" Then
                rtCompanyInformation.Text = rtCompanyInformation.Text + ", " + .State

            End If
            If .PostalCode <> "" Then
                rtCompanyInformation.Text = rtCompanyInformation.Text + " " + .PostalCode

            End If
        End With


    End Sub


    ' **********************************************
    ' ****
    ' ******    FILL Inspector INFORMATION
    ' ****
    ' **********************************************
    ' 
    Private Sub FillInspectorInformation()
        Inspector = New Inspector
        With Inspector
            .Name = My.Settings.InspectorName
            .License = My.Settings.InspectorLicense
            .Phone = My.Settings.InspectorPhone
            tbInspectorName.Text = .Name
            tbInspectorLicense.Text = .License
            tbInspectorPhone.Text = .Phone
        End With
    End Sub



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
    Public Property Inspector As Inspector
        Get
            Return m_Inspector

        End Get
        Set(value As Inspector)
            m_Inspector = value

        End Set
    End Property
    Private m_Inspector As Inspector

    Public Property Company As Company
        Get
            Return m_Company

        End Get
        Set(value As Company)
            m_Company = value

        End Set
    End Property
    Private m_Company As Company
End Class