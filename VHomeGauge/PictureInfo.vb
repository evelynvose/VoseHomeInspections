﻿' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Imports System.IO

Public Class PictureInfo
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New(ByVal path As String)
        ' Initialize the members
        m_Path = ""

        If Not IsNothing(path) AndAlso path <> "" Then
            m_Path = path

        End If

    End Sub


    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 
    Private Function ImageToByteArray(ByRef imageIn As System.Drawing.Image) As Byte()
        Dim ms As New MemoryStream
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
        Return ms.ToArray()

    End Function


    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Public ReadOnly Property ID As String
        Get
            Dim theSerialNumber As New SerialNumber
            Return theSerialNumber.Generate
        End Get
    End Property




    Private m_Path As String
    Public Property Path As String
        Get
            Return m_Path
        End Get
        Set(value As String)
            m_Path = value
        End Set
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return System.IO.Path.GetFileName(m_Path)
        End Get
    End Property


    Public ReadOnly Property Picture As Byte()
        Get
            Return ImageToByteArray(Image.FromFile(m_Path))
        End Get
    End Property

    Public ReadOnly Property PictureImage As Image
        Get
            Return Image.FromFile(m_Path)
        End Get
    End Property


End Class
