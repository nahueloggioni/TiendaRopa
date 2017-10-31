Module GestorParametros

    Public Function traerParametros()
        Dim par As New Parametros
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "select * from Parametros"
        Try
            'dr = cmd.ExecuteReader()
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    par.porcentajeRecargo = dr(0)
                    par.ruta = dr(1)
                    par.cuotas = dr(2)

                End While
            Else
                MsgBox("No existen registros")
                par = Nothing
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return par
    End Function

    Public Sub actualizarParametro(ByVal param As Parametros)
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.Text
        sql = "UPDATE Parametros SET porcentajeTajeta = " & param.porcentajeRecargo & ",rutaCodigo = '" & param.ruta & "' ,`cantidadCuotas`=" & param.cuotas & ""
        'cmd.CommandText = sql
        Try
            'cmd.ExecuteNonQuery()
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
            MsgBox("Parametros Actualizados")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
