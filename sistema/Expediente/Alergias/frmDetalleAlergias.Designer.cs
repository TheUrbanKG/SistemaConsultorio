namespace sistema.Expediente.Alergias
{
    partial class frmDetalleAlergias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleAlergias));
            this.cbSeveridad = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.btnGuardar = new FrameworkTest.SATAButton();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSeveridad
            // 
            this.cbSeveridad.FormattingEnabled = true;
            this.cbSeveridad.Items.AddRange(new object[] {
            "",
            "Ligera",
            "Moderada",
            "Severa",
            "Desconocida"});
            this.cbSeveridad.Location = new System.Drawing.Point(39, 248);
            this.cbSeveridad.Name = "cbSeveridad";
            this.cbSeveridad.Size = new System.Drawing.Size(194, 21);
            this.cbSeveridad.TabIndex = 1;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "",
            "Confirmada",
            "Confirmada pero Inactiva",
            "En Duda",
            "Pendiente",
            "Sin Confirmar"});
            this.cbEstado.Location = new System.Drawing.Point(39, 314);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(178, 21);
            this.cbEstado.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(397, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(36, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(36, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nivel de Alergía";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(37, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado Clínico";
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.CustomButton.Image = null;
            this.txtNombre.CustomButton.Location = new System.Drawing.Point(238, 1);
            this.txtNombre.CustomButton.Name = "";
            this.txtNombre.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombre.CustomButton.TabIndex = 1;
            this.txtNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombre.CustomButton.UseSelectable = true;
            this.txtNombre.CustomButton.Visible = false;
            this.txtNombre.Lines = new string[0];
            this.txtNombre.Location = new System.Drawing.Point(39, 116);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.PromptText = "Indica Agente Alergeno";
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(260, 23);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.UseSelectable = true;
            this.txtNombre.WaterMark = "Indica Agente Alergeno";
            this.txtNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonText = "Guardar Cambios";
            this.btnGuardar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnGuardar.CheckedForeColor = System.Drawing.Color.White;
            this.btnGuardar.CheckedImageTint = System.Drawing.Color.White;
            this.btnGuardar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(79)))));
            this.btnGuardar.HoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverImage = null;
            this.btnGuardar.HoverImageTint = System.Drawing.Color.White;
            this.btnGuardar.HoverOutline = System.Drawing.Color.Empty;
            this.btnGuardar.Image = global::sistema.Properties.Resources.Guardar;
            this.btnGuardar.ImageAutoCenter = true;
            this.btnGuardar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGuardar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnGuardar.ImageTint = System.Drawing.Color.White;
            this.btnGuardar.IsToggleButton = false;
            this.btnGuardar.IsToggled = false;
            this.btnGuardar.Location = new System.Drawing.Point(39, 363);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnGuardar.NormalForeColor = System.Drawing.Color.White;
            this.btnGuardar.NormalOutline = System.Drawing.Color.Empty;
            this.btnGuardar.OutlineThickness = 2F;
            this.btnGuardar.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.PressedForeColor = System.Drawing.Color.White;
            this.btnGuardar.PressedImageTint = System.Drawing.Color.White;
            this.btnGuardar.PressedOutline = System.Drawing.Color.Empty;
            this.btnGuardar.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Size = new System.Drawing.Size(177, 48);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.TextAutoCenter = true;
            this.btnGuardar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "",
            "Sustancia",
            "Comida",
            "Farmaco",
            "Animal",
            "Ambiente",
            "Planta"});
            this.cbTipo.Location = new System.Drawing.Point(39, 184);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(178, 21);
            this.cbTipo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(36, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo";
            // 
            // frmDetalleAlergias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 434);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.cbSeveridad);
            this.Name = "frmDetalleAlergias";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Detalles de la Alergia";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.frmDetalleAlergias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbSeveridad;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private FrameworkTest.SATAButton btnGuardar;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label5;
    }
}