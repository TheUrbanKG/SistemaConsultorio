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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacientes));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificar = new FrameworkTest.SATAButton();
            this.btnAñadir = new FrameworkTest.SATAButton();
            this.txtBuscar = new SATATextBox();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // sataPanel1
            // 
            this.sataPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(157)))), ((int)(((byte)(69)))));
            this.sataPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(79)))));
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
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
            this.dgvPacientes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPacientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPacientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPacientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cedula,
            this.Nombre,
            this.Apellido,
            this.EdadActual,
            this.Genero,
            this.Telefono});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPacientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacientes.EnableHeadersVisualStyles = false;
            this.dgvPacientes.Location = new System.Drawing.Point(5, 1);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPacientes.RowHeadersVisible = false;
            this.dgvPacientes.RowHeadersWidth = 30;
            this.dgvPacientes.RowTemplate.Height = 30;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(823, 444);
            this.dgvPacientes.TabIndex = 0;
            this.dgvPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // EdadActual
            // 
            this.EdadActual.HeaderText = "EdadActual";
            this.EdadActual.Name = "EdadActual";
            this.EdadActual.ReadOnly = true;
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Genero";
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
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
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(157)))), ((int)(((byte)(69)))));
            this.txtBuscar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(197)))), ((int)(((byte)(99)))));
            this.txtBuscar.BorderRadius = 15;
            this.txtBuscar.BorderSize = 1;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBuscar.Icon = ((System.Drawing.Image)(resources.GetObject("txtBuscar.Icon")));
            this.txtBuscar.IconSize = new System.Drawing.Size(20, 20);
            this.txtBuscar.Location = new System.Drawing.Point(55, 41);
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = false;
            this.txtBuscar.PlaceholderColor = System.Drawing.Color.Silver;
            this.txtBuscar.PlaceholderText = "Buscar Paciente";
            this.txtBuscar.Size = new System.Drawing.Size(574, 36);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "sataTextBox1";
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderlinedStyle = false;
            // 
            // frmPacientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1163, 601);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.sataPanel1);
            this.Controls.Add(this.txtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPacientes";
            this.Text = "frmPacientes";
            this.Load += new System.EventHandler(this.frmPacientes_Load);
            this.sataPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATATextBox txtBuscar;
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private FrameworkTest.SATAButton btnAñadir;
        private FrameworkTest.SATAButton btnModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdadActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}