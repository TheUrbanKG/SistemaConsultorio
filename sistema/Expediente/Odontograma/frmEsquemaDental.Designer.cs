namespace sistema.Expediente.Odontograma
{
    partial class frmEsquemaDental
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpCaries = new System.Windows.Forms.GroupBox();
            this.pnlCaries = new System.Windows.Forms.FlowLayoutPanel();
            this.grpMixtas = new System.Windows.Forms.GroupBox();
            this.pnlMixtas = new System.Windows.Forms.FlowLayoutPanel();
            this.grpCuraciones = new System.Windows.Forms.GroupBox();
            this.pnlCuraciones = new System.Windows.Forms.FlowLayoutPanel();
            this.grpSimbologia = new System.Windows.Forms.GroupBox();
            this.pnlSimbologia = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAusente = new System.Windows.Forms.Button();
            this.btnExtraccion = new System.Windows.Forms.Button();
            this.btnEndodoncia = new System.Windows.Forms.Button();
            this.btnTratamiento = new System.Windows.Forms.Button();
            this.btnCorona = new System.Windows.Forms.Button();
            this.btnPuente = new System.Windows.Forms.Button();
            this.btnProtesisParcial = new System.Windows.Forms.Button();
            this.btnSano = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpCaries.SuspendLayout();
            this.grpMixtas.SuspendLayout();
            this.grpCuraciones.SuspendLayout();
            this.grpSimbologia.SuspendLayout();
            this.pnlSimbologia.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(620, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(248, 19);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Esquema Dental - Selector de Estado";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(582, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(28, 26);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grpCaries
            // 
            this.grpCaries.Controls.Add(this.pnlCaries);
            this.grpCaries.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCaries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.grpCaries.Location = new System.Drawing.Point(16, 48);
            this.grpCaries.Name = "grpCaries";
            this.grpCaries.Size = new System.Drawing.Size(185, 175);
            this.grpCaries.TabIndex = 1;
            this.grpCaries.TabStop = false;
            this.grpCaries.Text = "CARIES";
            // 
            // pnlCaries
            // 
            this.pnlCaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCaries.Location = new System.Drawing.Point(3, 19);
            this.pnlCaries.Name = "pnlCaries";
            this.pnlCaries.Size = new System.Drawing.Size(179, 153);
            this.pnlCaries.TabIndex = 0;
            // 
            // grpMixtas
            // 
            this.grpMixtas.Controls.Add(this.pnlMixtas);
            this.grpMixtas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpMixtas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            this.grpMixtas.Location = new System.Drawing.Point(217, 48);
            this.grpMixtas.Name = "grpMixtas";
            this.grpMixtas.Size = new System.Drawing.Size(185, 175);
            this.grpMixtas.TabIndex = 2;
            this.grpMixtas.TabStop = false;
            this.grpMixtas.Text = "CURACION CON CARIES";
            // 
            // pnlMixtas
            // 
            this.pnlMixtas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMixtas.Location = new System.Drawing.Point(3, 19);
            this.pnlMixtas.Name = "pnlMixtas";
            this.pnlMixtas.Size = new System.Drawing.Size(179, 153);
            this.pnlMixtas.TabIndex = 0;
            // 
            // grpCuraciones
            // 
            this.grpCuraciones.Controls.Add(this.pnlCuraciones);
            this.grpCuraciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCuraciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.grpCuraciones.Location = new System.Drawing.Point(418, 48);
            this.grpCuraciones.Name = "grpCuraciones";
            this.grpCuraciones.Size = new System.Drawing.Size(185, 175);
            this.grpCuraciones.TabIndex = 3;
            this.grpCuraciones.TabStop = false;
            this.grpCuraciones.Text = "CURACIONES";
            // 
            // pnlCuraciones
            // 
            this.pnlCuraciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuraciones.Location = new System.Drawing.Point(3, 19);
            this.pnlCuraciones.Name = "pnlCuraciones";
            this.pnlCuraciones.Size = new System.Drawing.Size(179, 153);
            this.pnlCuraciones.TabIndex = 0;
            // 
            // grpSimbologia
            // 
            this.grpSimbologia.Controls.Add(this.pnlSimbologia);
            this.grpSimbologia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSimbologia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.grpSimbologia.Location = new System.Drawing.Point(16, 235);
            this.grpSimbologia.Name = "grpSimbologia";
            this.grpSimbologia.Size = new System.Drawing.Size(587, 85);
            this.grpSimbologia.TabIndex = 4;
            this.grpSimbologia.TabStop = false;
            this.grpSimbologia.Text = "TRATAMIENTOS Y SIMBOLOGÍA";
            // 
            // pnlSimbologia
            // 
            this.pnlSimbologia.Controls.Add(this.btnAusente);
            this.pnlSimbologia.Controls.Add(this.btnExtraccion);
            this.pnlSimbologia.Controls.Add(this.btnEndodoncia);
            this.pnlSimbologia.Controls.Add(this.btnTratamiento);
            this.pnlSimbologia.Controls.Add(this.btnCorona);
            this.pnlSimbologia.Controls.Add(this.btnPuente);
            this.pnlSimbologia.Controls.Add(this.btnProtesisParcial);
            this.pnlSimbologia.Controls.Add(this.btnSano);
            this.pnlSimbologia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSimbologia.Location = new System.Drawing.Point(3, 19);
            this.pnlSimbologia.Name = "pnlSimbologia";
            this.pnlSimbologia.Size = new System.Drawing.Size(581, 63);
            this.pnlSimbologia.TabIndex = 0;
            // 
            // btnAusente
            // 
            this.btnAusente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusente.Location = new System.Drawing.Point(3, 3);
            this.btnAusente.Name = "btnAusente";
            this.btnAusente.Size = new System.Drawing.Size(42, 38);
            this.btnAusente.TabIndex = 0;
            this.btnAusente.UseVisualStyleBackColor = true;
            // 
            // btnExtraccion
            // 
            this.btnExtraccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtraccion.Location = new System.Drawing.Point(51, 3);
            this.btnExtraccion.Name = "btnExtraccion";
            this.btnExtraccion.Size = new System.Drawing.Size(42, 38);
            this.btnExtraccion.TabIndex = 1;
            this.btnExtraccion.UseVisualStyleBackColor = true;
            // 
            // btnEndodoncia
            // 
            this.btnEndodoncia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndodoncia.Location = new System.Drawing.Point(99, 3);
            this.btnEndodoncia.Name = "btnEndodoncia";
            this.btnEndodoncia.Size = new System.Drawing.Size(42, 38);
            this.btnEndodoncia.TabIndex = 2;
            this.btnEndodoncia.UseVisualStyleBackColor = true;
            // 
            // btnTratamiento
            // 
            this.btnTratamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTratamiento.Location = new System.Drawing.Point(147, 3);
            this.btnTratamiento.Name = "btnTratamiento";
            this.btnTratamiento.Size = new System.Drawing.Size(42, 38);
            this.btnTratamiento.TabIndex = 3;
            this.btnTratamiento.UseVisualStyleBackColor = true;
            // 
            // btnCorona
            // 
            this.btnCorona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorona.Location = new System.Drawing.Point(195, 3);
            this.btnCorona.Name = "btnCorona";
            this.btnCorona.Size = new System.Drawing.Size(42, 38);
            this.btnCorona.TabIndex = 4;
            this.btnCorona.UseVisualStyleBackColor = true;
            // 
            // btnPuente
            // 
            this.btnPuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuente.Location = new System.Drawing.Point(243, 3);
            this.btnPuente.Name = "btnPuente";
            this.btnPuente.Size = new System.Drawing.Size(42, 38);
            this.btnPuente.TabIndex = 5;
            this.btnPuente.UseVisualStyleBackColor = true;
            // 
            // btnProtesisParcial
            // 
            this.btnProtesisParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProtesisParcial.Location = new System.Drawing.Point(291, 3);
            this.btnProtesisParcial.Name = "btnProtesisParcial";
            this.btnProtesisParcial.Size = new System.Drawing.Size(42, 38);
            this.btnProtesisParcial.TabIndex = 6;
            this.btnProtesisParcial.UseVisualStyleBackColor = true;
            // 
            // btnSano
            // 
            this.btnSano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSano.Location = new System.Drawing.Point(339, 3);
            this.btnSano.Name = "btnSano";
            this.btnSano.Size = new System.Drawing.Size(42, 38);
            this.btnSano.TabIndex = 7;
            this.btnSano.UseVisualStyleBackColor = true;
            // 
            // frmEsquemaDental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(620, 335);
            this.Controls.Add(this.grpSimbologia);
            this.Controls.Add(this.grpCuraciones);
            this.Controls.Add(this.grpMixtas);
            this.Controls.Add(this.grpCaries);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEsquemaDental";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Esquema Dental";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpCaries.ResumeLayout(false);
            this.grpMixtas.ResumeLayout(false);
            this.grpCuraciones.ResumeLayout(false);
            this.grpSimbologia.ResumeLayout(false);
            this.pnlSimbologia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox grpCaries;
        private System.Windows.Forms.FlowLayoutPanel pnlCaries;
        private System.Windows.Forms.GroupBox grpMixtas;
        private System.Windows.Forms.FlowLayoutPanel pnlMixtas;
        private System.Windows.Forms.GroupBox grpCuraciones;
        private System.Windows.Forms.FlowLayoutPanel pnlCuraciones;
        private System.Windows.Forms.GroupBox grpSimbologia;
        private System.Windows.Forms.FlowLayoutPanel pnlSimbologia;
        private System.Windows.Forms.Button btnAusente;
        private System.Windows.Forms.Button btnExtraccion;
        private System.Windows.Forms.Button btnEndodoncia;
        private System.Windows.Forms.Button btnTratamiento;
        private System.Windows.Forms.Button btnCorona;
        private System.Windows.Forms.Button btnPuente;
        private System.Windows.Forms.Button btnProtesisParcial;
        private System.Windows.Forms.Button btnSano;
    }
}
