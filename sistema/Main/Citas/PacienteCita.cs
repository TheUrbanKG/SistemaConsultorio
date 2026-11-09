using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private Font fuentePlaceholder;
        private Font fuenteNormal;
        private Regex _regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

        public PacienteCita()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint, true);

            fuentePlaceholder = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            fuenteNormal = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            panelConocido.Visible = false;
            panelDesconocido.Visible = false;

            InicializarCampos();
            dtpFechaNacimiento.Visible = false;
            dtpFechaNacimientoDesconocido.Visible = true;

            ConfigurarValidaciones();
        }

        private void InicializarCampos()
        {
            // Cedula
            txtCedula.Text = PlaceholderCedula;
            txtCedula.ForeColor = Color.FromArgb(148, 163, 184);
            txtCedula.Font = fuentePlaceholder;
            txtCedula.BackColor = Color.White;
            lblCedula.ForeColor = Color.FromArgb(71, 85, 105);

            // Nombre
            txtNombre.Text = PlaceholderNombre;
            txtNombre.ForeColor = Color.FromArgb(148, 163, 184);
            txtNombre.Font = fuentePlaceholder;
            txtNombre.BackColor = Color.White;
            lblNombre.ForeColor = Color.FromArgb(71, 85, 105);

            // Apellido Paterno
            txtApellido.Text = PlaceholderApellidoPa;
            txtApellido.ForeColor = Color.FromArgb(148, 163, 184);
            txtApellido.Font = fuentePlaceholder;
            txtApellido.BackColor = Color.White;
            lblApellidoPa.ForeColor = Color.FromArgb(71, 85, 105);
        }

        private void ConfigurarValidaciones()
        {
            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            txtTelefono.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
                    e.Handled = true;
            };

            txtTelefonoDesconocido.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
                    e.Handled = true;
            };

            txtNombre.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtApellido.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtNombreDesconocido.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtOcupacion.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtOcupacionDesconocido.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtCedula.MaxLength = 20;
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtNombreDesconocido.MaxLength = 50;
            txtTelefono.MaxLength = 15;
            txtTelefonoDesconocido.MaxLength = 15;
            txtOcupacion.MaxLength = 50;
            txtOcupacionDesconocido.MaxLength = 50;
            txtDireccion.MaxLength = 200;
            txtDireccionDesconocido.MaxLength = 200;
            txtCorreo.MaxLength = 100;
        }

        private bool ValidarFormularioCompleto()
        {
            if (panelConocido.Visible)
            {
                return ValidarPacienteConocido();
            }
            else if (panelDesconocido.Visible)
            {
                return ValidarPacienteDesconocido();
            }

            MessageBox.Show("Por favor seleccione si es un paciente conocido o desconocido.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool ValidarPacienteConocido()
        {
            if (!ValidarCedula(txtCedula))
                return false;

            if (!ValidarNombre(txtNombre))
                return false;

            if (!ValidarApellido(txtApellido))
                return false;

            if (!ValidarFechaNacimiento(dtpFechaNacimiento.Value))
                return false;

            if (!ValidarGenero(radioButton2, radioButton1))
                return false;

            if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !ValidarCorreo(txtCorreo))
                return false;

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !ValidarTelefono(txtTelefono))
                return false;

            return true;
        }

        private bool ValidarPacienteDesconocido()
        {
            if (!ValidarNombreDesconocido(txtNombreDesconocido))
                return false;

            if (!ValidarGenero(radioButton4, radioButton3))
                return false;

            if (!string.IsNullOrWhiteSpace(txtTelefonoDesconocido.Text) && !ValidarTelefono(txtTelefonoDesconocido))
                return false;

            return true;
        }

        private bool ValidarCedula(TextBox txtCedulaControl)
        {
            string cedula = txtCedulaControl.Text.Trim();

            if (string.IsNullOrEmpty(cedula) || cedula == PlaceholderCedula)
            {
                MessageBox.Show("La cédula es obligatoria.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedulaControl.Focus();
                return false;
            }

            if (cedula.Length < 7)
            {
                MessageBox.Show("La cédula debe tener al menos 7 dígitos.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedulaControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarNombre(TextBox txtNombreControl)
        {
            string nombre = txtNombreControl.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || nombre == PlaceholderNombre)
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreControl.Focus();
                return false;
            }

            if (nombre.Length < 2)
            {
                MessageBox.Show("El nombre debe tener al menos 2 caracteres.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarNombreDesconocido(TextBox txtNombreControl)
        {
            string nombre = txtNombreControl.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre o identificador para el paciente.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarApellido(TextBox txtApellidoControl)
        {
            string apellido = txtApellidoControl.Text.Trim();

            if (string.IsNullOrEmpty(apellido) || apellido == PlaceholderApellidoPa)
            {
                MessageBox.Show("El apellido es obligatorio.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidoControl.Focus();
                return false;
            }

            if (apellido.Length < 2)
            {
                MessageBox.Show("El apellido debe tener al menos 2 caracteres.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidoControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarFechaNacimiento(DateTime fecha)
        {
            if (string.IsNullOrEmpty(txtFechaNacimiento.Text))
            {
                MessageBox.Show("La fecha de nacimiento es obligatoria.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (fecha > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarGenero(RadioButton rbMasculino, RadioButton rbFemenino)
        {
            if (!rbMasculino.Checked && !rbFemenino.Checked)
            {
                MessageBox.Show("Debe seleccionar un género.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarTelefono(TextBox txtTelefonoControl)
        {
            string telefono = txtTelefonoControl.Text.Trim();
            string soloDigitos = new string(telefono.Where(char.IsDigit).ToArray());

            if (soloDigitos.Length < 7)
            {
                MessageBox.Show("El teléfono debe tener al menos 7 dígitos.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefonoControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCorreo(TextBox txtCorreoControl)
        {
            string correo = txtCorreoControl.Text.Trim();

            if (string.IsNullOrEmpty(correo))
                return true;

            if (!_regexEmail.IsMatch(correo))
            {
                MessageBox.Show("Formato de correo electrónico inválido.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreoControl.Focus();
                return false;
            }

            return true;
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSi.Checked)
            {
                panelSi.BackColor = Color.FromArgb(0, 168, 89);
                panelNo.BackColor = Color.FromArgb(226, 232, 240);
                rbSi.ForeColor = Color.FromArgb(0, 140, 70);
                rbNo.ForeColor = Color.FromArgb(100, 116, 139);

                panelConocido.Visible = true;
                panelDesconocido.Visible = false;
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                panelNo.BackColor = Color.FromArgb(245, 158, 11);
                panelSi.BackColor = Color.FromArgb(226, 232, 240);
                rbNo.ForeColor = Color.FromArgb(180, 83, 9);
                rbSi.ForeColor = Color.FromArgb(100, 116, 139);

                panelConocido.Visible = false;
                panelDesconocido.Visible = true;
            }
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            txtCedula.BackColor = Color.FromArgb(240, 253, 244);

            if (txtCedula.Text == PlaceholderCedula)
            {
                txtCedula.Text = "";
                txtCedula.ForeColor = Color.FromArgb(15, 23, 42);
                txtCedula.Font = fuenteNormal;
            }
            lblCedula.ForeColor = Color.FromArgb(0, 168, 89);
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                txtCedula.Text = PlaceholderCedula;
                txtCedula.ForeColor = Color.FromArgb(220, 38, 38);
                txtCedula.BackColor = Color.FromArgb(254, 242, 242);
                txtCedula.Font = fuentePlaceholder;
                lblCedula.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                txtCedula.ForeColor = Color.FromArgb(15, 23, 42);
                txtCedula.BackColor = Color.White;
                txtCedula.Font = fuenteNormal;
                lblCedula.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.FromArgb(240, 253, 244);

            if (txtNombre.Text == PlaceholderNombre)
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.FromArgb(15, 23, 42);
                txtNombre.Font = fuenteNormal;
            }
            lblNombre.ForeColor = Color.FromArgb(0, 168, 89);
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = PlaceholderNombre;
                txtNombre.ForeColor = Color.FromArgb(220, 38, 38);
                txtNombre.BackColor = Color.FromArgb(254, 242, 242);
                txtNombre.Font = fuentePlaceholder;
                lblNombre.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                txtNombre.ForeColor = Color.FromArgb(15, 23, 42);
                txtNombre.BackColor = Color.White;
                txtNombre.Font = fuenteNormal;
                lblNombre.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        private void txtApellidoPa_Enter(object sender, EventArgs e)
        {
            txtApellido.BackColor = Color.FromArgb(240, 253, 244);

            if (txtApellido.Text == PlaceholderApellidoPa)
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.FromArgb(15, 23, 42);
                txtApellido.Font = fuenteNormal;
            }
            lblApellidoPa.ForeColor = Color.FromArgb(0, 168, 89);
        }

        private void txtApellidoPa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = PlaceholderApellidoPa;
                txtApellido.ForeColor = Color.FromArgb(220, 38, 38);
                txtApellido.BackColor = Color.FromArgb(254, 242, 242);
                txtApellido.Font = fuentePlaceholder;
                lblApellidoPa.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                txtApellido.ForeColor = Color.FromArgb(15, 23, 42);
                txtApellido.BackColor = Color.White;
                txtApellido.Font = fuenteNormal;
                lblApellidoPa.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        private void PacienteCita_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dtpFechaNacimiento.Visible = true;
            dtpFechaNacimiento.Focus();
            SendKeys.Send("%{DOWN}");
        }

        private void dtpFechaNacimiento_CloseUp(object sender, EventArgs e)
        {
            txtFechaNacimiento.Text = dtpFechaNacimiento.Value.ToString("dd/MM/yyyy");
            dtpFechaNacimiento.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioCompleto())
            {
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Paciente
                    (Cedula, Nombre, Apellido, FechaNacimiento, Genero, EstadoCivil, Ocupacion, Escolaridad, Direccion, Telefono, GrupoSanguineo, TipoPaciente, Detalles, Correo, FechaRegistro)
                    VALUES
                    (@Cedula, @Nombre, @Apellido, @FechaNacimiento, @Genero, @EstadoCivil, @Ocupacion, @Escolaridad, @Direccion, @Telefono, @GrupoSanguineo, @TipoPaciente, @Detalles, @Correo, @FechaRegistro)";

                SqlCommand cmd = new SqlCommand(query, conexion);
                DateTime fechaRegistro = DateTime.Now;

                if (panelConocido.Visible)
                {
                    cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", CapitalizarTexto(txtNombre.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Apellido", CapitalizarTexto(txtApellido.Text.Trim()));
                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@Genero", radioButton2.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@EstadoCivil", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ocupacion", string.IsNullOrWhiteSpace(txtOcupacion.Text) ? DBNull.Value : (object)CapitalizarTexto(txtOcupacion.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Escolaridad", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(txtDireccion.Text) ? DBNull.Value : (object)txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(txtTelefono.Text) ? "No especificado" : txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", string.IsNullOrWhiteSpace(cbGrupoSanguineo.Text) ? DBNull.Value : (object)cbGrupoSanguineo.Text);
                    cmd.Parameters.AddWithValue("@TipoPaciente", "Conocido");
                    cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrWhiteSpace(txtDetalles.Text) ? DBNull.Value : (object)txtDetalles.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", string.IsNullOrWhiteSpace(txtCorreo.Text) ? DBNull.Value : (object)txtCorreo.Text.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                }
                else if (panelDesconocido.Visible)
                {
                    string cedulaUnica = GenerarCedulaUnicaParaDesconocido();

                    cmd.Parameters.AddWithValue("@Cedula", cedulaUnica);
                    cmd.Parameters.AddWithValue("@Nombre", CapitalizarTexto(txtNombreDesconocido.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Apellido", "Desconocido");
                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimientoDesconocido.Value);
                    cmd.Parameters.AddWithValue("@Genero", radioButton4.Checked ? "Masculino" : "Femenino");
                    cmd.Parameters.AddWithValue("@EstadoCivil", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ocupacion", string.IsNullOrWhiteSpace(txtOcupacionDesconocido.Text) ? DBNull.Value : (object)CapitalizarTexto(txtOcupacionDesconocido.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Escolaridad", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrWhiteSpace(txtDireccionDesconocido.Text) ? DBNull.Value : (object)txtDireccionDesconocido.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(txtTelefonoDesconocido.Text) ? "No especificado" : txtTelefonoDesconocido.Text.Trim());
                    cmd.Parameters.AddWithValue("@GrupoSanguineo", string.IsNullOrWhiteSpace(cbGrupoSanguineoDesconocido.Text) ? DBNull.Value : (object)cbGrupoSanguineoDesconocido.Text);
                    cmd.Parameters.AddWithValue("@TipoPaciente", "Desconocido");
                    cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrWhiteSpace(txtDetallesDesconocido.Text) ? DBNull.Value : (object)txtDetallesDesconocido.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                }

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el paciente: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerarCedulaUnicaParaDesconocido()
        {
            return "DESC-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private string CapitalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.FromArgb(203, 213, 225), 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(p, 0, panel1.Height - 1, panel1.Width, panel1.Height - 1);
            }
        }

        private void panelBorde_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            }
        }
    }
}
