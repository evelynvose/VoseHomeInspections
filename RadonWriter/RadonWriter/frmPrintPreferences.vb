' **********************************************
' ****
' ******    Form Print Properties
' ****
' **********************************************
' 
Public Class frmPrintPreferences
    ' **********************************************
    ' ****
    ' ******    Members
    ' ****
    ' **********************************************
    '
    Private m_PrintPreferences As PrintPreferences

    ' **********************************************
    ' ****
    ' ******    Methods / Events
    ' ****
    ' **********************************************
    ' 
    Private Sub frmPrintPreferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m_printPreferences As New PrintPreferences

        cbIncludeHumidity.Checked = m_printPreferences.IncludeHumidity
        cbIncludeTemperature.Checked = m_printPreferences.IncludeTemperature

    End Sub

    Private Sub frmPrintPreferences_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        With m_PrintPreferences
            .IncludeTemperature = cbIncludeTemperature.Checked
            .IncludeHumidity = cbIncludeHumidity.Checked
        End With
    End Sub
End Class