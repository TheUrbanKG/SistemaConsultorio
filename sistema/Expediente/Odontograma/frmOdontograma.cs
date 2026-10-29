using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using sistema.Data;
using sistema.Models;

namespace sistema.Expediente.Odontograma
{
    public partial class frmOdontograma : Form
    {
        public int PacienteID { get; set; }

        private readonly OdontogramaRepository _repo = new OdontogramaRepository();
        private readonly Dictionary<int, OdontogramaDiente> _dientesData = new Dictionary<int, OdontogramaDiente>();

        private int _currentOdontoId = 0;
        private int _selectedToothNumber = 11;
        private int _hoveredToothNumber = 0;

        // Coordenadas anatómicas calibradas sobre el lienzo de la boca (235 x 408)
        private readonly Dictionary<int, Point> _posiciones = new Dictionary<int, Point>
        {
            // Arcada Superior: 18..11 (Cuadrante 1, Izquierda en pantalla), 21..28 (Cuadrante 2, Derecha en pantalla)
            { 18, new Point(14, 168) },
            { 17, new Point(14, 138) },
            { 16, new Point(16, 108) },
            { 15, new Point(22, 78) },
            { 14, new Point(34, 52) },
            { 13, new Point(50, 30) },
            { 12, new Point(72, 16) },
            { 11, new Point(96, 10) },

            { 21, new Point(118, 10) },
            { 22, new Point(142, 16) },
            { 23, new Point(164, 30) },
            { 24, new Point(180, 52) },
            { 25, new Point(192, 78) },
            { 26, new Point(198, 108) },
            { 27, new Point(200, 138) },
            { 28, new Point(200, 168) },

            // Arcada Inferior: 48..41 (Cuadrante 4, Izquierda en pantalla), 31..38 (Cuadrante 3, Derecha en pantalla)
            { 48, new Point(14, 224) },
            { 47, new Point(14, 254) },
            { 46, new Point(16, 284) },
            { 45, new Point(22, 314) },
            { 44, new Point(34, 340) },
            { 43, new Point(50, 360) },
            { 42, new Point(72, 374) },
            { 41, new Point(96, 380) },

            { 31, new Point(118, 380) },
            { 32, new Point(142, 374) },
            { 33, new Point(164, 360) },
            { 34, new Point(180, 340) },
            { 35, new Point(192, 314) },
            { 36, new Point(198, 284) },
            { 37, new Point(200, 254) },
            { 38, new Point(200, 224) }
        };

        public frmOdontograma()
        {
            InitializeComponent();
            HabilitarDobleBufer(pnlBoca);
        }

        private void HabilitarDobleBufer(Control control)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void frmOdontograma_Load(object sender, EventArgs e)
        {
            ConfigurarSelectorTipo();
            InicializarDatosDientes();

            if (PacienteID > 0)
            {
                CargarOdontograma("Inicial");
            }
        }

