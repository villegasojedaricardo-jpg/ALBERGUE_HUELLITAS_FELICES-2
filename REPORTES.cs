using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ALBERGUE_HUELLITAS_FELICES.Reportes;
using Microsoft.Reporting.WinForms;

namespace ALBERGUE_HUELLITAS_FELICES;

public class REPORTES : Form
{
    private readonly TabControl pestañas = new();

    private ComboBox cmbEstadoMascota = new();
    private ComboBox cmbEspecieMascota = new();
    private DataGridView dgvMascotas = new();
    private Label lblResumenMascotas = new();

    private DateTimePicker dtDesdeAdopciones = new();
    private DateTimePicker dtHastaAdopciones = new();
    private DataGridView dgvAdopciones = new();
    private Label lblResumenAdopciones = new();

    private DateTimePicker dtDesdeVacunaciones = new();
    private DateTimePicker dtHastaVacunaciones = new();
    private DataGridView dgvVacunaciones = new();
    private Label lblResumenVacunaciones = new();
    private ReportViewer visorVacunaciones = new();

    private ComboBox cmbTipoInsumo = new();
    private CheckBox chkBajoStock = new();
    private DataGridView dgvInsumos = new();
    private Label lblResumenInsumos = new();

    private DateTimePicker dtDesdeAportes = new();
    private DateTimePicker dtHastaAportes = new();
    private DataGridView dgvAportes = new();
    private Label lblResumenAportes = new();
    private ReportViewer visorAportes = new();

    private DateTimePicker dtDesdeCompras = new();
    private DateTimePicker dtHastaCompras = new();
    private DataGridView dgvCompras = new();
    private Label lblResumenCompras = new();
    private readonly Button btnExportarPdf = new();

    public REPORTES()
    {
        Text = "Reportes - Albergue Huellitas Felices";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(950, 600);
        Size = new Size(1200, 750);
        BackColor = Color.WhiteSmoke;

        pestañas.Dock = DockStyle.Fill;
        pestañas.Padding = new Point(12, 6);
        var encabezado = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.WhiteSmoke };
        btnExportarPdf.Text = "Exportar PDF";
        btnExportarPdf.AutoSize = true;
        btnExportarPdf.Location = new Point(12, 8);
        btnExportarPdf.BackColor = Color.SeaGreen;
        btnExportarPdf.ForeColor = Color.White;
        btnExportarPdf.FlatStyle = FlatStyle.Flat;
        btnExportarPdf.Click += (_, _) => ExportarReporteActual();
        encabezado.Controls.Add(btnExportarPdf);
        Controls.Add(pestañas);
        Controls.Add(encabezado);

