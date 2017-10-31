Imports MySql.Data.MySqlClient

Public Class NuevaCompra

    Dim fechaActual As Date = Today
    Dim indice As Integer
    Dim menuTablaArt As ContextMenuStrip

    'METODO PARA LLENAR EL COMBO DE PROVEEDORES
    Public Sub llenarCombo()
        'Me.comboProveedores.Items.Clear()
        Me.comboProveedores.Items.Add("SELECCIONE")
        Dim ds As New DataSet

        sql = "select idProveedor, razonSocial from Proveedores "
        Dim nuevoda = New MySqlDataAdapter(sql, conex)
        nuevoda.Fill(ds, "Proveedores")
        Me.comboProveedores.DataSource = ds.Tables("Proveedores")
        Me.comboProveedores.DisplayMember = "razonSocial"
        Me.comboProveedores.ValueMember = "idProveedor"


    End Sub




    'LLENAMOS EL COMBO Y SETEAMOS LA FECHA AL INCIALIZAR
    Private Sub NuevaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFecha.Text = fechaActual.ToString("dd/MM/yyyy")
        llenarCombo()
        autocompletar()
    End Sub


    'BOTON PARA GENERAR LA COMPRA
    Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btbCompra.Click

        If tablaArticulosCompra.RowCount - 1 <= 0 Then
            MsgBox("Debe completar al menos un articulo", MsgBoxStyle.Critical, "Advertencia")
        Else
            If MsgBox("Confirma la compra?", vbYesNo, "Nueva Compra") = vbYes Then
                Try

                    Dim i As Integer
                    Dim articulo As New Articulos
                    Dim nuevoAart As New Articulos
                    Dim compra As New Compra
                    Dim detalleCompra As New DetalleCompra
                    Dim proveedor As New Proveedor

                    proveedor.idProveedor = comboProveedores.SelectedValue
                    compra.fecha = fechaActual.ToString("dd/MM/yyyy")
                    compra.proveedor = proveedor

                    altaCompra(compra)

                    For i = 0 To Me.tablaArticulosCompra.Rows.Count - 2 'menos 1 porque cuenta el encabezado
                        articulo = buscarArticulo(Me.tablaArticulosCompra.Rows(i).Cells(0).Value.ToString)
                        If articulo Is Nothing Then
                            nuevoAart.codigo = Me.tablaArticulosCompra.Rows(i).Cells(0).Value.ToString
                            nuevoAart.descripcion = Me.tablaArticulosCompra.Rows(i).Cells(1).Value.ToString
                            nuevoAart.stock = Me.tablaArticulosCompra.Rows(i).Cells(2).Value.ToString
                            nuevoAart.stockCritico = Me.tablaArticulosCompra.Rows(i).Cells(3).Value.ToString
                            nuevoAart.costo = Me.tablaArticulosCompra.Rows(i).Cells(4).Value.ToString
                            nuevoAart.precio = Me.tablaArticulosCompra.Rows(i).Cells(5).Value.ToString
                            nuevoAart.proveedor = proveedor

                            detalleCompra.codigoArticulo = nuevoAart.codigo
                            detalleCompra.cantidad = nuevoAart.stock
                            detalleCompra.costoArticulo = nuevoAart.costo
                            detalleCompra.idCompra = ConsultaIdCompra()

                            altaDetalleCompra(detalleCompra)
                            altaArticuloCompra(nuevoAart)
                        Else
                            articulo.stock = Me.tablaArticulosCompra.Rows(i).Cells(2).Value
                            articulo.costo = Me.tablaArticulosCompra.Rows(i).Cells(4).Value.ToString
                            articulo.precio = Me.tablaArticulosCompra.Rows(i).Cells(5).Value.ToString

                            detalleCompra.codigoArticulo = articulo.codigo
                            detalleCompra.cantidad = articulo.stock
                            detalleCompra.costoArticulo = articulo.costo
                            detalleCompra.idCompra = ConsultaIdCompra()

                            altaDetalleCompra(detalleCompra)
                            actualizarStockCompra(articulo, articulo.stock)
                        End If
                    Next i

                    MsgBox("Copmpra Realizada con exito")

                    Me.Dispose()
                Catch ex As Exception
                    MsgBox("Debe completar todos los datos del articulo", MsgBoxStyle.Information)
                End Try
            Else

            End If
        End If



    End Sub


    'EVENTO COMBO PARA COMPLETAR LOS DATOS DEL PROVEEDOR
    Private Sub comboProveedores_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProveedores.SelectionChangeCommitted
        Dim prov As New Proveedor
        prov = busquedaProveedorID(comboProveedores.SelectedValue.ToString)

        txtCiudad.Text = prov.ciudad
        txtCuit.Text = prov.cuit
        txtDireccion.Text = prov.direccion
        txtEmail.Text = prov.email
        txtProvincia.Text = prov.provincia
        txtTelefono.Text = prov.telefono
        txtTelefono2.Text = prov.telefono2
    End Sub



    'EVENTO TABLA PARA ELIMINAR FILAS
    Private Sub tablaArticulosCompra_MouseDown(sender As Object, e As MouseEventArgs) Handles tablaArticulosCompra.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim Mi_Test As DataGridView.HitTestInfo = Me.tablaArticulosCompra.HitTest(e.X, e.Y)
            If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                If Mi_Test.RowIndex >= 0 Then
                    indice = Mi_Test.RowIndex
                    Me.tablaArticulosCompra.CurrentCell = Me.tablaArticulosCompra.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                    Me.tablaArticulosCompra.Rows(Mi_Test.RowIndex).Selected = True
                    menuTablaArt = New ContextMenuStrip()
                    menuTablaArt.Items.Add("Eliminar", Nothing, New EventHandler(AddressOf EliminarFila))
                    Me.tablaArticulosCompra.ContextMenuStrip = menuTablaArt
                End If
            End If
        End If
    End Sub

    'METODO PARA ELIMINAR LAS FIALAS(FALTA DESCONTAR AL TEXBOX DEL TOTAL)
    Private Sub EliminarFila(sender As Object, e As EventArgs)
        Try
            'totalVenta = totalVenta - Me.tablaArticulosCompra.Rows(indice).Cells.Item(3).Value
            'txtTotalCompra.Text = totalVenta.ToString
            Me.tablaArticulosCompra.Rows.RemoveAt(indice)
        Catch ex As Exception

        End Try


    End Sub




    'VALIDAR CAMPOS NUMERICOS EN TABLA ARTICULOS COMPRA
    Private Sub tablaArticulosCompra_EditingControlShowing( _
       ByVal sender As Object, _
       ByVal e As DataGridViewEditingControlShowingEventArgs) _
           Handles tablaArticulosCompra.EditingControlShowing

        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress

        Dim dgv As DataGridView = TryCast(sender, DataGridView)
        Dim tb As TextBox = TryCast(dgv.EditingControl, TextBox)
        If dgv.CurrentCell.ColumnIndex = 0 Then
            ' ... indicamos que convierta todos los valores a mayúsculas.
            '
            tb.CharacterCasing = CharacterCasing.Upper
        Else
            ' Los valores se escribirán tal y como los introduzca
            ' el usuario.
            '
            tb.CharacterCasing = CharacterCasing.Normal
        End If

    End Sub

    ' evento Keypress  
    ' '''''''''''''''''''  
    Private Sub validar_Keypress( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = tablaArticulosCompra.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a las columnas 2 y 3
        If columna = 2 Or columna = 3 Then

            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If
        If columna = 0 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso  
            If Not caracter = ChrW(Keys.Space) = False Then
                e.Handled = True
            End If


        End If
        'Validar punto en valores decimales
        If columna = 4 Or columna = 5 Then
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or _
               (caracter = ChrW(Keys.Back)) Or _
               (caracter = ",") And _
               (txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    ' FIN DE LA VALIDACION



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        calcularTotal()

    End Sub

    Private Sub calcularTotal()
        Dim totalVenta As Double = 0.0
        For i = 0 To tablaArticulosCompra.RowCount - 2
            totalVenta += Convert.ToDouble(Me.tablaArticulosCompra.Rows(i).Cells(4).Value * Me.tablaArticulosCompra.Rows(i).Cells(2).Value)
        Next
        txtTotalCompra.Text = totalVenta.ToString
    End Sub

    Private Sub btnExistente_Click(sender As Object, e As EventArgs) Handles btnExistente.Click
        If btnExistente.Text = "Articulo Existente" Then
            lblCodigo.Visible = True
            txtCodigo.Visible = True
            btnAgregar.Visible = True
            btnExistente.Text = "Cancelar"
            Me.Codigo.ReadOnly = True
            Me.StockCritico.ReadOnly = True
            Me.Articulo.ReadOnly = True
        Else
            lblCodigo.Visible = False
            txtCodigo.Visible = False
            btnAgregar.Visible = False
            btnExistente.Text = "Articulo Existente"

            Me.Codigo.ReadOnly = False
            Me.StockCritico.ReadOnly = False
            Me.Articulo.ReadOnly = False
        End If
        
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim cod As String = txtCodigo.Text
        If cod.Replace(" ", "") = "" Then
        Else
            Dim existe = False

            For Each row As DataGridViewRow In tablaArticulosCompra.Rows
                If Convert.ToString(row.Cells(0).Value) = cod.Replace(" ", "") Then
                    existe = True
                End If
            Next
            If (existe = True) Then
                MsgBox("Éste articulo ya fué agregado", MsgBoxStyle.OkOnly, "INFORMACIÓN")
                txtCodigo.Text = ""
            Else
                agregarArticuloTabla(cod)
            End If
        End If
    End Sub

    Public Sub agregarArticuloTabla(ByVal codigo As String)

        Dim art As New Articulos
        art = buscarArticulo(codigo)
        If art Is Nothing Then

        Else
            tablaArticulosCompra.Rows.Insert(0, art.codigo, art.descripcion, "", art.stockCritico)
            txtCodigo.Text = ""
            txtCodigo.Focus()

        End If

    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        If Char.IsLower(e.KeyChar) Then
            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCodigo.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
        ' comprobar si el caracter es un número o el retroceso  
        If Not caracter = ChrW(Keys.Space) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub autocompletar()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)

            Dim da As New MySqlDataAdapter("select codigoArticulo from Articulos", conex)
            da.Fill(dt)

            Dim r As DataRow

            txtCodigo.AutoCompleteCustomSource.Clear()

            For Each r In dt.Rows
                txtCodigo.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    
End Class