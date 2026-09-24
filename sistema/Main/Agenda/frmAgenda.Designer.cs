namespace sistema
{
    partial class frmAgenda
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.panelDiaEspecifico = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panelMesEspecifico = new System.Windows.Forms.Panel();
            this.lblMes = new System.Windows.Forms.Label();
            this.dtpMesEspecifico = new System.Windows.Forms.DateTimePicker();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.flowPanelCitas = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblEstadoCita = new System.Windows.Forms.Label();
            this.cmbEstadoCita = new System.Windows.Forms.ComboBox();
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.panelFiltros.SuspendLayout();
            this.panelDiaEspecifico.SuspendLayout();
            this.panelMesEspecifico.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(36, 25);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(227, 32);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "AGENDA DE CITAS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFiltros
            // 
            this.panelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.panelMesEspecifico);
            this.panelFiltros.Controls.Add(this.lblFiltro);
            this.panelFiltros.Controls.Add(this.cmbFiltro);
            this.panelFiltros.Controls.Add(this.cmbEstadoCita);
            this.panelFiltros.Controls.Add(this.lblEstadoCita);
            this.panelFiltros.Controls.Add(this.panelDiaEspecifico);
            this.panelFiltros.Controls.Add(this.btnAplicarFiltro);
            this.panelFiltros.Controls.Add(this.btnExportarPDF);
            this.panelFiltros.Location = new System.Drawing.Point(36, 75);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15);
            this.panelFiltros.Size = new System.Drawing.Size(1037, 110);
            this.panelFiltros.TabIndex = 4;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFiltro.Location = new System.Drawing.Point(435, 23);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(73, 17);
            this.lblFiltro.TabIndex = 0;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.BackColor = System.Drawing.Color.White;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Día específico",
            "Mes actual",
            "Mes específico"});
            this.cmbFiltro.Location = new System.Drawing.Point(515, 20);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(145, 24);
            this.cmbFiltro.TabIndex = 1;
            // 
            // panelDiaEspecifico
            // 
            this.panelDiaEspecifico.BackColor = System.Drawing.Color.Transparent;
            this.panelDiaEspecifico.Controls.Add(this.lblFecha);
            this.panelDiaEspecifico.Controls.Add(this.dtpFecha);
            this.panelDiaEspecifico.Location = new System.Drawing.Point(675, 14);
            this.panelDiaEspecifico.Name = "panelDiaEspecifico";
            this.panelDiaEspecifico.Size = new System.Drawing.Size(340, 35);
            this.panelDiaEspecifico.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFecha.Location = new System.Drawing.Point(5, 8);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(55, 5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(265, 24);
            this.dtpFecha.TabIndex = 1;
            // 
            // panelMesEspecifico
            // 
            this.panelMesEspecifico.BackColor = System.Drawing.Color.Transparent;
            this.panelMesEspecifico.Controls.Add(this.lblMes);
            this.panelMesEspecifico.Controls.Add(this.dtpMesEspecifico);
            this.panelMesEspecifico.Location = new System.Drawing.Point(675, 14);
            this.panelMesEspecifico.Name = "panelMesEspecifico";
            this.panelMesEspecifico.Size = new System.Drawing.Size(300, 35);
            this.panelMesEspecifico.TabIndex = 3;
            this.panelMesEspecifico.Visible = false;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMes.Location = new System.Drawing.Point(5, 8);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(37, 17);
            this.lblMes.TabIndex = 0;
            this.lblMes.Text = "Mes:";
            // 
            // dtpMesEspecifico
            // 
            this.dtpMesEspecifico.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dtpMesEspecifico.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpMesEspecifico.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.dtpMesEspecifico.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpMesEspecifico.CustomFormat = "MMMM yyyy";
            this.dtpMesEspecifico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMesEspecifico.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMesEspecifico.Location = new System.Drawing.Point(48, 5);
            this.dtpMesEspecifico.Name = "dtpMesEspecifico";
            this.dtpMesEspecifico.ShowUpDown = true;
            this.dtpMesEspecifico.Size = new System.Drawing.Size(200, 24);
            this.dtpMesEspecifico.TabIndex = 1;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnAplicarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarFiltro.FlatAppearance.BorderSize = 0;
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(18, 58);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(125, 34);
            this.btnAplicarFiltro.TabIndex = 4;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPDF.FlatAppearance.BorderSize = 0;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(875, 58);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(142, 34);
            this.btnExportarPDF.TabIndex = 10;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            // 
            // flowPanelCitas
            // 
            this.flowPanelCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelCitas.AutoScroll = true;
            this.flowPanelCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.flowPanelCitas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelCitas.Location = new System.Drawing.Point(36, 198);
            this.flowPanelCitas.Name = "flowPanelCitas";
            this.flowPanelCitas.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.flowPanelCitas.Size = new System.Drawing.Size(1037, 470);
            this.flowPanelCitas.TabIndex = 5;
            this.flowPanelCitas.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del Paciente:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtBuscar.Location = new System.Drawing.Point(165, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 24);
            this.txtBuscar.TabIndex = 7;
            // 
            // lblEstadoCita
            // 
            this.lblEstadoCita.AutoSize = true;
            this.lblEstadoCita.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEstadoCita.Location = new System.Drawing.Point(165, 66);
            this.lblEstadoCita.Name = "lblEstadoCita";
            this.lblEstadoCita.Size = new System.Drawing.Size(53, 17);
            this.lblEstadoCita.TabIndex = 8;
            this.lblEstadoCita.Text = "Estado:";
            // 
            // cmbEstadoCita
            // 
            this.cmbEstadoCita.BackColor = System.Drawing.Color.White;
            this.cmbEstadoCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbEstadoCita.FormattingEnabled = true;
            this.cmbEstadoCita.Items.AddRange(new object[] {
            "Todos",
            "Programada",
            "Confirmada",
            "Completada",
            "Cancelada",
            "No asistió",
            "Reprogramada"});
            this.cmbEstadoCita.Location = new System.Drawing.Point(225, 63);
            this.cmbEstadoCita.Name = "cmbEstadoCita";
            this.cmbEstadoCita.Size = new System.Drawing.Size(155, 24);
            this.cmbEstadoCita.TabIndex = 9;
            // 
            // panelTopAccent
            // 
            this.panelTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.panelTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccent.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccent.Name = "panelTopAccent";
            this.panelTopAccent.Size = new System.Drawing.Size(1109, 3);
            this.panelTopAccent.TabIndex = 102;
            // 
            // frmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.panelTopAccent);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.flowPanelCitas);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgenda";
            this.Text = "Agenda de Citas";
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelDiaEspecifico.ResumeLayout(false);
            this.panelDiaEspecifico.PerformLayout();
            this.panelMesEspecifico.ResumeLayout(false);
            this.panelMesEspecifico.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Panel panelDiaEspecifico;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel panelMesEspecifico;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.DateTimePicker dtpMesEspecifico;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.FlowLayoutPanel flowPanelCitas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstadoCita;
        private System.Windows.Forms.ComboBox cmbEstadoCita;
        private System.Windows.Forms.Panel panelTopAccent;
        private System.Windows.Forms.Button btnExportarPDF;
    }
}