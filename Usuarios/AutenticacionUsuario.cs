using System;
using System.Collections.Generic;
using System.Text;


namespace ALBERGUE_HUELLITAS_FELICES.Usuarios
{
    public static class AutenticacionUsuario
    {
        public static bool IniciarSesion(string usuario, string clave, out string mensaje)
        {
        const string generico = "Usuario o contraseña incorrectos.";
        mensaje = "";

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
        {
            mensaje = "Ingrese su usuario y su contraseña.";
            return false;
        }

         UsuarioInfo? u = UsuarioDatos.ObtenerPorUsuario(usuario.Trim());
        if (u == null) { mensaje = generico; return false; }          // no revela si el usuario existe

        if (!Seguridad.Verificar(clave, u.Hash))
        {
            if (u.Estado == "Activo")
                UsuarioDatos.RegistrarIntentoFallido(u.IdUsuario);    // al 3.er intento queda Bloqueado
            mensaje = generico;
            return false;
        }

        if (u.Estado == "Bloqueado") { mensaje = "Cuenta bloqueada. Contacte al administrador."; return false; }
        if (u.Estado != "Activo")    { mensaje = "La cuenta está inactiva.";                   return false; }

        UsuarioDatos.ReiniciarIntentos(u.IdUsuario);
        Sesion.IdUsuario = u.IdUsuario;
        Sesion.NombreCompleto = u.NombreCompleto;
        Sesion.Rol = u.Rol;
        Sesion.Autenticado = true;
         Sesion.IdPersonal = u.IdPersonal;
         return true;
    }
        public static bool Crear(string nombreCompleto, string usuario, string contrasena,
                                 string confirmar, string? rol, out string mensaje)
        {
            nombreCompleto = (nombreCompleto ?? "").Trim();
            usuario = (usuario ?? "").Trim();
            contrasena ??= "";
            confirmar ??= "";

            if (nombreCompleto == "" || usuario == "" || contrasena == "" || confirmar == "")
            {
                mensaje = "Complete todos los campos obligatorios.";
                return false;
            }

            if (rol != "Administrador" && rol != "Empleado")
            {
                mensaje = "Seleccione un rol válido.";
                return false;
            }

            if (nombreCompleto.Length > 100)
            {
                mensaje = "El nombre completo no puede superar los 100 caracteres.";
                return false;
            }

            if (usuario.Length > 50 || usuario.Contains(' '))
            {
                mensaje = "El usuario debe tener máximo 50 caracteres y no puede llevar espacios.";
                return false;
            }

            if (contrasena != confirmar)
            {
                mensaje = "La contraseña y su confirmación no coinciden.";
                return false;
            }

            if (!ContrasenaValida(contrasena, out mensaje))
                return false;

            try
            {
                if (UsuarioDatos.ExisteUsuario(usuario))
                {
                    mensaje = "Ese nombre de usuario ya está en uso.";
                    return false;
                }

                UsuarioDatos.CrearUsuario(nombreCompleto, usuario, contrasena, rol);
                mensaje = "Usuario creado correctamente.";
                return true;
            }
            catch (InvalidOperationException ex)
            {
                mensaje = ex.Message;
                return false;
            }
            catch (Exception)
            {
                mensaje = "No se pudo crear el usuario. Intente de nuevo.";
                return false;
            }
        }

        private static bool ContrasenaValida(string contrasena, out string mensaje)
        {
            mensaje = "";

            if (contrasena.Length < 8)
                mensaje = "La contraseña debe tener al menos 8 caracteres.";
            else if (!contrasena.Any(char.IsLetter))
                mensaje = "La contraseña debe incluir al menos una letra.";
            else if (!contrasena.Any(char.IsDigit))
                mensaje = "La contraseña debe incluir al menos un número.";

            return mensaje == "";
        }

        public static bool Editar(int idUsuario, string rolActual, string nombreCompleto, string? rol,
                                  string contrasena, string confirmar, out string mensaje)
        {
            nombreCompleto = (nombreCompleto ?? "").Trim();
            contrasena ??= "";
            confirmar ??= "";

            if (idUsuario == 0)
            {
                mensaje = "Seleccione un usuario de la lista.";
                return false;
            }

            if (nombreCompleto == "" || nombreCompleto.Length > 100)
            {
                mensaje = "Ingrese un nombre completo válido (máximo 100 caracteres).";
                return false;
            }

            if (rol != "Administrador" && rol != "Empleado")
            {
                mensaje = "Seleccione un rol válido.";
                return false;
            }

            if (contrasena != "" || confirmar != "")
            {
                if (contrasena != confirmar)
                {
                    mensaje = "La contraseña y su confirmación no coinciden.";
                    return false;
                }
                if (!ContrasenaValida(contrasena, out mensaje))
                    return false;
            }

            try
            {
                // No dejar el sistema sin administradores
                if (rolActual == "Administrador" && rol == "Empleado" && UsuarioDatos.ContarAdministradores() <= 1)
                {
                    mensaje = "No se puede quitar el rol al único administrador del sistema.";
                    return false;
                }

                UsuarioDatos.ActualizarUsuario(idUsuario, nombreCompleto, rol,
                    contrasena == "" ? null : contrasena);
                mensaje = "Usuario actualizado correctamente.";
                return true;
            }
            catch (InvalidOperationException ex)
            {
                mensaje = ex.Message;
                return false;
            }
            catch (Exception)
            {
                mensaje = "No se pudo actualizar el usuario.";
                return false;
            }
        }
    }
}

