using System.Data;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace ALBERGUE_HUELLITAS_FELICES.Reportes;

public static class PdfExporter
{
    public static void Exportar(DataTable tabla, string titulo, string resumen, string ruta)
    {
        using var documento = new PdfDocument();
        int fila = 0;
        int filasPorPagina = 28;

        while (fila < Math.Max(tabla.Rows.Count, 1))
        {
            var pagina = documento.AddPage();
            pagina.Orientation = PdfSharpCore.PageOrientation.Landscape;
            pagina.Size = PdfSharpCore.PageSize.A4;

            using var grafico = XGraphics.FromPdfPage(pagina);
            var fuenteTitulo = new XFont("Arial", 16, XFontStyle.Bold);
            var fuenteNormal = new XFont("Arial", 8, XFontStyle.Regular);
            var fuenteEncabezado = new XFont("Arial", 8, XFontStyle.Bold);
            var lapiz = new XPen(XColors.LightGray, 0.5);
            var margen = 28d;
            var anchoUtil = pagina.Width - (margen * 2);
            var altoFila = 18d;
            var y = 28d;

            grafico.DrawString(titulo, fuenteTitulo, XBrushes.MidnightBlue,
                new XRect(margen, y, anchoUtil, 24), XStringFormats.TopLeft);
            y += 25;
            grafico.DrawString($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm} | {resumen}",
                fuenteNormal, XBrushes.Black,
                new XRect(margen, y, anchoUtil, 16), XStringFormats.TopLeft);
            y += 24;

            if (tabla.Columns.Count == 0)
            {
                grafico.DrawString("El reporte no contiene columnas.", fuenteNormal, XBrushes.Black,
                    new XRect(margen, y, anchoUtil, 20), XStringFormats.TopLeft);
                break;
            }

            var anchoColumna = anchoUtil / tabla.Columns.Count;
            for (int columna = 0; columna < tabla.Columns.Count; columna++)
            {
                var rect = new XRect(margen + (columna * anchoColumna), y,
                    anchoColumna, altoFila);
                grafico.DrawRectangle(XBrushes.LightSteelBlue, rect);
                grafico.DrawRectangle(lapiz, rect);
                grafico.DrawString(Texto(tabla.Columns[columna].ColumnName, 22),
                    fuenteEncabezado, XBrushes.Black, rect, XStringFormats.CenterLeft);
            }
            y += altoFila;

            if (tabla.Rows.Count == 0)
            {
                grafico.DrawString("No hay resultados para los filtros seleccionados.",
                    fuenteNormal, XBrushes.Black,
                    new XRect(margen, y + 6, anchoUtil, 20), XStringFormats.TopLeft);
                break;
            }

            int limite = Math.Min(fila + filasPorPagina, tabla.Rows.Count);
            for (; fila < limite; fila++)
            {
                var datos = tabla.Rows[fila];
                for (int columna = 0; columna < tabla.Columns.Count; columna++)
                {
                    var rect = new XRect(margen + (columna * anchoColumna), y,
                        anchoColumna, altoFila);
                    if (fila % 2 == 0)
                        grafico.DrawRectangle(new XSolidBrush(XColor.FromArgb(248, 250, 252)), rect);
                    grafico.DrawRectangle(lapiz, rect);
                    var valor = datos[columna] == DBNull.Value ? "" : Formatear(datos[columna]);
                    grafico.DrawString(Texto(valor, 24), fuenteNormal, XBrushes.Black,
                        rect, XStringFormats.CenterLeft);
                }
                y += altoFila;
            }

            grafico.DrawString($"Página {documento.PageCount}", fuenteNormal, XBrushes.Gray,
                new XRect(margen, pagina.Height - 24, anchoUtil, 14), XStringFormats.TopRight);
        }

        documento.Save(ruta);
    }

    private static string Formatear(object valor)
    {
        return valor switch
        {
            DateTime fecha => fecha.ToString("dd/MM/yyyy"),
            decimal numero => numero.ToString("N2"),
            double numero => numero.ToString("N2"),
            float numero => numero.ToString("N2"),
            _ => valor.ToString() ?? ""
        };
    }

    private static string Texto(string texto, int maximo)
    {
        texto = texto.Replace("\r", " ").Replace("\n", " ");
        return texto.Length <= maximo ? texto : texto[..(maximo - 1)] + "…";
    }
}
