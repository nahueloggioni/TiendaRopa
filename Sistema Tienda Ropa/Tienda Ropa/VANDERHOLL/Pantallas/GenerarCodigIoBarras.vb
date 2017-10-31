Public Class GenerarCodigIoBarras
    Dim genero As Boolean = False
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCodigoBarras.Text = "" Then
            MsgBox("Escriba el Codigo")
        Else
            Try
                genero = True
                Dim alto As Single = 0
                Dim bm As Bitmap = Nothing
                bm = CodigosBarra.codigo128(txtCodigoBarras.Text, " ", True, 80)
                If Not IsNothing(bm) Then
                    imagenCodigoBarra.Image = bm
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtCodigoBarras.Text = "" Then
            MsgBox("Coloque el codigo del articulo ", MsgBoxStyle.Information)
        Else
                If genero = False Then
                    MsgBox("Genere el codigo para poder guardarlo")
                Else
                If MsgBox("Desea guardar el codigo?", vbYesNo, "Guardar Codigo") = vbYes Then
                    Dim parametroC As New Parametros
                    parametroC = traerParametros()
                    Dim vFoto As New Bitmap(imagenCodigoBarra.Width, imagenCodigoBarra.Height)
                    imagenCodigoBarra.DrawToBitmap(vFoto, New Rectangle(0, 0, imagenCodigoBarra.Width, imagenCodigoBarra.Height))
                    MsgBox(parametroC.ruta & "\" & txtCodigoBarras.Text & ".jpeg")
                    vFoto.Save(parametroC.ruta & "\" & txtCodigoBarras.Text & ".jpeg", Imaging.ImageFormat.Jpeg)
                    MsgBox("Imagen almacenada en: " & vbNewLine & parametroC.ruta & "\" & txtCodigoBarras.Text & ".jpeg", MsgBoxStyle.OkOnly, "Imagen Guardada Correctamente")
                Else

                    Exit Sub 'CON ESTO SALES DE LA FUNCIÓN 
                End If
                End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Desea Imprimir el Codigo?", vbYesNo, "Imprimir Codigo") = vbYes Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                PrintDocument1.Print()
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txtCodigoBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoBarras.KeyPress
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCodigoBarras.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
        ' comprobar si el caracter es un número o el retroceso  
        If Not caracter = ChrW(Keys.Space) = False Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtCodigoBarras_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarras.TextChanged
        genero = False
        imagenCodigoBarra.Image = Nothing
    End Sub
End Class