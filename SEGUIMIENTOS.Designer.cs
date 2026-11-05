namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class SEGUIMIENTOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEGUIMIENTOS));
            btnGuardarSeguimiento = new Button();
            cmbEstadoSeguimiento = new ComboBox();
            cmbAdopcionSeguimiento = new ComboBox();
            dtpFechaVisitaSrguimiento = new DateTimePicker();
            btnVolverSeguimiento = new Button();
            dgvSeguimiento = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).BeginInit();
            SuspendLayout();
            // 
            // btnGuardarSeguimiento
            // 
            btnGuardarSeguimiento.BackColor = Color.Transparent;
            btnGuardarSeguimiento.FlatAppearance.BorderSize = 0;
            btnGuardarSeguimiento.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarSeguimiento.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarSeguimiento.FlatStyle = FlatStyle.Flat;
            btnGuardarSeguimiento.Location = new Point(58, 342);
            btnGuardarSeguimiento.Name = "btnGuardarSeguimiento";
            btnGuardarSeguimiento.Size = new Size(258, 37);
            btnGuardarSeguimiento.TabIndex = 0;
            btnGuardarSeguimiento.Text = ".";
            btnGuardarSeguimiento.UseVisualStyleBackColor = false;
            btnGuardarSeguimiento.Click += btnGuardarSeguimiento_Click;
            // 
            // cmbEstadoSeguimiento
            // 
            cmbEstadoSeguimiento.FormattingEnabled = true;
            cmbEstadoSeguimiento.Location = new Point(834, 271);
            cmbEstadoSeguimiento.Name = "cmbEstadoSeguimiento";
            cmbEstadoSeguimiento.Size = new Size(266, 33);
            cmbEstadoSeguimiento.TabIndex = 1;
            // 
            // cmbAdopcionSeguimiento
            // 
            cmbAdopcionSeguimiento.FormattingEnabled = true;
            cmbAdopcionSeguimiento.Location = new Point(113, 274);
            cmbAdopcionSeguimiento.Name = "cmbAdopcionSeguimiento";
            cmbAdopcionSeguimiento.Size = new Size(282, 33);
            cmbAdopcionSeguimiento.TabIndex = 2;
            // 
            // dtpFechaVisitaSrguimiento
            // 
            dtpFechaVisitaSrguimiento.Location = new Point(490, 272);
            dtpFechaVisitaSrguimiento.Name = "dtpFechaVisitaSrguimiento";
            dtpFechaVisitaSrguimiento.Size = new Size(254, 31);
            dtpFechaVisitaSrguimiento.TabIndex = 3;
            // 
            // btnVolverSeguimiento
            // 
            btnVolverSeguimiento.BackColor = Color.Transparent;
            btnVolverSeguimiento.FlatAppearance.BorderSize = 0;
            btnVolverSeguimiento.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverSeguimiento.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverSeguimiento.FlatStyle = FlatStyle.Flat;
            btnVolverSeguimiento.Location = new Point(1089, 165);
            btnVolverSeguimiento.Name = "btnVolverSeguimiento";
            btnVolverSeguimiento.Size = new Size(159, 34);
            btnVolverSeguimiento.TabIndex = 4;
            btnVolverSeguimiento.Text = ".";
            btnVolverSeguimiento.UseVisualStyleBackColor = false;
            btnVolverSeguimiento.Click += btnVolverSeguimiento_Click;
            // 
            // dgvSeguimiento
            // 
            dgvSeguimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeguimiento.Location = new Point(44, 525);
            dgvSeguimiento.Name = "dgvSeguimiento";
            dgvSeguimiento.RowHeadersWidth = 62;
            dgvSeguimiento.Size = new Size(1253, 170);
            dgvSeguimiento.TabIndex = 5;
            // 
            // SEGUIMIENTOS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvSeguimiento);
            Controls.Add(btnVolverSeguimiento);
            Controls.Add(dtpFechaVisitaSrguimiento);
            Controls.Add(cmbAdopcionSeguimiento);
            Controls.Add(cmbEstadoSeguimiento);
            Controls.Add(btnGuardarSeguimiento);
            Name = "SEGUIMIENTOS";
            Text = "SEGUIMIENTOS";
            Load += SEGUIMIENTOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSeguimiento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGuardarSeguimiento;
        private ComboBox cmbEstadoSeguimiento;
        private ComboBox cmbAdopcionSeguimiento;
        private DateTimePicker dtpFechaVisitaSrguimiento;
        private Button btnVolverSeguimiento;
        private DataGridView dgvSeguimiento;
    }
}