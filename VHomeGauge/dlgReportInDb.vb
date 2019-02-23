Imports Syncfusion.Windows.Forms

Public Class dlgReportInDb

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If ckUpdateFromReportFile.Checked Then UpdateFlag = True
        Me.Close()
        '
    End Sub

    Private UpdateFlag As Boolean
    Public ReadOnly Property UpdateFromReport As Boolean
        Get
            Return UpdateFlag
        End Get
    End Property
End Class
