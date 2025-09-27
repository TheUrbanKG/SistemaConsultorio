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
            _paciente = paciente;
            _formPacientes = formPacientes;

            CargarDatosDesdePaciente(_paciente);
        }

        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            txtCedula.Text = paciente.Cedula;
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;
            if (paciente.FechaNacimiento >= dtpFechaNacimiento.MinDate && paciente.FechaNacimiento <= dtpFechaNacimiento.MaxDate)
            {
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            }
            else
            {
                dtpFechaNacimiento.Value = DateTime.Today; // o un valor por defecto
            }


        }


        private bool ValidarDatos()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtCedula.Text) || txtCedula.Text.Trim().Length <= 7)
            {
                errorProvider1.SetError(txtCedula, "Ingrese la cedula");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Ingrese el apellido");
                valido = false;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha de nacimiento no puede ser futura");
                valido = false;
            }



            return valido;
        }

        public void PrecargarDatos(Paciente paciente)
        {
            // Precargar los datos en los controles
            txtCedula.Text = paciente.Cedula;
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;
            dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            cbSexo.Text = paciente.Genero == "1" ? "Masculino" : paciente.Genero == "2" ? "Femenino" : "Otro";
            // ... otros campos del primer formulario ...

            // Guardar referencia al paciente
            _paciente = paciente;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _paciente.Cedula = txtCedula.Text;
                _paciente.Nombre = txtNombre.Text;
                _paciente.Apellido = txtApellido.Text;
                _paciente.Genero = cbSexo.SelectedIndex.ToString();

                DateTime nacimiento = dtpFechaNacimiento.Value;
                int edad = DateTime.Today.Year - nacimiento.Year;
                if (nacimiento > DateTime.Today.AddYears(-edad)) edad--;
                _paciente.FechaNacimiento = dtpFechaNacimiento.Value;


                var frmPaso2 = new frmDetallePaciente2(_paciente, _formPacientes);
                frmPaso2.Show();
                this.Close();
            }
        }
    }
}
