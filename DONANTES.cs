using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class DONANTES : Form
    {
        public DONANTES()
        {
            InitializeComponent();
        }

        private void DONANTES_Load(object sender, EventArgs e)
        {
            txtNombreCompletoDonante.MaxLength = 100;
            CargarDonantes();
        }

        private void CargarDonantes()
        {
            string sql = @"SELECT id_donante, nombre_completo
                   FROM donantes
                   ORDER BY nombre_completo";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonantes.DataSource = dt;
                    dgvDonantes.Columns["id_donante"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar donantes: " + ex.Message);
            }
        }

        private void btnGuardarDonantes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompletoDonante.Text))
            {
                MessageBox.Show("Escribe el nombre completo.");
                return;
            }

            string sql = @"INSERT INTO donantes (nombre_completo)
                   VALUES (@nombre)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreCompletoDonante.Text.Trim());
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Donante guardado.");
                limpiar();
                CargarDonantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            txtNombreCompletoDonante.Clear();
            txtNombreCompletoDonante.Focus();
        }

        private void btnVolverDonantes_Click(object sender, EventArgs e)
        {
            var inicio = Application.OpenForms.OfType<INICIO>().FirstOrDefault();
            if (inicio != null)
            {
                inicio.Show();
            }
            this.Close();
        }

        private void btnReporteDonacion_Click(object sender, EventArgs e)
        {
            frmReporteDonaciones frm = new frmReporteDonaciones();
            frm.Show();
        }
    }
}
