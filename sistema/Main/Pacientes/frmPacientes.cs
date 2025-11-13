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

            // Establecer "Conocido" como valor por defecto
            cbTipoPaciente.SelectedItem = "Conocido";

            // Agregar opción para filtrar por huella
            cbTipoPaciente.Items.Add("Con Huella");

            CargarPacientes(); // carga inicial

            // Conectar eventos de filtrado
            txtBuscar.TextChanged += (s, ev) => AplicarFiltros();
            cbTipoPaciente.SelectedIndexChanged += (s, ev) => AplicarFiltros();
        }

        // Método para aplicar ambos filtros
        private void AplicarFiltros()
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            string tipoPaciente = cbTipoPaciente.SelectedItem?.ToString();

            CargarPacientes(textoBusqueda, tipoPaciente);
        }

        // Carga con filtros opcionales (búsqueda y tipo de paciente)
        public void CargarPacientes(string search = null, string tipoPaciente = null)
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
    Telefono,
    CASE WHEN Huella IS NOT NULL THEN 'Sí' ELSE 'No' END AS TieneHuella
FROM Paciente
WHERE 1=1";

                    // Filtro para tipo de paciente
                    if (tipoPaciente == "Conocido")
                    {
                        query += " AND Cedula <> 'SIN-CEDULA' AND Cedula NOT LIKE 'desc%'";
                    }
                    else if (tipoPaciente == "Desconocido")
                    {
                        query += " AND (Cedula = 'SIN-CEDULA' OR Cedula LIKE 'desc%')";
                    }
                    else if (tipoPaciente == "Con Huella")
                    {
                        query += " AND Huella IS NOT NULL";
                    }
                    else // Por defecto (incluye cuando se llama sin parámetros)
                    {
                        query += " AND Cedula <> 'SIN-CEDULA' AND Cedula NOT LIKE 'desc%'";
                    }

                    // Filtro de búsqueda por texto
                    query += @" AND (
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

        // Nuevo método para el botón de huella
        private void btnHuella_Click(object sender, EventArgs e)
        {
            try
            {
                using (var verificarPaciente = new VerificarHuellaPaciente())
                {
                    var resultado = verificarPaciente.ShowDialog();

                    if (resultado == DialogResult.OK && verificarPaciente.HuellaVerificada)
                    {
                        FiltrarPorPacienteId(verificarPaciente.PacienteID);

                        MessageBox.Show($"¡Paciente encontrado!\n\nNombre: {verificarPaciente.PacienteEncontrado}\nCédula: {verificarPaciente.CedulaPaciente}",
                                      "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún paciente con esa huella.",
                                      "Búsqueda Fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarTodosLosPacientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar paciente por huella: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener el PacienteID por nombre de usuario
        private int ObtenerPacienteIdPorUsuario(string usuarioNombre)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT PacienteID FROM Paciente WHERE Nombre = @nombre", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuarioNombre);
                    conn.Open();

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar paciente: {ex.Message}");
                return -1;
            }
        }

        // Método para filtrar el DataGridView por PacienteID
        private void FiltrarPorPacienteId(int pacienteId)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
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
    Telefono,
    CASE WHEN Huella IS NOT NULL THEN 'Sí' ELSE 'No' END AS TieneHuella
FROM Paciente
WHERE PacienteID = @id";

                    var da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", pacienteId);

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvPacientes.DataSource = dt;

                    // Si se encontró el paciente, seleccionar la fila
                    if (dt.Rows.Count > 0)
                    {
                        dgvPacientes.ClearSelection();
                        dgvPacientes.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar paciente: {ex.Message}");
            }
        }

        // Método para limpiar filtros y mostrar todos los pacientes
        public void MostrarTodosLosPacientes()
        {
            txtBuscar.Text = "";
            cbTipoPaciente.SelectedItem = "Conocido";
            CargarPacientes();
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

                string cedula = fila.Cells["Cedula"].Value?.ToString() ?? "";
                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";

                // Verificar si es paciente desconocido
                if (EsPacienteDesconocido(cedula))
                {
                    MessageBox.Show("Debe completar los datos del paciente antes de abrir un expediente.",
                        "Paciente Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Abrir formulario de edición del paciente
                    using (var context = new Data.DBContext())
                    {
                        var paciente = context.Paciente.FirstOrDefault(p => p.PacienteID == pacienteId);
                        if (paciente != null)
                        {
                            var formPaciente = new frmDetallePaciente(paciente, this);
                            formPaciente.Show();
                        }
                    }
                    return;
                }

                // Si es paciente conocido, abrir expediente normal
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

        // Método para verificar si un paciente es desconocido
        private bool EsPacienteDesconocido(string cedula)
        {
            return cedula == "SIN-CEDULA" ||
                   (cedula?.StartsWith("desc", StringComparison.OrdinalIgnoreCase) == true);
        }
    }
}