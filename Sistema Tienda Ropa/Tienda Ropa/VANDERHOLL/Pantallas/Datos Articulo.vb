Public Class Datos_Articulo
    Public Shadows art As Articulos
    Private Sub Datos_Articulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtCodigo.Text = art.codigo
        txtDescripcion.Text = art.descripcion
        txtProv.Text = art.proveedor.razonSocial
        txtStock.Text = art.stock
        txtStockCritico.Text = art.stockCritico
        txtCosto.Text = art.costo
        txtPrecio.Text = art.precio


        Try
            Dim alto As Single = 0
            Dim bm As Bitmap = Nothing
            bm = CodigosBarra.codigo128(txtCodigo.Text, art.descripcion, True, 100)
            If Not IsNothing(bm) Then
                imagenCodigo.Image = bm
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnGuardarCodigo_Click(sender As Object, e As EventArgs) Handles brnGauardarCodigo.Click
        If txtDescripcion.Text = "" Then
            MsgBox("Coloque la descripcion del Articulo", MsgBoxStyle.Information)
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

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If MsgBox("Desea Imprimir el Codigo?", vbYesNo, "Imprimir Codigo") = vbYes Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                PrintDocument1.Print()
            End If
        Else
            Exit Sub
        End If
    End Sub

   

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        
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
End Class