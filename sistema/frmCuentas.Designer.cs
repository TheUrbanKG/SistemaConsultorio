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
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnDesabilitar = new FrameworkTest.SATAButton();
            this.sataButton1 = new FrameworkTest.SATAButton();
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
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius2;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.dgvUsuarios);
            this.sataPanel1.Location = new System.Drawing.Point(69, 129);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.Nombre,
            this.Apellido,
            this.Rol,
            this.Status});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(5, 1);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            this.btnAñadirUsuario.Location = new System.Drawing.Point(886, 119);
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
            this.btnModificarUsuario.Location = new System.Drawing.Point(886, 208);
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
            this.btnDesabilitar.Location = new System.Drawing.Point(886, 292);
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
            // 
            // sataButton1
            // 
            this.sataButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sataButton1.ButtonText = "Ver Historial";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(90)))));
            this.sataButton1.HoverForeColor = System.Drawing.Color.White;
            this.sataButton1.HoverImage = null;
            this.sataButton1.HoverImageTint = System.Drawing.Color.White;
            this.sataButton1.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton1.Image = ((System.Drawing.Image)(resources.GetObject("sataButton1.Image")));
            this.sataButton1.ImageAutoCenter = true;
            this.sataButton1.ImageExpand = new System.Drawing.Point(7, 7);
            this.sataButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.sataButton1.ImageTint = System.Drawing.Color.White;
            this.sataButton1.IsToggleButton = false;
            this.sataButton1.IsToggled = false;
            this.sataButton1.Location = new System.Drawing.Point(886, 520);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.Coral;
            this.sataButton1.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(107)))), ((int)(((byte)(60)))));
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(20);
            this.sataButton1.Size = new System.Drawing.Size(240, 47);
            this.sataButton1.TabIndex = 45;
            this.sataButton1.TextAutoCenter = true;
            this.sataButton1.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // frmCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1173, 692);
            this.Controls.Add(this.sataButton1);
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
        private FrameworkTest.SATAButton btnDesabilitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private FrameworkTest.SATAButton sataButton1;
    }
}