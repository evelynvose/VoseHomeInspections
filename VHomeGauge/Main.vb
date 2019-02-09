Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid
'
' **********************************************
' ****
' ******    Main (Form) Class
' ****
' **********************************************
' 
#Region "Main Form Class"
Public Class Main
    '
    ' ***********************************************
    ' *****     Load
    ' ***********************************************
    '
#Region "Load"
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' This allows the form to get keypresses.  This is needed for the NUMS lock and CAPS lock status  on the status bar.
        ' The two event handlers below won't be invoked unless this is set to true.
        Me.KeyPreview = True

        ' This is where the picture's path are pulled from the directory and loaded and stored.
        ' Any path that goes in here will have its corresponding picture displayed in the first
        ' column of the dgHiInfo data grid
        Dim thePictureRepository As New PictureRepository

        m_PictureFilter = New PictureFilter
        For Each s As String In My.Settings.PictureFilters
            m_PictureFilter.FilterList.Add(s)

        Next

        ' Set dgPictureInfo data source to the default start up picture repository
        dgFilmstrip.DataSource = thePictureRepository.GetPictureList("")

        ' Set the column display parameters
        SetPictureInfoColumns()

    End Sub
#End Region
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
#Region "Methods"
    '
    ' ***********************************************
    ' *****     Set Picture Info Columns Method
    ' ***********************************************
    '
    Public Sub SetPictureInfoColumns()
        With dgFilmstrip

            TryCast(.Columns("Picture"), GridImageColumn).ImageLayout = ImageLayout.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.VerticalAlignment = VerticalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.HorizontalAlignment = HorizontalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).AllowResizing = True
            TryCast(.Columns("Picture"), GridImageColumn).ImageLayout = ImageLayout.Stretch

            ' row height set to an aspect ratio of the expected pictures
            TryCast(.Columns("Picture"), GridImageColumn).MinimumWidth = 160
            .RowHeight = 120

            ' These columns will get added because they are properties in PicturInfo
            ' We can't hide them until the DataSource is set, so they have to appear after that
            TryCast(.Columns("Path"), GridTextColumn).Visible = False
            TryCast(.Columns("ID"), GridTextColumn).Visible = False

        End With
    End Sub

#End Region

    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    ' 
#Region "Properties"

    Private m_PictureFilter As PictureFilter
    Public ReadOnly Property PictureFilter As PictureFilter
        Get
            Return m_PictureFilter
        End Get
    End Property
#End Region

    ' **********************************************
    ' ****
    ' ******    Event Handlers
    ' ****
    ' **********************************************
    ' 
#Region "Event Handlers"

    ' ***********************************************
    ' *****     Key Down Event Handler
    ' *****     Caps, Num and Insert key states
    ' ***********************************************
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
    ' ***********************************************
    ' *****     Picture Browser Button Event Handler
    ' ***********************************************
    '
    Private Sub btnPictureBrowser_Click(sender As Object, e As EventArgs) Handles btnPictureBrowser.Click
        Dim FileDialog As FolderBrowserDialog = New FolderBrowserDialog With {
            .ShowNewFolderButton = False
        }
        If FileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim folderPath As String = FileDialog.SelectedPath

            ' Add the original folder to the cbPhotoLocker

            Dim pictureDirectoryInfo As New PictureDirectory(folderPath) ' System.IO.DirectoryInfo(folderPath)
            cbPhotoLocker.Items.Clear()
            cbPhotoLocker.Items.Add(pictureDirectoryInfo)

            ' Get the sub folders
            For Each folderPath In System.IO.Directory.GetDirectories(folderPath)
                pictureDirectoryInfo = New PictureDirectory(folderPath)
                cbPhotoLocker.Items.Add(pictureDirectoryInfo)

            Next

            ' Set the index to the first item, shows the first item
            ' This will fire the cbPhotoLocker.SelectedIndexChanged Event, which will load the pictures
            ' that are in this folder
            cbPhotoLocker.SelectedIndex = 0

        Else
            MessageBox.Show("Can't load pictures. Folder not found!")

        End If

    End Sub
    '
    ' ***********************************************
    ' *****     Photo Locker Drop Down Event Handler
    ' *****     Loads new pictures into the filmstrip
    ' ***********************************************
    '
    Private Sub cbPhotoLocker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPhotoLocker.SelectedIndexChanged
        Dim pictureDirectoryInfo As PictureDirectory
        pictureDirectoryInfo = cbPhotoLocker.Items(cbPhotoLocker.SelectedIndex)

        Dim thePictureRepository As New PictureRepository
        dgFilmstrip.DataSource = thePictureRepository.GetPictureList(pictureDirectoryInfo.Path)
        SetPictureInfoColumns()

    End Sub
    '
    ' ***********************************************
    ' *****     Contact Clients Event Handler
    ' *****     Loads new clients into the contacts datagrid
    ' ***********************************************
    '
    Private Sub btnContactsClient_Click(sender As Object, e As EventArgs) Handles btnContactsClient.Click

        Dim OpenFileDialog1 = New OpenFileDialog With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DefaultExt = "csv",
            .FileName = "",
            .Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
            .Multiselect = False
        }

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim newClientRepository As New PersonRepository
            dgPeopleInfo.DataSource = newClientRepository.GetList(New IO.FileInfo(OpenFileDialog1.FileName), 0)

        End If

    End Sub

#End Region
End Class
#End Region






'
' **********************************************
' ****
' ******    Picture Directory Class
' ****
' **********************************************
' 
Public Class PictureDirectory

    Private m_DirInfo As System.IO.DirectoryInfo

    Public Sub New(ByVal folderpath As String)
        m_DirInfo = New System.IO.DirectoryInfo(folderpath)

    End Sub

    Public Overrides Function ToString() As String
        Return m_DirInfo.Name

    End Function

    Public ReadOnly Property Path As String
        Get
            Return m_DirInfo.FullName

        End Get
    End Property



End Class

