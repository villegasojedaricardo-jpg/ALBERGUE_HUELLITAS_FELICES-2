using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class DONACION_INSUMOS : Form
    {
        private readonly DateTimePicker dtpFechaDonacion = SelectorFecha.Crear();

        public DONACION_INSUMOS()
        {
            InitializeComponent();
            dtpFechaDonacion.Location = new Point(950, 261);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha de donación:", new Point(950, 227)));
            Controls.Add(dtpFechaDonacion);
        }

        private void btnGuardarDonacionInsumo_Click(object sender, EventArgs e)
        {
            if (cmbDonanteNomDonacionInsumo.SelectedIndex < 0 ||
        cmbInsumoDonacionInsumo.SelectedIndex < 0 ||
            string.IsNullOrWhiteSpace(txtCantidadDonacionInsumo.Text) ||
            !dtpFechaDonacion.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            // Acepta coma o punto como separador decimal
            string texto = txtCantidadDonacionInsumo.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal cantidad))
            {
                MessageBox.Show("La cantidad no es válida.");
                return;
            }

            cantidad = Math.Round(cantidad, 2);

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.");
                return;
            }
            if (cantidad > 99999999.99m)
            {
                MessageBox.Show("La cantidad es demasiado grande.");
                return;
            }

            string sql = @"INSERT INTO donaciones_insumo
                   (cantidad_donada, id_donante, id_insumo, fecha_donacion)
                   VALUES (@cantidad, @donante, @insumo, @fecha)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    SqlParameter pCantidad = cmd.Parameters.Add("@cantidad", SqlDbType.Decimal);
                    pCantidad.Precision = 10;
                    pCantidad.Scale = 2;
                    pCantidad.Value = cantidad;

                    cmd.Parameters.AddWithValue("@donante", cmbDonanteNomDonacionInsumo.SelectedValue);
                    cmd.Parameters.AddWithValue("@insumo", cmbInsumoDonacionInsumo.SelectedValue);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaDonacion.Value.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Donación guardada.");
                limpiar();
                CargarDonaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }

        private void DONACION_INSUMOS_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDonaciones();
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                {
                    // Donantes se muestra el nombre, el id va por detrás
                    DataTable dtDonantes = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_donante, nombre_completo FROM donantes ORDER BY nombre_completo", cn))
                    {
                        da.Fill(dtDonantes);
                    }
                    cmbDonanteNomDonacionInsumo.DisplayMember = "nombre_completo";
                    cmbDonanteNomDonacionInsumo.ValueMember = "id_donante";
                    cmbDonanteNomDonacionInsumo.DataSource = dtDonantes;
                    cmbDonanteNomDonacionInsumo.SelectedIndex = -1;

                    // Insumos: se muestra la descripción, el id va por detrás
                    DataTable dtInsumos = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_insumo, descripcion_insumo FROM insumos ORDER BY descripcion_insumo", cn))
                    {
                        da.Fill(dtInsumos);
                    }
                    cmbInsumoDonacionInsumo.DisplayMember = "descripcion_insumo";
                    cmbInsumoDonacionInsumo.ValueMember = "id_insumo";
                    cmbInsumoDonacionInsumo.DataSource = dtInsumos;
                    cmbInsumoDonacionInsumo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los combos: " + ex.Message);
            }
        }

        private void CargarDonaciones()
        {
            string sql = @"SELECT di.id_donacion_insumo,
                          d.nombre_completo AS donante,
                          i.descripcion_insumo AS insumo,
                          di.cantidad_donada,
                          i.unidad_medida AS unidad,
                          di.fecha_donacion
                   FROM donaciones_insumo di
                   INNER JOIN donantes d ON d.id_donante = di.id_donante
                   INNER JOIN insumos i ON i.id_insumo = di.id_insumo
                   ORDER BY di.fecha_donacion DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDonacionInsumo.DataSource = dt;
                    dgvDonacionInsumo.Columns["id_donacion_insumo"].Visible = false;
                    dgvDonacionInsumo.Columns["cantidad_donada"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar donaciones: " + ex.Message);
            }
        }
        private void limpiar()
        {
            cmbDonanteNomDonacionInsumo.SelectedIndex = -1;
            cmbInsumoDonacionInsumo.SelectedIndex = -1;
            txtCantidadDonacionInsumo.Clear();
            SelectorFecha.Vaciar(dtpFechaDonacion);
        }

        private void btnVolverDonacionInsumo_Click(object sender, EventArgs e)
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
