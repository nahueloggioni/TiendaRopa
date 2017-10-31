Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.Barcode128
Public Class CodigosBarra
    Public Shared Function codigo128(ByVal _code As String, Optional ByVal descrip As String = " ", Optional ByVal vertexto As Boolean = False, Optional ByVal Height As Single = 0)
        Dim barcode As New Barcode128
        barcode.StartStopText = True
        If Height <> 0 Then
            barcode.BarHeight = Height
        End If
        barcode.Code = _code
        
        Try
            Dim bm As New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))
            Dim ancho As Integer = 350
            If bm.Width < 350 Then
                If vertexto = False Then
                    Return bm
                Else
                    'generando el texto
                    Dim bmT As Image
                    bmT = New Bitmap(ancho, bm.Height + 30)
                    Dim g As Graphics = Graphics.FromImage(bmT)
                    g.FillRectangle(New SolidBrush(Color.White), 0, 0, ancho, bm.Height + 30)

                    'Codigo texto
                    Dim pintarTexto As New Font("Arial", 8)
                    Dim brocha As New SolidBrush(Color.Black)

                    Dim stringSize As New SizeF
                    stringSize = g.MeasureString(_code, pintarTexto)
                    Dim centrox As Single = (ancho - stringSize.Width) / 2
                    Dim x As Single = centrox
                    Dim y As Single = bm.Height + 15

                    'Descripcion
                    Dim pintarTexto2 As New Font("News706 BT", 10, FontStyle.Bold)
                    Dim brocha2 As New SolidBrush(Color.Black)

                    Dim stringSize2 As New SizeF
                    stringSize2 = g.MeasureString(descrip, pintarTexto2)
                    Dim centrox2 As Single = (ancho - stringSize2.Width) / 2
                    Dim x2 As Single = centrox2
                    Dim y2 As Single = 0

                    'Pintar codigo de barras y texto codigo
                    Dim drawformat As New StringFormat
                    drawformat.FormatFlags = StringFormatFlags.NoWrap

                    Dim centroC As Integer = (ancho - bm.Width) / 2
                    g.DrawImage(bm, centroC, 15)

                    Dim ncode As String = _code.ToString
                    g.DrawString(ncode, pintarTexto, brocha, x, y, drawformat)

                    'Pintar descripcion
                    Dim ncode2 As String = descrip.ToString
                    g.DrawString(ncode2, pintarTexto2, brocha2, x2, y2)

                    Return bmT

                End If
            Else
                MsgBox("El codigo es muy largo para generar el Codigo de Barras")
                Dim bmE As Image
                bmE = New Bitmap(ancho, 80)
                Dim g As Graphics = Graphics.FromImage(bmE)
                Dim pintarTexto As New Font("Arial", 12)
                Dim brocha As New SolidBrush(Color.Black)
                Dim x As Single = 10
                Dim y As Single = 10
                g.DrawString("Error al generar el codigo de barras", pintarTexto, brocha, x, y)
                Return bmE
            End If
        Catch ex As Exception
            Throw New Exception("Error al generar el codigo" & ex.ToString)
        End Try
    End Function

End Class
