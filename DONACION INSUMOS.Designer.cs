namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class DONACION_INSUMOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DONACION_INSUMOS));
            cmbInsumoDonacionInsumo = new ComboBox();
            cmbDonanteNomDonacionInsumo = new ComboBox();
            btnGuardarDonacionInsumo = new Button();
            btnVolverDonacionInsumo = new Button();
            txtCantidadDonacionInsumo = new TextBox();
            dgvDonacionInsumo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDonacionInsumo).BeginInit();
            SuspendLayout();
            // 
            // cmbInsumoDonacionInsumo
            // 
            cmbInsumoDonacionInsumo.FormattingEnabled = true;
            cmbInsumoDonacionInsumo.Location = new Point(700, 261);
            cmbInsumoDonacionInsumo.Name = "cmbInsumoDonacionInsumo";
            cmbInsumoDonacionInsumo.Size = new Size(380, 33);
            cmbInsumoDonacionInsumo.TabIndex = 0;
            // 
            // cmbDonanteNomDonacionInsumo
            // 
            cmbDonanteNomDonacionInsumo.FormattingEnabled = true;
            cmbDonanteNomDonacionInsumo.Location = new Point(120, 263);
            cmbDonanteNomDonacionInsumo.Name = "cmbDonanteNomDonacionInsumo";
            cmbDonanteNomDonacionInsumo.Size = new Size(480, 33);
            cmbDonanteNomDonacionInsumo.TabIndex = 1;
            // 
            // btnGuardarDonacionInsumo
            // 
            btnGuardarDonacionInsumo.BackColor = Color.Transparent;
            btnGuardarDonacionInsumo.FlatAppearance.BorderSize = 0;
            btnGuardarDonacionInsumo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarDonacionInsumo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarDonacionInsumo.FlatStyle = FlatStyle.Flat;
            btnGuardarDonacionInsumo.Location = new Point(56, 372);
            btnGuardarDonacionInsumo.Name = "btnGuardarDonacionInsumo";
            btnGuardarDonacionInsumo.Size = new Size(236, 34);
            btnGuardarDonacionInsumo.TabIndex = 2;
            btnGuardarDonacionInsumo.Text = ".";
            btnGuardarDonacionInsumo.UseVisualStyleBackColor = false;
            btnGuardarDonacionInsumo.Click += btnGuardarDonacionInsumo_Click;
            // 
            // btnVolverDonacionInsumo
            // 
            btnVolverDonacionInsumo.BackColor = Color.Transparent;
            btnVolverDonacionInsumo.FlatAppearance.BorderSize = 0;
            btnVolverDonacionInsumo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverDonacionInsumo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverDonacionInsumo.FlatStyle = FlatStyle.Flat;
            btnVolverDonacionInsumo.Location = new Point(1085, 162);
            btnVolverDonacionInsumo.Name = "btnVolverDonacionInsumo";
            btnVolverDonacionInsumo.Size = new Size(173, 44);
            btnVolverDonacionInsumo.TabIndex = 3;
            btnVolverDonacionInsumo.Text = ".";
            btnVolverDonacionInsumo.UseVisualStyleBackColor = false;
            btnVolverDonacionInsumo.Click += btnVolverDonacionInsumo_Click;
            // 
            // txtCantidadDonacionInsumo
            // 
            txtCantidadDonacionInsumo.Location = new Point(110, 334);
            txtCantidadDonacionInsumo.Name = "txtCantidadDonacionInsumo";
            txtCantidadDonacionInsumo.Size = new Size(490, 31);
            txtCantidadDonacionInsumo.TabIndex = 4;
            // 
            // dgvDonacionInsumo
            // 
            dgvDonacionInsumo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonacionInsumo.Location = new Point(38, 523);
            dgvDonacionInsumo.Name = "dgvDonacionInsumo";
            dgvDonacionInsumo.RowHeadersWidth = 62;
            dgvDonacionInsumo.Size = new Size(1262, 149);
            dgvDonacionInsumo.TabIndex = 5;
            // 
            // DONACION_INSUMOS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvDonacionInsumo);
            Controls.Add(txtCantidadDonacionInsumo);
            Controls.Add(btnVolverDonacionInsumo);
            Controls.Add(btnGuardarDonacionInsumo);
            Controls.Add(cmbDonanteNomDonacionInsumo);
            Controls.Add(cmbInsumoDonacionInsumo);
            Name = "DONACION_INSUMOS";
            Text = "DONACION_INSUMOS";
            Load += DONACION_INSUMOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDonacionInsumo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbInsumoDonacionInsumo;
        private ComboBox cmbDonanteNomDonacionInsumo;
        private Button btnGuardarDonacionInsumo;
        private Button btnVolverDonacionInsumo;
        private TextBox txtCantidadDonacionInsumo;
        private DataGridView dgvDonacionInsumo;
    }
}