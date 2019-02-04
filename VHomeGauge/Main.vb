Imports Syncfusion.Windows.Forms
Imports Syncfusion.WinForms.DataGrid
Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True


    End Sub





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

