using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace ALBERGUE_HUELLITAS_FELICES;

public class UsuarioInfo
{
    public int IdUsuario { get; set; }
    public string Usuario { get; set; } = "";
    public string Hash { get; set; } = "";
    public int Intentos { get; set; }
    public string Estado { get; set; } = "";
    public string Rol { get; set; } = "";
    public string NombreCompleto { get; set; } = "";
    public int IdPersonal { get; set; }
}

public static class UsuarioDatos
{
    public static bool ExisteAdministrador()
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            "SELECT COUNT(*) FROM dbo.Usuarios WHERE Rol = @rol", cn);
        cmd.Parameters.AddWithValue("@rol", "Administrador");
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public static void CrearAdministradorInicial(string usuario, string contrasena)
    {
        CrearRegistro("Jhasmin", usuario, contrasena, "Administrador");
    }

    private static void CrearRegistro(string nombreCompleto, string usuario, string contrasena, string rol)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            @"INSERT INTO dbo.Usuarios
                (NombreCompleto, NombreUsuario, PasswordHash, Rol, Estado, FechaCreacion, NumeroIntentos)
              VALUES (@nombre, @usuario, @hash, @rol, 1, GETDATE(), 0)", cn);
        cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@hash", Seguridad.GenerarHash(contrasena));
        cmd.Parameters.AddWithValue("@rol", rol);
        cmd.ExecuteNonQuery();
    }

    public static UsuarioInfo? ObtenerPorUsuario(string usuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            @"SELECT u.IdUsuario, u.NombreUsuario, u.PasswordHash, u.NumeroIntentos,
                     CASE WHEN u.NumeroIntentos >= 3 THEN N'Bloqueado'
                          WHEN u.Estado = 1 THEN N'Activo' ELSE N'Inactivo' END,
                     u.Rol, u.NombreCompleto, 0
              FROM dbo.Usuarios u
              WHERE u.NombreUsuario = @usuario", cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);

        using var rd = cmd.ExecuteReader();
        if (!rd.Read()) return null;
        return new UsuarioInfo
        {
            IdUsuario = rd.GetInt32(0),
            Usuario = rd.GetString(1),
            Hash = rd.GetString(2),
            Intentos = rd.GetInt32(3),
            Estado = rd.GetString(4),
            Rol = rd.GetString(5),
            NombreCompleto = rd.GetString(6),
            IdPersonal = rd.GetInt32(7)
        };
    }

    public static void RegistrarIntentoFallido(int idUsuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            @"UPDATE dbo.Usuarios
              SET NumeroIntentos = NumeroIntentos + 1,
                  Estado = CASE WHEN NumeroIntentos + 1 >= 3 THEN 0 ELSE Estado END
              WHERE IdUsuario = @id", cn);
        cmd.Parameters.AddWithValue("@id", idUsuario);
        cmd.ExecuteNonQuery();
    }

    public static void ReiniciarIntentos(int idUsuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            "UPDATE dbo.Usuarios SET NumeroIntentos = 0 WHERE IdUsuario = @id", cn);
        cmd.Parameters.AddWithValue("@id", idUsuario);
        cmd.ExecuteNonQuery();
    }

    public static bool ExisteUsuario(string usuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            "SELECT COUNT(*) FROM dbo.Usuarios WHERE NombreUsuario = @usuario", cn);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public static void CrearUsuario(string nombreCompleto, string usuario, string contrasena, string rol)
    {
        CrearRegistro(nombreCompleto, usuario, contrasena, rol);
    }

    public static DataTable ListarUsuarios()
    {
        var tabla = new DataTable();
        using var cn = Conexion.Obtener();
        using var da = new SqlDataAdapter(
            @"SELECT ROW_NUMBER() OVER (ORDER BY u.IdUsuario) AS Numero,
                     u.IdUsuario AS id_usuario,
                     u.NombreCompleto AS NombreCompleto,
                     u.NombreUsuario AS Usuario,
                     u.Rol AS Rol,
                     CASE WHEN u.NumeroIntentos >= 3 THEN N'Bloqueado'
                          WHEN u.Estado = 1 THEN N'Activo' ELSE N'Inactivo' END AS Estado,
                     u.NumeroIntentos AS Intentos
              FROM dbo.Usuarios u
              ORDER BY u.IdUsuario", cn);
        da.Fill(tabla);
        return tabla;
    }

    public static void Desbloquear(int idUsuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            "UPDATE dbo.Usuarios SET NumeroIntentos = 0, Estado = 1 WHERE IdUsuario = @id", cn);
        cmd.Parameters.AddWithValue("@id", idUsuario);
        cmd.ExecuteNonQuery();
    }

    public static int ContarAdministradores()
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            "SELECT COUNT(*) FROM dbo.Usuarios WHERE Rol = @rol", cn);
        cmd.Parameters.AddWithValue("@rol", "Administrador");
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    public static void EliminarUsuario(int idUsuario)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var tx = cn.BeginTransaction();
        try
        {
            using (var c2 = new SqlCommand(
                "DELETE FROM dbo.Usuarios WHERE IdUsuario = @id", cn, tx))
            {
                c2.Parameters.AddWithValue("@id", idUsuario);
                c2.ExecuteNonQuery();
            }

            tx.Commit();
        }
        catch (SqlException ex) when (ex.Number == 547)
        {
            tx.Rollback();
            throw new InvalidOperationException(
                "No se puede eliminar: esta persona tiene registros asociados (mascotas, compras o adopciones).");
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public static void ActualizarUsuario(int idUsuario, string nombreCompleto, string rol, string? nuevaContrasena)
    {
        using var cn = Conexion.Obtener();
        cn.Open();
        using var cmd = new SqlCommand(
            @"UPDATE dbo.Usuarios
              SET NombreCompleto = @nombre,
                  Rol = @rol,
                  PasswordHash = CASE WHEN @hash IS NULL THEN PasswordHash ELSE @hash END
              WHERE IdUsuario = @id", cn);
        cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
        cmd.Parameters.AddWithValue("@rol", rol);
        cmd.Parameters.AddWithValue("@hash",
            string.IsNullOrEmpty(nuevaContrasena) ? DBNull.Value : Seguridad.GenerarHash(nuevaContrasena));
        cmd.Parameters.AddWithValue("@id", idUsuario);
        cmd.ExecuteNonQuery();
    }
}
