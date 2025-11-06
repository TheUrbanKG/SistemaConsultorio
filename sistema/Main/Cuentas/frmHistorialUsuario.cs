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

            dgvHistorial.DefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.DefaultCellStyle.BackColor = Color.FromArgb(54, 57, 63);
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 167, 110);
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(62, 62, 62);
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.EnableHeadersVisualStyles = false;

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
                h.App,
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
