namespace sistema.Expediente.Cuadros
{
    partial class frmDetalleCuadros
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtImpresiones = new System.Windows.Forms.TextBox();
            this.dtInicio = new MetroFramework.Controls.MetroDateTime();
            this.dtFin = new MetroFramework.Controls.MetroDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new FrameworkTest.SATAButton();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(50, 105);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(324, 21);
            this.txtNombre.TabIndex = 0;
            // 
            // txtImpresiones
            // 
            this.txtImpresiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpresiones.Location = new System.Drawing.Point(50, 161);
            this.txtImpresiones.Multiline = true;
            this.txtImpresiones.Name = "txtImpresiones";
            this.txtImpresiones.Size = new System.Drawing.Size(471, 128);
            this.txtImpresiones.TabIndex = 1;
            // 
            // dtInicio
            // 
            this.dtInicio.Location = new System.Drawing.Point(50, 342);
            this.dtInicio.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 29);
            this.dtInicio.TabIndex = 2;
            // 
            // dtFin
            // 
            this.dtFin.Location = new System.Drawing.Point(438, 342);
            this.dtFin.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(200, 29);
            this.dtFin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(47, 86);
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
            this.label2.Location = new System.Drawing.Point(47, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Primeras Impresiones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(50, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(439, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Fin";
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
            this.btnGuardar.Location = new System.Drawing.Point(50, 405);
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
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.TextAutoCenter = true;
            this.btnGuardar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmDetalleCuadros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 497);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.txtImpresiones);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmDetalleCuadros";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Detalles del Cuadro Clinico";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtImpresiones;
        private MetroFramework.Controls.MetroDateTime dtInicio;
        private MetroFramework.Controls.MetroDateTime dtFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FrameworkTest.SATAButton btnGuardar;
    }
}