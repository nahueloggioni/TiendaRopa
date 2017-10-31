Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Public Class Compras

    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCompras()

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

    Public Sub llenarCompras()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT compras.idCompra,compras.fecha ,sum(detallecompra.precioCosto*detallecompra.cantidad),sum(detallecompra.cantidad),proveedores.razonSocial FROM compras inner JOIN detallecompra on detallecompra.idCompra=compras.idCompra inner JOIN proveedores on compras.idProveedor=proveedores.idProveedor where compras.habilitar like 'SI' and detallecompra.habilitar like 'SI' GROUP BY compras.idCompra"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Compras")
        adp.Fill(ds.Tables("Compras"))

        Me.tablaCompras.DataSource = ds.Tables("Compras")
        Me.tablaCompras.Columns(0).HeaderText = "ID"
        Me.tablaCompras.Columns(0).Width = 30
        Me.tablaCompras.Columns(1).HeaderText = "FECHA"
        Me.tablaCompras.Columns(2).HeaderText = "TOTAL Compra"
        Me.tablaCompras.Columns(3).HeaderText = "CANTIDAD"
        Me.tablaCompras.Columns(3).Width = 80
        Me.tablaCompras.Columns(4).HeaderText = "PROVEEDOR"
        Me.tablaCompras.Columns(4).Width = 150


        tablaCompras.Sort(tablaCompras.Columns(0), ListSortDirection.Descending)

    End Sub

    Public Sub filtrarCompras()
        Dim ds As New DataSet
        Dim dt As New DataTable

        MsgBox(calDesde.Value.Date.ToString & " " & calHasta.Value.Date.ToString)
        Dim sql As String = "SELECT compras.idCompra,compras.fecha ,sum(detallecompra.precioCosto*detallecompra.cantidad),sum(detallecompra.cantidad),proveedores.razonSocial FROM compras inner JOIN detallecompra on detallecompra.idCompra=compras.idCompra inner JOIN proveedores on compras.idProveedor=proveedores.idProveedor "
        sql += " where compras.fecha >= '" & Format(calDesde.Value.Date.ToString, "short date") & "' and compras.fecha <= '" & Format(calHasta.Value.Date.ToString, "short date") & "' and compras.habilitar like 'SI' and detallecompra.habilitar like 'SI' GROUP BY compras.idCompra"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Compras")
        adp.Fill(ds.Tables("Compras"))

        Me.tablaCompras.DataSource = ds.Tables("Compras")
        Me.tablaCompras.Columns(0).HeaderText = "ID"
        Me.tablaCompras.Columns(0).Width = 30
        Me.tablaCompras.Columns(1).HeaderText = "FECHA"
        Me.tablaCompras.Columns(2).HeaderText = "TOTAL Compra"
        Me.tablaCompras.Columns(3).HeaderText = "CANTIDAD"
        Me.tablaCompras.Columns(3).Width = 80
        Me.tablaCompras.Columns(4).HeaderText = "PROVEEDOR"
        Me.tablaCompras.Columns(4).Width = 150


        tablaCompras.Sort(tablaCompras.Columns(0), ListSortDirection.Descending)


    End Sub

    Public Sub llenarDetalleCompra(ByVal idCompra As Integer)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT compras.idCompra,detallecompra.codigoArticulo,articulos.descripcion,detallecompra.precioCosto,detallecompra.cantidad from detallecompra inner JOIN articulos on detallecompra.codigoArticulo=articulos.codigoArticulo INNER JOIN compras on detallecompra.idCompra=compras.idCompra WHERE compras.idCompra=" & idCompra & " and detallecompra.habilitar like 'SI'"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.tablaDetalleCompra.DataSource = ds.Tables("Articulos")
        Me.tablaDetalleCompra.Columns(0).HeaderText = "ID"
        Me.tablaDetalleCompra.Columns(0).Width = 30
        Me.tablaDetalleCompra.Columns(1).HeaderText = "CODIGO ARTICULO"
        Me.tablaDetalleCompra.Columns(2).HeaderText = "DESCRIPCION"
        Me.tablaDetalleCompra.Columns(2).Width = 150
        Me.tablaDetalleCompra.Columns(3).HeaderText = "COSTO"
        Me.tablaDetalleCompra.Columns(4).HeaderText = "CANTIDAD"
        Me.tablaDetalleCompra.Columns(4).Width = 80

        lblID.Text = idCompra

    End Sub

    Private Sub tablaCompras_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tablaCompras.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            llenarDetalleCompra(tablaCompras.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If calDesde.Checked = False And calHasta.Checked = False Then
            llenarCompras()
            tablaDetalleCompra.DataSource = ""
            lblID.Text = ""
        Else
            filtrarCompras()
            tablaDetalleCompra.DataSource = ""
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
End Class