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
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if(fechaNacimiento > hoy.AddYears(-edad)) edad--;

            TextBoxEdadDesconocido.Text = edad.ToString();
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
            if (panelConocido.Visible)
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO dbo.PacienteDesconocido
                                    (Cedula, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Edad, Genero, Telefono, TelefonoCelular, Ocupacion, Domicilio, Ciudad, CorreoElectronico, GrupoSanguineo, Religion, Detalles, FechaRegistro)
                                    VALUES (@Cedula, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Edad, @Genero, @Telefono, @TelefonoCelular, @Ocupacion, @Domicilio, @Ciudad, @CorreoElectronico, @GrupoSanguineo, @Religion, @Detalles, @FechaRegistro)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", txtApellidoPa.Text);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", txtApellidoMa.Text);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@Edad", TextBoxEdadDesconocido.Text);
                    cmd.Parameters.AddWithValue("@Genero", radioButton2.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@Telefono", textBox2.Text);
                    cmd.Parameters.AddWithValue("@TelefonoCelular", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Ocupacion", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Domicilio", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", textBox5.Text);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", textBox8.Text);
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Religion", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Detalles", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else if (panelDesconocido.Visible)
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO PacienteConocido
                (FechaRegistro, Nombre, Edad, Genero, TelefonoCelular, Ocupacion, Domicilio, Ciudad, GrupoSanguineo, Religion, Detalles)
                VALUES (@FechaRegistro,@Nombre, @Edad, @Genero, @TelefonoCelular, @Ocupacion, @Domicilio, @Ciudad, @GrupoSanguineo, @Religion, @Detalles)";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Edad", txtBoxEdad.Text);
                    cmd.Parameters.AddWithValue("@Genero", radioButton4.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@TelefonoCelular", textBox12.Text);
                    cmd.Parameters.AddWithValue("@Ocupacion", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Domicilio", textBox13.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", textBox18.Text);
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Religion", textBox17.Text);
                    cmd.Parameters.AddWithValue("@Detalles", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            string nombre = txtNombre.Text == PlaceholderNombre ? "" : txtNombre.Text;
            string apellidoPaterno = txtApellidoPa.Text == PlaceholderApellidoPa ? "" : txtApellidoPa.Text;
            MessageBox.Show("Paciente guardado correctamente.");
            this.Close();

            var preview = new PacientePreview
            {
                Tipo = panelConocido.Visible ? "Conocido" : "Desconocido",
                Nombre = panelConocido.Visible ? txtNombre.Text : "Desconocido",
                Genero = panelConocido.Visible ? (radioButton2.Checked ? "Masculino" : "Femenino") : (radioButton4.Checked ? "Masculino" : "Femenino"),
                GrupoSanguineo = panelConocido.Visible ? comboBox1.Text : comboBox2.Text,
                Edad = panelConocido.Visible ? TextBoxEdadDesconocido.Text : txtBoxEdad.Text
            };

            // Abrir AgregarCitas con la vista previa del paciente
            var agregarCitas = new AgregarCitas(preview);
            agregarCitas.ShowDialog();

        }
    }
}