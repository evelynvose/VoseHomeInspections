Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports SyncfusionWindowsFormsApplication1

#Region "PictureInfoCollection Class"

' **********************************************
' ****
' ******    Class
' ****
' **********************************************
' 
Public Class PictureInfoCollection
    Implements IDisposable
    '
    ' **********************************************
    ' ****
    ' ******    Constructor
    ' ****
    ' **********************************************
    ' 
    Public Sub New()
        ' Here is where you define and fill the repository.

    End Sub

    ' **********************************************
    ' ****
    ' ******    Methods
    ' ****
    ' **********************************************
    ' 



    ' **********************************************
    ' ****
    ' ******    Properties
    ' ****
    ' **********************************************
    '
    Private m_PicturesListDetails As BindingList(Of PictureInfo)
    Public Property PicturesListDetails As BindingList(Of PictureInfo)
        Get
            Return m_PicturesListDetails
        End Get
        Set(value As BindingList(Of PictureInfo))
            m_PicturesListDetails = value
        End Set
    End Property



    ' **********************************************
    ' ****
    ' ******    Interfaces
    ' ****
    ' **********************************************
    ' 
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)

        If Not IsNothing(PicturesListDetails) Then
            PicturesListDetails.Clear()

        End If
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
#End Region



