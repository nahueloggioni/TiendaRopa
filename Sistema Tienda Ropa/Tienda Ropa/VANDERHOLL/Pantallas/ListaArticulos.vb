Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class ListaArticulos

    Private Sub ListaArticulos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        llenarListaArticulos()
    End Sub



    Private Sub ListaArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarListaArticulos()
    End Sub

    Public Sub llenarListaArticulos()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "select codigoArticulo,descripcion,stock ,stockCritico,costoArticulo,precioArticulo,razonSocial from Articulos inner join Proveedores on Articulos.idProveedor=Proveedores.idProveedor where Articulos.habilitar=1"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.DataGridView1.DataSource = ds.Tables("Articulos")
        Me.DataGridView1.Columns(0).HeaderText = "CODIGO"
        Me.DataGridView1.Columns(1).HeaderText = "ARTICULO"
        Me.DataGridView1.Columns(1).Width = 200
        Me.DataGridView1.Columns(2).HeaderText = "STOCK"
        Me.DataGridView1.Columns(3).HeaderText = "STOCK CRITICO"
        Me.DataGridView1.Columns(4).HeaderText = "COSTO"
        Me.DataGridView1.Columns(5).HeaderText = "PRECIO"
        Me.DataGridView1.Columns(6).HeaderText = "PROVEEDOR"

        DataGridView1.Sort(DataGridView1.Columns(2), ListSortDirection.Descending)

    End Sub

    Public Sub filtrarListaArticulos(ByVal filtro As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "select codigoArticulo,descripcion,stock ,stockCritico,costoArticulo,precioArticulo,razonSocial from Articulos inner join "
        sql += "Proveedores on Articulos.idProveedor=Proveedores.idProveedor where Articulos.habilitar=1 and codigoArticulo like '%" & filtro & "%' or descripcion like '%" & filtro & "%'"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.DataGridView1.DataSource = ds.Tables("Articulos")
        Me.DataGridView1.Columns(0).HeaderText = "CODIGO"
        Me.DataGridView1.Columns(1).HeaderText = "ARTICULO"
        Me.DataGridView1.Columns(1).Width = 200
        Me.DataGridView1.Columns(2).HeaderText = "STOCK"
        Me.DataGridView1.Columns(3).HeaderText = "STOCK CRITICO"
        Me.DataGridView1.Columns(4).HeaderText = "COSTO"
        Me.DataGridView1.Columns(5).HeaderText = "PRECIO"
        Me.DataGridView1.Columns(6).HeaderText = "PROVEEDOR"

    End Sub

    Private Sub txtBuscarArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscarArticulo.KeyPress
        Dim caracter As Char = e.KeyChar

        If Not caracter = ChrW(Keys.Space) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBuscarArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarArticulo.TextChanged
        If e.ToString.Equals("") Then
            llenarListaArticulos()
        Else
            filtrarListaArticulos(txtBuscarArticulo.Text.ToString)

        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        Dim datosArt As New Datos_Articulo
        datosArt.art = buscarArticulo(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        datosArt.ShowDialog()

    End Sub



    Private Sub DataGridView1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        If DataGridView1.Rows(e.RowIndex).Cells("Stock").Value = 0 Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        ElseIf DataGridView1.Rows(e.RowIndex).Cells("Stock").Value <= DataGridView1.Rows(e.RowIndex).Cells("stockCritico").Value Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)

        End If
    End Sub
End Class