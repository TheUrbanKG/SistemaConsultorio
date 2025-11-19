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

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

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

                    // AGREGAR PARÁMETRO DE HUELLA
                    if (dlg.HuellaCapturada != null && dlg.HuellaCapturada.Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@Huella", dlg.HuellaCapturada);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Huella", DBNull.Value);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                CargarUsuarios();

                // Mensaje informativo sobre la huella
                string mensajeHuella = dlg.HuellaCapturada != null ?
                    " con huella digital registrada" : " sin huella digital";

                MessageBox.Show($"Usuario creado correctamente{mensajeHuella}.");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // PK/UNIQUE
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

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

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
                    if (dlg.HuellaCapturada != null && dlg.HuellaCapturada.Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@Huella", dlg.HuellaCapturada);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Huella", huellaActual ?? (object)DBNull.Value);
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // Pide al usuario que elija dónde guardar el archivo.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak";
            saveFileDialog.FileName = $"tesis_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            saveFileDialog.Title = "Guardar copia de seguridad de la base de datos";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                try
                {
                    using (var conn = new SqlConnection(connectionString))
                    {
                        // El comando BACKUP DATABASE debe ejecutarse en su propio lote.
                        string sql = $"BACKUP DATABASE tesis TO DISK = @ruta";
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ruta", rutaArchivo);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Copia de seguridad creada exitosamente en:\n" + rutaArchivo, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la copia de seguridad:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
