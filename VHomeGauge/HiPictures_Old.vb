

Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.IO


Public Class PictureInfoCollection
    Implements IDisposable

    Public Sub New()
        ' OrdersListDetails = New OrderInfoRepository().GetListPicturessDetails(200)

    End Sub


    Public Function GetListPicturesDetails(ByVal count As Integer) As BindingList(Of PictureInfo)

        Dim ordersDetails As New BindingList(Of PictureInfo)()

        For i As Integer = 10000 To count + 10000 - 1
            ordersDetails.Add(GetPicture(i))

        Next i
        Return ordersDetails

    End Function


    Private Function GetPicture(ByVal i As Integer) As PictureInfo
        Dim thePictureInfo As New PictureInfo

        With thePictureInfo
            .PicturePath = "c:\users\evie.4hi-vm3\documents\homegauge\reports\190131191e 1.2\cover1.jpg"
            .Picture = ImageToByteArray(Image.FromFile(.PicturePath))
            .PictureId = 0

        End With

        Return thePictureInfo

    End Function


    Public Function ImageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
        Return ms.ToArray()

    End Function


    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()

    End Sub


End Class




Public Class PictureInfo
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private m_pictureid As Integer
    Private m_path As String
    Private m_picture As Byte()

    Public Property PictureId() As Integer
        Get
            Return m_pictureid
        End Get
        Set(ByVal value As Integer)
            m_pictureid = value
        End Set
    End Property

    Public Property PicturePath() As String
        Get
            Return m_path
        End Get
        Set(ByVal value As String)
            m_path = value
        End Set
    End Property

    Public Property Picture() As Byte()
        Get
            Return m_picture

        End Get
        Set(value As Byte())
            m_picture = value

        End Set
    End Property


End Class



