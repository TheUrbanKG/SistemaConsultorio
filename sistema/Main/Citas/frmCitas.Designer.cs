namespace sistema
{
    partial class frmCitas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.contenedorDias = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDividerDias = new System.Windows.Forms.Panel();
            this.tlpHeaderDias = new System.Windows.Forms.TableLayoutPanel();
            this.lblSab = new System.Windows.Forms.Label();
            this.lblVie = new System.Windows.Forms.Label();
            this.lblJue = new System.Windows.Forms.Label();
            this.lblMie = new System.Windows.Forms.Label();
            this.lblMar = new System.Windows.Forms.Label();
            this.lblLun = new System.Windows.Forms.Label();
            this.lblDom = new System.Windows.Forms.Label();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelLeyenda = new System.Windows.Forms.Panel();
            this.lblTextoLeyenda = new System.Windows.Forms.Label();
            this.panelDotLeyenda = new System.Windows.Forms.Panel();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.labelSubtituloCitas = new System.Windows.Forms.Label();
            this.labelTituloCitas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tlpHeaderDias.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelLeyenda.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.contenedorDias);
            this.panel1.Controls.Add(this.panelDividerDias);
            this.panel1.Controls.Add(this.tlpHeaderDias);
            this.panel1.Controls.Add(this.panelDivider);
            this.panel1.Controls.Add(this.panelHeader);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 590);
            this.panel1.TabIndex = 102;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // contenedorDias
            // 
            this.contenedorDias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.contenedorDias.AutoScroll = true;
            this.contenedorDias.BackColor = System.Drawing.Color.White;
            this.contenedorDias.Location = new System.Drawing.Point(12, 112);
            this.contenedorDias.Name = "contenedorDias";
            this.contenedorDias.Size = new System.Drawing.Size(1126, 465);
            this.contenedorDias.TabIndex = 0;
            // 
            // panelDividerDias
            // 
            this.panelDividerDias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelDividerDias.Location = new System.Drawing.Point(14, 106);
            this.panelDividerDias.Name = "panelDividerDias";
            this.panelDividerDias.Size = new System.Drawing.Size(1120, 1);
            this.panelDividerDias.TabIndex = 106;
            // 
            // tlpHeaderDias
            // 
            this.tlpHeaderDias.ColumnCount = 7;
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpHeaderDias.Controls.Add(this.lblSab, 6, 0);
            this.tlpHeaderDias.Controls.Add(this.lblVie, 5, 0);
            this.tlpHeaderDias.Controls.Add(this.lblJue, 4, 0);
            this.tlpHeaderDias.Controls.Add(this.lblMie, 3, 0);
            this.tlpHeaderDias.Controls.Add(this.lblMar, 2, 0);
            this.tlpHeaderDias.Controls.Add(this.lblLun, 1, 0);
            this.tlpHeaderDias.Controls.Add(this.lblDom, 0, 0);
            this.tlpHeaderDias.Location = new System.Drawing.Point(14, 78);
            this.tlpHeaderDias.Name = "tlpHeaderDias";
            this.tlpHeaderDias.RowCount = 1;
            this.tlpHeaderDias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeaderDias.Size = new System.Drawing.Size(1120, 26);
            this.tlpHeaderDias.TabIndex = 105;
            // 
            // lblSab
            // 
            this.lblSab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSab.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSab.Location = new System.Drawing.Point(963, 0);
            this.lblSab.Name = "lblSab";
            this.lblSab.Size = new System.Drawing.Size(154, 26);
            this.lblSab.TabIndex = 6;
            this.lblSab.Text = "SÁBADO";
            this.lblSab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVie
            // 
            this.lblVie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVie.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblVie.Location = new System.Drawing.Point(803, 0);
            this.lblVie.Name = "lblVie";
            this.lblVie.Size = new System.Drawing.Size(154, 26);
            this.lblVie.TabIndex = 5;
            this.lblVie.Text = "VIERNES";
            this.lblVie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJue
            // 
            this.lblJue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblJue.Location = new System.Drawing.Point(643, 0);
            this.lblJue.Name = "lblJue";
            this.lblJue.Size = new System.Drawing.Size(154, 26);
            this.lblJue.TabIndex = 4;
            this.lblJue.Text = "JUEVES";
            this.lblJue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMie
            // 
            this.lblMie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMie.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMie.Location = new System.Drawing.Point(483, 0);
            this.lblMie.Name = "lblMie";
            this.lblMie.Size = new System.Drawing.Size(154, 26);
            this.lblMie.TabIndex = 3;
            this.lblMie.Text = "MIÉRCOLES";
            this.lblMie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMar
            // 
            this.lblMar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMar.Location = new System.Drawing.Point(323, 0);
            this.lblMar.Name = "lblMar";
            this.lblMar.Size = new System.Drawing.Size(154, 26);
            this.lblMar.TabIndex = 2;
            this.lblMar.Text = "MARTES";
            this.lblMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLun
            // 
            this.lblLun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLun.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblLun.Location = new System.Drawing.Point(163, 0);
            this.lblLun.Name = "lblLun";
            this.lblLun.Size = new System.Drawing.Size(154, 26);
            this.lblLun.TabIndex = 1;
            this.lblLun.Text = "LUNES";
            this.lblLun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDom
            // 
            this.lblDom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDom.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDom.Location = new System.Drawing.Point(3, 0);
            this.lblDom.Name = "lblDom";
            this.lblDom.Size = new System.Drawing.Size(154, 26);
            this.lblDom.TabIndex = 0;
            this.lblDom.Text = "DOMINGO";
            this.lblDom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelDivider.Location = new System.Drawing.Point(14, 70);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(1122, 1);
            this.panelDivider.TabIndex = 104;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelLeyenda);
            this.panelHeader.Controls.Add(this.panelNav);
            this.panelHeader.Controls.Add(this.labelSubtituloCitas);
            this.panelHeader.Controls.Add(this.labelTituloCitas);
            this.panelHeader.Location = new System.Drawing.Point(14, 10);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1122, 54);
            this.panelHeader.TabIndex = 103;
            // 
            // panelLeyenda
            // 
            this.panelLeyenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.panelLeyenda.Controls.Add(this.lblTextoLeyenda);
            this.panelLeyenda.Controls.Add(this.panelDotLeyenda);
            this.panelLeyenda.Location = new System.Drawing.Point(920, 12);
            this.panelLeyenda.Name = "panelLeyenda";
            this.panelLeyenda.Size = new System.Drawing.Size(195, 30);
            this.panelLeyenda.TabIndex = 15;
            this.panelLeyenda.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeyenda_Paint);
            // 
            // lblTextoLeyenda
            // 
            this.lblTextoLeyenda.AutoSize = true;
            this.lblTextoLeyenda.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoLeyenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.lblTextoLeyenda.Location = new System.Drawing.Point(26, 8);
            this.lblTextoLeyenda.Name = "lblTextoLeyenda";
            this.lblTextoLeyenda.Size = new System.Drawing.Size(155, 13);
            this.lblTextoLeyenda.TabIndex = 1;
            this.lblTextoLeyenda.Text = "Días con citas programadas";
            // 
            // panelDotLeyenda
            // 
            this.panelDotLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.panelDotLeyenda.Location = new System.Drawing.Point(12, 11);
            this.panelDotLeyenda.Name = "panelDotLeyenda";
            this.panelDotLeyenda.Size = new System.Drawing.Size(8, 8);
            this.panelDotLeyenda.TabIndex = 0;
            this.panelDotLeyenda.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDotLeyenda_Paint);
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnHoy);
            this.panelNav.Controls.Add(this.btnSiguiente);
            this.panelNav.Controls.Add(this.labelFecha);
            this.panelNav.Controls.Add(this.btnAnterior);
            this.panelNav.Location = new System.Drawing.Point(420, 8);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(460, 38);
            this.panelNav.TabIndex = 14;
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.btnHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(247)))), ((int)(((byte)(208)))));
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.btnHoy.Location = new System.Drawing.Point(395, 3);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(58, 32);
            this.btnHoy.TabIndex = 13;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSiguiente.Location = new System.Drawing.Point(292, 3);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(95, 32);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = "Siguiente ▶";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.labelFecha.Location = new System.Drawing.Point(97, 3);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(190, 32);
            this.labelFecha.TabIndex = 10;
            this.labelFecha.Text = "MES AÑO";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAnterior.Location = new System.Drawing.Point(3, 3);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(90, 32);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "◀ Anterior";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // labelSubtituloCitas
            // 
            this.labelSubtituloCitas.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtituloCitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.labelSubtituloCitas.Location = new System.Drawing.Point(4, 30);
            this.labelSubtituloCitas.Name = "labelSubtituloCitas";
            this.labelSubtituloCitas.Size = new System.Drawing.Size(380, 20);
            this.labelSubtituloCitas.TabIndex = 12;
            this.labelSubtituloCitas.Text = "Haga clic en un día para agendar o gestionar citas";
            this.labelSubtituloCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTituloCitas
            // 
            this.labelTituloCitas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloCitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.labelTituloCitas.Location = new System.Drawing.Point(4, 4);
            this.labelTituloCitas.Name = "labelTituloCitas";
            this.labelTituloCitas.Size = new System.Drawing.Size(320, 26);
            this.labelTituloCitas.TabIndex = 11;
            this.labelTituloCitas.Text = "Calendario de Citas";
            this.labelTituloCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1170, 610);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1185, 615);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCitas";
            this.Text = "frmCitas";
            this.Load += new System.EventHandler(this.frmCitas_Load);
            this.Resize += new System.EventHandler(this.frmCitas_Resize);
            this.panel1.ResumeLayout(false);
            this.tlpHeaderDias.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeyenda.ResumeLayout(false);
            this.panelLeyenda.PerformLayout();
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel contenedorDias;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTituloCitas;
        private System.Windows.Forms.Label labelSubtituloCitas;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Panel panelLeyenda;
        private System.Windows.Forms.Label lblTextoLeyenda;
        private System.Windows.Forms.Panel panelDotLeyenda;
        private System.Windows.Forms.Panel panelDivider;
        private System.Windows.Forms.TableLayoutPanel tlpHeaderDias;
        private System.Windows.Forms.Label lblDom;
        private System.Windows.Forms.Label lblLun;
        private System.Windows.Forms.Label lblMar;
        private System.Windows.Forms.Label lblMie;
        private System.Windows.Forms.Label lblJue;
        private System.Windows.Forms.Label lblVie;
        private System.Windows.Forms.Label lblSab;
        private System.Windows.Forms.Panel panelDividerDias;
    }
}
