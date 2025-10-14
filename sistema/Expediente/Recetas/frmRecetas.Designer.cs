namespace sistema.Expediente.Recetas
{
    partial class frmRecetas
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNuevaReceta = new FrameworkTest.SATAButton();
            this.flpRecetas = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel2.Controls.Add(this.btnNuevaReceta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 84);
            this.panel2.TabIndex = 1;
            // 
            // btnNuevaReceta
            // 
            this.btnNuevaReceta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaReceta.ButtonText = "Nueva Receta";
            this.btnNuevaReceta.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnNuevaReceta.CheckedForeColor = System.Drawing.Color.White;
            this.btnNuevaReceta.CheckedImageTint = System.Drawing.Color.White;
            this.btnNuevaReceta.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnNuevaReceta.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNuevaReceta.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaReceta.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnNuevaReceta.HoverForeColor = System.Drawing.Color.White;
            this.btnNuevaReceta.HoverImage = null;
            this.btnNuevaReceta.HoverImageTint = System.Drawing.Color.White;
            this.btnNuevaReceta.HoverOutline = System.Drawing.Color.Empty;
            this.btnNuevaReceta.Image = null;
            this.btnNuevaReceta.ImageAutoCenter = true;
            this.btnNuevaReceta.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnNuevaReceta.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNuevaReceta.ImageTint = System.Drawing.Color.White;
            this.btnNuevaReceta.IsToggleButton = false;
            this.btnNuevaReceta.IsToggled = false;
            this.btnNuevaReceta.Location = new System.Drawing.Point(1021, 24);
            this.btnNuevaReceta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNuevaReceta.Name = "btnNuevaReceta";
            this.btnNuevaReceta.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnNuevaReceta.NormalForeColor = System.Drawing.Color.Black;
            this.btnNuevaReceta.NormalOutline = System.Drawing.Color.Empty;
            this.btnNuevaReceta.OutlineThickness = 2F;
            this.btnNuevaReceta.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnNuevaReceta.PressedForeColor = System.Drawing.Color.White;
            this.btnNuevaReceta.PressedImageTint = System.Drawing.Color.White;
            this.btnNuevaReceta.PressedOutline = System.Drawing.Color.Empty;
            this.btnNuevaReceta.Rounding = new System.Windows.Forms.Padding(5);
            this.btnNuevaReceta.Size = new System.Drawing.Size(121, 37);
            this.btnNuevaReceta.TabIndex = 1;
            this.btnNuevaReceta.TextAutoCenter = true;
            this.btnNuevaReceta.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // flpRecetas
            // 
            this.flpRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRecetas.Location = new System.Drawing.Point(0, 84);
            this.flpRecetas.Name = "flpRecetas";
            this.flpRecetas.Size = new System.Drawing.Size(1180, 429);
            this.flpRecetas.TabIndex = 2;
            // 
            // frmRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1180, 513);
            this.Controls.Add(this.flpRecetas);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecetas";
            this.Text = "frmRecetas";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private FrameworkTest.SATAButton btnNuevaReceta;
        private System.Windows.Forms.FlowLayoutPanel flpRecetas;
    }
}