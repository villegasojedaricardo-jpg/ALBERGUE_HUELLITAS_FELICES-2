namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class DONANTES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DONANTES));
            dgvDonantes = new DataGridView();
            btnGuardarDonantes = new Button();
            btnVolverDonantes = new Button();
            txtNombreCompletoDonante = new TextBox();
            btnReporteDonacion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDonantes).BeginInit();
            SuspendLayout();
            // 
            // dgvDonantes
            // 
            dgvDonantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonantes.Location = new Point(71, 807);
            dgvDonantes.Margin = new Padding(5, 5, 5, 5);
            dgvDonantes.Name = "dgvDonantes";
            dgvDonantes.RowHeadersWidth = 62;
            dgvDonantes.Size = new Size(2130, 335);
            dgvDonantes.TabIndex = 1;
            // 
            // btnGuardarDonantes
            // 
            btnGuardarDonantes.BackColor = Color.Transparent;
            btnGuardarDonantes.FlatAppearance.BorderSize = 0;
            btnGuardarDonantes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarDonantes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarDonantes.FlatStyle = FlatStyle.Flat;
            btnGuardarDonantes.Location = new Point(110, 566);
            btnGuardarDonantes.Margin = new Padding(5, 5, 5, 5);
            btnGuardarDonantes.Name = "btnGuardarDonantes";
            btnGuardarDonantes.Size = new Size(430, 74);
            btnGuardarDonantes.TabIndex = 2;
            btnGuardarDonantes.Text = ".";
            btnGuardarDonantes.UseVisualStyleBackColor = false;
            btnGuardarDonantes.Click += btnGuardarDonantes_Click;
            // 
            // btnVolverDonantes
            // 
            btnVolverDonantes.BackColor = Color.Transparent;
            btnVolverDonantes.FlatAppearance.BorderSize = 0;
            btnVolverDonantes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverDonantes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverDonantes.FlatStyle = FlatStyle.Flat;
            btnVolverDonantes.Location = new Point(1844, 259);
            btnVolverDonantes.Margin = new Padding(5, 5, 5, 5);
            btnVolverDonantes.Name = "btnVolverDonantes";
            btnVolverDonantes.Size = new Size(284, 74);
            btnVolverDonantes.TabIndex = 3;
            btnVolverDonantes.Text = ".";
            btnVolverDonantes.UseVisualStyleBackColor = false;
            btnVolverDonantes.Click += btnVolverDonantes_Click;
            // 
            // txtNombreCompletoDonante
            // 
            txtNombreCompletoDonante.Location = new Point(206, 449);
            txtNombreCompletoDonante.Margin = new Padding(5, 5, 5, 5);
            txtNombreCompletoDonante.Name = "txtNombreCompletoDonante";
            txtNombreCompletoDonante.Size = new Size(871, 47);
            txtNombreCompletoDonante.TabIndex = 4;
            // 
            // btnReporteDonacion
            // 
            btnReporteDonacion.Location = new Point(1304, 453);
            btnReporteDonacion.Name = "btnReporteDonacion";
            btnReporteDonacion.Size = new Size(188, 58);
            btnReporteDonacion.TabIndex = 5;
            btnReporteDonacion.Text = "Reporte";
            btnReporteDonacion.UseVisualStyleBackColor = true;
            btnReporteDonacion.Click += btnReporteDonacion_Click;
            // 
            // DONANTES
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2275, 1243);
            Controls.Add(btnReporteDonacion);
            Controls.Add(txtNombreCompletoDonante);
            Controls.Add(btnVolverDonantes);
            Controls.Add(btnGuardarDonantes);
            Controls.Add(dgvDonantes);
            Margin = new Padding(5, 5, 5, 5);
            Name = "DONANTES";
            Text = "DONANTES";
            Load += DONANTES_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDonantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDonantes;
        private Button btnGuardarDonantes;
        private Button btnVolverDonantes;
        private TextBox txtNombreCompletoDonante;
        private Button btnReporteDonacion;
    }
}