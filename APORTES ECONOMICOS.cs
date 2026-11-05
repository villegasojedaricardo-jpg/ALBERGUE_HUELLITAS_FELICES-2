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
    public partial class APORTES_ECONOMICOS : Form
    {
        private readonly DateTimePicker dtpFechaAporte = SelectorFecha.Crear();

        public APORTES_ECONOMICOS()
        {
            InitializeComponent();
            dtpFechaAporte.Location = new Point(950, 271);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha del aporte:", new Point(950, 237)));
            Controls.Add(dtpFechaAporte);
        }

        private void APORTES_ECONOMICOS_Load(object sender, EventArgs e)
        {
            CargarDonantes();
            CargarAportes();
        }

        private void CargarDonantes()
        {
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_donante, nombre_completo FROM donantes ORDER BY nombre_completo", cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDonanteAportesEconomicos.DisplayMember = "nombre_completo";
                    cmbDonanteAportesEconomicos.ValueMember = "id_donante";
                    cmbDonanteAportesEconomicos.DataSource = dt;
                    cmbDonanteAportesEconomicos.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar donantes: " + ex.Message);
            }
        }

        private void CargarAportes()
        {
            string sql = @"SELECT a.id_aporte AS id_aporte,
                          d.nombre_completo AS donante,
                          a.monto,
                          a.fecha_aporte
                   FROM aportes_economicos a
                   INNER JOIN donantes d ON d.id_donante = a.id_donante
                   ORDER BY a.fecha_aporte DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAportesEconomicos.DataSource = dt;
                    // El id_aporte se deja visible a propósito
                    dgvAportesEconomicos.Columns["monto"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar aportes: " + ex.Message);
            }
        }

        private void btnVolverAportesEconomicos_Click(object sender, EventArgs e)
        {
            var inicio = Application.OpenForms.OfType<INICIO>().FirstOrDefault();
            if (inicio != null)
            {
                inicio.Show();
            }
            this.Close();
        }

        private void btnGuardarAportesEconomicos_Click(object sender, EventArgs e)
        {
            if (cmbDonanteAportesEconomicos.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtMontoAportesEconomicos.Text) ||
                !dtpFechaAporte.Checked)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            // Acepta coma o punto como separador decimal
            string texto = txtMontoAportesEconomicos.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal monto))
            {
                MessageBox.Show("El monto no es válido.");
                return;
            }

            monto = Math.Round(monto, 2);

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.");
                return;
            }
            if (monto > 99999999.99m)
            {
                MessageBox.Show("El monto es demasiado grande.");
                return;
            }

            string sql = @"INSERT INTO aportes_economicos (monto, id_donante, fecha_aporte)
                   VALUES (@monto, @donante, @fecha)";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    SqlParameter pMonto = cmd.Parameters.Add("@monto", SqlDbType.Decimal);
                    pMonto.Precision = 10;
                    pMonto.Scale = 2;
                    pMonto.Value = monto;

                    cmd.Parameters.AddWithValue("@donante", cmbDonanteAportesEconomicos.SelectedValue);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaAporte.Value.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Aporte guardado.");
                limpiar();
                CargarAportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar: " + ex.Message);
            }
        }
        private void limpiar()
        {
            cmbDonanteAportesEconomicos.SelectedIndex = -1;
            txtMontoAportesEconomicos.Clear();
            SelectorFecha.Vaciar(dtpFechaAporte);
        }
    }
}
