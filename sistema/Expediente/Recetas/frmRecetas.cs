using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema.Expediente.Recetas
{
    public partial class frmRecetas : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }

        public frmRecetas()
        {
            InitializeComponent();
            this.Load += frmRecetas_Load;
        }

        private void frmRecetas_Load(object sender, EventArgs e)
        {
            if (PacienteID <= 0)
            {
                MessageBox.Show("No se ha especificado un paciente válido");
                this.Close();
                return;
            }
            CargarRecetas(PacienteID);
        }


        private class PlanView
        {
            public int Id { get; set; }
            public int PacienteID { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string Cuadro { get; set; }
        }

        private void CargarRecetas(int pacienteId)
        {
            var planes = new List<PlanView>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
            SELECT p.Id, p.PacienteID, p.Titulo, p.Descripcion, p.FechaCreacion, c.Nombre as Cuadro
            FROM PlanTerapeutico p
            LEFT JOIN CuadroClinico c ON c.Id = p.CuadroClinicoId
            WHERE p.PacienteID = @PacienteID
            ORDER BY p.FechaCreacion DESC;", conn))
            {
                cmd.Parameters.AddWithValue("@PacienteID", pacienteId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        planes.Add(new PlanView
                        {
                            Id = r.GetInt32(0),
                            PacienteID = r.GetInt32(1),
                            Titulo = r["Titulo"]?.ToString(),
                            Descripcion = r["Descripcion"]?.ToString(),
                            FechaCreacion = r.GetDateTime(4),
                            Cuadro = r["Cuadro"]?.ToString()
                        });
                    }
                }
            }

            MostrarRecetas(planes);
        }

        private void MostrarRecetas(List<PlanView> planes)
        {
            flpRecetas.Controls.Clear();

            if (planes == null || planes.Count == 0)
            {
                lbRecetas.Visible = true;
                pbRecetas.Visible = true;
                flpRecetas.Visible = false;
                return;
            }

            lbRecetas.Visible = false;
            pbRecetas.Visible = false;
            flpRecetas.Visible = true;

            foreach (var p in planes)
            {
                var panel = new Panel
                {
                    Width = flpRecetas.Width - 1,
                    Height = 110,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(0, 0, 0, 8),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };

                // Línea superior verde esmeralda
                var topLine = new Panel
                {
                    Height = 3,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(0, 168, 89)
                };
                panel.Controls.Add(topLine);

                // Título en slate oscuro
                var lblTitulo = new Label
                {
                    Text = p.Titulo?.ToUpper(),
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Location = new Point(14, 14),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(30, 41, 59)
                };
                panel.Controls.Add(lblTitulo);

                // Descripción
                var lblDesc = new Label
                {
                    Text = p.Descripcion,
                    ForeColor = Color.FromArgb(71, 85, 105),
                    Location = new Point(14, 40),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Regular)
                };
                panel.Controls.Add(lblDesc);

                // Fecha (badge suave)
                var lblFecha = new Label
                {
                    Text = p.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                    ForeColor = Color.FromArgb(109, 40, 217),
                    Location = new Point(14, 70),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(243, 232, 255),
                    Padding = new Padding(8, 4, 8, 4)
                };
                panel.Controls.Add(lblFecha);

                // Panel de botones (solo Consultar)
                var panelBotones = new Panel
                {
                    Width = 120,
                    Height = 40,
                    Location = new Point(panel.Width - 130, 65),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };

                var btnConsultar = new Button
                {
                    Text = "Consultar",
                    BackColor = Color.FromArgb(37, 99, 235),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 32,
                    Width = 110,
                    Font = new Font("Century Gothic", 9.75F, FontStyle.Bold),
                    Location = new Point(0, 0),
                    Cursor = Cursors.Hand
                };
                btnConsultar.FlatAppearance.BorderSize = 0;
                btnConsultar.Click += (s, e) =>
                {
                    var frm = new frmDetalleRecetas();
                    frm.PacienteID = p.PacienteID;
                    frm.RecetaID = p.Id; // modo edición
                    frm.ShowDialog();
                    CargarRecetas(p.PacienteID);
                };
                panelBotones.Controls.Add(btnConsultar);

                panel.Controls.Add(panelBotones);

                flpRecetas.Controls.Add(panel);
            }
        }

        private void btnNuevaReceta_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevaReceta_Click_1(object sender, EventArgs e)
        {
            var frm = new frmDetalleRecetas();
            frm.PacienteID = this.PacienteID;
            frm.ShowDialog();
            CargarRecetas(this.PacienteID);
        }
    }
}
