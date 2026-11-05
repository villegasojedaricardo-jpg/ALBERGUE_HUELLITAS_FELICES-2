using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public static class Conexion
    {
        private const string Cadena = @"Server=LAPTOP-G92RG5L1\SQLEXPRESS;Database=Huellitas_Felices;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection Obtener() => new SqlConnection(Cadena);
    }
}
