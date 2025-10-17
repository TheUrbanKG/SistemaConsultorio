namespace sistema
{
    partial class frmNotas
    {
        private System.ComponentModel.IContainer components = null;

        // Acento superior (línea verde)
        private System.Windows.Forms.Panel panelTopAccent;

        // Filtros
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.ComboBox cboFiltroTipo;
        private System.Windows.Forms.ComboBox cboFiltroPaciente;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.Label lblFiltroPaciente;
        private System.Windows.Forms.Label lblBuscar;

        // Editor
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.RadioButton rbGeneral;
        private System.Windows.Forms.RadioButton rbMedica;
        private System.Windows.Forms.ComboBox cboPaciente;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.RichTextBox txtContenido;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblContenido;

        // Listado
        private System.Windows.Forms.FlowLayoutPanel flpNotas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.cboFiltroTipo = new System.Windows.Forms.ComboBox();
            this.lblFiltroPaciente = new System.Windows.Forms.Label();
            this.cboFiltroPaciente = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.rbGeneral = new System.Windows.Forms.RadioButton();
            this.rbMedica = new System.Windows.Forms.RadioButton();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cboPaciente = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblContenido = new System.Windows.Forms.Label();
            this.txtContenido = new System.Windows.Forms.RichTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.flpNotas = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFiltros.SuspendLayout();
            this.panelEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopAccent
            // 
            this.panelTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panelTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccent.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccent.Name = "panelTopAccent";
            this.panelTopAccent.Size = new System.Drawing.Size(915, 3);
            this.panelTopAccent.TabIndex = 100;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panelFiltros.Controls.Add(this.lblFiltroTipo);
            this.panelFiltros.Controls.Add(this.cboFiltroTipo);
            this.panelFiltros.Controls.Add(this.lblFiltroPaciente);
            this.panelFiltros.Controls.Add(this.cboFiltroPaciente);
            this.panelFiltros.Controls.Add(this.lblBuscar);
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.btnRefrescar);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 3);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(915, 49);
            this.panelFiltros.TabIndex = 0;
            // 
            // lblFiltroTipo
            // 
            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblFiltroTipo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFiltroTipo.Location = new System.Drawing.Point(10, 16);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(32, 17);
            this.lblFiltroTipo.TabIndex = 0;
            this.lblFiltroTipo.Text = "Tipo";
            // 
            // cboFiltroTipo
            // 
            this.cboFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.cboFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroTipo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFiltroTipo.ForeColor = System.Drawing.Color.Black;
            this.cboFiltroTipo.Location = new System.Drawing.Point(48, 14);
            this.cboFiltroTipo.Name = "cboFiltroTipo";
            this.cboFiltroTipo.Size = new System.Drawing.Size(112, 21);
            this.cboFiltroTipo.TabIndex = 1;
            // 
            // lblFiltroPaciente
            // 
            this.lblFiltroPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltroPaciente.AutoSize = true;
            this.lblFiltroPaciente.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblFiltroPaciente.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFiltroPaciente.Location = new System.Drawing.Point(514, 17);
            this.lblFiltroPaciente.Name = "lblFiltroPaciente";
            this.lblFiltroPaciente.Size = new System.Drawing.Size(62, 17);
            this.lblFiltroPaciente.TabIndex = 2;
            this.lblFiltroPaciente.Text = "Paciente";
            // 
            // cboFiltroPaciente
            // 
            this.cboFiltroPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiltroPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.cboFiltroPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroPaciente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFiltroPaciente.ForeColor = System.Drawing.Color.Black;
            this.cboFiltroPaciente.Location = new System.Drawing.Point(582, 14);
            this.cboFiltroPaciente.Name = "cboFiltroPaciente";
            this.cboFiltroPaciente.Size = new System.Drawing.Size(198, 21);
            this.cboFiltroPaciente.TabIndex = 3;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblBuscar.Location = new System.Drawing.Point(188, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(47, 17);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(241, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(257, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.Black;
            this.btnRefrescar.Location = new System.Drawing.Point(805, 10);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(91, 26);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // panelEditor
            // 
            this.panelEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelEditor.Controls.Add(this.rbGeneral);
            this.panelEditor.Controls.Add(this.rbMedica);
            this.panelEditor.Controls.Add(this.lblPaciente);
            this.panelEditor.Controls.Add(this.cboPaciente);
            this.panelEditor.Controls.Add(this.lblTitulo);
            this.panelEditor.Controls.Add(this.txtTitulo);
            this.panelEditor.Controls.Add(this.lblContenido);
            this.panelEditor.Controls.Add(this.txtContenido);
            this.panelEditor.Controls.Add(this.btnGuardar);
            this.panelEditor.Controls.Add(this.btnLimpiar);
            this.panelEditor.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEditor.Location = new System.Drawing.Point(0, 52);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(326, 505);
            this.panelEditor.TabIndex = 1;
            // 
            // rbGeneral
            // 
            this.rbGeneral.AutoSize = true;
            this.rbGeneral.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.rbGeneral.ForeColor = System.Drawing.Color.White;
            this.rbGeneral.Location = new System.Drawing.Point(86, 14);
            this.rbGeneral.Name = "rbGeneral";
            this.rbGeneral.Size = new System.Drawing.Size(74, 21);
            this.rbGeneral.TabIndex = 0;
            this.rbGeneral.TabStop = true;
            this.rbGeneral.Text = "General";
            this.rbGeneral.UseVisualStyleBackColor = true;
            // 
            // rbMedica
            // 
            this.rbMedica.AutoSize = true;
            this.rbMedica.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.rbMedica.ForeColor = System.Drawing.Color.White;
            this.rbMedica.Location = new System.Drawing.Point(179, 14);
            this.rbMedica.Name = "rbMedica";
            this.rbMedica.Size = new System.Drawing.Size(72, 21);
            this.rbMedica.TabIndex = 1;
            this.rbMedica.TabStop = true;
            this.rbMedica.Text = "Médica";
            this.rbMedica.UseVisualStyleBackColor = true;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblPaciente.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPaciente.Location = new System.Drawing.Point(14, 50);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(178, 17);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "Paciente (solo para Médica)";
            // 
            // cboPaciente
            // 
            this.cboPaciente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaciente.Enabled = false;
            this.cboPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaciente.ForeColor = System.Drawing.Color.Black;
            this.cboPaciente.Location = new System.Drawing.Point(13, 70);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(292, 21);
            this.cboPaciente.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitulo.Location = new System.Drawing.Point(14, 116);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(39, 17);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitulo.ForeColor = System.Drawing.Color.Black;
            this.txtTitulo.Location = new System.Drawing.Point(14, 136);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(292, 20);
            this.txtTitulo.TabIndex = 5;
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblContenido.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblContenido.Location = new System.Drawing.Point(14, 173);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(71, 17);
            this.lblContenido.TabIndex = 6;
            this.lblContenido.Text = "Contenido";
            // 
            // txtContenido
            // 
            this.txtContenido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtContenido.BackColor = System.Drawing.Color.White;
            this.txtContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContenido.ForeColor = System.Drawing.Color.Black;
            this.txtContenido.Location = new System.Drawing.Point(17, 193);
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(292, 243);
            this.txtContenido.TabIndex = 7;
            this.txtContenido.Text = "";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(86, 451);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 29);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(202, 451);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(103, 29);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // flpNotas
            // 
            this.flpNotas.AutoScroll = true;
            this.flpNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.flpNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNotas.Location = new System.Drawing.Point(326, 52);
            this.flpNotas.Name = "flpNotas";
            this.flpNotas.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.flpNotas.Size = new System.Drawing.Size(589, 505);
            this.flpNotas.TabIndex = 2;
            // 
            // frmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(915, 557);
            this.Controls.Add(this.flpNotas);
            this.Controls.Add(this.panelEditor);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTopAccent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(823, 485);
            this.Name = "frmNotas";
            this.Text = "Notas";
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelEditor.ResumeLayout(false);
            this.panelEditor.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}