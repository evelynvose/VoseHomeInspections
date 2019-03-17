'
' **********************************************
' ****
' ******    Class
' ****
' **********************************************
'
Imports System.ComponentModel
Imports System.IO
' 
Public Class Pictures
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        ' GetPictureList("")
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
    ' *****     +GetPictureList(string):BindingList(Of Picture)
    ' ***********************************************
    '
    Private m_PictureRepository As IList(Of Picture)
    '
    Public Function GetPictureList(ByVal folderpath As String) As IList(Of Picture)
        '
        Dim m_PictureRepository As New List(Of Picture)
        '
        If Not IsNothing(folderpath) AndAlso folderpath = "" Then    ' Set the default picture
            m_PictureRepository.Add(New Picture(My.Settings.DefaultPictureImagePath))
            '
        Else
            Try
                For Each filepath As String In Directory.GetFiles(folderpath)
                    If Not frmMain.PictureFilter.IsFiltered(filepath) Then
                        If filepath.Contains(".jpg") Then
                            m_PictureRepository.Add(New Picture(filepath))
                            '
                        End If
                    End If
                Next
            Catch e As Exception
                MsgBox(e.Message)
                '
            End Try
            '
        End If
        '
        Return m_PictureRepository
        '
    End Function
    '

    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    ' ***********************************************
    ' *****     +Property(string):string
    ' ***********************************************
    '

End Class
