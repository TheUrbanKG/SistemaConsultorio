
using DPFP;
using sistema.Main.Pacientes;
using sistema.Models;
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
using static DPFP.Processing.Enrollment;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sistema
{
    public partial class frmDetallePaciente : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);
        private DPFP.Template Template;

        private byte[] _huellaTemporal;

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
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Items.AddRange(new[] { "Masculino", "Femenino" });

            txtCedula.MaxLength = 20;
            txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;

            ConfigurarEventosValidacion();

            pictureBoxHuella.Cursor = Cursors.Hand;
            pictureBoxHuella.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHuella.Image = Properties.Resources.huella_vacia;
            toolTip1.SetToolTip(pictureBoxHuella, "Click para registrar huella");
        }


        private void pictureBoxHuella_Click_1(object sender, EventArgs e)
        {
            CapturarHuella capturarHuella = new CapturarHuella();
            capturarHuella.OnTemplate += OnTemplate;
            capturarHuella.ShowDialog();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                btnAgregar.Enabled = (Template != null);
                btnAgregar.Visible = (Template != null);
                if (Template != null)
                {
                    // Convertir inmediatamente a bytes y guardar en la variable
                    try
                    {
                        using (var stream = new System.IO.MemoryStream())
                        {
                            Template.Serialize(stream);
                            _huellaTemporal = stream.ToArray(); // ← GUARDAR aquí
                        }
                        MessageBox.Show($"Huella capturada y convertida: {_huellaTemporal.Length} bytes",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir huella: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                }
            }));
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

                byte[] huellaBytes = null;
                if (Template != null)
                {
                    try
                    {
                        using (var stream = new System.IO.MemoryStream())
                        {
                            Template.Serialize(stream);
                            huellaBytes = stream.ToArray();

                            // DEBUG: Verificar la conversión
                            MessageBox.Show($"Huella convertida a bytes. Tamaño: {huellaBytes.Length} bytes",
                                "Conversión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir huella: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha capturado ninguna huella. ¿Desea continuar sin huella?",
                        "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }


                var paso2 = new frmDetallePaciente2(_paciente, _formPacientes, _huellaTemporal);
                paso2.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            txtCedula.Text = paciente.Cedula;
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;

            if (paciente.FechaNacimiento.Year > 1900 && paciente.FechaNacimiento <= DateTime.Today)
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;

            if (!string.IsNullOrWhiteSpace(paciente.Genero) && cbSexo.Items.Contains(paciente.Genero))
                cbSexo.SelectedItem = paciente.Genero;
        }

        private void ConfigurarEventosValidacion()
        {
            txtCedula.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };
            txtNombre.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; };
            txtApellido.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; };

            txtCedula.Validating += (s, e) => ValidarCedula();
            txtNombre.Validating += (s, e) => ValidarNombre();
            txtApellido.Validating += (s, e) => ValidarApellido();
            dtpFechaNacimiento.Validating += (s, e) => ValidarFechaNacimiento();
            cbSexo.Validating += (s, e) => ValidarGenero();
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
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad)) edad--;

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
            return ValidarCedula() && ValidarNombre() && ValidarApellido() &&
                   ValidarFechaNacimiento() && ValidarGenero();
        }

        private string CapitalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return texto;
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }
        public void PrecargarDatos(Paciente paciente)
        {
            _paciente = paciente ?? new Paciente();
            CargarDatosDesdePaciente(_paciente);
        }
    }
}