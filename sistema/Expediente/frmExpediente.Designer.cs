namespace sistema.Expediente
{
    partial class frmExpediente
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpediente));
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnPDF = new FrameworkTest.SATAButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnRecetas = new FrameworkTest.SATAButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAlergias = new FrameworkTest.SATAButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCuadros = new FrameworkTest.SATAButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnFisico = new FrameworkTest.SATAButton();
            this.lbCedulayGenero = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHistoria = new FrameworkTest.SATAButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRegistro = new FrameworkTest.SATAButton();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnCerrar = new FrameworkTest.SATAButton();
            this.btnMinimizar = new FrameworkTest.SATAButton();
            this.panel1.SuspendLayout();
            this.sataPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 20;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel1.Controls.Add(this.sataPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 160);
            this.panel1.TabIndex = 0;
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.sataPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.btnMinimizar);
            this.sataPanel1.Controls.Add(this.btnCerrar);
            this.sataPanel1.Controls.Add(this.panel8);
            this.sataPanel1.Controls.Add(this.panel7);
            this.sataPanel1.Controls.Add(this.panel5);
            this.sataPanel1.Controls.Add(this.panel4);
            this.sataPanel1.Controls.Add(this.panel6);
            this.sataPanel1.Controls.Add(this.lbCedulayGenero);
            this.sataPanel1.Controls.Add(this.lbNombre);
            this.sataPanel1.Controls.Add(this.panel3);
            this.sataPanel1.Controls.Add(this.panel2);
            this.sataPanel1.Location = new System.Drawing.Point(3, 3);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(1191, 150);
            this.sataPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel8.Controls.Add(this.btnPDF);
            this.panel8.Location = new System.Drawing.Point(1116, 93);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(75, 57);
            this.panel8.TabIndex = 4;
            // 
            // btnPDF
            // 
            this.btnPDF.ButtonText = "";
            this.btnPDF.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnPDF.CheckedForeColor = System.Drawing.Color.White;
            this.btnPDF.CheckedImageTint = System.Drawing.Color.White;
            this.btnPDF.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnPDF.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPDF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnPDF.HoverForeColor = System.Drawing.Color.White;
            this.btnPDF.HoverImage = null;
            this.btnPDF.HoverImageTint = System.Drawing.Color.White;
            this.btnPDF.HoverOutline = System.Drawing.Color.Empty;
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.ImageAutoCenter = true;
            this.btnPDF.ImageExpand = new System.Drawing.Point(7, 7);
            this.btnPDF.ImageOffset = new System.Drawing.Point(6, 0);
            this.btnPDF.ImageTint = System.Drawing.Color.White;
            this.btnPDF.IsToggleButton = false;
            this.btnPDF.IsToggled = false;
            this.btnPDF.Location = new System.Drawing.Point(3, 3);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnPDF.NormalForeColor = System.Drawing.Color.White;
            this.btnPDF.NormalOutline = System.Drawing.Color.Empty;
            this.btnPDF.OutlineThickness = 2F;
            this.btnPDF.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnPDF.PressedForeColor = System.Drawing.Color.White;
            this.btnPDF.PressedImageTint = System.Drawing.Color.White;
            this.btnPDF.PressedOutline = System.Drawing.Color.Empty;
            this.btnPDF.Rounding = new System.Windows.Forms.Padding(5);
            this.btnPDF.Size = new System.Drawing.Size(69, 51);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.TextAutoCenter = true;
            this.btnPDF.TextOffset = new System.Drawing.Point(0, 0);
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel7.Controls.Add(this.btnRecetas);
            this.panel7.Location = new System.Drawing.Point(837, 100);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3);
            this.panel7.Size = new System.Drawing.Size(167, 57);
            this.panel7.TabIndex = 3;
            // 
            // btnRecetas
            // 
            this.btnRecetas.ButtonText = "Recetas";
            this.btnRecetas.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnRecetas.CheckedForeColor = System.Drawing.Color.White;
            this.btnRecetas.CheckedImageTint = System.Drawing.Color.White;
            this.btnRecetas.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnRecetas.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecetas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecetas.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnRecetas.HoverForeColor = System.Drawing.Color.White;
            this.btnRecetas.HoverImage = null;
            this.btnRecetas.HoverImageTint = System.Drawing.Color.White;
            this.btnRecetas.HoverOutline = System.Drawing.Color.Empty;
            this.btnRecetas.Image = null;
            this.btnRecetas.ImageAutoCenter = true;
            this.btnRecetas.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRecetas.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRecetas.ImageTint = System.Drawing.Color.White;
            this.btnRecetas.IsToggleButton = false;
            this.btnRecetas.IsToggled = false;
            this.btnRecetas.Location = new System.Drawing.Point(3, 3);
            this.btnRecetas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRecetas.Name = "btnRecetas";
            this.btnRecetas.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnRecetas.NormalForeColor = System.Drawing.Color.White;
            this.btnRecetas.NormalOutline = System.Drawing.Color.Empty;
            this.btnRecetas.OutlineThickness = 2F;
            this.btnRecetas.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnRecetas.PressedForeColor = System.Drawing.Color.White;
            this.btnRecetas.PressedImageTint = System.Drawing.Color.White;
            this.btnRecetas.PressedOutline = System.Drawing.Color.Empty;
            this.btnRecetas.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRecetas.Size = new System.Drawing.Size(161, 51);
            this.btnRecetas.TabIndex = 0;
            this.btnRecetas.TextAutoCenter = true;
            this.btnRecetas.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRecetas.Click += new System.EventHandler(this.btnRecetas_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel5.Controls.Add(this.btnAlergias);
            this.panel5.Location = new System.Drawing.Point(669, 100);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(167, 57);
            this.panel5.TabIndex = 1;
            // 
            // btnAlergias
            // 
            this.btnAlergias.ButtonText = "Alergias";
            this.btnAlergias.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnAlergias.CheckedForeColor = System.Drawing.Color.White;
            this.btnAlergias.CheckedImageTint = System.Drawing.Color.White;
            this.btnAlergias.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAlergias.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAlergias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlergias.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlergias.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnAlergias.HoverForeColor = System.Drawing.Color.White;
            this.btnAlergias.HoverImage = null;
            this.btnAlergias.HoverImageTint = System.Drawing.Color.White;
            this.btnAlergias.HoverOutline = System.Drawing.Color.Empty;
            this.btnAlergias.Image = null;
            this.btnAlergias.ImageAutoCenter = true;
            this.btnAlergias.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAlergias.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAlergias.ImageTint = System.Drawing.Color.White;
            this.btnAlergias.IsToggleButton = false;
            this.btnAlergias.IsToggled = false;
            this.btnAlergias.Location = new System.Drawing.Point(3, 3);
            this.btnAlergias.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAlergias.Name = "btnAlergias";
            this.btnAlergias.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnAlergias.NormalForeColor = System.Drawing.Color.White;
            this.btnAlergias.NormalOutline = System.Drawing.Color.Empty;
            this.btnAlergias.OutlineThickness = 2F;
            this.btnAlergias.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnAlergias.PressedForeColor = System.Drawing.Color.White;
            this.btnAlergias.PressedImageTint = System.Drawing.Color.White;
            this.btnAlergias.PressedOutline = System.Drawing.Color.Empty;
            this.btnAlergias.Rounding = new System.Windows.Forms.Padding(5);
            this.btnAlergias.Size = new System.Drawing.Size(161, 51);
            this.btnAlergias.TabIndex = 0;
            this.btnAlergias.TextAutoCenter = true;
            this.btnAlergias.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAlergias.Click += new System.EventHandler(this.btnAlergias_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel4.Controls.Add(this.btnCuadros);
            this.panel4.Location = new System.Drawing.Point(503, 100);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(167, 57);
            this.panel4.TabIndex = 2;
            // 
            // btnCuadros
            // 
            this.btnCuadros.ButtonText = "Cuadros";
            this.btnCuadros.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCuadros.CheckedForeColor = System.Drawing.Color.White;
            this.btnCuadros.CheckedImageTint = System.Drawing.Color.White;
            this.btnCuadros.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCuadros.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCuadros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCuadros.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuadros.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnCuadros.HoverForeColor = System.Drawing.Color.White;
            this.btnCuadros.HoverImage = null;
            this.btnCuadros.HoverImageTint = System.Drawing.Color.White;
            this.btnCuadros.HoverOutline = System.Drawing.Color.Empty;
            this.btnCuadros.Image = null;
            this.btnCuadros.ImageAutoCenter = true;
            this.btnCuadros.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCuadros.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCuadros.ImageTint = System.Drawing.Color.White;
            this.btnCuadros.IsToggleButton = false;
            this.btnCuadros.IsToggled = false;
            this.btnCuadros.Location = new System.Drawing.Point(3, 3);
            this.btnCuadros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCuadros.Name = "btnCuadros";
            this.btnCuadros.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCuadros.NormalForeColor = System.Drawing.Color.White;
            this.btnCuadros.NormalOutline = System.Drawing.Color.Empty;
            this.btnCuadros.OutlineThickness = 2F;
            this.btnCuadros.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnCuadros.PressedForeColor = System.Drawing.Color.White;
            this.btnCuadros.PressedImageTint = System.Drawing.Color.White;
            this.btnCuadros.PressedOutline = System.Drawing.Color.Empty;
            this.btnCuadros.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCuadros.Size = new System.Drawing.Size(161, 51);
            this.btnCuadros.TabIndex = 0;
            this.btnCuadros.TextAutoCenter = true;
            this.btnCuadros.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCuadros.Click += new System.EventHandler(this.btnCuadros_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel6.Controls.Add(this.btnFisico);
            this.panel6.Location = new System.Drawing.Point(335, 100);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(167, 57);
            this.panel6.TabIndex = 2;
            // 
            // btnFisico
            // 
            this.btnFisico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnFisico.ButtonText = "Diagnostico Fisico";
            this.btnFisico.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnFisico.CheckedForeColor = System.Drawing.Color.White;
            this.btnFisico.CheckedImageTint = System.Drawing.Color.White;
            this.btnFisico.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnFisico.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFisico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFisico.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFisico.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnFisico.HoverForeColor = System.Drawing.Color.White;
            this.btnFisico.HoverImage = null;
            this.btnFisico.HoverImageTint = System.Drawing.Color.White;
            this.btnFisico.HoverOutline = System.Drawing.Color.Empty;
            this.btnFisico.Image = null;
            this.btnFisico.ImageAutoCenter = true;
            this.btnFisico.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnFisico.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnFisico.ImageTint = System.Drawing.Color.White;
            this.btnFisico.IsToggleButton = false;
            this.btnFisico.IsToggled = false;
            this.btnFisico.Location = new System.Drawing.Point(3, 3);
            this.btnFisico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFisico.Name = "btnFisico";
            this.btnFisico.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnFisico.NormalForeColor = System.Drawing.Color.White;
            this.btnFisico.NormalOutline = System.Drawing.Color.Empty;
            this.btnFisico.OutlineThickness = 2F;
            this.btnFisico.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnFisico.PressedForeColor = System.Drawing.Color.White;
            this.btnFisico.PressedImageTint = System.Drawing.Color.White;
            this.btnFisico.PressedOutline = System.Drawing.Color.Empty;
            this.btnFisico.Rounding = new System.Windows.Forms.Padding(5);
            this.btnFisico.Size = new System.Drawing.Size(161, 51);
            this.btnFisico.TabIndex = 0;
            this.btnFisico.TextAutoCenter = true;
            this.btnFisico.TextOffset = new System.Drawing.Point(0, 0);
            this.btnFisico.Click += new System.EventHandler(this.btnFisico_Click);
            // 
            // lbCedulayGenero
            // 
            this.lbCedulayGenero.AutoSize = true;
            this.lbCedulayGenero.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCedulayGenero.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCedulayGenero.Location = new System.Drawing.Point(68, 64);
            this.lbCedulayGenero.Name = "lbCedulayGenero";
            this.lbCedulayGenero.Size = new System.Drawing.Size(137, 20);
            this.lbCedulayGenero.TabIndex = 4;
            this.lbCedulayGenero.Text = "Cedula + Genero";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbNombre.Location = new System.Drawing.Point(66, 29);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(118, 25);
            this.lbNombre.TabIndex = 3;
            this.lbNombre.Text = "UserName";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel3.Controls.Add(this.btnHistoria);
            this.panel3.Location = new System.Drawing.Point(168, 100);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(167, 57);
            this.panel3.TabIndex = 1;
            // 
            // btnHistoria
            // 
            this.btnHistoria.ButtonText = "Historia";
            this.btnHistoria.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnHistoria.CheckedForeColor = System.Drawing.Color.White;
            this.btnHistoria.CheckedImageTint = System.Drawing.Color.White;
            this.btnHistoria.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnHistoria.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHistoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistoria.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoria.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnHistoria.HoverForeColor = System.Drawing.Color.White;
            this.btnHistoria.HoverImage = null;
            this.btnHistoria.HoverImageTint = System.Drawing.Color.White;
            this.btnHistoria.HoverOutline = System.Drawing.Color.Empty;
            this.btnHistoria.Image = null;
            this.btnHistoria.ImageAutoCenter = true;
            this.btnHistoria.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnHistoria.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHistoria.ImageTint = System.Drawing.Color.White;
            this.btnHistoria.IsToggleButton = false;
            this.btnHistoria.IsToggled = false;
            this.btnHistoria.Location = new System.Drawing.Point(3, 3);
            this.btnHistoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHistoria.Name = "btnHistoria";
            this.btnHistoria.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnHistoria.NormalForeColor = System.Drawing.Color.White;
            this.btnHistoria.NormalOutline = System.Drawing.Color.Empty;
            this.btnHistoria.OutlineThickness = 2F;
            this.btnHistoria.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnHistoria.PressedForeColor = System.Drawing.Color.White;
            this.btnHistoria.PressedImageTint = System.Drawing.Color.White;
            this.btnHistoria.PressedOutline = System.Drawing.Color.Empty;
            this.btnHistoria.Rounding = new System.Windows.Forms.Padding(5);
            this.btnHistoria.Size = new System.Drawing.Size(161, 51);
            this.btnHistoria.TabIndex = 0;
            this.btnHistoria.TextAutoCenter = true;
            this.btnHistoria.TextOffset = new System.Drawing.Point(0, 0);
            this.btnHistoria.Click += new System.EventHandler(this.btnHistoria_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panel2.Controls.Add(this.btnRegistro);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(167, 57);
            this.panel2.TabIndex = 0;
            // 
            // btnRegistro
            // 
            this.btnRegistro.ButtonText = "Registro";
            this.btnRegistro.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(58)))));
            this.btnRegistro.CheckedForeColor = System.Drawing.Color.White;
            this.btnRegistro.CheckedImageTint = System.Drawing.Color.White;
            this.btnRegistro.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(108)))), ((int)(((byte)(58)))));
            this.btnRegistro.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegistro.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(88)))), ((int)(((byte)(78)))));
            this.btnRegistro.HoverForeColor = System.Drawing.Color.White;
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
            this.btnRegistro.Location = new System.Drawing.Point(3, 3);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnRegistro.NormalForeColor = System.Drawing.Color.White;
            this.btnRegistro.NormalOutline = System.Drawing.Color.Empty;
            this.btnRegistro.OutlineThickness = 2F;
            this.btnRegistro.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(68)))));
            this.btnRegistro.PressedForeColor = System.Drawing.Color.White;
            this.btnRegistro.PressedImageTint = System.Drawing.Color.White;
            this.btnRegistro.PressedOutline = System.Drawing.Color.Empty;
            this.btnRegistro.Rounding = new System.Windows.Forms.Padding(5);
            this.btnRegistro.Size = new System.Drawing.Size(161, 51);
            this.btnRegistro.TabIndex = 0;
            this.btnRegistro.TextAutoCenter = true;
            this.btnRegistro.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 160);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1200, 540);
            this.panelContenedor.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ButtonText = "X";
            this.btnCerrar.CheckedBackground = System.Drawing.Color.Firebrick;
            this.btnCerrar.CheckedForeColor = System.Drawing.Color.White;
            this.btnCerrar.CheckedImageTint = System.Drawing.Color.White;
            this.btnCerrar.CheckedOutline = System.Drawing.Color.Firebrick;
            this.btnCerrar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.btnCerrar.HoverForeColor = System.Drawing.Color.White;
            this.btnCerrar.HoverImage = null;
            this.btnCerrar.HoverImageTint = System.Drawing.Color.White;
            this.btnCerrar.HoverOutline = System.Drawing.Color.Empty;
            this.btnCerrar.Image = null;
            this.btnCerrar.ImageAutoCenter = true;
            this.btnCerrar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCerrar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCerrar.ImageTint = System.Drawing.Color.White;
            this.btnCerrar.IsToggleButton = false;
            this.btnCerrar.IsToggled = false;
            this.btnCerrar.Location = new System.Drawing.Point(1133, -3);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.NormalBackground = System.Drawing.Color.Crimson;
            this.btnCerrar.NormalForeColor = System.Drawing.Color.White;
            this.btnCerrar.NormalOutline = System.Drawing.Color.Empty;
            this.btnCerrar.OutlineThickness = 2F;
            this.btnCerrar.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(10)))), ((int)(((byte)(50)))));
            this.btnCerrar.PressedForeColor = System.Drawing.Color.White;
            this.btnCerrar.PressedImageTint = System.Drawing.Color.White;
            this.btnCerrar.PressedOutline = System.Drawing.Color.Empty;
            this.btnCerrar.Rounding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCerrar.Size = new System.Drawing.Size(60, 31);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.TextAutoCenter = true;
            this.btnCerrar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.ButtonText = "___";
            this.btnMinimizar.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnMinimizar.CheckedForeColor = System.Drawing.Color.White;
            this.btnMinimizar.CheckedImageTint = System.Drawing.Color.White;
            this.btnMinimizar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnMinimizar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimizar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnMinimizar.HoverForeColor = System.Drawing.Color.White;
            this.btnMinimizar.HoverImage = null;
            this.btnMinimizar.HoverImageTint = System.Drawing.Color.White;
            this.btnMinimizar.HoverOutline = System.Drawing.Color.Empty;
            this.btnMinimizar.Image = null;
            this.btnMinimizar.ImageAutoCenter = true;
            this.btnMinimizar.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnMinimizar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMinimizar.ImageTint = System.Drawing.Color.White;
            this.btnMinimizar.IsToggleButton = false;
            this.btnMinimizar.IsToggled = false;
            this.btnMinimizar.Location = new System.Drawing.Point(1077, -3);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.NormalBackground = System.Drawing.Color.DimGray;
            this.btnMinimizar.NormalForeColor = System.Drawing.Color.White;
            this.btnMinimizar.NormalOutline = System.Drawing.Color.Empty;
            this.btnMinimizar.OutlineThickness = 2F;
            this.btnMinimizar.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.btnMinimizar.PressedForeColor = System.Drawing.Color.White;
            this.btnMinimizar.PressedImageTint = System.Drawing.Color.White;
            this.btnMinimizar.PressedOutline = System.Drawing.Color.Empty;
            this.btnMinimizar.Rounding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.btnMinimizar.Size = new System.Drawing.Size(56, 31);
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.TextAutoCenter = true;
            this.btnMinimizar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // frmExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExpediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expediente ";
            this.Load += new System.EventHandler(this.frmExpediente_Load);
            this.panel1.ResumeLayout(false);
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.Panel panel1;
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private FrameworkTest.SATAButton btnAlergias;
        private System.Windows.Forms.Panel panel4;
        private FrameworkTest.SATAButton btnCuadros;
        private System.Windows.Forms.Panel panel3;
        private FrameworkTest.SATAButton btnHistoria;
        private FrameworkTest.SATAButton btnRegistro;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbCedulayGenero;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panel7;
        private FrameworkTest.SATAButton btnRecetas;
        private System.Windows.Forms.Panel panel6;
        private FrameworkTest.SATAButton btnFisico;
        private System.Windows.Forms.Panel panel8;
        private FrameworkTest.SATAButton btnPDF;
        private FrameworkTest.SATAButton btnCerrar;
        private FrameworkTest.SATAButton btnMinimizar;
    }
}