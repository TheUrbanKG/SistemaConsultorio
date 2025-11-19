using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace sistema
{
    public partial class frmMain : Form
    {
        // Lee la cadena de conexión desde el archivo App.config para conectar a la base de datos.
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        // Arreglo para almacenar los botones de navegación principal (del tipo SATAButton).
        // Esto nos permite gestionarlos todos juntos, por ejemplo, para cambiar sus colores.
        private FrameworkTest.SATAButton[] _navMainButtons;

        public frmMain()
        {
            InitializeComponent();
            // Llama al método para configurar los colores y estados de los botones de navegación al iniciar.
            InicializarNavegacionLateral();
        }

        // Este método se ejecuta cuando el formulario principal se ha cargado completamente.
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Abre el formulario de 'Inicio' por defecto dentro del panel contenedor.
            abrirFormHijo(new frmInicio(this));
            // Establece el título y el ícono en la barra superior para que coincidan con la sección 'Inicio'.
            labelTitulo.Text = "Inicio";
            this.pbTitulo.Image = Properties.Resources.hogar;

            // Comprueba el rol del usuario actual y oculta o muestra el botón de 'Gestión de Cuentas'.
            AplicarPermisosCuentasPorRol();

            // Resalta visualmente el botón 'Inicio' para indicar que es la sección activa.
            SetActiveNavButton(BTNInicio);
        }

        public void abrirFormHijo(object formHijo)
        {
            // Si ya hay un formulario en el panel, lo elimina para dar paso al nuevo.
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            // Convierte el objeto recibido a un tipo 'Form'.
            Form fh = formHijo as Form;
            // Configura el formulario para que no sea una ventana de nivel superior, sino un control hijo.
            fh.TopLevel = false;
            // Hace que el formulario hijo ocupe todo el espacio del panel contenedor.
            fh.Dock = DockStyle.Fill;
            // Añade el formulario hijo al panel.
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            // Muestra el formulario.
            fh.Show();
        }

        // --- MANEJADORES DE EVENTOS PARA LOS BOTONES DE NAVEGACIÓN ---

        private void BTNInicio_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmInicio(this)); // Abre el formulario de inicio.
            labelTitulo.Text = "Inicio"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.hogar; // Actualiza el ícono.
            SetActiveNavButton(BTNInicio); // Resalta el botón de inicio.
            this.Refresh(); // Refresca la UI.
        }

        private void BTNCitas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCitas()); // Abre el formulario de citas.
            labelTitulo.Text = "Citas"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.calendario; // Actualiza el ícono.
            SetActiveNavButton(BTNCitas); // Resalta el botón de citas.
            this.Refresh();
        }

        private void BTNPacientes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmPacientes()); // Abre el formulario de pacientes.
            labelTitulo.Text = "Pacientes"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.paciente; // Actualiza el ícono.
            SetActiveNavButton(BTNPacientes); // Resalta el botón de pacientes.
            this.Refresh();
        }

        private void BTNAgenda_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmAgenda()); // Abre el formulario de agenda.
            labelTitulo.Text = "Agenda"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.agenda; // Actualiza el ícono.
            SetActiveNavButton(BTNAgenda); // Resalta el botón de agenda.
            this.Refresh();
        }

        private void BTNNotas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmNotas()); // Abre el formulario de notas.
            labelTitulo.Text = "Notas"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.notas; // Actualiza el ícono.
            SetActiveNavButton(BTNNotas); // Resalta el botón de notas.
            this.Refresh();
        }

        private void BTNSalir_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo para confirmar si el usuario realmente quiere salir.
            DialogResult result = MessageBox.Show("Estas seguro que desea salir?", "Confirmacion de salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Si el usuario hace clic en 'Sí', se cierra la aplicación completamente.
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCuentas()); // Abre el formulario de gestión de cuentas.
            labelTitulo.Text = "Gestion De Cuentas"; // Actualiza el título.
            this.pbTitulo.Image = Properties.Resources.usuario; // Actualiza el ícono.
            SetActiveNavButton(btnCuentas); // Resalta el botón de cuentas.
            this.Refresh();
        }

        // --- LÓGICA DE PERMISOS Y NAVEGACIÓN ---

        // Revisa el rol del usuario que ha iniciado sesión para mostrar u ocultar la sección de 'Gestión de Cuentas'.
        private void AplicarPermisosCuentasPorRol()
        {
            try
            {
                bool esAdmin = false;
                // Obtiene el nombre del usuario actual desde la clase estática 'Sesion'.
                string usuario = sistema.Infrastructure.Security.Sesion.UsuarioActual;

                // Si hay un usuario en sesión, consulta su rol en la base de datos.
                if (!string.IsNullOrWhiteSpace(usuario))
                {
                    using (var conn = new SqlConnection(connectionString))
                    using (var cmd = new SqlCommand("SELECT TOP (1) Rol FROM login WHERE Usuario = @Usuario", conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        conn.Open();
                        // ExecuteScalar es eficiente para obtener un solo valor.
                        var rol = cmd.ExecuteScalar()?.ToString();
                        // Comprueba si el rol es 'Administrador', ignorando mayúsculas/minúsculas.
                        esAdmin = string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase);
                    }
                }

                // Aplica la visibilidad y habilitación al panel y al botón de cuentas.
                // Solo los administradores podrán ver y usar esta sección.
                if (panelCuentas != null)
                {
                    panelCuentas.Visible = esAdmin;
                    panelCuentas.Enabled = esAdmin;
                }
                if (btnCuentas != null)
                    btnCuentas.Enabled = esAdmin;
            }
            catch
            {
                // Si ocurre cualquier error (ej. fallo de conexión), se oculta la sección por seguridad.
                if (panelCuentas != null)
                {
                    panelCuentas.Visible = false;
                    panelCuentas.Enabled = false;
                }
                if (btnCuentas != null)
                    btnCuentas.Enabled = false;
            }
        }

        // Configura los colores de los botones de navegación para el efecto de resaltado.
        private void InicializarNavegacionLateral()
        {
            // Define qué botones forman parte del menú de navegación principal.
            _navMainButtons = new[] { BTNInicio, BTNCitas, BTNPacientes, BTNAgenda, BTNNotas, btnCuentas };

            foreach (var sb in _navMainButtons)
            {
                if (sb == null) continue; // Si un botón no existe en el diseñador, lo ignora.

                // Guarda el color de fondo normal del botón en su propiedad 'Tag'.
                // Esto nos permite recordar el color original para restaurarlo después.
                if (sb.Tag == null) sb.Tag = sb.NormalBackground;

                // Si el color para cuando el mouse pasa por encima ('Hover') no está definido,
                // lo calcula automáticamente aclarando un poco el color normal.
                if (sb.HoverBackground.IsEmpty)
                {
                    var normal = (Color)sb.Tag;
                    sb.HoverBackground = ControlPaint.Light(normal);
                }
            }
        }

        // Cambia el color de fondo del botón activo para que parezca que está "presionado" o seleccionado.
        private void SetActiveNavButton(FrameworkTest.SATAButton active)
        {
            if (_navMainButtons == null) return; // Si los botones no se han inicializado, no hace nada.

            // Recorre todos los botones de navegación.
            foreach (var sb in _navMainButtons)
            {
                if (sb == null) continue;

                // Recupera el color normal original que guardamos en el 'Tag'.
                var normal = (Color)(sb.Tag ?? sb.NormalBackground);

                // Si el botón actual es el que queremos activar...
                if (sb == active)
                {
                    // ...le asigna el color de 'Hover' como su color de fondo normal.
                    var hover = sb.HoverBackground.IsEmpty ? ControlPaint.Light(normal) : sb.HoverBackground;
                    sb.NormalBackground = hover;
                    // También cambia el color del texto si hay un color de 'Hover' definido para él.
                    if (!sb.HoverForeColor.IsEmpty)
                        sb.NormalForeColor = sb.HoverForeColor;
                }
                else
                {
                    // Si no es el botón activo, le restaura su color de fondo original.
                    sb.NormalBackground = normal;
                }

                // Invalida y refresca el botón para forzar que se redibuje con los nuevos colores.
                sb.Invalidate();
                sb.Refresh();
            }
        }
    }
}
