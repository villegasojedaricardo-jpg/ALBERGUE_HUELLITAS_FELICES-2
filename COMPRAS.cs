using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class COMPRAS : Form
    {
        private readonly DateTimePicker dtpFechaCompra = SelectorFecha.Crear();

        // Id de la compra seleccionada (va por detrás, no se muestra)
        private int idCompraSeleccionada = 0;

        public COMPRAS()
        {
            InitializeComponent();
            dtpFechaCompra.Location = new Point(1000, 277);
            Controls.Add(SelectorFecha.CrearEtiqueta("Fecha de compra:", new Point(1000, 243)));
            Controls.Add(dtpFechaCompra);
            this.Load += COMPRAS_Load;
        }

        private void COMPRAS_Load(object sender, EventArgs e)
        {
            // Ajustes iniciales basados en los nombres de controles del diseñador
            txtNumeroFacturaRegistroCompra.MaxLength = 20;

            dgvRegistroCompra.ReadOnly = true;
            dgvRegistroCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistroCompra.MultiSelect = false;
            dgvDetalleCompra.ReadOnly = true;

            CargarInsumos();
            CargarCompras();
            CargarDetalle();
        }

        // ---------- Utilidad ----------

        private bool LeerDecimal(string texto, out decimal valor)
        {
            // Acepta coma o punto como separador decimal
            string t = texto.Trim().Replace(',', '.');
            if (!decimal.TryParse(t, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                return false;
            valor = Math.Round(valor, 2);
            return true;
        }

        // ---------- COMPRAS (panel derecho) ----------

        private void CargarCompras()
        {
            string sql = @"SELECT id_compra, numero_factura, fecha_compra
                           FROM compras
                           ORDER BY fecha_compra DESC, id_compra DESC";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRegistroCompra.DataSource = dt;
                    if (dgvRegistroCompra.Columns.Contains("id_compra"))
                        dgvRegistroCompra.Columns["id_compra"].Visible = false;
                    if (dgvRegistroCompra.Columns.Contains("numero_factura"))
                        dgvRegistroCompra.Columns["numero_factura"].HeaderText = "N° Factura";
                    if (dgvRegistroCompra.Columns.Contains("fecha_compra"))
                    {
                        dgvRegistroCompra.Columns["fecha_compra"].HeaderText = "Fecha de compra";
                        dgvRegistroCompra.Columns["fecha_compra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar compras: " + ex.Message);
            }
        }

        private void btnGuardarRegistroCompra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroFacturaRegistroCompra.Text) ||
                !dtpFechaCompra.Checked)
            {
                MessageBox.Show("Escribe el número de factura.");
                return;
            }

            string sql = @"INSERT INTO compras (numero_factura, fecha_compra)
                           OUTPUT INSERTED.id_compra
                           VALUES (@factura, @fecha)";
            try
            {
                int nuevoId;
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@factura", txtNumeroFacturaRegistroCompra.Text.Trim());
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaCompra.Value.Date;
                    cn.Open();
                    nuevoId = (int)cmd.ExecuteScalar();
                }

                // La compra recién guardada queda seleccionada para agregarle insumos
                idCompraSeleccionada = nuevoId;
                MessageBox.Show("Compra guardada. Ahora agrega los insumos.");
                LimpiarCompra();
                CargarCompras();
                CargarDetalle();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe una compra con ese número de factura.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la compra: " + ex.Message);
            }
        }

        private void btnLimpiarCompra_Click(object sender, EventArgs e)
        {
            LimpiarCompra();
        }

        private void LimpiarCompra()
        {
            txtNumeroFacturaRegistroCompra.Clear();
            SelectorFecha.Vaciar(dtpFechaCompra);
            txtNumeroFacturaRegistroCompra.Focus();
        }

        // Evento CellClick de dgvRegistroCompra: selecciona la compra y muestra sus detalles
        private void dgvRegistroCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvRegistroCompra.Rows[e.RowIndex].Cells["id_compra"].Value == null) return;
            idCompraSeleccionada = Convert.ToInt32(dgvRegistroCompra.Rows[e.RowIndex].Cells["id_compra"].Value);
            CargarDetalle();
        }

        // ---------- DETALLE COMPRA (panel izquierdo) ----------

        private void CargarInsumos()
        {
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_insumo, descripcion_insumo FROM insumos ORDER BY descripcion_insumo", cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbNombreInsumoCompras.DisplayMember = "descripcion_insumo";
                    cmbNombreInsumoCompras.ValueMember = "id_insumo";
                    cmbNombreInsumoCompras.DataSource = dt;
                    cmbNombreInsumoCompras.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar insumos: " + ex.Message);
            }
        }

        private void CargarDetalle()
        {
            if (idCompraSeleccionada == 0)
            {
                dgvDetalleCompra.DataSource = null;
                return;
            }

            string sql = @"SELECT i.descripcion_insumo AS insumo,
                          d.cantidad,
                          i.unidad_medida AS unidad,
                          d.precio_unitario
                   FROM detalles_compra d
                   INNER JOIN insumos i ON i.id_insumo = d.id_insumo
                   WHERE d.id_compra = @compra
                   ORDER BY i.descripcion_insumo";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@compra", idCompraSeleccionada);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDetalleCompra.DataSource = dt;
                    if (dgvDetalleCompra.Columns.Contains("insumo"))
                        dgvDetalleCompra.Columns["insumo"].HeaderText = "Nombre del insumo";
                    if (dgvDetalleCompra.Columns.Contains("cantidad"))
                    {
                        dgvDetalleCompra.Columns["cantidad"].HeaderText = "Cantidad";
                        dgvDetalleCompra.Columns["cantidad"].DefaultCellStyle.Format = "N2";
                    }
                    if (dgvDetalleCompra.Columns.Contains("unidad"))
                        dgvDetalleCompra.Columns["unidad"].HeaderText = "Unidad";
                    if (dgvDetalleCompra.Columns.Contains("precio_unitario"))
                    {
                        dgvDetalleCompra.Columns["precio_unitario"].HeaderText = "Precio unitario";
                        dgvDetalleCompra.Columns["precio_unitario"].DefaultCellStyle.Format = "N2";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle: " + ex.Message);
            }
        }

        private void btnGuardarDetalleCompra_Click(object sender, EventArgs e)
        {
            if (idCompraSeleccionada == 0)
            {
                MessageBox.Show("Primero registra o selecciona una compra.");
                return;
            }

            if (cmbNombreInsumoCompras.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtCantidadDetalleCompra.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitarioCompra.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (!LeerDecimal(txtCantidadDetalleCompra.Text, out decimal cantidad))
            {
                MessageBox.Show("La cantidad no es válida.");
                return;
            }
            if (!LeerDecimal(txtPrecioUnitarioCompra.Text, out decimal precio))
            {
                MessageBox.Show("El precio unitario no es válido.");
                return;
            }
            if (cantidad <= 0 || precio <= 0)
            {
                MessageBox.Show("La cantidad y el precio deben ser mayores que cero.");
                return;
            }
            if (cantidad > 99999999.99m || precio > 99999999.99m)
            {
                MessageBox.Show("Uno de los valores es demasiado grande.");
                return;
            }

            string sqlDetalle = @"INSERT INTO detalles_compra (id_compra, id_insumo, cantidad, precio_unitario)
                          VALUES (@compra, @insumo, @cantidad, @precio)";
            string sqlStock = @"UPDATE insumos
                        SET stock_actual = stock_actual + @cantidad
                        WHERE id_insumo = @insumo";
            try
            {
                using (SqlConnection cn = Conexion.Obtener())
                {
                    cn.Open();
                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(sqlDetalle, cn, tx))
                            {
                                cmd.Parameters.AddWithValue("@compra", idCompraSeleccionada);
                                cmd.Parameters.AddWithValue("@insumo", cmbNombreInsumoCompras.SelectedValue);

                                SqlParameter pCant = cmd.Parameters.Add("@cantidad", SqlDbType.Decimal);
                                pCant.Precision = 10; pCant.Scale = 2; pCant.Value = cantidad;

                                SqlParameter pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
                                pPrecio.Precision = 10; pPrecio.Scale = 2; pPrecio.Value = precio;

                                cmd.ExecuteNonQuery();
                            }

                            // Suma lo comprado al stock del insumo
                            using (SqlCommand cmd2 = new SqlCommand(sqlStock, cn, tx))
                            {
                                SqlParameter p = cmd2.Parameters.Add("@cantidad", SqlDbType.Decimal);
                                p.Precision = 10; p.Scale = 2; p.Value = cantidad;
                                cmd2.Parameters.AddWithValue("@insumo", cmbNombreInsumoCompras.SelectedValue);
                                cmd2.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Insumo agregado a la compra.");
                LimpiarDetalle();
                CargarDetalle();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ese insumo ya está en esta compra.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el detalle: " + ex.Message);
            }
        }

        private void btnLimpiarDetalleCompra_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();
        }

        private void LimpiarDetalle()
        {
            cmbNombreInsumoCompras.SelectedIndex = -1;
            txtCantidadDetalleCompra.Clear();
            txtPrecioUnitarioCompra.Clear();
        }

        // Evento KeyPress de txtCantidadDetalleCompra y txtPrecioUnitarioCompra (enlaza los dos al mismo método)
        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            TextBox txt = (TextBox)sender;
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                !txt.Text.Contains(".") && !txt.Text.Contains(","))
                return;

            e.Handled = true;
        }

        
        private void btnVolverCompras_Click(object sender, EventArgs e)
        {
            var inicio = Application.OpenForms.OfType<INICIO>().FirstOrDefault();
            if (inicio != null) inicio.Show();
            this.Close();
        }

        private void COMPRAS_Load_1(object sender, EventArgs e)
        {

        }
    }
}
