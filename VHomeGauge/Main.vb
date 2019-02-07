Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid
Imports Syncfusion.WinForms.DataGrid.Events

Public Class Main
    '
    ' **********************************************
    ' ****
    ' ******    LOAD handler
    ' ****
    ' **********************************************
    ' 
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' This allows the form to get keypresses.  This is needed for the NUMS lock and CAPS lock status  on the status bar.
        ' The two event handlers below won't be invoked unless this is set to true.
        Me.KeyPreview = True

        ' This is where the picture's path are pulled from the directory and loaded and stored.
        ' Any path that goes in here will have its corresponding picture displayed in the first
        ' column of the dgHiInfo data grid
        Dim thePictureRepository As New PictureRepository

        ' Set up the sfDataGrid picture column to the default row height and colimn width of pictures (150, 200)
        With dgHiInfo
            TryCast(.Columns("Picture"), GridImageColumn).ImageLayout = ImageLayout.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.VerticalAlignment = VerticalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.HorizontalAlignment = HorizontalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).AllowResizing = True
            TryCast(.Columns("Picture"), GridImageColumn).MinimumWidth = 200
            .RowHeight = 150

            ' Set the data source 
            .DataSource = thePictureRepository.GetPictureList("")

        End With
    End Sub



#Region "Methods"
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' *****     CAPS & NUM Lock
    '
    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.CapsLock Then
            With sbPanCapsLock
                If My.Computer.Keyboard.CapsLock Then
                    .Font = New Font(.Font, FontStyle.Bold)

                Else
                    .Font = New Font(.Font, FontStyle.Regular)

                End If
                .Text = "CAP"
            End With
        End If


        If e.KeyCode = Keys.NumLock Then
            With sbPanNumLock
                If My.Computer.Keyboard.NumLock Then
                    .Font = New Font(.Font, FontStyle.Bold)

                Else
                    .Font = New Font(.Font, FontStyle.Regular)

                End If
                .Text = "NUM"
            End With
        End If
    End Sub
    '
    ' ***** Get the path to the pictures
    '
    Private Sub btnPictureBrowser_Click(sender As Object, e As EventArgs) Handles btnPictureBrowser.Click
        Dim FileDialog As FolderBrowserDialog = New FolderBrowserDialog With {
            .ShowNewFolderButton = False
        }
        If FileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim folderPath As String = FileDialog.SelectedPath
            Dim thePictureRepository As New PictureRepository
            dgHiInfo.DataSource = thePictureRepository.GetPictureList(folderPath)

        Else
            MessageBox.Show("Can't load pictures. Folder not found!")

        End If

    End Sub

#End Region
End Class

