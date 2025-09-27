using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using sistema.Models;


namespace sistema.Expediente
{
    public partial class frmAlergias : Form
    {
        private readonly string connectionString = "Server=DESKTOP-GR08655;Database=tesis;Trusted_Connection=True;";
        public int PacienteID { get; set; }
        public frmAlergias()
        {
            InitializeComponent();
        }

        private void CargarAlergias(int pacienteId)
        {
            var alergias = new List<Alergia>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Id, PacienteID, Nombre, EstadoClinico, Tipo, Severidad
            FROM Alergia
            WHERE PacienteID = @PacienteID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PacienteID", pacienteId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        alergias.Add(new Alergia
                        {
                            Id = reader.GetInt32(0),
                            PacienteID = reader.GetInt32(1),
                            Nombre = reader["Nombre"]?.ToString(),
                            EstadoClinico = reader["EstadoClinico"]?.ToString(),
                            Tipo = reader["Tipo"]?.ToString(),
                            Severidad = reader["Severidad"]?.ToString()
                        });
                    }
                }
            }

            MostrarAlergias(alergias);
        }

        // Renombra tu método original a MostrarAlergias para separar la carga de la visualización:
        private void MostrarAlergias(List<Alergia> alergias)
        {
            flpAlergias.Controls.Clear();

            if (alergias == null || alergias.Count == 0)
            {
                lblSinAlergias.Visible = true;
                pbAlergias.Visible = true;
                flpAlergias.Visible = false;
                return;
            }

            lblSinAlergias.Visible = false;
            pbAlergias.Visible = false;
            flpAlergias.Visible = true;

            foreach (var alergia in alergias)
            {
                Panel panel = new Panel
                {
                    Width = flpAlergias.Width - 5,
                    Height = 110,
                    BackColor = Color.FromArgb(62, 62, 62),
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(0, 0, 0, 1) // Espacio entre paneles
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
                    Text = alergia.Nombre?.ToUpper(),
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    ForeColor = Color.White
                };
                panel.Controls.Add(lblNombre);

                Label lblEstado = new Label
                {
                    Text = "Estado clínico: " + alergia.EstadoClinico,
                    ForeColor = Color.FromArgb(0, 220, 100),
                    Location = new Point(10, 35),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 9, FontStyle.Regular)
                };
                panel.Controls.Add(lblEstado);

                // Botones más grandes y con más separación
                Button btnTipo = new Button
                {
                    Text = alergia.Tipo?.ToUpper(),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 180, 255),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(10, 65),
                    Height = 32,
                    Width = 120,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold)
                };
                btnTipo.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 255);
                btnTipo.FlatAppearance.BorderSize = 2;
                panel.Controls.Add(btnTipo);

                Button btnSeveridad = new Button
                {
                    Text = alergia.Severidad?.ToUpper(),
                    BackColor = Color.White,
                    ForeColor = alergia.Severidad?.ToUpper() == "MODERADA"
                        ? Color.FromArgb(255, 193, 7)
                        : Color.FromArgb(255, 71, 87),
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(140, 65),
                    Height = 32,
                    Width = 120,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold)
                };
                btnSeveridad.FlatAppearance.BorderColor = btnSeveridad.ForeColor;
                btnSeveridad.FlatAppearance.BorderSize = 2;
                panel.Controls.Add(btnSeveridad);

                Panel panelBotones = new Panel
                {
                    Width = 220, // Suficiente para ambos botones y separación
                    Height = 40,
                    Location = new Point(panel.Width - 230, 65), // Ajusta el valor según el ancho de tu panel
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
                    var frmDetalle = new sistema.Expediente.Alergias.frmDetalleAlergias();
                    frmDetalle.PacienteID = alergia.PacienteID;
                    frmDetalle.AlergiaID = alergia.Id; 
                    frmDetalle.ShowDialog();
                    CargarAlergias(alergia.PacienteID);
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
                    var confirm = MessageBox.Show("¿Seguro que deseas eliminar esta alergia?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM Alergia WHERE Id = @Id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", alergia.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        CargarAlergias(alergia.PacienteID);
                    }
                };
                panelBotones.Controls.Add(btnEliminar);

                // Agrega el panel de botones al panel principal
                panel.Controls.Add(panelBotones);

                // Sombra inferior (opcional)
                Panel bottomShadow = new Panel
                {
                    Height = 4,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.FromArgb(30, 30, 30)
                };
                panel.Controls.Add(bottomShadow);

                flpAlergias.Controls.Add(panel);
            }
        }


        private void frmAlergias_Load(object sender, EventArgs e)
        {
            if (this.PacienteID <= 0)
            {
                MessageBox.Show("No se ha especificado un paciente válido");
                this.Close();
                return;
            }

            CargarAlergias(PacienteID);

        }

        private void btnNuevaAlergia_Click(object sender, EventArgs e)
        {
            var frmDetalle = new sistema.Expediente.Alergias.frmDetalleAlergias();
            frmDetalle.PacienteID = this.PacienteID;
            frmDetalle.ShowDialog();
        }
    }
}
