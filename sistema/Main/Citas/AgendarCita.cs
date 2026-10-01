using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class AgendarCita : MetroFramework.Forms.MetroForm
    {
        public DateTime FechaSeleccionada { get; set; }
        private PacientePreview _paciente; // Campo privado

        public AgendarCita()
        {
            InitializeComponent();
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true;
            dtpHora.Value = DateTime.Today.AddHours(8);
        }

        public void SetPaciente(PacientePreview paciente)
        {
            this._paciente = paciente;

            if (_paciente != null)
            {
                lblNombrePaciente.Text = _paciente.Nombre ?? "No disponible";
                lblEdadPaciente.Text = _paciente.Edad ?? "No disponible";
                lblGeneroPaciente.Text = _paciente.Genero ?? "No disponible";
                lblTipoSangre.Text = _paciente.GrupoSanguineo ?? "No disponible";
            }
            else
            {
                MessageBox.Show("Error: No se recibió información del paciente.");
            }
        }

        public void SetFechaCita(DateTime fecha)
        {
            lblFechaCita.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void AgendarCita_Load(object sender, EventArgs e)
        {
            lblFechaCita.Text = FechaSeleccionada.ToString("dd/MM/yyyy");
            CargarDoctores();
        }

        private void CargarDoctores()
        {
            cbDoctor.Items.Clear();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT Usuario, Nombre, Apellido, Rol FROM login WHERE Status = 'Habilitado' AND Rol IN ('Usuario', 'Administrador') ORDER BY Nombre, Apellido", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nom = reader["Nombre"]?.ToString() ?? "";
                            string ape = reader["Apellido"]?.ToString() ?? "";
                            string user = reader["Usuario"]?.ToString() ?? "";
                            string rol = reader["Rol"]?.ToString() ?? "";

                            string nombreMostrar = $"{nom} {ape}".Trim();
                            if (string.IsNullOrEmpty(nombreMostrar)) nombreMostrar = user;

                            cbDoctor.Items.Add(new DoctorItem
                            {
                                Usuario = user,
                                NombreCompleto = nombreMostrar,
                                Rol = rol
                            });
                        }
                    }
                }

                if (cbDoctor.Items.Count > 0)
                {
                    string usuarioActual = sistema.Infrastructure.Security.Sesion.UsuarioActual;
                    int indexActual = -1;

                    for (int i = 0; i < cbDoctor.Items.Count; i++)
                    {
                        if (cbDoctor.Items[i] is DoctorItem item &&
                            string.Equals(item.Usuario, usuarioActual, StringComparison.OrdinalIgnoreCase))
                        {
                            indexActual = i;
                            break;
                        }
                    }

                    cbDoctor.SelectedIndex = indexActual >= 0 ? indexActual : 0;
                }
            }
            catch
            {
                // Manejo de contingencia si no se pueden cargar usuarios
                cbDoctor.Items.Add(new DoctorItem { Usuario = "admin", NombreCompleto = "Médico General", Rol = "Administrador" });
                cbDoctor.SelectedIndex = 0;
            }
        }

        private class DoctorItem
        {
            public string Usuario { get; set; }
            public string NombreCompleto { get; set; }
            public string Rol { get; set; }
            public override string ToString() => $"{NombreCompleto} ({Rol})";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

            // VALIDACIONES
            if (_paciente == null)
            {
                MessageBox.Show("Error: No se ha seleccionado un paciente válido.");
                return;
            }

            if (_paciente.PacienteID <= 0)
            {
                MessageBox.Show("Error: El ID del paciente no es válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivoCita.Text))
            {
                MessageBox.Show("Por favor, ingrese el motivo de la cita.");
                txtMotivoCita.Focus();
                return;
            }

            DateTime fecha = FechaSeleccionada.Date;
            string motivo = txtMotivoCita.Text.Trim();
            int pacienteID = _paciente.PacienteID;
            int hora = dtpHora.Value.Hour;
            int minuto = dtpHora.Value.Minute;

            // Determina el periodo
            string periodo = radioAM.Checked ? "AM" : "PM";

            // Ajusta la hora si es PM
            if (radioPM.Checked && hora < 12)
                hora += 12;
            if (radioAM.Checked && hora == 12)
                hora = 0;

            TimeSpan horaCita = new TimeSpan(hora, minuto, 0);

            // Obtiene el médico asignado seleccionado
            string doctorAsignado = null;
            if (cbDoctor.SelectedItem is DoctorItem docItem)
            {
                doctorAsignado = docItem.NombreCompleto;
            }
            else if (!string.IsNullOrWhiteSpace(cbDoctor.Text))
            {
                doctorAsignado = cbDoctor.Text.Trim();
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // VERIFICAR que el paciente existe
                    string verificarQuery = "SELECT COUNT(1) FROM Paciente WHERE PacienteID = @PacienteID";
                    SqlCommand verificarCmd = new SqlCommand(verificarQuery, conexion);
                    verificarCmd.Parameters.AddWithValue("@PacienteID", pacienteID);

                    int existe = (int)verificarCmd.ExecuteScalar();

                    if (existe == 0)
                    {
                        MessageBox.Show($"Error: El paciente con ID {pacienteID} no existe en la base de datos.");
                        return;
                    }

                    // INSERTAR la cita con el médico seleccionado
                    string insertQuery = @"INSERT INTO Cita (PacienteID, FechaCita, HoraCita, Motivo, Periodo, DoctorAsignado) 
                                         VALUES (@PacienteID, @FechaCita, @HoraCita, @Motivo, @Periodo, @DoctorAsignado)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conexion);
                    cmd.Parameters.AddWithValue("@PacienteID", pacienteID);
                    cmd.Parameters.AddWithValue("@FechaCita", fecha);
                    cmd.Parameters.AddWithValue("@HoraCita", horaCita);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@Periodo", periodo);
                    cmd.Parameters.AddWithValue("@DoctorAsignado", string.IsNullOrWhiteSpace(doctorAsignado) ? (object)DBNull.Value : doctorAsignado);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cita guardada correctamente.");
                        this.Close();
                    }
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show($"Error: El paciente con ID {pacienteID} no existe en la base de datos.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            metroButton1_Click(sender, e);
        }
    }
}