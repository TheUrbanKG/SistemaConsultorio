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
    public partial class AgregarCitas : MetroFramework.Forms.MetroForm
    {
        public DateTime FechaSeleccionada { get; set; }
        private PacientePreview paciente;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        private bool formLoaded = false;

        public AgregarCitas(DateTime fechaSeleccionada)
        {
            InitializeComponent();
            FechaSeleccionada = fechaSeleccionada;
            lblFecha.Text = fechaSeleccionada.ToString("dd/MM/yyyy");
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            // Prevenir ejecución múltiple
            if (formLoaded) return;
            formLoaded = true;

            lblFechaActual.ForeColor = Color.DarkSlateGray;

            // Cargar pacientes desde la base de datos
            CargarPacientesDesdeBD();

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void CargarPacientesDesdeBD()
        {
            List<PacientePreview> pacientes = new List<PacientePreview>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        PacienteID,
                        Nombre, 
                        Apellido,
                        Genero, 
                        GrupoSanguineo,
                        TipoPaciente,
                        FechaNacimiento,
                        DATEDIFF(YEAR, FechaNacimiento, GETDATE()) - 
                        CASE 
                            WHEN DATEADD(YEAR, DATEDIFF(YEAR, FechaNacimiento, GETDATE()), FechaNacimiento) > GETDATE() 
                            THEN 1 
                            ELSE 0 
                        END AS Edad
                    FROM Paciente";

                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipoPaciente = reader["TipoPaciente"].ToString();
                        string nombreCompleto;

                        // Si es Desconocido, mostrar solo el nombre
                        if (tipoPaciente == "Desconocido")
                        {
                            nombreCompleto = reader["Nombre"].ToString();
                        }
                        else
                        {
                            // Si es Conocido, mostrar nombre + apellido
                            nombreCompleto = reader["Nombre"].ToString() + " " + reader["Apellido"].ToString();
                        }

                        var preview = new PacientePreview
                        {
                            PacienteID = Convert.ToInt32(reader["PacienteID"]),
                            Tipo = tipoPaciente,
                            Nombre = nombreCompleto.Trim(),
                            Genero = reader["Genero"].ToString(),
                            GrupoSanguineo = reader["GrupoSanguineo"]?.ToString() ?? "No especificado",
                            Edad = reader["Edad"].ToString()
                        };
                        pacientes.Add(preview);
                    }
                }
            }

            // Limpiar y agregar pacientes
            flpPacientes.Controls.Clear();
            foreach (var p in pacientes)
                AgregarPacientePreview(p);
        }

        public void AgregarPacientePreview(PacientePreview paciente)
        {
            Color colorFondo = Color.FromArgb(44, 62, 80); // Azul oscuro por defecto (Conocido)

            // Cambiar color según el tipo de paciente
            if (paciente.Tipo == "Desconocido")
            {
                colorFondo = Color.FromArgb(0, 128, 128); // Rojo oscuro para desconocidos
            }

            Panel panel = new Panel
            {
                Width = 364,
                Height = 90,
                Margin = new Padding(10),
                Tag = paciente,
                BackColor = colorFondo,
                Cursor = Cursors.Hand
            };

            Font labelFont = new Font("Segoe UI", 12, FontStyle.Bold);

            Label lblTipo = new Label
            {
                Text = "Tipo: " + paciente.Tipo,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.White,
                Font = labelFont
            };

            Label lblNombre = new Label
            {
                Text = "Nombre: " + paciente.Nombre,
                Location = new Point(10, 35),
                AutoSize = true,
                ForeColor = Color.White,
                Font = labelFont
            };

            Label lblGenero = new Label
            {
                Text = "Género: " + paciente.Genero,
                Location = new Point(170, 10),
                AutoSize = true,
                ForeColor = Color.White,
                Font = labelFont
            };

            Label lblEdad = new Label
            {
                Text = "Edad: " + paciente.Edad,
                Location = new Point(10, 60),
                AutoSize = true,
                ForeColor = Color.White,
                Font = labelFont
            };

            panel.Controls.Add(lblTipo);
            panel.Controls.Add(lblNombre);
            panel.Controls.Add(lblGenero);
            panel.Controls.Add(lblEdad);

            panel.Click += PanelPaciente_Click;

            flpPacientes.Controls.Add(panel);
        }

        private void PanelPaciente_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && panel.Tag is PacientePreview pacienteSeleccionado)
            {
                // Verificar si ya existe una instancia abierta
                if (Application.OpenForms.OfType<AgendarCita>().Any())
                {
                    Application.OpenForms.OfType<AgendarCita>().First().BringToFront();
                    return;
                }

                AgendarCita agendarCita = new AgendarCita();
                agendarCita.FechaSeleccionada = FechaSeleccionada;
                agendarCita.SetPaciente(pacienteSeleccionado);
                this.Hide(); // Ocultar en lugar de cerrar
                agendarCita.ShowDialog();
                this.Show(); // Volver a mostrar cuando se cierre AgendarCita
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si ya existe una instancia abierta
            if (Application.OpenForms.OfType<PacienteCita>().Any())
            {
                Application.OpenForms.OfType<PacienteCita>().First().BringToFront();
                return;
            }

            PacienteCita pacienteCita = new PacienteCita();
            this.Hide(); // Ocultar en lugar de cerrar
            pacienteCita.ShowDialog();
            this.Show(); // Volver a mostrar cuando se cierre PacienteCita
        }

    }
}