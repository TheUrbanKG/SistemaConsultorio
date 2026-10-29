namespace sistema.Expediente.Odontograma
{
    partial class frmOdontograma
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTipDiente = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.cardBoca = new System.Windows.Forms.Panel();
            this.pnlBoca = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.grpDiente = new System.Windows.Forms.GroupBox();
            this.lblPiezaSeleccionada = new System.Windows.Forms.Label();
            this.picPreviewDiente = new System.Windows.Forms.PictureBox();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.btnAbrirEsquema = new System.Windows.Forms.Button();
            this.btnMarcarSano = new System.Windows.Forms.Button();
            this.btnMarcarAusente = new System.Windows.Forms.Button();
            this.lblObsDiente = new System.Windows.Forms.Label();
            this.txtObservacionDiente = new System.Windows.Forms.TextBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtObservacionesGenerales = new System.Windows.Forms.TextBox();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.cardBoca.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.grpDiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewDiente)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Controls.Add(this.lblTipo);
            this.pnlTop.Controls.Add(this.cmbTipo);
            this.pnlTop.Controls.Add(this.lblFecha);
            this.pnlTop.Controls.Add(this.dtpFecha);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlTop.Size = new System.Drawing.Size(950, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(222, 19);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Odontograma del Paciente";
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTipo.Location = new System.Drawing.Point(540, 18);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 15);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(580, 14);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(120, 23);
            this.cmbTipo.TabIndex = 2;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFecha.Location = new System.Drawing.Point(716, 18);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(42, 15);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(764, 14);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(160, 23);
            this.dtpFecha.TabIndex = 4;
            // 
            // pnlCenter
            // 
            this.pnlCenter.AutoScroll = true;
            this.pnlCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlCenter.Controls.Add(this.cardBoca);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 52);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(16);
            this.pnlCenter.Size = new System.Drawing.Size(520, 508);
            this.pnlCenter.TabIndex = 1;
            // 
            // cardBoca
            // 
            this.cardBoca.BackColor = System.Drawing.Color.White;
            this.cardBoca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardBoca.Controls.Add(this.pnlBoca);
            this.cardBoca.Location = new System.Drawing.Point(20, 16);
            this.cardBoca.Name = "cardBoca";
            this.cardBoca.Size = new System.Drawing.Size(255, 428);
            this.cardBoca.TabIndex = 0;
            // 
            // pnlBoca
            // 
            this.pnlBoca.BackColor = System.Drawing.Color.White;
            this.pnlBoca.Location = new System.Drawing.Point(9, 9);
            this.pnlBoca.Name = "pnlBoca";
            this.pnlBoca.Size = new System.Drawing.Size(235, 408);
            this.pnlBoca.TabIndex = 0;
            this.pnlBoca.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoca_Paint);
            this.pnlBoca.DoubleClick += new System.EventHandler(this.pnlBoca_DoubleClick);
            this.pnlBoca.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBoca_MouseDown);
            this.pnlBoca.MouseLeave += new System.EventHandler(this.pnlBoca_MouseLeave);
            this.pnlBoca.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBoca_MouseMove);
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.BackColor = System.Drawing.Color.White;
            this.pnlDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDerecha.Controls.Add(this.pnlAcciones);
            this.pnlDerecha.Controls.Add(this.grpGeneral);
            this.pnlDerecha.Controls.Add(this.grpDiente);
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.Location = new System.Drawing.Point(520, 52);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Padding = new System.Windows.Forms.Padding(14);
            this.pnlDerecha.Size = new System.Drawing.Size(430, 508);
            this.pnlDerecha.TabIndex = 2;
            // 
            // grpDiente
            // 
            this.grpDiente.Controls.Add(this.lblPiezaSeleccionada);
            this.grpDiente.Controls.Add(this.picPreviewDiente);
            this.grpDiente.Controls.Add(this.lblEstadoActual);
            this.grpDiente.Controls.Add(this.btnAbrirEsquema);
            this.grpDiente.Controls.Add(this.btnMarcarSano);
            this.grpDiente.Controls.Add(this.btnMarcarAusente);
            this.grpDiente.Controls.Add(this.lblObsDiente);
            this.grpDiente.Controls.Add(this.txtObservacionDiente);
            this.grpDiente.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDiente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpDiente.Location = new System.Drawing.Point(14, 14);
            this.grpDiente.Name = "grpDiente";
            this.grpDiente.Size = new System.Drawing.Size(400, 240);
            this.grpDiente.TabIndex = 0;
            this.grpDiente.TabStop = false;
            this.grpDiente.Text = "Pieza Dental Seleccionada";
            // 
            // lblPiezaSeleccionada
            // 
            this.lblPiezaSeleccionada.AutoSize = true;
            this.lblPiezaSeleccionada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPiezaSeleccionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblPiezaSeleccionada.Location = new System.Drawing.Point(12, 26);
            this.lblPiezaSeleccionada.Name = "lblPiezaSeleccionada";
            this.lblPiezaSeleccionada.Size = new System.Drawing.Size(240, 19);
            this.lblPiezaSeleccionada.TabIndex = 0;
            this.lblPiezaSeleccionada.Text = "Pieza #11 - Incisivo Central Superior";
            // 
            // picPreviewDiente
            // 
            this.picPreviewDiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.picPreviewDiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreviewDiente.Location = new System.Drawing.Point(16, 56);
            this.picPreviewDiente.Name = "picPreviewDiente";
            this.picPreviewDiente.Size = new System.Drawing.Size(48, 48);
            this.picPreviewDiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPreviewDiente.TabIndex = 1;
            this.picPreviewDiente.TabStop = false;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblEstadoActual.Location = new System.Drawing.Point(74, 60);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(117, 15);
            this.lblEstadoActual.TabIndex = 2;
            this.lblEstadoActual.Text = "Estado: Sano (Limpio)";
            // 
            // btnAbrirEsquema
            // 
            this.btnAbrirEsquema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAbrirEsquema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirEsquema.FlatAppearance.BorderSize = 0;
            this.btnAbrirEsquema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirEsquema.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAbrirEsquema.ForeColor = System.Drawing.Color.White;
            this.btnAbrirEsquema.Location = new System.Drawing.Point(77, 80);
            this.btnAbrirEsquema.Name = "btnAbrirEsquema";
            this.btnAbrirEsquema.Size = new System.Drawing.Size(200, 28);
            this.btnAbrirEsquema.TabIndex = 3;
            this.btnAbrirEsquema.Text = "🎨 Abrir Esquema Dental...";
            this.btnAbrirEsquema.UseVisualStyleBackColor = false;
            this.btnAbrirEsquema.Click += new System.EventHandler(this.btnAbrirEsquema_Click);
            // 
            // btnMarcarSano
            // 
            this.btnMarcarSano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnMarcarSano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarSano.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMarcarSano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarSano.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMarcarSano.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnMarcarSano.Location = new System.Drawing.Point(16, 116);
            this.btnMarcarSano.Name = "btnMarcarSano";
            this.btnMarcarSano.Size = new System.Drawing.Size(120, 26);
            this.btnMarcarSano.TabIndex = 4;
            this.btnMarcarSano.Text = "✓ Marcar Sano";
            this.btnMarcarSano.UseVisualStyleBackColor = false;
            this.btnMarcarSano.Click += new System.EventHandler(this.btnMarcarSano_Click);
            // 
            // btnMarcarAusente
            // 
            this.btnMarcarAusente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnMarcarAusente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarAusente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMarcarAusente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarAusente.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMarcarAusente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnMarcarAusente.Location = new System.Drawing.Point(144, 116);
            this.btnMarcarAusente.Name = "btnMarcarAusente";
            this.btnMarcarAusente.Size = new System.Drawing.Size(133, 26);
            this.btnMarcarAusente.TabIndex = 5;
            this.btnMarcarAusente.Text = "❌ Marcar Ausente";
            this.btnMarcarAusente.UseVisualStyleBackColor = false;
            this.btnMarcarAusente.Click += new System.EventHandler(this.btnMarcarAusente_Click);
            // 
            // lblObsDiente
            // 
            this.lblObsDiente.AutoSize = true;
            this.lblObsDiente.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblObsDiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblObsDiente.Location = new System.Drawing.Point(14, 154);
            this.lblObsDiente.Name = "lblObsDiente";
            this.lblObsDiente.Size = new System.Drawing.Size(161, 15);
            this.lblObsDiente.TabIndex = 6;
            this.lblObsDiente.Text = "Observación sobre esta pieza:";
            // 
            // txtObservacionDiente
            // 
            this.txtObservacionDiente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacionDiente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacionDiente.Location = new System.Drawing.Point(16, 174);
            this.txtObservacionDiente.Multiline = true;
            this.txtObservacionDiente.Name = "txtObservacionDiente";
            this.txtObservacionDiente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacionDiente.Size = new System.Drawing.Size(368, 52);
            this.txtObservacionDiente.TabIndex = 7;
            this.txtObservacionDiente.TextChanged += new System.EventHandler(this.txtObservacionDiente_TextChanged);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeneral.Controls.Add(this.txtObservacionesGenerales);
            this.grpGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpGeneral.Location = new System.Drawing.Point(14, 260);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(400, 178);
            this.grpGeneral.TabIndex = 1;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Observaciones y Diagnóstico General";
            // 
            // txtObservacionesGenerales
            // 
            this.txtObservacionesGenerales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacionesGenerales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacionesGenerales.Location = new System.Drawing.Point(3, 20);
            this.txtObservacionesGenerales.Multiline = true;
            this.txtObservacionesGenerales.Name = "txtObservacionesGenerales";
            this.txtObservacionesGenerales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacionesGenerales.Size = new System.Drawing.Size(394, 155);
            this.txtObservacionesGenerales.TabIndex = 0;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(14, 444);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(400, 48);
            this.pnlAcciones.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(230, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(165, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar Odontograma";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnLimpiar.Location = new System.Drawing.Point(4, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 34);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "🔄 Restablecer";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmOdontograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOdontograma";
            this.Text = "Odontograma";
            this.Load += new System.EventHandler(this.frmOdontograma_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.cardBoca.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.grpDiente.ResumeLayout(false);
            this.grpDiente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewDiente)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolTip toolTipDiente;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel cardBoca;
        private System.Windows.Forms.Panel pnlBoca;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.GroupBox grpDiente;
        private System.Windows.Forms.Label lblPiezaSeleccionada;
        private System.Windows.Forms.PictureBox picPreviewDiente;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Button btnAbrirEsquema;
        private System.Windows.Forms.Button btnMarcarSano;
        private System.Windows.Forms.Button btnMarcarAusente;
        private System.Windows.Forms.Label lblObsDiente;
        private System.Windows.Forms.TextBox txtObservacionDiente;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtObservacionesGenerales;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
