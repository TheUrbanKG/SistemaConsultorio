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
            ConfigurarInteraccionesTarjetas();
            ActualizarContadoresPacientes();
            ActualizarContadorCitasHoy();
        }

        private void ConfigurarInteraccionesTarjetas()
        {
            // Permitir navegación rápida haciendo clic en las tarjetas de estadísticas (KPI)
            Action<Control, EventHandler> agregarClick = (ctrl, handler) =>
            {
                ctrl.Cursor = Cursors.Hand;
                ctrl.Click += handler;
            };

            // Tarjeta de Citas
            EventHandler irACitas = (s, e) => btnBuscarCita_Click(s, e);
            agregarClick(sataPanel1, irACitas);
            agregarClick(label5, irACitas);
            agregarClick(lbCitasAgendadas, irACitas);
            agregarClick(label1, irACitas);
            agregarClick(panel2, irACitas);
            agregarClick(pictureBox2, irACitas);

            // Tarjeta de Pacientes Totales
            EventHandler irAPacientes = (s, e) => btnBuscarPaciente_Click(s, e);
            agregarClick(sataPanel2, irAPacientes);
            agregarClick(label4, irAPacientes);
            agregarClick(lbPacientesRegistrados, irAPacientes);
            agregarClick(label3, irAPacientes);
            agregarClick(panel3, irAPacientes);
            agregarClick(pictureBox1, irAPacientes);

            // Tarjeta Pacientes Masculinos
            agregarClick(sataPanel3, irAPacientes);
            agregarClick(label7, irAPacientes);
            agregarClick(lbPacientesMasculinos, irAPacientes);
            agregarClick(label9, irAPacientes);
            agregarClick(panel4, irAPacientes);
            agregarClick(pictureBox3, irAPacientes);

            // Tarjeta Pacientes Femeninos
            agregarClick(sataPanel4, irAPacientes);
            agregarClick(label6, irAPacientes);
            agregarClick(lbPacientesFemeninos, irAPacientes);
            agregarClick(label12, irAPacientes);
            agregarClick(panel5, irAPacientes);
            agregarClick(pictureBox4, irAPacientes);
        }

        private void ActualizarContadoresPacientes()
        {
            try
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
            catch (Exception)
            {
                lbPacientesRegistrados.Text = "0";
                lbPacientesMasculinos.Text = "0";
                lbPacientesFemeninos.Text = "0";
            }
        }

        private void ActualizarContadorCitasHoy()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT COUNT(*) 
                    FROM Cita
                    WHERE FechaCita = CAST(GETDATE() AS DATE);";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        object scalar = cmd.ExecuteScalar();
                        int totalCitasHoy = (scalar != null && scalar != DBNull.Value) ? Convert.ToInt32(scalar) : 0;
                        lbCitasAgendadas.Text = totalCitasHoy.ToString();
                    }
                }
            }
            catch (Exception)
            {
                lbCitasAgendadas.Text = "0";
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmPacientes());
            _mainForm.labelTitulo.Text = "Pacientes";
            _mainForm.labelSubtitulo.Text = "Directorio y expedientes clínicos de pacientes";
            _mainForm.pbTitulo.Image = Properties.Resources.paciente;
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmCitas());
            _mainForm.labelTitulo.Text = "Citas";
            _mainForm.labelSubtitulo.Text = "Gestión y programación de citas médicas";
            _mainForm.pbTitulo.Image = Properties.Resources.calendario;
        }

        private void btnBuscarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmAgenda());
            _mainForm.labelTitulo.Text = "Agenda";
            _mainForm.labelSubtitulo.Text = "Calendario semanal y citas programadas";
            _mainForm.pbTitulo.Image = Properties.Resources.agenda;
        }
    }
}
