namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class APORTES_ECONOMICOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APORTES_ECONOMICOS));
            cmbDonanteAportesEconomicos = new ComboBox();
            txtMontoAportesEconomicos = new TextBox();
            btnGuardarAportesEconomicos = new Button();
            btnVolverAportesEconomicos = new Button();
            dgvAportesEconomicos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAportesEconomicos).BeginInit();
            SuspendLayout();
            // 
            // cmbDonanteAportesEconomicos
            // 
            cmbDonanteAportesEconomicos.FormattingEnabled = true;
            cmbDonanteAportesEconomicos.Location = new Point(116, 272);
            cmbDonanteAportesEconomicos.Name = "cmbDonanteAportesEconomicos";
            cmbDonanteAportesEconomicos.Size = new Size(487, 33);
            cmbDonanteAportesEconomicos.TabIndex = 0;
            // 
            // txtMontoAportesEconomicos
            // 
            txtMontoAportesEconomicos.Location = new Point(711, 271);
            txtMontoAportesEconomicos.Name = "txtMontoAportesEconomicos";
            txtMontoAportesEconomicos.Size = new Size(325, 31);
            txtMontoAportesEconomicos.TabIndex = 1;
            // 
            // btnGuardarAportesEconomicos
            // 
            btnGuardarAportesEconomicos.BackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatAppearance.BorderSize = 0;
            btnGuardarAportesEconomicos.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnGuardarAportesEconomicos.FlatStyle = FlatStyle.Flat;
            btnGuardarAportesEconomicos.Location = new Point(63, 337);
            btnGuardarAportesEconomicos.Name = "btnGuardarAportesEconomicos";
            btnGuardarAportesEconomicos.Size = new Size(258, 43);
            btnGuardarAportesEconomicos.TabIndex = 2;
            btnGuardarAportesEconomicos.Text = ".";
            btnGuardarAportesEconomicos.UseVisualStyleBackColor = false;
            btnGuardarAportesEconomicos.Click += btnGuardarAportesEconomicos_Click;
            // 
            // btnVolverAportesEconomicos
            // 
            btnVolverAportesEconomicos.BackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatAppearance.BorderSize = 0;
            btnVolverAportesEconomicos.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolverAportesEconomicos.FlatStyle = FlatStyle.Flat;
            btnVolverAportesEconomicos.Location = new Point(1085, 165);
            btnVolverAportesEconomicos.Name = "btnVolverAportesEconomicos";
            btnVolverAportesEconomicos.Size = new Size(168, 34);
            btnVolverAportesEconomicos.TabIndex = 3;
            btnVolverAportesEconomicos.Text = ".";
            btnVolverAportesEconomicos.UseVisualStyleBackColor = false;
            btnVolverAportesEconomicos.Click += btnVolverAportesEconomicos_Click;
            // 
            // dgvAportesEconomicos
            // 
            dgvAportesEconomicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAportesEconomicos.Location = new Point(42, 521);
            dgvAportesEconomicos.Name = "dgvAportesEconomicos";
            dgvAportesEconomicos.RowHeadersWidth = 62;
            dgvAportesEconomicos.Size = new Size(1256, 165);
            dgvAportesEconomicos.TabIndex = 4;
            // 
            // APORTES_ECONOMICOS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(dgvAportesEconomicos);
            Controls.Add(btnVolverAportesEconomicos);
            Controls.Add(btnGuardarAportesEconomicos);
            Controls.Add(txtMontoAportesEconomicos);
            Controls.Add(cmbDonanteAportesEconomicos);
            Name = "APORTES_ECONOMICOS";
            Text = "APORTES_ECONOMICOS";
            Load += APORTES_ECONOMICOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAportesEconomicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDonanteAportesEconomicos;
        private TextBox txtMontoAportesEconomicos;
        private Button btnGuardarAportesEconomicos;
        private Button btnVolverAportesEconomicos;
        private DataGridView dgvAportesEconomicos;
    }
}