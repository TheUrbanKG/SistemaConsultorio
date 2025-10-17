namespace sistema
{
    partial class frmDetallePaciente2
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
            this.cbCivil = new System.Windows.Forms.ComboBox();
            this.cbEscolaridad = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.btnRegresar = new FrameworkTest.SATAButton();
            this.btnRegistro = new FrameworkTest.SATAButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbCivil
            // 
            this.cbCivil.FormattingEnabled = true;
            this.cbCivil.Items.AddRange(new object[] {
            "",
            "Soltero/a",
            "Casado/a",
            "Viudo/a"});
            this.cbCivil.Location = new System.Drawing.Point(124, 103);
            this.cbCivil.Name = "cbCivil";
            this.cbCivil.Size = new System.Drawing.Size(171, 21);
            this.cbCivil.TabIndex = 0;
            // 
            // cbEscolaridad
            // 
            this.cbEscolaridad.FormattingEnabled = true;
            this.cbEscolaridad.Items.AddRange(new object[] {
            "",
            "Educación Basica",
            "Bachiller",
            "Universitario"});
            this.cbEscolaridad.Location = new System.Drawing.Point(124, 174);
            this.cbEscolaridad.Name = "cbEscolaridad";
            this.cbEscolaridad.Size = new System.Drawing.Size(171, 21);
            this.cbEscolaridad.TabIndex = 1;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(124, 239);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(171, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(449, 104);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(173, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Location = new System.Drawing.Point(449, 175);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(173, 20);
            this.txtOcupacion.TabIndex = 4;
            // 
            // btnRegresar
            // 
            this.btnRegresar.ButtonText = "Regresar";
            this.btnRegresar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnRegresar.CheckedForeColor = System.Drawing.Color.Black;
            this.btnRegresar.CheckedImageTint = System.Drawing.Color.White;
            this.btnRegresar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnRegresar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegresar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(89)))));
            this.btnRegresar.HoverForeColor = System.Drawing.Color.Black;
            this.btnRegresar.HoverImage = null;
            this.btnRegresar.HoverImageTint = System.Drawing.Color.White;
            this.btnRegresar.HoverOutline = System.Drawing.Color.Empty;
            this.btnRegresar.Image = null;
            this.btnRegresar.ImageAutoCenter = true;
            this.btnRegresar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRegresar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRegresar.ImageTint = System.Drawing.Color.White;
            this.btnRegresar.IsToggleButton = false;
            this.btnRegresar.IsToggled = false;
            this.btnRegresar.Location = new System.Drawing.Point(140, 305);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            this.btnRegresar.NormalForeColor = System.Drawing.Color.Black;
            this.btnRegresar.NormalOutline = System.Drawing.Color.Empty;
            this.btnRegresar.OutlineThickness = 2F;
            this.btnRegresar.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnRegresar.PressedForeColor = System.Drawing.Color.White;
            this.btnRegresar.PressedImageTint = System.Drawing.Color.White;
            this.btnRegresar.PressedOutline = System.Drawing.Color.Empty;
            this.btnRegresar.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRegresar.Size = new System.Drawing.Size(190, 50);
            this.btnRegresar.TabIndex = 5;
            this.btnRegresar.TextAutoCenter = true;
            this.btnRegresar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.ButtonText = "Completar Registro";
            this.btnRegistro.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnRegistro.CheckedForeColor = System.Drawing.Color.Black;
            this.btnRegistro.CheckedImageTint = System.Drawing.Color.White;
            this.btnRegistro.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnRegistro.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegistro.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(89)))));
            this.btnRegistro.HoverForeColor = System.Drawing.Color.Black;
            this.btnRegistro.HoverImage = null;
            this.btnRegistro.HoverImageTint = System.Drawing.Color.White;
            this.btnRegistro.HoverOutline = System.Drawing.Color.Empty;
            this.btnRegistro.Image = null;
            this.btnRegistro.ImageAutoCenter = true;
            this.btnRegistro.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRegistro.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRegistro.ImageTint = System.Drawing.Color.White;
            this.btnRegistro.IsToggleButton = false;
            this.btnRegistro.IsToggled = false;
            this.btnRegistro.Location = new System.Drawing.Point(356, 305);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            this.btnRegistro.NormalForeColor = System.Drawing.Color.Black;
            this.btnRegistro.NormalOutline = System.Drawing.Color.Empty;
            this.btnRegistro.OutlineThickness = 2F;
            this.btnRegistro.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnRegistro.PressedForeColor = System.Drawing.Color.White;
            this.btnRegistro.PressedImageTint = System.Drawing.Color.White;
            this.btnRegistro.PressedOutline = System.Drawing.Color.Empty;
            this.btnRegistro.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRegistro.Size = new System.Drawing.Size(190, 50);
            this.btnRegistro.TabIndex = 6;
            this.btnRegistro.TextAutoCenter = true;
            this.btnRegistro.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(37, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estado Civil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(37, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Escolaridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(37, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(372, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(356, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ocupacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(321, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Grupo Sanguineo";
            // 
            // cbGrupoSanguineo
            // 
            this.cbGrupoSanguineo.FormattingEnabled = true;
            this.cbGrupoSanguineo.Items.AddRange(new object[] {
            "",
            "O+",
            "A+",
            "B+",
            "AB+",
            "O-",
            "A-",
            "B-",
            "AB-"});
            this.cbGrupoSanguineo.Location = new System.Drawing.Point(449, 232);
            this.cbGrupoSanguineo.Name = "cbGrupoSanguineo";
            this.cbGrupoSanguineo.Size = new System.Drawing.Size(171, 21);
            this.cbGrupoSanguineo.TabIndex = 14;
            // 
            // frmDetallePaciente2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 378);
            this.Controls.Add(this.cbGrupoSanguineo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.txtOcupacion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cbEscolaridad);
            this.Controls.Add(this.cbCivil);
            this.Name = "frmDetallePaciente2";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Agregar Paciente";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCivil;
        private System.Windows.Forms.ComboBox cbEscolaridad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtOcupacion;
        private FrameworkTest.SATAButton btnRegresar;
        private FrameworkTest.SATAButton btnRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGrupoSanguineo;
    }
}