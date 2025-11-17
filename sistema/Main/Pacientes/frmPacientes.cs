using sistema.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmPacientes : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        // Constantes para tipos de filtro y valores especiales
        private const string TipoConocido = "Conocido";
        private const string TipoDesconocido = "Desconocido";
        private const string TipoConHuella = "Con Huella";
        private const string CedulaDesconocido = "SIN-CEDULA";
        private const string PrefijoCedulaDesc = "desc";

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            AplicarTemaGrid();
            InicializarFiltros();
            CargarPacientes(); // Carga inicial
        }

        private void ConfigurarGrid()
        {
            dgvPacientes.AutoGenerateColumns = true;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.CellDoubleClick += dgvPacientes_CellDoubleClick;
        }

        private void InicializarFiltros()
        {
            cbTipoPaciente.Items.Add(TipoConHuella);
            cbTipoPaciente.SelectedItem = TipoConocido;

            txtBuscar.TextChanged += (s, ev) => AplicarFiltros();
            cbTipoPaciente.SelectedIndexChanged += (s, ev) => AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string textoBusqueda = txtBuscar.Text;
            string tipoPaciente = cbTipoPaciente.SelectedItem?.ToString();
            CargarPacientes(textoBusqueda, tipoPaciente);
        }

        public void CargarPacientes(string search = null, string tipoPaciente = null)
        {
            var (query, parameters) = ConstruirConsultaPacientes(search, tipoPaciente);
            EjecutarConsulta(query, parameters);
        }

        private void FiltrarPorPacienteId(int pacienteId)
        {
            var (query, parameters) = ConstruirConsultaPacientes(pacienteId: pacienteId);
            var dt = EjecutarConsulta(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvPacientes.ClearSelection();
                dgvPacientes.Rows[0].Selected = true;
            }
        }

        private (string, SqlParameter[]) ConstruirConsultaPacientes(string search = null, string tipoPaciente = null, int? pacienteId = null)
        {
            const string baseQuery = @"
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

            var conditions = new System.Collections.Generic.List<string>();
            var parameters = new System.Collections.Generic.List<SqlParameter>();

            if (pacienteId.HasValue)
            {
                conditions.Add("PacienteID = @id");
                parameters.Add(new SqlParameter("@id", pacienteId.Value));
            }
            else
            {
                string effectiveTipo = tipoPaciente ?? TipoConocido;
                switch (effectiveTipo)
                {
                    case TipoConocido:
                        conditions.Add($"Cedula <> '{CedulaDesconocido}' AND Cedula NOT LIKE '{PrefijoCedulaDesc}%'");
                        break;
                    case TipoDesconocido:
                        conditions.Add($"(Cedula = '{CedulaDesconocido}' OR Cedula LIKE '{PrefijoCedulaDesc}%')");
                        break;
                    case TipoConHuella:
                        conditions.Add("Huella IS NOT NULL");
                        break;
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    conditions.Add("(Nombre LIKE @q OR Apellido LIKE @q OR Cedula LIKE @q OR Telefono LIKE @q)");
                    parameters.Add(new SqlParameter("@q", $"%{search.Trim()}%"));
                }
            }

            string finalQuery = $"{baseQuery} AND {string.Join(" AND ", conditions)} ORDER BY Nombre, Apellido;";
            return (finalQuery, parameters.ToArray());
        }

        private DataTable EjecutarConsulta(string query, SqlParameter[] parameters)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var da = new SqlDataAdapter(query, conn))
                    {
                        if (parameters != null)
                        {
                            da.SelectCommand.Parameters.AddRange(parameters);
                        }

                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvPacientes.DataSource = dt;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar pacientes: " + ex.Message);
                return null;
            }
        }

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

        public void MostrarTodosLosPacientes()
        {
            txtBuscar.Clear();
            cbTipoPaciente.SelectedItem = TipoConocido;
            CargarPacientes();
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var fila = dgvPacientes.Rows[e.RowIndex];
                if (!int.TryParse(fila.Cells["ID"].Value?.ToString(), out int pacienteId) || pacienteId <= 0)
                {
                    MessageBox.Show("La fila seleccionada no contiene un ID de paciente válido.");
                    return;
                }

                string cedula = fila.Cells["Cedula"].Value?.ToString() ?? "";
                if (EsPacienteDesconocido(cedula))
                {
                    MessageBox.Show("Debe completar los datos del paciente antes de abrir un expediente.",
                        "Paciente Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    using (var context = new Data.DBContext())
                    {
                        var paciente = context.Paciente.FirstOrDefault(p => p.PacienteID == pacienteId);
                        if (paciente != null)
                        {
                            new frmDetallePaciente(paciente, this).Show();
                        }
                    }
                    return;
                }

                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";

                var expediente = new sistema.Expediente.frmExpediente
                {
                    PacienteID = pacienteId,
                    NombreCompleto = $"{nombre} {apellido}".Trim(),
                    Cedula = cedula,
                    StartPosition = FormStartPosition.CenterScreen
                };

                expediente.Show();
                expediente.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir expediente: " + ex.Message);
            }
        }

        private bool EsPacienteDesconocido(string cedula)
        {
            return cedula == CedulaDesconocido ||
                   (cedula?.StartsWith(PrefijoCedulaDesc, StringComparison.OrdinalIgnoreCase) == true);
        }
    }
}