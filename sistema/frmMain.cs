using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            abrirFormHijo(new frmInicio(this));
            labelTitulo.Text = "Inicio";
            this.pbTitulo.Image = Properties.Resources.hogar;
            // Así accedes al recurso correctamente


        }


        public void abrirFormHijo(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void BTNInicio_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmInicio(this));
            labelTitulo.Text = "Inicio";
            this.pbTitulo.Image = Properties.Resources.hogar;
            this.Refresh();
        }

        private void BTNCitas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCitas());
            labelTitulo.Text = "Citas";
            this.pbTitulo.Image = Properties.Resources.calendario;
            this.Refresh();
        }

        private void BTNPacientes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmPacientes());
            labelTitulo.Text = "Pacientes";
            this.pbTitulo.Image = Properties.Resources.paciente;
            this.Refresh();
        }

        private void BTNAgenda_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmAgenda());
            labelTitulo.Text = "Agenda";
            this.pbTitulo.Image = Properties.Resources.agenda;
            this.Refresh();
        }

        private void BTNNotas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmNotas());
            labelTitulo.Text = "Notas";
            this.pbTitulo.Image = Properties.Resources.notas;
            this.Refresh();
        }

        private void BTNSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro que desea salir?", "Confirmacion de salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCuentas());
            labelTitulo.Text = "Gestion De Cuentas";
            this.pbTitulo.Image = Properties.Resources.usuario;
            this.Refresh();
        }
    }
}
