Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class ActualizarPrecios
    Private Sub ActualizarPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autocompletar()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cod As String = txtCodigoArt.Text
        If cod.Replace(" ", "") = "" Then
            'MsgBox("Coloque un codigo")
        Else
            Dim existe = False

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Convert.ToString(row.Cells(0).Value) = cod.Replace(" ", "") Then
                    existe = True
                End If
            Next
            If (existe = True) Then
                MsgBox("Éste articulo ya fué agregado", MsgBoxStyle.OkOnly, "INFORMACIÓN")
                txtCodigoArt.Text = ""
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
            If art.stock = 0 Then
                MsgBox("No posee Stock del articulo " & art.codigo & vbNewLine & art.descripcion, MsgBoxStyle.Information)
            Else
                DataGridView1.Rows.Insert(0, art.codigo, art.descripcion, art.stock, art.precio, 1)
                txtCodigoArt.Text = ""
                txtCodigoArt.Focus()

            End If

        End If
    End Sub

    Private Sub txtCodigoArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArt.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        If Char.IsLower(e.KeyChar) Then
            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCodigoArt.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
        ' comprobar si el caracter es un número o el retroceso  
        If Not caracter = ChrW(Keys.Space) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoArt_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoArt.KeyUp
        If e.KeyValue = Keys.Enter Then
            Dim cod As String = txtCodigoArt.Text
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
                    txtCodigoArt.Text = ""
                Else
                    agregarArticuloTabla(cod)
                End If
            End If

        End If
    End Sub

    Private Sub autocompletar()

        Try
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)

            Dim da As New MySqlDataAdapter("select codigoArticulo from Articulos where stock>0", conex)
            da.Fill(dt)

            Dim r As DataRow

            txtCodigoArt.AutoCompleteCustomSource.Clear()

            For Each r In dt.Rows
                txtCodigoArt.AutoCompleteCustomSource.Add(r.Item(0).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

  

    Public Sub llenarListaArticulos()

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "select codigoArticulo,descripcion,stock ,precioArticulo from Articulos  where Articulos.habilitar=1 and stock>0"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Articulos")
        adp.Fill(ds.Tables("Articulos"))

        Me.DataGridView1.DataSource = ds.Tables("Articulos")
        Me.DataGridView1.Columns(0).HeaderText = "CODIGO"
        Me.DataGridView1.Columns(1).HeaderText = "ARTICULO"
        Me.DataGridView1.Columns(1).Width = 250
        Me.DataGridView1.Columns(2).HeaderText = "STOCK"
        Me.DataGridView1.Columns(3).HeaderText = "PRECIO"

        Me.DataGridView1.Columns(0).ReadOnly = True
        Me.DataGridView1.Columns(1).ReadOnly = True
        Me.DataGridView1.Columns(2).ReadOnly = True
        Me.DataGridView1.Columns(3).ReadOnly = True

        DataGridView1.Sort(DataGridView1.Columns(2), ListSortDirection.Descending)

    End Sub

    'Datagridview manual
    Private Sub tablaManual()
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.ARTICULO, Me.STOCK, Me.PRECIO})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 87)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(593, 297)
        Me.DataGridView1.TabIndex = 3
        '
        'CODIGO
        '
        Me.CODIGO.Frozen = True
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ARTICULO
        '
        Me.ARTICULO.Frozen = True
        Me.ARTICULO.HeaderText = "ARTICULO"
        Me.ARTICULO.Name = "ARTICULO"
        Me.ARTICULO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ARTICULO.ReadOnly = True
        Me.ARTICULO.Width = 250
        '
        'STOCK
        '
        Me.STOCK.Frozen = True
        Me.STOCK.HeaderText = "STOCK"
        Me.STOCK.Name = "STOCK"
        Me.STOCK.ReadOnly = True
        Me.STOCK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PRECIO
        '
        Me.PRECIO.Frozen = True
        Me.PRECIO.HeaderText = "PRECIO"
        Me.PRECIO.Name = "PRECIO"
        Me.PRECIO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Todos los Articulos" Then
            txtCodigoArt.Enabled = False
            Button1.Enabled = False
            llenarListaArticulos()
            Me.PRECIO.ReadOnly = True
            Button2.Text = "Quitar Todos"
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else
            txtCodigoArt.Enabled = True
            Button1.Enabled = True
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            tablaManual()
            Button2.Text = "Todos los Articulos"
            Me.PRECIO.ReadOnly = False
            CheckBox1.Checked = True
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PanelProcentaje.Enabled = False
            Me.PRECIO.ReadOnly = False
        Else
            PanelProcentaje.Enabled = True
            Me.PRECIO.ReadOnly = True
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing( _
       ByVal sender As Object, _
       ByVal e As DataGridViewEditingControlShowingEventArgs) _
           Handles DataGridView1.EditingControlShowing

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

    Private Sub validar_Keypress( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = DataGridView1.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a las columnas 2 y 3
        
        'Validar punto en valores decimales
        If columna = 3 Then
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.RowCount - 1 <= 0 Then
            MsgBox("Debe completar al menos un articulo", MsgBoxStyle.Critical, "Advertencia")
        Else
            If MsgBox("Esta seguro de actualizar los precios?", vbYesNo, "Actualizar Precios") = vbYes Then
                Try
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    Dim x As New List(Of Articulos)
                    For i = 0 To Me.DataGridView1.Rows.Count - 2
                        Dim articulo As New Articulos
                        articulo.codigo = Me.DataGridView1.Rows(i).Cells(0).Value.ToString
                        articulo.precio = Format(Convert.ToDouble(Me.DataGridView1.Rows(i).Cells(3).Value), "0.00")
                        x.Add(articulo)
                    Next i

                    If CheckBox1.Checked Then
                        For Each art As Articulos In x
                            Try
                                actualizarPrecio(art)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        Next
                    Else
                        Dim porcentaje As Integer = Convert.ToInt16(txtPorcentaje.Text)
                        If rbAumento.Checked Then
                            For Each art As Articulos In x
                                Try
                                    art.precio += art.precio * porcentaje / 100
                                    actualizarPrecio(art)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Next
                        Else
                            For Each art As Articulos In x
                                Try
                                    art.precio -= art.precio * porcentaje / 100
                                    actualizarPrecio(art)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Next
                        End If
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                    MsgBox("Actualizacion exitosa")

                    Me.Dispose()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information)
                End Try
            Else

            End If
        End If

    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar

        ' comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class