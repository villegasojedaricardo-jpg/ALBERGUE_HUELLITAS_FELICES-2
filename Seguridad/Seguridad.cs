using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace ALBERGUE_HUELLITAS_FELICES;

    public static class Seguridad
    {
        private const int Iteraciones = 100000;

        // Devuelve "iteraciones.sal.hash" en un solo texto, listo para guardar en usuarios.contrasena
        public static string GenerarHash(string contrasena)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(contrasena, sal, Iteraciones, HashAlgorithmName.SHA256, 32);
            return $"{Iteraciones}.{Convert.ToBase64String(sal)}.{Convert.ToBase64String(hash)}";
        }

        // Compara lo que escribió el usuario con lo guardado en la base
        public static bool Verificar(string contrasena, string guardado)
        {
            string[] p = guardado.Split('.');
            if (p.Length != 3) return false;

            int iter = int.Parse(p[0]);
            byte[] sal = Convert.FromBase64String(p[1]);
            byte[] esperado = Convert.FromBase64String(p[2]);

            byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(contrasena, sal, iter, HashAlgorithmName.SHA256, esperado.Length);
            return CryptographicOperations.FixedTimeEquals(calculado, esperado);
        }
    }


