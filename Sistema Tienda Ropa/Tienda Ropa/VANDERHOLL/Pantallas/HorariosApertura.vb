Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class HorariosApertura

    Private Sub HorariosApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarHorarios()
    End Sub

    Public Sub llenarHorarios()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String = "SELECT fecha,TURNO,tipo,hora FROM `horariosinicio`"
        Dim adp As New MySqlDataAdapter(sql, conex)

        ds.Tables.Add("Horarios")
        adp.Fill(ds.Tables("Horarios"))

        Me.DataGridView1.DataSource = ds.Tables("Horarios")
        Me.DataGridView1.Columns(0).HeaderText = "DIA"
        Me.DataGridView1.Columns(3).HeaderText = "HORA"
        Me.DataGridView1.Columns(3).Width = 70
        Me.DataGridView1.Columns(2).HeaderText = "TIPO"
        Me.DataGridView1.Columns(2).Width = 80
        Me.DataGridView1.Columns(1).HeaderText = "TURNO"
        Me.DataGridView1.Columns(1).Width = 50

        Me.DataGridView1.Columns(0).Resizable = DataGridViewTriState.False
        Me.DataGridView1.Columns(1).Resizable = DataGridViewTriState.False
        Me.DataGridView1.Columns(2).Resizable = DataGridViewTriState.False
        Me.DataGridView1.Columns(3).Resizable = DataGridViewTriState.False

        Dim style As New DataGridViewCellStyle()
        style.Font = New Font(DataGridView1.Font, FontStyle.Bold)

        DataGridView1.Columns(3).DefaultCellStyle = style

        DataGridView1.Sort(DataGridView1.Columns(0), ListSortDirection.Descending)

    End Sub

  
    Private Sub DataGridView1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        If DataGridView1.Rows(e.RowIndex).Cells(0).Value = Date.Now.ToString("dd/MM/yyyy") Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
        End If
    End Sub
End Class