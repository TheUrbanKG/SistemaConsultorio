using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class AgregarCitas : MetroFramework.Forms.MetroForm
    {
        public DateTime FechaSeleccionada { get; set; }
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        private bool formLoaded = false;

        public AgregarCitas(DateTime fechaSeleccionada)
        {
            InitializeComponent();
            FechaSeleccionada = fechaSeleccionada;
            lblFecha.Text = "Cita para: " + fechaSeleccionada.ToString("dd/MM/yyyy");
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            if (formLoaded) return;
            formLoaded = true;

            lblFechaActual.ForeColor = Color.FromArgb(100, 116, 139);

            CargarPacientesDesdeBD();

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void CargarPacientesDesdeBD()
        {
            List<PacientePreview> pacientes = new List<PacientePreview>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            PacienteID,
                            Nombre, 
                            Apellido,
                            Genero, 
                            GrupoSanguineo,
                            TipoPaciente,
                            FechaNacimiento,
                            DATEDIFF(YEAR, FechaNacimiento, GETDATE()) - 
                            CASE 
                                WHEN DATEADD(YEAR, DATEDIFF(YEAR, FechaNacimiento, GETDATE()), FechaNacimiento) > GETDATE() 
                                THEN 1 
                                ELSE 0 
                            END AS Edad
                        FROM Paciente
                        ORDER BY Nombre, Apellido";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipoPaciente = reader["TipoPaciente"]?.ToString() ?? "Conocido";
                            string nombreCompleto;

                            if (tipoPaciente == "Desconocido")
                            {
                                nombreCompleto = reader["Nombre"]?.ToString() ?? "";
                            }
                            else
                            {
                                nombreCompleto = $"{reader["Nombre"]} {reader["Apellido"]}".Trim();
                            }

                            var preview = new PacientePreview
                            {
                                PacienteID = Convert.ToInt32(reader["PacienteID"]),
                                Tipo = tipoPaciente,
                                Nombre = nombreCompleto,
                                Genero = reader["Genero"]?.ToString() ?? "No especificado",
                                GrupoSanguineo = reader["GrupoSanguineo"]?.ToString() ?? "No especificado",
                                Edad = reader["Edad"]?.ToString() ?? "N/A"
                            };
                            pacientes.Add(preview);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar pacientes: " + ex.Message);
            }

            flpPacientes.SuspendLayout();
            flpPacientes.Controls.Clear();
            foreach (var p in pacientes)
            {
                AgregarPacientePreview(p);
            }
            flpPacientes.ResumeLayout();
        }

        public void AgregarPacientePreview(PacientePreview paciente)
        {
            bool esDesconocido = paciente.Tipo == "Desconocido";
            Color accentColor = esDesconocido ? Color.FromArgb(245, 158, 11) : Color.FromArgb(0, 168, 89);

            Panel card = new Panel
            {
                Width = 336,
                Height = 84,
                Margin = new Padding(3, 4, 3, 6),
                Tag = paciente,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            card.Paint += (s, pe) =>
            {
                using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    pe.Graphics.DrawRectangle(p, 0, 0, card.Width - 1, card.Height - 1);
                }
                using (SolidBrush b = new SolidBrush(accentColor))
                {
                    pe.Graphics.FillRectangle(b, 0, 0, 4, card.Height);
                }
            };

            // Nombre del paciente
            Label lblNombre = new Label
            {
                Text = paciente.Nombre,
                Location = new Point(14, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Insignia de tipo
            Label lblTipoBadge = new Label
            {
                Text = esDesconocido ? "DESCONOCIDO" : "CONOCIDO",
                Location = new Point(230, 10),
                Size = new Size(92, 18),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                BackColor = esDesconocido ? Color.FromArgb(254, 243, 199) : Color.FromArgb(220, 252, 231),
                ForeColor = esDesconocido ? Color.FromArgb(180, 83, 9) : Color.FromArgb(0, 140, 70),
                Cursor = Cursors.Hand
            };

            // Información secundaria: Género y Sangre
            Label lblDetalles = new Label
            {
                Text = $"Género: {paciente.Genero}   •   Sangre: {paciente.GrupoSanguineo}",
                Location = new Point(14, 35),
                AutoSize = true,
                ForeColor = Color.FromArgb(71, 85, 105),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };

            // Edad
            Label lblEdad = new Label
            {
                Text = $"Edad: {paciente.Edad} años",
                Location = new Point(14, 56),
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 116, 139),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };

            card.Controls.Add(lblNombre);
            card.Controls.Add(lblTipoBadge);
            card.Controls.Add(lblDetalles);
            card.Controls.Add(lblEdad);

            // Manejadores de Hover y Click unificados
            VincularEventosCard(card);

            flpPacientes.Controls.Add(card);
        }

        private void VincularEventosCard(Panel card)
        {
            Action onEnter = () => { card.BackColor = Color.FromArgb(248, 250, 252); };
            Action onLeave = () =>
            {
                Point pos = card.PointToClient(Cursor.Position);
                if (!card.ClientRectangle.Contains(pos))
                {
                    card.BackColor = Color.White;
                }
            };

            card.MouseEnter += (s, e) => onEnter();
            card.MouseLeave += (s, e) => onLeave();
            card.Click += PanelPaciente_Click;

            foreach (Control child in card.Controls)
            {
                child.MouseEnter += (s, e) => onEnter();
                child.MouseLeave += (s, e) => onLeave();
                child.Click += (s, e) => PanelPaciente_Click(card, e);
            }
        }

        private void PanelPaciente_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null && panel.Tag is PacientePreview pacienteSeleccionado)
            {
                if (Application.OpenForms.OfType<AgendarCita>().Any())
                {
                    Application.OpenForms.OfType<AgendarCita>().First().BringToFront();
                    return;
                }

                AgendarCita agendarCita = new AgendarCita();
                agendarCita.FechaSeleccionada = FechaSeleccionada;
                agendarCita.SetPaciente(pacienteSeleccionado);
                this.Hide();

                var resultado = agendarCita.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.Close(); // Cierra el selector para regresar al calendario y actualizarlo
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<PacienteCita>().Any())
            {
                Application.OpenForms.OfType<PacienteCita>().First().BringToFront();
                return;
            }

            PacienteCita pacienteCita = new PacienteCita();
            this.Hide();
            pacienteCita.ShowDialog();
            this.Show();
            CargarPacientesDesdeBD(); // Recargar pacientes por si se registró uno nuevo
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, panel1.Width - 1, panel1.Height - 1);
            }
        }
    }
}
