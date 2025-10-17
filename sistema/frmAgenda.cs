using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmAgenda : Form
    {
        private DateTimePicker dtpFecha;
        private FlowLayoutPanel flowPanelContenedor;
        private FlowLayoutPanel flowPanelCitas;

        public frmAgenda()
        {
            InitializeComponent();

            // FlowLayoutPanel contenedor para organizar los controles
            flowPanelContenedor = new FlowLayoutPanel();
            flowPanelContenedor.Location = new Point(40, 40);
            flowPanelContenedor.Size = new Size(1000, 700);
            flowPanelContenedor.FlowDirection = FlowDirection.TopDown;
            flowPanelContenedor.WrapContents = false;
            flowPanelContenedor.AutoScroll = true;
            this.Controls.Add(flowPanelContenedor);

            // DateTimePicker expandido
            dtpFecha = new DateTimePicker();
            dtpFecha.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            dtpFecha.Size = new Size(600, 60);
            dtpFecha.Location = new Point(0, 0);
            dtpFecha.ValueChanged += DtpFecha_ValueChanged;
            flowPanelContenedor.Controls.Add(dtpFecha);

            // FlowLayoutPanel para los paneles de citas
            flowPanelCitas = new FlowLayoutPanel();
            flowPanelCitas.Size = new Size(950, 600);
            flowPanelCitas.Location = new Point(0, 80);
            flowPanelCitas.FlowDirection = FlowDirection.TopDown;
            flowPanelCitas.WrapContents = false;
            flowPanelCitas.AutoScroll = true;
            flowPanelContenedor.Controls.Add(flowPanelCitas);

            // Carga las citas del día actual al iniciar
            CargarCitasPorFecha(dtpFecha.Value.Date);

            // Abre el calendario automáticamente al cargar
            this.Shown += (s, e) => dtpFecha.Focus();
            this.Shown += (s, e) => SendKeys.Send("%{DOWN}");
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarCitasPorFecha(dtpFecha.Value.Date);
        }

        private void CargarCitasPorFecha(DateTime fecha)
        {
            flowPanelCitas.Controls.Clear();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo,
                           p.Nombre, p.Apellido, p.Telefono
                    FROM Cita c
                    INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
                    WHERE c.FechaCita = @FechaCita";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaCita", fecha);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Panel panelCita = new Panel();
                        panelCita.Size = new Size(900, 120);
                        panelCita.BorderStyle = BorderStyle.FixedSingle;
                        panelCita.BackColor = Color.FromArgb(40, 40, 40);

                        string datos = $"Paciente: {reader["Nombre"]} {reader["Apellido"]} | Teléfono: {reader["Telefono"]} | " +
                                       $"Hora: {reader["HoraCita"]} {reader["Periodo"]} | Motivo: {reader["Motivo"]}";
                        Label lblDatos = new Label();
                        lblDatos.Text = datos;
                        lblDatos.Font = new Font("Segoe UI", 18, FontStyle.Regular);
                        lblDatos.ForeColor = Color.White;
                        lblDatos.AutoSize = false;
                        lblDatos.Size = new Size(880, 100);
                        lblDatos.Location = new Point(10, 10);

                        panelCita.Controls.Add(lblDatos);
                        flowPanelCitas.Controls.Add(panelCita);
                    }
                }
            }
        }
    }
}
