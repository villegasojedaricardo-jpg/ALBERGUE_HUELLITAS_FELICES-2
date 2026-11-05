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
    public partial class REGISTRO_ADOPCION : Form
    {
        private readonly DateTimePicker dtpFechaAdopcion = SelectorFecha.Crear();

        public REGISTRO_ADOPCION()
        {
            InitializeComponent();
            dtpFechaAdopcion.Location = new Point(900, 264);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha de adopción:", new Point(900, 230)));
            Controls.Add(dtpFechaAdopcion);
        }

        private void cmbAdoptanteNuevaAdopcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvNuevaAdopcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void REGISTRO_ADOPCION_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarRegistros();
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                {
                    // Mascotas se muestra el nombre, el id va por detrás
                    DataTable dtMascotas = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_mascota, nombre FROM mascotas ORDER BY nombre", cn))
                    {
                        da.Fill(dtMascotas);
                    }
                    cmbMascotaNuevaAdopcion.DisplayMember = "nombre";
                    cmbMascotaNuevaAdopcion.ValueMember = "id_mascota";
                    cmbMascotaNuevaAdopcion.DataSource = dtMascotas;
                    cmbMascotaNuevaAdopcion.SelectedIndex = -1;

                    // Adoptantes se muestra el nombre completo, el id va por detrás
                    DataTable dtAdoptantes = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_adoptante, nombre_completo FROM adoptantes ORDER BY nombre_completo", cn))
                    {
                        da.Fill(dtAdoptantes);
                    }
                    cmbAdoptanteNuevaAdopcion.DisplayMember = "nombre_completo";
                    cmbAdoptanteNuevaAdopcion.ValueMember = "id_adoptante";
                    cmbAdoptanteNuevaAdopcion.DataSource = dtAdoptantes;
                    cmbAdoptanteNuevaAdopcion.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los combos: " + ex.Message);
            }
        }

        private void CargarRegistros()
        {
            string sql = @"SELECT r.id_registro_adopcion AS id_registro,
                          m.nombre AS mascota,
                          a.nombre_completo AS adoptante,
                          r.fecha_adopcion
                   FROM registros_adopcion r
                   INNER JOIN mascotas m ON m.id_mascota = r.id_mascota
                   INNER JOIN adoptantes a ON a.id_adoptante = r.id_adoptante
                   ORDER BY r.fecha_adopcion DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNuevaAdopcion.DataSource = dt;
                    // El id del registro se deja visible a propósito
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros: " + ex.Message);
            }
        }

        private void btnGuardarNuevaAdopcion_Click(object sender, EventArgs e)
        {
            if (cmbMascotaNuevaAdopcion.SelectedIndex < 0 ||
                cmbAdoptanteNuevaAdopcion.SelectedIndex < 0 ||
                !dtpFechaAdopcion.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string sql = @"INSERT INTO registros_adopcion
                   (id_mascota, id_adoptante, fecha_adopcion)
                   VALUES (@mascota, @adoptante, @fecha)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@mascota", cmbMascotaNuevaAdopcion.SelectedValue);
                    cmd.Parameters.AddWithValue("@adoptante", cmbAdoptanteNuevaAdopcion.SelectedValue);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaAdopcion.Value.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Adopción registrada.");
                limpiar();
                CargarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            cmbMascotaNuevaAdopcion.SelectedIndex = -1;
            cmbAdoptanteNuevaAdopcion.SelectedIndex = -1;
            SelectorFecha.Vaciar(dtpFechaAdopcion);
        }

        private void btnVolverNuevaAdopcion_Click(object sender, EventArgs e)
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
