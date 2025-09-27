using sistema.Expediente.Historia;
using sistema.Expediente.Registro;
using sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema.Expediente
{
    public partial class frmExpediente : Form
    {
        public int PacienteID { get; set; }
        public frmExpediente()
        {
            InitializeComponent();
        }

        public string NombreCompleto
        {
            get => lbNombre.Text;
            set => lbNombre.Text = value;
        }

        public string Cedula
        {
            get => lbCedula.Text;
            set => lbCedula.Text = value;
        }

        private void abrirFormHijo(Form formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.None;

            fh.Width = panelContenedor.ClientSize.Width;

            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();


            panelContenedor.AutoScroll = true;
            panelContenedor.HorizontalScroll.Enabled = false;
            panelContenedor.HorizontalScroll.Visible = false;
            panelContenedor.HorizontalScroll.Maximum = 0;
            panelContenedor.PerformLayout();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmRegistro());
            this.Refresh();
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            // Verificar que tenemos un PacienteID válido
            if (PacienteID <= 0)
            {
                MessageBox.Show("No se ha recibido un ID de paciente válido");
                return;
            }

            // Abrir frmHistoria pasando el mismo ID
            frmHistoria historia = new frmHistoria();
            historia.PacienteID = this.PacienteID; // Pasa el mismo ID recibido
            abrirFormHijo(historia);
        }

        private void btnCuadros_Click(object sender, EventArgs e)
        {
            frmCuadros cuadros = new frmCuadros();
            cuadros.PacienteID = this.PacienteID;
            abrirFormHijo(cuadros);
            this.Refresh();
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0)
            {
                MessageBox.Show("No se ha recibido un ID de paciente válido");
                return;
            }

            frmAlergias alergias = new frmAlergias();
            alergias.PacienteID = this.PacienteID;
            abrirFormHijo(alergias);

        }

        private void frmExpediente_Load(object sender, EventArgs e)
        {
            abrirFormHijo(new frmRegistro());
        }
    }
}
