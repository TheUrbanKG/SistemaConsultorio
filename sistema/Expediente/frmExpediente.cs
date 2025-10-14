using sistema.Expediente.ExploracionFisica;
using sistema.Expediente.Historia;
using sistema.Expediente.Recetas;
using sistema.Expediente.Registro;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sistema.Expediente
{
    public partial class frmExpediente : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        public int PacienteID { get; set; }

        public frmExpediente()
        {
            InitializeComponent();
        }

        public string NombreCompleto
        {
            get => lbNombre.Text;
            set => lbNombre.Text = value;
        }

        public string Cedula
        {
            get => lbCedulayGenero.Text;
            set => lbCedulayGenero.Text = value;
        }

        private void frmExpediente_Load(object sender, EventArgs e)
        {
            if (PacienteID > 0)
            {
                CargarCedulaYGenero(PacienteID);
            }
            var registro = new frmRegistro { PacienteID = this.PacienteID };
            abrirFormHijo(registro);
            this.Refresh();
        }

        private void CargarCedulaYGenero(int pacienteId)
        {
            string cedula = null;
            string genero = null;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT Cedula, Genero FROM Paciente WHERE PacienteID = @Id", conn))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pacienteId;
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            cedula = r["Cedula"]?.ToString();
                            genero = r["Genero"]?.ToString();
                        }
                    }
                }

                genero = NormalizarGenero(genero);
                if (string.IsNullOrWhiteSpace(cedula) && genero == "N/D")
                    lbCedulayGenero.Text = "Datos de identificación no disponibles.";
                else
                    lbCedulayGenero.Text = $"V - {cedula}. / Género: {genero}.";
            }
            catch
            {
                lbCedulayGenero.Text = "Error al cargar identificación.";
            }
        }

        private string NormalizarGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero)) return "N/D";
            switch (genero.Trim().ToUpperInvariant())
            {
                case "M":
                case "MASCULINO": return "Masculino";
                case "F":
                case "FEMENINO": return "Femenino";
                default: return "N/D"; // ya no aceptamos “Otro”
            }
        }

        private void abrirFormHijo(Form formHijo)
        {
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.None;
            formHijo.Width = panelContenedor.ClientSize.Width;
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.Show();

            panelContenedor.AutoScroll = true;
            panelContenedor.HorizontalScroll.Enabled = false;
            panelContenedor.HorizontalScroll.Visible = false;
            panelContenedor.HorizontalScroll.Maximum = 0;
            panelContenedor.PerformLayout();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            var registro = new frmRegistro { PacienteID = this.PacienteID };
            abrirFormHijo(registro);
            this.Refresh();
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var historia = new frmHistoria { PacienteID = this.PacienteID };
            abrirFormHijo(historia);
        }

        private void btnCuadros_Click(object sender, EventArgs e)
        {
            var cuadros = new frmCuadros { PacienteID = this.PacienteID };
            abrirFormHijo(cuadros);
            this.Refresh();
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var alergias = new frmAlergias { PacienteID = this.PacienteID };
            abrirFormHijo(alergias);
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var recetas = new frmRecetas { PacienteID = this.PacienteID };
            abrirFormHijo(recetas);
        }

        private void btnFisico_Click(object sender, EventArgs e)
        {
            if (PacienteID <= 0) { MessageBox.Show("No se ha recibido un ID de paciente válido"); return; }
            var fisica = new frmExploracionFisica { PacienteID = this.PacienteID };
            abrirFormHijo(fisica);
        }
    }
}
