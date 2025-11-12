using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();

            // Ajustes para embebido
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ConfigurarEventos();
            this.Shown += (s, e) => AplicarFiltro();
        }

        private void ConfigurarEventos()
        {
            cmbFiltro.SelectedIndexChanged += CmbFiltro_SelectedIndexChanged;
            btnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            dtpFecha.ValueChanged += DtpFecha_ValueChanged;
            this.Load += frmAgenda_Load;
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AplicarFiltro();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDiaEspecifico.Visible = cmbFiltro.SelectedIndex == 0;
            panelMesEspecifico.Visible = cmbFiltro.SelectedIndex == 2;
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e) => AplicarFiltro();

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
                CargarCitasPorFecha(dtpFecha.Value.Date);
        }

        private void AplicarFiltro()
        {
            switch (cmbFiltro.SelectedIndex)
            {
                case 0: // Día específico
                    CargarCitasPorFecha(dtpFecha.Value.Date);
                    break;
                case 1: // Mes actual
                    CargarCitasDelMesActual();
                    break;
                case 2: // Mes específico
                    CargarCitasDelMesEspecifico(dtpMesEspecifico.Value);
                    break;
            }
        }

        private void CargarCitasPorFecha(DateTime fecha)
        {
            flowPanelCitas.Controls.Clear();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT c.CitaID, c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo, c.Status,
                   p.Nombre, p.Apellido, p.Telefono
            FROM Cita c
            INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
            WHERE c.FechaCita = @FechaCita
              AND (p.Nombre + ' ' + p.Apellido) LIKE @FiltroNombre
            ORDER BY c.HoraCita";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaCita", fecha);
                string filtroNombre = string.IsNullOrWhiteSpace(txtBuscar.Text) ? "%" : $"%{txtBuscar.Text.Trim()}%";
                cmd.Parameters.AddWithValue("@FiltroNombre", filtroNombre);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        CrearPanelCita(reader);
                }
            }
            ActualizarTitulo($"Citas del día: {fecha:dd/MM/yyyy}");
            MostrarMensajeVacio();
        }

        private void CargarCitasDelMesActual()
        {
            LimpiarPanelCitas();
            DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            CargarCitasPorRango(primerDiaMes, ultimoDiaMes, $"Citas del mes: {DateTime.Now:MMMM yyyy}");
        }

        private void CargarCitasDelMesEspecifico(DateTime fecha)
        {
            LimpiarPanelCitas();
            DateTime primerDiaMes = new DateTime(fecha.Year, fecha.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            CargarCitasPorRango(primerDiaMes, ultimoDiaMes, $"Citas del mes: {fecha:MMMM yyyy}");
        }

        private void CargarCitasPorRango(DateTime fechaInicio, DateTime fechaFin, string titulo)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT c.CitaID, c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo, c.Status,
                   p.Nombre, p.Apellido, p.Telefono
            FROM Cita c
            INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
            WHERE c.FechaCita BETWEEN @FechaInicio AND @FechaFin
              AND (p.Nombre + ' ' + p.Apellido) LIKE @FiltroNombre
            ORDER BY c.FechaCita, c.HoraCita";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                string filtroNombre = string.IsNullOrWhiteSpace(txtBuscar.Text) ? "%" : $"%{txtBuscar.Text.Trim()}%";
                cmd.Parameters.AddWithValue("@FiltroNombre", filtroNombre);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        CrearPanelCita(reader);
                }
            }
            ActualizarTitulo(titulo);
            MostrarMensajeVacio();
            AjustarTamañoPaneles();
        }

        private void LimpiarPanelCitas()
        {
            flowPanelCitas.SuspendLayout();
            flowPanelCitas.Controls.Clear();
            flowPanelCitas.ResumeLayout();
        }

        private void CrearPanelCita(SqlDataReader reader)
        {
            Panel panelCita = new Panel();
            panelCita.Width = flowPanelCitas.ClientSize.Width - 25;
            panelCita.Height = 130;
            panelCita.BackColor = Color.FromArgb(55, 55, 58);
            panelCita.Margin = new Padding(0, 0, 0, 10);
            panelCita.Padding = new Padding(10);

            DateTime fechaCita = Convert.ToDateTime(reader["FechaCita"]);
            TimeSpan horaCita = (TimeSpan)reader["HoraCita"];
            string periodo = reader["Periodo"].ToString();
            int citaID = Convert.ToInt32(reader["CitaID"]);
            string statusActual = reader["Status"].ToString();

            // Panel izquierdo: fecha y hora
            Panel panelInfo = new Panel();
            panelInfo.Size = new Size(100, 110);
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
            lblPaciente.Size = new Size(300, 25);
            lblPaciente.Location = new Point(120, 15);
            lblPaciente.ForeColor = Color.White;
            panelCita.Controls.Add(lblPaciente);

            // Teléfono
            Label lblTelefono = new Label();
            lblTelefono.Text = $"📞 {reader["Telefono"]}";
            lblTelefono.Font = new Font("Segoe UI", 10);
            lblTelefono.Size = new Size(200, 20);
            lblTelefono.Location = new Point(120, 45);
            lblTelefono.ForeColor = Color.LightGray;
            panelCita.Controls.Add(lblTelefono);

            // Motivo
            Label lblMotivo = new Label();
            lblMotivo.Text = $"📋 {reader["Motivo"]}";
            lblMotivo.Font = new Font("Segoe UI", 10);
            lblMotivo.Size = new Size(350, 20);
            lblMotivo.Location = new Point(120, 70);
            lblMotivo.ForeColor = Color.LightGray;
            panelCita.Controls.Add(lblMotivo);

            // ComboBox para Status
            ComboBox cmbStatus = new ComboBox();
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] {
                "Programada",
                "Confirmada",
                "Completada",
                "Cancelada",
                "No asistió",
                "Reprogramada"
            });
            cmbStatus.SelectedItem = statusActual;
            cmbStatus.Location = new Point(120, 95);
            cmbStatus.Size = new Size(150, 25);
            cmbStatus.Tag = citaID; // guardar el ID de la cita
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            cmbStatus.Font = new Font("Segoe UI", 9);
            panelCita.Controls.Add(cmbStatus);

            // Botón Eliminar
            Button btnEliminar = new Button();
            btnEliminar.Size = new Size(80, 30);
            btnEliminar.Location = new Point(panelCita.Width - btnEliminar.Width - 10, 70);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Tag = citaID;
            btnEliminar.Click += BtnEliminar_Click;
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCita.Controls.Add(btnEliminar);

            // Año
            Label lblAnio = new Label();
            lblAnio.Text = $"Año: {fechaCita:yyyy}";
            lblAnio.Font = new Font("Segoe UI", 9);
            lblAnio.Size = new Size(60, 20);
            lblAnio.Location = new Point(panelCita.Width - lblAnio.Width - 10, 15);
            lblAnio.ForeColor = Color.LightGray;
            lblAnio.TextAlign = ContentAlignment.MiddleRight;
            lblAnio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCita.Controls.Add(lblAnio);

            flowPanelCitas.Controls.Add(panelCita);
        }

        private void AjustarTamañoPaneles()
        {
            foreach (Control control in flowPanelCitas.Controls)
            {
                if (control is Panel panelCita)
                {
                    panelCita.Width = flowPanelCitas.ClientSize.Width - 25;

                    foreach (Control innerControl in panelCita.Controls)
                    {
                        if (innerControl is Button btn && btn.Text == "Eliminar")
                        {
                            btn.Location = new Point(panelCita.Width - 90, 70);
                        }
                        else if (innerControl is Label lbl && lbl.Text.StartsWith("Año"))
                        {
                            lbl.Location = new Point(panelCita.Width - lbl.Width - 10, 15);
                        }
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int citaID = (int)btnEliminar.Tag;

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta cita?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                EliminarCita(citaID);
            }
        }

        private void EliminarCita(int citaID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cita WHERE CitaID = @CitaID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@CitaID", citaID);

                try
                {
                    conexion.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cita eliminada correctamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AplicarFiltro();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la cita: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarMensajeVacio()
        {
            if (flowPanelCitas.Controls.Count == 0)
            {
                Panel placeholder = new Panel();
                placeholder.Width = flowPanelCitas.ClientSize.Width - 25;
                placeholder.Height = 100;
                placeholder.BackColor = Color.FromArgb(45, 45, 48);

                Label lblVacio = new Label();
                lblVacio.Text = "No hay citas para esta fecha.";
                lblVacio.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblVacio.ForeColor = Color.Gray;
                lblVacio.Dock = DockStyle.Fill;
                lblVacio.TextAlign = ContentAlignment.MiddleCenter;

                placeholder.Controls.Add(lblVacio);
                flowPanelCitas.Controls.Add(placeholder);
            }
        }

        private void ActualizarTitulo(string subtitulo)
        {
            lblTitulo.Text = $"AGENDA DE CITAS - {subtitulo.ToUpper()}";
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Manejador para actualizar el Status en BD
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb != null && cmb.Tag is int citaID)
            {
                string nuevoStatus = cmb.SelectedItem.ToString();
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Cita SET Status = @Status WHERE CitaID = @CitaID";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Status", nuevoStatus);
                    cmd.Parameters.AddWithValue("@CitaID", citaID);

                    try
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Estado de la cita actualizado correctamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el estado: {ex.Message}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
