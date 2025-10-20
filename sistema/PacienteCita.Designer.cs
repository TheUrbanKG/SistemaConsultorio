namespace sistema
{
    partial class PacienteCita
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelTipo = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbConocido = new System.Windows.Forms.RadioButton();
            this.rbDesconocido = new System.Windows.Forms.RadioButton();
            this.panelConocido = new System.Windows.Forms.Panel();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.lblApellidoPa = new System.Windows.Forms.Label();
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.lblApellidoMa = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.cbGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.lblGrupoSanguineo = new System.Windows.Forms.Label();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.panelDesconocido = new System.Windows.Forms.Panel();
            this.txtEdadDes = new System.Windows.Forms.TextBox();
            this.lblEdadDes = new System.Windows.Forms.Label();
            this.lblGeneroDes = new System.Windows.Forms.Label();
            this.rbMasculinoDes = new System.Windows.Forms.RadioButton();
            this.rbFemeninoDes = new System.Windows.Forms.RadioButton();
            this.txtOcupacionDes = new System.Windows.Forms.TextBox();
            this.lblOcupacionDes = new System.Windows.Forms.Label();
            this.txtDireccionDes = new System.Windows.Forms.TextBox();
            this.lblDireccionDes = new System.Windows.Forms.Label();
            this.cbGrupoSanguineoDes = new System.Windows.Forms.ComboBox();
            this.lblGrupoSanguineoDes = new System.Windows.Forms.Label();
            this.txtDetallesDes = new System.Windows.Forms.TextBox();
            this.lblDetallesDes = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.btnGuardar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(254, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agendar Cita";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(110)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(400, 20);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 32);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // panelTipo
            // 
            this.panelTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panelTipo.Controls.Add(this.lblTipo);
            this.panelTipo.Controls.Add(this.rbConocido);
            this.panelTipo.Controls.Add(this.rbDesconocido);
            this.panelTipo.Location = new System.Drawing.Point(20, 80);
            this.panelTipo.Name = "panelTipo";
            this.panelTipo.Size = new System.Drawing.Size(460, 50);
            this.panelTipo.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(10, 15);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de paciente:";
            // 
            // rbConocido
            // 
            this.rbConocido.ForeColor = System.Drawing.Color.White;
            this.rbConocido.Location = new System.Drawing.Point(150, 15);
            this.rbConocido.Name = "rbConocido";
            this.rbConocido.Size = new System.Drawing.Size(104, 24);
            this.rbConocido.TabIndex = 1;
            this.rbConocido.Text = "Conocido";
            // 
            // rbDesconocido
            // 
            this.rbDesconocido.ForeColor = System.Drawing.Color.White;
            this.rbDesconocido.Location = new System.Drawing.Point(260, 14);
            this.rbDesconocido.Name = "rbDesconocido";
            this.rbDesconocido.Size = new System.Drawing.Size(104, 24);
            this.rbDesconocido.TabIndex = 2;
            this.rbDesconocido.Text = "Desconocido";
            // 
            // panelConocido
            // 
            this.panelConocido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panelConocido.AutoScroll = true;
            this.panelConocido.Location = new System.Drawing.Point(20, 140);
            this.panelConocido.Name = "panelConocido";
            this.panelConocido.Size = new System.Drawing.Size(460, 500);
            this.panelConocido.TabIndex = 2;
            // 
            // txtCedula
            // 
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtCedula.Location = new System.Drawing.Point(20, 40);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(150, 20);
            this.txtCedula.TabIndex = 0;
            // 
            // lblCedula
            // 
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblCedula.ForeColor = System.Drawing.Color.White;
            this.lblCedula.Location = new System.Drawing.Point(20, 20);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(100, 23);
            this.lblCedula.TabIndex = 1;
            this.lblCedula.Text = "Cédula:";
            // 
            // txtNombre
            // 
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNombre.Location = new System.Drawing.Point(20, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(20, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtApellidoPa
            // 
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.txtApellidoPa.Location = new System.Drawing.Point(20, 160);
            this.txtApellidoPa.Name = "txtApellidoPa";
            this.txtApellidoPa.Size = new System.Drawing.Size(150, 20);
            this.txtApellidoPa.TabIndex = 4;
            // 
            // lblApellidoPa
            // 
            this.lblApellidoPa = new System.Windows.Forms.Label();
            this.lblApellidoPa.ForeColor = System.Drawing.Color.White;
            this.lblApellidoPa.Location = new System.Drawing.Point(20, 140);
            this.lblApellidoPa.Name = "lblApellidoPa";
            this.lblApellidoPa.Size = new System.Drawing.Size(100, 23);
            this.lblApellidoPa.TabIndex = 5;
            this.lblApellidoPa.Text = "Apellido Paterno:";
            // 
            // txtApellidoMa
            // 
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.txtApellidoMa.Location = new System.Drawing.Point(20, 220);
            this.txtApellidoMa.Name = "txtApellidoMa";
            this.txtApellidoMa.Size = new System.Drawing.Size(150, 20);
            this.txtApellidoMa.TabIndex = 6;
            // 
            // lblApellidoMa
            // 
            this.lblApellidoMa = new System.Windows.Forms.Label();
            this.lblApellidoMa.ForeColor = System.Drawing.Color.White;
            this.lblApellidoMa.Location = new System.Drawing.Point(20, 200);
            this.lblApellidoMa.Name = "lblApellidoMa";
            this.lblApellidoMa.Size = new System.Drawing.Size(100, 23);
            this.lblApellidoMa.TabIndex = 7;
            this.lblApellidoMa.Text = "Apellido Materno:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(20, 280);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 8;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.White;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(20, 260);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(200, 23);
            this.lblFechaNacimiento.TabIndex = 9;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // lblGenero
            // 
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            this.lblGenero.Location = new System.Drawing.Point(20, 320);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(60, 23);
            this.lblGenero.TabIndex = 10;
            this.lblGenero.Text = "Género:";
            // 
            // rbMasculino
            // 
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.rbMasculino.ForeColor = System.Drawing.Color.White;
            this.rbMasculino.Location = new System.Drawing.Point(90, 320);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(80, 24);
            this.rbMasculino.TabIndex = 11;
            this.rbMasculino.Text = "Masculino";
            // 
            // rbFemenino
            // 
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.rbFemenino.ForeColor = System.Drawing.Color.White;
            this.rbFemenino.Location = new System.Drawing.Point(180, 320);
            this.rbFemenino.Name = "rbFemenino";
            this.rbFemenino.Size = new System.Drawing.Size(80, 24);
            this.rbFemenino.TabIndex = 12;
            this.rbFemenino.Text = "Femenino";
            // 
            // txtOcupacion
            // 
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.txtOcupacion.Location = new System.Drawing.Point(20, 380);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(180, 20);
            this.txtOcupacion.TabIndex = 15;
            // 
            // lblOcupacion
            // 
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.lblOcupacion.Location = new System.Drawing.Point(20, 360);
            this.lblOcupacion.Size = new System.Drawing.Size(80, 23);
            // 
            // txtTelefono
            // 
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtTelefono.Location = new System.Drawing.Point(20, 440);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 20);
            this.txtTelefono.TabIndex = 19;
            // 
            // lblTelefono
            // 
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(20, 420);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtDireccion.Location = new System.Drawing.Point(220, 380);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(180, 20);
            this.txtDireccion.TabIndex = 21;
            // 
            // lblDireccion
            // 
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblDireccion.Location = new System.Drawing.Point(220, 360);
            this.lblDireccion.Size = new System.Drawing.Size(80, 23);
            // 
            // cbGrupoSanguineo
            // 
            this.cbGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.cbGrupoSanguineo.Location = new System.Drawing.Point(20, 480);
            this.cbGrupoSanguineo.Name = "cbGrupoSanguineo";
            this.cbGrupoSanguineo.Size = new System.Drawing.Size(121, 21);
            this.cbGrupoSanguineo.TabIndex = 25;
            // 
            // lblGrupoSanguineo
            // 
            this.lblGrupoSanguineo = new System.Windows.Forms.Label();
            this.lblGrupoSanguineo.ForeColor = System.Drawing.Color.White;
            this.lblGrupoSanguineo.Location = new System.Drawing.Point(20, 460);
            this.lblGrupoSanguineo.Name = "lblGrupoSanguineo";
            this.lblGrupoSanguineo.Size = new System.Drawing.Size(100, 23);
            this.lblGrupoSanguineo.Text = "Grupo Sanguíneo:";
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtCorreoElectronico.Location = new System.Drawing.Point(220, 560);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(180, 20);
            this.txtCorreoElectronico.TabIndex = 29;
            // 
            // lblCorreoElectronico
            // 
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.lblCorreoElectronico.Location = new System.Drawing.Point(220, 540);
            this.lblCorreoElectronico.Size = new System.Drawing.Size(120, 23);
            // 
            // txtDetalles
            // 
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.txtDetalles.Location = new System.Drawing.Point(20, 620);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(380, 60);
            this.txtDetalles.TabIndex = 31;
            this.txtDetalles.Multiline = true;
            // 
            // lblDetalles
            // 
            this.lblDetalles = new System.Windows.Forms.Label();
            this.lblDetalles.Location = new System.Drawing.Point(20, 600);
            this.lblDetalles.Size = new System.Drawing.Size(80, 23);
            // 
            // panelDesconocido
            // 
            this.panelDesconocido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panelDesconocido.AutoScroll = true;
            this.panelDesconocido.Location = new System.Drawing.Point(20, 140);
            this.panelDesconocido.Name = "panelDesconocido";
            this.panelDesconocido.Size = new System.Drawing.Size(460, 350);
            this.panelDesconocido.TabIndex = 3;
            // 
            // txtEdadDes
            // 
            this.txtEdadDes = new System.Windows.Forms.TextBox();
            this.txtEdadDes.Location = new System.Drawing.Point(20, 40);
            this.txtEdadDes.Name = "txtEdadDes";
            this.txtEdadDes.Size = new System.Drawing.Size(100, 20);
            this.txtEdadDes.TabIndex = 0;
            // 
            // lblEdadDes
            // 
            this.lblEdadDes = new System.Windows.Forms.Label();
            this.lblEdadDes.ForeColor = System.Drawing.Color.White;
            this.lblEdadDes.Location = new System.Drawing.Point(20, 20);
            this.lblEdadDes.Name = "lblEdadDes";
            this.lblEdadDes.Size = new System.Drawing.Size(100, 23);
            this.lblEdadDes.TabIndex = 1;
            this.lblEdadDes.Text = "Edad:";
            // 
            // lblGeneroDes
            // 
            this.lblGeneroDes = new System.Windows.Forms.Label();
            this.lblGeneroDes.ForeColor = System.Drawing.Color.White;
            this.lblGeneroDes.Location = new System.Drawing.Point(20, 70);
            this.lblGeneroDes.Name = "lblGeneroDes";
            this.lblGeneroDes.Size = new System.Drawing.Size(100, 23);
            this.lblGeneroDes.TabIndex = 2;
            this.lblGeneroDes.Text = "Género:";
            // 
            // rbMasculinoDes
            // 
            this.rbMasculinoDes = new System.Windows.Forms.RadioButton();
            this.rbMasculinoDes.ForeColor = System.Drawing.Color.White;
            this.rbMasculinoDes.Location = new System.Drawing.Point(20, 90);
            this.rbMasculinoDes.Name = "rbMasculinoDes";
            this.rbMasculinoDes.Size = new System.Drawing.Size(104, 24);
            this.rbMasculinoDes.TabIndex = 3;
            this.rbMasculinoDes.Text = "Masculino";
            // 
            // rbFemeninoDes
            // 
            this.rbFemeninoDes = new System.Windows.Forms.RadioButton();
            this.rbFemeninoDes.ForeColor = System.Drawing.Color.White;
            this.rbFemeninoDes.Location = new System.Drawing.Point(20, 120);
            this.rbFemeninoDes.Name = "rbFemeninoDes";
            this.rbFemeninoDes.Size = new System.Drawing.Size(104, 24);
            this.rbFemeninoDes.TabIndex = 4;
            this.rbFemeninoDes.Text = "Femenino";
            // 
            // lblOcupacionDes
            // 
            this.lblOcupacionDes = new System.Windows.Forms.Label();
            this.lblOcupacionDes.ForeColor = System.Drawing.Color.White;
            this.lblOcupacionDes.Location = new System.Drawing.Point(20, 140);
            this.lblOcupacionDes.Name = "lblOcupacionDes";
            this.lblOcupacionDes.Size = new System.Drawing.Size(100, 23);
            this.lblOcupacionDes.TabIndex = 6;
            this.lblOcupacionDes.Text = "Ocupación:";
            // 
            // txtOcupacionDes
            // 
            this.txtOcupacionDes = new System.Windows.Forms.TextBox();
            this.txtOcupacionDes.Location = new System.Drawing.Point(20, 160);
            this.txtOcupacionDes.Name = "txtOcupacionDes";
            this.txtOcupacionDes.Size = new System.Drawing.Size(150, 20);
            this.txtOcupacionDes.TabIndex = 5;
            // 
            // lblDireccionDes
            // 
            this.lblDireccionDes = new System.Windows.Forms.Label();
            this.lblDireccionDes.ForeColor = System.Drawing.Color.White;
            this.lblDireccionDes.Location = new System.Drawing.Point(20, 260);
            this.lblDireccionDes.Name = "lblDireccionDes";
            this.lblDireccionDes.Size = new System.Drawing.Size(100, 23);
            this.lblDireccionDes.TabIndex = 10;
            this.lblDireccionDes.Text = "Dirección:";
            // 
            // txtDireccionDes
            // 
            this.txtDireccionDes = new System.Windows.Forms.TextBox();
            this.txtDireccionDes.Location = new System.Drawing.Point(20, 280);
            this.txtDireccionDes.Name = "txtDireccionDes";
            this.txtDireccionDes.Size = new System.Drawing.Size(150, 20);
            this.txtDireccionDes.TabIndex = 9;
            // 
            // lblGrupoSanguineoDes
            // 
            this.lblGrupoSanguineoDes = new System.Windows.Forms.Label();
            this.lblGrupoSanguineoDes.ForeColor = System.Drawing.Color.White;
            this.lblGrupoSanguineoDes.Location = new System.Drawing.Point(200, 20);
            this.lblGrupoSanguineoDes.Name = "lblGrupoSanguineoDes";
            this.lblGrupoSanguineoDes.Size = new System.Drawing.Size(100, 23);
            this.lblGrupoSanguineoDes.TabIndex = 12;
            this.lblGrupoSanguineoDes.Text = "Grupo Sanguíneo:";
            // 
            // cbGrupoSanguineoDes
            // 
            this.cbGrupoSanguineoDes = new System.Windows.Forms.ComboBox();
            this.cbGrupoSanguineoDes.Location = new System.Drawing.Point(200, 40);
            this.cbGrupoSanguineoDes.Name = "cbGrupoSanguineoDes";
            this.cbGrupoSanguineoDes.Size = new System.Drawing.Size(121, 21);
            this.cbGrupoSanguineoDes.TabIndex = 11;
            // 
            // lblDetallesDes
            // 
            this.lblDetallesDes = new System.Windows.Forms.Label();
            this.lblDetallesDes.ForeColor = System.Drawing.Color.White;
            this.lblDetallesDes.Location = new System.Drawing.Point(20, 320);
            this.lblDetallesDes.Name = "lblDetallesDes";
            this.lblDetallesDes.Size = new System.Drawing.Size(100, 23);
            this.lblDetallesDes.TabIndex = 14;
            this.lblDetallesDes.Text = "Detalles:";
            // 
            // txtDetallesDes
            // 
            this.txtDetallesDes = new System.Windows.Forms.TextBox();
            this.txtDetallesDes.Location = new System.Drawing.Point(20, 340);
            this.txtDetallesDes.Name = "txtDetallesDes";
            this.txtDetallesDes.Size = new System.Drawing.Size(350, 20);
            this.txtDetallesDes.TabIndex = 13;
            // 
            // PacienteCita
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelTipo);
            this.Controls.Add(this.panelConocido);
            this.Controls.Add(this.panelDesconocido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PacienteCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacienteCita";
            this.panelHeader.ResumeLayout(false);
            this.panelTipo.ResumeLayout(false);
            this.ResumeLayout(false);

            // Inicialización de variables de diseño para panelConocido
            int leftCon = 20;
            int widthCon = 400;
            int heightCon = 23;
            int spacingCon = 8;
            int yCon = 20;

            // ----------------------------------------------------------------------------------------------------
            // Código para panelConocido (lblCedula, txtCedula, etc.)
            // ----------------------------------------------------------------------------------------------------
            // lblCedula
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblCedula.ForeColor = System.Drawing.Color.White;
            this.lblCedula.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblCedula.TabIndex = 1;
            this.lblCedula.Text = "Cédula:";
            this.panelConocido.Controls.Add(this.lblCedula);
            yCon += heightCon + spacingCon;

            // txtCedula
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtCedula.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(widthCon, 20);
            this.txtCedula.TabIndex = 0;
            this.panelConocido.Controls.Add(this.txtCedula);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblNombre
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            this.panelConocido.Controls.Add(this.lblNombre);
            yCon += heightCon + spacingCon;

            // txtNombre
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNombre.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(widthCon, 20);
            this.txtNombre.TabIndex = 2;
            this.panelConocido.Controls.Add(this.txtNombre);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblApellidoPa
            this.lblApellidoPa = new System.Windows.Forms.Label();
            this.lblApellidoPa.ForeColor = System.Drawing.Color.White;
            this.lblApellidoPa.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblApellidoPa.Name = "lblApellidoPa";
            this.lblApellidoPa.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblApellidoPa.TabIndex = 5;
            this.lblApellidoPa.Text = "Apellido Paterno:";
            this.panelConocido.Controls.Add(this.lblApellidoPa);
            yCon += heightCon + spacingCon;

            // txtApellidoPa
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.txtApellidoPa.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtApellidoPa.Name = "txtApellidoPa";
            this.txtApellidoPa.Size = new System.Drawing.Size(widthCon, 20);
            this.txtApellidoPa.TabIndex = 4;
            this.panelConocido.Controls.Add(this.txtApellidoPa);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblApellidoMa
            this.lblApellidoMa = new System.Windows.Forms.Label();
            this.lblApellidoMa.ForeColor = System.Drawing.Color.White;
            this.lblApellidoMa.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblApellidoMa.Name = "lblApellidoMa";
            this.lblApellidoMa.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblApellidoMa.TabIndex = 7;
            this.lblApellidoMa.Text = "Apellido Materno:";
            this.panelConocido.Controls.Add(this.lblApellidoMa);
            yCon += heightCon + spacingCon;

            // txtApellidoMa
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.txtApellidoMa.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtApellidoMa.Name = "txtApellidoMa";
            this.txtApellidoMa.Size = new System.Drawing.Size(widthCon, 20);
            this.txtApellidoMa.TabIndex = 6;
            this.panelConocido.Controls.Add(this.txtApellidoMa);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblFechaNacimiento
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.White;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblFechaNacimiento.TabIndex = 9;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            this.panelConocido.Controls.Add(this.lblFechaNacimiento);
            yCon += heightCon + spacingCon;

            // dtpFechaNacimiento
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(leftCon, yCon);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(widthCon, 20);
            this.dtpFechaNacimiento.TabIndex = 8;
            this.panelConocido.Controls.Add(this.dtpFechaNacimiento);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblGenero
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            this.lblGenero.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(60, heightCon);
            this.lblGenero.TabIndex = 10;
            this.lblGenero.Text = "Género:";
            this.panelConocido.Controls.Add(this.lblGenero);

            // rbMasculino
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.rbMasculino.ForeColor = System.Drawing.Color.White;
            this.rbMasculino.Location = new System.Drawing.Point(leftCon + 70, yCon);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(80, heightCon);
            this.rbMasculino.TabIndex = 11;
            this.rbMasculino.Text = "Masculino";
            this.panelConocido.Controls.Add(this.rbMasculino);

            // rbFemenino
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.rbFemenino.ForeColor = System.Drawing.Color.White;
            this.rbFemenino.Location = new System.Drawing.Point(leftCon + 160, yCon);
            this.rbFemenino.Name = "rbFemenino";
            this.rbFemenino.Size = new System.Drawing.Size(80, heightCon);
            this.rbFemenino.TabIndex = 12;
            this.rbFemenino.Text = "Femenino";
            this.panelConocido.Controls.Add(this.rbFemenino);
            yCon += heightCon + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblOcupacion
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.lblOcupacion.ForeColor = System.Drawing.Color.White;
            this.lblOcupacion.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblOcupacion.TabIndex = 13;
            this.lblOcupacion.Text = "Ocupación:";
            this.panelConocido.Controls.Add(this.lblOcupacion);
            yCon += heightCon + spacingCon;

            // txtOcupacion
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.txtOcupacion.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(widthCon, 20);
            this.txtOcupacion.TabIndex = 15;
            this.panelConocido.Controls.Add(this.txtOcupacion);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblTelefono
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblTelefono.TabIndex = 20;
            this.lblTelefono.Text = "Teléfono:";
            this.panelConocido.Controls.Add(this.lblTelefono);
            yCon += heightCon + spacingCon;

            // txtTelefono
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtTelefono.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(widthCon, 20);
            this.txtTelefono.TabIndex = 19;
            this.panelConocido.Controls.Add(this.txtTelefono);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblDireccion
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblDireccion.ForeColor = System.Drawing.Color.White;
            this.lblDireccion.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblDireccion.TabIndex = 22;
            this.lblDireccion.Text = "Dirección:";
            this.panelConocido.Controls.Add(this.lblDireccion);
            yCon += heightCon + spacingCon;

            // txtDireccion
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtDireccion.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(widthCon, 20);
            this.txtDireccion.TabIndex = 21;
            this.panelConocido.Controls.Add(this.txtDireccion);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblGrupoSanguineo
            this.lblGrupoSanguineo = new System.Windows.Forms.Label();
            this.lblGrupoSanguineo.ForeColor = System.Drawing.Color.White;
            this.lblGrupoSanguineo.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblGrupoSanguineo.Name = "lblGrupoSanguineo";
            this.lblGrupoSanguineo.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblGrupoSanguineo.TabIndex = 26;
            this.lblGrupoSanguineo.Text = "Grupo Sanguíneo:";
            this.panelConocido.Controls.Add(this.lblGrupoSanguineo);
            yCon += heightCon + spacingCon;

            // cbGrupoSanguineo
            this.cbGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.cbGrupoSanguineo.Location = new System.Drawing.Point(leftCon, yCon);
            this.cbGrupoSanguineo.Name = "cbGrupoSanguineo";
            this.cbGrupoSanguineo.Size = new System.Drawing.Size(widthCon, 21);
            this.cbGrupoSanguineo.TabIndex = 25;
            this.panelConocido.Controls.Add(this.cbGrupoSanguineo);
            yCon += 21 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblCorreoElectronico
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.lblCorreoElectronico.ForeColor = System.Drawing.Color.White;
            this.lblCorreoElectronico.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblCorreoElectronico.Name = "lblCorreoElectronico";
            this.lblCorreoElectronico.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblCorreoElectronico.TabIndex = 30;
            this.lblCorreoElectronico.Text = "Correo Electrónico:";
            this.panelConocido.Controls.Add(this.lblCorreoElectronico);
            yCon += heightCon + spacingCon;

            // txtCorreoElectronico
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtCorreoElectronico.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(widthCon, 20);
            this.txtCorreoElectronico.TabIndex = 29;
            this.panelConocido.Controls.Add(this.txtCorreoElectronico);
            yCon += 20 + spacingCon;

            // ----------------------------------------------------------------------------------------------------
            // lblDetalles
            this.lblDetalles = new System.Windows.Forms.Label();
            this.lblDetalles.ForeColor = System.Drawing.Color.White;
            this.lblDetalles.Location = new System.Drawing.Point(leftCon, yCon);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(widthCon, heightCon);
            this.lblDetalles.TabIndex = 32;
            this.lblDetalles.Text = "Detalles:";
            this.panelConocido.Controls.Add(this.lblDetalles);
            yCon += heightCon + spacingCon;

            // txtDetalles
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.txtDetalles.Location = new System.Drawing.Point(leftCon, yCon);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(widthCon, 60);
            this.txtDetalles.TabIndex = 31;
            this.txtDetalles.Multiline = true;
            this.panelConocido.Controls.Add(this.txtDetalles);
            yCon += 60 + spacingCon;

            // Ajustar el tamaño del panelConocido para que quepan todos los controles
            this.panelConocido.Size = new System.Drawing.Size(460, yCon + 20);

            // Inicialización de variables de diseño para panelDesconocido
            int leftDes = 20;
            int widthDes = 400;
            int heightDes = 23;
            int spacingDes = 8;
            int yDes = 20;

            // ----------------------------------------------------------------------------------------------------
            // lblFechaNacimientoDes
            this.lblFechaNacimientoDes = new System.Windows.Forms.Label();
            this.lblFechaNacimientoDes.ForeColor = System.Drawing.Color.White;
            this.lblFechaNacimientoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblFechaNacimientoDes.Name = "lblFechaNacimientoDes";
            this.lblFechaNacimientoDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblFechaNacimientoDes.TabIndex = 1;
            this.lblFechaNacimientoDes.Text = "Fecha de Nacimiento:";
            this.panelDesconocido.Controls.Add(this.lblFechaNacimientoDes);
            yDes += heightDes + spacingDes;

            // dtpFechaNacimientoDes
            this.dtpFechaNacimientoDes = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaNacimientoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.dtpFechaNacimientoDes.Name = "dtpFechaNacimientoDes";
            this.dtpFechaNacimientoDes.Size = new System.Drawing.Size(widthDes, 20);
            this.dtpFechaNacimientoDes.TabIndex = 0;
            this.panelDesconocido.Controls.Add(this.dtpFechaNacimientoDes);
            yDes += 20 + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblGeneroDes
            this.lblGeneroDes = new System.Windows.Forms.Label();
            this.lblGeneroDes.ForeColor = System.Drawing.Color.White;
            this.lblGeneroDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblGeneroDes.Name = "lblGeneroDes";
            this.lblGeneroDes.Size = new System.Drawing.Size(60, heightDes);
            this.lblGeneroDes.TabIndex = 2;
            this.lblGeneroDes.Text = "Género:";
            this.panelDesconocido.Controls.Add(this.lblGeneroDes);

            // rbMasculinoDes
            this.rbMasculinoDes = new System.Windows.Forms.RadioButton();
            this.rbMasculinoDes.ForeColor = System.Drawing.Color.White;
            this.rbMasculinoDes.Location = new System.Drawing.Point(leftDes + 70, yDes);
            this.rbMasculinoDes.Name = "rbMasculinoDes";
            this.rbMasculinoDes.Size = new System.Drawing.Size(80, heightDes);
            this.rbMasculinoDes.TabIndex = 3;
            this.rbMasculinoDes.Text = "Masculino";
            this.panelDesconocido.Controls.Add(this.rbMasculinoDes);

            // rbFemeninoDes
            this.rbFemeninoDes = new System.Windows.Forms.RadioButton();
            this.rbFemeninoDes.ForeColor = System.Drawing.Color.White;
            this.rbFemeninoDes.Location = new System.Drawing.Point(leftDes + 160, yDes);
            this.rbFemeninoDes.Name = "rbFemeninoDes";
            this.rbFemeninoDes.Size = new System.Drawing.Size(80, heightDes);
            this.rbFemeninoDes.TabIndex = 4;
            this.rbFemeninoDes.Text = "Femenino";
            this.panelDesconocido.Controls.Add(this.rbFemeninoDes);
            yDes += heightDes + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblOcupacionDes
            this.lblOcupacionDes = new System.Windows.Forms.Label();
            this.lblOcupacionDes.ForeColor = System.Drawing.Color.White;
            this.lblOcupacionDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblOcupacionDes.Name = "lblOcupacionDes";
            this.lblOcupacionDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblOcupacionDes.TabIndex = 6;
            this.lblOcupacionDes.Text = "Ocupación:";
            this.panelDesconocido.Controls.Add(this.lblOcupacionDes);
            yDes += heightDes + spacingDes;

            // txtOcupacionDes
            this.txtOcupacionDes = new System.Windows.Forms.TextBox();
            this.txtOcupacionDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.txtOcupacionDes.Name = "txtOcupacionDes";
            this.txtOcupacionDes.Size = new System.Drawing.Size(widthDes, 20);
            this.txtOcupacionDes.TabIndex = 5;
            this.panelDesconocido.Controls.Add(this.txtOcupacionDes);
            yDes += 20 + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblTelefonoDes
            this.lblTelefonoDes = new System.Windows.Forms.Label();
            this.lblTelefonoDes.ForeColor = System.Drawing.Color.White;
            this.lblTelefonoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblTelefonoDes.Name = "lblTelefonoDes";
            this.lblTelefonoDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblTelefonoDes.TabIndex = 8;
            this.lblTelefonoDes.Text = "Teléfono:";
            this.panelDesconocido.Controls.Add(this.lblTelefonoDes);
            yDes += heightDes + spacingDes;

            // txtTelefonoDes
            this.txtTelefonoDes = new System.Windows.Forms.TextBox();
            this.txtTelefonoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.txtTelefonoDes.Name = "txtTelefonoDes";
            this.txtTelefonoDes.Size = new System.Drawing.Size(widthDes, 20);
            this.txtTelefonoDes.TabIndex = 7;
            this.panelDesconocido.Controls.Add(this.txtTelefonoDes);
            yDes += 20 + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblDireccionDes
            this.lblDireccionDes = new System.Windows.Forms.Label();
            this.lblDireccionDes.ForeColor = System.Drawing.Color.White;
            this.lblDireccionDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblDireccionDes.Name = "lblDireccionDes";
            this.lblDireccionDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblDireccionDes.TabIndex = 10;
            this.lblDireccionDes.Text = "Dirección:";
            this.panelDesconocido.Controls.Add(this.lblDireccionDes);
            yDes += heightDes + spacingDes;

            // txtDireccionDes
            this.txtDireccionDes = new System.Windows.Forms.TextBox();
            this.txtDireccionDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.txtDireccionDes.Name = "txtDireccionDes";
            this.txtDireccionDes.Size = new System.Drawing.Size(widthDes, 20);
            this.txtDireccionDes.TabIndex = 9;
            this.panelDesconocido.Controls.Add(this.txtDireccionDes);
            yDes += 20 + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblGrupoSanguineoDes
            this.lblGrupoSanguineoDes = new System.Windows.Forms.Label();
            this.lblGrupoSanguineoDes.ForeColor = System.Drawing.Color.White;
            this.lblGrupoSanguineoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblGrupoSanguineoDes.Name = "lblGrupoSanguineoDes";
            this.lblGrupoSanguineoDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblGrupoSanguineoDes.TabIndex = 12;
            this.lblGrupoSanguineoDes.Text = "Grupo Sanguíneo:";
            this.panelDesconocido.Controls.Add(this.lblGrupoSanguineoDes);
            yDes += heightDes + spacingDes;

            // cbGrupoSanguineoDes
            this.cbGrupoSanguineoDes = new System.Windows.Forms.ComboBox();
            this.cbGrupoSanguineoDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.cbGrupoSanguineoDes.Name = "cbGrupoSanguineoDes";
            this.cbGrupoSanguineoDes.Size = new System.Drawing.Size(widthDes, 21);
            this.cbGrupoSanguineoDes.TabIndex = 11;
            this.panelDesconocido.Controls.Add(this.cbGrupoSanguineoDes);
            yDes += 21 + spacingDes;

            // ----------------------------------------------------------------------------------------------------
            // lblDetallesDes
            this.lblDetallesDes = new System.Windows.Forms.Label();
            this.lblDetallesDes.ForeColor = System.Drawing.Color.White;
            this.lblDetallesDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.lblDetallesDes.Name = "lblDetallesDes";
            this.lblDetallesDes.Size = new System.Drawing.Size(widthDes, heightDes);
            this.lblDetallesDes.TabIndex = 14;
            this.lblDetallesDes.Text = "Detalles:";
            this.panelDesconocido.Controls.Add(this.lblDetallesDes);
            yDes += heightDes + spacingDes;

            // txtDetallesDes
            this.txtDetallesDes = new System.Windows.Forms.TextBox();
            this.txtDetallesDes.Location = new System.Drawing.Point(leftDes, yDes);
            this.txtDetallesDes.Name = "txtDetallesDes";
            this.txtDetallesDes.Size = new System.Drawing.Size(widthDes, 60);
            this.txtDetallesDes.TabIndex = 13;
            this.txtDetallesDes.Multiline = true;
            this.panelDesconocido.Controls.Add(this.txtDetallesDes);
            yDes += 60 + spacingDes;

            // Ajustar el tamaño del panelDesconocido para que quepan todos los controles
            this.panelDesconocido.Size = new System.Drawing.Size(460, yDes + 20);
        }

        #endregion

        // Declaración de controles
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rbConocido;
        private System.Windows.Forms.RadioButton rbDesconocido;
        private System.Windows.Forms.Panel panelConocido;
        private System.Windows.Forms.TextBox txtCedula, txtNombre, txtApellidoPa, txtApellidoMa, txtOcupacion, txtTelefono, txtDireccion, txtCorreoElectronico, txtDetalles;
        private System.Windows.Forms.Label lblCedula, lblNombre, lblApellidoPa, lblApellidoMa, lblFechaNacimiento, lblGenero, lblOcupacion, lblTelefono, lblDireccion, lblGrupoSanguineo, lblCorreoElectronico, lblDetalles;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.RadioButton rbMasculino, rbFemenino;
        private System.Windows.Forms.ComboBox cbGrupoSanguineo;
        private System.Windows.Forms.Panel panelDesconocido;
        private System.Windows.Forms.TextBox txtEdadDes, txtOcupacionDes, txtDireccionDes, txtTelefonoDes, txtDetallesDes;
        private System.Windows.Forms.Label lblEdadDes, lblGeneroDes, lblOcupacionDes, lblTelefonoDes, lblDireccionDes, lblGrupoSanguineoDes, lblDetallesDes, lblFechaNacimientoDes;
        private System.Windows.Forms.RadioButton rbMasculinoDes, rbFemeninoDes;
        private System.Windows.Forms.ComboBox cbGrupoSanguineoDes;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimientoDes;
    }
}