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
            Try
                For Each filepath As String In Directory.GetFiles(folderpath)
                    If Not frmMain.PictureFilter.IsFiltered(filepath) Then
                        If filepath.Contains(".jpg") Then
                            picturesDetails.Add(New PictureInfo(filepath))

                        End If
                    End If
                Next
            Catch e As Exception
                MsgBox(e.Message)

            End Try

        End If


        Return picturesDetails

    End Function




    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '

    '
    '
End Class
#End Region
