using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sistema.Data;

namespace sistema
{
    public partial class frmHistorialUsuario : Form
    {
        private readonly HistorialRepository _repo = new HistorialRepository();

        public frmHistorialUsuario()
        {
            InitializeComponent();

            this.Load += frmHistorialUsuario_Load;
            btnRefrescar.Click += (s, e) => Cargar();
            cboUsuario.SelectedIndexChanged += (s, e) => Cargar();
            cboAccion.SelectedIndexChanged += (s, e) => Cargar();
            dtpDesde.ValueChanged += (s, e) => Cargar();
            dtpHasta.ValueChanged += (s, e) => Cargar();
            dtpDesde.MouseUp += (s, e) => Cargar();
            dtpHasta.MouseUp += (s, e) => Cargar();
            dtpDesde.KeyUp += (s, e) => { if (e.KeyCode == Keys.Space) Cargar(); };
            dtpHasta.KeyUp += (s, e) => { if (e.KeyCode == Keys.Space) Cargar(); };
            txtBuscar.TextChanged += (s, e) => Cargar();
        }

        private void frmHistorialUsuario_Load(object sender, EventArgs e)
        {
            var usuarios = _repo.ListarUsuarios();
            usuarios.Insert(0, "Todos");
            cboUsuario.DataSource = usuarios;

            var acciones = _repo.ListarAcciones();
            acciones.Insert(0, "Todas");
            cboAccion.DataSource = acciones;

            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.GridColor = Color.FromArgb(226, 232, 240);
            dgvHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 168, 89);
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9.5f, FontStyle.Bold);
            dgvHistorial.ColumnHeadersHeight = 32;

            dgvHistorial.DefaultCellStyle.BackColor = Color.White;
            dgvHistorial.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvHistorial.DefaultCellStyle.Font = new Font("Century Gothic", 9f, FontStyle.Regular);
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            dgvHistorial.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 83, 45);

            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvHistorial.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvHistorial.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            dgvHistorial.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 83, 45);
            dgvHistorial.RowTemplate.Height = 30;

            Cargar();
        }

        private void Cargar()
        {
            string usuario = cboUsuario.SelectedItem != null && cboUsuario.SelectedItem.ToString() != "Todos"
                ? cboUsuario.SelectedItem.ToString()
                : null;

            string accion = cboAccion.SelectedItem != null && cboAccion.SelectedItem.ToString() != "Todas"
                ? cboAccion.SelectedItem.ToString()
                : null;

            DateTime? desde = dtpDesde.Checked ? (DateTime?)dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? (DateTime?)dtpHasta.Value.Date.AddDays(1) : null;

            string search = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();

            var data = _repo.Listar(usuario, accion, desde, hasta, search);

            dgvHistorial.DataSource = data.Select(h => new
            {
                h.Id,
                h.Usuario,
                h.Accion,
                h.Tabla,
                RegistroId = h.RegistroId,
                h.Host,
                Anterior = h.ValoresAnteriores,
                Nuevo = h.ValoresNuevos,
                Fecha = h.Fecha.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            if (dgvHistorial.Columns.Contains("Anterior"))
                dgvHistorial.Columns["Anterior"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dgvHistorial.Columns.Contains("Nuevo"))
                dgvHistorial.Columns["Nuevo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
