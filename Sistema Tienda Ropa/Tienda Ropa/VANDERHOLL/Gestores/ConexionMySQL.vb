Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports MySql.Data.Types

Module ConexionMySQL
    Friend dr As MySqlDataReader
    Public conex As New MySqlConnection
    Public adapter As New MySqlDataAdapter
    Public cadena As String
    Public sql As String


    Public Sub conectarMySql()
        Try
            cadena = "server=localhost;database=vanderholl;user id=root;password=;"
            conex = New MySqlConnection(cadena)
            conex.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub
End Module
