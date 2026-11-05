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
    public partial class APLICACION_VACUNAS : Form
    {
        private readonly DateTimePicker dtpFechaAplicacion = SelectorFecha.Crear();

        public APLICACION_VACUNAS()
        {
            InitializeComponent();
            dtpFechaAplicacion.Location = new Point(900, 255);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha de aplicación:", new Point(900, 221)));
            Controls.Add(dtpFechaAplicacion);
        }
        private void APLICACION_VACUNAS_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarAplicaciones();
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                {
                    // Mascotas
                    DataTable dtMascotas = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_mascota, nombre FROM mascotas ORDER BY nombre", cn))
                    {
                        da.Fill(dtMascotas);
                    }
                    cmbMascotaApliVacunas.DisplayMember = "nombre";
                    cmbMascotaApliVacunas.ValueMember = "id_mascota";
                    cmbMascotaApliVacunas.DataSource = dtMascotas;
                    cmbMascotaApliVacunas.SelectedIndex = -1;

                    // Tipos de vacuna (columna real: nombre_vacuna)
                    DataTable dtVacunas = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_tipo_vacuna, nombre_vacuna FROM tipos_vacuna ORDER BY nombre_vacuna", cn))
                    {
                        da.Fill(dtVacunas);
                    }
                    cmbTipoVacunaApliVacuna.DisplayMember = "nombre_vacuna";
                    cmbTipoVacunaApliVacuna.ValueMember = "id_tipo_vacuna";
                    cmbTipoVacunaApliVacuna.DataSource = dtVacunas;
                    cmbTipoVacunaApliVacuna.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los combos: " + ex.Message);
            }
        }

        private void CargarAplicaciones()
        {
            string sql = @"SELECT a.id_aplicacion, m.nombre AS mascota,
                      t.nombre_vacuna AS vacuna, a.fecha_aplicacion
               FROM aplicaciones_vacuna a
               INNER JOIN mascotas m ON m.id_mascota = a.id_mascota
               INNER JOIN tipos_vacuna t ON t.id_tipo_vacuna = a.id_tipo_vacuna
               ORDER BY a.fecha_aplicacion DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAplicacionVacunas.DataSource = dt;
                    dgvAplicacionVacunas.Columns["id_aplicacion"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar aplicaciones: " + ex.Message);
            }
        }



        private void btnGuardarApliVacuna_Click(object sender, EventArgs e)
        {
            if (cmbMascotaApliVacunas.SelectedIndex < 0 ||
                cmbTipoVacunaApliVacuna.SelectedIndex < 0 ||
                !dtpFechaAplicacion.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string sql = @"INSERT INTO aplicaciones_vacuna
                   (id_mascota, id_tipo_vacuna, fecha_aplicacion)
                   VALUES (@mascota, @vacuna, @fecha)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@mascota", cmbMascotaApliVacunas.SelectedValue);
                    cmd.Parameters.AddWithValue("@vacuna", cmbTipoVacunaApliVacuna.SelectedValue);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaAplicacion.Value.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Aplicación de vacuna guardada.");
                limpiar();
                CargarAplicaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            cmbMascotaApliVacunas.SelectedIndex = -1;
            cmbTipoVacunaApliVacuna.SelectedIndex = -1;
            SelectorFecha.Vaciar(dtpFechaAplicacion);
        }

        private void btnVolverApliVacuna_Click(object sender, EventArgs e)
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
