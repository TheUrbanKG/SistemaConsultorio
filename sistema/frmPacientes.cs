using sistema.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmPacientes : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmPacientes()
        {
            InitializeComponent();
        }

        public void CargarPacientes()
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
    Genero,
    Telefono
FROM Paciente;";

                    var dt = new DataTable();
                    new SqlDataAdapter(query, conn).Fill(dt);

                    dgvPacientes.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string genero = row["Genero"]?.ToString();
                        if (string.IsNullOrWhiteSpace(genero)) genero = "N/D";

                        dgvPacientes.Rows.Add(
                            row["ID"],
                            row["Cedula"],
                            row["Nombre"],
                            row["Apellido"],
                            row["EdadActual"],
                            genero,
                            row["Telefono"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes: " + ex.Message);
            }
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                // Validaciones defensivas
                if (fila.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Fila sin ID válido.");
                    return;
                }

                int pacienteId;
                if (!int.TryParse(fila.Cells["ID"].Value.ToString(), out pacienteId) || pacienteId <= 0)
                {
                    MessageBox.Show("ID de paciente inválido.");
                    return;
                }

                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";
                string cedula = fila.Cells["Cedula"].Value?.ToString() ?? "";

                // Crear y configurar el expediente
                var expediente = new sistema.Expediente.frmExpediente
                {
                    PacienteID = pacienteId,
                    NombreCompleto = (nombre + " " + apellido).Trim()
                };

                // Solo asignamos la cédula aquí si quieres mostrar algo inmediato;
                // el formulario luego la reemplazará con el formato completo al cargar.
                expediente.Cedula = cedula;

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
