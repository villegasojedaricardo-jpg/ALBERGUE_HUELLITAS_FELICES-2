using Microsoft.Data.SqlClient;
using System.Data;

namespace ALBERGUE_HUELLITAS_FELICES.Reportes;

public static class ReportesDatos
{
    public static List<string> ListarEspecies()
    {
        return EjecutarLista("SELECT DISTINCT especie FROM dbo.mascotas WHERE especie IS NOT NULL AND LTRIM(RTRIM(especie)) <> '' ORDER BY especie");
    }

    public static List<string> ListarTiposInsumo()
    {
        return EjecutarLista("SELECT DISTINCT tipo_insumo FROM dbo.insumos WHERE tipo_insumo IS NOT NULL AND LTRIM(RTRIM(tipo_insumo)) <> '' ORDER BY tipo_insumo");
    }

    public static DataTable Mascotas(string? estado, string? especie)
    {
        const string sql = @"
            SELECT m.id_mascota AS Id,
                   m.nombre AS Nombre,
                   m.especie AS Especie,
                   m.fecha_ingreso AS FechaIngreso,
                   m.estado_disponibilidad AS Estado
            FROM dbo.mascotas m
            WHERE (@estado = '' OR m.estado_disponibilidad = @estado)
              AND (@especie = '' OR m.especie = @especie)
            ORDER BY m.estado_disponibilidad, m.nombre;";

        return Ejecutar(sql,
            new SqlParameter("@estado", estado?.Trim() ?? ""),
            new SqlParameter("@especie", especie?.Trim() ?? ""));
    }

    public static DataTable Adopciones(DateTime? desde, DateTime? hasta)
    {
        const string sql = @"
            SELECT r.id_registro_adopcion AS Id,
                   r.fecha_adopcion AS Fecha,
                   m.nombre AS Mascota,
                   m.especie AS Especie,
                   a.nombre_completo AS Adoptante,
                   a.telefono AS Telefono
            FROM dbo.registros_adopcion r
            INNER JOIN dbo.mascotas m ON m.id_mascota = r.id_mascota
            INNER JOIN dbo.adoptantes a ON a.id_adoptante = r.id_adoptante
            WHERE (@desde IS NULL OR r.fecha_adopcion >= @desde)
              AND (@hasta IS NULL OR r.fecha_adopcion < DATEADD(day, 1, @hasta))
            ORDER BY r.fecha_adopcion DESC;";

        return Ejecutar(sql,
            FechaParametro("@desde", desde),
            FechaParametro("@hasta", hasta));
    }

    public static DataTable Vacunaciones(DateTime? desde, DateTime? hasta)
    {
        const string sql = @"
            SELECT a.id_aplicacion AS Id,
                   a.fecha_aplicacion AS Fecha,
                   m.nombre AS Mascota,
                   m.especie AS Especie,
                   t.nombre_vacuna AS Vacuna,
                   t.dosis_recomendada AS Dosis
            FROM dbo.aplicaciones_vacuna a
            INNER JOIN dbo.mascotas m ON m.id_mascota = a.id_mascota
            INNER JOIN dbo.tipos_vacuna t ON t.id_tipo_vacuna = a.id_tipo_vacuna
            WHERE (@desde IS NULL OR a.fecha_aplicacion >= @desde)
              AND (@hasta IS NULL OR a.fecha_aplicacion < DATEADD(day, 1, @hasta))
            ORDER BY a.fecha_aplicacion DESC, m.nombre;";

        return Ejecutar(sql,
            FechaParametro("@desde", desde),
            FechaParametro("@hasta", hasta));
    }

    public static DataTable Insumos(string? tipo, bool soloBajoStock)
    {
        const string sql = @"
            SELECT i.id_insumo AS Id,
                   i.descripcion_insumo AS Insumo,
                   i.tipo_insumo AS Tipo,
                   i.unidad_medida AS Unidad,
                   i.stock_actual AS Stock,
                   i.fecha_vencimiento AS Vencimiento,
                   CASE WHEN i.stock_actual <= 5 THEN N'Bajo' ELSE N'Normal' END AS NivelStock
            FROM dbo.insumos i
            WHERE (@tipo = '' OR i.tipo_insumo = @tipo)
              AND (@soloBajoStock = 0 OR i.stock_actual <= 5)
            ORDER BY i.stock_actual, i.descripcion_insumo;";

        return Ejecutar(sql,
            new SqlParameter("@tipo", tipo?.Trim() ?? ""),
            new SqlParameter("@soloBajoStock", soloBajoStock ? 1 : 0));
    }

    public static DataTable AportesEconomicos(DateTime? desde, DateTime? hasta)
    {
        const string sql = @"
            SELECT ap.id_aporte AS Id,
                   ap.fecha_aporte AS Fecha,
                   d.nombre_completo AS Donante,
                   ap.monto AS Monto
            FROM dbo.aportes_economicos ap
            INNER JOIN dbo.donantes d ON d.id_donante = ap.id_donante
            WHERE (@desde IS NULL OR ap.fecha_aporte >= @desde)
              AND (@hasta IS NULL OR ap.fecha_aporte < DATEADD(day, 1, @hasta))
            ORDER BY ap.fecha_aporte DESC;";

        return Ejecutar(sql,
            FechaParametro("@desde", desde),
            FechaParametro("@hasta", hasta));
    }

    public static DataTable Compras(DateTime? desde, DateTime? hasta)
    {
        const string sql = @"
            SELECT c.id_compra AS Id,
                   c.numero_factura AS Factura,
                   c.fecha_compra AS Fecha,
                   COUNT(dc.id_insumo) AS Lineas,
                   SUM(dc.cantidad * dc.precio_unitario) AS Total
            FROM dbo.compras c
            LEFT JOIN dbo.detalles_compra dc ON dc.id_compra = c.id_compra
            WHERE (@desde IS NULL OR c.fecha_compra >= @desde)
              AND (@hasta IS NULL OR c.fecha_compra < DATEADD(day, 1, @hasta))
            GROUP BY c.id_compra, c.numero_factura, c.fecha_compra
            ORDER BY c.fecha_compra DESC;";

        return Ejecutar(sql,
            FechaParametro("@desde", desde),
            FechaParametro("@hasta", hasta));
    }

    private static SqlParameter FechaParametro(string nombre, DateTime? valor)
    {
        return new SqlParameter(nombre, SqlDbType.DateTime2)
        {
            Value = valor.HasValue ? valor.Value.Date : DBNull.Value
        };
    }

    private static DataTable Ejecutar(string sql, params SqlParameter[] parametros)
    {
        var tabla = new DataTable();
        using var cn = Conexion.Obtener();
        using var cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddRange(parametros);
        using var da = new SqlDataAdapter(cmd);
        da.Fill(tabla);
        return tabla;
    }

    private static List<string> EjecutarLista(string sql)
    {
        var valores = new List<string>();
        using var cn = Conexion.Obtener();
        using var cmd = new SqlCommand(sql, cn);
        cn.Open();
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
            valores.Add(rd.GetString(0));
        return valores;
    }
}
