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

namespace sistema.Expediente
{
    public partial class frmCuadros : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }
        public frmCuadros()
        {
            InitializeComponent();
        }

        private void CargarCuadros(int pacienteId)
        {
            var cuadros = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT Id, PacienteID, Nombre, Impresiones, FechaInicio, FechaFin
                    FROM CuadroClinico
                    WHERE PacienteID = @PacienteID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PacienteID", pacienteId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cuadros.Add(new
                        {
                            Id = reader.GetInt32(0),
                            PacienteID = reader.GetInt32(1),
                            Nombre = reader["Nombre"]?.ToString(),
                            Impresiones = reader["Impresiones"]?.ToString(),
                            FechaInicio = reader["FechaInicio"] as DateTime?,
                            FechaFin = reader["FechaFin"] as DateTime?
                        });
                    }
                }
            }

            MostrarCuadros(cuadros);
        }

        private void MostrarCuadros(List<dynamic> cuadros)
        {
            flpCuadros.Controls.Clear();

            if (cuadros == null || cuadros.Count == 0)
            {
                lbCuadros.Visible = true;
                pbCuadros.Visible = true;
                flpCuadros.Visible = false;
                return;
            }

            lbCuadros.Visible = false;
            pbCuadros.Visible = false;
            flpCuadros.Visible = true;

            foreach (var cuadro in cuadros)
            {
                Panel panel = new Panel
                {
                    Width = flpCuadros.Width - 5,
                    Height = 110,
                    BackColor = Color.FromArgb(62, 62, 62),
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(0, 0, 0, 1)
                };

                // Línea superior verde
                Panel topLine = new Panel
                {
                    Height = 3,
                    Dock = DockStyle.Top,
                    BackColor = Color.FromArgb(100, 197, 121)
                };
                panel.Controls.Add(topLine);

                Label lblNombre = new Label
                {
                    Text = cuadro.Nombre?.ToUpper(),
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    ForeColor = Color.White
                };
                panel.Controls.Add(lblNombre);

                Label lblImpresiones = new Label
                {
                    Text = "Impresiones: " + cuadro.Impresiones,
                    ForeColor = Color.LightGray,
                    Location = new Point(10, 35),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Regular)
                };
                panel.Controls.Add(lblImpresiones);

                Label lblFechas = new Label
                {
                    Text = $"Inicio: {cuadro.FechaInicio:dd/MM/yyyy}  Fin: {cuadro.FechaFin:dd/MM/yyyy}",
                    ForeColor = Color.FromArgb(0, 220, 100),
                    Location = new Point(10, 60),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Italic)
                };
                panel.Controls.Add(lblFechas);

                // Panel para botones
                Panel panelBotones = new Panel
                {
                    Width = 220,
                    Height = 40,
                    Location = new Point(panel.Width - 230, 65),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };

                // Botón Modificar
                Button btnModificar = new Button
                {
                    Text = "Modificar",
                    BackColor = Color.FromArgb(255, 220, 37),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Height = 32,
                    Width = 100,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold),
                    Location = new Point(0, 0)
                };
                btnModificar.FlatAppearance.BorderColor = Color.FromArgb(255, 220, 37);
                btnModificar.FlatAppearance.BorderSize = 2;
                btnModificar.Click += (s, e) =>
                {
                    var frmDetalle = new sistema.Expediente.Cuadros.frmDetalleCuadros();
                    frmDetalle.PacienteID = cuadro.PacienteID;
                    frmDetalle.CuadroID = cuadro.Id;
                    frmDetalle.ShowDialog();
                    CargarCuadros(cuadro.PacienteID);
                };
                panelBotones.Controls.Add(btnModificar);

                // Botón Eliminar
                Button btnEliminar = new Button
                {
                    Text = "Eliminar",
                    BackColor = Color.FromArgb(255, 71, 87),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 32,
                    Width = 100,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold),
                    Location = new Point(110, 0)
                };
                btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(255, 71, 87);
                btnEliminar.FlatAppearance.BorderSize = 2;
                btnEliminar.Click += (s, e) =>
                {
                    var confirm = MessageBox.Show("¿Seguro que deseas eliminar este cuadro clínico?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM CuadroClinico WHERE Id = @Id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", cuadro.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarCuadros(cuadro.PacienteID);
                    }
                };
                panelBotones.Controls.Add(btnEliminar);

                panel.Controls.Add(panelBotones);

                // Sombra inferior (opcional)
                Panel bottomShadow = new Panel
                {
                    Height = 4,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.FromArgb(30, 30, 30)
                };
                panel.Controls.Add(bottomShadow);

                flpCuadros.Controls.Add(panel);
            }
        }

        private void btnNuevoCuadro_Click(object sender, EventArgs e)
        {
            var frmDetalle = new sistema.Expediente.Cuadros.frmDetalleCuadros();
            frmDetalle.PacienteID = this.PacienteID; 
            frmDetalle.ShowDialog();
            CargarCuadros(this.PacienteID);
        }

        private void frmCuadros_Load(object sender, EventArgs e)
        {
            if (this.PacienteID > 0)
                CargarCuadros(this.PacienteID);
        }
    }
}
