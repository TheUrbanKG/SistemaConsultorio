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
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace sistema
{
    public partial class frmDetallePaciente2 : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;
        private byte[] _huellaTemporal;
        private Regex _regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private Regex _regexSoloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);

        public frmDetallePaciente2(Paciente paciente, frmPacientes formPacientes, byte[] huellaTemporal = null)
        {
            InitializeComponent();
            _paciente = paciente;
            _formPacientes = formPacientes;
            _huellaTemporal = huellaTemporal;

            InicializarControles();
            CargarDatosDesdePaciente(_paciente);
        }

        private void InicializarControles()
        {
            // Configurar combos como DropDownList
            cbCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEscolaridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupoSanguineo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar longitud máxima
            txtDireccion.MaxLength = 200;
            txtTelefono.MaxLength = 15;
            txtOcupacion.MaxLength = 50;
            txtCorreo.MaxLength = 100;

            // Configurar eventos de validación
            ConfigurarEventosValidacion();
        }

        private void ConfigurarEventosValidacion()
        {
            // Validación para teléfono (solo números)
            txtTelefono.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '-')
                    e.Handled = true;
            };

            // Validación para ocupación (solo letras y espacios)
            txtOcupacion.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            };

            // Validación al perder foco
            txtTelefono.Validating += (s, e) => ValidarTelefono();
            txtCorreo.Validating += (s, e) => ValidarCorreo();
            txtOcupacion.Validating += (s, e) => ValidarOcupacion();
        }



        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // Validar todos los campos antes de guardar
            if (!ValidarFormulario())
            {
                MessageBox.Show("Por favor, corrija los errores en el formulario antes de continuar.",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new Data.DBContext())
                {
                    Paciente existente = null;

                    if (_paciente.PacienteID != 0)
                    {
                        existente = context.Paciente.FirstOrDefault(p => p.PacienteID == _paciente.PacienteID);
                    }

                    // DEBUG: Verificar que la huella llega al segundo formulario
                    if (_huellaTemporal != null)
                    {
                        MessageBox.Show($"Huella recibida en paso 2: {_huellaTemporal.Length} bytes",
                            "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se recibió huella en el paso 2",
                            "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (existente != null)
                    {
                        // Actualizar paciente existente
                        existente.EstadoCivil = ObtenerValorOpcional(cbCivil.Text);
                        existente.Escolaridad = ObtenerValorOpcional(cbEscolaridad.Text);
                        existente.Direccion = ObtenerValorOpcional(txtDireccion.Text.Trim());
                        existente.Telefono = ObtenerValorOpcional(txtTelefono.Text.Trim());
                        existente.Ocupacion = ObtenerValorOpcional(txtOcupacion.Text.Trim());
                        existente.GrupoSanguineo = ObtenerValorOpcional(cbGrupoSanguineo.Text);
                        existente.Correo = ObtenerValorOpcional(txtCorreo.Text.Trim());

                        if (_huellaTemporal != null && _huellaTemporal.Length > 0)
                        {
                            existente.Huella = _huellaTemporal;
                        }

                        // Mantener datos del primer formulario
                        existente.Genero = _paciente.Genero;
                        existente.FechaNacimiento = _paciente.FechaNacimiento;
                        existente.Cedula = _paciente.Cedula;
                        existente.Nombre = _paciente.Nombre;
                        existente.Apellido = _paciente.Apellido;

                        // Asegurar FechaRegistro
                        if (existente.FechaRegistro < SqlDateTime.MinValue.Value)
                            existente.FechaRegistro = DateTime.Now;

                        EjecutarComandoContexto(context);
                        context.SaveChanges();

                        MessageBox.Show("Paciente editado correctamente.");
                    }
                    else
                    {
                        // Crear nuevo paciente
                        _paciente.EstadoCivil = ObtenerValorOpcional(cbCivil.Text);
                        _paciente.Escolaridad = ObtenerValorOpcional(cbEscolaridad.Text);
                        _paciente.Direccion = ObtenerValorOpcional(txtDireccion.Text.Trim());
                        _paciente.Telefono = ObtenerValorOpcional(txtTelefono.Text.Trim());
                        _paciente.Ocupacion = ObtenerValorOpcional(txtOcupacion.Text.Trim());
                        _paciente.GrupoSanguineo = ObtenerValorOpcional(cbGrupoSanguineo.Text);
                        _paciente.Correo = ObtenerValorOpcional(txtCorreo.Text.Trim());

                        if (_huellaTemporal != null && _huellaTemporal.Length > 0)
                        {
                            _paciente.Huella = _huellaTemporal;
                        }

                        // Asegurar FechaRegistro
                        if (_paciente.FechaRegistro < SqlDateTime.MinValue.Value)
                            _paciente.FechaRegistro = DateTime.Now;

                        context.Paciente.Add(_paciente);
                        EjecutarComandoContexto(context);
                        context.SaveChanges();

                        MessageBox.Show("Paciente guardado exitosamente.");
                    }
                }

                _formPacientes.CargarPacientes();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODOS DE VALIDACIÓN
        private bool ValidarFormulario()
        {
            return ValidarTelefono() && ValidarCorreo() && ValidarOcupacion();
        }

        private bool ValidarTelefono()
        {
            errorProvider1.SetError(txtTelefono, "");

            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrEmpty(telefono))
                return true; // Opcional, no hay error

            // Validar formato básico de teléfono
            if (!EsTelefonoValido(telefono))
            {
                errorProvider1.SetError(txtTelefono, "Formato de teléfono inválido. Use solo números, +, - o espacios.");
                return false;
            }

            // Validar longitud mínima
            if (telefono.Replace(" ", "").Replace("-", "").Replace("+", "").Length < 7)
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener al menos 7 dígitos.");
                return false;
            }

            return true;
        }

        private bool ValidarCorreo()
        {
            errorProvider1.SetError(txtCorreo, "");

            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
                return true; // Opcional, no hay error

            if (!_regexEmail.IsMatch(correo))
            {
                errorProvider1.SetError(txtCorreo, "Formato de correo electrónico inválido.");
                return false;
            }

            return true;
        }

        private bool ValidarOcupacion()
        {
            errorProvider1.SetError(txtOcupacion, "");

            string ocupacion = txtOcupacion.Text.Trim();

            if (string.IsNullOrEmpty(ocupacion))
                return true; // Opcional, no hay error

            if (!_regexSoloLetras.IsMatch(ocupacion))
            {
                errorProvider1.SetError(txtOcupacion, "La ocupación solo puede contener letras y espacios.");
                return false;
            }

            if (ocupacion.Length < 2)
            {
                errorProvider1.SetError(txtOcupacion, "La ocupación debe tener al menos 2 caracteres.");
                return false;
            }

            return true;
        }

        // MÉTODOS AUXILIARES
        private bool EsTelefonoValido(string telefono)
        {
            // Permitir números, +, espacios y guiones
            return Regex.IsMatch(telefono, @"^[\+\d\s\-]+$");
        }

        private string ObtenerValorOpcional(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor;
        }

        private string CapitalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }

        private void EjecutarComandoContexto(Data.DBContext context)
        {
            var conn = context.Database.Connection;
            var wasClosed = conn.State == System.Data.ConnectionState.Closed;
            if (wasClosed) conn.Open();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "EXEC sp_set_session_context @key, @val;";
                var pKey = cmd.CreateParameter();
                pKey.ParameterName = "@key";
                pKey.Value = "AppUser";
                cmd.Parameters.Add(pKey);

                var pVal = cmd.CreateParameter();
                pVal.ParameterName = "@val";
                pVal.Value = (object)(sistema.Infrastructure.Security.Sesion.UsuarioActual ?? "desconocido");
                cmd.Parameters.Add(pVal);

                cmd.ExecuteNonQuery();
            }

            if (wasClosed) conn.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            var frmPaso1 = new frmDetallePaciente(_paciente, _formPacientes);
            frmPaso1.PrecargarDatos(_paciente);
            frmPaso1.Show();
            this.Close();
        }

        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            if (paciente == null) return;

            cbCivil.Text = paciente.EstadoCivil ?? "";
            cbEscolaridad.Text = paciente.Escolaridad ?? "";
            txtDireccion.Text = paciente.Direccion ?? "";
            txtTelefono.Text = paciente.Telefono ?? "";
            txtOcupacion.Text = paciente.Ocupacion ?? "";
            cbGrupoSanguineo.Text = paciente.GrupoSanguineo ?? "";
            txtCorreo.Text = paciente.Correo ?? "";
        }
    }
}