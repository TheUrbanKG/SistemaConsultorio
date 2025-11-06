using System;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmUsuario : MetroFramework.Forms.MetroForm
    {
        // Indica si la contraseña es opcional (true al modificar; false al crear)
        public bool ContrasenaOpcional { get; set; } = false;

        // Habilita/deshabilita edición del campo Usuario (PK)
        public bool UsuarioEnabled
        {
            get => txtUsuario.Enabled;
            set => txtUsuario.Enabled = value;
        }

        // Propiedades de datos para consumir desde frmCuentas
        public string Usuario { get => txtUsuario.Text?.Trim(); set => txtUsuario.Text = value; }
        public string Nombre { get => txtNombre.Text?.Trim(); set => txtNombre.Text = value; }
        public string Apellido { get => txtApellido.Text?.Trim(); set => txtApellido.Text = value; }
        public string Rol { get => cbRol.Text?.Trim(); set => cbRol.Text = value; }
        public string Status { get => cbStatus.Text?.Trim(); set => cbStatus.Text = value; }
        public string Contrasena => txtPassword.Text;

        public frmUsuario()
        {
            InitializeComponent();

            // Eventos
            btnAñadirUsuario.Click += BtnConfirmar_Click;
            sataButton1.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; Close(); };
            checkBox1.CheckedChanged += (s, e) =>
            {
                bool ver = checkBox1.Checked;
                txtPassword.PasswordChar = ver ? '\0' : '*';
                txtPassword2.PasswordChar = ver ? '\0' : '*';
            };

            // Opcional: valores por defecto
            if (cbRol.Items.Count == 0)
                cbRol.Items.AddRange(new object[] { "Administrador", "Usuario" });
            if (cbStatus.Items.Count == 0)
                cbStatus.Items.AddRange(new object[] { "Habilitado", "Deshabilitado" });
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(Usuario))
            {
                MessageBox.Show("Usuario es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                MessageBox.Show("Nombre es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                MessageBox.Show("Apellido es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(Rol))
            {
                MessageBox.Show("Rol es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(Status))
            {
                MessageBox.Show("Status es requerido."); return;
            }

            var pw1 = txtPassword.Text;
            var pw2 = txtPassword2.Text;

            // Si contraseña es obligatoria (alta) o si se ingresó una en edición, validar y confirmar
            if (!ContrasenaOpcional || !string.IsNullOrWhiteSpace(pw1) || !string.IsNullOrWhiteSpace(pw2))
            {
                if (string.IsNullOrWhiteSpace(pw1) || string.IsNullOrWhiteSpace(pw2))
                {
                    MessageBox.Show("Debes ingresar y confirmar la contraseña."); return;
                }
                if (!pw1.Equals(pw2))
                {
                    MessageBox.Show("Las contraseñas no coinciden."); return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
