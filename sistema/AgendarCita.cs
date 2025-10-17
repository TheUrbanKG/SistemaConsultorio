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
        private PacientePreview paciente;

        public AgendarCita()
        {
            InitializeComponent();
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true; // Esto activa el selector tipo spin SOLO para hora
            dtpHora.Value = DateTime.Today.AddHours(8); // Opcional: valor inicial
        }

        public void SetPaciente(PacientePreview paciente)
        {
            this.paciente = paciente;
            lblNombrePaciente.Text = paciente.Nombre;
            lblEdadPaciente.Text = paciente.Edad;
            lblGeneroPaciente.Text = paciente.Genero;
            lblTipoSangre.Text = paciente.GrupoSanguineo;
            // ... muestra los datos en los labels correspondientes
        }
        public void SetFechaCita(DateTime fecha)
        {
            lblFechaCita.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void AgendarCita_Load(object sender, EventArgs e)
        {
            lblFechaCita.Text = FechaSeleccionada.ToString("dd/MM/yyyy");
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            DateTime fecha = FechaSeleccionada.Date;
            string motivo = txtMotivoCita.Text;
            int pacienteID = this.paciente.PacienteID;
            int hora = dtpHora.Value.Hour;
            int minuto = dtpHora.Value.Minute;

            // Determina el periodo
            string periodo = radioAM.Checked ? "AM" : "PM";

            // Ajusta la hora si es PM
            if (radioPM.Checked && hora < 12)
                hora += 12;
            if (radioAM.Checked && hora == 12)
                hora = 0;

            // Construye el TimeSpan para la hora
            TimeSpan horaCita = new TimeSpan(hora, minuto, 0);

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Cita (PacienteID, FechaCita, HoraCita, Motivo, Periodo) VALUES (@PacienteID, @FechaCita, @HoraCita, @Motivo, @Periodo)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@PacienteID", pacienteID);
                cmd.Parameters.AddWithValue("@FechaCita", fecha);
                cmd.Parameters.AddWithValue("@HoraCita", horaCita);
                cmd.Parameters.AddWithValue("@Motivo", motivo);
                cmd.Parameters.AddWithValue("@Periodo", periodo);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Cita guardada correctamente.");
            this.Close();
        }
    }
}
