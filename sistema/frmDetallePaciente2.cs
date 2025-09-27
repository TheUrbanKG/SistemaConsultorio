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
    public partial class frmDetallePaciente2 : MetroFramework.Forms.MetroForm
    {
        private frmPacientes _formPacientes;
        private Paciente _paciente;

        public frmDetallePaciente2(Paciente paciente, frmPacientes formPacientes)
        {
            InitializeComponent();
            _paciente = paciente;
            _formPacientes = formPacientes;
            CargarDatosDesdePaciente(_paciente);
        }


        private void btnRegistro_Click(object sender, EventArgs e)
        {
            using (var context = new Data.DBContext())
            {
                Paciente existente = null;

                if (_paciente.PacienteID != 0)
                {
                    existente = context.Paciente.FirstOrDefault(p => p.PacienteID == _paciente.PacienteID);
                }

                if (existente != null)
                {
                    existente.EstadoCivil = cbCivil.Text;
                    existente.Escolaridad = cbEscolaridad.Text;
                    existente.Direccion = txtDireccion.Text;
                    existente.Telefono = txtTelefono.Text;
                    existente.Ocupacion = txtOcupacion.Text;
                    existente.Genero = _paciente.Genero;
                    existente.FechaNacimiento = _paciente.FechaNacimiento;
                    existente.Cedula = _paciente.Cedula;
                    existente.Nombre = _paciente.Nombre;
                    existente.Apellido = _paciente.Apellido;

                    context.SaveChanges();
                    MessageBox.Show("Paciente editado correctamente.");
                }
                else
                {
                    _paciente.EstadoCivil = cbCivil.Text;
                    _paciente.Escolaridad = cbEscolaridad.Text;
                    _paciente.Direccion = txtDireccion.Text;
                    _paciente.Telefono = txtTelefono.Text;
                    _paciente.Ocupacion = txtOcupacion.Text;

                    context.Paciente.Add(_paciente);
                    context.SaveChanges();
                    MessageBox.Show("Paciente guardado exitosamente.");
                }
            }

            _formPacientes.CargarPacientes();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            var frmPaso1 = new frmDetallePaciente(_paciente, _formPacientes);
            frmPaso1.PrecargarDatos(_paciente);
            frmPaso1.Show();
            this.Close(); // Cierra este formulario
        }

        private void CargarDatosDesdePaciente(Paciente paciente)
        {
            cbCivil.Text = paciente.EstadoCivil ?? "";
            cbEscolaridad.Text = paciente.Escolaridad ?? "";
            txtDireccion.Text = paciente.Direccion ?? "";
            txtTelefono.Text = paciente.Telefono ?? "";
            txtOcupacion.Text = paciente.Ocupacion ?? "";
            // Si tienes otros campos, agrégalos aquí
        }
    }
}
