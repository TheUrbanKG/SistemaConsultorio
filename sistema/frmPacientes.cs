using sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        PacienteID AS ID,
                        Cedula, 
                        Nombre, 
                        Apellido, 
                        DATEDIFF(YEAR, FechaNacimiento, GETDATE()) - 
                            CASE 
                                WHEN MONTH(FechaNacimiento) > MONTH(GETDATE()) 
                                     OR (MONTH(FechaNacimiento) = MONTH(GETDATE()) AND DAY(FechaNacimiento) > DAY(GETDATE()))
                                THEN 1 ELSE 0 
                            END AS EdadActual,
                        Genero, 
                        Telefono 
                    FROM Paciente";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPacientes.AutoGenerateColumns = false;
                dgvPacientes.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    // Si tienes una columna "Genero" tipo string, puedes convertir aquí
                    string genero = row["Genero"].ToString() == "1" ? "Masculino" : "Femenino";

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

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Paciente nuevoPaciente = new Paciente(); // crear un paciente nuevo vacío
            var formPaciente = new frmDetallePaciente(nuevoPaciente, this); // pasamos paciente + referencia al form actual
            formPaciente.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                var fila = dgvPacientes.SelectedRows[0];
                int pacienteId = Convert.ToInt32(fila.Cells["ID"].Value);

                using (var context = new Data.DBContext())
                {
                    // Buscar el paciente por ID
                    var paciente = context.Paciente.FirstOrDefault(p => p.PacienteID == pacienteId);

                    if (paciente != null)
                    {
                        // PASA el objeto paciente recuperado (con su ID) al formulario de edición
                        var formEditar = new frmDetallePaciente(paciente, this);
                        formEditar.Show();
                        this.Hide();
                        formEditar.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el paciente en la base de datos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un paciente para editar.");
            }

        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvPacientes.Rows[e.RowIndex];
                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";
                string cedula = fila.Cells["Cedula"].Value?.ToString() ?? "";
                int pacienteId = Convert.ToInt32(fila.Cells["ID"].Value);

                var frmExpediente = new sistema.Expediente.frmExpediente();
                frmExpediente.NombreCompleto = $"{nombre} {apellido}";
                frmExpediente.Cedula = cedula;
                frmExpediente.PacienteID = pacienteId;
                frmExpediente.Show();
            }
        }
    }
}
