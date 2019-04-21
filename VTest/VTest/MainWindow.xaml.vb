Imports Microsoft.Win32

Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '
        ' Get the image file
        '
        Dim OpenFileDialog1 = New OpenFileDialog With {
           .CheckFileExists = True,
           .CheckPathExists = True,
           .DefaultExt = "png",
           .FileName = "ArcImage",
           .Filter = "Image Files (*.png)|*.png|All Files (*.*)|*.*",
           .Multiselect = False
       }

        If OpenFileDialog1.ShowDialog Then ' = DialogResult.OK Then
            Dim theImage As New BitmapImage()
            With theImage
                .BeginInit()
                .UriSource = New Uri("file://" & OpenFileDialog1.FileName)
                .EndInit()
            End With
            ArcBanner.Source = theImage
            '
        Else
            MsgBox("Sorry, try again!",, "American Red Cross")
            '
        End If

        '
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As RoutedEventArgs) Handles CloseButton.Click
        If MsgBox("Are you sure you want to close this application?", MsgBoxStyle.YesNo, "American Red Cross") = MsgBoxResult.No Then Return
        Close()
        '
    End Sub
End Class
