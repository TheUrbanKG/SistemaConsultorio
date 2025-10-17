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
        }

        private void ActualizarContadoresPacientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
SELECT 
    COUNT(*) AS Total,
    SUM(CASE WHEN Genero = 'Masculino' THEN 1 ELSE 0 END) AS Masculinos,
    SUM(CASE WHEN Genero = 'Femenino'  THEN 1 ELSE 0 END) AS Femeninos
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

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmPacientes());
            _mainForm.labelTitulo.Text = "Pacientes";
            _mainForm.pbTitulo.Image = Image.FromFile(@"C:\Users\Urban\Desktop\Sistema Consultorio\Icons\paciente.png");
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmCitas());
            _mainForm.labelTitulo.Text = "Citas";
            _mainForm.pbTitulo.Image = Image.FromFile(@"C:\Users\Urban\Desktop\Sistema Consultorio\Icons\calendario.png");
        }

        private void btnBuscarCita_Click(object sender, EventArgs e)
        {
            _mainForm.abrirFormHijo(new frmAgenda());
            _mainForm.labelTitulo.Text = "Agenda";
            _mainForm.pbTitulo.Image = Image.FromFile(@"C:\Users\Urban\Desktop\Sistema Consultorio\Icons\agenda.png");
        }
    }
}
