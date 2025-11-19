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
            // RECOLECCIÓN Y VALIDACIÓN DE DATOS DE ENTRADA
            var usuario = txtUsuario.Text?.Trim(); 
            var password = txtPassword.Text ?? "";   

            // Valida que el campo de usuario no esté vacío.
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Usuario requerido");
                return; 
            }

            // 2. CONEXIÓN Y CONSULTA A LA BASE DE DATOS
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT Contraseña, Status FROM login WHERE Usuario=@u", conn))
            {
              
                cmd.Parameters.AddWithValue("@u", usuario);
                conn.Open(); // conexión a la base de datos.

                string storedHash = null; 
                string status = null;     

                using (var rd = cmd.ExecuteReader())
                {
                    // 3. VERIFICACIÓN DEL USUARIO Y SU ESTADO
                    if (!rd.Read()) 
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                        return;
                    }

                    // Lee los valores de la base de datos.
                    storedHash = rd.IsDBNull(0) ? null : rd.GetString(0);
                    status = rd.IsDBNull(1) ? null : rd.GetString(1);

                    // Comprueba si el usuario está activo.
                    if (!string.Equals(status, "Habilitado", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Usuario deshabilitado.");
                        return;
                    }

                    // 4. VERIFICACIÓN DE LA CONTRASEÑA
                    bool passwordValida = false;
                    if (!string.IsNullOrEmpty(storedHash) && storedHash.StartsWith("PBKDF2$", StringComparison.Ordinal))
                    {
                        // Compara la contraseña ingresada con el hash almacenado.
                        passwordValida = PasswordHasher.VerifyPBKDF2(password, storedHash);
                    }

                    if (!passwordValida)
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                        return;
                    }
                } 


            } 

            // 6. INICIO DE SESIÓN EXITOSO
            sistema.Infrastructure.Security.Sesion.UsuarioActual = usuario;
            this.Hide();
            var mainForm = new frmMain();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        /// Maneja el evento de clic para el inicio de sesión con huella dactilar.
        private void btnHuella_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VERIFICACIÓN PRELIMINAR
                if (!HayHuellasRegistradasEnBD())
                {
                    MessageBox.Show("No hay huellas registradas en el sistema. Por favor, use usuario y contraseña.",
                                  "Sin huellas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. PROCESO DE VERIFICACIÓN DE HUELLA
                using (var verificarHuellaForm = new VerificarHuellaForm())
                {
                    var resultado = verificarHuellaForm.ShowDialog(); 

                    if (resultado == DialogResult.OK && verificarHuellaForm.HuellaVerificada)
                    {
                        string usuarioVerificado = verificarHuellaForm.UsuarioVerificado;

                        // 3. VERIFICACIÓN DEL ESTADO DEL USUARIO
                        if (!VerificarEstadoUsuario(usuarioVerificado))
                        {
                            MessageBox.Show("Usuario deshabilitado.", "Acceso denegado",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 4. INICIO DE SESIÓN EXITOSO
                        txtUsuario.Text = usuarioVerificado;
                        sistema.Infrastructure.Security.Sesion.UsuarioActual = usuarioVerificado;
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

        /// Comprueba si hay al menos un usuario con una huella registrada en la base de datos.
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

        /// Verifica si el estado de un usuario específico es "Habilitado".
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

                        // Devuelve true solo si el estado es "Habilitado".
                        return string.Equals(status, "Habilitado", StringComparison.OrdinalIgnoreCase);
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
