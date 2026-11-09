using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class UserControlDias : UserControl
    {
        public DateTime Fecha { get; set; }
        public int CantidadCitas { get; private set; } = 0;
        public bool EsHoy { get; private set; } = false;
        public Action CitaAgendadaCallback { get; set; }

        private bool _isHovered = false;

        public UserControlDias()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint, true);

            // Vincula eventos de clic y hover a todos los controles internos
            VincularEventosHijos(this);

            // Dibujar el punto indicador como un círculo perfecto
            panelDot.Paint += PanelDot_Paint;
        }

        private void VincularEventosHijos(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += UserControlDias_Click;
                c.MouseEnter += SubControl_MouseEnter;
                c.MouseLeave += SubControl_MouseLeave;
                c.Cursor = Cursors.Hand;
            }
        }

        private void PanelDot_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 168, 89)))
            {
                e.Graphics.FillEllipse(brush, 0, 0, panelDot.Width - 1, panelDot.Height - 1);
            }
        }

        private void UserControlDias_Load(object sender, EventArgs e)
        {
            // Inicialización opcional
        }

        /// <summary>
        /// Configura el día y opcionalmente el conteo de citas.
        /// </summary>
        public void SetDia(DateTime fecha, int citasCount = 0)
        {
            this.Fecha = fecha;
            lblDias.Text = fecha.Day.ToString();

            EsHoy = (fecha.Date == DateTime.Today);

            if (EsHoy)
            {
                lblHoy.Visible = true;
                lblDias.ForeColor = Color.FromArgb(0, 168, 89);
                this.BackColor = Color.FromArgb(240, 253, 244); // Tinte verde suave
            }
            else
            {
                lblHoy.Visible = false;
                lblDias.ForeColor = Color.FromArgb(30, 41, 59);
                this.BackColor = Color.White;
            }

            SetCitasCount(citasCount);
            this.Invalidate();
        }

        /// <summary>
        /// Mantiene compatibilidad con llamadas existentes
        /// </summary>
        public void dias(int numDias)
        {
            lblDias.Text = numDias.ToString();
        }

        /// <summary>
        /// Actualiza el indicador visual y contador de citas para este día.
        /// </summary>
        public void SetCitasCount(int count)
        {
            this.CantidadCitas = count;

            if (count > 0)
            {
                panelDot.Visible = true;
                lblCitasInfo.Visible = true;
                lblCitasInfo.Text = count == 1 ? "● 1 cita" : $"● {count} citas";
                lblCitasInfo.ForeColor = Color.FromArgb(0, 140, 70);
            }
            else
            {
                panelDot.Visible = false;
                lblCitasInfo.Visible = false;
            }
        }

        private void SubControl_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void SubControl_MouseLeave(object sender, EventArgs e)
        {
            Point clientPos = this.PointToClient(Cursor.Position);
            if (!this.ClientRectangle.Contains(clientPos))
            {
                OnMouseLeave(e);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            if (!EsHoy)
            {
                this.BackColor = Color.FromArgb(248, 250, 252);
            }
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Point clientPos = this.PointToClient(Cursor.Position);
            if (!this.ClientRectangle.Contains(clientPos))
            {
                _isHovered = false;
                if (!EsHoy)
                {
                    this.BackColor = Color.White;
                }
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor;
            int penWidth;

            if (EsHoy)
            {
                borderColor = Color.FromArgb(0, 168, 89);
                penWidth = 2;
            }
            else if (_isHovered)
            {
                borderColor = Color.FromArgb(148, 163, 184);
                penWidth = 1;
            }
            else
            {
                borderColor = Color.FromArgb(226, 232, 240);
                penWidth = 1;
            }

            using (Pen pen = new Pen(borderColor, penWidth))
            {
                int offset = penWidth > 1 ? 1 : 0;
                e.Graphics.DrawRectangle(pen, offset, offset, this.Width - 1 - (offset * 2), this.Height - 1 - (offset * 2));
            }
        }

        private void UserControlDias_Click(object sender, EventArgs e)
        {
            // Verifica si ya hay una instancia abierta de AgregarCitas
            var existente = Application.OpenForms.OfType<AgregarCitas>().FirstOrDefault();
            if (existente != null)
            {
                existente.BringToFront();
                return;
            }

            // Crear nueva instancia pasando la fecha de esta casilla
            AgregarCitas agregarCitas = new AgregarCitas(this.Fecha);
            agregarCitas.FormClosed += (s, args) =>
            {
                // Al cerrar la ventana de citas, refrescar el calendario para actualizar los indicadores
                CitaAgendadaCallback?.Invoke();
            };
            agregarCitas.Show();
        }
    }
}
