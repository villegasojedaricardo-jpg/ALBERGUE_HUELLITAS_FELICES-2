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
    public partial class ADOPTANTES : Form
    {
        public ADOPTANTES()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCalleAdoptante_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCiudadAdoptante_TextChanged(object sender, EventArgs e)
        {

        }

        private void ADOPTANTES_Load(object sender, EventArgs e)
        {
            txtNombreAdoptante.MaxLength = 100;
            txtTelefonoAdoptante.MaxLength = 20;
            txtCalleAdoptante.MaxLength = 120;
            txtCiudadAdoptante.MaxLength = 60;
            txtReferenciaAdoptante.MaxLength = 150;

            CargarAdoptantes();
        }

        private void CargarAdoptantes()
        {
            string sql = @"SELECT id_adoptante, nombre_completo, telefono,
                          calle, ciudad, referencia
                   FROM adoptantes
                   ORDER BY nombre_completo";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAdoptantes.DataSource = dt;
                    dgvAdoptantes.Columns["id_adoptante"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar adoptantes: " + ex.Message);
            }
        }

        private void btnGuaradarAdoptantes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreAdoptante.Text) ||
        string.IsNullOrWhiteSpace(txtTelefonoAdoptante.Text) ||
        string.IsNullOrWhiteSpace(txtCalleAdoptante.Text) ||
        string.IsNullOrWhiteSpace(txtCiudadAdoptante.Text))
            {
                MessageBox.Show("Completa nombre, teléfono, calle y ciudad.");
                return;
            }

            string sql = @"INSERT INTO adoptantes (nombre_completo, telefono, calle, ciudad, referencia)
                   VALUES (@nombre, @telefono, @calle, @ciudad, @referencia)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreAdoptante.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefonoAdoptante.Text.Trim());
                    cmd.Parameters.AddWithValue("@calle", txtCalleAdoptante.Text.Trim());
                    cmd.Parameters.AddWithValue("@ciudad", txtCiudadAdoptante.Text.Trim());

                    // Si la referencia está vacía se guarda NULL, no una cadena vacía
                    if (string.IsNullOrWhiteSpace(txtReferenciaAdoptante.Text))
                        cmd.Parameters.AddWithValue("@referencia", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@referencia", txtReferenciaAdoptante.Text.Trim());

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Adoptante guardado.");
                limpiar();
                CargarAdoptantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            txtNombreAdoptante.Clear();
            txtTelefonoAdoptante.Clear();
            txtCalleAdoptante.Clear();
            txtCiudadAdoptante.Clear();
            txtReferenciaAdoptante.Clear();
            txtNombreAdoptante.Focus();
        }

        private void btnVolverAdoptantes_Click(object sender, EventArgs e)
        {
            var inicio = Application.OpenForms.OfType<INICIO>().FirstOrDefault();
            if (inicio != null)
            {
                inicio.Show();
            }
            this.Close();
        }
    }
}
