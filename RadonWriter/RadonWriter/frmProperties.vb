Imports System.ComponentModel

Public Class frmProperties
    Private Sub frmProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
        pbCompanyLogo.Load(My.Settings.CompanyLogoPath)
        tbInspectorsName.Text = My.Settings.InspectorName
        tbInspectorsLicense.Text = My.Settings.InspectorLicense
        tbInspectorsPhone.Text = My.Settings.InspectorPhone
        tbCompanyName.Text = My.Settings.CompanyName
        tbCompanyAddress1.Text = My.Settings.CompanyAddress1
        tbCompanyAddress2.Text = My.Settings.CompanyAddress2
        tbCompanyCity.Text = My.Settings.CompanyCity
        tbCompanyState.Text = My.Settings.CompanyState
        tbCompanyZipCode.Text = My.Settings.CompanyZipCode

    End Sub


    ' Browse for the logo file
    Private Sub btnBrowseLogoFile_Click(sender As Object, e As EventArgs) Handles btnBrowseLogoFile.Click
        ' Browse for the picture file
        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "txt",
            .FileName = "",
            .Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png",
            .Multiselect = False
        }

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.CompanyLogoPath = OpenFileDialog1.FileName
            pbCompanyLogo.Load(My.Settings.CompanyLogoPath)

        End If

    End Sub

    Private Sub frmProperties_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.InspectorName = tbInspectorsName.Text
        My.Settings.InspectorLicense = tbInspectorsLicense.Text
        My.Settings.InspectorPhone = tbInspectorsPhone.Text
        My.Settings.CompanyName = tbCompanyName.Text
        My.Settings.CompanyAddress1 = tbCompanyAddress1.Text
        My.Settings.CompanyAddress2 = tbCompanyAddress2.Text
        My.Settings.CompanyCity = tbCompanyCity.Text
        My.Settings.CompanyState = tbCompanyState.Text
        My.Settings.CompanyZipCode = tbCompanyZipCode.Text


        My.Settings.Save()


    End Sub
End Class