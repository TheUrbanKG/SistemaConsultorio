using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmInicio : Form
    {
        private frmMain _mainForm;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmInicio(frmMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            ActualizarContadoresPacientes();
            ActualizarContadorCitasHoy();
        }

        private void ActualizarContadoresPacientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                COUNT(*) AS Total,
                COALESCE(SUM(CASE WHEN Genero = 'Masculino' THEN 1 ELSE 0 END), 0) AS Masculinos,
                COALESCE(SUM(CASE WHEN Genero = 'Femenino'  THEN 1 ELSE 0 END), 0) AS Femeninos
                FROM Paciente;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbPacientesRegistrados.Text = reader["Total"].ToString();
                            lbPacientesMasculinos.Text = reader["Masculinos"].ToString();
                            lbPacientesFemeninos.Text = reader["Femeninos"].ToString();
                        }
                    }
                }
            }
        }

        private void ActualizarContadorCitasHoy()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Cita
            WHERE FechaCita = CAST(GETDATE() AS DATE);"; // compara solo la fecha actual

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int totalCitasHoy = (int)cmd.ExecuteScalar();
                    lbCitasAgendadas.Text = totalCitasHoy.ToString();
                }
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmPacientes());
            _mainForm.labelTitulo.Text = "Pacientes";
            _mainForm.pbTitulo.Image = Properties.Resources.paciente;
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmCitas());
            _mainForm.labelTitulo.Text = "Citas";
            _mainForm.pbTitulo.Image = Properties.Resources.calendario;
        }

        private void btnBuscarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmAgenda());
            _mainForm.labelTitulo.Text = "Agenda";
            _mainForm.pbTitulo.Image = Properties.Resources.agenda;
        }
    }
}
