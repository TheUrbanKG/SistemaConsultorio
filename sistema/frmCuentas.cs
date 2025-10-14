using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using sistema.Infrastructure.Security; // <-- agregar

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
INSERT INTO login (Usuario, Contraseña, Nombre, Apellido, Rol, Status)
VALUES (@Usuario, @Contrasena, @Nombre, @Apellido, @Rol, @Status);";
                    cmd.Parameters.AddWithValue("@Usuario", dlg.Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", PasswordHasher.HashPBKDF2(dlg.Contrasena ?? string.Empty));
                    cmd.Parameters.AddWithValue("@Nombre", dlg.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", dlg.Apellido);
                    cmd.Parameters.AddWithValue("@Rol", dlg.Rol);
                    cmd.Parameters.AddWithValue("@Status", dlg.Status);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                CargarUsuarios();
                MessageBox.Show("Usuario creado correctamente.");
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
    Contraseña = COALESCE(@Contrasena, Contraseña)
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

                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("No se encontró el usuario para modificar.");
                        return;
                    }
                }

                CargarUsuarios();
                MessageBox.Show("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }
    }
}
