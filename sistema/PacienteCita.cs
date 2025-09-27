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
    public partial class PacienteCita : Form
    {
        private const string PlaceholderCedula = "Ingrese cédula";
        private const string PlaceholderNombre = "Ingrese Nombre";
        private const string PlaceholderApellidoPa = "Ingrese Apellido";

        // Crear una fuente de referencia consistente
        private Font fuentePlaceholder;
        private Font fuenteNormal;

        public PacienteCita()
        {
            InitializeComponent();

            // Inicializar las fuentes una sola vez
            fuentePlaceholder = new Font("Segoe UI", 13, FontStyle.Italic);
            fuenteNormal = new Font("Segoe UI", 12, FontStyle.Regular);

            InicializarCampos();
            dtpFechaNacimiento.Visible = false;
        }

        private void InicializarCampos()
        {
            // Cedula
            txtCedula.Text = PlaceholderCedula;
            txtCedula.ForeColor = Color.Gray;
            txtCedula.Font = fuentePlaceholder;
            txtCedula.BackColor = Color.White;
            lblCedula.ForeColor = Color.Black;

            // Nombre - FUENTE IDÉNTICA
            txtNombre.Text = PlaceholderNombre;
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Font = fuentePlaceholder; // Misma instancia de fuente
            txtNombre.BackColor = Color.White;
            lblNombre.ForeColor = Color.Black;

            // Apellido Paterno - FUENTE IDÉNTICA
            txtApellidoPa.Text = PlaceholderApellidoPa;
            txtApellidoPa.ForeColor = Color.Gray;
            txtApellidoPa.Font = fuentePlaceholder; // Misma instancia de fuente
            txtApellidoPa.BackColor = Color.White;
            lblApellidoPa.ForeColor = Color.Black;
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSi.Checked)
            {
                panelSi.BackColor = Color.LightGreen;
                panelNo.BackColor = Color.WhiteSmoke;
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                panelNo.BackColor = Color.LightCoral;
                panelSi.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            txtCedula.BackColor = Color.Lavender;

            if (txtCedula.Text == PlaceholderCedula)
            {
                txtCedula.Text = "";
                txtCedula.ForeColor = Color.Black;
                txtCedula.Font = fuenteNormal;
            }
            lblCedula.ForeColor = Color.Black;
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                txtCedula.Text = PlaceholderCedula;
                txtCedula.ForeColor = Color.Red;
                txtCedula.BackColor = Color.MistyRose;
                txtCedula.Font = fuentePlaceholder;
                lblCedula.ForeColor = Color.Red;
            }
            else
            {
                txtCedula.ForeColor = Color.Black;
                txtCedula.BackColor = Color.White;
                txtCedula.Font = fuenteNormal;
                lblCedula.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.Lavender;

            if (txtNombre.Text == PlaceholderNombre)
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
                txtNombre.Font = fuenteNormal;
            }
            lblNombre.ForeColor = Color.Black;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = PlaceholderNombre;
                txtNombre.ForeColor = Color.Red;
                txtNombre.BackColor = Color.MistyRose;
                txtNombre.Font = fuentePlaceholder;
                lblNombre.ForeColor = Color.Red;
            }
            else
            {
                txtNombre.ForeColor = Color.Black;
                txtNombre.BackColor = Color.White;
                txtNombre.Font = fuenteNormal;
                lblNombre.ForeColor = Color.Black;
            }
        }

        private void txtApellidoPa_Enter(object sender, EventArgs e)
        {
            txtApellidoPa.BackColor = Color.Lavender;

            if (txtApellidoPa.Text == PlaceholderApellidoPa)
            {
                txtApellidoPa.Text = "";
                txtApellidoPa.ForeColor = Color.Black;
                txtApellidoPa.Font = fuenteNormal;
            }
            lblApellidoPa.ForeColor = Color.Black;
        }

        private void txtApellidoPa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellidoPa.Text))
            {
                txtApellidoPa.Text = PlaceholderApellidoPa;
                txtApellidoPa.ForeColor = Color.Red;
                txtApellidoPa.BackColor = Color.MistyRose;
                txtApellidoPa.Font = fuentePlaceholder;
                lblApellidoPa.ForeColor = Color.Red;
            }
            else
            {
                txtApellidoPa.ForeColor = Color.Black;
                txtApellidoPa.BackColor = Color.White;
                txtApellidoPa.Font = fuenteNormal;
                lblApellidoPa.ForeColor = Color.Black;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void PacienteCita_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dtpFechaNacimiento.Visible = true;
            dtpFechaNacimiento.Focus();
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_CloseUp(object sender, EventArgs e)
        {
            txtFechaNacimiento.Text = dtpFechaNacimiento.Value.ToString("dd/MM/yyyy");
            dtpFechaNacimiento.Visible = false;
        }

        private void picCalendario_MouseEnter(object sender, EventArgs e)
        {
        }

        private void picCalendario_MouseLeave(object sender, EventArgs e)
        {
        }
    }
}