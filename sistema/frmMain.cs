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
        // Resaltar Botones de Navegación
        private FrameworkTest.SATAButton[] _navMainButtons;

        public frmMain()
        {
            InitializeComponent();
            InicializarNavegacionLateral();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            abrirFormHijo(new frmInicio(this));
            labelTitulo.Text = "Inicio";
            this.pbTitulo.Image = Properties.Resources.hogar;

            // Resaltar Inicio al cargar
            SetActiveNavButton(BTNInicio);
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
            SetActiveNavButton(BTNInicio);
            this.Refresh();
        }

        private void BTNCitas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCitas());
            labelTitulo.Text = "Citas";
            this.pbTitulo.Image = Properties.Resources.calendario;
            SetActiveNavButton(BTNCitas);
            this.Refresh();
        }

        private void BTNPacientes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmPacientes());
            labelTitulo.Text = "Pacientes";
            this.pbTitulo.Image = Properties.Resources.paciente;
            SetActiveNavButton(BTNPacientes);
            this.Refresh();
        }

        private void BTNAgenda_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmAgenda());
            labelTitulo.Text = "Agenda";
            this.pbTitulo.Image = Properties.Resources.agenda;
            SetActiveNavButton(BTNAgenda);
            this.Refresh();
        }

        private void BTNNotas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmNotas());
            labelTitulo.Text = "Notas";
            this.pbTitulo.Image = Properties.Resources.notas;
            SetActiveNavButton(BTNNotas);
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
            SetActiveNavButton(btnCuentas);
            this.Refresh();
        }

        // -------------------- Navegación/Resaltado --------------------

        private void InicializarNavegacionLateral()
        {
            // Excluyo BTNSalir para que no quede “activo”
            _navMainButtons = new[]
            {
                BTNInicio, BTNCitas, BTNPacientes, BTNAgenda, BTNNotas, btnCuentas
            };

            foreach (var sb in _navMainButtons)
            {
                if (sb == null) continue;

                // Guarda el color normal original en Tag
                if (sb.Tag == null) sb.Tag = sb.NormalBackground;

                // Si no hay Hover definido, calcula uno a partir del Normal
                if (sb.HoverBackground.IsEmpty)
                {
                    var normal = (Color)sb.Tag;
                    sb.HoverBackground = ControlPaint.Light(normal);
                }
            }
        }

        // Deja el botón activo con el color Hover y el resto vuelve a Normal
        private void SetActiveNavButton(FrameworkTest.SATAButton active)
        {
            if (_navMainButtons == null) return;

            foreach (var sb in _navMainButtons)
            {
                if (sb == null) continue;

                var normal = (Color)(sb.Tag ?? sb.NormalBackground);

                if (sb == active)
                {
                    // Forzamos el color del “activo” usando el Hover como Normal para que se vea fijo
                    var hover = sb.HoverBackground.IsEmpty ? ControlPaint.Light(normal) : sb.HoverBackground;
                    sb.NormalBackground = hover;

                    // Si definiste HoverForeColor, úsalo; si no, deja el actual
                    if (!sb.HoverForeColor.IsEmpty)
                        sb.NormalForeColor = sb.HoverForeColor;
                }
                else
                {
                    // Restaurar color normal original
                    sb.NormalBackground = normal;
                }

                sb.Invalidate();
                sb.Refresh();
            }
        }
    }
}
