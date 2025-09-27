namespace sistema
{
    partial class PacienteCita
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelNo = new System.Windows.Forms.Panel();
            this.panelSi = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.panelConocido = new System.Windows.Forms.Panel();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.lblApellidoPa = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelDesconocido = new System.Windows.Forms.Panel();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.picCalendario = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelConocido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 100);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(285, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Capture los datos del Formulario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paciente";
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(7, 33);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(34, 17);
            this.rbSi.TabIndex = 1;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Si";
            this.rbSi.UseVisualStyleBackColor = true;
            this.rbSi.CheckedChanged += new System.EventHandler(this.rbSi_CheckedChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(150, 33);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 2;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panelNo);
            this.panel2.Controls.Add(this.panelSi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbNo);
            this.panel2.Controls.Add(this.rbSi);
            this.panel2.Location = new System.Drawing.Point(25, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 68);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panelNo
            // 
            this.panelNo.Location = new System.Drawing.Point(115, 56);
            this.panelNo.Name = "panelNo";
            this.panelNo.Size = new System.Drawing.Size(110, 10);
            this.panelNo.TabIndex = 4;
            // 
            // panelSi
            // 
            this.panelSi.Location = new System.Drawing.Point(2, 56);
            this.panelSi.Name = "panelSi";
            this.panelSi.Size = new System.Drawing.Size(110, 10);
            this.panelSi.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desconocido";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(7, 47);
            this.txtCedula.Multiline = true;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(161, 39);
            this.txtCedula.TabIndex = 4;
            this.txtCedula.Enter += new System.EventHandler(this.txtCedula_Enter);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            this.txtCedula.Leave += new System.EventHandler(this.txtCedula_Leave);
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(4, 31);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(40, 13);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "Cedula";
            // 
            // panelConocido
            // 
            this.panelConocido.Controls.Add(this.picCalendario);
            this.panelConocido.Controls.Add(this.txtFechaNacimiento);
            this.panelConocido.Controls.Add(this.label4);
            this.panelConocido.Controls.Add(this.txtApellidoMa);
            this.panelConocido.Controls.Add(this.label6);
            this.panelConocido.Controls.Add(this.txtApellidoPa);
            this.panelConocido.Controls.Add(this.lblApellidoPa);
            this.panelConocido.Controls.Add(this.txtNombre);
            this.panelConocido.Controls.Add(this.lblNombre);
            this.panelConocido.Controls.Add(this.txtCedula);
            this.panelConocido.Controls.Add(this.lblCedula);
            this.panelConocido.Location = new System.Drawing.Point(25, 207);
            this.panelConocido.Name = "panelConocido";
            this.panelConocido.Size = new System.Drawing.Size(200, 467);
            this.panelConocido.TabIndex = 6;
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Location = new System.Drawing.Point(7, 363);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(117, 20);
            this.txtFechaNacimiento.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // txtApellidoMa
            // 
            this.txtApellidoMa.Location = new System.Drawing.Point(7, 287);
            this.txtApellidoMa.Multiline = true;
            this.txtApellidoMa.Name = "txtApellidoMa";
            this.txtApellidoMa.Size = new System.Drawing.Size(161, 39);
            this.txtApellidoMa.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Apellido Materno";
            // 
            // txtApellidoPa
            // 
            this.txtApellidoPa.Location = new System.Drawing.Point(6, 198);
            this.txtApellidoPa.Multiline = true;
            this.txtApellidoPa.Name = "txtApellidoPa";
            this.txtApellidoPa.Size = new System.Drawing.Size(161, 39);
            this.txtApellidoPa.TabIndex = 8;
            this.txtApellidoPa.Enter += new System.EventHandler(this.txtApellidoPa_Enter);
            this.txtApellidoPa.Leave += new System.EventHandler(this.txtApellidoPa_Leave);
            // 
            // lblApellidoPa
            // 
            this.lblApellidoPa.AutoSize = true;
            this.lblApellidoPa.Location = new System.Drawing.Point(4, 182);
            this.lblApellidoPa.Name = "lblApellidoPa";
            this.lblApellidoPa.Size = new System.Drawing.Size(84, 13);
            this.lblApellidoPa.TabIndex = 9;
            this.lblApellidoPa.Text = "Apellido Paterno";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(7, 121);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(161, 39);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 105);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre";
            // 
            // panelDesconocido
            // 
            this.panelDesconocido.Location = new System.Drawing.Point(269, 207);
            this.panelDesconocido.Name = "panelDesconocido";
            this.panelDesconocido.Size = new System.Drawing.Size(200, 467);
            this.panelDesconocido.TabIndex = 7;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(164, 601);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 13;
            this.dtpFechaNacimiento.CloseUp += new System.EventHandler(this.dtpFechaNacimiento_CloseUp);
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // picCalendario
            // 
            this.picCalendario.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCalendario.InitialImage")));
            this.picCalendario.Location = new System.Drawing.Point(150, 356);
            this.picCalendario.Name = "picCalendario";
            this.picCalendario.Size = new System.Drawing.Size(32, 32);
            this.picCalendario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCalendario.TabIndex = 0;
            this.picCalendario.TabStop = false;
            this.picCalendario.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picCalendario.MouseEnter += new System.EventHandler(this.picCalendario_MouseEnter);
            this.picCalendario.MouseLeave += new System.EventHandler(this.picCalendario_MouseLeave);
            // 
            // PacienteCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(390, 744);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.panelDesconocido);
            this.Controls.Add(this.panelConocido);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PacienteCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacienteCita";
            this.Load += new System.EventHandler(this.PacienteCita_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelConocido.ResumeLayout(false);
            this.panelConocido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbSi;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelNo;
        private System.Windows.Forms.Panel panelSi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Panel panelConocido;
        private System.Windows.Forms.TextBox txtApellidoPa;
        private System.Windows.Forms.Label lblApellidoPa;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panelDesconocido;
        private System.Windows.Forms.TextBox txtApellidoMa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picCalendario;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
    }
}