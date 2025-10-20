using sistema.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace sistema
{
    public partial class frmPacientes : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            // Asegura autogeneración por si el diseñador no quedó en True
            dgvPacientes.AutoGenerateColumns = true;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            AplicarTemaGrid();

            CargarPacientes(); // carga inicial

            // Búsqueda en vivo (igual que frmNotas)
            txtBuscar.TextChanged += (s, ev) => CargarPacientes(txtBuscar.Text);
        }

        // Carga con filtro opcional (servidor) y enlaza por DataSource
        public void CargarPacientes(string search = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    PacienteID AS ID,
    Cedula,
    Nombre,
    Apellido,
    DATEDIFF(YEAR, FechaNacimiento, GETDATE()) -
        CASE WHEN MONTH(FechaNacimiento) > MONTH(GETDATE())
               OR (MONTH(FechaNacimiento) = MONTH(GETDATE()) AND DAY(FechaNacimiento) > DAY(GETDATE()))
             THEN 1 ELSE 0 END AS EdadActual,
    ISNULL(NULLIF(LTRIM(RTRIM(Genero)), ''), 'N/D') AS Genero,
    Telefono
FROM Paciente
WHERE Cedula <> 'SIN-CEDULA'
  AND (
    @q IS NULL
    OR Nombre  LIKE @q
    OR Apellido LIKE @q
    OR Cedula   LIKE @q
    OR Telefono LIKE @q
  )
ORDER BY Nombre, Apellido;";

                    var da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@q",
                        string.IsNullOrWhiteSpace(search) ? (object)DBNull.Value : $"%{search.Trim()}%");

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvPacientes.DataSource = dt; // binding directo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes: " + ex.Message);
            }
        }

        // Tema oscuro consistente con tus formularios (verde de acento)
        private void AplicarTemaGrid()
        {
            var fondo = Color.FromArgb(45, 48, 53);
            var fila = Color.FromArgb(54, 57, 63);
            var alterna = Color.FromArgb(60, 63, 70);
            var header = Color.FromArgb(62, 62, 62);
            var acento = Color.FromArgb(0, 167, 110);

            dgvPacientes.BackgroundColor = fondo;
            dgvPacientes.BorderStyle = BorderStyle.None;
            dgvPacientes.GridColor = header;

            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = acento;
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9f, FontStyle.Bold);
            dgvPacientes.ColumnHeadersHeight = 28;

            dgvPacientes.DefaultCellStyle.BackColor = fila;
            dgvPacientes.DefaultCellStyle.ForeColor = Color.White;
            dgvPacientes.DefaultCellStyle.SelectionBackColor = acento;
            dgvPacientes.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = alterna;
            dgvPacientes.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvPacientes.AlternatingRowsDefaultCellStyle.SelectionBackColor = acento;
            dgvPacientes.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var nuevoPaciente = new Paciente();
            var formPaciente = new frmDetallePaciente(nuevoPaciente, this);
            formPaciente.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }
            int pacienteId = Convert.ToInt32(dgvPacientes.SelectedRows[0].Cells["ID"].Value);
            using (var context = new Data.DBContext())
            {
                var paciente = context.Paciente.FirstOrDefault(p => p.PacienteID == pacienteId);
                if (paciente != null)
                {
                    var formPaciente = new frmDetallePaciente(paciente, this);
                    formPaciente.Show();
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                }
            }
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var fila = dgvPacientes.Rows[e.RowIndex];
                if (fila.Cells["ID"].Value == null) { MessageBox.Show("Fila sin ID válido."); return; }

                if (!int.TryParse(fila.Cells["ID"].Value.ToString(), out var pacienteId) || pacienteId <= 0)
                {
                    MessageBox.Show("ID de paciente inválido.");
                    return;
                }

                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";
                string cedula = fila.Cells["Cedula"].Value?.ToString() ?? "";

                var expediente = new sistema.Expediente.frmExpediente
                {
                    PacienteID = pacienteId,
                    NombreCompleto = (nombre + " " + apellido).Trim(),
                    Cedula = cedula
                };

                expediente.StartPosition = FormStartPosition.CenterScreen;
                expediente.Show();
                expediente.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir expediente: " + ex.Message);
            }
        }
    }
}
