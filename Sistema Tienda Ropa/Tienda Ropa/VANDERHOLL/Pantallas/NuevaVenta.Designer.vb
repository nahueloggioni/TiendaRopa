<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevaVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NuevaVenta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoArtVenta = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalCuota = New System.Windows.Forms.Label()
        Me.lblde = New System.Windows.Forms.Label()
        Me.comboCuotas = New System.Windows.Forms.ComboBox()
        Me.lblCuotas = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTarjeta = New System.Windows.Forms.RadioButton()
        Me.btnEfectivo = New System.Windows.Forms.RadioButton()
        Me.btnVender = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnDebito = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Humnst777 Blk BT", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nueva Venta"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Articulo, Me.Stock, Me.Precio, Me.Cantidad})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 102)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(760, 283)
        Me.DataGridView1.TabIndex = 1
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Codigo.Width = 120
        '
        'Articulo
        '
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Articulo.Width = 300
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo: "
        '
        'txtCodigoArtVenta
        '
        Me.txtCodigoArtVenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCodigoArtVenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCodigoArtVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoArtVenta.Location = New System.Drawing.Point(85, 43)
        Me.txtCodigoArtVenta.Name = "txtCodigoArtVenta"
        Me.txtCodigoArtVenta.Size = New System.Drawing.Size(167, 26)
        Me.txtCodigoArtVenta.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(258, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel1.Controls.Add(Me.btnDebito)
        Me.Panel1.Controls.Add(Me.lblTotalCuota)
        Me.Panel1.Controls.Add(Me.lblde)
        Me.Panel1.Controls.Add(Me.comboCuotas)
        Me.Panel1.Controls.Add(Me.lblCuotas)
        Me.Panel1.Controls.Add(Me.lblTotalVenta)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnTarjeta)
        Me.Panel1.Controls.Add(Me.btnEfectivo)
        Me.Panel1.Location = New System.Drawing.Point(778, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 200)
        Me.Panel1.TabIndex = 5
        '
        'lblTotalCuota
        '
        Me.lblTotalCuota.AutoSize = True
        Me.lblTotalCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCuota.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalCuota.Location = New System.Drawing.Point(110, 130)
        Me.lblTotalCuota.Name = "lblTotalCuota"
        Me.lblTotalCuota.Size = New System.Drawing.Size(0, 20)
        Me.lblTotalCuota.TabIndex = 7
        Me.lblTotalCuota.Visible = False
        '
        'lblde
        '
        Me.lblde.AutoSize = True
        Me.lblde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblde.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblde.Location = New System.Drawing.Point(69, 130)
        Me.lblde.Name = "lblde"
        Me.lblde.Size = New System.Drawing.Size(35, 20)
        Me.lblde.TabIndex = 6
        Me.lblde.Text = "de: "
        Me.lblde.Visible = False
        '
        'comboCuotas
        '
        Me.comboCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboCuotas.FormattingEnabled = True
        Me.comboCuotas.Location = New System.Drawing.Point(73, 106)
        Me.comboCuotas.Name = "comboCuotas"
        Me.comboCuotas.Size = New System.Drawing.Size(121, 21)
        Me.comboCuotas.TabIndex = 5
        Me.comboCuotas.Visible = False
        '
        'lblCuotas
        '
        Me.lblCuotas.AutoSize = True
        Me.lblCuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuotas.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCuotas.Location = New System.Drawing.Point(3, 107)
        Me.lblCuotas.Name = "lblCuotas"
        Me.lblCuotas.Size = New System.Drawing.Size(64, 20)
        Me.lblCuotas.TabIndex = 4
        Me.lblCuotas.Text = "Cuotas:"
        Me.lblCuotas.Visible = False
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.AutoSize = True
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalVenta.Location = New System.Drawing.Point(66, 147)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(0, 33)
        Me.lblTotalVenta.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(3, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TOTAL:"
        '
        'btnTarjeta
        '
        Me.btnTarjeta.AutoSize = True
        Me.btnTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTarjeta.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnTarjeta.Location = New System.Drawing.Point(3, 80)
        Me.btnTarjeta.Name = "btnTarjeta"
        Me.btnTarjeta.Size = New System.Drawing.Size(78, 24)
        Me.btnTarjeta.TabIndex = 1
        Me.btnTarjeta.Text = "Credito"
        Me.btnTarjeta.UseVisualStyleBackColor = True
        '
        'btnEfectivo
        '
        Me.btnEfectivo.AutoSize = True
        Me.btnEfectivo.Checked = True
        Me.btnEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEfectivo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEfectivo.Location = New System.Drawing.Point(3, 20)
        Me.btnEfectivo.Name = "btnEfectivo"
        Me.btnEfectivo.Size = New System.Drawing.Size(84, 24)
        Me.btnEfectivo.TabIndex = 0
        Me.btnEfectivo.TabStop = True
        Me.btnEfectivo.Text = "Efectivo"
        Me.btnEfectivo.UseVisualStyleBackColor = True
        '
        'btnVender
        '
        Me.btnVender.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVender.Location = New System.Drawing.Point(826, 308)
        Me.btnVender.Name = "btnVender"
        Me.btnVender.Size = New System.Drawing.Size(100, 60)
        Me.btnVender.TabIndex = 6
        Me.btnVender.Text = "Vender"
        Me.btnVender.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(611, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha: "
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(679, 46)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(0, 20)
        Me.lblFecha.TabIndex = 8
        '
        'btnDebito
        '
        Me.btnDebito.AutoSize = True
        Me.btnDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDebito.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDebito.Location = New System.Drawing.Point(3, 50)
        Me.btnDebito.Name = "btnDebito"
        Me.btnDebito.Size = New System.Drawing.Size(74, 24)
        Me.btnDebito.TabIndex = 8
        Me.btnDebito.TabStop = True
        Me.btnDebito.Text = "Debito"
        Me.btnDebito.UseVisualStyleBackColor = True
        '
        'NuevaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(984, 411)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnVender)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCodigoArtVenta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 450)
        Me.MinimumSize = New System.Drawing.Size(1000, 450)
        Me.Name = "NuevaVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuevaVenta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoArtVenta As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTotalVenta As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnTarjeta As System.Windows.Forms.RadioButton
    Friend WithEvents btnEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnVender As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents comboCuotas As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuotas As System.Windows.Forms.Label
    Friend WithEvents lblTotalCuota As System.Windows.Forms.Label
    Friend WithEvents lblde As System.Windows.Forms.Label
    Friend WithEvents btnDebito As System.Windows.Forms.RadioButton
End Class
