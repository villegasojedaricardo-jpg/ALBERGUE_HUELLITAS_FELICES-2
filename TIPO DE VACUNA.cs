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
    public partial class TIPO_DE_VACUNA : Form
    {
        public TIPO_DE_VACUNA()
        {
            InitializeComponent();
        }

        private void btnGuardarTipoVacunas_Click(object sender, EventArgs e)
        {
            if (cmbTipoVacuna.SelectedIndex < 0 || cmbDosisRecomendada.SelectedIndex < 0)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string sql = @"INSERT INTO tipos_vacuna (nombre_vacuna, dosis_recomendada)
                   VALUES (@nombre, @dosis)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cmbTipoVacuna.Text);
                    cmd.Parameters.AddWithValue("@dosis", cmbDosisRecomendada.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Tipo de vacuna guardado.");
                limpiar();
                CargarTiposVacuna();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }

        private void TIPO_DE_VACUNA_Load(object sender, EventArgs e)
        {

            cmbTipoVacuna.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDosisRecomendada.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipoVacuna.Items.Clear();
            cmbTipoVacuna.Items.AddRange(new object[]
            {
        "Antirrábica", "Quíntuple canina", "Séxtuple canina",
        "Parvovirus", "Tos de las perreras", "Triple felina", "Leucemia felina"
            });

            cmbDosisRecomendada.Items.Clear();
            cmbDosisRecomendada.Items.AddRange(new object[] { "0.5 ml", "1 ml", "2 ml" });

            CargarTiposVacuna();
        }

        private void CargarTiposVacuna()
        {
            string sql = @"SELECT id_tipo_vacuna, nombre_vacuna, dosis_recomendada
                   FROM tipos_vacuna
                   ORDER BY nombre_vacuna";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTipoVacuna.DataSource = dt;
                    dgvTipoVacuna.Columns["id_tipo_vacuna"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de vacuna: " + ex.Message);
            }

        }
        private void limpiar()
        {
            cmbTipoVacuna.SelectedIndex = -1;
            cmbDosisRecomendada.SelectedIndex = -1;
        }

        private void btnVolverTipoVacuna_Click(object sender, EventArgs e)
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
