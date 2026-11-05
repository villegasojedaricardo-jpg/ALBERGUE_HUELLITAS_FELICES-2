namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class APLICACION_VACUNAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APLICACION_VACUNAS));
            btnGuardarApliVacuna = new Button();
            btnVolverApliVacuna = new Button();
            cmbMascotaApliVacunas = new ComboBox();
            cmbTipoVacunaApliVacuna = new ComboBox();
            dgvAplicacionVacunas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAplicacionVacunas).BeginInit();
            SuspendLayout();
            // 
            // btnGuardarApliVacuna
            // 
            btnGuardarApliVacuna.BackColor = Color.Transparent;
            btnGuardarApliVacuna.FlatAppearance.BorderSize = 0;
            btnGuardarApliVacuna.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarApliVacuna.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarApliVacuna.FlatStyle = FlatStyle.Flat;
            btnGuardarApliVacuna.Location = new Point(61, 349);
            btnGuardarApliVacuna.Name = "btnGuardarApliVacuna";
            btnGuardarApliVacuna.Size = new Size(249, 34);
            btnGuardarApliVacuna.TabIndex = 0;
            btnGuardarApliVacuna.Text = ".";
            btnGuardarApliVacuna.UseVisualStyleBackColor = false;
            btnGuardarApliVacuna.Click += btnGuardarApliVacuna_Click;
            // 
            // btnVolverApliVacuna
            // 
            btnVolverApliVacuna.BackColor = Color.Transparent;
            btnVolverApliVacuna.FlatAppearance.BorderSize = 0;
            btnVolverApliVacuna.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverApliVacuna.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverApliVacuna.FlatStyle = FlatStyle.Flat;
            btnVolverApliVacuna.Location = new Point(1083, 166);
            btnVolverApliVacuna.Name = "btnVolverApliVacuna";
            btnVolverApliVacuna.Size = new Size(169, 34);
            btnVolverApliVacuna.TabIndex = 1;
            btnVolverApliVacuna.Text = ".";
            btnVolverApliVacuna.UseVisualStyleBackColor = false;
            btnVolverApliVacuna.Click += btnVolverApliVacuna_Click;
            // 
            // cmbMascotaApliVacunas
            // 
            cmbMascotaApliVacunas.FormattingEnabled = true;
            cmbMascotaApliVacunas.Location = new Point(61, 255);
            cmbMascotaApliVacunas.Name = "cmbMascotaApliVacunas";
            cmbMascotaApliVacunas.Size = new Size(450, 33);
            cmbMascotaApliVacunas.TabIndex = 2;
            // 
            // cmbTipoVacunaApliVacuna
            // 
            cmbTipoVacunaApliVacuna.FormattingEnabled = true;
            cmbTipoVacunaApliVacuna.Location = new Point(574, 255);
            cmbTipoVacunaApliVacuna.Name = "cmbTipoVacunaApliVacuna";
            cmbTipoVacunaApliVacuna.Size = new Size(456, 33);
            cmbTipoVacunaApliVacuna.TabIndex = 3;
            // 
            // dgvAplicacionVacunas
            // 
            dgvAplicacionVacunas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAplicacionVacunas.Location = new Point(37, 533);
            dgvAplicacionVacunas.Name = "dgvAplicacionVacunas";
            dgvAplicacionVacunas.RowHeadersWidth = 62;
            dgvAplicacionVacunas.Size = new Size(1260, 178);
            dgvAplicacionVacunas.TabIndex = 4;
            // 
            // APLICACION_VACUNAS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvAplicacionVacunas);
            Controls.Add(cmbTipoVacunaApliVacuna);
            Controls.Add(cmbMascotaApliVacunas);
            Controls.Add(btnVolverApliVacuna);
            Controls.Add(btnGuardarApliVacuna);
            Name = "APLICACION_VACUNAS";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "APLICACION_VACUNAS";
            Load += APLICACION_VACUNAS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAplicacionVacunas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGuardarApliVacuna;
        private Button btnVolverApliVacuna;
        private ComboBox cmbMascotaApliVacunas;
        private ComboBox cmbTipoVacunaApliVacuna;
        private DataGridView dgvAplicacionVacunas;
    }
}