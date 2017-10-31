Imports MySql.Data.MySqlClient

Public Class NuevaVenta
    Dim fechaActual As Date = Today
    Dim indice As Integer
    Dim recargo As Double
    Shadows menu As ContextMenuStrip
    Private Sub NuevaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        lblFecha.Text = fechaActual.ToString("dd/MM/yyyy")
        autocompletar()
        txtCodigoArtVenta.Focus()
        Dim paramet As Parametros = traerParametros()
        btnTarjeta.Text = "Tarjeta " & paramet.porcentajeRecargo & "%"
    End Sub

    'PASAR A MAYUSCULA EL CODIGO
    Private Sub txtCodigoArtVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArtVenta.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        If Char.IsLower(e.KeyChar) Then
            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCodigoArtVenta.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
        ' comprobar si el caracter es un número o el retroceso  
        If Not caracter = ChrW(Keys.Space) = False Then
            e.Handled = True
        End If
    End Sub

    'EVENTO ENTER TEXTBO CODIGO
    Private Sub txtCodigoArtVenta_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoArtVenta.KeyUp
        If e.KeyValue = Keys.Enter Then
            Dim cod As String = txtCodigoArtVenta.Text
            If cod.Replace(" ", "") = "" Then
                MsgBox("Coloque un codigo")
            Else
                Dim existe = False

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Convert.ToString(row.Cells(0).Value) = cod.Replace(" ", "") Then
                        existe = True
                    End If
                Next
                If (existe = True) Then
                    MsgBox("Éste articulo ya fué agregado", MsgBoxStyle.OkOnly, "INFORMACIÓN")
                    txtCodigoArtVenta.Text = ""
                Else
                    agregarArticuloTabla(cod)
                End If
            End If

        End If
    End Sub

    'VALIDAR SOLO NUMEROS EN "CANTIDAD"
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    'PERMITIR SOLO NUMEROS EN CANTIDAD
    Private Sub validar_Keypress( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = DataGridView1.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a las columnas 2 y 3
        If columna = 4 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                e.Handled = True
            End If
        End If


    End Sub

    'EVENTO ENTER EN LA TABLA PARA ACTUALIZAR TOTAL
    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If DataGridView1.RowCount = 0 Then
                MsgBox("Debe añadir algun articulo")
            Else
                Dim x As Boolean = False
                For i = 0 To DataGridView1.RowCount - 1
                    If Convert.ToInt64(DataGridView1.Rows(i).Cells(4).Value) > Convert.ToInt64(DataGridView1.Rows(i).Cells(2).Value) Then
                        x = True
                    ElseIf Convert.ToInt64(DataGridView1.Rows(i).Cells(4).Value) = 0 Then
                        x = True
                    End If
                Next
                If x = True Then
                    MsgBox("Error Cantidad de Articulos" & vbNewLine & "Debe ser mayor a 0 y menor que el Stock", MsgBoxStyle.Information)
                Else
                    actualizarTotal()
                End If
            End If

        End If
    End Sub

    'ELIMINAR FILLA
    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If DataGridView1.Rows.Count > 0 Then
                Dim Mi_Test As DataGridView.HitTestInfo = Me.DataGridView1.HitTest(e.X, e.Y)
                If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                    If Mi_Test.RowIndex >= 0 Then
                        indice = Mi_Test.RowIndex
                        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                        Me.DataGridView1.Rows(Mi_Test.RowIndex).Selected = True
                        menu = New ContextMenuStrip()
                        menu.Items.Add("Eliminar", Nothing, New EventHandler(AddressOf EliminarFila))
                        Me.DataGridView1.ContextMenuStrip = menu
                    End If
                End If
            Else
            End If
        End If
    End Sub

    Private Sub EliminarFila(sender As Object, e As EventArgs)
        Try
            Me.DataGridView1.Rows.RemoveAt(indice)
            actualizarTotal()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        

    End Sub

    'EVENTO BOTON BUSCAR
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cod As String = txtCodigoArtVenta.Text
        If cod.Replace(" ", "") = "" Then
        Else
            Dim existe = False

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Convert.ToString(row.Cells(0).Value) = cod.Replace(" ", "") Then
                    existe = True
                End If
            Next
            If (existe = True) Then
                MsgBox("Éste articulo ya fué agregado", MsgBoxStyle.OkOnly, "INFORMACIÓN")
                txtCodigoArtVenta.Text = ""
            Else
                agregarArticuloTabla(cod)
            End If
        End If
    End Sub

    'METODO AGREGAR FILA A TABLA 
    Public Sub agregarArticuloTabla(ByVal codigo As String)

        Dim art As New Articulos
        art = buscarArticulo(codigo)
        If art Is Nothing Then

        Else
            If art.stock = 0 Then
                MsgBox("No posee Stock del articulo " & art.codigo & vbNewLine & art.descripcion, MsgBoxStyle.Information)
            Else
                DataGridView1.Rows.Insert(0, art.codigo, art.descripcion, art.stock, art.precio, 1)
                txtCodigoArtVenta.Text = ""
                txtCodigoArtVenta.Focus()
                actualizarTotal()
            End If

        End If

    End Sub



    Public Sub actualizarTotal()
        Dim totalVenta As Double = 0
        Dim precioArt As Double
        Dim cant As Integer
        Dim paramet As Parametros = traerParametros()
        For Each row As DataGridViewRow In DataGridView1.Rows
            precioArt = Convert.ToDouble(row.Cells(3).Value)
            cant = row.Cells(4).Value
            totalVenta += (precioArt * cant)
        Next

        If btnEfectivo.Checked Or btnDebito.Checked Then
            lblTotalVenta.Text = totalVenta.ToString
            recargo = 1

        ElseIf btnTarjeta.Checked Then
            totalVenta += (totalVenta * paramet.porcentajeRecargo / 100)
            lblTotalVenta.Text = FormatNumber(totalVenta.ToString, 2)
            recargo = paramet.porcentajeRecargo / 100

        Else
            MsgBox("Seleccione el tipo de pago")
        End If
    End Sub


    'EVENTOS RADIOS BUTTON
    Private Sub btnEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles btnEfectivo.CheckedChanged
        lblCuotas.Visible = False
        comboCuotas.Visible = False
        lblde.Visible = False
        lblTotalCuota.Visible = False
        actualizarTotal()

    End Sub

    Private Sub btnDebito_CheckedChanged(sender As Object, e As EventArgs) Handles btnDebito.CheckedChanged
        lblCuotas.Visible = False
        comboCuotas.Visible = False
        lblde.Visible = False
        lblTotalCuota.Visible = False
        actualizarTotal()
    End Sub

    Private Sub btnTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles btnTarjeta.CheckedChanged
        lblCuotas.Visible = True
        comboCuotas.Visible = True
        llenarComboCuotas()
        actualizarTotal()


    End Sub

 

    'BOTON VENDER
    Private Sub btnVender_Click(sender As Object, e As EventArgs) Handles btnVender.Click
        Try
            If DataGridView1.RowCount = 0 Then
                MsgBox("Debe añadir algun articulo")
            Else
                Dim x As Boolean = False
                For i = 0 To DataGridView1.RowCount - 1
                    If Convert.ToInt64(DataGridView1.Rows(i).Cells(4).Value) > Convert.ToInt64(DataGridView1.Rows(i).Cells(2).Value) Then
                        x = True
                    ElseIf Convert.ToInt64(DataGridView1.Rows(i).Cells(4).Value) = 0 Then
                        x = True
                    End If
                Next
                If x = True Then
                    MsgBox("Error Cantidad de Articulos" & vbNewLine & "Debe ser mayor a 0 y menor que el Stock", MsgBoxStyle.Information)
                Else
                    realizarVenta()
                    PantallaPrincipal.actualizarTotalDia()
                    Me.Dispose()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub realizarVenta()

        If MsgBox("Confirma la Venta?", vbYesNo, "Nueva Venta") = vbYes Then
            Try

                Dim i As Integer
                Dim venta As New Venta
                Dim detalleVenta As New DetalleVenta
                Dim articulo As New Articulos
                Dim tipoPago As New TipoPago
                Dim ventaCuota As New VentaCuota
                venta.fecha = fechaActual.ToString("dd/MM/yyyy")
                If btnEfectivo.Checked Then
                    tipoPago.idTipoPago = 1
                ElseIf btnDebito.Checked Then
                    tipoPago.idTipoPago = 3
                Else
                    tipoPago.idTipoPago = 2
                End If

                venta.tipoPago = tipoPago
                venta.idVenta = ConsultaIdVenta() + 1

                
                For i = 0 To Me.DataGridView1.Rows.Count - 1 'menos 1 porque cuenta el encabezado
                    articulo.codigo = Me.DataGridView1.Rows(i).Cells(0).Value.ToString
                    articulo.descripcion = Me.DataGridView1.Rows(i).Cells(1).Value.ToString
                    articulo.stock = Me.DataGridView1.Rows(i).Cells(2).Value.ToString
                    If recargo = 1 Then
                        articulo.precio = Me.DataGridView1.Rows(i).Cells(3).Value.ToString
                    Else
                        articulo.precio = Me.DataGridView1.Rows(i).Cells(3).Value.ToString + (Me.DataGridView1.Rows(i).Cells(3).Value.ToString * recargo)
                    End If


                    detalleVenta.codigoArticulo = articulo.codigo
                    detalleVenta.cantidad = Me.DataGridView1.Rows(i).Cells(4).Value.ToString
                    detalleVenta.precioArticulo = Convert.ToDouble(articulo.precio)
                    detalleVenta.venta = venta

                    altaDetalleVenta(detalleVenta)
                    actualizarStockVenta(articulo, detalleVenta.cantidad)

                Next i

                ventaCuota.idVentaCuota = venta.idVenta
                If comboCuotas.SelectedItem < 1 Then
                    ventaCuota.cuotas = 1
                Else
                    ventaCuota.cuotas = comboCuotas.SelectedItem
                End If


                altaVenta(venta)
                altaVentaCuota(ventaCuota)
                MsgBox("Venta Realizada con exito")

                Me.Dispose()
            Catch ex As Exception
                MsgBox("Debe completar todos los datos del articulo", MsgBoxStyle.Information)
                MsgBox(ex.ToString)
            End Try
        Else
        End If
    End Sub

    'METODO PARA AUTO COMPLETAR TEXBOX CON CODIGOS DE ARTICULOS
    Private Sub autocompletar()
        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)

            Dim da As New MySqlDataAdapter("select codigoArticulo from Articulos", conex)
            da.Fill(dt)

            Dim r As DataRow

            txtCodigoArtVenta.AutoCompleteCustomSource.Clear()

            For Each r In dt.Rows
                txtCodigoArtVenta.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Public Sub llenarComboCuotas()
        comboCuotas.Items.Clear()
        Dim parametro As New Parametros
        parametro = traerParametros()

        For i = 1 To parametro.cuotas
            comboCuotas.Items.Add(i)
        Next
        comboCuotas.SelectedItem = 1

    End Sub

    
    Private Sub comboCuotas_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboCuotas.SelectedValueChanged
        lblde.Visible = True
        lblTotalCuota.Visible = True

        Dim totalCuota As Double
        totalCuota = Convert.ToDouble(lblTotalVenta.Text) / comboCuotas.SelectedItem

        lblTotalCuota.Text = FormatNumber(totalCuota.ToString, 2)


    End Sub

    
    
End Class