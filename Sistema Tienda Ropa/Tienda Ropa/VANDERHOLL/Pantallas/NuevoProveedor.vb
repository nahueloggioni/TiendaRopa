Imports MySql.Data.MySqlClient

Public Class NuevoProveedor



    Private Sub NuevoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As New DataSet

        sql = "select * from Provincias "
        Dim nuevoda = New MySqlDataAdapter(sql, conex)
        nuevoda.Fill(ds, "Provincias")
        Me.comboProvincia.DataSource = ds.Tables("Provincias")
        Me.comboProvincia.DisplayMember = "provincia"
        Me.comboProvincia.ValueMember = "id"

        Me.comboProvincia.SelectedIndex = 21
        llenarComboCiudades(comboProvincia.SelectedValue)
        Me.comboCiudad.SelectedIndex = 46
    End Sub

    Private Sub llenarComboCiudades(ByVal id As String)
        Dim ds As New DataSet
        sql = "select ciudades.* from ciudades inner join Provincias on Ciudades.id_provincia = Provincias.id	where Provincias.id =" + id
        Dim nuevoda = New MySqlDataAdapter(sql, conex)
        nuevoda.Fill(ds, "Ciudades")
        Me.comboCiudad.DataSource = ds.Tables("Ciudades")
        Me.comboCiudad.DisplayMember = "localidad"
        Me.comboCiudad.ValueMember = "id"
    End Sub
    Private Sub comboProvincia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProvincia.SelectionChangeCommitted
        llenarComboCiudades(comboProvincia.SelectedValue.ToString)
    End Sub




    Private Sub txtCBU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCBU.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar

        ' comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As String
        p = txtRazonSocial.Text.Replace(" ", "")
        If p = "" Then
            MsgBox("Complete la Razon Social")
        Else
            Try
                Dim prov As New Proveedor
                prov.razonSocial = txtRazonSocial.Text
                prov.cuit = txtCuit.Text
                prov.direccion = txtDireccion.Text
                prov.ciudad = comboCiudad.Text
                prov.provincia = comboProvincia.Text
                prov.telefono = txtTel.Text
                prov.telefono2 = txtTel2.Text
                prov.email = txtEmail.Text
                prov.banco = txtBanco.Text
                prov.cbu = txtCBU.Text

                altaProveedor(prov)
                MsgBox("Agregado Correctamente")
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class