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
    public partial class MASCOTAS : Form
    {
        private readonly DateTimePicker dtpFechaIngreso = SelectorFecha.Crear();

        public MASCOTAS()
        {
            InitializeComponent();
            dtpFechaIngreso.Location = new Point(921, 350);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha de ingreso:", new Point(921, 322)));
            Controls.Add(dtpFechaIngreso);
        }

        private void MASCOTAS_Load(object sender, EventArgs e)
        {
            cmbPersonal.SelectedValue = Sesion.IdPersonal;
            cmbPersonal.Enabled = false;   
            CargarMascotas();
        }

        private void CargarMascotas()
        {
            string sql = @"SELECT m.id_mascota, m.nombre, m.especie, m.fecha_ingreso,
                          m.estado_disponibilidad, p.nombre_completo AS personal
                   FROM mascotas m
                   INNER JOIN personal p ON p.id_personal = m.id_personal";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMascotas.DataSource = dt;
                    dgvMascotas.Columns["id_mascota"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mascotas: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)// Es el boton de volver a la pantalla de inicio, se elimino de la interfaz
        {
            var inicio = Application.OpenForms.OfType<INICIO>().FirstOrDefault();
            if (inicio != null)
            {
                inicio.Show();
            }
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                cmbEspecie.SelectedIndex < 0 ||
                cmbEstadoDisponibilidad.SelectedIndex < 0 ||
                cmbPersonal.SelectedIndex < 0 ||
                !dtpFechaIngreso.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string sql = @"INSERT INTO mascotas
                   (nombre, especie, estado_disponibilidad, id_personal, fecha_ingreso)
                   VALUES (@nombre, @especie, @estado, @personal, @fecha)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombreMascota.Text.Trim());
                    cmd.Parameters.AddWithValue("@especie", cmbEspecie.Text);
                    cmd.Parameters.AddWithValue("@estado", cmbEstadoDisponibilidad.Text);
                    cmd.Parameters.AddWithValue("@personal", cmbPersonal.SelectedValue);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaIngreso.Value.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Mascota guardada.");
                limpiar();
                CargarMascotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }


        private void lstEspecie_SelectedIndexChanged(object sender, EventArgs e)// se elimino de la interfaz
        {

        }

        private void cmbEstadoDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // se elimino de la interfaz
        {

        }

        private void dgvMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombreMascota_TextChanged(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txtNombreMascota.Clear();
            cmbEspecie.SelectedIndex = -1;
            cmbEstadoDisponibilidad.SelectedIndex = -1;
            cmbPersonal.SelectedIndex = -1;
            SelectorFecha.Vaciar(dtpFechaIngreso);
            // opcional: deseleccionar fila del DataGridView si procede
            if (dgvMascotas.CurrentRow != null)
                dgvMascotas.ClearSelection();
        }

        private void cmbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
