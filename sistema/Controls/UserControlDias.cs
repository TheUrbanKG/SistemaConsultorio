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
            List<PacientePreview> pacientes = new List<PacientePreview>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                // Pacientes de la tabla Paciente
                string queryPaciente = "SELECT PacienteID, Nombre, Genero, FechaNacimiento FROM Paciente";
                SqlCommand cmdPaciente = new SqlCommand(queryPaciente, conexion);
                conexion.Open();
                using (SqlDataReader reader = cmdPaciente.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime fechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                        int edad = DateTime.Today.Year - fechaNacimiento.Year;
                        if (fechaNacimiento > DateTime.Today.AddYears(-edad)) edad--;

                        var preview = new PacientePreview
                        {
                            PacienteID = Convert.ToInt32(reader["PacienteID"]), // <--- Asignar correctamente
                            Tipo = "Expediente",
                            Nombre = reader["Nombre"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            GrupoSanguineo = "", // Si tienes este dato en la tabla, agrégalo aquí
                            Edad = edad.ToString()
                        };
                        pacientes.Add(preview);
                    }
                }
                conexion.Close();

                // Pacientes conocidos
                conexion.Open();
                string queryConocido = "SELECT Nombre, Genero, GrupoSanguineo, Edad FROM PacienteConocido";
                SqlCommand cmdConocido = new SqlCommand(queryConocido, conexion);
                using (SqlDataReader reader = cmdConocido.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var preview = new PacientePreview
                        {
                            Tipo = "Conocido",
                            Nombre = reader["Nombre"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            GrupoSanguineo = reader["GrupoSanguineo"].ToString(),
                            Edad = reader["Edad"].ToString()
                        };
                        pacientes.Add(preview);
                    }
                }
                conexion.Close();

                // Pacientes desconocidos
                conexion.Open();
                string queryDesconocido = "SELECT Nombre, Genero, GrupoSanguineo, Edad FROM PacienteDesconocido";
                SqlCommand cmdDesconocido = new SqlCommand(queryDesconocido, conexion);
                using (SqlDataReader reader = cmdDesconocido.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var preview = new PacientePreview
                        {
                            Tipo = "Desconocido",
                            Nombre = reader["Nombre"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            GrupoSanguineo = reader["GrupoSanguineo"].ToString(),
                            Edad = reader["Edad"].ToString()
                        };
                        pacientes.Add(preview);
                    }
                }
                conexion.Close();
            }

            // Crea el formulario pasando la fecha seleccionada
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
