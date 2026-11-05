using ALBERGUE_HUELLITAS_FELICES.Usuarios;

namespace ALBERGUE_HUELLITAS_FELICES
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            // temporal, para probar solo este formulario
            ApplicationConfiguration.Initialize();
         

            try
            {
                if (!UsuarioDatos.ExisteAdministrador())
                    UsuarioDatos.CrearAdministradorInicial("Jhasmin", "010308jr");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo preparar la base de datos: " + ex.Message);
            }

            Application.Run(new INISION_DE_SESION());
        }

    }
       
    
}