namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class ADOPTANTES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADOPTANTES));
            btnGuaradarAdoptantes = new Button();
            btnVolverAdoptantes = new Button();
            txtNombreAdoptante = new TextBox();
            txtTelefonoAdoptante = new TextBox();
            txtCalleAdoptante = new TextBox();
            txtCiudadAdoptante = new TextBox();
            txtReferenciaAdoptante = new TextBox();
            dgvAdoptantes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAdoptantes).BeginInit();
            SuspendLayout();
            // 
            // btnGuaradarAdoptantes
            // 
            btnGuaradarAdoptantes.BackColor = Color.Transparent;
            btnGuaradarAdoptantes.FlatAppearance.BorderSize = 0;
            btnGuaradarAdoptantes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuaradarAdoptantes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuaradarAdoptantes.FlatStyle = FlatStyle.Flat;
            btnGuaradarAdoptantes.Location = new Point(99, 648);
            btnGuaradarAdoptantes.Margin = new Padding(5, 5, 5, 5);
            btnGuaradarAdoptantes.Name = "btnGuaradarAdoptantes";
            btnGuaradarAdoptantes.Size = new Size(432, 56);
            btnGuaradarAdoptantes.TabIndex = 0;
            btnGuaradarAdoptantes.Text = ".";
            btnGuaradarAdoptantes.UseVisualStyleBackColor = false;
            btnGuaradarAdoptantes.Click += btnGuaradarAdoptantes_Click;
            // 
            // btnVolverAdoptantes
            // 
            btnVolverAdoptantes.BackColor = Color.Transparent;
            btnVolverAdoptantes.FlatAppearance.BorderSize = 0;
            btnVolverAdoptantes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverAdoptantes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverAdoptantes.FlatStyle = FlatStyle.Flat;
            btnVolverAdoptantes.Location = new Point(1862, 262);
            btnVolverAdoptantes.Margin = new Padding(5, 5, 5, 5);
            btnVolverAdoptantes.Name = "btnVolverAdoptantes";
            btnVolverAdoptantes.Size = new Size(257, 56);
            btnVolverAdoptantes.TabIndex = 1;
            btnVolverAdoptantes.Text = ".";
            btnVolverAdoptantes.UseVisualStyleBackColor = false;
            btnVolverAdoptantes.Click += btnVolverAdoptantes_Click;
            // 
            // txtNombreAdoptante
            // 
            txtNombreAdoptante.Location = new Point(206, 407);
            txtNombreAdoptante.Margin = new Padding(5, 5, 5, 5);
            txtNombreAdoptante.Name = "txtNombreAdoptante";
            txtNombreAdoptante.Size = new Size(835, 47);
            txtNombreAdoptante.TabIndex = 2;
            // 
            // txtTelefonoAdoptante
            // 
            txtTelefonoAdoptante.Location = new Point(1212, 407);
            txtTelefonoAdoptante.Margin = new Padding(5, 5, 5, 5);
            txtTelefonoAdoptante.Name = "txtTelefonoAdoptante";
            txtTelefonoAdoptante.Size = new Size(633, 47);
            txtTelefonoAdoptante.TabIndex = 3;
            // 
            // txtCalleAdoptante
            // 
            txtCalleAdoptante.Location = new Point(206, 556);
            txtCalleAdoptante.Margin = new Padding(5, 5, 5, 5);
            txtCalleAdoptante.Name = "txtCalleAdoptante";
            txtCalleAdoptante.Size = new Size(475, 47);
            txtCalleAdoptante.TabIndex = 4;
            txtCalleAdoptante.TextChanged += txtCalleAdoptante_TextChanged;
            // 
            // txtCiudadAdoptante
            // 
            txtCiudadAdoptante.Location = new Point(833, 556);
            txtCiudadAdoptante.Margin = new Padding(5, 5, 5, 5);
            txtCiudadAdoptante.Name = "txtCiudadAdoptante";
            txtCiudadAdoptante.Size = new Size(461, 47);
            txtCiudadAdoptante.TabIndex = 5;
            txtCiudadAdoptante.TextChanged += txtCiudadAdoptante_TextChanged;
            // 
            // txtReferenciaAdoptante
            // 
            txtReferenciaAdoptante.Location = new Point(1428, 556);
            txtReferenciaAdoptante.Margin = new Padding(5, 5, 5, 5);
            txtReferenciaAdoptante.Name = "txtReferenciaAdoptante";
            txtReferenciaAdoptante.Size = new Size(417, 47);
            txtReferenciaAdoptante.TabIndex = 6;
            // 
            // dgvAdoptantes
            // 
            dgvAdoptantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdoptantes.Location = new Point(71, 918);
            dgvAdoptantes.Margin = new Padding(5, 5, 5, 5);
            dgvAdoptantes.Name = "dgvAdoptantes";
            dgvAdoptantes.RowHeadersWidth = 62;
            dgvAdoptantes.Size = new Size(2147, 257);
            dgvAdoptantes.TabIndex = 7;
            // 
            // ADOPTANTES
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2275, 1243);
            Controls.Add(dgvAdoptantes);
            Controls.Add(txtReferenciaAdoptante);
            Controls.Add(txtCiudadAdoptante);
            Controls.Add(txtCalleAdoptante);
            Controls.Add(txtTelefonoAdoptante);
            Controls.Add(txtNombreAdoptante);
            Controls.Add(btnVolverAdoptantes);
            Controls.Add(btnGuaradarAdoptantes);
            Margin = new Padding(5, 5, 5, 5);
            Name = "ADOPTANTES";
            Text = "ADOPTANTES";
            Load += ADOPTANTES_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdoptantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuaradarAdoptantes;
        private Button btnVolverAdoptantes;
        private TextBox txtNombreAdoptante;
        private TextBox txtTelefonoAdoptante;
        private TextBox txtCalleAdoptante;
        private TextBox txtCiudadAdoptante;
        private TextBox txtReferenciaAdoptante;
        private DataGridView dgvAdoptantes;
    }
}