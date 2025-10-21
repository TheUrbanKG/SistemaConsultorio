namespace sistema
{
    partial class frmAgenda
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
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelTopAccent
            // 
            this.panelTopAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.panelTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccent.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccent.Name = "panelTopAccent";
            this.panelTopAccent.Size = new System.Drawing.Size(800, 3);
            this.panelTopAccent.TabIndex = 101;
            // 
            // frmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelTopAccent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgenda";
            this.Text = "frmAgenda";
            this.Load += new System.EventHandler(this.frmAgenda_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopAccent;
    }
}