Module GestorProveedores
    'Public drr As OleDb.OleDbDataReader
    Public Function busquedaProveedorID(ByRef idProv As String)
        Dim prov As New Proveedor
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "SELECT * FROM Proveedores WHERE idProveedor = " + idProv
        Try
            'drr = cmd.ExecuteReader()
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    prov.idProveedor = dr(0)
                    prov.razonSocial = dr(1)
                    prov.cuit = dr(2)
                    prov.direccion = dr(3)
                    prov.ciudad = dr(4)
                    prov.provincia = dr(5)
                    prov.telefono = dr(6)
                    prov.telefono2 = dr(7)
                    prov.email = dr(8)

                End While
            Else
                MsgBox("No existen registros")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return prov
    End Function

    Public Sub altaProveedor(ByRef prov As Proveedor)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "INSERT INTO Proveedores (razonSocial,cuit,direccion,ciudad,provincia,telefono ,telefono2 ,email,banco,cbu)"
        sql += "VALUES ('" & prov.razonSocial & "','" & prov.cuit & "','" & prov.direccion & "','" & prov.ciudad & "','" & prov.provincia & "','" & prov.telefono & "','" & prov.telefono2 & "','" & prov.email & "','" & prov.banco & "','" & prov.cbu & "')"
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
End Module
