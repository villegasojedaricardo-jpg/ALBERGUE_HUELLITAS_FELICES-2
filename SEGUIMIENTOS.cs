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
    public partial class SEGUIMIENTOS : Form
    {
        public SEGUIMIENTOS()
        {
            InitializeComponent();
        }

        private void SEGUIMIENTOS_Load(object sender, EventArgs e)
        {
            cmbEstadoSeguimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoSeguimiento.Items.Clear();
            cmbEstadoSeguimiento.Items.AddRange(new object[] { "Excelente", "Bueno", "Regular", "Mal" });
            cmbEstadoSeguimiento.SelectedIndex = -1;

            // Fecha de visita
            SelectorFecha.Configurar(dtpFechaVisitaSrguimiento);

            CargarRegistrosAdopcion();
            CargarSeguimientos();
        }

        private void CargarRegistrosAdopcion()
        {
            string sql = @"SELECT r.id_registro_adopcion,
                          CONCAT(m.nombre, ' - ', a.nombre_completo, ' - ',
                                 CONVERT(VARCHAR(10), r.fecha_adopcion, 103)) AS descripcion
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
                    cmbAdopcionSeguimiento.DisplayMember = "descripcion";
                    cmbAdopcionSeguimiento.ValueMember = "id_registro_adopcion";
                    cmbAdopcionSeguimiento.DataSource = dt;
                    cmbAdopcionSeguimiento.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros de adopción: " + ex.Message);
            }
        }

        private void CargarSeguimientos()
        {
            string sql = @"SELECT s.id_seguimiento AS id_seguimiento,
                          CONCAT(m.nombre, ' - ', a.nombre_completo, ' - ',
                                 CONVERT(VARCHAR(10), r.fecha_adopcion, 103)) AS adopcion,
                          s.fecha_visita,
                          s.estado_bienestar
                   FROM seguimientos_adopcion s
                   INNER JOIN registros_adopcion r ON r.id_registro_adopcion = s.id_registro_adopcion
                   INNER JOIN mascotas m ON m.id_mascota = r.id_mascota
                   INNER JOIN adoptantes a ON a.id_adoptante = r.id_adoptante
                   ORDER BY s.fecha_visita DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSeguimiento.DataSource = dt;
                    // El id_seguimiento se deja visible a propósito
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar seguimientos: " + ex.Message);
            }
        }

        private void btnGuardarSeguimiento_Click(object sender, EventArgs e)
        {
            if (cmbAdopcionSeguimiento.SelectedIndex < 0 ||
                cmbEstadoSeguimiento.SelectedIndex < 0 ||
                !dtpFechaVisitaSrguimiento.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string sql = @"INSERT INTO seguimientos_adopcion (fecha_visita, estado_bienestar, id_registro_adopcion)
                   VALUES (@fecha, @estado, @registro)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaVisitaSrguimiento.Value.Date;
                    cmd.Parameters.AddWithValue("@estado", cmbEstadoSeguimiento.Text);
                    cmd.Parameters.AddWithValue("@registro", cmbAdopcionSeguimiento.SelectedValue);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Seguimiento guardado.");
                limpiar();
                CargarSeguimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            cmbAdopcionSeguimiento.SelectedIndex = -1;
            cmbEstadoSeguimiento.SelectedIndex = -1;
            SelectorFecha.Vaciar(dtpFechaVisitaSrguimiento);
        }

        private void btnVolverSeguimiento_Click(object sender, EventArgs e)
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
