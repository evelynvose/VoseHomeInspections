Imports Syncfusion.Windows.Forms

Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        Me.SfListView1.DataSource = GetDataSource()

    End Sub


    Private Function GetDataSource() As ImageList
        Dim ImageCollection As New ImageList

        Dim theImage = New HiImage
        ImageCollection.Images.Add(theImage.Image)
        ImageCollection.Images.Add(theImage.Image)
        ImageCollection.Images.Add(theImage.Image)

        Return ImageCollection

    End Function


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



End Class

Friend Class HiImage
    Private m_ImagePath As String

    Public Sub New()
        ImagePath = "C:\Users\Evie.4HI-VM3\Pictures\iCloud Photos\Downloads\IMG_4044.jpg"

    End Sub

    Public ReadOnly Property Image As Image
        Get
            Return Image.FromFile(ImagePath)

        End Get
    End Property

    Public Property ImagePath As String
        Get
            If IsNothing(m_ImagePath) Then m_ImagePath = ""
            Return m_ImagePath

        End Get
        Set(value As String)
            If IsNothing(value) Then value = ""
            m_ImagePath = value

        End Set
    End Property





End Class
