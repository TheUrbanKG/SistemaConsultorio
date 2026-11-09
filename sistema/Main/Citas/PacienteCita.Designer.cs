namespace sistema
{
    public partial class PacienteCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacienteCita));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelNo = new System.Windows.Forms.Panel();
            this.panelSi = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.panelConocido = new System.Windows.Forms.Panel();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.RichTextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.picCalendario = new System.Windows.Forms.PictureBox();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellidoPa = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.panelDesconocido = new System.Windows.Forms.Panel();
            this.txtDetallesDesconocido = new System.Windows.Forms.RichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cbGrupoSanguineoDesconocido = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDireccionDesconocido = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTelefonoDesconocido = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtOcupacionDesconocido = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.dtpFechaNacimientoDesconocido = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNombreDesconocido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelConocido.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendario)).BeginInit();
            this.panelDesconocido.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.labelSubtitulo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 80);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCerrar.Location = new System.Drawing.Point(180, 22);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 36);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(268, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 36);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.labelSubtitulo.Location = new System.Drawing.Point(14, 38);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(155, 13);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Asociar paciente a nueva cita";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Registrar Paciente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panelNo);
            this.panel2.Controls.Add(this.panelSi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbNo);
            this.panel2.Controls.Add(this.rbSi);
            this.panel2.Location = new System.Drawing.Point(16, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 68);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorde_Paint);
            // 
            // panelNo
            // 
            this.panelNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelNo.Location = new System.Drawing.Point(176, 56);
            this.panelNo.Name = "panelNo";
            this.panelNo.Size = new System.Drawing.Size(145, 3);
            this.panelNo.TabIndex = 4;
            // 
            // panelSi
            // 
            this.panelSi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelSi.Location = new System.Drawing.Point(16, 56);
            this.panelSi.Name = "panelSi";
            this.panelSi.Size = new System.Drawing.Size(130, 3);
            this.panelSi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "¿Es un paciente conocido?";
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.rbNo.Location = new System.Drawing.Point(176, 32);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(122, 19);
            this.rbNo.TabIndex = 2;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No (Desconocido)";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.rbSi.Location = new System.Drawing.Point(16, 32);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(102, 19);
            this.rbSi.TabIndex = 1;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Sí (Registrado)";
            this.rbSi.UseVisualStyleBackColor = true;
            this.rbSi.CheckedChanged += new System.EventHandler(this.rbSi_CheckedChanged);
            // 
            // panelConocido
            // 
            this.panelConocido.BackColor = System.Drawing.Color.White;
            this.panelConocido.Controls.Add(this.dtpFechaNacimiento);
            this.panelConocido.Controls.Add(this.label16);
            this.panelConocido.Controls.Add(this.txtDetalles);
            this.panelConocido.Controls.Add(this.txtCorreo);
            this.panelConocido.Controls.Add(this.label15);
            this.panelConocido.Controls.Add(this.label13);
            this.panelConocido.Controls.Add(this.cbGrupoSanguineo);
            this.panelConocido.Controls.Add(this.txtDireccion);
            this.panelConocido.Controls.Add(this.label11);
            this.panelConocido.Controls.Add(this.txtOcupacion);
            this.panelConocido.Controls.Add(this.label10);
            this.panelConocido.Controls.Add(this.txtTelefono);
            this.panelConocido.Controls.Add(this.label8);
            this.panelConocido.Controls.Add(this.panel3);
            this.panelConocido.Controls.Add(this.picCalendario);
            this.panelConocido.Controls.Add(this.txtFechaNacimiento);
            this.panelConocido.Controls.Add(this.label4);
            this.panelConocido.Controls.Add(this.txtApellido);
            this.panelConocido.Controls.Add(this.lblApellidoPa);
            this.panelConocido.Controls.Add(this.txtNombre);
            this.panelConocido.Controls.Add(this.lblNombre);
            this.panelConocido.Controls.Add(this.txtCedula);
            this.panelConocido.Controls.Add(this.lblCedula);
            this.panelConocido.Location = new System.Drawing.Point(16, 175);
            this.panelConocido.Name = "panelConocido";
            this.panelConocido.Size = new System.Drawing.Size(348, 770);
            this.panelConocido.TabIndex = 2;
            this.panelConocido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorde_Paint);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(16, 218);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(316, 24);
            this.dtpFechaNacimiento.TabIndex = 7;
            this.dtpFechaNacimiento.Visible = false;
            this.dtpFechaNacimiento.CloseUp += new System.EventHandler(this.dtpFechaNacimiento_CloseUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label16.Location = new System.Drawing.Point(16, 626);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Detalles y Observaciones";
            // 
            // txtDetalles
            // 
            this.txtDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetalles.Location = new System.Drawing.Point(16, 644);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(316, 95);
            this.txtDetalles.TabIndex = 22;
            this.txtDetalles.Text = "";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorreo.Location = new System.Drawing.Point(16, 588);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(316, 24);
            this.txtCorreo.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label15.Location = new System.Drawing.Point(16, 570);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 15);
            this.label15.TabIndex = 19;
            this.label15.Text = "Correo Electrónico";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label13.Location = new System.Drawing.Point(16, 514);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 15);
            this.label13.TabIndex = 17;
            this.label13.Text = "Grupo Sanguíneo";
            // 
            // cbGrupoSanguineo
            // 
            this.cbGrupoSanguineo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupoSanguineo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbGrupoSanguineo.FormattingEnabled = true;
            this.cbGrupoSanguineo.Items.AddRange(new object[] {
            "",
            "O-",
            "A-",
            "B-",
            "AB-",
            "O+",
            "A+",
            "B+",
            "AB+"});
            this.cbGrupoSanguineo.Location = new System.Drawing.Point(16, 532);
            this.cbGrupoSanguineo.Name = "cbGrupoSanguineo";
            this.cbGrupoSanguineo.Size = new System.Drawing.Size(316, 25);
            this.cbGrupoSanguineo.TabIndex = 18;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location = new System.Drawing.Point(16, 456);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(316, 46);
            this.txtDireccion.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label11.Location = new System.Drawing.Point(16, 438);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "Dirección";
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtOcupacion.Location = new System.Drawing.Point(16, 344);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(316, 24);
            this.txtOcupacion.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label10.Location = new System.Drawing.Point(16, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Ocupación";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location = new System.Drawing.Point(16, 400);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(316, 24);
            this.txtTelefono.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label8.Location = new System.Drawing.Point(16, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Teléfono";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Location = new System.Drawing.Point(16, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 60);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorde_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label7.Location = new System.Drawing.Point(10, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Género *";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioButton1.Location = new System.Drawing.Point(140, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Femenino";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioButton2.Location = new System.Drawing.Point(14, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Masculino";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // picCalendario
            // 
            this.picCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.picCalendario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCalendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendario.Image = global::sistema.Properties.Resources.calendario;
            this.picCalendario.Location = new System.Drawing.Point(302, 186);
            this.picCalendario.Name = "picCalendario";
            this.picCalendario.Size = new System.Drawing.Size(30, 24);
            this.picCalendario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCalendario.TabIndex = 6;
            this.picCalendario.TabStop = false;
            this.picCalendario.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFechaNacimiento.Location = new System.Drawing.Point(16, 186);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.ReadOnly = true;
            this.txtFechaNacimiento.Size = new System.Drawing.Size(280, 24);
            this.txtFechaNacimiento.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(16, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Nacimiento *";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellido.Location = new System.Drawing.Point(16, 134);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(316, 24);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.Enter += new System.EventHandler(this.txtApellidoPa_Enter);
            this.txtApellido.Leave += new System.EventHandler(this.txtApellidoPa_Leave);
            // 
            // lblApellidoPa
            // 
            this.lblApellidoPa.AutoSize = true;
            this.lblApellidoPa.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblApellidoPa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblApellidoPa.Location = new System.Drawing.Point(16, 116);
            this.lblApellidoPa.Name = "lblApellidoPa";
            this.lblApellidoPa.Size = new System.Drawing.Size(59, 15);
            this.lblApellidoPa.TabIndex = 2;
            this.lblApellidoPa.Text = "Apellido *";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(16, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 24);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNombre.Location = new System.Drawing.Point(16, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCedula.Location = new System.Drawing.Point(16, 30);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(316, 24);
            this.txtCedula.TabIndex = 0;
            this.txtCedula.Enter += new System.EventHandler(this.txtCedula_Enter);
            this.txtCedula.Leave += new System.EventHandler(this.txtCedula_Leave);
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCedula.Location = new System.Drawing.Point(16, 12);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(51, 15);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cédula *";
            // 
            // panelDesconocido
            // 
            this.panelDesconocido.BackColor = System.Drawing.Color.White;
            this.panelDesconocido.Controls.Add(this.txtDetallesDesconocido);
            this.panelDesconocido.Controls.Add(this.label30);
            this.panelDesconocido.Controls.Add(this.cbGrupoSanguineoDesconocido);
            this.panelDesconocido.Controls.Add(this.label28);
            this.panelDesconocido.Controls.Add(this.txtDireccionDesconocido);
            this.panelDesconocido.Controls.Add(this.label22);
            this.panelDesconocido.Controls.Add(this.txtTelefonoDesconocido);
            this.panelDesconocido.Controls.Add(this.label21);
            this.panelDesconocido.Controls.Add(this.txtOcupacionDesconocido);
            this.panelDesconocido.Controls.Add(this.label23);
            this.panelDesconocido.Controls.Add(this.panel6);
            this.panelDesconocido.Controls.Add(this.dtpFechaNacimientoDesconocido);
            this.panelDesconocido.Controls.Add(this.label17);
            this.panelDesconocido.Controls.Add(this.txtNombreDesconocido);
            this.panelDesconocido.Controls.Add(this.label1);
            this.panelDesconocido.Location = new System.Drawing.Point(16, 175);
            this.panelDesconocido.Name = "panelDesconocido";
            this.panelDesconocido.Size = new System.Drawing.Size(348, 680);
            this.panelDesconocido.TabIndex = 3;
            this.panelDesconocido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorde_Paint);
            // 
            // txtDetallesDesconocido
            // 
            this.txtDetallesDesconocido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetallesDesconocido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetallesDesconocido.Location = new System.Drawing.Point(16, 542);
            this.txtDetallesDesconocido.Name = "txtDetallesDesconocido";
            this.txtDetallesDesconocido.Size = new System.Drawing.Size(316, 105);
            this.txtDetallesDesconocido.TabIndex = 14;
            this.txtDetallesDesconocido.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label30.Location = new System.Drawing.Point(16, 524);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(138, 15);
            this.label30.TabIndex = 13;
            this.label30.Text = "Detalles y Observaciones";
            // 
            // cbGrupoSanguineoDesconocido
            // 
            this.cbGrupoSanguineoDesconocido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupoSanguineoDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbGrupoSanguineoDesconocido.FormattingEnabled = true;
            this.cbGrupoSanguineoDesconocido.Items.AddRange(new object[] {
            "",
            "O-",
            "A-",
            "B-",
            "AB-",
            "O+",
            "A+",
            "B+",
            "AB+"});
            this.cbGrupoSanguineoDesconocido.Location = new System.Drawing.Point(16, 486);
            this.cbGrupoSanguineoDesconocido.Name = "cbGrupoSanguineoDesconocido";
            this.cbGrupoSanguineoDesconocido.Size = new System.Drawing.Size(316, 25);
            this.cbGrupoSanguineoDesconocido.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label28.Location = new System.Drawing.Point(16, 468);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 15);
            this.label28.TabIndex = 11;
            this.label28.Text = "Grupo Sanguíneo";
            // 
            // txtDireccionDesconocido
            // 
            this.txtDireccionDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccionDesconocido.Location = new System.Drawing.Point(16, 410);
            this.txtDireccionDesconocido.Multiline = true;
            this.txtDireccionDesconocido.Name = "txtDireccionDesconocido";
            this.txtDireccionDesconocido.Size = new System.Drawing.Size(316, 46);
            this.txtDireccionDesconocido.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label22.Location = new System.Drawing.Point(16, 392);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 9;
            this.label22.Text = "Dirección";
            // 
            // txtTelefonoDesconocido
            // 
            this.txtTelefonoDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefonoDesconocido.Location = new System.Drawing.Point(16, 354);
            this.txtTelefonoDesconocido.Name = "txtTelefonoDesconocido";
            this.txtTelefonoDesconocido.Size = new System.Drawing.Size(316, 24);
            this.txtTelefonoDesconocido.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label21.Location = new System.Drawing.Point(16, 336);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 15);
            this.label21.TabIndex = 7;
            this.label21.Text = "Teléfono";
            // 
            // txtOcupacionDesconocido
            // 
            this.txtOcupacionDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtOcupacionDesconocido.Location = new System.Drawing.Point(16, 298);
            this.txtOcupacionDesconocido.Name = "txtOcupacionDesconocido";
            this.txtOcupacionDesconocido.Size = new System.Drawing.Size(316, 24);
            this.txtOcupacionDesconocido.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label23.Location = new System.Drawing.Point(16, 280);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 15);
            this.label23.TabIndex = 5;
            this.label23.Text = "Ocupación";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.radioButton3);
            this.panel6.Controls.Add(this.radioButton4);
            this.panel6.Location = new System.Drawing.Point(16, 206);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(316, 60);
            this.panel6.TabIndex = 4;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorde_Paint);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label18.Location = new System.Drawing.Point(10, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Género *";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioButton3.Location = new System.Drawing.Point(140, 30);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(78, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Femenino";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioButton4.Location = new System.Drawing.Point(14, 30);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(80, 19);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Masculino";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimientoDesconocido
            // 
            this.dtpFechaNacimientoDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaNacimientoDesconocido.Location = new System.Drawing.Point(16, 168);
            this.dtpFechaNacimientoDesconocido.Name = "dtpFechaNacimientoDesconocido";
            this.dtpFechaNacimientoDesconocido.Size = new System.Drawing.Size(316, 24);
            this.dtpFechaNacimientoDesconocido.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label17.Location = new System.Drawing.Point(16, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(186, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "Fecha de Nacimiento (Estimada) *";
            // 
            // txtNombreDesconocido
            // 
            this.txtNombreDesconocido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreDesconocido.Location = new System.Drawing.Point(16, 30);
            this.txtNombreDesconocido.Name = "txtNombreDesconocido";
            this.txtNombreDesconocido.Size = new System.Drawing.Size(316, 24);
            this.txtNombreDesconocido.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre o Identificador *";
            // 
            // PacienteCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(380, 720);
            this.Controls.Add(this.panelDesconocido);
            this.Controls.Add(this.panelConocido);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PacienteCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Paciente";
            this.Load += new System.EventHandler(this.PacienteCita_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelConocido.ResumeLayout(false);
            this.panelConocido.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendario)).EndInit();
            this.panelDesconocido.ResumeLayout(false);
            this.panelDesconocido.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelNo;
        private System.Windows.Forms.Panel panelSi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbSi;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Panel panelConocido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellidoPa;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.PictureBox picCalendario;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtOcupacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbGrupoSanguineo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox txtDetalles;
        private System.Windows.Forms.Panel panelDesconocido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreDesconocido;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimientoDesconocido;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox txtOcupacionDesconocido;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTelefonoDesconocido;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDireccionDesconocido;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbGrupoSanguineoDesconocido;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RichTextBox txtDetallesDesconocido;
        private System.Windows.Forms.Label label30;
    }
}
