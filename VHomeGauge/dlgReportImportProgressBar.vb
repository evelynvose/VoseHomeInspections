Imports Syncfusion.Windows.Forms

Public Class dlgReportImportProgressBar
    Inherits MetroForm


    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick

        If Me.ProgressBarAdv1.Value < 100 Then

            Me.ProgressBarAdv1.Value += 1

        Else

            Me.ProgressBarAdv1.Value = 0

        End If

    End Sub

    Public Sub StartTimer()
        Timer1.Enabled = True

    End Sub

End Class
