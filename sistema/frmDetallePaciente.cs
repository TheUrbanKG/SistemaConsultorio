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
using System.Text.RegularExpressions;

namespace sistema
{
    public partial class frmDetallePaciente : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

        public frmDetallePaciente(Paciente paciente, frmPacientes formPacientes)
        {
            InitializeComponent();
            _paciente = paciente ?? new Paciente();
            _formPacientes = formPacientes;

            InicializarControles();
            CargarDatosDesdePaciente(_paciente);
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
        }

        private void ConfigurarEventosValidacion()
        {
            // Validación en tiempo real para campos de texto
            txtCedula.KeyPress += (s, e) =>
            {
                // Permitir solo números, backspace y delete
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            txtNombre.KeyPress += (s, e) =>
            {
                // Permitir solo letras, espacios y controles
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            txtApellido.KeyPress += (s, e) =>
            {
                // Permitir solo letras, espacios y controles
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

            // Fecha de nacimiento con validación
            if (paciente.FechaNacimiento != default(DateTime) &&
                paciente.FechaNacimiento.Year > 1900 &&
                paciente.FechaNacimiento <= DateTime.Today)
            {
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            }

            // Género
            if (!string.IsNullOrWhiteSpace(paciente.Genero) &&
                cbSexo.Items.Contains(paciente.Genero))
            {
                cbSexo.SelectedItem = paciente.Genero;
            }
        }

        // MÉTODOS DE VALIDACIÓN OPTIMIZADOS
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

            // Validar que no sea fecha futura
            if (fechaNacimiento > fechaActual)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha no puede ser futura.");
                return false;
            }

            // Validar que no sea menor a 1900
            if (fechaNacimiento.Year < 1900)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha no es válida.");
                return false;
            }

            // Validar que el paciente tenga al menos 1 año de edad
            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Ajustar si aún no ha cumplido años este año
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
                // Asignar datos al objeto
                _paciente.Cedula = txtCedula.Text.Trim();
                _paciente.Nombre = CapitalizarTexto(txtNombre.Text.Trim());
                _paciente.Apellido = CapitalizarTexto(txtApellido.Text.Trim());
                _paciente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                _paciente.Genero = cbSexo.SelectedItem.ToString();

                // Ir al segundo formulario
                var paso2 = new frmDetallePaciente2(_paciente, _formPacientes);
                paso2.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método público para precargar datos (si aún lo necesitas)
        public void PrecargarDatos(Paciente paciente)
        {
            _paciente = paciente ?? new Paciente();
            CargarDatosDesdePaciente(_paciente);
        }
    }
}