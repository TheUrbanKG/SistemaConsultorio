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

namespace sistema
{
    public partial class frmDetallePaciente : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;

        public frmDetallePaciente(Paciente paciente, frmPacientes formPacientes)
        {
            InitializeComponent();
            _paciente = paciente ?? new Paciente();
            _formPacientes = formPacientes;

            InicializarGeneroCombo();
            CargarDatosDesdePaciente(_paciente);
        }

        private void InicializarGeneroCombo()
        {
            // Solo permitimos estos dos valores
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Items.Clear();
            cbSexo.Items.AddRange(new[] { "Masculino", "Femenino" });
        }

        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            if (paciente == null) return;

            txtCedula.Text = paciente.Cedula;
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;

            if (paciente.FechaNacimiento >= dtpFechaNacimiento.MinDate &&
                paciente.FechaNacimiento <= dtpFechaNacimiento.MaxDate &&
                paciente.FechaNacimiento.Year > 1900)
            {
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            }
            else
            {
                dtpFechaNacimiento.Value = DateTime.Today;
            }

            // Mapear valores antiguos numéricos (1/2) a texto
            string genero = MapearGenero(paciente.Genero);
            if (!string.IsNullOrWhiteSpace(genero) && cbSexo.Items.Contains(genero))
                cbSexo.SelectedItem = genero;
            else
                cbSexo.SelectedIndex = -1;
        }

        private string MapearGenero(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return null;
            switch (valor.Trim().ToUpperInvariant())
            {
                case "1":
                case "M":
                case "MASC":
                case "MASCULINO":
                    return "Masculino";
                case "2":
                case "F":
                case "FEM":
                case "FEMENINO":
                    return "Femenino";
                default:
                    return valor; // Si ya viene como "Masculino"/"Femenino" lo conserva
            }
        }

        public void PrecargarDatos(Paciente paciente)
        {
            _paciente = paciente ?? new Paciente();
            txtCedula.Text = _paciente.Cedula;
            txtNombre.Text = _paciente.Nombre;
            txtApellido.Text = _paciente.Apellido;
            dtpFechaNacimiento.Value = _paciente.FechaNacimiento == default(DateTime)
                ? DateTime.Today
                : _paciente.FechaNacimiento;

            string genero = MapearGenero(_paciente.Genero);
            if (!string.IsNullOrWhiteSpace(genero) && cbSexo.Items.Contains(genero))
                cbSexo.SelectedItem = genero;
            else
                cbSexo.SelectedIndex = -1;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtCedula.Text) || txtCedula.Text.Trim().Length <= 6)
            {
                errorProvider1.SetError(txtCedula, "Ingrese la cédula (mínimo 7 caracteres).");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Ingrese el apellido.");
                valido = false;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha de nacimiento no puede ser futura.");
                valido = false;
            }

            if (cbSexo.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbSexo, "Seleccione el género.");
                valido = false;
            }

            return valido;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            // Asignar datos al objeto (guardar texto "Masculino"/"Femenino")
            _paciente.Cedula = txtCedula.Text?.Trim();
            _paciente.Nombre = txtNombre.Text?.Trim();
            _paciente.Apellido = txtApellido.Text?.Trim();
            _paciente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
            _paciente.Genero = cbSexo.SelectedItem?.ToString(); // Valor textual definitivo

            // Ir al segundo formulario conservando el mismo objeto
            var paso2 = new frmDetallePaciente2(_paciente, _formPacientes);
            paso2.Show();
            this.Close();
        }
    }
}
