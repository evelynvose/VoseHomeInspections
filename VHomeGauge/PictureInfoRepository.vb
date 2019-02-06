Imports System.ComponentModel



#Region "PictureInfoRepository Class"
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class PictureInfoRepository

    Private m_PictureIdCount As Integer = 0


    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        GetListPictureDetails(1)

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Private m_PictureDictionary As New Dictionary(Of String, String())
    '
    '
    Public Function GetListPictureDetails(ByVal count As Integer) As BindingList(Of PictureInfo)

        Dim picturesDetails As New BindingList(Of PictureInfo)

        picturesDetails.Add(New PictureInfo("C:\Users\Evie.4HI-VM3\Dropbox\_Vose Home Inspections\Marketing\Logo\vosehi_hg_175.jpeg"))

        Return picturesDetails

    End Function




    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '



End Class

#End Region