        CrearPestanaMascotas();
        CrearPestanaAdopciones();
        CrearPestanaVacunaciones();
        CrearPestanaInsumos();
        CrearPestanaAportes();
        CrearPestanaCompras();
    }

    private void CrearPestanaMascotas()
    {
        var tab = new TabPage("Mascotas por estado") { Padding = new Padding(10) };
        cmbEstadoMascota = Combo("Todos", "Disponible", "En tratamiento", "Adoptado");
        cmbEspecieMascota = Combo("Todas");
        AgregarOpciones(cmbEspecieMascota, ReportesDatos.ListarEspecies());
        var consultar = Boton("Consultar", (_, _) => CargarMascotas());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            cmbEstadoMascota.SelectedIndex = 0;
            cmbEspecieMascota.SelectedIndex = 0;
            CargarMascotas();
        });
        var barra = Barra(
            Etiqueta("Estado:"), cmbEstadoMascota,
            Etiqueta("Especie:"), cmbEspecieMascota,
            consultar, limpiar);
        lblResumenMascotas = Resumen();
        dgvMascotas = Tabla();
        tab.Controls.Add(dgvMascotas);
        tab.Controls.Add(lblResumenMascotas);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarMascotas();
    }

    private void CrearPestanaAdopciones()
    {
        var tab = new TabPage("Adopciones por fecha") { Padding = new Padding(10) };
        dtDesdeAdopciones = Fecha();
        dtHastaAdopciones = Fecha();
        var consultar = Boton("Consultar", (_, _) => CargarAdopciones());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            dtDesdeAdopciones.Checked = false;
            dtHastaAdopciones.Checked = false;
            dtDesdeAdopciones.CustomFormat = " ";
            dtHastaAdopciones.CustomFormat = " ";
            CargarAdopciones();
        });
        var barra = Barra(
            Etiqueta("Desde:"), dtDesdeAdopciones,
            Etiqueta("Hasta:"), dtHastaAdopciones,
            consultar, limpiar);
        lblResumenAdopciones = Resumen();
        dgvAdopciones = Tabla();
        tab.Controls.Add(dgvAdopciones);
        tab.Controls.Add(lblResumenAdopciones);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarAdopciones();
    }

    private void CrearPestanaVacunaciones()
    {
        var tab = new TabPage("Vacunaciones") { Padding = new Padding(10) };
        dtDesdeVacunaciones = Fecha();
        dtHastaVacunaciones = Fecha();
        var consultar = Boton("Consultar", (_, _) => CargarVacunaciones());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            dtDesdeVacunaciones.Checked = false;
            dtHastaVacunaciones.Checked = false;
            dtDesdeVacunaciones.CustomFormat = " ";
            dtHastaVacunaciones.CustomFormat = " ";
            CargarVacunaciones();
        });
        var barra = Barra(
            Etiqueta("Desde:"), dtDesdeVacunaciones,
            Etiqueta("Hasta:"), dtHastaVacunaciones,
            consultar, limpiar);
        lblResumenVacunaciones = Resumen();
        dgvVacunaciones = Tabla();
        visorVacunaciones = CrearVisor();
        tab.Controls.Add(visorVacunaciones);
        tab.Controls.Add(lblResumenVacunaciones);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarVacunaciones();
    }

    private void CrearPestanaInsumos()
    {
        var tab = new TabPage("Existencias de insumos") { Padding = new Padding(10) };
        cmbTipoInsumo = Combo("Todos");
        AgregarOpciones(cmbTipoInsumo, ReportesDatos.ListarTiposInsumo());
        chkBajoStock = new CheckBox { Text = "Solo stock bajo (≤ 5)", AutoSize = true, Margin = new Padding(12, 8, 12, 4) };
        var consultar = Boton("Consultar", (_, _) => CargarInsumos());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            cmbTipoInsumo.SelectedIndex = 0;
            chkBajoStock.Checked = false;
            CargarInsumos();
        });
        var barra = Barra(
            Etiqueta("Tipo:"), cmbTipoInsumo, chkBajoStock, consultar, limpiar);
        lblResumenInsumos = Resumen();
        dgvInsumos = Tabla();
        tab.Controls.Add(dgvInsumos);
        tab.Controls.Add(lblResumenInsumos);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarInsumos();
    }

    private void CrearPestanaAportes()
    {
        var tab = new TabPage("Aportes económicos") { Padding = new Padding(10) };
        dtDesdeAportes = Fecha();
        dtHastaAportes = Fecha();
        var consultar = Boton("Consultar", (_, _) => CargarAportes());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            dtDesdeAportes.Checked = false;
            dtHastaAportes.Checked = false;
            dtDesdeAportes.CustomFormat = " ";
            dtHastaAportes.CustomFormat = " ";
            CargarAportes();
        });
        var barra = Barra(
            Etiqueta("Desde:"), dtDesdeAportes,
            Etiqueta("Hasta:"), dtHastaAportes,
            consultar, limpiar);
        lblResumenAportes = Resumen();
        dgvAportes = Tabla();
        visorAportes = CrearVisor();
        tab.Controls.Add(visorAportes);
        tab.Controls.Add(lblResumenAportes);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarAportes();
    }

    private void CrearPestanaCompras()
    {
        var tab = new TabPage("Compras y egresos") { Padding = new Padding(10) };
        dtDesdeCompras = Fecha();
        dtHastaCompras = Fecha();
        var consultar = Boton("Consultar", (_, _) => CargarCompras());
        var limpiar = Boton("Limpiar", (_, _) =>
        {
            dtDesdeCompras.Checked = false;
            dtHastaCompras.Checked = false;
            dtDesdeCompras.CustomFormat = " ";
            dtHastaCompras.CustomFormat = " ";
            CargarCompras();
        });
        var barra = Barra(
            Etiqueta("Desde:"), dtDesdeCompras,
            Etiqueta("Hasta:"), dtHastaCompras,
            consultar, limpiar);
        lblResumenCompras = Resumen();
        dgvCompras = Tabla();
        tab.Controls.Add(dgvCompras);
        tab.Controls.Add(lblResumenCompras);
        tab.Controls.Add(barra);
        pestañas.TabPages.Add(tab);
        CargarCompras();
    }

    private void CargarMascotas()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.Mascotas(
                cmbEstadoMascota.SelectedIndex <= 0 ? "" : cmbEstadoMascota.Text,
                cmbEspecieMascota.SelectedIndex <= 0 ? "" : cmbEspecieMascota.Text);
            dgvMascotas.DataSource = tabla;
            lblResumenMascotas.Text = $"Total de mascotas: {tabla.Rows.Count}";
        });
    }

    private void ExportarReporteActual()
    {
        var reporte = pestañas.SelectedIndex switch
        {
            0 => (dgvMascotas, "Reporte de mascotas", lblResumenMascotas.Text),
            1 => (dgvAdopciones, "Reporte de adopciones", lblResumenAdopciones.Text),
            2 => (dgvVacunaciones, "Reporte de vacunaciones", lblResumenVacunaciones.Text),
            3 => (dgvInsumos, "Reporte de existencias de insumos", lblResumenInsumos.Text),
            4 => (dgvAportes, "Reporte de aportes económicos", lblResumenAportes.Text),
            5 => (dgvCompras, "Reporte de compras y egresos", lblResumenCompras.Text),
            _ => (null, "Reporte", "")
        };

        if (reporte.Item1?.DataSource is not DataTable tabla)
        {
            MessageBox.Show("No hay datos cargados para exportar.", "Exportar PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialogo = new SaveFileDialog
        {
            Title = "Guardar reporte en PDF",
            Filter = "Archivo PDF (*.pdf)|*.pdf",
            FileName = $"{NombreArchivo(reporte.Item2)}_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
            AddExtension = true,
            DefaultExt = "pdf"
        };

        if (dialogo.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            PdfExporter.Exportar(tabla, reporte.Item2, reporte.Item3, dialogo.FileName);
            MessageBox.Show("El reporte se exportó correctamente.", "Exportar PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo exportar el reporte: " + ex.Message, "Exportar PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string NombreArchivo(string texto)
    {
        foreach (var caracter in Path.GetInvalidFileNameChars())
            texto = texto.Replace(caracter, '_');
        return texto.Replace(' ', '_');
    }

    private void CargarAdopciones()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.Adopciones(
                dtDesdeAdopciones.Checked ? dtDesdeAdopciones.Value : null,
                dtHastaAdopciones.Checked ? dtHastaAdopciones.Value : null);
            dgvAdopciones.DataSource = tabla;
            lblResumenAdopciones.Text = $"Total de adopciones: {tabla.Rows.Count}";
        });
    }

    private void CargarVacunaciones()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.Vacunaciones(
                dtDesdeVacunaciones.Checked ? dtDesdeVacunaciones.Value : null,
                dtHastaVacunaciones.Checked ? dtHastaVacunaciones.Value : null);
            dgvVacunaciones.DataSource = tabla;
            ActualizarVisor(visorVacunaciones, "ALBERGUE_HUELLITAS_FELICES.Reportes.Vacunaciones.rdlc", "VacunacionesDataSet", tabla);
            lblResumenVacunaciones.Text = $"Total de vacunaciones: {tabla.Rows.Count}";
        });
    }

    private void CargarInsumos()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.Insumos(
                cmbTipoInsumo.SelectedIndex <= 0 ? "" : cmbTipoInsumo.Text,
                chkBajoStock.Checked);
            dgvInsumos.DataSource = tabla;
            decimal stock = 0;
            foreach (DataRow fila in tabla.Rows)
                stock += fila["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Stock"]);
            lblResumenInsumos.Text = $"Insumos: {tabla.Rows.Count} | Stock total: {stock:N2}";
        });
    }

    private void CargarAportes()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.AportesEconomicos(
                dtDesdeAportes.Checked ? dtDesdeAportes.Value : null,
                dtHastaAportes.Checked ? dtHastaAportes.Value : null);
            dgvAportes.DataSource = tabla;
            ActualizarVisor(visorAportes, "ALBERGUE_HUELLITAS_FELICES.Reportes.AportesEconomicos.rdlc", "AportesEconomicosDataSet", tabla);
            decimal total = 0;
            foreach (DataRow fila in tabla.Rows)
                total += fila["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Monto"]);
            lblResumenAportes.Text = $"Aportes: {tabla.Rows.Count} | Total recaudado: {total:C2}";
        });
    }

    private void CargarCompras()
    {
        Ejecutar(() =>
        {
            var tabla = ReportesDatos.Compras(
                dtDesdeCompras.Checked ? dtDesdeCompras.Value : null,
                dtHastaCompras.Checked ? dtHastaCompras.Value : null);
            dgvCompras.DataSource = tabla;
            decimal total = 0;
            foreach (DataRow fila in tabla.Rows)
                total += fila["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Total"]);
            lblResumenCompras.Text = $"Compras: {tabla.Rows.Count} | Total de egresos: {total:C2}";
        });
    }

    private static void Ejecutar(Action accion)
    {
        try
        {
            accion();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo cargar el reporte: " + ex.Message,
                "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static ReportViewer CrearVisor() => new()
    {
        Dock = DockStyle.Fill,
        ProcessingMode = ProcessingMode.Local,
        ShowExportButton = true,
        ShowFindControls = true,
        ShowPageNavigationControls = true,
        ShowPrintButton = true,
        ShowRefreshButton = true,
        ShowZoomControl = true,
        ZoomMode = ZoomMode.PageWidth
    };

    private static void ActualizarVisor(ReportViewer visor, string recurso, string nombreDataSet, DataTable tabla)
    {
        visor.LocalReport.DataSources.Clear();
        visor.LocalReport.ReportEmbeddedResource = recurso;
        visor.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet, tabla));
        visor.RefreshReport();
    }

    private static FlowLayoutPanel Barra(params Control[] controles)
    {
        var barra = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 58,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(4),
            BackColor = Color.White
        };
        barra.Controls.AddRange(controles);
        return barra;
    }

    private static Label Etiqueta(string texto) => new()
    {
        Text = texto,
        AutoSize = true,
        Margin = new Padding(10, 10, 4, 4),
        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
    };

    private static Label Resumen() => new()
    {
        Dock = DockStyle.Bottom,
        Height = 36,
        Text = "Sin resultados",
        TextAlign = ContentAlignment.MiddleLeft,
        Padding = new Padding(8, 0, 0, 0),
        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
        ForeColor = Color.MidnightBlue
    };

    private static Button Boton(string texto, EventHandler evento)
    {
        var boton = new Button
        {
            Text = texto,
            AutoSize = true,
            Height = 32,
            Margin = new Padding(10, 5, 4, 4),
            BackColor = Color.CornflowerBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        boton.Click += evento;
        return boton;
    }

    private static ComboBox Combo(params string[] elementos)
    {
        var combo = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 160,
            Margin = new Padding(4, 5, 8, 4)
        };
        combo.Items.AddRange(elementos);
        combo.SelectedIndex = 0;
        return combo;
    }

    private static void AgregarOpciones(ComboBox combo, IEnumerable<string> opciones)
    {
        foreach (var opcion in opciones)
            combo.Items.Add(opcion);
    }

    private static DateTimePicker Fecha()
    {
        var fecha = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = " ",
            ShowCheckBox = true,
            Checked = false,
            Width = 130,
            Margin = new Padding(4, 5, 8, 4)
        };

        fecha.ValueChanged += (_, _) =>
        {
            fecha.CustomFormat = fecha.Checked ? "dd/MM/yyyy" : " ";
        };
        fecha.MouseUp += (_, _) =>
        {
            fecha.CustomFormat = fecha.Checked ? "dd/MM/yyyy" : " ";
        };

        return fecha;
    }

    private static DataGridView Tabla() => new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        AutoGenerateColumns = true,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        BackgroundColor = Color.White,
        BorderStyle = BorderStyle.Fixed3D,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect
    };
}
