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
using System.Text.RegularExpressions;

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
        private Regex _regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

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
            dtpFechaNacimientoDesconocido.Visible = true;

            ConfigurarValidaciones();
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

        private void ConfigurarValidaciones()
        {
            // Validación para cédula (solo números)
            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Validación para teléfono (solo números y caracteres especiales)
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

            // Validación para nombre y apellido (solo letras y espacios)
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

            // Validación para ocupación (solo letras y espacios)
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

            // Validación de longitud máxima
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

        // MÉTODOS DE VALIDACIÓN
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

            return false;
        }

        private bool ValidarPacienteConocido()
        {
            // Campos obligatorios para paciente conocido
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

            // Validaciones opcionales (solo si se ingresan datos)
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !ValidarCorreo(txtCorreo))
                return false;

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !ValidarTelefono(txtTelefono))
                return false;

            return true;
        }

        private bool ValidarPacienteDesconocido()
        {
            // Solo nombre y género son obligatorios para paciente desconocido
            if (!ValidarNombreDesconocido(txtNombreDesconocido))
                return false;

            if (!ValidarGenero(radioButton4, radioButton3))
                return false;

            // Validaciones opcionales (solo si se ingresan datos)
            if (!string.IsNullOrWhiteSpace(txtTelefonoDesconocido.Text) && !ValidarTelefono(txtTelefonoDesconocido))
                return false;

            return true;
        }

        private bool ValidarCedula(TextBox txtCedulaControl)
        {
            string cedula = txtCedulaControl.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedula) || cedula == PlaceholderCedula)
            {
                MessageBox.Show("La cédula es obligatoria para pacientes conocidos.", "Error de Validación",
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

            if (string.IsNullOrWhiteSpace(nombre) || nombre == PlaceholderNombre)
            {
                MessageBox.Show("El nombre es obligatorio para pacientes conocidos.", "Error de Validación",
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

            if (!_regexSoloLetras.IsMatch(nombre))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarNombreDesconocido(TextBox txtNombreControl)
        {
            string nombre = txtNombreControl.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio para pacientes desconocidos.", "Error de Validación",
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

            if (!_regexSoloLetras.IsMatch(nombre))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarApellido(TextBox txtApellidoControl)
        {
            string apellido = txtApellidoControl.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellido) || apellido == PlaceholderApellidoPa)
            {
                MessageBox.Show("El apellido es obligatorio para pacientes conocidos.", "Error de Validación",
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

            if (!_regexSoloLetras.IsMatch(apellido))
            {
                MessageBox.Show("El apellido solo puede contener letras y espacios.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidoControl.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarFechaNacimiento(DateTime fecha)
        {
            if (fecha > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que el paciente tenga al menos 1 año de edad
            DateTime fechaMinima = DateTime.Today.AddYears(-1);

            if (fecha > fechaMinima)
            {
                MessageBox.Show("El paciente debe tener al menos 1 año de edad.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarGenero(RadioButton rbMasculino, RadioButton rbFemenino)
        {
            if (!rbMasculino.Checked && !rbFemenino.Checked)
            {
                MessageBox.Show("Debe seleccionar el género del paciente.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarTelefono(TextBox txtTelefonoControl)
        {
            string telefono = txtTelefonoControl.Text.Trim();

            // Remover caracteres especiales para contar solo dígitos
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
                return true; // Opcional, no hay error

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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar formulario completo antes de guardar
            if (!ValidarFormularioCompleto())
            {
                return; // No continuar si hay errores de validación
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
                    MessageBox.Show("Paciente guardado correctamente.");
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
            this.Close();
        }
    }
}