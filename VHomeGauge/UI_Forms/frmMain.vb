
'
' **********************************************
' ****
' ******    Main (Form) Class
' ****
' **********************************************
' 
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools.Events
Imports Syncfusion.WinForms.DataGrid
'
Public Class frmMain
    Inherits MetroForm
    '
    ' ***********************************************
    ' *****     -Main_Load(sender, e)
    ' ***********************************************
    '
    Private m_HasBeenLoaded As Boolean
    '
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        ' This flag prevents the form from recycling
        '
        If m_HasBeenLoaded Then Exit Sub
        m_HasBeenLoaded = True
        '
        ' This allows the form to get keypresses.  This is needed for the NUMS lock and CAPS lock status  on the status bar.
        ' The two event handlers below won't be invoked unless this is set to true.
        '
        Me.KeyPreview = True
        '
        ' Initialize general
        '
        InitializeConnectionString()
        '
        ' Initialize the form elements
        '
        InitializeSplitters()
        InitializeFilmstrip()
        InitializePeopleDataGrid()
        '
        ' Add the open report browser form
        '
        Dim f As New frmReportBrowser
        With f
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            f.Size = scTabs.Panel1.Size
            f.Location = New Point(0, 0)
            f.WindowState = FormWindowState.Normal
            f.Visible = True
            '
        End With
        scTabs.Panel1.Controls.Add(f)
        f.Dock = DockStyle.Fill
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     -InitializeSplitters()
    ' ***********************************************
    '
    Private m_IsSplittersInitialized As Boolean
    '
    Private Sub InitializeSplitters()
        ' Stops repeated calls
        If m_IsSplittersInitialized Then
            MsgBox("Circular loads!")
            Exit Sub
        End If
        m_IsSplittersInitialized = True

        ' Uncomment for debugging initial startup 
        ' My.Settings.SplitterRightDistance = 0
        ' My.Settings.SplitterLeftDistance = 0

        ' Calculate the splitters, if needed
        ' then set them to the user's last known position
        With My.Settings
            If .SplitterLeftDistance = 0 Then .SplitterLeftDistance = 175
            scControlsBase.SplitterDistance = .SplitterLeftDistance

            If .SplitterRightDistance = 0 Then
                My.Settings.SplitterRightDistance = Math.Ceiling(scTabs.Width * 0.8)

            End If
            scTabs.SplitterDistance = .SplitterRightDistance

        End With

    End Sub
    '
    ' ***********************************************
    ' *****     -InitializeFilmstrip():bool
    ' ***********************************************
    '
    Private m_IsFilmstripInitialized As Boolean
    '
    Private Sub InitializeFilmstrip()
        '
        ' Stops Repeated Calls
        '
        If m_IsFilmstripInitialized Then
            MsgBox("Circular loads!")
            Exit Sub
            '
        End If
        m_IsFilmstripInitialized = True
        '
        ' This is where the picture's path are pulled from the directory and loaded and stored.
        ' Any path that goes in here will have its corresponding picture displayed in the first
        ' column of the dgHiInfo data grid
        '
        m_PictureFilter = New PictureFilter
        For Each s As String In My.Settings.PictureFilters
            m_PictureFilter.FilterList.Add(s)
            '
        Next
        With dgFilmstrip
            TryCast(.Columns("Picture"), GridImageColumn).ImageLayout = ImageLayout.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.VerticalAlignment = VerticalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).CellStyle.HorizontalAlignment = HorizontalAlignment.Center
            TryCast(.Columns("Picture"), GridImageColumn).AllowResizing = True
            TryCast(.Columns("Picture"), GridImageColumn).ImageLayout = ImageLayout.Stretch
            '
            ' row height set to an aspect ratio of the expected pictures
            '
            TryCast(.Columns("Picture"), GridImageColumn).MinimumWidth = 160
            .RowHeight = 120
            '
        End With
        '
        ' Load the cbPhotLocker with the intial path
        '
        cbPhotoLocker.Items.Clear()
        cbPhotoLocker.Items.Add(New PictureDirectory(My.Settings.DefaultPictureImagePath))
        '
        ' Set dgPictureInfo data source to the default start up picture repository
        '
        Dim theRepository = New Pictures
        dgFilmstrip.DataSource = theRepository.GetPictureList("")
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -InitializePeopleDataGrid():bool
    ' ***********************************************
    '
    Private m_IsPeopleDataGridInitialized As Boolean
    '
    Private Sub InitializePeopleDataGrid()
        ' Stops repeated calls
        If m_IsPeopleDataGridInitialized Then
            MsgBox("Circular loads!")
            Exit Sub
        End If
        m_IsPeopleDataGridInitialized = True

        If IsNothing(My.Settings.People4DataPath) Then Exit Sub
        If My.Settings.People4DataPath = "" Then Exit Sub

        ' We always start out with the customers showing
        dgPeopleInfo.DataSource = New ClientRepository

    End Sub
    '
    ' ***********************************************
    ' *****     -InitializeConnectionString()
    ' ***********************************************
    '
    Private Sub InitializeConnectionString()
        Dim ta As New vreportsDataSetTableAdapters.ReportMasterTableAdapter
        Dim con As OleDb.OleDbConnection
        con = ta.Connection
        My.Settings.ConnectionString = con.ConnectionString
        '
    End Sub
    '
    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     -m_PictureFilter():picturefilter
    ' ***********************************************
    '    
    Private m_PictureFilter As PictureFilter
    '
    Public ReadOnly Property PictureFilter As PictureFilter
        Get
            Return m_PictureFilter
        End Get
    End Property
    '
    ' **********************************************
    ' ****
    ' ******    Event Handlers
    ' ****
    ' **********************************************
    ' 
    ' ***********************************************
    ' *****     Key Down Event Handler
    ' *****     Caps, Num and Insert key states
    ' ***********************************************
    '
    ' ***********************************************
    ' *****     -Main_KeyDown(sender, e):picturefilter
    ' ***********************************************
    '
    Private m_InsertOvrStateFlag As Boolean
    '
    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        ' CAPS Lock
        '
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
        '
        ' NUM Lock
        '
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
        '
        ' INS Lock
        '
        If e.KeyData = Keys.Insert Then
            With sbPanInsLock
                If m_InsertOvrStateFlag Then
                    m_InsertOvrStateFlag = True
                    .Font = New Font(.Font, FontStyle.Bold)
                    .Text = "OVR"

                Else
                    m_InsertOvrStateFlag = True
                    .Font = New Font(.Font, FontStyle.Regular)
                    .Text = "INS"

                End If
            End With
        End If

    End Sub
    '
    ' ***********************************************
    ' *****     -btnPictureBrowser_Click(sender, e)
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
    ' *****     -cbPhotoLocker_SelectedIndexChanged(sender, e)
    ' *****     Loads new pictures into the filmstrip
    ' ***********************************************
    '
    Private Sub cbPhotoLocker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPhotoLocker.SelectedIndexChanged
        If IsNothing(cbPhotoLocker.Items(cbPhotoLocker.SelectedIndex)) Then
            Exit Sub

        End If

        Dim newPictureDirectoryInfo As PictureDirectory
        newPictureDirectoryInfo = cbPhotoLocker.Items(cbPhotoLocker.SelectedIndex)

        Dim thePictureRepository As New Pictures
        dgFilmstrip.DataSource = thePictureRepository.GetPictureList(newPictureDirectoryInfo.Path)

    End Sub
    '
    ' ***********************************************
    ' *****     -btnContactsClient_Click(sender, e)
    ' *****     Loads new clients into the contacts datagrid
    ' ***********************************************
    '
    Private Sub btnContactsClient_Click(sender As Object, e As EventArgs) Handles btnContactsClient.Click
        Dim newRepository As New ClientRepository
        dgPeopleInfo.DataSource = newRepository.GetList()

        ' Change the image so the user will know what list is being shown
        btnContactsClient.Image = My.Resources.customer_selected
        btnContactsAgent.Image = My.Resources.agent

    End Sub
    '
    ' ***********************************************
    ' *****     -btnContactsAgent_Click(sender, e)
    ' *****     Loads new clients into the contacts datagrid
    ' ***********************************************
    '
    Private Sub btnContactsAgent_Click(sender As Object, e As EventArgs) Handles btnContactsAgent.Click
        Dim newRepository As New AgentRepository
        dgPeopleInfo.DataSource = newRepository.GetList()

        ' Change the image so the user will know what list is being shown
        btnContactsAgent.Image = My.Resources.agent_selected
        btnContactsClient.Image = My.Resources.customer

    End Sub
    '
    ' ***********************************************
    ' *****     -dgPeopleInfo_Click(sender, e)
    ' ***********************************************
    '
    Private Sub dgPeopleInfo_Click(sender As Object, e As EventArgs) Handles dgPeopleInfo.SelectionChanged
        Dim frmPeopleInfo As New frmPeopleInfo(TryCast(dgPeopleInfo.SelectedItem, PersonInfo))
        frmPeopleInfo.ShowDialog()

    End Sub
    '
    ' ***********************************************
    ' *****     -scTabs_SplitterMoved(sender,e)
    ' ***********************************************
    '
    Private Sub scTabs_SplitterMoved(sender As Object, e As SplitterMoveEventArgs) Handles scTabs.SplitterMoved
        My.Settings.SplitterRightDistance = e.NewSplitPosition.X

    End Sub
    '
    ' ***********************************************
    ' *****     -scControlsBase_SplitterMoved(sender, e)
    ' ***********************************************
    '
    Private Sub scControlsBase_SplitterMoved(sender As Object, e As SplitterMoveEventArgs) Handles scControlsBase.SplitterMoved
        My.Settings.SplitterLeftDistance = e.NewSplitPosition.X

    End Sub
    '
    ' ***********************************************
    ' *****     -miMainFileProperties_Click(sender, e)
    ' ***********************************************
    '
    Private Sub miMainFileProperties_Click(sender As Object, e As EventArgs) Handles miMainFileProperties.Click
        Dim theDialog As New dlgMainFileProperties
        theDialog.ShowDialog()
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -miMainTemplateConnectors_Click(sender, e)
    ' ***********************************************
    '
    Private Sub miMainTemplateConnectors_Click(sender As Object, e As EventArgs) Handles miMainTemplateConnectors.Click
        Cursor = Cursors.WaitCursor
        Dim theDialog As New dlgConnectors
        theDialog.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -miMainTemplateSmartText_Click(sedner, e)
    ' ***********************************************
    '
    Private Sub miMainTemplateSmartText_Click(sender As Object, e As EventArgs) Handles miMainTemplateSmartText.Click
        Cursor = Cursors.WaitCursor
        Dim theDialog As New dlgSmartText
        theDialog.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -CommentsToolStripMenuItem_Click(sedner, e)
    ' ***********************************************
    '
    Private Sub CommentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommentsToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim theDialog As New dlgComments
        theDialog.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -SummariesToolStripMenuItem_Click(sedner, e)
    ' ***********************************************
    '
    Private Sub SummariesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummariesToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim theDialog As New dlgSummaries
        theDialog.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
    '
    ' ***********************************************
    ' *****     -CatalogToolStripMenuItem_Click(sedner, e)
    ' ***********************************************
    '
    Private Sub CatalogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalogToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim theDialog As New dlgComments
        theDialog.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
    '
End Class






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

