namespace sistema
{
    partial class AgendarCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendarCita));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoSangre = new System.Windows.Forms.Label();
            this.lblGeneroPaciente = new System.Windows.Forms.Label();
            this.lblEdadPaciente = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.lblFechaCita = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioPM = new System.Windows.Forms.RadioButton();
            this.radioAM = new System.Windows.Forms.RadioButton();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.metroLabelDoctor = new MetroFramework.Controls.MetroLabel();
            this.cbDoctor = new System.Windows.Forms.ComboBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtMotivoCita = new System.Windows.Forms.RichTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTipoSangre);
            this.panel1.Controls.Add(this.lblGeneroPaciente);
            this.panel1.Controls.Add(this.lblEdadPaciente);
            this.panel1.Controls.Add(this.lblNombrePaciente);
            this.panel1.Location = new System.Drawing.Point(16, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 160);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label5.Location = new System.Drawing.Point(14, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Datos del Paciente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(14, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo de Sangre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(14, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Género:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Edad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // lblTipoSangre
            // 
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSangre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.lblTipoSangre.Location = new System.Drawing.Point(140, 124);
            this.lblTipoSangre.Name = "lblTipoSangre";
            this.lblTipoSangre.Size = new System.Drawing.Size(102, 17);
            this.lblTipoSangre.TabIndex = 3;
            this.lblTipoSangre.Text = "No especificado";
            // 
            // lblGeneroPaciente
            // 
            this.lblGeneroPaciente.AutoSize = true;
            this.lblGeneroPaciente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneroPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGeneroPaciente.Location = new System.Drawing.Point(140, 96);
            this.lblGeneroPaciente.Name = "lblGeneroPaciente";
            this.lblGeneroPaciente.Size = new System.Drawing.Size(102, 17);
            this.lblGeneroPaciente.TabIndex = 2;
            this.lblGeneroPaciente.Text = "No especificado";
            // 
            // lblEdadPaciente
            // 
            this.lblEdadPaciente.AutoSize = true;
            this.lblEdadPaciente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdadPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblEdadPaciente.Location = new System.Drawing.Point(140, 68);
            this.lblEdadPaciente.Name = "lblEdadPaciente";
            this.lblEdadPaciente.Size = new System.Drawing.Size(32, 17);
            this.lblEdadPaciente.TabIndex = 1;
            this.lblEdadPaciente.Text = "N/A";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Segoe UI Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNombrePaciente.Location = new System.Drawing.Point(140, 40);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(135, 17);
            this.lblNombrePaciente.TabIndex = 0;
            this.lblNombrePaciente.Text = "Nombre del Paciente";
            // 
            // lblFechaCita
            // 
            this.lblFechaCita.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.lblFechaCita.Location = new System.Drawing.Point(16, 236);
            this.lblFechaCita.Name = "lblFechaCita";
            this.lblFechaCita.Size = new System.Drawing.Size(430, 22);
            this.lblFechaCita.TabIndex = 1;
            this.lblFechaCita.Text = "Fecha: 00/00/0000";
            this.lblFechaCita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPM);
            this.groupBox1.Controls.Add(this.radioAM);
            this.groupBox1.Controls.Add(this.dtpHora);
            this.groupBox1.Controls.Add(this.metroLabelDoctor);
            this.groupBox1.Controls.Add(this.cbDoctor);
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.txtMotivoCita);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 305);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de la Cita";
            // 
            // radioPM
            // 
            this.radioPM.AutoSize = true;
            this.radioPM.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioPM.Location = new System.Drawing.Point(364, 31);
            this.radioPM.Name = "radioPM";
            this.radioPM.Size = new System.Drawing.Size(42, 19);
            this.radioPM.TabIndex = 7;
            this.radioPM.TabStop = true;
            this.radioPM.Text = "PM";
            this.radioPM.UseVisualStyleBackColor = true;
            // 
            // radioAM
            // 
            this.radioAM.AutoSize = true;
            this.radioAM.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.radioAM.Location = new System.Drawing.Point(308, 31);
            this.radioAM.Name = "radioAM";
            this.radioAM.Size = new System.Drawing.Size(43, 19);
            this.radioAM.TabIndex = 6;
            this.radioAM.TabStop = true;
            this.radioAM.Text = "AM";
            this.radioAM.UseVisualStyleBackColor = true;
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHora.Location = new System.Drawing.Point(134, 29);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(160, 24);
            this.dtpHora.TabIndex = 5;
            this.dtpHora.ValueChanged += new System.EventHandler(this.dtpHora_ValueChanged);
            // 
            // metroLabelDoctor
            // 
            this.metroLabelDoctor.AutoSize = true;
            this.metroLabelDoctor.Location = new System.Drawing.Point(14, 76);
            this.metroLabelDoctor.Name = "metroLabelDoctor";
            this.metroLabelDoctor.Size = new System.Drawing.Size(117, 19);
            this.metroLabelDoctor.TabIndex = 8;
            this.metroLabelDoctor.Text = "Médico Asignado:";
            this.metroLabelDoctor.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // cbDoctor
            // 
            this.cbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoctor.FormattingEnabled = true;
            this.cbDoctor.Location = new System.Drawing.Point(134, 74);
            this.cbDoctor.Name = "cbDoctor";
            this.cbDoctor.Size = new System.Drawing.Size(278, 25);
            this.cbDoctor.TabIndex = 9;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(89)))));
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(282, 248);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(130, 36);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Guardar Cita";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 118);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(113, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Motivo de la Cita:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txtMotivoCita
            // 
            this.txtMotivoCita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivoCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoCita.Location = new System.Drawing.Point(134, 118);
            this.txtMotivoCita.Name = "txtMotivoCita";
            this.txtMotivoCita.Size = new System.Drawing.Size(278, 110);
            this.txtMotivoCita.TabIndex = 2;
            this.txtMotivoCita.Text = "";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 32);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Hora de la Cita:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // AgendarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 595);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFechaCita);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgendarCita";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Agendar Cita";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.AgendarCita_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTipoSangre;
        private System.Windows.Forms.Label lblGeneroPaciente;
        private System.Windows.Forms.Label lblEdadPaciente;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label lblFechaCita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.RichTextBox txtMotivoCita;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.RadioButton radioPM;
        private System.Windows.Forms.RadioButton radioAM;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroLabel metroLabelDoctor;
        private System.Windows.Forms.ComboBox cbDoctor;
    }
}
