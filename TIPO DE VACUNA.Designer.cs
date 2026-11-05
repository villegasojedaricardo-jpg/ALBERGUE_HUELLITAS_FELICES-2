namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class TIPO_DE_VACUNA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIPO_DE_VACUNA));
            cmbTipoVacuna = new ComboBox();
            cmbDosisRecomendada = new ComboBox();
            btnGuardarTipoVacunas = new Button();
            btnVolverTipoVacuna = new Button();
            dgvTipoVacuna = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTipoVacuna).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoVacuna
            // 
            cmbTipoVacuna.FormattingEnabled = true;
            cmbTipoVacuna.Items.AddRange(new object[] { "Antirrábica", "Quíntuple canina", "Séxtuple canina", "Parvovirus", "Tos de las perreras", "Triple felina", "Leucemia felina" });
            cmbTipoVacuna.Location = new Point(114, 276);
            cmbTipoVacuna.Name = "cmbTipoVacuna";
            cmbTipoVacuna.Size = new Size(398, 33);
            cmbTipoVacuna.TabIndex = 0;
            // 
            // cmbDosisRecomendada
            // 
            cmbDosisRecomendada.FormattingEnabled = true;
            cmbDosisRecomendada.Items.AddRange(new object[] { "0.5 ml", "1 ml", "2 ml" });
            cmbDosisRecomendada.Location = new Point(639, 276);
            cmbDosisRecomendada.Name = "cmbDosisRecomendada";
            cmbDosisRecomendada.Size = new Size(408, 33);
            cmbDosisRecomendada.TabIndex = 1;
            // 
            // btnGuardarTipoVacunas
            // 
            btnGuardarTipoVacunas.BackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatAppearance.BorderSize = 0;
            btnGuardarTipoVacunas.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarTipoVacunas.FlatStyle = FlatStyle.Flat;
            btnGuardarTipoVacunas.Location = new Point(58, 343);
            btnGuardarTipoVacunas.Name = "btnGuardarTipoVacunas";
            btnGuardarTipoVacunas.Size = new Size(255, 34);
            btnGuardarTipoVacunas.TabIndex = 2;
            btnGuardarTipoVacunas.Text = ".";
            btnGuardarTipoVacunas.UseVisualStyleBackColor = false;
            btnGuardarTipoVacunas.Click += btnGuardarTipoVacunas_Click;
            // 
            // btnVolverTipoVacuna
            // 
            btnVolverTipoVacuna.BackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatAppearance.BorderSize = 0;
            btnVolverTipoVacuna.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverTipoVacuna.FlatStyle = FlatStyle.Flat;
            btnVolverTipoVacuna.Location = new Point(1094, 165);
            btnVolverTipoVacuna.Name = "btnVolverTipoVacuna";
            btnVolverTipoVacuna.Size = new Size(155, 34);
            btnVolverTipoVacuna.TabIndex = 3;
            btnVolverTipoVacuna.Text = ".";
            btnVolverTipoVacuna.UseVisualStyleBackColor = false;
            btnVolverTipoVacuna.Click += btnVolverTipoVacuna_Click;
            // 
            // dgvTipoVacuna
            // 
            dgvTipoVacuna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipoVacuna.Location = new Point(39, 521);
            dgvTipoVacuna.Name = "dgvTipoVacuna";
            dgvTipoVacuna.RowHeadersWidth = 62;
            dgvTipoVacuna.Size = new Size(1260, 181);
            dgvTipoVacuna.TabIndex = 4;
            // 
            // TIPO_DE_VACUNA
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvTipoVacuna);
            Controls.Add(btnVolverTipoVacuna);
            Controls.Add(btnGuardarTipoVacunas);
            Controls.Add(cmbDosisRecomendada);
            Controls.Add(cmbTipoVacuna);
            Name = "TIPO_DE_VACUNA";
            Text = "TIPO_DE_VACUNA";
            Load += TIPO_DE_VACUNA_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTipoVacuna).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbTipoVacuna;
        private ComboBox cmbDosisRecomendada;
        private Button btnGuardarTipoVacunas;
        private Button btnVolverTipoVacuna;
        private DataGridView dgvTipoVacuna;
    }
}