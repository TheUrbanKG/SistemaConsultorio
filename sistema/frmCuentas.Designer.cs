namespace sistema
{
    partial class frmCuentas
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
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentas));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAñadirUsuario = new FrameworkTest.SATAButton();
            this.btnModificarUsuario = new FrameworkTest.SATAButton();
            this.btnHistorial = new FrameworkTest.SATAButton();
            this.panelTopAccent = new System.Windows.Forms.Panel();
            this.btnDesabilitar = new FrameworkTest.SATAButton();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // sataPanel1
            // 
            this.sataPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sataPanel1.BackColor = System.Drawing.Color.LightSalmon;
            this.sataPanel1.BackColor2 = System.Drawing.Color.LightSalmon;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 10;
            borderRadius3.BottomRight = 10;
            borderRadius3.TopLeft = 10;
            borderRadius3.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius3;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.dgvUsuarios);
            this.sataPanel1.Location = new System.Drawing.Point(73, 79);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Padding = new System.Windows.Forms.Padding(5, 1, 5, 15);
            this.sataPanel1.Size = new System.Drawing.Size(765, 488);
            this.sataPanel1.TabIndex = 2;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.Nombre,
            this.Apellido,
            this.Rol,
            this.Status});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(5, 1);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 30;
            this.dgvUsuarios.RowTemplate.Height = 30;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(752, 472);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
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
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // btnAñadirUsuario
            // 
            this.btnAñadirUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAñadirUsuario.ButtonText = "Crear Nuevo Usuario";
            this.btnAñadirUsuario.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnAñadirUsuario.CheckedForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.CheckedImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAñadirUsuario.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAñadirUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirUsuario.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(79)))));
            this.btnAñadirUsuario.HoverForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.HoverImage = null;
            this.btnAñadirUsuario.HoverImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.HoverOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnAñadirUsuario.Image")));
            this.btnAñadirUsuario.ImageAutoCenter = true;
            this.btnAñadirUsuario.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnAñadirUsuario.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAñadirUsuario.ImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.IsToggleButton = false;
            this.btnAñadirUsuario.IsToggled = false;
            this.btnAñadirUsuario.Location = new System.Drawing.Point(886, 80);
            this.btnAñadirUsuario.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAñadirUsuario.Name = "btnAñadirUsuario";
            this.btnAñadirUsuario.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(79)))));
            this.btnAñadirUsuario.NormalForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.NormalOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.OutlineThickness = 2F;
            this.btnAñadirUsuario.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnAñadirUsuario.PressedForeColor = System.Drawing.Color.White;
            this.btnAñadirUsuario.PressedImageTint = System.Drawing.Color.White;
            this.btnAñadirUsuario.PressedOutline = System.Drawing.Color.Empty;
            this.btnAñadirUsuario.Rounding = new System.Windows.Forms.Padding(20);
            this.btnAñadirUsuario.Size = new System.Drawing.Size(240, 47);
            this.btnAñadirUsuario.TabIndex = 42;
            this.btnAñadirUsuario.TextAutoCenter = true;
            this.btnAñadirUsuario.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAñadirUsuario.Click += new System.EventHandler(this.btnAñadirUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarUsuario.ButtonText = "Modificar Permisos";
            this.btnModificarUsuario.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnModificarUsuario.CheckedForeColor = System.Drawing.Color.White;
            this.btnModificarUsuario.CheckedImageTint = System.Drawing.Color.White;
            this.btnModificarUsuario.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnModificarUsuario.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarUsuario.HoverBackground = System.Drawing.Color.DodgerBlue;
            this.btnModificarUsuario.HoverForeColor = System.Drawing.Color.White;
            this.btnModificarUsuario.HoverImage = null;
            this.btnModificarUsuario.HoverImageTint = System.Drawing.Color.White;
            this.btnModificarUsuario.HoverOutline = System.Drawing.Color.Empty;
            this.btnModificarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarUsuario.Image")));
            this.btnModificarUsuario.ImageAutoCenter = true;
            this.btnModificarUsuario.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnModificarUsuario.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnModificarUsuario.ImageTint = System.Drawing.Color.White;
            this.btnModificarUsuario.IsToggleButton = false;
            this.btnModificarUsuario.IsToggled = false;
            this.btnModificarUsuario.Location = new System.Drawing.Point(886, 175);
            this.btnModificarUsuario.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.NormalBackground = System.Drawing.Color.RoyalBlue;
            this.btnModificarUsuario.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModificarUsuario.NormalOutline = System.Drawing.Color.Empty;
            this.btnModificarUsuario.OutlineThickness = 2F;
            this.btnModificarUsuario.PressedBackground = System.Drawing.Color.DarkBlue;
            this.btnModificarUsuario.PressedForeColor = System.Drawing.Color.White;
            this.btnModificarUsuario.PressedImageTint = System.Drawing.Color.White;
            this.btnModificarUsuario.PressedOutline = System.Drawing.Color.Empty;
            this.btnModificarUsuario.Rounding = new System.Windows.Forms.Padding(20);
            this.btnModificarUsuario.Size = new System.Drawing.Size(240, 47);
            this.btnModificarUsuario.TabIndex = 43;
            this.btnModificarUsuario.TextAutoCenter = true;
            this.btnModificarUsuario.TextOffset = new System.Drawing.Point(0, 0);
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.ButtonText = "Ver Historial";
            this.btnHistorial.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnHistorial.CheckedForeColor = System.Drawing.Color.White;
            this.btnHistorial.CheckedImageTint = System.Drawing.Color.White;
            this.btnHistorial.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnHistorial.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHistorial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(90)))));
            this.btnHistorial.HoverForeColor = System.Drawing.Color.White;
            this.btnHistorial.HoverImage = null;
            this.btnHistorial.HoverImageTint = System.Drawing.Color.White;
            this.btnHistorial.HoverOutline = System.Drawing.Color.Empty;
            this.btnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorial.Image")));
            this.btnHistorial.ImageAutoCenter = true;
            this.btnHistorial.ImageExpand = new System.Drawing.Point(7, 7);
            this.btnHistorial.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHistorial.ImageTint = System.Drawing.Color.White;
            this.btnHistorial.IsToggleButton = false;
            this.btnHistorial.IsToggled = false;
            this.btnHistorial.Location = new System.Drawing.Point(886, 495);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.NormalBackground = System.Drawing.Color.Coral;
            this.btnHistorial.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistorial.NormalOutline = System.Drawing.Color.Empty;
            this.btnHistorial.OutlineThickness = 2F;
            this.btnHistorial.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(107)))), ((int)(((byte)(60)))));
            this.btnHistorial.PressedForeColor = System.Drawing.Color.White;
            this.btnHistorial.PressedImageTint = System.Drawing.Color.White;
            this.btnHistorial.PressedOutline = System.Drawing.Color.Empty;
            this.btnHistorial.Rounding = new System.Windows.Forms.Padding(20);
            this.btnHistorial.Size = new System.Drawing.Size(240, 47);
            this.btnHistorial.TabIndex = 45;
            this.btnHistorial.TextAutoCenter = true;
            this.btnHistorial.TextOffset = new System.Drawing.Point(0, 0);
            this.btnHistorial.Click += new System.EventHandler(this.sataButton1_Click);
            // 
            // panelTopAccent
            // 
            this.panelTopAccent.BackColor = System.Drawing.Color.Coral;
            this.panelTopAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccent.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccent.Name = "panelTopAccent";
            this.panelTopAccent.Size = new System.Drawing.Size(1173, 3);
            this.panelTopAccent.TabIndex = 101;
            // 
            // btnDesabilitar
            // 
            this.btnDesabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesabilitar.ButtonText = "Desabilitar/Habilitar Usuario";
            this.btnDesabilitar.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnDesabilitar.CheckedForeColor = System.Drawing.Color.White;
            this.btnDesabilitar.CheckedImageTint = System.Drawing.Color.White;
            this.btnDesabilitar.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnDesabilitar.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDesabilitar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesabilitar.HoverBackground = System.Drawing.Color.Firebrick;
            this.btnDesabilitar.HoverForeColor = System.Drawing.Color.White;
            this.btnDesabilitar.HoverImage = null;
            this.btnDesabilitar.HoverImageTint = System.Drawing.Color.White;
            this.btnDesabilitar.HoverOutline = System.Drawing.Color.Empty;
            this.btnDesabilitar.Image = null;
            this.btnDesabilitar.ImageAutoCenter = true;
            this.btnDesabilitar.ImageExpand = new System.Drawing.Point(5, 5);
            this.btnDesabilitar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDesabilitar.ImageTint = System.Drawing.Color.White;
            this.btnDesabilitar.IsToggleButton = false;
            this.btnDesabilitar.IsToggled = false;
            this.btnDesabilitar.Location = new System.Drawing.Point(886, 266);
            this.btnDesabilitar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnDesabilitar.Name = "btnDesabilitar";
            this.btnDesabilitar.NormalBackground = System.Drawing.Color.Crimson;
            this.btnDesabilitar.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDesabilitar.NormalOutline = System.Drawing.Color.Empty;
            this.btnDesabilitar.OutlineThickness = 2F;
            this.btnDesabilitar.PressedBackground = System.Drawing.Color.Firebrick;
            this.btnDesabilitar.PressedForeColor = System.Drawing.Color.White;
            this.btnDesabilitar.PressedImageTint = System.Drawing.Color.White;
            this.btnDesabilitar.PressedOutline = System.Drawing.Color.Empty;
            this.btnDesabilitar.Rounding = new System.Windows.Forms.Padding(20);
            this.btnDesabilitar.Size = new System.Drawing.Size(240, 47);
            this.btnDesabilitar.TabIndex = 44;
            this.btnDesabilitar.TextAutoCenter = true;
            this.btnDesabilitar.TextOffset = new System.Drawing.Point(0, 0);
            this.btnDesabilitar.Click += new System.EventHandler(this.btnDesabilitar_Click);
            // 
            // frmCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1173, 692);
            this.Controls.Add(this.panelTopAccent);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnDesabilitar);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnAñadirUsuario);
            this.Controls.Add(this.sataPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCuentas";
            this.Text = "frmCuentas";
            this.Load += new System.EventHandler(this.frmCuentas_Load);
            this.sataPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private FrameworkTest.SATAButton btnAñadirUsuario;
        private FrameworkTest.SATAButton btnModificarUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private FrameworkTest.SATAButton btnHistorial;
        private System.Windows.Forms.Panel panelTopAccent;
        private FrameworkTest.SATAButton btnDesabilitar;
    }
}