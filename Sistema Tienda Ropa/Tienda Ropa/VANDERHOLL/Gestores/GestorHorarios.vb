
Module GestorHorarios

    Public Sub altaHorario(ByRef dia As String, ByRef hora As String, ByRef turno As String, ByRef tipo As String)
        sql = "INSERT INTO `horariosinicio`(`fecha`, `hora`,turno,tipo) VALUES ('" & dia & "','" & hora & "','" & turno & "','" & tipo & "')"
        Try
            adapter.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.InsertCommand.Connection = conex
            adapter.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function traerHorarios(ByRef fecha As String)
        Dim listaHorarios As New List(Of Horario)
        sql = "SELECT * FROM `horariosinicio` WHERE fecha like '" & fecha & "' "
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Dim horario As New Horario
                    horario.dia = dr.GetValue(0)
                    horario.hora = dr.GetValue(1)
                    horario.turno = dr.GetValue(2)
                    horario.tipo = dr.GetValue(3)

                    listaHorarios.Add(horario)
                End While
            Else
                listaHorarios = Nothing
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return listaHorarios
    End Function

    Public Function traerHorariosPorTurno(ByRef fecha As String, ByRef turno As String)
        Dim hora As New Horario
        sql = "SELECT * FROM `horariosinicio` WHERE fecha like '" & fecha & "' and turno like '" & turno & "' "
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Dim horario As New Horario
                    horario.dia = dr.GetValue(0)
                    horario.hora = dr.GetValue(1)
                    horario.turno = dr.GetValue(2)
                End While
            Else
                hora = Nothing
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return hora
    End Function

    Public Function traerHorariosPorTipo(ByRef fecha As String, ByRef turno As String, ByRef tipo As String)
        Dim hora As New Horario
        sql = "SELECT * FROM `horariosinicio` WHERE fecha like '" & fecha & "' and turno like '" & turno & "' and tipo like '" & tipo & "' "
        Try
            adapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(sql)
            adapter.SelectCommand.Connection = conex
            dr = adapter.SelectCommand.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Dim horario As New Horario
                    horario.dia = dr.GetValue(0)
                    horario.hora = dr.GetValue(1)
                    horario.turno = dr.GetValue(2)
                    horario.tipo = dr.GetValue(3)
                End While
            Else
                hora = Nothing
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return hora
    End Function
End Module
