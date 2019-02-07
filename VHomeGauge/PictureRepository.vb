Imports System.ComponentModel
Imports System.IO



#Region "PictureInfoRepository Class"
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class PictureRepository
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        GetPictureList("")

    End Sub



    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    ' Private m_PictureDictionary As New Dictionary(Of String, String())
    '
    '
    Public Function GetPictureList(ByVal folderpath As String) As BindingList(Of PictureInfo)

        Dim picturesDetails As New BindingList(Of PictureInfo)

        If Not IsNothing(folderpath) AndAlso folderpath = "" Then    ' Set the default picture
            picturesDetails.Add(New PictureInfo(My.Settings.DefaultPictureImagePath))

        Else
            For Each filepath As String In Directory.GetFiles(folderpath)
                If filepath.Contains("Signature") Or filepath.Contains("hgis") Or filepath.Contains("hgix") Or filepath.Contains("hvac") Or filepath.Contains("vosehi") Then
                    ' do nothing

                Else ' do something
                    If filepath.Contains(".jpg") Then
                        picturesDetails.Add(New PictureInfo(filepath))

                    End If
                End If
            Next
        End If


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
