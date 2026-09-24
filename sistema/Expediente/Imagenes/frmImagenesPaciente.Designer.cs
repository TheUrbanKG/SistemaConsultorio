namespace sistema.Expediente.Imagenes
{
    partial class frmImagenesPaciente
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
            this.panelHeaderBorder = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTotalImagenes = new System.Windows.Forms.Label();
            this.cbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnNuevaImagen = new FrameworkTest.SATAButton();
            this.flpImagenes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSinImagenes = new System.Windows.Forms.Label();
            this.pbSinImagenes = new System.Windows.Forms.PictureBox();
            this.panelHeaderBorder.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSinImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderBorder
            // 
            this.panelHeaderBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelHeaderBorder.Controls.Add(this.panelHeader);
            this.panelHeaderBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderBorder.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderBorder.Name = "panelHeaderBorder";
            this.panelHeaderBorder.Size = new System.Drawing.Size(1180, 87);
            this.panelHeaderBorder.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTotalImagenes);
            this.panelHeader.Controls.Add(this.cbFiltroCategoria);
            this.panelHeader.Controls.Add(this.lblFiltro);
            this.panelHeader.Controls.Add(this.btnNuevaImagen);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1180, 84);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTotalImagenes
            // 
            this.lblTotalImagenes.AutoSize = true;
            this.lblTotalImagenes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImagenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalImagenes.Location = new System.Drawing.Point(400, 34);
            this.lblTotalImagenes.Name = "lblTotalImagenes";
            this.lblTotalImagenes.Size = new System.Drawing.Size(130, 17);
            this.lblTotalImagenes.TabIndex = 3;
            this.lblTotalImagenes.Text = "Total: 0 imágenes";
            // 
            // cbFiltroCategoria
            // 
            this.cbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroCategoria.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroCategoria.FormattingEnabled = true;
            this.cbFiltroCategoria.Items.AddRange(new object[] {
            "Todas las categorías",
            "Evolución",
            "Rayos X",
            "Ecografía",
            "Laboratorio",
            "Otro"});
            this.cbFiltroCategoria.Location = new System.Drawing.Point(190, 30);
            this.cbFiltroCategoria.Name = "cbFiltroCategoria";
            this.cbFiltroCategoria.Size = new System.Drawing.Size(190, 25);
            this.cbFiltroCategoria.TabIndex = 2;
            this.cbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cbFiltroCategoria_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFiltro.Location = new System.Drawing.Point(26, 34);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(158, 16);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Filtrar por Categoría:";
            // 
            // btnNuevaImagen
            // 
            this.btnNuevaImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaImagen.ButtonText = "Subir Imagen";
            this.btnNuevaImagen.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnNuevaImagen.CheckedForeColor = System.Drawing.Color.White;
            this.btnNuevaImagen.CheckedImageTint = System.Drawing.Color.White;
            this.btnNuevaImagen.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnNuevaImagen.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNuevaImagen.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaImagen.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(74)))));
            this.btnNuevaImagen.HoverForeColor = System.Drawing.Color.White;
            this.btnNuevaImagen.HoverImage = null;
            this.btnNuevaImagen.HoverImageTint = System.Drawing.Color.White;
            this.btnNuevaImagen.HoverOutline = System.Drawing.Color.Empty;
            this.btnNuevaImagen.Image = global::sistema.Properties.Resources.Guardar;
            this.btnNuevaImagen.ImageAutoCenter = true;
            this.btnNuevaImagen.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnNuevaImagen.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNuevaImagen.ImageTint = System.Drawing.Color.White;
            this.btnNuevaImagen.IsToggleButton = false;
            this.btnNuevaImagen.IsToggled = false;
            this.btnNuevaImagen.Location = new System.Drawing.Point(1015, 23);
            this.btnNuevaImagen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNuevaImagen.Name = "btnNuevaImagen";
            this.btnNuevaImagen.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnNuevaImagen.NormalForeColor = System.Drawing.Color.White;
            this.btnNuevaImagen.NormalOutline = System.Drawing.Color.Empty;
            this.btnNuevaImagen.OutlineThickness = 2F;
            this.btnNuevaImagen.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.btnNuevaImagen.PressedForeColor = System.Drawing.Color.White;
            this.btnNuevaImagen.PressedImageTint = System.Drawing.Color.White;
            this.btnNuevaImagen.PressedOutline = System.Drawing.Color.Empty;
            this.btnNuevaImagen.Rounding = new System.Windows.Forms.Padding(6);
            this.btnNuevaImagen.Size = new System.Drawing.Size(140, 38);
            this.btnNuevaImagen.TabIndex = 0;
            this.btnNuevaImagen.TextAutoCenter = true;
            this.btnNuevaImagen.TextOffset = new System.Drawing.Point(0, 0);
            this.btnNuevaImagen.Click += new System.EventHandler(this.btnNuevaImagen_Click);
            // 
            // flpImagenes
            // 
            this.flpImagenes.AutoScroll = true;
            this.flpImagenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.flpImagenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpImagenes.Location = new System.Drawing.Point(0, 87);
            this.flpImagenes.Name = "flpImagenes";
            this.flpImagenes.Padding = new System.Windows.Forms.Padding(15);
            this.flpImagenes.Size = new System.Drawing.Size(1180, 426);
            this.flpImagenes.TabIndex = 1;
            // 
            // lblSinImagenes
            // 
            this.lblSinImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSinImagenes.AutoSize = true;
            this.lblSinImagenes.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinImagenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSinImagenes.Location = new System.Drawing.Point(400, 380);
            this.lblSinImagenes.Name = "lblSinImagenes";
            this.lblSinImagenes.Size = new System.Drawing.Size(380, 28);
            this.lblSinImagenes.TabIndex = 2;
            this.lblSinImagenes.Text = "No hay imágenes registradas";
            this.lblSinImagenes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSinImagenes
            // 
            this.pbSinImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSinImagenes.Image = global::sistema.Properties.Resources.Guardar;
            this.pbSinImagenes.Location = new System.Drawing.Point(490, 150);
            this.pbSinImagenes.Name = "pbSinImagenes";
            this.pbSinImagenes.Size = new System.Drawing.Size(200, 200);
            this.pbSinImagenes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSinImagenes.TabIndex = 3;
            this.pbSinImagenes.TabStop = false;
            // 
            // frmImagenesPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1180, 513);
            this.Controls.Add(this.lblSinImagenes);
            this.Controls.Add(this.pbSinImagenes);
            this.Controls.Add(this.flpImagenes);
            this.Controls.Add(this.panelHeaderBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImagenesPaciente";
            this.Text = "frmImagenesPaciente";
            this.Load += new System.EventHandler(this.frmImagenesPaciente_Load);
            this.panelHeaderBorder.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSinImagenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderBorder;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cbFiltroCategoria;
        private System.Windows.Forms.Label lblTotalImagenes;
        private FrameworkTest.SATAButton btnNuevaImagen;
        private System.Windows.Forms.FlowLayoutPanel flpImagenes;
        private System.Windows.Forms.Label lblSinImagenes;
        private System.Windows.Forms.PictureBox pbSinImagenes;
    }
}
