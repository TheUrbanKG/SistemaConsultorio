using sistema.Models;
using SistemaConsultorio.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sistema
{
    public partial class frmDetallePaciente : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

        // Variables para el sistema de huellas
        private FingerprintManager fingerprintManager;
        private bool lectorConectado = false;
        private byte[] huellaTemporal; // Para almacenar huella antes de guardar paciente

        public frmDetallePaciente(Paciente paciente, frmPacientes formPacientes)
        {
            InitializeComponent();
            _paciente = paciente ?? new Paciente();
            _formPacientes = formPacientes;

            InicializarControles();
            CargarDatosDesdePaciente(_paciente);

            // Inicializar sistema de huellas (para pacientes nuevos y existentes)
            InitializeFingerprintSystem();
        }

        private void InicializarControles()
        {
            // Configurar combo de género
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Items.AddRange(new[] { "Masculino", "Femenino" });

            // Configurar longitud máxima
            txtCedula.MaxLength = 20;
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;

            // Configurar eventos de validación
            ConfigurarEventosValidacion();

            // Configurar pictureBox de huella
            pictureBoxHuella.Cursor = Cursors.Hand;
            pictureBoxHuella.SizeMode = PictureBoxSizeMode.Zoom;

            // Actualizar estado inicial de la huella
            ActualizarEstadoHuellaInicial();
        }

        // SISTEMA DE HUELLAS DIGITALES
        private void InitializeFingerprintSystem()
        {
            fingerprintManager = new FingerprintManager();

            fingerprintManager.OnStatusChanged += (mensaje) =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => ActualizarEstadoHuella(mensaje)));
                }
                else
                {
                    ActualizarEstadoHuella(mensaje);
                }
            };

            fingerprintManager.OnHuellaCapturada += () =>
            {
                this.Invoke(new Action(() => ProcesarHuellaCapturada()));
            };

            fingerprintManager.OnRegistrationResult += (exito, mensaje) =>
            {
                this.Invoke(new Action(() =>
                {
                    if (exito)
                    {
                        MessageBox.Show(mensaje, "Registro Exitoso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pictureBoxHuella.Image = Properties.Resources.huella_registrada;
                        lblEstadoHuella.Text = "Huella registrada";
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };

            // Conectar automáticamente
            ConectarLectorAutomaticamente();
        }

        private void ActualizarEstadoHuellaInicial()
        {
            if (_paciente.PacienteID == 0) // Paciente nuevo
            {
                pictureBoxHuella.Image = Properties.Resources.huella_vacia;
                lblEstadoHuella.Text = "Registrar huella";
                toolTip1.SetToolTip(pictureBoxHuella, "Click para registrar huella (opcional)");
            }
            else // Paciente existente
            {
                pictureBoxHuella.Image = Properties.Resources.huella_vacia;
                lblEstadoHuella.Text = "Verificando...";
                toolTip1.SetToolTip(pictureBoxHuella, "Verificando estado de huella");
            }
        }

        private void ConectarLectorAutomaticamente()
        {
            lectorConectado = fingerprintManager.Connect("COM3", 57600);
            if (lectorConectado)
            {
                ActualizarEstadoHuella("Lector conectado");

                // Si es paciente existente, verificar si ya tiene huella
                if (_paciente.PacienteID > 0)
                {
                    VerificarHuellaExistente();
                }
            }
            else
            {
                ActualizarEstadoHuella("Lector no conectado");
                pictureBoxHuella.Image = Properties.Resources.huella_error;
            }
        }

        private void VerificarHuellaExistente()
        {
            try
            {
                bool tieneHuella = fingerprintManager.CheckPacienteFingerprintAvailable(_paciente.PacienteID);
                if (tieneHuella)
                {
                    pictureBoxHuella.Image = Properties.Resources.huella_registrada;
                    lblEstadoHuella.Text = "Huella registrada";
                    toolTip1.SetToolTip(pictureBoxHuella, "Click para reemplazar huella");
                }
                else
                {
                    pictureBoxHuella.Image = Properties.Resources.huella_vacia;
                    lblEstadoHuella.Text = "Registrar huella";
                    toolTip1.SetToolTip(pictureBoxHuella, "Click para registrar huella");
                }
            }
            catch
            {
                pictureBoxHuella.Image = Properties.Resources.huella_error;
                lblEstadoHuella.Text = "Error verificar huella";
            }
        }

        private void ActualizarEstadoHuella(string mensaje)
        {
            lblEstadoHuella.Text = mensaje;
            toolTip1.SetToolTip(pictureBoxHuella, mensaje);
        }

        private void RegistrarHuellaPaciente()
        {
            if (!lectorConectado)
            {
                var resultado = MessageBox.Show("El lector de huellas no está conectado. ¿Desea conectarlo ahora?",
                                              "Lector No Conectado",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ConectarLectorAutomaticamente();
                    if (!lectorConectado) return;
                }
                else
                {
                    return;
                }
            }

            // Para pacientes existentes, verificar si ya tiene huella
            if (_paciente.PacienteID > 0)
            {
                bool tieneHuella = fingerprintManager.CheckPacienteFingerprintAvailable(_paciente.PacienteID);

                if (tieneHuella)
                {
                    var resultado = MessageBox.Show("Este paciente ya tiene una huella registrada. ¿Desea reemplazarla?",
                                                  "Huella Existente",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                        return;
                }
            }

            // Iniciar proceso de registro
            fingerprintManager.StartCapture(FingerprintMode.RegistroPaciente);
            lblEstadoHuella.Text = "Coloque el dedo en el sensor...";
        }

        private void ProcesarHuellaCapturada()
        {
            var template = fingerprintManager.GetCapturedTemplate();

            if (template != null && template.Length > 0)
            {
                if (_paciente.PacienteID > 0) // Paciente existente
                {
                    // Registrar directamente en la base de datos
                    bool exito = fingerprintManager.RegisterPacienteFingerprint(_paciente.PacienteID, template);

                    if (exito)
                    {
                        pictureBoxHuella.Image = Properties.Resources.huella_registrada;
                        lblEstadoHuella.Text = "Huella registrada";
                        MessageBox.Show("Huella registrada exitosamente!", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar la huella en la base de datos",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBoxHuella.Image = SystemIcons.Error.ToBitmap();
                    }
                }
                else // Paciente nuevo
                {
                    // Guardar huella temporalmente hasta que se guarde el paciente
                    huellaTemporal = template;
                    pictureBoxHuella.Image = Properties.Resources.huella_registrada;
                    lblEstadoHuella.Text = "Huella lista para guardar";
                    toolTip1.SetToolTip(pictureBoxHuella, "Huella capturada - Se guardará con el paciente");

                    MessageBox.Show("Huella capturada correctamente. Se guardará cuando registre el paciente.",
                                  "Huella Capturada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se pudo capturar la huella correctamente. Intente nuevamente.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBoxHuella.Image = Properties.Resources.huella_error;
            }
        }

        // Método para obtener la huella temporal (será llamado desde frmDetallePaciente2)
        public byte[] ObtenerHuellaTemporal()
        {
            return huellaTemporal;
        }

        // Método para verificar si hay huella temporal
        public bool TieneHuellaTemporal()
        {
            return huellaTemporal != null && huellaTemporal.Length > 0;
        }

        // [TUS MÉTODOS EXISTENTES SE MANTIENEN IGUAL]
        private void ConfigurarEventosValidacion()
        {
            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

            // Validación al perder foco
            txtCedula.Validating += (s, e) => ValidarCedula();
            txtNombre.Validating += (s, e) => ValidarNombre();
            txtApellido.Validating += (s, e) => ValidarApellido();
            dtpFechaNacimiento.Validating += (s, e) => ValidarFechaNacimiento();
            cbSexo.Validating += (s, e) => ValidarGenero();
        }

        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            if (paciente == null) return;

            txtCedula.Text = paciente.Cedula;
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;

            if (paciente.FechaNacimiento != default(DateTime) &&
                paciente.FechaNacimiento.Year > 1900 &&
                paciente.FechaNacimiento <= DateTime.Today)
            {
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            }

            if (!string.IsNullOrWhiteSpace(paciente.Genero) &&
                cbSexo.Items.Contains(paciente.Genero))
            {
                cbSexo.SelectedItem = paciente.Genero;
            }
        }

        private bool ValidarCedula()
        {
            errorProvider1.SetError(txtCedula, "");
            string cedula = txtCedula.Text.Trim();
            if (string.IsNullOrEmpty(cedula))
            {
                errorProvider1.SetError(txtCedula, "La cédula es obligatoria.");
                return false;
            }
            if (cedula.Length < 7)
            {
                errorProvider1.SetError(txtCedula, "La cédula debe tener al menos 7 dígitos.");
                return false;
            }
            return true;
        }

        private bool ValidarNombre()
        {
            errorProvider1.SetError(txtNombre, "");
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio.");
                return false;
            }
            if (nombre.Length < 2)
            {
                errorProvider1.SetError(txtNombre, "El nombre debe tener al menos 2 caracteres.");
                return false;
            }
            if (!_regexSoloLetras.IsMatch(nombre))
            {
                errorProvider1.SetError(txtNombre, "Solo se permiten letras y espacios.");
                return false;
            }
            return true;
        }

        private bool ValidarApellido()
        {
            errorProvider1.SetError(txtApellido, "");
            string apellido = txtApellido.Text.Trim();
            if (string.IsNullOrEmpty(apellido))
            {
                errorProvider1.SetError(txtApellido, "El apellido es obligatorio.");
                return false;
            }
            if (apellido.Length < 2)
            {
                errorProvider1.SetError(txtApellido, "El apellido debe tener al menos 2 caracteres.");
                return false;
            }
            if (!_regexSoloLetras.IsMatch(apellido))
            {
                errorProvider1.SetError(txtApellido, "Solo se permiten letras y espacios.");
                return false;
            }
            return true;
        }

        private bool ValidarFechaNacimiento()
        {
            errorProvider1.SetError(dtpFechaNacimiento, "");
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            DateTime fechaActual = DateTime.Today;

            if (fechaNacimiento > fechaActual)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha no puede ser futura.");
                return false;
            }
            if (fechaNacimiento.Year < 1900)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha no es válida.");
                return false;
            }

            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            if (edad < 1)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "El paciente debe tener al menos 1 año de edad.");
                return false;
            }
            return true;
        }

        private bool ValidarGenero()
        {
            errorProvider1.SetError(cbSexo, "");
            if (cbSexo.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbSexo, "Seleccione el género.");
                return false;
            }
            return true;
        }

        private bool ValidarFormularioCompleto()
        {
            return ValidarCedula() &&
                   ValidarNombre() &&
                   ValidarApellido() &&
                   ValidarFechaNacimiento() &&
                   ValidarGenero();
        }

        private string CapitalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioCompleto())
            {
                MessageBox.Show("Por favor, corrija los errores en el formulario antes de continuar.",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _paciente.Cedula = txtCedula.Text.Trim();
                _paciente.Nombre = CapitalizarTexto(txtNombre.Text.Trim());
                _paciente.Apellido = CapitalizarTexto(txtApellido.Text.Trim());
                _paciente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                _paciente.Genero = cbSexo.SelectedItem.ToString();

                // Pasar también la huella temporal si existe
                var paso2 = new frmDetallePaciente2(_paciente, _formPacientes, huellaTemporal);
                paso2.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PrecargarDatos(Paciente paciente)
        {
            _paciente = paciente ?? new Paciente();
            CargarDatosDesdePaciente(_paciente);
        }

        private void frmDetallePaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            fingerprintManager?.Disconnect();
        }

        private void pictureBoxHuella_Click_1(object sender, EventArgs e)
        {
            RegistrarHuellaPaciente();
        }
    }
}