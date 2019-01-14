Imports System.IO
Imports System.IO.StreamReader




Public Class Form1


    Private Sub OpenRadonFile_Click(sender As Object, e As EventArgs) Handles OpenRadonFile.Click
        OpenFile()
    End Sub

    Private Sub ProcessFile_Click(sender As Object, e As EventArgs) Handles ProcessFile.Click

    End Sub

    Private Sub SaveNew_Click(sender As Object, e As EventArgs) Handles SaveNew.Click

    End Sub


    Private Sub OpenFile()
        Dim OpenFileDialog1 As New OpenFileDialog
        Dim oReader As StreamReader

        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.DefaultExt = "txt"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog1.Multiselect = False

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            oReader = New StreamReader(OpenFileDialog1.FileName, True)
            RichTextBox1.Text = oReader.ReadToEnd
        End If

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
End Class
