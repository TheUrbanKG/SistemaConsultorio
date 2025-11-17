using sistema.Expediente.ExploracionFisica;
using sistema.Expediente.Historia;
using sistema.Expediente.Recetas;
using sistema.Expediente.Registro;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sistema.Expediente
{
    public partial class frmExpediente : Form
    {
        // Cadena de conexión a la base de datos, leída desde el archivo de configuración App.config.
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        
        // Propiedad pública para recibir el ID del paciente desde el formulario que lo abre (ej. frmPacientes).
        public int PacienteID { get; set; }

        // Arreglo para almacenar los botones de navegación del expediente (Registro, Historia, etc.).
        // Nos permite gestionarlos en conjunto para el resaltado visual.
        private Control[] _navButtons;

        public frmExpediente()
        {
            InitializeComponent();
            // Prepara los botones de navegación (colores, etc.) en cuanto se crea el formulario.
            InicializarNavegacion();
        }

        // Propiedades para establecer fácilmente el nombre y la cédula en las etiquetas de la UI.
        public string NombreCompleto
        {
            get => lbNombre.Text;
            set => lbNombre.Text = value;
        }

        public string Cedula
        {
            get => lbCedulayGenero.Text;
            set => lbCedulayGenero.Text = value;
        }

        // Este método se ejecuta cuando el formulario se carga por primera vez.
        private void frmExpediente_Load(object sender, EventArgs e)
        {
            // Si se ha proporcionado un ID de paciente válido, carga su información de cabecera.
            if (PacienteID > 0)
            {
                CargarCedulaYGenero(PacienteID);
            }

            // Por defecto, abre la sección 'Registro' al entrar al expediente.
            var registro = new frmRegistro { PacienteID = this.PacienteID };
            abrirFormHijo(registro, btnRegistro); // Llama al método para abrir el form y resaltar el botón.
            this.Refresh(); // Refresca la UI.
        }

        // Carga la cédula y el género del paciente desde la base de datos para mostrarlos en la cabecera.
        private void CargarCedulaYGenero(int pacienteId)
        {
            string cedula = null;
            string genero = null;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT Cedula, Genero FROM Paciente WHERE PacienteID = @Id", conn))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pacienteId;
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read()) // Si se encuentra el paciente...
                        {
                            // ...lee sus datos.
                            cedula = r["Cedula"]?.ToString();
                            genero = r["Genero"]?.ToString();
                        }
                    }
                }

                // Limpia y formatea el valor del género para mostrarlo de forma consistente.
                genero = NormalizarGenero(genero);
                
                // Construye el texto final para la etiqueta.
                if (string.IsNullOrWhiteSpace(cedula) && genero == "N/D")
                    lbCedulayGenero.Text = "Datos de identificación no disponibles.";
                else
                    lbCedulayGenero.Text = $"V - {cedula} / Género: {genero}.";
            }
            catch
            {
                // Si algo falla, muestra un mensaje de error genérico en la etiqueta.
                lbCedulayGenero.Text = "Error al cargar identificación.";
            }
        }

        // Método de utilidad para estandarizar el valor del género.
        private string NormalizarGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero)) return "N/D"; // Si es nulo o vacío, devuelve "No disponible".
            switch (genero.Trim().ToUpperInvariant()) // Convierte a mayúsculas y quita espacios.
            {
                case "M":
                case "MASCULINO": return "Masculino";
                case "F":
                case "FEMENINO": return "Femenino";
                default: return "N/D"; // Para cualquier otro valor.
            }
        }

        // --- LÓGICA DE NAVEGACIÓN Y RESALTADO DE BOTONES ---

        // Configura los botones de navegación la primera vez que se carga el formulario.
        private void InicializarNavegacion()
        {
            // Agrupa todos los botones de navegación en un arreglo para manejarlos fácilmente.
            _navButtons = new Control[] { btnRegistro, btnHistoria, btnFisico, btnCuadros, btnAlergias, btnRecetas };

            foreach (var c in _navButtons)
            {
                if (c == null) continue; // Ignora si algún botón no existe.

                // Manejo especial para botones del tipo SATAButton.
                var sb = c as FrameworkTest.SATAButton;
                if (sb != null)
                {
                    if (sb.Tag == null) sb.Tag = sb.NormalBackground; // Guarda el color original.
                    if (sb.HoverBackground.IsEmpty) // Si no tiene color de hover, lo calcula.
                        sb.HoverBackground = ControlPaint.Light((Color)sb.Tag);
                    continue; // Pasa al siguiente control.
                }

                // Manejo para botones estándar de Windows Forms.
                var btn = c as Button;
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.UseVisualStyleBackColor = false;
                    if (btn.Tag == null) btn.Tag = btn.BackColor; // Guarda el color original.
                    if (btn.FlatAppearance.MouseOverBackColor.IsEmpty) // Si no tiene color de hover, lo calcula.
                        btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light((Color)btn.Tag);
                }
            }
        }

        // Cambia el estilo del botón activo y restaura el de los demás.
        private void SetActiveNavButton(Control active)
        {
            if (_navButtons == null) return;

            foreach (var c in _navButtons)
            {
                if (c == null) continue;

                // Lógica para SATAButton.
                var sb = c as FrameworkTest.SATAButton;
                if (sb != null)
                {
                    var normal = (Color)(sb.Tag ?? sb.NormalBackground);
                    // Si es el botón activo, le pone el color de hover.
                    if (c == active)
                    {
                        sb.NormalBackground = sb.HoverBackground.IsEmpty ? ControlPaint.Light(normal) : sb.HoverBackground;
                    }
                    else // Si no, le devuelve su color original.
                    {
                        sb.NormalBackground = normal;
                    }
                    sb.Invalidate();
                    sb.Refresh();
                    continue;
                }

                // Lógica para Button estándar.
                var btn = c as Button;
                if (btn != null)
                {
                    var normal = (Color)(btn.Tag ?? btn.BackColor);
                    if (c == active)
                    {
                        var hover = btn.FlatAppearance.MouseOverBackColor;
                        btn.BackColor = hover.IsEmpty ? ControlPaint.Light(normal) : hover;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.BorderColor = ControlPaint.Light(normal);
                    }
                    else
                    {
                        btn.BackColor = normal;
                        btn.ForeColor = SystemColors.ControlText;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.BorderColor = normal;
                    }
                    btn.Invalidate();
                }
            }
        }

        // --- MANEJADORES DE EVENTOS PARA ABRIR SECCIONES ---

        // Método principal para abrir un formulario hijo y resaltar el botón correspondiente.
        private void abrirFormHijo(Form formHijo, Control originButton)
        {
            abrirFormHijo(formHijo); // Llama al método base para cargar el formulario.
            SetActiveNavButton(originButton); // Resalta el botón que lo invocó.
        }

        // Carga un formulario dentro del 'panelContenedor'.
        private void abrirFormHijo(Form formHijo)
        {
            // Si ya hay un control en el panel, lo elimina.
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);

            formHijo.TopLevel = false; // No es una ventana independiente.
            formHijo.Dock = DockStyle.None; // Se ajustará manualmente.
            formHijo.Width = panelContenedor.ClientSize.Width; // Ajusta el ancho al del panel.
            panelContenedor.Controls.Add(formHijo); // Lo añade al panel.
            formHijo.Show(); // Lo muestra.

            // Configura el scroll del panel.
            panelContenedor.AutoScroll = true;
            panelContenedor.HorizontalScroll.Enabled = false;
            panelContenedor.HorizontalScroll.Visible = false;
        }

        // Cada uno de estos métodos crea una instancia del formulario de la sección
        // y lo abre, pasando el ID del paciente.

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            var registro = new frmRegistro { PacienteID = this.PacienteID };
            abrirFormHijo(registro, btnRegistro);
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var historia = new frmHistoria { PacienteID = this.PacienteID };
            abrirFormHijo(historia, btnHistoria);
        }

        private void btnCuadros_Click(object sender, EventArgs e)
        {
            var cuadros = new frmCuadros { PacienteID = this.PacienteID };
            abrirFormHijo(cuadros, btnCuadros);
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var alergias = new frmAlergias { PacienteID = this.PacienteID };
            abrirFormHijo(alergias, btnAlergias);
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var recetas = new frmRecetas { PacienteID = this.PacienteID };
            abrirFormHijo(recetas, btnRecetas);
        }

        private void btnFisico_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var fisica = new frmExploracionFisica { PacienteID = this.PacienteID };
            abrirFormHijo(fisica, btnFisico);
        }

        // --- BOTONES DE ACCIÓN DE LA VENTANA ---

        private void btnPDF_Click(object sender, EventArgs e)
        {
            this.ExportarExpedienteAPdf(); 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario del expediente.
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimiza la ventana.
        }
    }
}
