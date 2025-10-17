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
using System.Data.SqlTypes; // arriba si no lo tienes

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
                    existente.GrupoSanguineo = cbGrupoSanguineo != null ? cbGrupoSanguineo.Text : existente.GrupoSanguineo;

                    var minSql = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                    if (existente.FechaNacimiento < minSql)
                    {
                        MessageBox.Show("La fecha de nacimiento es inválida.");
                        return;
                    }
                    if (existente.FechaRegistro < minSql)
                        existente.FechaRegistro = DateTime.Now;

                    var conn = context.Database.Connection;
                    var wasClosed = conn.State == System.Data.ConnectionState.Closed;
                    if (wasClosed) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "EXEC sp_set_session_context @key, @val;";
                        var pKey = cmd.CreateParameter(); pKey.ParameterName = "@key"; pKey.Value = "AppUser"; cmd.Parameters.Add(pKey);
                        var pVal = cmd.CreateParameter(); pVal.ParameterName = "@val"; pVal.Value = (object)(sistema.Infrastructure.Security.Sesion.UsuarioActual ?? "desconocido"); cmd.Parameters.Add(pVal);
                        cmd.ExecuteNonQuery();
                    }

                    context.SaveChanges();
                    if (wasClosed) conn.Close();
                    MessageBox.Show("Paciente editado correctamente.");
                }
                else
                {
                    _paciente.EstadoCivil = cbCivil.Text;
                    _paciente.Escolaridad = cbEscolaridad.Text;
                    _paciente.Direccion = txtDireccion.Text;
                    _paciente.Telefono = txtTelefono.Text;
                    _paciente.Ocupacion = txtOcupacion.Text;
                    _paciente.GrupoSanguineo = cbGrupoSanguineo != null ? cbGrupoSanguineo.Text : null;

                    var minSql = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                    if (_paciente.FechaNacimiento < minSql)
                    {
                        MessageBox.Show("La fecha de nacimiento es inválida o no fue seleccionada.");
                        return;
                    }
                    if (_paciente.FechaRegistro < minSql)
                        _paciente.FechaRegistro = DateTime.Now;

                    context.Paciente.Add(_paciente);

                    var conn = context.Database.Connection;
                    var wasClosed = conn.State == System.Data.ConnectionState.Closed;
                    if (wasClosed) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "EXEC sp_set_session_context @key, @val;";
                        var pKey = cmd.CreateParameter(); pKey.ParameterName = "@key"; pKey.Value = "AppUser"; cmd.Parameters.Add(pKey);
                        var pVal = cmd.CreateParameter(); pVal.ParameterName = "@val"; pVal.Value = (object)(sistema.Infrastructure.Security.Sesion.UsuarioActual ?? "desconocido"); cmd.Parameters.Add(pVal);
                        cmd.ExecuteNonQuery();
                    }

                    context.SaveChanges();
                    if (wasClosed) conn.Close();
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
            if (cbGrupoSanguineo != null)
                cbGrupoSanguineo.Text = paciente.GrupoSanguineo ?? "";
        }

        // Función auxiliar local
        DateTime MinSqlDate = SqlDateTime.MinValue.Value;

        private void AsegurarFechas()
        {
            // Asegurar FechaNacimiento válida
            if (_paciente.FechaNacimiento < MinSqlDate)
            {
                MessageBox.Show("La fecha de nacimiento es inválida o no fue seleccionada.");
                return;
            }

            // Asegurar FechaRegistro (si no estaba seteada)
            if (_paciente.FechaRegistro < MinSqlDate)
            {
                _paciente.FechaRegistro = DateTime.Now;
            }
        }
    }
}
