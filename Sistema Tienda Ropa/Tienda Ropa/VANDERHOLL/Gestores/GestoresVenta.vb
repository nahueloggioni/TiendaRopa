Module GestoresVenta

    Public Function ConsultaIdVenta()
        Dim id As Integer
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "SELECT idVenta from Ventas order by idVenta desc LIMIT 1"
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            '    drr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    id = dr.GetValue(0)
                End While
            Else
                ' MsgBox("No existen registros")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
            Return id
    End Function

    Public Sub altaVenta(ByRef venta As Venta)
        sql = "INSERT INTO Ventas (idVenta,fecha,idTipoPago) VALUES ('" & venta.idVenta.ToString & "','" & venta.fecha.ToString & "'," & venta.tipoPago.idTipoPago.ToString & ")"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub altaDetalleVenta(ByRef detalleVenta As DetalleVenta)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "INSERT INTO DetalleVenta(idVenta,codigoArticulo,precioArticulo ,cantidad)"
        sql += "VALUES(" & detalleVenta.venta.idVenta & ",'" & detalleVenta.codigoArticulo & "'," & detalleVenta.precioArticulo.ToString.Replace(",", ".") & "," & detalleVenta.cantidad & ")"
        'cmd.CommandText = sql
        Try
            'cmd.ExecuteNonQuery()
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub altaVentaCuota(ByRef venta As VentaCuota)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "INSERT INTO `ventacuota`(`idVenta`, `cuotas`) VALUES (" & venta.idVentaCuota & "," & venta.cuotas & " )"
        'cmd.CommandText = sql
        Try
            'cmd.ExecuteNonQuery()
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function ConsultaVentaDia(ByVal fecha As String)
        Dim ventasDia As Double
        sql = "SELECT sum(detalleventa.precioArticulo*detalleventa.cantidad) FROM `ventas` inner join detalleventa on ventas.idVenta=detalleventa.idVenta WHERE ventas.fecha like '" & fecha & "'"
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    If IsDBNull(dr.GetValue(0)) Then
                        ventasDia = 0
                    Else
                        ventasDia = dr.GetValue(0)
                    End If
                End While
            Else
                ventasDia = 0
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ventasDia
    End Function

    Public Sub eliminarVenta(ByRef idVenta As Integer)
        sql = "UPDATE `ventas` SET `habilitar`='NO' WHERE idVenta=" & idVenta & " "
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub actualizarStockDevolucion(ByRef articulo As Articulos, ByVal cantidad As Integer)
        sql = "update Articulos set stock = stock+" & cantidad & " where codigoArticulo like '" & articulo.codigo & "'"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function ConsultaVenta(ByVal idVenta As Integer)
        
        Dim x As New List(Of Venta)
        sql = "SELECT * FROM ventas INNER JOIN detalleventa on ventas.idVenta=detalleventa.idVenta INNER JOIN ventacuota on ventas.idVenta=ventacuota.idVenta where ventas.idVenta=" & idVenta & ""
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Dim venta As New Venta
                    Dim detalleVenta As New DetalleVenta
                    Dim ventaCuota As New VentaCuota
                    ventaCuota.cuotas = dr.GetValue(10)

                    detalleVenta.codigoArticulo = dr.GetValue(5)
                    detalleVenta.cantidad = dr.GetValue(7)
                    detalleVenta.precioArticulo = dr.GetValue(6)

                    venta.idVenta = dr.GetValue(0)
                    venta.fecha = dr.GetValue(1)
                    venta.cuota = ventaCuota
                    venta.detalle = detalleVenta

                    x.Add(venta)

                End While
            Else
                MsgBox("No se encuentra la venta")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return x
    End Function
    Public Sub elminarCuotas(ByRef idVenta As Integer)
        sql = "DELETE FROM `ventacuota` WHERE idVenta=" & idVenta & " "
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub elminarDetalle(ByRef idVenta As Integer)
        sql = "UPDATE `detalleventa` SET `habilitar`='NO' WHERE  idVenta=" & idVenta & " "
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub elminarDetalleArt(ByRef idVenta As Integer, ByRef codigo As String)
        sql = "UPDATE `detalleventa` SET `habilitar`='NO' WHERE  idVenta=" & idVenta & " and codigoArticulo like '" & codigo & "' "
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
