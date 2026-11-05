namespace ALBERGUE_HUELLITAS_FELICES
{
    partial class INISION_DE_SESION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INISION_DE_SESION));
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(497, 344);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(354, 31);
            txtUsuario.TabIndex = 0;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(497, 423);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(354, 31);
            txtContrasena.TabIndex = 1;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Transparent;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(424, 480);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(489, 53);
            btnIngresar.TabIndex = 2;
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // INISION_DE_SESION
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 758);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Name = "INISION_DE_SESION";
            Text = "INISION_DE_SESION";
            Load += INISION_DE_SESION_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnIngresar;
    }
}