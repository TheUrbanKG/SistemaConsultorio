using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmMain : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            abrirFormHijo(new frmInicio(this));
            labelTitulo.Text = "Inicio";
            this.pbTitulo.Image = Properties.Resources.hogar;

            AplicarPermisosCuentasPorRol();
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

        // Aplica visibilidad/habilitación de panelCuentas según rol del usuario logueado
        private void AplicarPermisosCuentasPorRol()
        {
            try
            {
                bool esAdmin = false;
                string usuario = sistema.Infrastructure.Security.Sesion.UsuarioActual;

                if (!string.IsNullOrWhiteSpace(usuario))
                {
                    using (var conn = new SqlConnection(connectionString))
                    using (var cmd = new SqlCommand("SELECT TOP (1) Rol FROM login WHERE Usuario = @Usuario", conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        conn.Open();
                        var rolObj = cmd.ExecuteScalar();
                        var rol = rolObj?.ToString();
                        esAdmin = string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase);
                    }
                }

                if (panelCuentas != null)
                {
                    panelCuentas.Visible = esAdmin;
                    panelCuentas.Enabled = esAdmin;
                }

                // Opcional: también deshabilita el botón si existe
                if (btnCuentas != null)
                    btnCuentas.Enabled = esAdmin;
            }
            catch
            {
                // Si falla la resolución de rol, por seguridad ocultamos/deshabilitamos
                if (panelCuentas != null)
                {
                    panelCuentas.Visible = false;
                    panelCuentas.Enabled = false;
                }
                if (btnCuentas != null)
                    btnCuentas.Enabled = false;
            }
        }
    }
}
