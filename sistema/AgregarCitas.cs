using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class AgregarCitas : Form
    {
        private PacientePreview paciente;

        public AgregarCitas()
        {
            InitializeComponent();
        }

        public AgregarCitas(PacientePreview pacientePreview)
        {
            InitializeComponent();
            paciente = pacientePreview;
            AgregarPacientePreview(pacientePreview);
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            lblFecha.ForeColor = Color.DarkSlateGray;

            var preview = new PacientePreview
            {
                Tipo = "Conocido",
                Nombre = "Prueba",
                Genero = "Masculino",
                GrupoSanguineo = "A+",
                Edad = "30"
            };
            AgregarPacientePreview(preview);

            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        public void AgregarPacientePreview(PacientePreview paciente)
        {
            // Crear panel para el paciente
            Panel panel = new Panel
            {
                Width = 300,
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Crear y agregar los labels
            Label lblTipo = new Label { Text = "Tipo: " + paciente.Tipo, Location = new Point(10, 10), AutoSize = true };
            Label lblNombre = new Label { Text = "Nombre: " + paciente.Nombre, Location = new Point(10, 30), AutoSize = true };
            Label lblGenero = new Label { Text = "Género: " + paciente.Genero, Location = new Point(150, 10), AutoSize = true };
            Label lblGrupoSanguineo = new Label { Text = "Sangre: " + paciente.GrupoSanguineo, Location = new Point(150, 30), AutoSize = true };
            Label lblEdad = new Label { Text = "Edad: " + paciente.Edad, Location = new Point(10, 50), AutoSize = true };

            panel.Controls.Add(lblTipo);
            panel.Controls.Add(lblNombre);
            panel.Controls.Add(lblGenero);
            panel.Controls.Add(lblGrupoSanguineo);
            panel.Controls.Add(lblEdad);

            // Agregar el panel al FlowLayoutPanel
            flpPacientes.Controls.Add(panel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - HH:mm:ss");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PacienteCita pacienteCita = new PacienteCita();
            pacienteCita.ShowDialog();
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            PacienteCita pacienteCita = new PacienteCita();
            if (pacienteCita.ShowDialog() == DialogResult.OK)
            {
                // Recibe el objeto PacientePreview desde PacienteCita
                AgregarPacientePreview(pacienteCita.PreviewPaciente);
            }
        }
    }
}
