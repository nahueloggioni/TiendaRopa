Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class NuevoArticulo
    Dim genero As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim articulo As New Articulos
            Dim prov As New Proveedor
            prov.idProveedor = comboProveedores.SelectedValue

            articulo.codigo = txtCodigo.Text
            articulo.descripcion = txtDescripcion.Text
            articulo.stock = txtStock.Text
            articulo.stockCritico = txtStockCritico.Text
            articulo.costo = Convert.ToDouble(txtCosto.Text)
            articulo.precio = Convert.ToDouble(txtPrecio.Text)
            articulo.proveedor = prov

            altaArticuloCompra(articulo)

            MsgBox("Agregado Correctamente")
            txtCodigo.Text = ""
            txtCosto.Text = ""
            txtDescripcion.Text = ""
            txtPrecio.Text = ""
            txtStock.Text = ""
            txtStockCritico.Text = ""

            If genero = False Then

            Else
                If MsgBox("Desea Imprimir el Codigo?", vbYesNo, "Imprimir Codigo") = vbYes Then
                    If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                        PrintDocument1.Print()
                    End If
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox("Complete todos los datos del Articulo")
        End Try
    End Sub

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

    Private Sub NuevoArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCodigo.Text = "" Then
            MsgBox("Escriba el Codigo")
        Else
            Try
                genero = True
                Dim alto As Single = 0
                Dim bm As Bitmap = Nothing
                bm = CodigosBarra.codigo128(txtCodigo.Text, txtDescripcion.Text, True, 80)
                If Not IsNothing(bm) Then
                    imagenCodigo.Image = bm
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If txtCodigo.Text = "" Then
                MsgBox("Coloque el codigo del articulo ", MsgBoxStyle.Information)
            Else
                If txtDescripcion.Text = "" Then
                    MsgBox("Coloque la descripcion del Articulo", MsgBoxStyle.Information)
                Else
                    If genero = False Then
                        MsgBox("Genere el codigo para poder guardarlo")
                    Else
                        If MsgBox("Desea guardar el codigo?", vbYesNo, "Guardar Codigo") = vbYes Then
                            Dim parametro As Parametros = traerParametros()
                            Dim vFoto As New Bitmap(imagenCodigo.Width, imagenCodigo.Height)
                            imagenCodigo.DrawToBitmap(vFoto, New Rectangle(0, 0, imagenCodigo.Width, imagenCodigo.Height))
                            vFoto.Save(parametro.ruta & "\" & txtDescripcion.Text & ".jpeg", Imaging.ImageFormat.Jpeg)
                            MsgBox("Imagen almacenada en: " & vbNewLine & parametro.ruta & "\" & txtDescripcion.Text & ".jpeg", MsgBoxStyle.OkOnly, "Imagen Guardada Correctamente")
                        Else

                            Exit Sub 'CON ESTO SALES DE LA FUNCIÓN 
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox("Error al guardar la imagen" & vbNewLine & "Asegurese que la carpeta exista")
        End Try
    End Sub


    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(imagenCodigo.Image, 10, 20, imagenCodigo.Image.Width, 100) 'PB1 ES EL NOMBRE DEL PICTUREBOX
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

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar

        ' comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtStockCritico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockCritico.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar

        ' comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
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
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
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
    End Sub

    Private Sub imagenCodigo_Click(sender As Object, e As EventArgs) Handles imagenCodigo.Click

    End Sub
End Class