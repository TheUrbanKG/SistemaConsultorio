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
            this.flowPanelCitas = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.panelFiltros.SuspendLayout();
            this.panelDiaEspecifico.SuspendLayout();
            this.panelMesEspecifico.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(50, 29);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(251, 37);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "AGENDA DE CITAS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFiltros
            // 
            this.panelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.panelMesEspecifico);
            this.panelFiltros.Controls.Add(this.lblFiltro);
            this.panelFiltros.Controls.Add(this.cmbFiltro);
            this.panelFiltros.Controls.Add(this.panelDiaEspecifico);
            this.panelFiltros.Controls.Add(this.btnAplicarFiltro);
            this.panelFiltros.Location = new System.Drawing.Point(36, 89);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15);
            this.panelFiltros.Size = new System.Drawing.Size(1040, 110);
            this.panelFiltros.TabIndex = 4;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.LightGray;
            this.lblFiltro.Location = new System.Drawing.Point(440, 24);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(72, 19);
            this.lblFiltro.TabIndex = 0;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltro.ForeColor = System.Drawing.Color.White;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Día específico",
            "Mes actual",
            "Mes específico"});
            this.cmbFiltro.Location = new System.Drawing.Point(518, 21);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(140, 25);
            this.cmbFiltro.TabIndex = 1;
            // 
            // panelDiaEspecifico
            // 
            this.panelDiaEspecifico.Controls.Add(this.lblFecha);
            this.panelDiaEspecifico.Controls.Add(this.dtpFecha);
            this.panelDiaEspecifico.Location = new System.Drawing.Point(682, 11);
            this.panelDiaEspecifico.Name = "panelDiaEspecifico";
            this.panelDiaEspecifico.Size = new System.Drawing.Size(340, 35);
            this.panelDiaEspecifico.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.LightGray;
            this.lblFecha.Location = new System.Drawing.Point(3, 11);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 19);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.ForeColor = System.Drawing.Color.White;
            this.dtpFecha.Location = new System.Drawing.Point(49, 8);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(268, 25);
            this.dtpFecha.TabIndex = 1;
            // 
            // panelMesEspecifico
            // 
            this.panelMesEspecifico.Controls.Add(this.lblMes);
            this.panelMesEspecifico.Controls.Add(this.dtpMesEspecifico);
            this.panelMesEspecifico.Location = new System.Drawing.Point(682, 13);
            this.panelMesEspecifico.Name = "panelMesEspecifico";
            this.panelMesEspecifico.Size = new System.Drawing.Size(300, 35);
            this.panelMesEspecifico.TabIndex = 3;
            this.panelMesEspecifico.Visible = false;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.LightGray;
            this.lblMes.Location = new System.Drawing.Point(3, 9);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(38, 19);
            this.lblMes.TabIndex = 0;
            this.lblMes.Text = "Mes:";
            // 
            // dtpMesEspecifico
            // 
            this.dtpMesEspecifico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.dtpMesEspecifico.CustomFormat = "MMMM yyyy";
            this.dtpMesEspecifico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMesEspecifico.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMesEspecifico.Location = new System.Drawing.Point(43, 8);
            this.dtpMesEspecifico.Name = "dtpMesEspecifico";
            this.dtpMesEspecifico.ShowUpDown = true;
            this.dtpMesEspecifico.Size = new System.Drawing.Size(200, 25);
            this.dtpMesEspecifico.TabIndex = 1;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(22, 57);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(120, 35);
            this.btnAplicarFiltro.TabIndex = 4;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            // 
            // flowPanelCitas
            // 
            this.flowPanelCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelCitas.AutoScroll = true;
            this.flowPanelCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.flowPanelCitas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelCitas.Location = new System.Drawing.Point(25, 201);
            this.flowPanelCitas.Name = "flowPanelCitas";
            this.flowPanelCitas.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelCitas.Size = new System.Drawing.Size(1062, 450);
            this.flowPanelCitas.TabIndex = 5;
            this.flowPanelCitas.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del Paciente:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(165, 24);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(269, 22);
            this.txtBuscar.TabIndex = 7;
            // 
            // panelTopAccent
            // 
            this.panelTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(177)))));
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.panelTopAccent);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.flowPanelCitas);
            this.ForeColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.Panel panelTopAccent;
    }
}