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
    public partial class INSUMO : Form
    {
        public INSUMO()
        {
            InitializeComponent();
        }

        private void INSUMO_Load(object sender, EventArgs e)
        {
            txtDescripcionInsumo.MaxLength = 120;

            cmbUnidadInsumo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadInsumo.Items.Clear();
            cmbUnidadInsumo.Items.AddRange(new object[] { "Kg", "Litro", "Unidad", "Bolsa", "Caja", "Frasco" });
            cmbUnidadInsumo.SelectedIndex = -1;

            cmbTipoInsumo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoInsumo.Items.Clear();
            cmbTipoInsumo.Items.AddRange(new object[] { "Perecedero", "No perecedero" });
            cmbTipoInsumo.SelectedIndex = -1;

            SelectorFecha.Configurar(dtpFechaVencimientoinsumo);
            dtpFechaVencimientoinsumo.Enabled = false;   // se activa solo si es Perecedero

            CargarInsumos();
        }

        // Evento SelectedIndexChanged de cmbTipoInsumo
        private void cmbTipoInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFechaVencimientoinsumo.Enabled = (cmbTipoInsumo.Text == "Perecedero");
        }

        private void CargarInsumos()
        {
            string sql = @"SELECT id_insumo, descripcion_insumo, unidad_medida,
                          stock_actual, tipo_insumo, fecha_vencimiento
                   FROM insumos
                   ORDER BY descripcion_insumo";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvInsumo.DataSource = dt;
                    // El id_insumo se deja visible a propósito
                    dgvInsumo.Columns["stock_actual"].DefaultCellStyle.Format = "N2";
                    dgvInsumo.Columns["fecha_vencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar insumos: " + ex.Message);
            }
        }

        private void btnGuardarInsumo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcionInsumo.Text) ||
        cmbUnidadInsumo.SelectedIndex < 0 ||
        string.IsNullOrWhiteSpace(txtStockActualInsumos.Text) ||
        cmbTipoInsumo.SelectedIndex < 0)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            // Acepta coma o punto como separador decimal
            string texto = txtStockActualInsumos.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal stock))
            {
                MessageBox.Show("El stock no es válido.");
                return;
            }

            stock = Math.Round(stock, 2);

            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo.");
                return;
            }
            if (stock > 99999999.99m)
            {
                MessageBox.Show("El stock es demasiado grande.");
                return;
            }

            bool esPerecedero = (cmbTipoInsumo.Text == "Perecedero");

            string sql = @"INSERT INTO insumos
                   (descripcion_insumo, unidad_medida, stock_actual, tipo_insumo, fecha_vencimiento)
                   VALUES (@descripcion, @unidad, @stock, @tipo, @vencimiento)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcionInsumo.Text.Trim());
                    cmd.Parameters.AddWithValue("@unidad", cmbUnidadInsumo.Text);

                    SqlParameter pStock = cmd.Parameters.Add("@stock", SqlDbType.Decimal);
                    pStock.Precision = 10;
                    pStock.Scale = 2;
                    pStock.Value = stock;

                    cmd.Parameters.AddWithValue("@tipo", cmbTipoInsumo.Text);

                    // Perecedero: lleva fecha. No perecedero: NULL (lo exige el CHECK)
                    SqlParameter pVenc = cmd.Parameters.Add("@vencimiento", SqlDbType.Date);
                    pVenc.Value = esPerecedero ? (object)dtpFechaVencimientoinsumo.Value.Date : DBNull.Value;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Insumo guardado.");
                limpiar();
                CargarInsumos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            txtDescripcionInsumo.Clear();
            cmbUnidadInsumo.SelectedIndex = -1;
            txtStockActualInsumos.Clear();
            cmbTipoInsumo.SelectedIndex = -1;
            SelectorFecha.Vaciar(dtpFechaVencimientoinsumo);
            dtpFechaVencimientoinsumo.Enabled = false;
            txtDescripcionInsumo.Focus();
        }

        private void btnVolverInsumo_Click(object sender, EventArgs e)
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
