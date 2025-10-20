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

namespace sistema
{
    public partial class UserControlDias : UserControl
    {
        public DateTime Fecha { get; set; }
        public UserControlDias()
        {
            InitializeComponent();
            this.Click += UserControlDias_Click; // El fondo del panel
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += UserControlDias_Click; // Todos los controles internos
            }
        }

        private void UserControlDias_Load(object sender, EventArgs e)
        {

        }

        public void dias(int numDias)
        {
            lblDias.Text = numDias + ""; 
        }

        public void MostrarPacientesRegistrados(DateTime fechaSeleccionada)
        {
            var pacientes = new List<PacientePreview>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Solo Paciente
                using (var cmdPaciente = new SqlCommand(
                    @"SELECT PacienteID, Nombre, Apellido, Genero, FechaNacimiento, GrupoSanguineo, Telefono, Detalles
                      FROM Paciente;", conexion))
                using (var reader = cmdPaciente.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int pacienteId = reader["PacienteID"] != DBNull.Value ? Convert.ToInt32(reader["PacienteID"]) : 0;
                        string nombre = reader["Nombre"]?.ToString() ?? "";
                        string apellido = reader["Apellido"]?.ToString() ?? "";
                        DateTime fechaNac = reader["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimiento"]) : DateTime.MinValue;

                        int edad = 0;
                        if (fechaNac != DateTime.MinValue)
                        {
                            edad = DateTime.Today.Year - fechaNac.Year;
                            if (fechaNac > DateTime.Today.AddYears(-edad)) edad--;
                        }

                        var preview = new PacientePreview
                        {
                            PacienteID = pacienteId,
                            Tipo = "Expediente",
                            Nombre = (nombre + " " + apellido).Trim(),
                            Genero = reader["Genero"]?.ToString() ?? "",
                            GrupoSanguineo = reader["GrupoSanguineo"]?.ToString() ?? "",
                            Edad = edad > 0 ? edad.ToString() : ""
                            // Si PacientePreview tiene Detalles, asígnalo aquí:
                            // Detalles = reader["Detalles"]?.ToString() ?? ""
                        };
                        pacientes.Add(preview);
                    }
                }
                conexion.Close();
            }

            // Abrir ventana de agregar citas y poblarla
            AgregarCitas agregarCitas = new AgregarCitas(fechaSeleccionada);
            foreach (var paciente in pacientes)
            {
                agregarCitas.AgregarPacientePreview(paciente);
            }
            agregarCitas.ShowDialog();
        }

        private void UserControlDias_Click(object sender, EventArgs e)
        {
            MostrarPacientesRegistrados(this.Fecha);
        }

    }
}
