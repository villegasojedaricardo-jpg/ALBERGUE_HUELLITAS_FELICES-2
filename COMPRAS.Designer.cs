namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class COMPRAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMPRAS));
            btnGuardarDetalleCompra = new Button();
            btnGuardarRegistroCompra = new Button();
            btnVolverCompras = new Button();
            cmbNombreInsumoCompras = new ComboBox();
            txtCantidadDetalleCompra = new TextBox();
            txtPrecioUnitarioCompra = new TextBox();
            txtNumeroFacturaRegistroCompra = new TextBox();
            dgvDetalleCompra = new DataGridView();
            dgvRegistroCompra = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroCompra).BeginInit();
            SuspendLayout();
            // 
            // btnGuardarDetalleCompra
            // 
            btnGuardarDetalleCompra.BackColor = Color.Transparent;
            btnGuardarDetalleCompra.FlatAppearance.BorderSize = 0;
            btnGuardarDetalleCompra.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarDetalleCompra.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarDetalleCompra.FlatStyle = FlatStyle.Flat;
            btnGuardarDetalleCompra.Location = new Point(42, 345);
            btnGuardarDetalleCompra.Name = "btnGuardarDetalleCompra";
            btnGuardarDetalleCompra.Size = new Size(161, 34);
            btnGuardarDetalleCompra.TabIndex = 0;
            btnGuardarDetalleCompra.Text = ".";
            btnGuardarDetalleCompra.UseVisualStyleBackColor = false;
            btnGuardarDetalleCompra.Click += btnGuardarDetalleCompra_Click;
            // 
            // btnGuardarRegistroCompra
            // 
            btnGuardarRegistroCompra.BackColor = Color.Transparent;
            btnGuardarRegistroCompra.FlatAppearance.BorderSize = 0;
            btnGuardarRegistroCompra.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarRegistroCompra.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarRegistroCompra.FlatStyle = FlatStyle.Flat;
            btnGuardarRegistroCompra.Location = new Point(777, 345);
            btnGuardarRegistroCompra.Name = "btnGuardarRegistroCompra";
            btnGuardarRegistroCompra.Size = new Size(134, 34);
            btnGuardarRegistroCompra.TabIndex = 1;
            btnGuardarRegistroCompra.Text = ".";
            btnGuardarRegistroCompra.UseVisualStyleBackColor = false;
            btnGuardarRegistroCompra.Click += btnGuardarRegistroCompra_Click;
            // 
            // btnVolverCompras
            // 
            btnVolverCompras.BackColor = Color.Transparent;
            btnVolverCompras.FlatAppearance.BorderSize = 0;
            btnVolverCompras.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverCompras.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverCompras.FlatStyle = FlatStyle.Flat;
            btnVolverCompras.Location = new Point(942, 56);
            btnVolverCompras.Name = "btnVolverCompras";
            btnVolverCompras.Size = new Size(129, 34);
            btnVolverCompras.TabIndex = 2;
            btnVolverCompras.Text = ".";
            btnVolverCompras.UseVisualStyleBackColor = false;
            btnVolverCompras.Click += btnVolverCompras_Click;
            // 
            // cmbNombreInsumoCompras
            // 
            cmbNombreInsumoCompras.FormattingEnabled = true;
            cmbNombreInsumoCompras.Location = new Point(91, 277);
            cmbNombreInsumoCompras.Name = "cmbNombreInsumoCompras";
            cmbNombreInsumoCompras.Size = new Size(192, 33);
            cmbNombreInsumoCompras.TabIndex = 3;
            // 
            // txtCantidadDetalleCompra
            // 
            txtCantidadDetalleCompra.Location = new Point(353, 277);
            txtCantidadDetalleCompra.Name = "txtCantidadDetalleCompra";
            txtCantidadDetalleCompra.Size = new Size(137, 31);
            txtCantidadDetalleCompra.TabIndex = 4;
            txtCantidadDetalleCompra.KeyPress += SoloDecimal_KeyPress;
            // 
            // txtPrecioUnitarioCompra
            // 
            txtPrecioUnitarioCompra.Location = new Point(558, 279);
            txtPrecioUnitarioCompra.Name = "txtPrecioUnitarioCompra";
            txtPrecioUnitarioCompra.Size = new Size(150, 31);
            txtPrecioUnitarioCompra.TabIndex = 5;
            txtPrecioUnitarioCompra.KeyPress += SoloDecimal_KeyPress;
            // 
            // txtNumeroFacturaRegistroCompra
            // 
            txtNumeroFacturaRegistroCompra.Location = new Point(824, 277);
            txtNumeroFacturaRegistroCompra.Name = "txtNumeroFacturaRegistroCompra";
            txtNumeroFacturaRegistroCompra.Size = new Size(194, 31);
            txtNumeroFacturaRegistroCompra.TabIndex = 6;
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Location = new Point(42, 437);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.RowHeadersWidth = 62;
            dgvDetalleCompra.Size = new Size(674, 162);
            dgvDetalleCompra.TabIndex = 7;
            // 
            // dgvRegistroCompra
            // 
            dgvRegistroCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistroCompra.Location = new Point(777, 437);
            dgvRegistroCompra.Name = "dgvRegistroCompra";
            dgvRegistroCompra.RowHeadersWidth = 62;
            dgvRegistroCompra.Size = new Size(525, 162);
            dgvRegistroCompra.TabIndex = 8;
            dgvRegistroCompra.CellClick += dgvRegistroCompra_CellClick;
            // 
            // COMPRAS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvRegistroCompra);
            Controls.Add(dgvDetalleCompra);
            Controls.Add(txtNumeroFacturaRegistroCompra);
            Controls.Add(txtPrecioUnitarioCompra);
            Controls.Add(txtCantidadDetalleCompra);
            Controls.Add(cmbNombreInsumoCompras);
            Controls.Add(btnVolverCompras);
            Controls.Add(btnGuardarRegistroCompra);
            Controls.Add(btnGuardarDetalleCompra);
            Name = "COMPRAS";
            Text = "COMPRAS";
            Load += COMPRAS_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardarDetalleCompra;
        private Button btnGuardarRegistroCompra;
        private Button btnVolverCompras;
        private ComboBox cmbNombreInsumoCompras;
        private TextBox txtCantidadDetalleCompra;
        private TextBox txtPrecioUnitarioCompra;
        private TextBox txtNumeroFacturaRegistroCompra;
        private DataGridView dgvDetalleCompra;
        private DataGridView dgvRegistroCompra;
    }
}