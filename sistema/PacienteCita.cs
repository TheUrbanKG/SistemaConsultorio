using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel; // Importa este namespace

namespace sistema
{
    public partial class PacienteCita : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public PacienteCita()
        {
            SuspendLayout(); // Suspender el diseño

            InitializeComponent();

            // Verificar si se está en tiempo de diseño
            if (!DesignMode)
            {
                AplicarTemaOscuro();
            }

            // Lógica para mostrar paneles según tipo de paciente
            rbConocido.CheckedChanged += (s, e) =>
            {
                panelConocido.Visible = rbConocido.Checked;
                panelDesconocido.Visible = !rbConocido.Checked;
            };
            rbDesconocido.CheckedChanged += (s, e) =>
            {
                panelConocido.Visible = !rbDesconocido.Checked;
                panelDesconocido.Visible = rbDesconocido.Checked;
            };

            // Por defecto, conocido
            rbConocido.Checked = true;

            // Ajustar ubicación y tamaño de los paneles
            panelConocido.Location = new Point(20, 140);
            panelConocido.Size = new Size(460, 500);
            panelDesconocido.Location = new Point(20, 140);
            panelDesconocido.Size = new Size(460, 350);

            cbGrupoSanguineo.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            cbGrupoSanguineoDes.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });

            ResumeLayout(false); // Reanudar el diseño
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar entradas
            if (panelConocido.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidoPa.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidoMa.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtEdadDes.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd;

                    if (panelConocido.Visible)
                    {
                        // Guardar paciente conocido
                        string sql = @"INSERT INTO Paciente
                            (Cedula, Nombre, Apellido, FechaNacimiento, Genero, Ocupacion, Telefono, Direccion, GrupoSanguineo, Detalles)
                            VALUES (@Cedula, @Nombre, @Apellido, @FechaNacimiento, @Genero, @Ocupacion, @Telefono, @Direccion, @GrupoSanguineo, @Detalles)";

                        cmd = new SqlCommand(sql, conexion);
                        cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", txtApellidoPa.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value);
                        cmd.Parameters.AddWithValue("@Genero", rbMasculino.Checked ? "Masculino" : "Femenino");
                        cmd.Parameters.AddWithValue("@Ocupacion", txtOcupacion.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@GrupoSanguineo", string.IsNullOrEmpty(cbGrupoSanguineo.Text) ? (object)DBNull.Value : cbGrupoSanguineo.Text);
                        cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrEmpty(txtDetalles.Text) ? (object)DBNull.Value : txtDetalles.Text);
                    }
                    else
                    {
                        // Guardar paciente desconocido
                        string sql = @"INSERT INTO Paciente
                            (Nombre, Genero, Ocupacion, Telefono, Direccion, GrupoSanguineo, Detalles)
                            VALUES (@Nombre, @Genero, @Ocupacion, @Telefono, @Direccion, @GrupoSanguineo, @Detalles)";

                        cmd = new SqlCommand(sql, conexion);
                        cmd.Parameters.AddWithValue("@Nombre", "Desconocido");
                        cmd.Parameters.AddWithValue("@Genero", rbMasculinoDes.Checked ? "Masculino" : "Femenino");
                        cmd.Parameters.AddWithValue("@Ocupacion", txtOcupacionDes.Text);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccionDes.Text);
                        cmd.Parameters.AddWithValue("@GrupoSanguineo", string.IsNullOrEmpty(cbGrupoSanguineoDes.Text) ? (object)DBNull.Value : cbGrupoSanguineoDes.Text);
                        cmd.Parameters.AddWithValue("@Detalles", string.IsNullOrEmpty(txtDetallesDes.Text) ? (object)DBNull.Value : txtDetallesDes.Text);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Paciente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Crear objeto PacientePreview
                PreviewPaciente = panelConocido.Visible ?
                    new PacientePreview
                    {
                        Tipo = "Conocido",
                        Nombre = txtNombre.Text,
                        Genero = rbMasculino.Checked ? "Masculino" : "Femenino",
                        GrupoSanguineo = cbGrupoSanguineo.Text,
                    }
                    : new PacientePreview
                    {
                        Tipo = "Desconocido",
                        Nombre = "Desconocido",
                        Genero = rbMasculinoDes.Checked ? "Masculino" : "Femenino",
                        GrupoSanguineo = cbGrupoSanguineoDes.Text,
                        Edad = txtEdadDes.Text
                    };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarTemaOscuro()
        {
            this.BackColor = Color.FromArgb(45, 48, 53);

            // Panel Header
            panelHeader.BackColor = Color.FromArgb(54, 57, 63);
            lblTitulo.ForeColor = Color.White;
            btnGuardar.BackColor = Color.FromArgb(0, 167, 110);
            btnGuardar.ForeColor = Color.White;

            // Panel Tipo
            panelTipo.BackColor = Color.FromArgb(54, 57, 63);
            lblTipo.ForeColor = Color.White;
            rbConocido.ForeColor = Color.White;
            rbDesconocido.ForeColor = Color.White;

            // Panel Conocido
            panelConocido.BackColor = Color.FromArgb(54, 57, 63);
            //lblCedula.ForeColor = Color.White;
            //lblNombre.ForeColor = Color.White;
            //lblApellidoPa.ForeColor = Color.White;
            //lblApellidoMa.ForeColor = Color.White;
            //lblFechaNacimiento.ForeColor = Color.White;
            //lblGenero.ForeColor = Color.White;
            //lblOcupacion.ForeColor = Color.White;
            //lblTelefono.ForeColor = Color.White;
            //lblDireccion.ForeColor = Color.White;
            //lblGrupoSanguineo.ForeColor = Color.White;
            //lblCorreoElectronico.ForeColor = Color.White;
            //lblDetalles.ForeColor = Color.White;

            // Panel Desconocido
            panelDesconocido.BackColor = Color.FromArgb(54, 57, 63);
            //lblEdadDes.ForeColor = Color.White;
            //lblGeneroDes.ForeColor = Color.White;
            //lblOcupacionDes.ForeColor = Color.White;
            //lblTelefonoCelularDes.ForeColor = Color.White;
            //lblDireccionDes.ForeColor = Color.White;
            //lblGrupoSanguineoDes.ForeColor = Color.White;
            //lblDetallesDes.ForeColor = Color.White;
        }

        public PacientePreview PreviewPaciente { get; set; }

        // Esta propiedad indica si el control está en modo de diseño
        private bool DesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    return true;
                }
                else
                {
                    return System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
                }
            }
        }
    }
}
