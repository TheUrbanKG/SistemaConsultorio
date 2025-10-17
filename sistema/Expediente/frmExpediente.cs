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
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        public int PacienteID { get; set; }

        // Navegación simple: el botón activo toma el color Hover y los demás vuelven a su color Normal
        private Control[] _navButtons;

        public frmExpediente()
        {
            InitializeComponent();
            InicializarNavegacion();
        }

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

        private void frmExpediente_Load(object sender, EventArgs e)
        {
            if (PacienteID > 0)
            {
                CargarCedulaYGenero(PacienteID);
            }

            var registro = new frmRegistro { PacienteID = this.PacienteID };
            abrirFormHijo(registro, btnRegistro); // establece botón activo
            this.Refresh();
        }

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
                        if (r.Read())
                        {
                            cedula = r["Cedula"]?.ToString();
                            genero = r["Genero"]?.ToString();
                        }
                    }
                }

                genero = NormalizarGenero(genero);
                if (string.IsNullOrWhiteSpace(cedula) && genero == "N/D")
                    lbCedulayGenero.Text = "Datos de identificación no disponibles.";
                else
                    lbCedulayGenero.Text = $"V - {cedula} / Género: {genero}.";
            }
            catch
            {
                lbCedulayGenero.Text = "Error al cargar identificación.";
            }
        }

        private string NormalizarGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero)) return "N/D";
            switch (genero.Trim().ToUpperInvariant())
            {
                case "M":
                case "MASCULINO": return "Masculino";
                case "F":
                case "FEMENINO": return "Femenino";
                default: return "N/D";
            }
        }

        // Configura botones: guardamos colores "normales" en Tag y usaremos Hover como activo
        private void InicializarNavegacion()
        {
            _navButtons = new Control[] { btnRegistro, btnHistoria, btnFisico, btnCuadros, btnAlergias, btnRecetas };

            foreach (var c in _navButtons)
            {
                if (c == null) continue;

                // SATAButton
                var sb = c as FrameworkTest.SATAButton;
                if (sb != null)
                {
                    // Guarda NormalBackground como "original"
                    if (sb.Tag == null) sb.Tag = sb.NormalBackground;

                    // Si no tiene Hover definido, creamos uno a partir del normal
                    if (sb.HoverBackground.IsEmpty)
                        sb.HoverBackground = ControlPaint.Light((Color)sb.Tag);

                    continue;
                }

                // Button estándar
                var btn = c as Button;
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.UseVisualStyleBackColor = false;
                    if (btn.Tag == null) btn.Tag = btn.BackColor; // original
                    if (btn.FlatAppearance.MouseOverBackColor.IsEmpty)
                        btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light((Color)btn.Tag);
                }
            }
        }

        // Activa un botón (colorea con Hover) y restaura el resto a su color "normal" guardado
        private void SetActiveNavButton(Control active)
        {
            if (_navButtons == null) return;

            foreach (var c in _navButtons)
            {
                if (c == null) continue;

                var sb = c as FrameworkTest.SATAButton;
                if (sb != null)
                {
                    var normal = (Color)(sb.Tag ?? sb.NormalBackground);
                    if (c == active)
                    {
                        // Fuerza el color activo asignando el Hover al Normal para que se vea inmediatamente
                        sb.NormalBackground = sb.HoverBackground.IsEmpty ? ControlPaint.Light(normal) : sb.HoverBackground;
                    }
                    else
                    {
                        // Restaura el color original
                        sb.NormalBackground = normal;
                    }
                    sb.Invalidate();
                    sb.Refresh();
                    continue;
                }

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

        // Sobrecarga que además resalta el botón que abrió el formulario
        private void abrirFormHijo(Form formHijo, Control originButton)
        {
            abrirFormHijo(formHijo);
            SetActiveNavButton(originButton);
        }

        private void abrirFormHijo(Form formHijo)
        {
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.None;
            formHijo.Width = panelContenedor.ClientSize.Width;
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.Show();

            panelContenedor.AutoScroll = true;
            panelContenedor.HorizontalScroll.Enabled = false;
            panelContenedor.HorizontalScroll.Visible = false;
            panelContenedor.HorizontalScroll.Maximum = 0;
            panelContenedor.PerformLayout();
        }

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

        private void btnPDF_Click(object sender, EventArgs e)
        {
            this.ExportarExpedienteAPdf();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
