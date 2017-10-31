

Public Class ParametrosSistema


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ChooseFolder()
    End Sub

    Public Sub ChooseFolder()
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

  

    Private Sub ParametrosSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Try
            Dim parametro As New Parametros
            parametro = traerParametros()
            txtPorcentaje.Text = parametro.porcentajeRecargo
            txtRuta.Text = parametro.ruta
            txtCuotas.Text = parametro.cuotas
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPorcentaje.ReadOnly = False
            txtRuta.ReadOnly = False
            txtCuotas.ReadOnly = False
            Button1.Enabled = True
            Button2.Text = "Guardar"
        Else
            txtPorcentaje.ReadOnly = True
            txtCuotas.ReadOnly = True
            txtRuta.ReadOnly = True
            Button1.Enabled = False
            Button2.Text = "Aceptar"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Aceptar" Then
            Me.Dispose()
        Else
            If Convert.ToInt32(txtPorcentaje.Text) <= 100 Then
                Dim parametro As New Parametros
                parametro.porcentajeRecargo = Convert.ToInt32(txtPorcentaje.Text)
                parametro.cuotas = Convert.ToInt32(txtCuotas.Text)
                parametro.ruta = txtRuta.Text.Replace("\", "\\")
                actualizarParametro(parametro)
                CheckBox1.Checked = False
            Else
                MsgBox("Coloque un valor entre 0 y 100", MsgBoxStyle.Information)
            End If
            
        End If
    End Sub

   
    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If e.KeyChar = vbBack Then
            ' Si es la tecla de borrar salimos del procedimiento
            ' entonces podra borrar.
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub txtCuotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuotas.KeyPress
        If e.KeyChar = vbBack Then
            ' Si es la tecla de borrar salimos del procedimiento
            ' entonces podra borrar.
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class