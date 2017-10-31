Module Gestores_Compra
    Public Function ConsultaIdCompra()
        Dim id As Integer
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "SELECT idCompra from Compras order by idCompra desc limit 1"
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
                'MsgBox("No existen registros")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return id
    End Function

    Public Sub altaCompra(ByRef compra As Compra)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "INSERT INTO Compras (fecha,idProveedor) VALUES ('" & compra.fecha.ToString & "'," & compra.proveedor.idProveedor & ")"
        'cmd.CommandText = sql
        Try
            '    cmd.ExecuteNonQuery()
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        
    End Sub

    Public Sub altaDetalleCompra(ByRef detalleCompra As DetalleCompra)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "INSERT INTO DetalleCompra(idCompra,codigoArticulo,cantidad ,precioCosto)"
        sql += "VALUES(" & detalleCompra.idCompra & ",'" & detalleCompra.codigoArticulo & "'," & detalleCompra.cantidad & "," & detalleCompra.costoArticulo.ToString.Replace(",", ".") & ")"
        'cmd.CommandText = sql
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
            '    cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        

    End Sub
End Module
