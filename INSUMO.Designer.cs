namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class INSUMO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INSUMO));
            txtDescripcionInsumo = new TextBox();
            cmbUnidadInsumo = new ComboBox();
            cmbTipoInsumo = new ComboBox();
            dtpFechaVencimientoinsumo = new DateTimePicker();
            dgvInsumo = new DataGridView();
            btnGuardarInsumo = new Button();
            btnVolverInsumo = new Button();
            txtStockActualInsumos = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvInsumo).BeginInit();
            SuspendLayout();
            // 
            // txtDescripcionInsumo
            // 
            txtDescripcionInsumo.Location = new Point(102, 261);
            txtDescripcionInsumo.Name = "txtDescripcionInsumo";
            txtDescripcionInsumo.Size = new Size(316, 31);
            txtDescripcionInsumo.TabIndex = 0;
            // 
            // cmbUnidadInsumo
            // 
            cmbUnidadInsumo.FormattingEnabled = true;
            cmbUnidadInsumo.Items.AddRange(new object[] { "Kg", "Litro", "Unidad", "Bolsa", "Caja", "Frasco" });
            cmbUnidadInsumo.Location = new Point(508, 258);
            cmbUnidadInsumo.Name = "cmbUnidadInsumo";
            cmbUnidadInsumo.Size = new Size(255, 33);
            cmbUnidadInsumo.TabIndex = 1;
            // 
            // cmbTipoInsumo
            // 
            cmbTipoInsumo.FormattingEnabled = true;
            cmbTipoInsumo.Items.AddRange(new object[] { "Perecedero", "No perecedero" });
            cmbTipoInsumo.Location = new Point(852, 262);
            cmbTipoInsumo.Name = "cmbTipoInsumo";
            cmbTipoInsumo.Size = new Size(252, 33);
            cmbTipoInsumo.TabIndex = 2;
            // 
            // dtpFechaVencimientoinsumo
            // 
            dtpFechaVencimientoinsumo.Location = new Point(518, 341);
            dtpFechaVencimientoinsumo.Name = "dtpFechaVencimientoinsumo";
            dtpFechaVencimientoinsumo.Size = new Size(315, 31);
            dtpFechaVencimientoinsumo.TabIndex = 3;
            // 
            // dgvInsumo
            // 
            dgvInsumo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInsumo.Location = new Point(43, 571);
            dgvInsumo.Name = "dgvInsumo";
            dgvInsumo.RowHeadersWidth = 62;
            dgvInsumo.Size = new Size(1259, 133);
            dgvInsumo.TabIndex = 4;
            // 
            // btnGuardarInsumo
            // 
            btnGuardarInsumo.BackColor = Color.Transparent;
            btnGuardarInsumo.FlatAppearance.BorderSize = 0;
            btnGuardarInsumo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarInsumo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarInsumo.FlatStyle = FlatStyle.Flat;
            btnGuardarInsumo.Location = new Point(57, 396);
            btnGuardarInsumo.Name = "btnGuardarInsumo";
            btnGuardarInsumo.Size = new Size(255, 51);
            btnGuardarInsumo.TabIndex = 5;
            btnGuardarInsumo.Text = ",";
            btnGuardarInsumo.UseVisualStyleBackColor = false;
            btnGuardarInsumo.Click += btnGuardarInsumo_Click;
            // 
            // btnVolverInsumo
            // 
            btnVolverInsumo.BackColor = Color.Transparent;
            btnVolverInsumo.FlatAppearance.BorderSize = 0;
            btnVolverInsumo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverInsumo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverInsumo.FlatStyle = FlatStyle.Flat;
            btnVolverInsumo.Location = new Point(1085, 162);
            btnVolverInsumo.Name = "btnVolverInsumo";
            btnVolverInsumo.Size = new Size(169, 37);
            btnVolverInsumo.TabIndex = 6;
            btnVolverInsumo.Text = ".";
            btnVolverInsumo.UseVisualStyleBackColor = false;
            btnVolverInsumo.Click += btnVolverInsumo_Click;
            // 
            // txtStockActualInsumos
            // 
            txtStockActualInsumos.Location = new Point(102, 341);
            txtStockActualInsumos.Name = "txtStockActualInsumos";
            txtStockActualInsumos.Size = new Size(316, 31);
            txtStockActualInsumos.TabIndex = 7;
            // 
            // INSUMO
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(txtStockActualInsumos);
            Controls.Add(btnVolverInsumo);
            Controls.Add(btnGuardarInsumo);
            Controls.Add(dgvInsumo);
            Controls.Add(dtpFechaVencimientoinsumo);
            Controls.Add(cmbTipoInsumo);
            Controls.Add(cmbUnidadInsumo);
            Controls.Add(txtDescripcionInsumo);
            Name = "INSUMO";
            Text = "INSUMO";
            Load += INSUMO_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInsumo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescripcionInsumo;
        private ComboBox cmbUnidadInsumo;
        private ComboBox cmbTipoInsumo;
        private DateTimePicker dtpFechaVencimientoinsumo;
        private DataGridView dgvInsumo;
        private Button btnGuardarInsumo;
        private Button btnVolverInsumo;
        private TextBox txtStockActualInsumos;
    }
}