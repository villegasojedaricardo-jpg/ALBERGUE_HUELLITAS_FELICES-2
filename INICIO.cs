using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class INICIO : Form
    {
        public INICIO()
        {
            InitializeComponent();
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            MASCOTAS frm = new MASCOTAS();
            frm.Show();
        }

        private void btnAplicarVacunaInicio_Click(object sender, EventArgs e)
        {
            APLICACION_VACUNAS frm = new APLICACION_VACUNAS();
            frm.Show();
        }

        private void txtPersonal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPersonal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnTipoVacunaInicio_Click(object sender, EventArgs e)
        {
            TIPO_DE_VACUNA frm = new TIPO_DE_VACUNA();
            frm.Show();
        }

        private void btnNuevaAdopcionInicio_Click(object sender, EventArgs e)
        {
            REGISTRO_ADOPCION frm = new REGISTRO_ADOPCION();
            frm.Show();
        }

        private void btnDonacionInsumoInicio_Click(object sender, EventArgs e)
        {
            DONACION_INSUMOS frm = new DONACION_INSUMOS();
            frm.Show();
        }

        private void btnInsumoInicio_Click(object sender, EventArgs e)
        {
            INSUMO frm = new INSUMO();
            frm.Show();
        }

        private void btnAdoptanteInicio_Click(object sender, EventArgs e)
        {
            ADOPTANTES frm = new ADOPTANTES();
            frm.Show();
        }

        private void btnSegumientoInicio_Click(object sender, EventArgs e)
        {
            SEGUIMIENTOS frm = new SEGUIMIENTOS();
            frm.Show();
        }

        private void btnDonanteInicio_Click(object sender, EventArgs e)
        {
            DONANTES frm = new DONANTES();
            frm.Show();
        }

        private void btnAporteEconomicoInicio_Click(object sender, EventArgs e)
        {
            APORTES_ECONOMICOS frm = new APORTES_ECONOMICOS();
            frm.Show();
        }

        private void INICIO_Load(object sender, EventArgs e)
        {
            {
                if (!Sesion.Autenticado)
                {
                    Close();
                    return;
                }

                txtPersonal.Text = Sesion.NombreCompleto;
                btnUsuarios.Visible = Sesion.Rol == "Administrador";
            }

        }

        private void btnComprasInicio_Click(object sender, EventArgs e)
        {
            COMPRAS frm = new COMPRAS();
            frm.Show();
        }

        private void btnCerrarSesionInicio_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();
            Close();
        }

        private void btnSalirInicio_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CREARUSUARIOS frm = new CREARUSUARIOS();
            frm.ShowDialog();

        }

        private void btnReportes_Click(object? sender, EventArgs e)
        {
            using var frm = new REPORTES();
            frm.ShowDialog(this);
        }
    }
    
}

