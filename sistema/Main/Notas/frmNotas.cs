using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sistema.Data;
using sistema.Models;

namespace sistema
{
    public partial class frmNotas : Form
    {
        private readonly NotasRepository _repo = new NotasRepository();
        private string UsuarioActual => sistema.Infrastructure.Security.Sesion.UsuarioActual;
        private int? _notaEditandoId = null;

        public frmNotas()
        {
            InitializeComponent();
            // Configurar flow para apilado vertical y sin wrap
            flpNotas.FlowDirection = FlowDirection.TopDown;
            flpNotas.WrapContents = false;
            flpNotas.SizeChanged += (s, e) => AjustarAnchoTarjetas();

            // Eventos de UI
            rbGeneral.CheckedChanged += (s, e) => TogglePaciente();
            rbMedica.CheckedChanged += (s, e) => TogglePaciente();
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += (s, e) => LimpiarEditor();
            btnRefrescar.Click += (s, e) => CargarNotas();
            cboFiltroTipo.SelectedIndexChanged += (s, e) => CargarNotas();
            cboFiltroPaciente.SelectedIndexChanged += (s, e) => CargarNotas();
            txtBuscar.TextChanged += (s, e) => CargarNotas();
            this.Load += frmNotas_Load;
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            // Filtros
            cboFiltroTipo.Items.Clear();
            cboFiltroTipo.Items.AddRange(new object[] { "Todos", "Generales", "Médicas" });
            cboFiltroTipo.SelectedIndex = 0;

            CargarNotas();
            rbGeneral.Checked = true; // por defecto

            AjustarAnchoTarjetas(); // asegurar ancho inicial
        }

        private void CargarPacientes()
        {
            var pacientes = _repo.ListarPacientes();
            // Editor
            cboPaciente.DisplayMember = "Nombre";
            cboPaciente.ValueMember = "PacienteID";
            cboPaciente.DataSource = pacientes.ToList();

            // Filtro
            var filtroPac = pacientes.ToList();
            filtroPac.Insert(0, new PacientePreview { PacienteID = 0, Nombre = "Todos" });
            cboFiltroPaciente.DisplayMember = "Nombre";
            cboFiltroPaciente.ValueMember = "PacienteID";
            cboFiltroPaciente.DataSource = filtroPac;
            cboFiltroPaciente.SelectedIndex = 0;
        }

