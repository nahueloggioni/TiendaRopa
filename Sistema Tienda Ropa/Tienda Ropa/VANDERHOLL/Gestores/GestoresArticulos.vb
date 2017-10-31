Imports MySql.Data.MySqlClient

Module GestoresArticulos

    Public Sub altaArticuloCompra(ByRef articulo As Articulos)

        sql = "INSERT INTO Articulos (codigoArticulo,descripcion,stock,stockCritico ,costoArticulo ,precioArticulo ,idProveedor)"
        sql += "VALUES('" & articulo.codigo & "','" & articulo.descripcion & "'," & articulo.stock & "," & articulo.stockCritico & "," & articulo.costo.ToString.Replace(",", ".") & " "
        sql += "," & articulo.precio.ToString.Replace(",", ".") & "," & articulo.proveedor.idProveedor & ")"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub actualizarStockVenta(ByRef articulo As Articulos, ByVal cantidad As Integer)
        sql = "update Articulos set stock = stock-" & cantidad & " where codigoArticulo like '" & articulo.codigo & "'"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub actualizarStockCompra(ByRef articulo As Articulos, ByVal cantidad As Integer)
        sql = "update Articulos set stock = stock+" & cantidad & ",`precioArticulo`='" & articulo.precio & "',`costoArticulo`='" & articulo.costo & "' where codigoArticulo like '" & articulo.codigo & "'"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function buscarArticulo(ByRef codigo As String)
        Dim art As New Articulos
        Dim prov As New Proveedor
        sql = "select * from Articulos inner join Proveedores on Articulos.idProveedor=Proveedores.idProveedor where Articulos.codigoArticulo like '" + codigo + "'"
        Try

            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            '    dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    art.codigo = dr(0)
                    art.descripcion = dr(1).ToString
                    art.stock = dr(2)
                    art.stockCritico = dr(3)
                    art.costo = dr(4)
                    art.precio = dr(5)
                    art.habilitar = dr(6)

                    prov.idProveedor = dr(8)
                    prov.razonSocial = dr(9).ToString
                    prov.cuit = dr(10).ToString
                    prov.direccion = dr(11).ToString
                    prov.ciudad = dr(12).ToString
                    prov.provincia = dr(13).ToString
                    prov.telefono = dr(14).ToString
                    prov.telefono2 = dr(15).ToString
                    prov.email = dr(16).ToString

                    art.proveedor = prov

                End While
            Else
                'MsgBox("No existen registros")
                art = Nothing
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return art
    End Function

    Public Sub actualizarArticulo(ByRef articulo As Articulos)
        sql = "UPDATE `articulos` SET `descripcion`='" & articulo.descripcion & "',`stock`=" & articulo.stock & ",`stockCritico`=" & articulo.stockCritico & ",`costoArticulo`='" & articulo.costo & "',"
        sql += "`precioArticulo`='" & articulo.precio & "'   WHERE codigoArticulo LIKE '" & articulo.codigo & "'"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
            MsgBox("Articulo Actualizado")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub actualizarPrecio(ByRef articulo As Articulos)
        sql = "UPDATE `articulos` SET `precioArticulo`='" & Replace(articulo.precio, ",", ".") & "'   WHERE codigoArticulo LIKE '" & articulo.codigo & "'"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  
End Module
