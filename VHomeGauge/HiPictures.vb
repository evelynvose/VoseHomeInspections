Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools.Navigation
Imports System.Drawing.Image

Public Class HiPictures2
    Public Property HiPictures() As ObservableCollection(Of HIPicture)

    Public Sub New()
        HiPictures = New ObservableCollection(Of HIPicture)()
        Me.GeneratePictures()
    End Sub

    Private Sub GeneratePictures()
        HiPictures.Add(New HIPicture)

    End Sub


End Class

Public Class HIPictures


    Public Sub New()
        MyBase.New

        List.Add(New HIPicture)

    End Sub

    Private m_List As List(Of HIPicture)
    Public ReadOnly Property List As List(Of HIPicture)
        Get
            Return m_List
        End Get
    End Property
End Class

Public Class HIPicture
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private m_PictureId As Integer
    Private m_Path As String
    Private m_Picture As Image

    Public Property PictureID() As Integer
        Get
            Return m_PictureId
        End Get
        Set(ByVal value As Integer)
            m_PictureId = value
        End Set
    End Property

    Public Property PicturePath() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

    Public Property Picture As Image
        Get
            Return m_Picture

        End Get
        Set(value As Image)
            m_Picture = value
        End Set
    End Property


    Public Sub New()
        PicturePath = "C:\Users\Evie.4HI-VM3\iCloudDrive\Desktopesv-stockphoto.png"
        Picture = Image.FromFile(PicturePath)

    End Sub

End Class



