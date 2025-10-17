namespace sistema
{
    partial class frmPacientes
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
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacientes));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.btnModificar = new FrameworkTest.SATAButton();
            this.btnAñadir = new FrameworkTest.SATAButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // sataPanel1
            // 
            this.sataPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.sataPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius5.BottomLeft = 10;
            borderRadius5.BottomRight = 10;
            borderRadius5.TopLeft = 10;
            borderRadius5.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius5;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.dgvPacientes);
            this.sataPanel1.Location = new System.Drawing.Point(55, 101);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Padding = new System.Windows.Forms.Padding(5, 1, 5, 15);
            this.sataPanel1.Size = new System.Drawing.Size(833, 460);
            this.sataPanel1.TabIndex = 1;
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToResizeColumns = false;
            this.dgvPacientes.AllowUserToResizeRows = false;
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dgvPacientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPacientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPacientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPacientes.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacientes.EnableHeadersVisualStyles = false;
            this.dgvPacientes.Location = new System.Drawing.Point(5, 1);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPacientes.RowHeadersVisible = false;
            this.dgvPacientes.RowHeadersWidth = 30;
            this.dgvPacientes.RowTemplate.Height = 30;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(823, 444);
            this.dgvPacientes.TabIndex = 0;
            this.dgvPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellDoubleClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.ButtonText = "Editar Paciente";
            this.btnModificar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnModificar.CheckedForeColor = System.Drawing.Color.White;
            this.btnModificar.CheckedImageTint = System.Drawing.Color.White;
            this.btnModificar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnModificar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(79)))));
            this.btnModificar.HoverForeColor = System.Drawing.Color.White;
            this.btnModificar.HoverImage = null;
            this.btnModificar.HoverImageTint = System.Drawing.Color.White;
            this.btnModificar.HoverOutline = System.Drawing.Color.Empty;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAutoCenter = true;
            this.btnModificar.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnModificar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnModificar.ImageTint = System.Drawing.Color.White;
            this.btnModificar.IsToggleButton = false;
            this.btnModificar.IsToggled = false;
            this.btnModificar.Location = new System.Drawing.Point(907, 190);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.NormalBackground = System.Drawing.Color.CornflowerBlue;
            this.btnModificar.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModificar.NormalOutline = System.Drawing.Color.Empty;
            this.btnModificar.OutlineThickness = 2F;
            this.btnModificar.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnModificar.PressedForeColor = System.Drawing.Color.White;
            this.btnModificar.PressedImageTint = System.Drawing.Color.White;
            this.btnModificar.PressedOutline = System.Drawing.Color.Empty;
            this.btnModificar.Rounding = new System.Windows.Forms.Padding(20);
            this.btnModificar.Size = new System.Drawing.Size(240, 47);
            this.btnModificar.TabIndex = 42;
            this.btnModificar.TextAutoCenter = true;
            this.btnModificar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAñadir.ButtonText = "Añadir Nuevo Paciente";
            this.btnAñadir.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnAñadir.CheckedForeColor = System.Drawing.Color.White;
            this.btnAñadir.CheckedImageTint = System.Drawing.Color.White;
            this.btnAñadir.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAñadir.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAñadir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(79)))));
            this.btnAñadir.HoverForeColor = System.Drawing.Color.White;
            this.btnAñadir.HoverImage = null;
            this.btnAñadir.HoverImageTint = System.Drawing.Color.White;
            this.btnAñadir.HoverOutline = System.Drawing.Color.Empty;
            this.btnAñadir.Image = ((System.Drawing.Image)(resources.GetObject("btnAñadir.Image")));
            this.btnAñadir.ImageAutoCenter = true;
            this.btnAñadir.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnAñadir.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAñadir.ImageTint = System.Drawing.Color.White;
            this.btnAñadir.IsToggleButton = false;
            this.btnAñadir.IsToggled = false;
            this.btnAñadir.Location = new System.Drawing.Point(907, 102);
            this.btnAñadir.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnAñadir.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAñadir.NormalOutline = System.Drawing.Color.Empty;
            this.btnAñadir.OutlineThickness = 2F;
            this.btnAñadir.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnAñadir.PressedForeColor = System.Drawing.Color.White;
            this.btnAñadir.PressedImageTint = System.Drawing.Color.White;
            this.btnAñadir.PressedOutline = System.Drawing.Color.Empty;
            this.btnAñadir.Rounding = new System.Windows.Forms.Padding(20);
            this.btnAñadir.Size = new System.Drawing.Size(240, 47);
            this.btnAñadir.TabIndex = 41;
            this.btnAñadir.TextAutoCenter = true;
            this.btnAñadir.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(68)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBuscar.Location = new System.Drawing.Point(60, 59);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(422, 23);
            this.txtBuscar.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(57, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Buscar paciente";
            // 
            // frmPacientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1163, 601);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.sataPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPacientes";
            this.Text = "frmPacientes";
            this.Load += new System.EventHandler(this.frmPacientes_Load);
            this.sataPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private FrameworkTest.SATAButton btnAñadir;
        private FrameworkTest.SATAButton btnModificar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
    }
}