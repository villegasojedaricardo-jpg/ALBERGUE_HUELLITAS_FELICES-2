using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ALBERGUE_HUELLITAS_FELICES.Usuarios;
namespace ALBERGUE_HUELLITAS_FELICES;

public partial class INISION_DE_SESION : Form
{
    public INISION_DE_SESION()
    {
        InitializeComponent();
    }

    private void INISION_DE_SESION_Load(object sender, EventArgs e)
    {
    }

    private void btnIngresar_Click(object sender, EventArgs e)

    {
        if (AutenticacionUsuario.IniciarSesion(txtUsuario.Text, txtContrasena.Text, out string mensaje))
        {
            var inicio = new INICIO();
            inicio.FormClosed += (s, args) =>
            {
                if (Sesion.Autenticado)
                {
                    Application.Exit();      
                }
                else
                {
                    txtUsuario.Clear();     
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                    Show();
                }
            };
            inicio.Show();
            Hide();
            
        }
        else
        {
            MessageBox.Show(mensaje, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtContrasena.Clear();
            txtContrasena.Focus();
        }
    }

}
