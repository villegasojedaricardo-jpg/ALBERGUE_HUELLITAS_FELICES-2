namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class REGISTRO_ADOPCION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REGISTRO_ADOPCION));
            cmbMascotaNuevaAdopcion = new ComboBox();
            cmbAdoptanteNuevaAdopcion = new ComboBox();
            btnGuardarNuevaAdopcion = new Button();
            btnVolverNuevaAdopcion = new Button();
            dgvNuevaAdopcion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNuevaAdopcion).BeginInit();
            SuspendLayout();
            // 
            // cmbMascotaNuevaAdopcion
            // 
            cmbMascotaNuevaAdopcion.FormattingEnabled = true;
            cmbMascotaNuevaAdopcion.Location = new Point(121, 264);
            cmbMascotaNuevaAdopcion.Name = "cmbMascotaNuevaAdopcion";
            cmbMascotaNuevaAdopcion.Size = new Size(328, 33);
            cmbMascotaNuevaAdopcion.TabIndex = 0;
            // 
            // cmbAdoptanteNuevaAdopcion
            // 
            cmbAdoptanteNuevaAdopcion.FormattingEnabled = true;
            cmbAdoptanteNuevaAdopcion.Location = new Point(550, 264);
            cmbAdoptanteNuevaAdopcion.Name = "cmbAdoptanteNuevaAdopcion";
            cmbAdoptanteNuevaAdopcion.Size = new Size(277, 33);
            cmbAdoptanteNuevaAdopcion.TabIndex = 1;
            cmbAdoptanteNuevaAdopcion.SelectedIndexChanged += cmbAdoptanteNuevaAdopcion_SelectedIndexChanged;
            // 
            // btnGuardarNuevaAdopcion
            // 
            btnGuardarNuevaAdopcion.BackColor = Color.Transparent;
            btnGuardarNuevaAdopcion.FlatAppearance.BorderSize = 0;
            btnGuardarNuevaAdopcion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarNuevaAdopcion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarNuevaAdopcion.FlatStyle = FlatStyle.Flat;
            btnGuardarNuevaAdopcion.Location = new Point(59, 333);
            btnGuardarNuevaAdopcion.Name = "btnGuardarNuevaAdopcion";
            btnGuardarNuevaAdopcion.Size = new Size(262, 41);
            btnGuardarNuevaAdopcion.TabIndex = 2;
            btnGuardarNuevaAdopcion.Text = ".";
            btnGuardarNuevaAdopcion.UseVisualStyleBackColor = false;
            btnGuardarNuevaAdopcion.Click += btnGuardarNuevaAdopcion_Click;
            // 
            // btnVolverNuevaAdopcion
            // 
            btnVolverNuevaAdopcion.BackColor = Color.Transparent;
            btnVolverNuevaAdopcion.BackgroundImageLayout = ImageLayout.Stretch;
            btnVolverNuevaAdopcion.FlatAppearance.BorderSize = 0;
            btnVolverNuevaAdopcion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverNuevaAdopcion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverNuevaAdopcion.FlatStyle = FlatStyle.Flat;
            btnVolverNuevaAdopcion.Location = new Point(1100, 162);
            btnVolverNuevaAdopcion.Name = "btnVolverNuevaAdopcion";
            btnVolverNuevaAdopcion.Size = new Size(143, 34);
            btnVolverNuevaAdopcion.TabIndex = 3;
            btnVolverNuevaAdopcion.Text = ".";
            btnVolverNuevaAdopcion.UseVisualStyleBackColor = false;
            btnVolverNuevaAdopcion.Click += btnVolverNuevaAdopcion_Click;
            // 
            // dgvNuevaAdopcion
            // 
            dgvNuevaAdopcion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNuevaAdopcion.Location = new Point(41, 522);
            dgvNuevaAdopcion.Name = "dgvNuevaAdopcion";
            dgvNuevaAdopcion.RowHeadersWidth = 62;
            dgvNuevaAdopcion.Size = new Size(1257, 169);
            dgvNuevaAdopcion.TabIndex = 4;
            dgvNuevaAdopcion.CellContentClick += dgvNuevaAdopcion_CellContentClick;
            // 
            // REGISTRO_ADOPCION
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvNuevaAdopcion);
            Controls.Add(btnVolverNuevaAdopcion);
            Controls.Add(btnGuardarNuevaAdopcion);
            Controls.Add(cmbAdoptanteNuevaAdopcion);
            Controls.Add(cmbMascotaNuevaAdopcion);
            Name = "REGISTRO_ADOPCION";
            Text = "REGISTRO_ADOPCION";
            Load += REGISTRO_ADOPCION_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNuevaAdopcion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbMascotaNuevaAdopcion;
        private ComboBox cmbAdoptanteNuevaAdopcion;
        private Button btnGuardarNuevaAdopcion;
        private Button btnVolverNuevaAdopcion;
        private DataGridView dgvNuevaAdopcion;
    }
}