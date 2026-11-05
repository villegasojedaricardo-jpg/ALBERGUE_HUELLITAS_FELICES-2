namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class MASCOTAS
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MASCOTAS));
            button1 = new Button();
            btnGuardar = new Button();
            dgvMascotas = new DataGridView();
            txtNombreMascota = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmbEstadoDisponibilidad = new ComboBox();
            cmbEspecie = new ComboBox();
            cmbPersonal = new ComboBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1103, 159);
            button1.Name = "button1";
            button1.Size = new Size(136, 37);
            button1.TabIndex = 0;
            button1.Text = ".";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            btnGuardar.Enabled = false;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(56, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(252, 34);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = ".";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvMascotas
            // 
            dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMascotas.Location = new Point(43, 506);
            dgvMascotas.Name = "dgvMascotas";
            dgvMascotas.RowHeadersWidth = 62;
            dgvMascotas.Size = new Size(1259, 200);
            dgvMascotas.TabIndex = 2;
            dgvMascotas.CellContentClick += dgvMascotas_CellContentClick;
            // 
            // txtNombreMascota
            // 
            txtNombreMascota.Location = new Point(113, 296);
            txtNombreMascota.Name = "txtNombreMascota";
            txtNombreMascota.Size = new Size(176, 31);
            txtNombreMascota.TabIndex = 4;
            txtNombreMascota.TextChanged += txtNombreMascota_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbEstadoDisponibilidad
            // 
            cmbEstadoDisponibilidad.FormattingEnabled = true;
            cmbEstadoDisponibilidad.Items.AddRange(new object[] { "Disponible", "En tratamiento", "Adoptado" });
            cmbEstadoDisponibilidad.Location = new Point(649, 296);
            cmbEstadoDisponibilidad.Name = "cmbEstadoDisponibilidad";
            cmbEstadoDisponibilidad.Size = new Size(182, 33);
            cmbEstadoDisponibilidad.TabIndex = 9;
            cmbEstadoDisponibilidad.SelectedIndexChanged += cmbEstadoDisponibilidad_SelectedIndexChanged;
            // 
            // cmbEspecie
            // 
            cmbEspecie.FormattingEnabled = true;
            cmbEspecie.Items.AddRange(new object[] { "Perro", "Gato" });
            cmbEspecie.Location = new Point(374, 294);
            cmbEspecie.Name = "cmbEspecie";
            cmbEspecie.Size = new Size(182, 33);
            cmbEspecie.TabIndex = 10;
            cmbEspecie.SelectedIndexChanged += cmbEspecie_SelectedIndexChanged;
            // 
            // cmbPersonal
            // 
            cmbPersonal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPersonal.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPersonal.DisplayMember = "id_personal";
            cmbPersonal.Enabled = false;
            cmbPersonal.FormattingEnabled = true;
            cmbPersonal.Location = new Point(921, 294);
            cmbPersonal.Name = "cmbPersonal";
            cmbPersonal.Size = new Size(182, 33);
            cmbPersonal.TabIndex = 11;
            cmbPersonal.ValueMember = "id_personal";
            cmbPersonal.SelectedIndexChanged += cmbPersonal_SelectedIndexChanged;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // MASCOTAS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(cmbPersonal);
            Controls.Add(cmbEspecie);
            Controls.Add(cmbEstadoDisponibilidad);
            Controls.Add(txtNombreMascota);
            Controls.Add(dgvMascotas);
            Controls.Add(btnGuardar);
            Controls.Add(button1);
            Name = "MASCOTAS";
            Text = "MASCOTAS";
            Load += MASCOTAS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnGuardar;
        private DataGridView dgvMascotas;
        private TextBox txtNombreMascota;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbEstadoDisponibilidad;
        private ComboBox cmbEspecie;
        private ComboBox cmbPersonal;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}