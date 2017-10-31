Imports System
Imports System.ServiceProcess
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO


Public Class PantallaPrincipal

    Private Sub PantallaPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PrevInstance() = True Then
            Application.Exit()
        End If
        conectarMySql()
        actualizarTotalDia()

        If Date.Now.Hour < 12 Then
            Dim horario As Horario = traerHorariosPorTurno(Date.Now.ToString("dd/MM/yyyy"), "M")
            If horario Is Nothing Then
                altaHorario(Date.Now.ToString("dd/MM/yyyy"), Date.Now.ToLongTimeString, "M", "APERTURA")
            End If
        Else
            Dim horario As Horario = traerHorariosPorTurno(Date.Now.ToString("dd/MM/yyyy"), "T")
            If horario Is Nothing Then
                altaHorario(Date.Now.ToString("dd/MM/yyyy"), Date.Now.ToLongTimeString, "T", "APERTURA")
            End If
        End If


    End Sub

    Private Sub NuevaCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaCompraToolStripMenuItem.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim compra As New NuevaCompra
        compra.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub ProveedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        Dim listaProv As New ListaProveedores
        listaProv.ShowDialog()

    End Sub


    Private Sub NuevoProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Dim nuevoProv As New NuevoProveedor
        nuevoProv.ShowDialog()
    End Sub

    Private Sub ListaDeArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeArticulosToolStripMenuItem.Click
        Dim listaArt As New ListaArticulos
        listaArt.Show()
    End Sub

    Private Sub NuevoArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoArticuloToolStripMenuItem.Click
        Try
            Dim nuevoArt As New NuevoArticulo
            nuevoArt.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub GenerarCodigoBarrasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarCodigoBarrasToolStripMenuItem.Click
        Dim generarCodigo As New GenerarCodigIoBarras
        generarCodigo.ShowDialog()

    End Sub

    Private Sub NuevaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaVentaToolStripMenuItem.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim nuevaVenta As New NuevaVenta
        nuevaVenta.ShowDialog()
        nuevaVenta.txtCodigoArtVenta.Focus()
        Cursor = System.Windows.Forms.Cursors.Default

    End Sub


    Private Sub ArticulosEnStockCriticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulosEnStockCriticoToolStripMenuItem.Click
        Dim stockCrit As New ListaStockCritico
        stockCrit.ShowDialog()
    End Sub

    Private Sub ParametrosDeSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametrosDeSistemaToolStripMenuItem.Click
        Dim parametro As New ParametrosSistema
        parametro.ShowDialog()

    End Sub


    Private Sub CerrarCesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarCesionToolStripMenuItem.Click
        Application.Exit()

    End Sub

    Private Sub IniciarBackUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarBackUpToolStripMenuItem.Click
        If MessageBox.Show("Desea realizar la copia de seguridad?", "BackUp", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            crearBackUp()
        End If

    End Sub

    Private Sub crearBackUp()
        Dim archivoDB As String
        Try
            SaveFileDialog1.Filter = "SQL Dumpl File (*.sql)|*.sql|All files(*.*)|*.*"
            Dim fecha As String = Date.Now.ToString("dd-MM-yyyy")
            SaveFileDialog1.FileName = "Vanderholl" + fecha + ".sql"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                archivoDB = SaveFileDialog1.FileName
                Dim backupProccess As New Process
                backupProccess.StartInfo.FileName = "cmd.exe"
                backupProccess.StartInfo.UseShellExecute = False
                backupProccess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                backupProccess.StartInfo.RedirectStandardInput = True
                backupProccess.StartInfo.RedirectStandardOutput = True
                backupProccess.Start()

                Dim backupStream As StreamWriter = backupProccess.StandardInput
                Dim myStreamReader As StreamReader = backupProccess.StandardOutput
                backupStream.WriteLine("mysqldump --user=root --password= -h localhost vanderholl >" + archivoDB + "")

                backupStream.Close()
                backupProccess.WaitForExit()
                backupProccess.Close()

                MsgBox("BackUp creado correctamente", MsgBoxStyle.Information, "BackUp")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub restaurarBackUp()
        Dim archivoDB As String
        Try
            OpenFileDialog1.Filter = "SQL Dumpl File (*.sql)|*.sql|All files(*.*)|*.*"
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                archivoDB = OpenFileDialog1.FileName
                Dim backupProccess As New Process
                backupProccess.StartInfo.FileName = "cmd.exe"
                backupProccess.StartInfo.UseShellExecute = False
                backupProccess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                backupProccess.StartInfo.RedirectStandardInput = True
                backupProccess.StartInfo.RedirectStandardOutput = True
                backupProccess.Start()

                Dim backupStream As StreamWriter = backupProccess.StandardInput
                Dim myStreamReader As StreamReader = backupProccess.StandardOutput
                backupStream.WriteLine("mysql --user=root --password= -h localhost vanderholl <" + archivoDB + "")

                backupStream.Close()
                backupProccess.WaitForExit()
                backupProccess.Close()

                MsgBox("BackUp restaurado correctamente", MsgBoxStyle.Information, "BackUp")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RestaurarBackUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarBackUpToolStripMenuItem.Click
        If MessageBox.Show("Desea restaurar una copia de seguridad?", "BackUp", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            MsgBox("ADVERTENCIA! Podria perder todos los datos. Por favor comuniquese con el administrador", MsgBoxStyle.Critical, "Advertencia")
            restaurarBackUp()
        End If

    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim ventas As New Ventas
        ventas.ShowDialog()
    End Sub

    Public Sub actualizarTotalDia()
        Dim totalDia As Double = ConsultaVentaDia(Date.Now.ToString("dd/MM/yyyy"))
        lblTotalDia.Text = FormatNumber(totalDia.ToString, 2)
    End Sub

    Function PrevInstance() As Boolean
        If UBound(System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem1.Click
        Dim compras As New Compras
        compras.ShowDialog()
    End Sub

    Private Sub HorariosAperturaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim horarios As New HorariosApertura
        horarios.ShowDialog()
    End Sub

    Private Sub ActualizarStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarStockToolStripMenuItem.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim actualizar As New ActualizarPrecios
        actualizar.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

End Class





