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
        public AgregarCitas()
        {
            InitializeComponent();
        }

        public AgregarCitas(PacientePreview pacientePreview)
        {
            InitializeComponent();
            paciente = pacientePreview;
            AgregarPacientePreview(pacientePreview);    
        }

        public AgregarCitas(DateTime fechaSeleccionada)
        {
            InitializeComponent();
            FechaSeleccionada = fechaSeleccionada;
            lblFecha.Text = fechaSeleccionada.ToString("dd/MM/yyyy"); // Así sí se muestra en lblFecha
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            lblFechaActual.ForeColor = Color.DarkSlateGray;

            List<PacientePreview> pacientes = new List<PacientePreview>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Genero, GrupoSanguineo, Edad FROM PacienteConocido";
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
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
            }

            var preview = new PacientePreview
            {
                Tipo = "Conocido",
                Nombre = "Prueba",
                Genero = "Masculino",
                GrupoSanguineo = "A+",
                Edad = "30"
            };
            AgregarPacientePreview(preview);

            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        public void AgregarPacientePreview(PacientePreview paciente)
        {
            Panel panel = new Panel
            {
                Width = 364,
                Height = 90,
                Margin = new Padding(10),
                Tag = paciente,
                BackColor = Color.FromArgb(44, 62, 80) // Azul claro moderno
            };

            Font labelFont = new Font("Segoe UI", 12, FontStyle.Bold);

            Label lblTipo = new Label { Text = "Tipo: " + paciente.Tipo, Location = new Point(10, 10), AutoSize = true, ForeColor = Color.White, Font = labelFont };
            Label lblNombre = new Label { Text = "Nombre: " + paciente.Nombre, Location = new Point(10, 35), AutoSize = true, ForeColor = Color.White, Font = labelFont };
            Label lblGenero = new Label { Text = "Género: " + paciente.Genero, Location = new Point(170, 10), AutoSize = true, ForeColor = Color.White, Font = labelFont };
            Label lblGrupoSanguineo = new Label { Text = "Sangre: " + paciente.GrupoSanguineo, Location = new Point(170, 35), AutoSize = true, ForeColor = Color.White, Font = labelFont };
            Label lblEdad = new Label { Text = "Edad: " + paciente.Edad, Location = new Point(10, 60), AutoSize = true, ForeColor = Color.White, Font = labelFont };

            panel.Controls.Add(lblTipo);
            panel.Controls.Add(lblNombre);
            panel.Controls.Add(lblGenero);
            panel.Controls.Add(lblGrupoSanguineo);
            panel.Controls.Add(lblEdad);

            panel.Click += PanelPaciente_Click;
            flpPacientes.Controls.Add(panel);
            flpPacientes.Controls.Add(panel);
        }

        private void PanelPaciente_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && panel.Tag is PacientePreview paciente)
            {
                AgendarCita agendarCita = new AgendarCita();
                agendarCita.FechaSeleccionada = FechaSeleccionada;
                agendarCita.SetPaciente(paciente);
                this.Close();
                agendarCita.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PacienteCita pacienteCita = new PacienteCita();
            pacienteCita.ShowDialog();
            this.Close();
        }

        private void flpPacientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            PacienteCita pacienteCita = new PacienteCita();
            if (pacienteCita.ShowDialog() == DialogResult.OK)
            {
                // Recibe el objeto PacientePreview desde PacienteCita
                AgregarPacientePreview(pacienteCita.PreviewPaciente);
            }
        }
    }
}
