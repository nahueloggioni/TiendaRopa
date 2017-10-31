<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compras))
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.calHasta = New System.Windows.Forms.DateTimePicker()
        Me.calDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tablaDetalleCompra = New System.Windows.Forms.DataGridView()
        Me.tablaCompras = New System.Windows.Forms.DataGridView()
        CType(Me.tablaDetalleCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(944, 47)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 20)
        Me.lblID.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(910, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "ID"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(558, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'calHasta
        '
        Me.calHasta.Location = New System.Drawing.Point(336, 13)
        Me.calHasta.Name = "calHasta"
        Me.calHasta.Size = New System.Drawing.Size(200, 20)
        Me.calHasta.TabIndex = 21
        '
        'calDesde
        '
        Me.calDesde.Location = New System.Drawing.Point(74, 12)
        Me.calDesde.Name = "calDesde"
        Me.calDesde.Size = New System.Drawing.Size(200, 20)
        Me.calDesde.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(516, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "DETALLE COMPRA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "COMPRAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(280, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Hasta: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Desde: "
        '
        'tablaDetalleCompra
        '
        Me.tablaDetalleCompra.AllowUserToAddRows = False
        Me.tablaDetalleCompra.AllowUserToDeleteRows = False
        Me.tablaDetalleCompra.AllowUserToResizeColumns = False
        Me.tablaDetalleCompra.BackgroundColor = System.Drawing.SystemColors.Control
        Me.tablaDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tablaDetalleCompra.Location = New System.Drawing.Point(520, 70)
        Me.tablaDetalleCompra.Name = "tablaDetalleCompra"
        Me.tablaDetalleCompra.ReadOnly = True
        Me.tablaDetalleCompra.Size = New System.Drawing.Size(452, 480)
        Me.tablaDetalleCompra.TabIndex = 15
        '
        'tablaCompras
        '
        Me.tablaCompras.AllowUserToAddRows = False
        Me.tablaCompras.AllowUserToDeleteRows = False
        Me.tablaCompras.AllowUserToOrderColumns = True
        Me.tablaCompras.AllowUserToResizeColumns = False
        Me.tablaCompras.BackgroundColor = System.Drawing.SystemColors.Control
        Me.tablaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tablaCompras.Location = New System.Drawing.Point(12, 70)
        Me.tablaCompras.MultiSelect = False
        Me.tablaCompras.Name = "tablaCompras"
        Me.tablaCompras.ReadOnly = True
        Me.tablaCompras.Size = New System.Drawing.Size(500, 480)
        Me.tablaCompras.TabIndex = 14
        '
        'Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.calHasta)
        Me.Controls.Add(Me.calDesde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tablaDetalleCompra)
        Me.Controls.Add(Me.tablaCompras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Compras"
        CType(Me.tablaDetalleCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents calHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents calDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tablaDetalleCompra As System.Windows.Forms.DataGridView
    Friend WithEvents tablaCompras As System.Windows.Forms.DataGridView
End Class
