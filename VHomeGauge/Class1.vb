Imports Syncfusion.Windows.Forms
Imports GridColumn = Syncfusion.WinForms.DataGrid.GridColumn

Public Class CustomGridColumnSizer
    Inherits Syncfusion.WinForms.DataGrid.AutoSizeController
    Public Sub New(ByVal sfDataGrid As Syncfusion.WinForms.DataGrid.SfDataGrid)
        MyBase.New(sfDataGrid)

    End Sub

    ' Overridden to customize the AutoSizeColumnsMode.Fill logic.
    Protected Overrides Sub SetFillWidth(ByVal remainingColumnWidth As Double, ByVal remainingColumns As IEnumerable(Of GridColumn))
        Dim removedColumn = New List(Of GridColumn)()
        Dim columns = remainingColumns.ToList()
        Dim totalRemainingFillValue = remainingColumnWidth
        Dim removedWidth As Double = 0
        Dim isRemoved As Boolean
        Dim columnscount As Integer

        Do While columns.Count > 0
            isRemoved = False
            removedWidth = 0

            For Each col As GridColumn In columns
                AddHandler GridColumn.columnscount, AddressOf FillRatio.GetColumnRatio

            Next

            Dim fillWidth As Double = Math.Floor((totalRemainingFillValue / columnsCount))
            Dim column = columns.First()
            fillWidth *= FillRatio.GetColumnRatio(column)
            Dim computedWidth As Double = SetColumnWidth(column, CInt(Fix(fillWidth)))

            If fillWidth <> computedWidth AndAlso fillWidth > 0 Then
                isRemoved = True
                columns.Remove(column)
                For Each remColumn As GridColumn In removedColumn
                    If Not columns.Contains(remColumn) Then
                        removedWidth += remColumn.ActualWidth
                        columns.Add(remColumn)
                    End If
                Next remColumn
                removedColumn.Clear()
                totalRemainingFillValue += removedWidth
            End If

            totalRemainingFillValue = totalRemainingFillValue - computedWidth

            If Not isRemoved Then
                columns.Remove(column)
                If Not removedColumn.Contains(column) Then
                    removedColumn.Add(column)
                End If
            End If
        Loop
    End Sub
End Class






Public NotInheritable Class FillRatio
    ' Returns the fill ratio for the column.
    Private Sub New()
    End Sub
    Public Shared Function GetColumnRatio(ByVal column As GridColumn) As Integer
        Dim i As Integer = 0
        Select Case column.MappingName
            Case "OrderID", "CustomerID", "Quantity", "ShipCountry"
                i = 1

            Case "ProductName"
                i = 3

            Case "OrderDate"
                i = 2
        End Select

        Return i
    End Function
End Class
