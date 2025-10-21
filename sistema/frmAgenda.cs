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
        private ComboBox cmbFiltro;
        private Button btnAplicarFiltro;
        private Label lblTitulo;

        public frmAgenda()
        {
            InitializeComponent();

            // Ajustes para embebido
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            
            InitializeModernUI();
            this.Shown += (s, e) => AplicarFiltro();
        }

        private void InitializeModernUI()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Contenedor principal
            flowPanelContenedor = new FlowLayoutPanel();
            flowPanelContenedor.Dock = DockStyle.Fill;
            flowPanelContenedor.FlowDirection = FlowDirection.TopDown;
            flowPanelContenedor.WrapContents = false;
            flowPanelContenedor.AutoScroll = true;
            flowPanelContenedor.BackColor = Color.FromArgb(37, 37, 38);
            flowPanelContenedor.Padding = new Padding(20);
            this.Controls.Add(flowPanelContenedor);

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "AGENDA DE CITAS";
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Margin = new Padding(0, 0, 0, 20);
            flowPanelContenedor.Controls.Add(lblTitulo);

            // Panel de filtros
            Panel panelFiltros = new Panel();
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Height = 80;
            panelFiltros.BackColor = Color.FromArgb(55, 55, 58);
            panelFiltros.Padding = new Padding(15);
            panelFiltros.Margin = new Padding(0, 0, 0, 20);
            flowPanelContenedor.Controls.Add(panelFiltros);

            // Filtro por tipo
            Label lblFiltro = new Label();
            lblFiltro.Text = "Filtrar por:";
            lblFiltro.Font = new Font("Segoe UI", 10);
            lblFiltro.ForeColor = Color.LightGray;
            lblFiltro.Location = new Point(15, 10);
            lblFiltro.AutoSize = true;
            panelFiltros.Controls.Add(lblFiltro);

            cmbFiltro = new ComboBox();
            cmbFiltro.Font = new Font("Segoe UI", 10);
            cmbFiltro.Size = new Size(120, 25);
            cmbFiltro.Location = new Point(90, 10);
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.BackColor = Color.FromArgb(63, 63, 70);
            cmbFiltro.ForeColor = Color.White;
            cmbFiltro.FlatStyle = FlatStyle.Flat;
            cmbFiltro.Items.AddRange(new string[] { "Día específico", "Mes actual" });
            cmbFiltro.SelectedIndex = 0;
            panelFiltros.Controls.Add(cmbFiltro);

            // Fecha
            Label lblFecha = new Label();
            lblFecha.Text = "Fecha:";
            lblFecha.Font = new Font("Segoe UI", 10);
            lblFecha.ForeColor = Color.LightGray;
            lblFecha.Location = new Point(230, 10);
            lblFecha.AutoSize = true;
            panelFiltros.Controls.Add(lblFecha);

            dtpFecha = new DateTimePicker();
            dtpFecha.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtpFecha.Size = new Size(300, 35);
            dtpFecha.Location = new Point(280, 10);
            dtpFecha.ValueChanged += DtpFecha_ValueChanged;
            dtpFecha.BackColor = Color.FromArgb(63, 63, 70);
            dtpFecha.ForeColor = Color.White;
            panelFiltros.Controls.Add(dtpFecha);

            // Botón aplicar
            btnAplicarFiltro = new Button();
            btnAplicarFiltro.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAplicarFiltro.Size = new Size(100, 30);
            btnAplicarFiltro.Location = new Point(600, 10);
            btnAplicarFiltro.Text = "Aplicar Filtro";
            btnAplicarFiltro.BackColor = Color.FromArgb(0, 122, 204);
            btnAplicarFiltro.ForeColor = Color.White;
            btnAplicarFiltro.FlatStyle = FlatStyle.Flat;
            btnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            panelFiltros.Controls.Add(btnAplicarFiltro);

            // Panel de citas
            flowPanelCitas = new FlowLayoutPanel();
            flowPanelCitas.Dock = DockStyle.Top;
            flowPanelCitas.AutoSize = true;
            flowPanelCitas.FlowDirection = FlowDirection.TopDown;
            flowPanelCitas.WrapContents = false;
            flowPanelCitas.AutoScroll = true;
            flowPanelCitas.BackColor = Color.FromArgb(37, 37, 38);
            flowPanelCitas.Padding = new Padding(10);
            flowPanelContenedor.Controls.Add(flowPanelCitas);

            // Cargar citas iniciales
            CargarCitasPorFecha(dtpFecha.Value.Date);

            // Abrir calendario al mostrar
            this.Shown += (s, e) => dtpFecha.Focus();
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e) => AplicarFiltro();

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
                CargarCitasPorFecha(dtpFecha.Value.Date);
        }

        private void AplicarFiltro()
        {
            if (cmbFiltro.SelectedIndex == 0)
                CargarCitasPorFecha(dtpFecha.Value.Date);
            else
                CargarCitasDelMesActual();
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
                    WHERE c.FechaCita = @FechaCita
                    ORDER BY c.HoraCita";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaCita", fecha);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        CrearPanelCita(reader);
                }
            }
            ActualizarTitulo($"Citas del día: {fecha:dd/MM/yyyy}");

            if (flowPanelCitas.Controls.Count == 0)
            {
                Panel placeholder = new Panel();
                placeholder.Size = new Size(flowPanelContenedor.ClientSize.Width - 60, 100);
                placeholder.BackColor = Color.FromArgb(45, 45, 48);

                Label lblVacio = new Label();
                lblVacio.Text = "No hay citas para esta fecha.";
                lblVacio.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblVacio.ForeColor = Color.Gray;
                lblVacio.Dock = DockStyle.Fill;
                lblVacio.TextAlign = ContentAlignment.MiddleCenter;

                placeholder.Controls.Add(lblVacio);
                flowPanelCitas.Controls.Add(placeholder);
                flowPanelCitas.PerformLayout();
                flowPanelContenedor.PerformLayout();
            }
        }

        private void CargarCitasDelMesActual()
        {
            flowPanelCitas.Controls.Clear();
            DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo,
                           p.Nombre, p.Apellido, p.Telefono
                    FROM Cita c
                    INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
                    WHERE c.FechaCita BETWEEN @FechaInicio AND @FechaFin
                    ORDER BY c.FechaCita, c.HoraCita";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", primerDiaMes);
                cmd.Parameters.AddWithValue("@FechaFin", ultimoDiaMes);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        CrearPanelCita(reader);
                }
            }
            ActualizarTitulo($"Citas del mes: {DateTime.Now:MMMM yyyy}");

            if (flowPanelCitas.Controls.Count == 0)
            {
                Panel placeholder = new Panel();
                placeholder.Dock = DockStyle.Top;
                placeholder.AutoSize = true;
                placeholder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                placeholder.BackColor = Color.FromArgb(45, 45, 48);

                Label lblVacio = new Label();
                lblVacio.Text = "No hay citas para esta fecha.";
                lblVacio.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblVacio.ForeColor = Color.Gray;
                lblVacio.Dock = DockStyle.Fill;
                lblVacio.TextAlign = ContentAlignment.MiddleCenter;

                placeholder.Controls.Add(lblVacio);
                flowPanelCitas.Controls.Add(placeholder);
                flowPanelCitas.PerformLayout();
                flowPanelContenedor.PerformLayout();
            }
        }

        private void CrearPanelCita(SqlDataReader reader)
        {
            Panel panelCita = new Panel();
            panelCita.Size = new Size(flowPanelContenedor.ClientSize.Width - 60, 120);
            panelCita.BackColor = Color.FromArgb(55, 55, 58);
            panelCita.Margin = new Padding(0, 0, 0, 10);
            panelCita.Padding = new Padding(10);

            // Borde sutil
            panelCita.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(80, 80, 80), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panelCita.Width - 1, panelCita.Height - 1);
                }
            };

            DateTime fechaCita = Convert.ToDateTime(reader["FechaCita"]);
            TimeSpan horaCita = (TimeSpan)reader["HoraCita"];
            string periodo = reader["Periodo"].ToString();

            // Panel izquierdo: fecha y hora
            Panel panelInfo = new Panel();
            panelInfo.Size = new Size(100, 100);
            panelInfo.Location = new Point(10, 10);
            panelInfo.BackColor = Color.FromArgb(0, 122, 204);

            Label lblFecha = new Label();
            lblFecha.Text = fechaCita.ToString("dd\nMMM").ToUpper();
            lblFecha.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFecha.Size = new Size(80, 40);
            lblFecha.Location = new Point(10, 15);
            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
            lblFecha.ForeColor = Color.White;
            panelInfo.Controls.Add(lblFecha);

            Label lblHora = new Label();
            lblHora.Text = $"{horaCita:hh\\:mm}\n{periodo}";
            lblHora.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblHora.Size = new Size(80, 30);
            lblHora.Location = new Point(10, 55);
            lblHora.TextAlign = ContentAlignment.MiddleCenter;
            lblHora.ForeColor = Color.White;
            panelInfo.Controls.Add(lblHora);

            panelCita.Controls.Add(panelInfo);

            // Información del paciente
            Label lblPaciente = new Label();
            lblPaciente.Text = $"{reader["Nombre"]} {reader["Apellido"]}";
            lblPaciente.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPaciente.Size = new Size(350, 25);
            lblPaciente.Location = new Point(120, 15);
            lblPaciente.ForeColor = Color.White;
            panelCita.Controls.Add(lblPaciente);

            // Teléfono
            Label lblTelefono = new Label();
            lblTelefono.Text = $"📞 {reader["Telefono"]}";
            lblTelefono.Font = new Font("Segoe UI", 10);
            lblTelefono.Size = new Size(250, 20);
            lblTelefono.Location = new Point(120, 45);
            lblTelefono.ForeColor = Color.LightGray;
            panelCita.Controls.Add(lblTelefono);

            // Motivo
            Label lblMotivo = new Label();
            lblMotivo.Text = $"📋 {reader["Motivo"]}";
            lblMotivo.Font = new Font("Segoe UI", 10);
            lblMotivo.Size = new Size(500, 20);
            lblMotivo.Location = new Point(120, 70);
            lblMotivo.ForeColor = Color.LightGray;
            panelCita.Controls.Add(lblMotivo);

            // Año
            Label lblAnio = new Label();
            lblAnio.Text = fechaCita.ToString("yyyy");
            lblAnio.Font = new Font("Segoe UI", 9);
            lblAnio.Size = new Size(80, 20);
            lblAnio.Location = new Point(panelCita.Width - 90, 15);
            lblAnio.ForeColor = Color.LightGray;
            lblAnio.TextAlign = ContentAlignment.MiddleRight;
            panelCita.Controls.Add(lblAnio);

            flowPanelCitas.Controls.Add(panelCita);
        }

        private void ActualizarTitulo(string subtitulo)
        {
            lblTitulo.Text = $"AGENDA DE CITAS - {subtitulo.ToUpper()}";
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            AplicarFiltro();
        }
    }
}
