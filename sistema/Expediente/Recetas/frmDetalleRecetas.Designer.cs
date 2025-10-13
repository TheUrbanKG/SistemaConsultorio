namespace sistema.Expediente.Recetas
{
    partial class frmDetalleRecetas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarArticulo = new FrameworkTest.SATAButton();
            this.cbCuadro = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flpArticulos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new FrameworkTest.SATAButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(26, 114);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(324, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(23, 187);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(584, 100);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Título";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(23, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAgregarArticulo);
            this.panel1.Location = new System.Drawing.Point(16, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 53);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(41, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Artículos";
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarArticulo.ButtonText = "Agregar";
            this.btnAgregarArticulo.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnAgregarArticulo.CheckedForeColor = System.Drawing.Color.White;
            this.btnAgregarArticulo.CheckedImageTint = System.Drawing.Color.White;
            this.btnAgregarArticulo.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAgregarArticulo.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregarArticulo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarArticulo.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(194)))), ((int)(((byte)(229)))));
            this.btnAgregarArticulo.HoverForeColor = System.Drawing.Color.White;
            this.btnAgregarArticulo.HoverImage = null;
            this.btnAgregarArticulo.HoverImageTint = System.Drawing.Color.White;
            this.btnAgregarArticulo.HoverOutline = System.Drawing.Color.Empty;
            this.btnAgregarArticulo.Image = null;
            this.btnAgregarArticulo.ImageAutoCenter = true;
            this.btnAgregarArticulo.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAgregarArticulo.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAgregarArticulo.ImageTint = System.Drawing.Color.White;
            this.btnAgregarArticulo.IsToggleButton = false;
            this.btnAgregarArticulo.IsToggled = false;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(650, 8);
            this.btnAgregarArticulo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnAgregarArticulo.NormalForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarArticulo.NormalOutline = System.Drawing.Color.Empty;
            this.btnAgregarArticulo.OutlineThickness = 2F;
            this.btnAgregarArticulo.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(209)))));
            this.btnAgregarArticulo.PressedForeColor = System.Drawing.Color.White;
            this.btnAgregarArticulo.PressedImageTint = System.Drawing.Color.White;
            this.btnAgregarArticulo.PressedOutline = System.Drawing.Color.Empty;
            this.btnAgregarArticulo.Rounding = new System.Windows.Forms.Padding(5);
            this.btnAgregarArticulo.Size = new System.Drawing.Size(121, 37);
            this.btnAgregarArticulo.TabIndex = 7;
            this.btnAgregarArticulo.TextAutoCenter = true;
            this.btnAgregarArticulo.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // cbCuadro
            // 
            this.cbCuadro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCuadro.FormattingEnabled = true;
            this.cbCuadro.Location = new System.Drawing.Point(448, 114);
            this.cbCuadro.Name = "cbCuadro";
            this.cbCuadro.Size = new System.Drawing.Size(264, 21);
            this.cbCuadro.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(445, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cuadro Clínico";
            // 
            // flpArticulos
            // 
            this.flpArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpArticulos.AutoScroll = true;
            this.flpArticulos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpArticulos.Location = new System.Drawing.Point(16, 385);
            this.flpArticulos.Name = "flpArticulos";
            this.flpArticulos.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.flpArticulos.Size = new System.Drawing.Size(809, 200);
            this.flpArticulos.TabIndex = 8;
            this.flpArticulos.WrapContents = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ButtonText = "";
            this.btnGuardar.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.CheckedForeColor = System.Drawing.Color.White;
            this.btnGuardar.CheckedImageTint = System.Drawing.Color.White;
            this.btnGuardar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnGuardar.HoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoverImage = null;
            this.btnGuardar.HoverImageTint = System.Drawing.Color.White;
            this.btnGuardar.HoverOutline = System.Drawing.Color.Empty;
            this.btnGuardar.Image = global::sistema.Properties.Resources.Guardar;
            this.btnGuardar.ImageAutoCenter = true;
            this.btnGuardar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGuardar.ImageOffset = new System.Drawing.Point(6, 0);
            this.btnGuardar.ImageTint = System.Drawing.Color.White;
            this.btnGuardar.IsToggleButton = false;
            this.btnGuardar.IsToggled = false;
            this.btnGuardar.Location = new System.Drawing.Point(727, 243);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnGuardar.NormalForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.NormalOutline = System.Drawing.Color.Empty;
            this.btnGuardar.OutlineThickness = 2F;
            this.btnGuardar.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.PressedForeColor = System.Drawing.Color.White;
            this.btnGuardar.PressedImageTint = System.Drawing.Color.White;
            this.btnGuardar.PressedOutline = System.Drawing.Color.Empty;
            this.btnGuardar.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGuardar.Size = new System.Drawing.Size(60, 44);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.TextAutoCenter = true;
            this.btnGuardar.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // frmDetalleRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(825, 586);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.flpArticulos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuadro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtTitulo);
            this.Name = "frmDetalleRecetas";
            this.Resizable = false;
            this.Text = "Plan Terapeutico";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCuadro;
        private System.Windows.Forms.Label label4;
        private FrameworkTest.SATAButton btnAgregarArticulo;
        private System.Windows.Forms.FlowLayoutPanel flpArticulos;
        private FrameworkTest.SATAButton btnGuardar;
    }
}