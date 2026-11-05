using System;
using System.Collections.Generic;
using System.Text;

namespace ALBERGUE_HUELLITAS_FELICES;

public static class Sesion
{
    public static int IdUsuario { get; set; }
    public static string NombreCompleto { get; set; } = "";
    public static string Rol { get; set; } = "";
    public static bool Autenticado { get; set; }
    public static int IdPersonal { get; set; }
    public static void Cerrar()
    {
        IdUsuario = 0;
        NombreCompleto = "";
        Rol = "";
        Autenticado = false;
        IdPersonal = 0;
    }
}