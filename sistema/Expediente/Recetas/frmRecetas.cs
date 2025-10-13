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
            btnNuevaReceta.Click += btnNuevaReceta_Click;
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

        private void btnNuevaReceta_Click(object sender, EventArgs e)
        {
            var frm = new frmDetalleRecetas();
            frm.PacienteID = this.PacienteID;
            frm.ShowDialog();
            CargarRecetas(this.PacienteID);
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
                // Opcional: mostrar un label "Sin recetas"
                var lbl = new Label
                {
                    Text = "No hay planes terapéuticos guardados.",
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Padding = new Padding(5)
                };
                flpRecetas.Controls.Add(lbl);
                return;
            }

            foreach (var p in planes)
            {
                var panel = new Panel
                {
                    Width = flpRecetas.Width - 1,
                    Height = 110,
                    BackColor = Color.FromArgb(62, 62, 62),
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(0, 0, 0, 0),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };

                // Línea superior verde
                var topLine = new Panel
                {
                    Height = 3,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(100, 197, 121)
                };
                panel.Controls.Add(topLine);

                // Título
                var lblTitulo = new Label
                {
                    Text = p.Titulo?.ToUpper(),
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    ForeColor = Color.White
                };
                panel.Controls.Add(lblTitulo);

                // Descripción (verde como en alergias)
                var lblDesc = new Label
                {
                    Text = p.Descripcion,
                    ForeColor = Color.FromArgb(0, 220, 100),
                    Location = new Point(10, 35),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Regular)
                };
                panel.Controls.Add(lblDesc);

                // Fecha (estilo badge morada)
                var lblFecha = new Label
                {
                    Text = p.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                    ForeColor = Color.MediumPurple,
                    Location = new Point(10, 65),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(45, 45, 45),
                    Padding = new Padding(6, 3, 6, 3)
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
                    BackColor = Color.FromArgb(0, 122, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 32,
                    Width = 110,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold),
                    Location = new Point(0, 0)
                };
                btnConsultar.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
                btnConsultar.FlatAppearance.BorderSize = 2;
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

                // Sombra inferior
                var bottomShadow = new Panel
                {
                    Height = 4,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.FromArgb(30, 30, 30)
                };
                panel.Controls.Add(bottomShadow);

                flpRecetas.Controls.Add(panel);
            }
        }
    }
}
