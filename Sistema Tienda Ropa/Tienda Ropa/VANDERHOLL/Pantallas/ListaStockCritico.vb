Imports MySql.Data.MySqlClient

Public Class ListaStockCritico

    Private Sub ListaStockCritico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarListaArticulosStockCritico()
    End Sub

    Public Sub llenarListaArticulosStockCritico()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "select codigoArticulo,descripcion,stock ,stockCritico,costoArticulo,precioArticulo,razonSocial from Articulos inner join Proveedores on Articulos.idProveedor=Proveedores.idProveedor"
        sql += " where Articulos.habilitar=1 and stock=stockCritico or stock<stockCritico and stock>0"
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
End Class