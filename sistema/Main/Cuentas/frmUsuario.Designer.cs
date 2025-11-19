namespace sistema
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAñadirUsuario = new FrameworkTest.SATAButton();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.btnHuella = new FrameworkTest.SATAButton();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(444, 116);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(277, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(72, 116);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(72, 177);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(278, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Items.AddRange(new object[] {
            "",
            "Administrador",
            "Usuario"});
            this.cbRol.Location = new System.Drawing.Point(443, 177);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(121, 21);
            this.cbRol.TabIndex = 3;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "",
            "Habilitado",
            "Deshabilitado"});
            this.cbStatus.Location = new System.Drawing.Point(600, 176);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(72, 244);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(278, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(443, 244);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(278, 20);
            this.txtPassword2.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(72, 270);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Mostrar Contraseña";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(69, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(440, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirme la Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(69, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(69, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(441, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(440, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Rol";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(597, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Status";
            // 
            // btnAñadirUsuario
            // 
            this.btnAñadirUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAñadirUsuario.ButtonText = "Confirmar";
            this.btnAñadirUsuario.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnAñadirUsuario.CheckedForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.CheckedImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAñadirUsuario.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAñadirUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirUsuario.HoverBackground = System.Drawing.Color.DarkTurquoise;
            this.btnAñadirUsuario.HoverForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.HoverImage = null;
            this.btnAñadirUsuario.HoverImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.HoverOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnAñadirUsuario.Image")));
            this.btnAñadirUsuario.ImageAutoCenter = true;
            this.btnAñadirUsuario.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnAñadirUsuario.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAñadirUsuario.ImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.IsToggleButton = false;
            this.btnAñadirUsuario.IsToggled = false;
            this.btnAñadirUsuario.Location = new System.Drawing.Point(591, 310);
            this.btnAñadirUsuario.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAñadirUsuario.Name = "btnAñadirUsuario";
            this.btnAñadirUsuario.NormalBackground = System.Drawing.Color.DarkTurquoise;
            this.btnAñadirUsuario.NormalForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.NormalOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.OutlineThickness = 2F;
            this.btnAñadirUsuario.PressedBackground = System.Drawing.Color.DarkTurquoise;
            this.btnAñadirUsuario.PressedForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.PressedImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.PressedOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.Rounding = new System.Windows.Forms.Padding(10);
            this.btnAñadirUsuario.Size = new System.Drawing.Size(130, 47);
            this.btnAñadirUsuario.TabIndex = 43;
            this.btnAñadirUsuario.TextAutoCenter = true;
            this.btnAñadirUsuario.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // sataButton1
            // 
            this.sataButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sataButton1.ButtonText = "Cancelar";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.sataButton1.HoverForeColor = System.Drawing.Color.White;
            this.sataButton1.HoverImage = null;
            this.sataButton1.HoverImageTint = System.Drawing.Color.White;
            this.sataButton1.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton1.Image = ((System.Drawing.Image)(resources.GetObject("sataButton1.Image")));
            this.sataButton1.ImageAutoCenter = true;
            this.sataButton1.ImageExpand = new System.Drawing.Point(2, 2);
            this.sataButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.sataButton1.ImageTint = System.Drawing.Color.White;
            this.sataButton1.IsToggleButton = false;
            this.sataButton1.IsToggled = false;
            this.sataButton1.Location = new System.Drawing.Point(434, 310);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.Crimson;
            this.sataButton1.NormalForeColor = System.Drawing.Color.White;
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(10);
            this.sataButton1.Size = new System.Drawing.Size(130, 47);
            this.sataButton1.TabIndex = 44;
            this.sataButton1.TextAutoCenter = true;
            this.sataButton1.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnHuella
            // 
            this.btnHuella.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuella.ButtonText = "Añadir Huella";
            this.btnHuella.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnHuella.CheckedForeColor = System.Drawing.Color.White;
            this.btnHuella.CheckedImageTint = System.Drawing.Color.White;
            this.btnHuella.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnHuella.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHuella.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuella.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(149)))), ((int)(((byte)(83)))));
            this.btnHuella.HoverForeColor = System.Drawing.Color.White;
            this.btnHuella.HoverImage = null;
            this.btnHuella.HoverImageTint = System.Drawing.Color.White;
            this.btnHuella.HoverOutline = System.Drawing.Color.Empty;
            this.btnHuella.Image = global::sistema.Properties.Resources.huella_vacia;
            this.btnHuella.ImageAutoCenter = true;
            this.btnHuella.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnHuella.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHuella.ImageTint = System.Drawing.Color.White;
            this.btnHuella.IsToggleButton = false;
            this.btnHuella.IsToggled = false;
            this.btnHuella.Location = new System.Drawing.Point(72, 310);
            this.btnHuella.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnHuella.Name = "btnHuella";
            this.btnHuella.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(129)))), ((int)(((byte)(63)))));
            this.btnHuella.NormalForeColor = System.Drawing.Color.White;
            this.btnHuella.NormalOutline = System.Drawing.Color.Empty;
            this.btnHuella.OutlineThickness = 2F;
            this.btnHuella.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btnHuella.PressedForeColor = System.Drawing.Color.White;
            this.btnHuella.PressedImageTint = System.Drawing.Color.White;
            this.btnHuella.PressedOutline = System.Drawing.Color.Empty;
            this.btnHuella.Rounding = new System.Windows.Forms.Padding(10);
            this.btnHuella.Size = new System.Drawing.Size(170, 47);
            this.btnHuella.TabIndex = 45;
            this.btnHuella.TextAutoCenter = true;
            this.btnHuella.TextOffset = new System.Drawing.Point(0, 0);
            this.btnHuella.Click += new System.EventHandler(this.btnHuella_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 389);
            this.Controls.Add(this.btnHuella);
            this.Controls.Add(this.sataButton1);
            this.Controls.Add(this.btnAñadirUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtUsuario);
            this.Name = "frmUsuario";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Gestión de Usuario";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private FrameworkTest.SATAButton btnAñadirUsuario;
        private FrameworkTest.SATAButton sataButton1;
        private FrameworkTest.SATAButton btnHuella;
    }
}