        private void TogglePaciente()
        {
            bool medica = rbMedica.Checked;
            cboPaciente.Enabled = medica;
            if (!medica)
                cboPaciente.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Indique un título.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContenido.Text))
            {
                MessageBox.Show("Escriba el contenido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tipo = rbMedica.Checked ? "Medica" : "General";
            int? pacienteId = null;
            string pacienteNombre = null;

            if (tipo == "Medica")
            {
                if (cboPaciente.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pacienteId = (int)cboPaciente.SelectedValue;
                pacienteNombre = ((PacientePreview)cboPaciente.SelectedItem).Nombre;
            }

            var nota = new Nota
            {
                NotaID = _notaEditandoId ?? 0,
                Usuario = UsuarioActual,
                Tipo = tipo,
                Titulo = txtTitulo.Text.Trim(),
                Contenido = txtContenido.Text.Trim(),
                PacienteID = pacienteId,
                PacienteNombre = pacienteNombre
            };

            try
            {
                if (_notaEditandoId == null)
                {
                    _repo.Crear(nota);
                }
                else
                {
                    _repo.Actualizar(nota);
                }

                LimpiarEditor();
                CargarNotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la nota. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarEditor()
        {
            _notaEditandoId = null;
            txtTitulo.Clear();
            txtContenido.Clear();
            rbGeneral.Checked = true;
            cboPaciente.SelectedIndex = -1;
        }

        private void CargarNotas()
        {
            string tipo = null;
            if (cboFiltroTipo.SelectedItem?.ToString() == "Generales") tipo = "General";
            else if (cboFiltroTipo.SelectedItem?.ToString() == "Médicas") tipo = "Medica";

            int? pacienteId = null;
            if (cboFiltroPaciente.SelectedItem is PacientePreview pp && pp.PacienteID != 0)
                pacienteId = pp.PacienteID;

            string search = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();

            var notas = _repo.Listar(UsuarioActual, tipo, search, pacienteId);
            RenderNotas(notas);
        }

        private void RenderNotas(System.Collections.Generic.List<Nota> notas)
        {
            flpNotas.SuspendLayout();
            flpNotas.Controls.Clear();

            foreach (var n in notas)
            {
                var card = new Panel
                {
                    Width = CalcularAnchoTarjeta(),
                    Height = 120,
                    Margin = new Padding(8),
                    BackColor = Color.FromArgb(30, 80, 85)  
                };

                var lblTipo = new Label
                {
                    Name = "lblTipo",
                    Text = n.Tipo == "Medica" ? "Médica" : "General",
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Location = new Point(12, 10)
                };

                var lblTitulo = new Label
                {
                    Name = "lblTitulo",
                    Text = n.Titulo,
                    AutoSize = false,
                    Height = 22,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(12, 32)
                };

                var lblPaciente = new Label
                {
                    Name = "lblPaciente",
                    Text = n.PacienteNombre != null ? $"Paciente: {n.PacienteNombre}" : "",
                    AutoSize = true,
                    ForeColor = Color.Gainsboro,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(12, 58)
                };

                var lblFecha = new Label
                {
                    Name = "lblFecha",
                    Text = n.CreadoEn.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    AutoSize = true,
                    ForeColor = Color.LightGray,
                    Location = new Point(12, 82)
                };

                var btnEditar = new Button
                {
                    Name = "btnEditar",
                    Text = "Editar",
                    Width = 80,
                    Height = 28,
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnEditar.FlatAppearance.BorderSize = 0;
                btnEditar.Click += (s, e) => CargarEnEditor(n);

                var btnEliminar = new Button
                {
                    Name = "btnEliminar",
                    Text = "Eliminar",
                    Width = 80,
                    Height = 28,
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnEliminar.FlatAppearance.BorderSize = 0;
                btnEliminar.Click += (s, e) =>
                {
                    if (MessageBox.Show("¿Eliminar esta nota?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _repo.Eliminar(n.NotaID, UsuarioActual);
                        CargarNotas();
                    }
                };

                card.Controls.AddRange(new Control[] { lblTipo, lblTitulo, lblPaciente, lblFecha, btnEditar, btnEliminar });

                // Reacomodar internamente según el ancho actual
                card.Resize += (s, e) => LayoutTarjeta((Panel)s);
                LayoutTarjeta(card);

                flpNotas.Controls.Add(card);
            }

            flpNotas.ResumeLayout();
        }

        // Calcula el ancho disponible para cada tarjeta dentro del FlowLayoutPanel
        private int CalcularAnchoTarjeta()
        {
            // espacio útil = ancho cliente - padding del flow - margen horizontal de la tarjeta
            int paddingH = flpNotas.Padding.Horizontal;
            int margenTarjeta = 16; // 8 izq + 8 der (Padding de la tarjeta)
            int w = flpNotas.ClientSize.Width - paddingH - margenTarjeta;
            return Math.Max(200, w);
        }

        // Ajusta todas las tarjetas al redimensionar el FlowLayoutPanel
        private void AjustarAnchoTarjetas()
        {
            int target = CalcularAnchoTarjeta();
            foreach (Control c in flpNotas.Controls)
                if (c is Panel p) p.Width = target;
        }

        // Layout interno de cada tarjeta (coloca botones a la derecha y ajusta el ancho del título)
        private void LayoutTarjeta(Panel card)
        {
            int padding = 12;

            var lblTitulo = (Label)card.Controls["lblTitulo"];
            var btnEditar = (Button)card.Controls["btnEditar"];
            var btnEliminar = (Button)card.Controls["btnEliminar"];

            // Posicionar botones pegados a la derecha
            int right = card.ClientSize.Width - padding;
            btnEliminar.Top = 75;
            btnEliminar.Left = right - btnEliminar.Width;

            btnEditar.Top = 75;
            btnEditar.Left = btnEliminar.Left - 8 - btnEditar.Width;

            // Ajustar ancho del título hasta antes de los botones
            lblTitulo.Width = Math.Max(50, btnEditar.Left - padding - lblTitulo.Left);
        }

        private void CargarEnEditor(Nota n)
        {
            _notaEditandoId = n.NotaID;
            txtTitulo.Text = n.Titulo;
            txtContenido.Text = n.Contenido;

            if (n.Tipo == "Medica")
            {
                rbMedica.Checked = true;
                // seleccionar paciente en combo si existe
                if (n.PacienteID.HasValue)
                    cboPaciente.SelectedValue = n.PacienteID.Value;
            }
            else
            {
                rbGeneral.Checked = true;
                cboPaciente.SelectedIndex = -1;
            }
        }
    }
}
