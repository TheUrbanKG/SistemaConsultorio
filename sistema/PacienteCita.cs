using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class PacienteCita : Form
    {
        public PacientePreview PreviewPaciente { get; private set; }
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
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

            panelConocido.Visible = false;
            panelDesconocido.Visible = false;

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
            txtApellido.Text = PlaceholderApellidoPa;
            txtApellido.ForeColor = Color.Gray;
            txtApellido.Font = fuentePlaceholder; // Misma instancia de fuente
            txtApellido.BackColor = Color.White;
            lblApellidoPa.ForeColor = Color.Black;
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSi.Checked)
            {
                panelSi.BackColor = Color.LightGreen;
                panelNo.BackColor = Color.WhiteSmoke;

                panelConocido.Visible = true;
                panelDesconocido.Visible = false;
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                panelNo.BackColor = Color.LightCoral;
                panelSi.BackColor = Color.WhiteSmoke;

                panelConocido.Visible = false;
                panelDesconocido.Visible = true;
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
            txtApellido.BackColor = Color.Lavender;

            if (txtApellido.Text == PlaceholderApellidoPa)
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
                txtApellido.Font = fuenteNormal;
            }
            lblApellidoPa.ForeColor = Color.Black;
        }

        private void txtApellidoPa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = PlaceholderApellidoPa;
                txtApellido.ForeColor = Color.Red;
                txtApellido.BackColor = Color.MistyRose;
                txtApellido.Font = fuentePlaceholder;
                lblApellidoPa.ForeColor = Color.Red;
            }
            else
            {
                txtApellido.ForeColor = Color.Black;
                txtApellido.BackColor = Color.White;
                txtApellido.Font = fuenteNormal;
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

        private void panelConocido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Paciente
                    (Cedula, Nombre, Apellido, FechaNacimiento, Genero, EstadoCivil, Ocupacion, Escolaridad, Direccion, Telefono, GrupoSanguineo, TipoPaciente, Detalles, Correo)
                    VALUES
                    (@Cedula, @Nombre, @Apellido, @FechaNacimiento, @Genero, @EstadoCivil, @Ocupacion, @Escolaridad, @Direccion, @Telefono, @GrupoSanguineo, @TipoPaciente, @Detalles, @Correo)";

                SqlCommand cmd = new SqlCommand(query, conexion);

                if (panelConocido.Visible)
                {
                    cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@Genero", radioButton2.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@EstadoCivil", DBNull.Value); // Si tienes el control, cámbialo
                    cmd.Parameters.AddWithValue("@Ocupacion", txtOcupacion.Text);
                    cmd.Parameters.AddWithValue("@Escolaridad", DBNull.Value); // Si tienes el control, cámbialo
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", cbGrupoSanguineo.Text);
                    cmd.Parameters.AddWithValue("@TipoPaciente", "Conocido");
                    cmd.Parameters.AddWithValue("@Detalles", txtDetalles.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                }
                else if (panelDesconocido.Visible)
                {
                    cmd.Parameters.AddWithValue("@Cedula", "SIN-CEDULA"); // O usa un textbox si tienes uno
                    cmd.Parameters.AddWithValue("@Nombre", "Desconocido");
                    cmd.Parameters.AddWithValue("@Apellido", "Desconocido");
                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@Genero", radioButton4.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@EstadoCivil", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ocupacion", txtOcupacionDesconocido.Text);
                    cmd.Parameters.AddWithValue("@Escolaridad", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccionDesconocido.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefonoDesconocido.Text);
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", cbGrupoSanguineoDesconocido.Text);
                    cmd.Parameters.AddWithValue("@TipoPaciente", "Desconocido");
                    cmd.Parameters.AddWithValue("@Detalles", txtDetallesDesconocido.Text);
                }

                conexion.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Paciente guardado correctamente.");
            this.Close();

            // Lógica para la vista previa y abrir AgregarCitas...
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}