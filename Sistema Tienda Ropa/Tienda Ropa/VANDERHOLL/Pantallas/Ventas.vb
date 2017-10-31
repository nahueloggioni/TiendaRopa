Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class Ventas
    Dim indice As Integer
    Shadows menu As ContextMenuStrip

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarVentas()

        ' Set the MinDate and MaxDate.
        calDesde.MinDate = New DateTime(1990, 6, 20)
        calDesde.MaxDate = DateTime.Today
        calDesde.Checked = False

        ' Set the CustomFormat string.
        ' DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"
        calDesde.Format = DateTimePickerFormat.Custom

        ' Show the CheckBox and display the control as an up-down control.
        calDesde.ShowCheckBox = True

        ' Set the MinDate and MaxDate.
        calHasta.MinDate = New DateTime(1990, 6, 20)
        calHasta.MaxDate = DateTime.Today

        ' Set the CustomFormat string.
        ' DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"
        calHasta.Format = DateTimePickerFormat.Custom

        ' Show the CheckBox and display the control as an up-down control.
        calHasta.ShowCheckBox = True
        calHasta.Checked = False
    End Sub

    Public Sub llenarVentas()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT ventas.idVenta,ventas.fecha ,sum(detalleventa.precioArticulo*detalleventa.cantidad),sum(detalleventa.cantidad),tipopago.tipoPago,ventacuota.cuotas FROM ventas inner JOIN `detalleventa` on ventas.idVenta=detalleventa.idVenta inner JOIN tipopago on ventas.idTipoPago=tipopago.idTipoPago inner join ventacuota on ventas.idVenta=ventacuota.idVenta where ventas.habilitar like 'SI' and detalleventa.habilitar like 'SI' GROUP BY ventas.idVenta "
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.tablaVentas.DataSource = ds.Tables("Articulos")
        Me.tablaVentas.Columns(0).HeaderText = "ID"
        Me.tablaVentas.Columns(0).Width = 30
        Me.tablaVentas.Columns(1).HeaderText = "FECHA"
        Me.tablaVentas.Columns(2).HeaderText = "TOTAL VENTA"
        Me.tablaVentas.Columns(3).HeaderText = "CANTIDAD"
        Me.tablaVentas.Columns(3).Width = 80
        Me.tablaVentas.Columns(4).HeaderText = "TIPO PAGO"
        Me.tablaVentas.Columns(5).HeaderText = "CUOTAS"
        Me.tablaVentas.Columns(5).Width = 60

        tablaVentas.Sort(tablaVentas.Columns(0), ListSortDirection.Descending)

    End Sub

    Public Sub filtrarVentas()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT ventas.idVenta,ventas.fecha ,sum(detalleventa.precioArticulo*detalleventa.cantidad),sum(detalleventa.cantidad),tipopago.tipoPago,ventacuota.cuotas FROM ventas inner JOIN `detalleventa` on ventas.idVenta=detalleventa.idVenta inner JOIN tipopago on ventas.idTipoPago=tipopago.idTipoPago inner join ventacuota on ventas.idVenta=ventacuota.idVenta "
        sql += " where ventas.habilitar like 'SI' and detalleventa.habilitar like 'SI' and  ventas.fecha >= '" & Format(calDesde.Value.Date.ToString, "short date") & "' and ventas.fecha <= '" & Format(calHasta.Value.Date.ToString, "short date") & "' GROUP BY ventas.idVenta"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.tablaVentas.DataSource = ds.Tables("Articulos")
        Me.tablaVentas.Columns(0).HeaderText = "ID"
        Me.tablaVentas.Columns(0).Width = 30
        Me.tablaVentas.Columns(1).HeaderText = "FECHA"
        Me.tablaVentas.Columns(2).HeaderText = "TOTAL VENTA"
        Me.tablaVentas.Columns(3).HeaderText = "CANTIDAD"
        Me.tablaVentas.Columns(3).Width = 80
        Me.tablaVentas.Columns(4).HeaderText = "TIPO PAGO"
        Me.tablaVentas.Columns(5).HeaderText = "CUOTAS"
        Me.tablaVentas.Columns(5).Width = 60


    End Sub
    Public Sub llenarDetalleVentas(ByVal idVenta As Integer)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT ventas.idVenta,detalleventa.codigoArticulo,articulos.descripcion,detalleventa.precioArticulo,detalleventa.cantidad from detalleventa inner JOIN articulos on detalleventa.codigoArticulo=articulos.codigoArticulo INNER JOIN ventas on detalleventa.idVenta=ventas.idVenta WHERE ventas.idVenta=" & idVenta & " and detalleventa.habilitar like 'SI'"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.tablaDetalleVenta.DataSource = ds.Tables("Articulos")
        Me.tablaDetalleVenta.Columns(0).HeaderText = "ID"
        Me.tablaDetalleVenta.Columns(0).Width = 30
        Me.tablaDetalleVenta.Columns(1).HeaderText = "CODIGO ARTICULO"
        Me.tablaDetalleVenta.Columns(2).HeaderText = "DESCRIPCION"
        Me.tablaDetalleVenta.Columns(2).Width = 150
        Me.tablaDetalleVenta.Columns(3).HeaderText = "PRECIO"
        Me.tablaDetalleVenta.Columns(4).HeaderText = "CANTIDAD"
        Me.tablaDetalleVenta.Columns(4).Width = 80

        lblID.Text = idVenta

    End Sub

    Private Sub tablaVentas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tablaVentas.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            llenarDetalleVentas(tablaVentas.Rows(e.RowIndex).Cells(0).Value)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If calDesde.Checked = False And calHasta.Checked = False Then
            llenarVentas()
            tablaDetalleVenta.DataSource = ""
            lblID.Text = ""
        Else
            filtrarVentas()
            tablaDetalleVenta.DataSource = ""
            lblID.Text = ""
        End If

    End Sub

    Private Sub calDesde_ValueChanged(sender As Object, e As EventArgs) Handles calDesde.ValueChanged
        ' Set the MinDate and MaxDate.
        calDesde.MinDate = New DateTime(1990, 6, 20)
        calDesde.MaxDate = DateTime.Today

        ' Set the CustomFormat string.
        ' DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"
        calDesde.Format = DateTimePickerFormat.Custom

        ' Show the CheckBox and display the control as an up-down control.
        calDesde.ShowCheckBox = True
    End Sub

    Private Sub calHasta_ValueChanged(sender As Object, e As EventArgs) Handles calHasta.ValueChanged
        ' Set the MinDate and MaxDate.
        calHasta.MinDate = New DateTime(1990, 6, 20)
        calHasta.MaxDate = DateTime.Today

        ' Set the CustomFormat string.
        ' DateTimePicker3.CustomFormat = "MMMM dd, yyyy - dddd"
        calHasta.Format = DateTimePickerFormat.Custom

        ' Show the CheckBox and display the control as an up-down control.
        calHasta.ShowCheckBox = True
    End Sub

    Private Sub tablaVentas_MouseDown(sender As Object, e As MouseEventArgs) Handles tablaVentas.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If tablaVentas.Rows.Count > 0 Then
                Dim Mi_Test As DataGridView.HitTestInfo = Me.tablaVentas.HitTest(e.X, e.Y)
                If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                    If Mi_Test.RowIndex >= 0 Then
                        indice = Mi_Test.RowIndex
                        Me.tablaVentas.CurrentCell = Me.tablaVentas.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                        Me.tablaVentas.Rows(Mi_Test.RowIndex).Selected = True
                        Menu = New ContextMenuStrip()
                        menu.Items.Add("Devolucion", Nothing, New EventHandler(AddressOf devolucionVenta))
                        Me.tablaVentas.ContextMenuStrip = Menu
                    End If
                End If
            Else
            End If
        End If
    End Sub

    Public Sub devolucionVenta()
        Try
            MsgBox("Atencion! La devolucion impilica eliminar la venta", MsgBoxStyle.Critical)
            If MessageBox.Show("Desea realizar la devolucion de esta venta?", "Devolucion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim x As New List(Of Venta)
                Dim idVent As Integer = tablaVentas.Rows(indice).Cells(0).Value
                x = ConsultaVenta(idVent)
                For Each Ventas As Venta In x
                    Dim art As New Articulos
                    art.codigo = Ventas.detalle.codigoArticulo
                    actualizarStockDevolucion(art, Ventas.detalle.cantidad)
                Next
                eliminarVenta(idVent)
                'elminarCuotas(idVent)
                elminarDetalle(idVent)
                MsgBox("Devolucion Completa")
                llenarVentas()
                PantallaPrincipal.actualizarTotalDia()

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub tablaDetalleVenta_MouseDown(sender As Object, e As MouseEventArgs) Handles tablaDetalleVenta.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If tablaDetalleVenta.Rows.Count > 1 Then
                Dim Mi_Test As DataGridView.HitTestInfo = Me.tablaDetalleVenta.HitTest(e.X, e.Y)
                If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                    If Mi_Test.RowIndex >= 0 Then
                        indice = Mi_Test.RowIndex
                        Me.tablaDetalleVenta.CurrentCell = Me.tablaDetalleVenta.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                        Me.tablaDetalleVenta.Rows(Mi_Test.RowIndex).Selected = True
                        menu = New ContextMenuStrip()
                        menu.Items.Add("Devolucion Articulo", Nothing, New EventHandler(AddressOf devolucionArticulo))
                        Me.tablaDetalleVenta.ContextMenuStrip = menu
                    End If
                End If
            Else
            End If
        End If
    End Sub

    Public Sub devolucionArticulo()
        Try
            MsgBox("Atencion! La devolucion impilica eliminar la articulo de la venta", MsgBoxStyle.Critical)
            If MessageBox.Show("Desea realizar la devolucion de este articulo?", "Devolucion Articulo", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim idVent As Integer = tablaDetalleVenta.Rows(indice).Cells(0).Value
                Dim art As New Articulos
                art.codigo = tablaDetalleVenta.Rows(indice).Cells(1).Value
                art.stock = tablaDetalleVenta.Rows(indice).Cells(4).Value
                actualizarStockDevolucion(art, art.stock)
                elminarDetalleArt(idVent, art.codigo)
                MsgBox("Devolucion Completa")
                llenarDetalleVentas(idVent)
                llenarVentas()
                PantallaPrincipal.actualizarTotalDia()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class