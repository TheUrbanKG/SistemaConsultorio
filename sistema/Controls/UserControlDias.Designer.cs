namespace sistema
{
    partial class UserControlDias
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDias = new System.Windows.Forms.Label();
            this.panelDot = new System.Windows.Forms.Panel();
            this.lblCitasInfo = new System.Windows.Forms.Label();
            this.lblHoy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.BackColor = System.Drawing.Color.Transparent;
            this.lblDias.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDias.Location = new System.Drawing.Point(10, 8);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(28, 21);
            this.lblDias.TabIndex = 0;
            this.lblDias.Text = "00";
            // 
            // panelDot
            // 
            this.panelDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.panelDot.Location = new System.Drawing.Point(134, 12);
            this.panelDot.Name = "panelDot";
            this.panelDot.Size = new System.Drawing.Size(8, 8);
            this.panelDot.TabIndex = 1;
            this.panelDot.Visible = false;
            // 
            // lblCitasInfo
            // 
            this.lblCitasInfo.AutoSize = true;
            this.lblCitasInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCitasInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.lblCitasInfo.Location = new System.Drawing.Point(10, 42);
            this.lblCitasInfo.Name = "lblCitasInfo";
            this.lblCitasInfo.Size = new System.Drawing.Size(43, 13);
            this.lblCitasInfo.TabIndex = 2;
            this.lblCitasInfo.Text = "● 1 cita";
            this.lblCitasInfo.Visible = false;
            // 
            // lblHoy
            // 
            this.lblHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblHoy.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.lblHoy.Location = new System.Drawing.Point(42, 10);
            this.lblHoy.Name = "lblHoy";
            this.lblHoy.Size = new System.Drawing.Size(34, 16);
            this.lblHoy.TabIndex = 3;
            this.lblHoy.Text = "HOY";
            this.lblHoy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHoy.Visible = false;
            // 
            // UserControlDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblHoy);
            this.Controls.Add(this.lblCitasInfo);
            this.Controls.Add(this.panelDot);
            this.Controls.Add(this.lblDias);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "UserControlDias";
            this.Size = new System.Drawing.Size(154, 68);
            this.Load += new System.EventHandler(this.UserControlDias_Load);
            this.Click += new System.EventHandler(this.UserControlDias_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Panel panelDot;
        private System.Windows.Forms.Label lblCitasInfo;
        private System.Windows.Forms.Label lblHoy;
    }
}
