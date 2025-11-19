using sistema.Infrastructure.Security;
using sistema.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmCuentas : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public frmCuentas()
        {
            InitializeComponent();
        }

        public void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                Usuario, 
                Nombre, 
                Apellido, 
                Rol, 
                Status
            FROM login";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvUsuarios.Rows.Add(
                        row["Usuario"],
                        row["Nombre"],
                        row["Apellido"],
                        row["Rol"],
                        row["Status"]
                    );
                }
            }
        }

        private void frmCuentas_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Conecta handlers
            btnAñadirUsuario.Click += btnAñadirUsuario_Click;
            btnModificarUsuario.Click += btnModificarUsuario_Click;
        }

        private void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            var dlg = new frmUsuario
            {
                Text = "Añadir usuario",
                UsuarioEnabled = true,
                ContrasenaOpcional = false
            };

            DialogResult dr;
            try
            {
                dr = dlg.ShowDialog(this);
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show("Lector de huellas no disponible o falta una DLL necesaria:\n" + ex.Message,
                    "Lector no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (BadImageFormatException ex)
            {
                MessageBox.Show("Error al cargar la librería del lector de huellas (formato inválido):\n" + ex.Message,
                    "Error de librería", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el diálogo de usuario:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dr != DialogResult.OK) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                INSERT INTO login (Usuario, Contraseña, Nombre, Apellido, Rol, Status, Huella)
                VALUES (@Usuario, @Contrasena, @Nombre, @Apellido, @Rol, @Status, @Huella);";

                    cmd.Parameters.AddWithValue("@Usuario", dlg.Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", PasswordHasher.HashPBKDF2(dlg.Contrasena ?? string.Empty));
                    cmd.Parameters.AddWithValue("@Nombre", dlg.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", dlg.Apellido);
                    cmd.Parameters.AddWithValue("@Rol", dlg.Rol);
                    cmd.Parameters.AddWithValue("@Status", dlg.Status);

                    // Parám. Huella con tipo explícito varbinary(max)
                    var pHuella = cmd.Parameters.Add("@Huella", System.Data.SqlDbType.VarBinary, -1);
                    pHuella.Value = (dlg.HuellaCapturada != null && dlg.HuellaCapturada.Length > 0)
                        ? (object)dlg.HuellaCapturada
                        : DBNull.Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                CargarUsuarios();

                string mensajeHuella = dlg.HuellaCapturada != null ?
                    " con huella digital registrada" : " sin huella digital";

                MessageBox.Show($"Usuario creado correctamente{mensajeHuella}.");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("El usuario ya existe.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message);
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario.");
                return;
            }

            var row = dgvUsuarios.SelectedRows[0];
            string usuarioSel = row.Cells[0].Value?.ToString();
            string nombreSel = row.Cells[1].Value?.ToString();
            string apellidoSel = row.Cells[2].Value?.ToString();
            string rolSel = row.Cells[3].Value?.ToString();
            string statusSel = row.Cells[4].Value?.ToString();

            // Obtener la huella actual del usuario desde la base de datos
            byte[] huellaActual = ObtenerHuellaActual(usuarioSel);

            var dlg = new frmUsuario
            {
                Text = "Modificar usuario",
                Usuario = usuarioSel,
                Nombre = nombreSel,
                Apellido = apellidoSel,
                Rol = rolSel,
                Status = statusSel,
                UsuarioEnabled = false,       // no editar PK
                ContrasenaOpcional = true     // contraseña opcional
            };

            DialogResult dr;
            try
            {
                dr = dlg.ShowDialog(this);
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show("Lector de huellas no disponible o falta una DLL necesaria:\n" + ex.Message,
                    "Lector no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (BadImageFormatException ex)
            {
                MessageBox.Show("Error al cargar la librería del lector de huellas (formato inválido):\n" + ex.Message,
                    "Error de librería", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el diálogo de usuario:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dr != DialogResult.OK) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                UPDATE login
                SET Nombre   = @Nombre,
                    Apellido = @Apellido,
                    Rol      = @Rol,
                    Status   = @Status,
                    Contraseña = COALESCE(@Contrasena, Contraseña),
                    Huella   = @Huella
                WHERE Usuario = @Usuario;";

                    cmd.Parameters.AddWithValue("@Usuario", usuarioSel);
                    cmd.Parameters.AddWithValue("@Nombre", dlg.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", dlg.Apellido);
                    cmd.Parameters.AddWithValue("@Rol", dlg.Rol);
                    cmd.Parameters.AddWithValue("@Status", dlg.Status);

                    if (!string.IsNullOrWhiteSpace(dlg.Contrasena))
                        cmd.Parameters.AddWithValue("@Contrasena", PasswordHasher.HashPBKDF2(dlg.Contrasena));
                    else
                        cmd.Parameters.AddWithValue("@Contrasena", DBNull.Value);

                    // MANEJO DE HUELLA: Si se capturó nueva huella, usar esa; sino mantener la actual
                    var pHuella = cmd.Parameters.Add("@Huella", System.Data.SqlDbType.VarBinary, -1);
                    if (dlg.HuellaCapturada != null && dlg.HuellaCapturada.Length > 0)
                    {
                        pHuella.Value = dlg.HuellaCapturada;
                    }
                    else
                    {
                        pHuella.Value = huellaActual ?? (object)DBNull.Value;
                    }

                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("No se encontró el usuario para modificar.");
                        return;
                    }
                }

                CargarUsuarios();

                // Mensaje informativo sobre la huella
                string mensajeHuella = dlg.HuellaCapturada != null ?
                    " con nueva huella digital" : " (huella digital sin cambios)";

                MessageBox.Show($"Usuario modificado correctamente{mensajeHuella}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        // Método auxiliar para obtener la huella actual de un usuario
        private byte[] ObtenerHuellaActual(string usuario)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Huella FROM login WHERE Usuario = @Usuario";
                    cmd.Parameters.AddWithValue("@Usuario", usuario);

                    conn.Open();
                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return (byte[])result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener huella actual: {ex.Message}", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;
        }

        private void sataButton1_Click(object sender, EventArgs e)
        {
            // Si se está ejecutando dentro de frmMain, abre como hijo en su panel
            var main = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (main != null)
            {
                main.abrirFormHijo(new frmHistorialUsuario());
            }
            else
            {
                var f = new frmHistorialUsuario { StartPosition = FormStartPosition.CenterScreen };
                f.Show();
            }
        }

        private void btnDesabilitar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario.");
                return;
            }

            var row = dgvUsuarios.SelectedRows[0];
            string usuarioSel = row.Cells[0].Value?.ToString();
            string statusSel = row.Cells[4].Value?.ToString();

            if (string.IsNullOrWhiteSpace(usuarioSel))
            {
                MessageBox.Show("Usuario inválido.");
                return;
            }

            // Determinar nuevo estado: si contiene "habil" => deshabilitar, sino habilitar
            string nuevoStatus;
            if (!string.IsNullOrWhiteSpace(statusSel) && statusSel.IndexOf("habil", StringComparison.OrdinalIgnoreCase) >= 0)
                nuevoStatus = "Deshabilitado";
            else
                nuevoStatus = "Habilitado";

            var confirmar = MessageBox.Show($"Cambiar estado de '{usuarioSel}' de '{statusSel}' a '{nuevoStatus}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE login SET Status = @Status WHERE Usuario = @Usuario";
                    cmd.Parameters.AddWithValue("@Status", nuevoStatus);
                    cmd.Parameters.AddWithValue("@Usuario", usuarioSel);

                    conn.Open();
                    int afectados = cmd.ExecuteNonQuery();
                    if (afectados == 0)
                    {
                        MessageBox.Show("No se encontró el usuario para actualizar.");
                        return;
                    }
                }

                CargarUsuarios();
                MessageBox.Show($"Estado actualizado a '{nuevoStatus}' para el usuario '{usuarioSel}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado: " + ex.Message);
            }
        }
    }
}
