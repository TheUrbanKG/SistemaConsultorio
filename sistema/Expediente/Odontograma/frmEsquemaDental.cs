using System;
using System.Drawing;
using System.Windows.Forms;

namespace sistema.Expediente.Odontograma
{
    public partial class frmEsquemaDental : Form
    {
        public string SelectedCodigoEstado { get; private set; } = "sincarie";
        public string SelectedCategoria { get; private set; } = "Sano";
        public string SelectedDescripcion { get; private set; } = "Diente Sano";

        public frmEsquemaDental(string estadoActual = "sincarie")
        {
            InitializeComponent();
            ConfigurarCatalogo();
        }

        private void ConfigurarCatalogo()
        {
            // Panel Caries
            CargarBloque(pnlCaries, "carie", 15, "Caries");

            // Panel Curación con Caries (Mixtas)
            CargarBloque(pnlMixtas, "mez", 16, "Curación con Caries");

            // Panel Curaciones
            CargarBloque(pnlCuraciones, "curada", 15, "Curaciones");

            // Simbología
            ConfigurarBotonSimbologia(btnAusente, "ausente", "Ausente", "Diente Ausente / Pérdida");
            ConfigurarBotonSimbologia(btnExtraccion, "eindicada", "Extracción", "Extracción Indicada");
            ConfigurarBotonSimbologia(btnEndodoncia, "endindicada", "Endodoncia", "Endodoncia Indicada");
            ConfigurarBotonSimbologia(btnTratamiento, "tcrealizado", "Conducto", "Tratamiento de Conducto Realizado");

            // Prótesis y Otros
            ConfigurarBotonSimbologia(btnProtesisParcial, "ds3", "Prótesis", "Prótesis Parcial Removible");
            ConfigurarBotonSimbologia(btnCorona, "corona", "Corona", "Corona Protésica");
            ConfigurarBotonSimbologia(btnPuente, "pf", "Puente", "Puente Fijo");
            ConfigurarBotonSimbologia(btnSano, "sincarie", "Sano", "Diente Sano / Limpiar");
        }

        private void CargarBloque(FlowLayoutPanel panel, string prefijo, int cantidad, string categoria)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            for (int i = 1; i <= cantidad; i++)
            {
                string codigo = $"{prefijo}{i}";
                var btn = new Button
                {
                    Width = 32,
                    Height = 32,
                    Margin = new Padding(2),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = new Tuple<string, string, string>(codigo, categoria, $"{categoria} #{i}"),
                    Image = OdontogramaResourceService.ObtenerImagen(codigo)
                };

                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 240, 255);

                toolTip1.SetToolTip(btn, $"{categoria} (Variante {i})");
                btn.Click += EstadoButton_Click;
                panel.Controls.Add(btn);
            }

            panel.ResumeLayout();
        }

        private void ConfigurarBotonSimbologia(Button btn, string codigo, string categoria, string descripcion)
        {
            if (btn == null) return;
            btn.Image = OdontogramaResourceService.ObtenerImagen(codigo);
            btn.Tag = new Tuple<string, string, string>(codigo, categoria, descripcion);
            btn.Cursor = Cursors.Hand;
            toolTip1.SetToolTip(btn, descripcion);
            btn.Click += EstadoButton_Click;
        }

        private void EstadoButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Tuple<string, string, string> data)
            {
                SelectedCodigoEstado = data.Item1;
                SelectedCategoria = data.Item2;
                SelectedDescripcion = data.Item3;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
