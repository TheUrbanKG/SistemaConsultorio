using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using sistema.Infrastructure.Security;

namespace sistema
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuario = txtUsuario.Text?.Trim();
            var password = txtPassword.Text ?? "";

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Usuario requerido");
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT Contraseña, Status FROM login WHERE Usuario=@u", conn))
            {
                cmd.Parameters.AddWithValue("@u", usuario);
                conn.Open();

                string stored = null;   // <-- ahora fuera del reader
                string status = null;

                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                        return;
                    }

                    stored = rd.IsDBNull(0) ? null : rd.GetString(0);
                    status = rd.IsDBNull(1) ? null : rd.GetString(1);

                    if (!string.Equals(status, "Habilitado", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Usuario deshabilitado.");
                        return;
                    }

                    bool ok = false;
                    if (!string.IsNullOrEmpty(stored) && stored.StartsWith("PBKDF2$", StringComparison.Ordinal))
                    {
                        ok = PasswordHasher.VerifyPBKDF2(password, stored);
                    }
                    else
                    {
                        // Compatibilidad con texto plano heredado
                        ok = string.Equals(stored, password);
                    }

                    if (!ok)
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                        return;
                    }
                } // aquí el reader ya está cerrado

                // Si era texto plano, migrar a PBKDF2
                if (!string.IsNullOrEmpty(stored) && !stored.StartsWith("PBKDF2$", StringComparison.Ordinal))
                {
                    var nuevoHash = PasswordHasher.HashPBKDF2(password);
                    using (var up = new SqlCommand("UPDATE login SET Contraseña=@p WHERE Usuario=@u", conn))
                    {
                        up.Parameters.AddWithValue("@p", nuevoHash);
                        up.Parameters.AddWithValue("@u", usuario);
                        up.ExecuteNonQuery();
                    }
                }
            }

            // Setea la sesión para auditoría (triggers)
            sistema.Infrastructure.Security.Sesion.UsuarioActual = usuario;

            // Abrir principal y cerrar Login cuando principal cierre
            this.Hide();
            var main = new frmMain();
            main.FormClosed += (s, args) => this.Close();
            main.Show();
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay huellas registradas en la base de datos
                if (!HayHuellasRegistradasEnBD())
                {
                    MessageBox.Show("No hay huellas registradas en el sistema. Por favor, use usuario y contraseña.",
                                  "Sin huellas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Abrir el formulario de verificación de huella
                using (var verificarHuellaForm = new VerificarHuellaForm())
                {
                    var resultado = verificarHuellaForm.ShowDialog();

                    if (resultado == DialogResult.OK && verificarHuellaForm.HuellaVerificada)
                    {
                        // Login exitoso por huella
                        string usuarioVerificado = verificarHuellaForm.UsuarioVerificado;

                        // Actualizar el campo de usuario
                        txtUsuario.Text = usuarioVerificado;

                        // Verificar el estado del usuario en la base de datos
                        if (!VerificarEstadoUsuario(usuarioVerificado))
                        {
                            MessageBox.Show("Usuario deshabilitado.", "Acceso denegado",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Setea la sesión para auditoría (triggers)
                        sistema.Infrastructure.Security.Sesion.UsuarioActual = usuarioVerificado;

                        // Abrir principal y cerrar Login cuando principal cierre
                        this.Hide();
                        var main = new frmMain();
                        main.FormClosed += (s, args) => this.Close();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Verificación de huella cancelada o no reconocida.",
                                      "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar huella: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HayHuellasRegistradasEnBD()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM login WHERE Huella IS NOT NULL", conn))
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar huellas registradas: {ex.Message}");
                return false;
            }
        }

        private bool VerificarEstadoUsuario(string usuario)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT Status FROM login WHERE Usuario=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", usuario);
                    conn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Usuario no encontrado.");
                            return false;
                        }

                        string status = rd.IsDBNull(0) ? null : rd.GetString(0);

                        if (!string.Equals(status, "Habilitado", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Usuario deshabilitado.");
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar estado del usuario: {ex.Message}");
                return false;
            }
        }
    }
}