        private void ConfigurarSelectorTipo()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new object[] { "Inicial", "Evolucion", "Tratamiento" });
            cmbTipo.SelectedIndex = 0;
        }

        private void InicializarDatosDientes()
        {
            _dientesData.Clear();
            foreach (var num in _posiciones.Keys)
            {
                _dientesData[num] = new OdontogramaDiente
                {
                    NumeroDiente = num,
                    CodigoEstado = "sincarie",
                    Categoria = "Sano",
                    Observacion = string.Empty
                };
            }
            SeleccionarDiente(11);
        }

        // ==========================================
        // RENDERIZADO SUAVE DE LA BOCA Y DIENTES
        // ==========================================

        private void pnlBoca_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 1. Dibujar el fondo anatómico limpio de la boca (boca.png o odonto.jpg)
            var fondo = OdontogramaResourceService.ObtenerFondoBoca();
            if (fondo != null)
            {
                g.DrawImage(fondo, 0, 0, pnlBoca.Width, pnlBoca.Height);
            }

            // 2. Dibujar las 32 piezas dentales
            foreach (var kvp in _posiciones)
            {
                int num = kvp.Key;
                Point pos = kvp.Value;

                // Anillo de selección si es la pieza activa
                if (num == _selectedToothNumber)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(90, 255, 193, 7)))
                    {
                        g.FillEllipse(brush, pos.X - 3, pos.Y - 3, 31, 31);
                    }
                    using (var pen = new Pen(Color.FromArgb(255, 160, 0), 2.5f))
                    {
                        g.DrawEllipse(pen, pos.X - 3, pos.Y - 3, 31, 31);
                    }
                }
                else if (num == _hoveredToothNumber)
                {
                    using (var pen = new Pen(Color.FromArgb(0, 120, 215), 2f))
                    {
                        g.DrawEllipse(pen, pos.X - 2, pos.Y - 2, 29, 29);
                    }
                }

                // Obtener imagen con transparencia circular
                string codigo = _dientesData.ContainsKey(num) ? _dientesData[num].CodigoEstado : "sincarie";
                var img = OdontogramaResourceService.ObtenerImagen(codigo);
                if (img != null)
                {
                    g.DrawImage(img, pos.X, pos.Y, 25, 25);
                }
            }
        }

        private void pnlBoca_MouseMove(object sender, MouseEventArgs e)
        {
            int hovered = ObtenerDienteEnCoordenada(e.Location);
            if (hovered != _hoveredToothNumber)
            {
                _hoveredToothNumber = hovered;
                if (hovered > 0)
                {
                    pnlBoca.Cursor = Cursors.Hand;
                    string estado = _dientesData.ContainsKey(hovered) ? _dientesData[hovered].Categoria : "Sano";
                    toolTipDiente.SetToolTip(pnlBoca, $"Pieza #{hovered}: {ObtenerNombreAnatomico(hovered)} [{estado}]");
                }
                else
                {
                    pnlBoca.Cursor = Cursors.Default;
                    toolTipDiente.SetToolTip(pnlBoca, null);
                }
                pnlBoca.Invalidate();
            }
        }

        private void pnlBoca_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredToothNumber != 0)
            {
                _hoveredToothNumber = 0;
                pnlBoca.Cursor = Cursors.Default;
                toolTipDiente.SetToolTip(pnlBoca, null);
                pnlBoca.Invalidate();
            }
        }

        private void pnlBoca_MouseDown(object sender, MouseEventArgs e)
        {
            int clicked = ObtenerDienteEnCoordenada(e.Location);
            if (clicked > 0)
            {
                SeleccionarDiente(clicked);
            }
        }

        private void pnlBoca_DoubleClick(object sender, EventArgs e)
        {
            if (_selectedToothNumber > 0)
            {
                AbrirSelectorEsquema();
            }
        }

        private int ObtenerDienteEnCoordenada(Point pt)
        {
            foreach (var kvp in _posiciones)
            {
                int cx = kvp.Value.X + 12;
                int cy = kvp.Value.Y + 12;
                int dx = pt.X - cx;
                int dy = pt.Y - cy;
                if (dx * dx + dy * dy <= 14 * 14)
                {
                    return kvp.Key;
                }
            }
            return 0;
        }

        // ==========================================
        // GESTIÓN DEL DIENTE SELECCIONADO
        // ==========================================

        private void SeleccionarDiente(int num)
        {
            _selectedToothNumber = num;

            if (_dientesData.ContainsKey(num))
            {
                var data = _dientesData[num];
                lblPiezaSeleccionada.Text = $"Pieza #{num} - {ObtenerNombreAnatomico(num)}";
                lblEstadoActual.Text = $"Estado: {data.Categoria} ({data.CodigoEstado})";
                txtObservacionDiente.Text = data.Observacion ?? string.Empty;
                picPreviewDiente.Image = OdontogramaResourceService.ObtenerImagen(data.CodigoEstado);
            }

            pnlBoca.Invalidate();
        }

        private void btnAbrirEsquema_Click(object sender, EventArgs e)
        {
            AbrirSelectorEsquema();
        }

        private void AbrirSelectorEsquema()
        {
            string estadoActual = _dientesData.ContainsKey(_selectedToothNumber)
                ? _dientesData[_selectedToothNumber].CodigoEstado
                : "sincarie";

            using (var dlg = new frmEsquemaDental(estadoActual))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AsignarEstadoADiente(_selectedToothNumber, dlg.SelectedCodigoEstado, dlg.SelectedCategoria, dlg.SelectedDescripcion);
                }
            }
        }

        private void AsignarEstadoADiente(int num, string codigoEstado, string categoria, string desc)
        {
            if (!_dientesData.ContainsKey(num)) return;

            var data = _dientesData[num];
            data.CodigoEstado = codigoEstado;
            data.Categoria = categoria;

            lblEstadoActual.Text = $"Estado: {desc}";
            picPreviewDiente.Image = OdontogramaResourceService.ObtenerImagen(codigoEstado);

            pnlBoca.Invalidate();
        }

        private void btnMarcarSano_Click(object sender, EventArgs e)
        {
            AsignarEstadoADiente(_selectedToothNumber, "sincarie", "Sano", "Diente Sano");
        }

        private void btnMarcarAusente_Click(object sender, EventArgs e)
        {
            AsignarEstadoADiente(_selectedToothNumber, "ausente", "Ausente", "Diente Ausente");
        }

        private void txtObservacionDiente_TextChanged(object sender, EventArgs e)
        {
            if (_dientesData.ContainsKey(_selectedToothNumber))
            {
                _dientesData[_selectedToothNumber].Observacion = txtObservacionDiente.Text;
            }
        }

        // ==========================================
        // CARGA Y PERSISTENCIA
        // ==========================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0)
            {
                MessageBox.Show("No hay un ID de paciente válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var odonto = new Models.Odontograma
                {
                    Id = _currentOdontoId,
                    PacienteID = this.PacienteID,
                    Fecha = dtpFecha.Value,
                    Tipo = cmbTipo.SelectedItem?.ToString() ?? "Inicial",
                    Observaciones = txtObservacionesGenerales.Text.Trim()
                };

                var listaDientes = _dientesData.Values.ToList();
                _currentOdontoId = _repo.Guardar(odonto, listaDientes);

                MessageBox.Show("Odontograma guardado correctamente con sus 32 piezas dentales.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar odontograma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOdontograma(string tipo)
        {
            try
            {
                var odonto = _repo.ObtenerPorPacienteYTipo(PacienteID, tipo);
                if (odonto != null)
                {
                    _currentOdontoId = odonto.Id;
                    dtpFecha.Value = odonto.Fecha;
                    cmbTipo.SelectedItem = odonto.Tipo;
                    txtObservacionesGenerales.Text = odonto.Observaciones ?? string.Empty;

                    foreach (var d in odonto.Dientes)
                    {
                        if (_dientesData.ContainsKey(d.NumeroDiente))
                        {
                            _dientesData[d.NumeroDiente] = d;
                        }
                    }
                    SeleccionarDiente(_selectedToothNumber);
                }
                else
                {
                    _currentOdontoId = 0;
                    dtpFecha.Value = DateTime.Now;
                    txtObservacionesGenerales.Clear();
                    LimpiarDientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar odontograma: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarDientes()
        {
            foreach (var num in _dientesData.Keys.ToList())
            {
                _dientesData[num].CodigoEstado = "sincarie";
                _dientesData[num].Categoria = "Sano";
                _dientesData[num].Observacion = string.Empty;
            }
            SeleccionarDiente(_selectedToothNumber);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PacienteID > 0)
            {
                CargarOdontograma(cmbTipo.SelectedItem?.ToString() ?? "Inicial");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea restablecer todas las piezas a estado Sano?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarDientes();
            }
        }

        private string ObtenerNombreAnatomico(int num)
        {
            switch (num)
            {
                case 18: return "Tercer Molar Superior Derecho";
                case 17: return "Segundo Molar Superior Derecho";
                case 16: return "Primer Molar Superior Derecho";
                case 15: return "Segundo Premolar Superior Derecho";
                case 14: return "Primer Premolar Superior Derecho";
                case 13: return "Canino Superior Derecho";
                case 12: return "Incisivo Lateral Superior Derecho";
                case 11: return "Incisivo Central Superior Derecho";

                case 21: return "Incisivo Central Superior Izquierdo";
                case 22: return "Incisivo Lateral Superior Izquierdo";
                case 23: return "Canino Superior Izquierdo";
                case 24: return "Primer Premolar Superior Izquierdo";
                case 25: return "Segundo Premolar Superior Izquierdo";
                case 26: return "Primer Molar Superior Izquierdo";
                case 27: return "Segundo Molar Superior Izquierdo";
                case 28: return "Tercer Molar Superior Izquierdo";

                case 48: return "Tercer Molar Inferior Derecho";
                case 47: return "Segundo Molar Inferior Derecho";
                case 46: return "Primer Molar Inferior Derecho";
                case 45: return "Segundo Premolar Inferior Derecho";
                case 44: return "Primer Premolar Inferior Derecho";
                case 43: return "Canino Inferior Derecho";
                case 42: return "Incisivo Lateral Inferior Derecho";
                case 41: return "Incisivo Central Inferior Derecho";

                case 31: return "Incisivo Central Inferior Izquierdo";
                case 32: return "Incisivo Lateral Inferior Izquierdo";
                case 33: return "Canino Inferior Izquierdo";
                case 34: return "Primer Premolar Inferior Izquierdo";
                case 35: return "Segundo Premolar Inferior Izquierdo";
                case 36: return "Primer Molar Inferior Izquierdo";
                case 37: return "Segundo Molar Inferior Izquierdo";
                case 38: return "Tercer Molar Inferior Izquierdo";

                default: return $"Pieza Dental {num}";
            }
        }
    }
}
