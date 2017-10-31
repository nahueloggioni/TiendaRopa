Imports MySql.Data.MySqlClient

Public Class ListaProveedores

    Private Sub ListaProveedoresCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarListaProveedores()

    End Sub
    Public Sub llenarListaProveedores()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT idProveedor,razonSocial,cuit,direccion,ciudad,provincia,telefono ,telefono2,email,banco,cbu FROM Proveedores where habilitar=1"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Proveedores")
        adp.Fill(ds.Tables("Proveedores"))

        Me.DataGridView1.DataSource = ds.Tables("Proveedores")
        Me.DataGridView1.Columns(0).HeaderText = "ID"
        Me.DataGridView1.Columns(0).Width = 50
        Me.DataGridView1.Columns(1).HeaderText = "PROVEEDOR"
        Me.DataGridView1.Columns(8).Width = 120
        Me.DataGridView1.Columns(2).HeaderText = "CUIT"
        Me.DataGridView1.Columns(3).HeaderText = "DIRECCION"
        Me.DataGridView1.Columns(4).HeaderText = "CIUDAD"
        Me.DataGridView1.Columns(5).HeaderText = "PROVINCIA"
        Me.DataGridView1.Columns(6).HeaderText = "TELEFONO"
        Me.DataGridView1.Columns(7).HeaderText = "TELEFONO 2"
        Me.DataGridView1.Columns(8).HeaderText = "EMAIL"
        Me.DataGridView1.Columns(8).Width = 200
        Me.DataGridView1.Columns(9).HeaderText = "BANCO"
        Me.DataGridView1.Columns(10).HeaderText = "CBU"
        Me.DataGridView1.Columns(10).Width = 200
    End Sub
    Public Sub filtraListaProveedores(ByVal filtro As String)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT idProveedor,razonSocial,cuit,direccion,ciudad,provincia,telefono ,telefono2,email FROM Proveedores"
        sql += " where habilitar=1 and razonSocial like '%" & filtro & "%'"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Proveedores")
        adp.Fill(ds.Tables("Proveedores"))

        Me.DataGridView1.DataSource = ds.Tables("Proveedores")
        Me.DataGridView1.Columns(0).HeaderText = "ID"
        Me.DataGridView1.Columns(0).Width = 50
        Me.DataGridView1.Columns(1).HeaderText = "PROVEEDOR"
        Me.DataGridView1.Columns(8).Width = 120
        Me.DataGridView1.Columns(2).HeaderText = "CUIT"
        Me.DataGridView1.Columns(3).HeaderText = "DIRECCION"
        Me.DataGridView1.Columns(4).HeaderText = "CIUDAD"
        Me.DataGridView1.Columns(5).HeaderText = "PROVINCIA"
        Me.DataGridView1.Columns(6).HeaderText = "TELEFONO"
        Me.DataGridView1.Columns(7).HeaderText = "TELEFONO 2"
        Me.DataGridView1.Columns(8).HeaderText = "EMAIL"
        Me.DataGridView1.Columns(8).Width = 200

    End Sub




    Private Sub txtBuscarProv_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProv.TextChanged
        If e.ToString.Equals("") Then
            llenarListaProveedores()
        Else
            filtraListaProveedores(txtBuscarProv.Text.ToString)

        End If
    End Sub
End Class