using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sistema.Expediente.Historia
{
    public partial class frmHistoria : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }
        public frmHistoria()
        {
            InitializeComponent();
        }

        // VALIDAR PACIENTE

        private bool ExistePaciente(int pacienteId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Paciente WHERE PacienteID = @PacienteID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteID", pacienteId);
                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }
        // GUARDAR ANTECEDENTES PATOLOGICOS
        private void GuardarAntecedentePatologico(int pacienteId)
        {
            if (!ExistePaciente(pacienteId))
            {
                MessageBox.Show("El paciente no existe. No se pueden guardar antecedentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
IF EXISTS (SELECT 1 FROM AntecedentePatologico WHERE PacienteID = @PacienteID)
    UPDATE AntecedentePatologico
    SET Hipertension = @Hipertension,
        Tuberculosis = @Tuberculosis,
        Diabetes = @Diabetes,
        Obesidad = @Obesidad,
        Tiroides = @Tiroides,
        Dislipidemia = @Dislipidemia,
        Sarampion = @Sarampion,
        Rubeola = @Rubeola,
        Tosferina = @Tosferina,
        Varicela = @Varicela,
        Artritis = @Artritis,
        Osteoporosis = @Osteoporosis,
        OtroPadecimiento = @OtroPadecimiento,
        Padecimiento = @Padecimiento
    WHERE PacienteID = @PacienteID
ELSE
    INSERT INTO AntecedentePatologico (
        PacienteID, Hipertension, Tuberculosis, Diabetes, Obesidad, Tiroides, Dislipidemia,
        Sarampion, Rubeola, Tosferina, Varicela, Artritis, Osteoporosis, OtroPadecimiento, Padecimiento
    ) VALUES (
        @PacienteID, @Hipertension, @Tuberculosis, @Diabetes, @Obesidad, @Tiroides, @Dislipidemia,
        @Sarampion, @Rubeola, @Tosferina, @Varicela, @Artritis, @Osteoporosis, @OtroPadecimiento, @Padecimiento
    )";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteID", pacienteId);
                    command.Parameters.AddWithValue("@Hipertension", toggleHipertension.Checked);
                    command.Parameters.AddWithValue("@Tuberculosis", toggleTuberculosis.Checked);
                    command.Parameters.AddWithValue("@Diabetes", toggleDiabetes.Checked);
                    command.Parameters.AddWithValue("@Obesidad", toggleObesidad.Checked);
                    command.Parameters.AddWithValue("@Tiroides", toggleTiroides.Checked);
                    command.Parameters.AddWithValue("@Dislipidemia", toggleDislipidemia.Checked);
                    command.Parameters.AddWithValue("@Sarampion", toggleSarampion.Checked);
                    command.Parameters.AddWithValue("@Rubeola", toggleRubeola.Checked);
                    command.Parameters.AddWithValue("@Tosferina", toggleTosferina.Checked);
                    command.Parameters.AddWithValue("@Varicela", toggleVaricela.Checked);
                    command.Parameters.AddWithValue("@Artritis", toggleArtritis.Checked);
                    command.Parameters.AddWithValue("@Osteoporosis", toggleOsteoporosis.Checked);
                    command.Parameters.AddWithValue("@OtroPadecimiento", toggleOtroPadecimiento.Checked);
                    command.Parameters.AddWithValue("@Padecimiento", txtPadecimiento.Text ?? "");

                    connection.Open();
                    sistema.Infrastructure.Sql.SqlSessionContext.SetAppUser(connection, sistema.Infrastructure.Security.Sesion.UsuarioActual);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Antecedentes patológicos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // GUARDAR ANTECEDENTES PERSONALES
        private void GuardarAntecedentePersonal(int pacienteId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
IF EXISTS (SELECT 1 FROM AntecedentePersonal WHERE PacienteID = @PacienteID)
    UPDATE AntecedentePersonal
    SET Tabaco = @Tabaco, Alcohol = @Alcohol, Mascotas = @Mascotas, Servicios = @Servicios, Vivienda = @Vivienda, FechaActualizacion = GETDATE()
    WHERE PacienteID = @PacienteID
else
    INSERT INTO AntecedentePersonal (PacienteID, Tabaco, Alcohol, Mascotas, Servicios, Vivienda)
    VALUES (@PacienteID, @Tabaco, @Alcohol, @Mascotas, @Servicios, @Vivienda)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteID", pacienteId);
                    command.Parameters.AddWithValue("@Tabaco", cbTabaquismo.Text ?? "");
                    command.Parameters.AddWithValue("@Alcohol", cbAlcohol.Text ?? "");
                    command.Parameters.AddWithValue("@Vivienda", cbVivienda.Text ?? "");

                    var servicios = new System.Collections.Generic.List<string>();
                    if (toggleAgua.Checked) servicios.Add("Agua Potable");
                    if (toggleLuz.Checked) servicios.Add("Luz");
                    if (toggleDrenaje.Checked) servicios.Add("Drenaje");
                    command.Parameters.AddWithValue("@Servicios", string.Join(",", servicios));

                    var mascotas = new System.Collections.Generic.List<string>();
                    if (togglePerros.Checked) mascotas.Add("Perros");
                    if (toggleGatos.Checked) mascotas.Add("Gatos");
                    if (toggleOtraMascota.Checked) mascotas.Add("Otro");
                    command.Parameters.AddWithValue("@Mascotas", string.Join(",", mascotas));

                    connection.Open();
                    sistema.Infrastructure.Sql.SqlSessionContext.SetAppUser(connection, sistema.Infrastructure.Security.Sesion.UsuarioActual);

                    command.ExecuteNonQuery();
                }
            }
        }
        // CARGAR ANTECEDENTES PATOLOGICOS
        private void CargarAntecedentePatologico(int pacienteId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Hipertension, Tuberculosis, Diabetes, Obesidad, Tiroides, Dislipidemia, Sarampion, Rubeola, Tosferina, Varicela, Artritis, Osteoporosis, OtroPadecimiento, Padecimiento
                         FROM AntecedentePatologico
                         WHERE PacienteID = @PacienteID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteID", pacienteId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            toggleHipertension.Checked = Convert.ToBoolean(reader["Hipertension"]);
                            toggleTuberculosis.Checked = Convert.ToBoolean(reader["Tuberculosis"]);
                            toggleDiabetes.Checked = Convert.ToBoolean(reader["Diabetes"]);
                            toggleObesidad.Checked = Convert.ToBoolean(reader["Obesidad"]);
                            toggleTiroides.Checked = Convert.ToBoolean(reader["Tiroides"]);
                            toggleDislipidemia.Checked = Convert.ToBoolean(reader["Dislipidemia"]);
                            toggleSarampion.Checked = Convert.ToBoolean(reader["Sarampion"]);
                            toggleRubeola.Checked = Convert.ToBoolean(reader["Rubeola"]);
                            toggleTosferina.Checked = Convert.ToBoolean(reader["Tosferina"]);
                            toggleVaricela.Checked = Convert.ToBoolean(reader["Varicela"]);
                            toggleArtritis.Checked = Convert.ToBoolean(reader["Artritis"]);
                            toggleOsteoporosis.Checked = Convert.ToBoolean(reader["Osteoporosis"]);
                            toggleOtroPadecimiento.Checked = Convert.ToBoolean(reader["OtroPadecimiento"]);
                            txtPadecimiento.Text = reader["Padecimiento"]?.ToString() ?? "";
                        }
                    }
                }
            }
        }
        // CARGAR ANTECEDENTES PERSONALES
        private void CargarAntecedentePersonal(int pacienteId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Tabaco, Alcohol, Mascotas, Servicios, Vivienda FROM AntecedentePersonal WHERE PacienteID = @PacienteID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteID", pacienteId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cbTabaquismo.Text = reader["Tabaco"]?.ToString() ?? "";
                            cbAlcohol.Text = reader["Alcohol"]?.ToString() ?? "";
                            cbVivienda.Text = reader["Vivienda"]?.ToString() ?? "";

                            // Servicios
                            string servicios = reader["Servicios"]?.ToString() ?? "";
                            toggleAgua.Checked = servicios.Contains("Agua Potable");
                            toggleLuz.Checked = servicios.Contains("Luz");
                            toggleDrenaje.Checked = servicios.Contains("Drenaje");

                            // Mascotas
                            string mascotas = reader["Mascotas"]?.ToString() ?? "";
                            togglePerros.Checked = mascotas.Contains("Perros");
                            toggleGatos.Checked = mascotas.Contains("Gatos");
                            toggleOtraMascota.Checked = mascotas.Contains("Otro");
                        }
                    }
                }
            }
        }

        // CARGAR DETALLES DEL PACIENTE
        private void CargarDetallesPaciente()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    // Consulta para obtener únicamente el contenido de la columna 'Detalles'.
                    const string sql = "SELECT Detalles FROM Paciente WHERE PacienteID = @PacienteID;";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PacienteID", this.PacienteID);
                        conn.Open();

                        // ExecuteScalar es muy eficiente para obtener un solo valor.
                        object resultado = cmd.ExecuteScalar();

                        // Si el resultado no es nulo ni DBNull, lo asignamos al TextBox.
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            txtPadecimientoActual.Text = resultado.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHistoria_Load(object sender, EventArgs e)
        {
            if (this.PacienteID <= 0)
            {
                MessageBox.Show("No se ha especificado un paciente válido");
                this.Close();
                return;
            }

            CargarAntecedentePatologico(PacienteID);
            CargarAntecedentePersonal(PacienteID);
            CargarDetallesPaciente();
        }

        private void btnGuardarAntecedentes_Click(object sender, EventArgs e)
        {
            GuardarAntecedentePatologico(PacienteID);
            GuardarAntecedentePersonal(PacienteID);
        }

        private void btnGuardarPadecimiento_Click(object sender, EventArgs e)
        {
            // Validamos que tengamos un paciente seleccionado.
            if (this.PacienteID <= 0)
            {
                MessageBox.Show("No se ha seleccionado un paciente válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos el texto del TextBox.
            string detalles = txtPadecimientoActual.Text.Trim();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    // Consulta para ACTUALIZAR (UPDATE) el registro del paciente existente.
                    const string sql = "UPDATE Paciente SET Detalles = @Detalles WHERE PacienteID = @PacienteID;";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        // Establece el contexto de sesión para la auditoría, si la tienes configurada.
                        sistema.Infrastructure.Sql.SqlSessionContext.SetAppUser(conn, sistema.Infrastructure.Security.Sesion.UsuarioActual);

                        // Usamos parámetros para seguridad y para manejar correctamente los nulos.
                        // Si el texto está vacío, guardamos un DBNull.Value en la base de datos.
                        cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrWhiteSpace(detalles) ? (object)DBNull.Value : detalles);
                        cmd.Parameters.AddWithValue("@PacienteID", this.PacienteID);

                        // Ejecutamos el comando de actualización.
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Los detalles del paciente se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró al paciente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
