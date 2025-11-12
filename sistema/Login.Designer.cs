namespace sistema
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnIngresar = new FrameworkTest.SATAButton();
            this.btnHuella = new FrameworkTest.SATAButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(297, 97);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(188, 23);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(293, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese el Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(293, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese la Contraseña";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(297, 188);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(188, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnIngresar
            // 
            this.btnIngresar.ButtonText = "Ingresar";
            this.btnIngresar.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnIngresar.CheckedForeColor = System.Drawing.Color.White;
            this.btnIngresar.CheckedImageTint = System.Drawing.Color.White;
            this.btnIngresar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnIngresar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(157)))), ((int)(((byte)(89)))));
            this.btnIngresar.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIngresar.HoverImage = null;
            this.btnIngresar.HoverImageTint = System.Drawing.Color.White;
            this.btnIngresar.HoverOutline = System.Drawing.Color.Empty;
            this.btnIngresar.Image = null;
            this.btnIngresar.ImageAutoCenter = true;
            this.btnIngresar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnIngresar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnIngresar.ImageTint = System.Drawing.Color.White;
            this.btnIngresar.IsToggleButton = false;
            this.btnIngresar.IsToggled = false;
            this.btnIngresar.Location = new System.Drawing.Point(297, 238);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnIngresar.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnIngresar.NormalOutline = System.Drawing.Color.Empty;
            this.btnIngresar.OutlineThickness = 2F;
            this.btnIngresar.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(69)))));
            this.btnIngresar.PressedForeColor = System.Drawing.Color.White;
            this.btnIngresar.PressedImageTint = System.Drawing.Color.White;
            this.btnIngresar.PressedOutline = System.Drawing.Color.Empty;
            this.btnIngresar.Rounding = new System.Windows.Forms.Padding(5);
            this.btnIngresar.Size = new System.Drawing.Size(120, 37);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.TextAutoCenter = true;
            this.btnIngresar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnHuella
            // 
            this.btnHuella.ButtonText = "";
            this.btnHuella.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(129)))), ((int)(((byte)(63)))));
            this.btnHuella.CheckedForeColor = System.Drawing.Color.White;
            this.btnHuella.CheckedImageTint = System.Drawing.Color.White;
            this.btnHuella.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(129)))), ((int)(((byte)(63)))));
            this.btnHuella.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHuella.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuella.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(139)))), ((int)(((byte)(73)))));
            this.btnHuella.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHuella.HoverImage = null;
            this.btnHuella.HoverImageTint = System.Drawing.Color.White;
            this.btnHuella.HoverOutline = System.Drawing.Color.Empty;
            this.btnHuella.Image = global::sistema.Properties.Resources.huella_login;
            this.btnHuella.ImageAutoCenter = true;
            this.btnHuella.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnHuella.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnHuella.ImageTint = System.Drawing.Color.White;
            this.btnHuella.IsToggleButton = false;
            this.btnHuella.IsToggled = false;
            this.btnHuella.Location = new System.Drawing.Point(444, 238);
            this.btnHuella.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHuella.Name = "btnHuella";
            this.btnHuella.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(129)))), ((int)(((byte)(63)))));
            this.btnHuella.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnHuella.NormalOutline = System.Drawing.Color.Empty;
            this.btnHuella.OutlineThickness = 2F;
            this.btnHuella.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.btnHuella.PressedForeColor = System.Drawing.Color.White;
            this.btnHuella.PressedImageTint = System.Drawing.Color.White;
            this.btnHuella.PressedOutline = System.Drawing.Color.Empty;
            this.btnHuella.Rounding = new System.Windows.Forms.Padding(5);
            this.btnHuella.Size = new System.Drawing.Size(75, 37);
            this.btnHuella.TabIndex = 6;
            this.btnHuella.TextAutoCenter = true;
            this.btnHuella.TextOffset = new System.Drawing.Point(0, 0);
            this.btnHuella.Click += new System.EventHandler(this.btnHuella_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 315);
            this.Controls.Add(this.btnHuella);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "¡Bienvenido al Sistema!";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private FrameworkTest.SATAButton btnIngresar;
        private FrameworkTest.SATAButton btnHuella;
    }
}