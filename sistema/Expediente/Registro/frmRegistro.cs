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

namespace sistema.Expediente.Registro
{
    public partial class frmRegistro : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        public int PacienteID { get; set; }
        public frmRegistro()
        {
            InitializeComponent();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDetalleRegistro frmDetalle = new frmDetalleRegistro();
            frmDetalle.PacienteID = this.PacienteID; // Asigna el ID del paciente actual
            frmDetalle.ShowDialog();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP(1)
                        ef.Peso,
                        ef.Altura,
                        ef.IMC,
                        ef.FechaRegistro,
                        p.FechaNacimiento,
                        p.FechaRegistro AS FechaRegistroPaciente
                    FROM Paciente p
                    OUTER APPLY (
                        SELECT TOP(1)
                            CAST(Peso   AS DECIMAL(9,2)) AS Peso,
                            CAST(Altura AS DECIMAL(9,2)) AS Altura,
                            CAST(IMC    AS DECIMAL(9,2)) AS IMC,
                            FechaRegistro
                        FROM ExploracionFisica
                        WHERE PacienteID = p.PacienteID
                        ORDER BY FechaRegistro DESC
                    ) ef
                    WHERE p.PacienteID = @PacienteID;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", this.PacienteID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int iPeso   = reader.GetOrdinal("Peso");
                            int iAltura = reader.GetOrdinal("Altura");
                            int iIMC    = reader.GetOrdinal("IMC");
                            int iFN     = reader.GetOrdinal("FechaNacimiento");
                            int iFRPac  = reader.GetOrdinal("FechaRegistroPaciente");

                            decimal peso   = reader.IsDBNull(iPeso)   ? 0m : reader.GetDecimal(iPeso);
                            decimal altura = reader.IsDBNull(iAltura) ? 0m : reader.GetDecimal(iAltura);
                            decimal imc    = reader.IsDBNull(iIMC)    ? 0m : reader.GetDecimal(iIMC);

                            // Si IMC no viene, intenta calcularlo con peso/altura
                            if (imc <= 0 && altura > 0 && peso > 0)
                                imc = Math.Round(peso / (decimal)Math.Pow((double)(altura / 100m), 2), 2);

                            // Solo actualiza cuando haya dato válido; si no, deja el label como estaba
                            if (peso > 0)
                                lbPeso.Text = $"{peso} kg.";

                            if (altura > 0)
                                lbAltura.Text = $"{Convert.ToInt32(altura)} cm";

                            if (imc > 0)
                                lbIMC.Text = $"{Math.Round(imc, 2)}";

                            // Edad desde FechaNacimiento 
                            if (!reader.IsDBNull(iFN))
                            {
                                DateTime fn = reader.GetDateTime(iFN).Date;
                                DateTime hoy = DateTime.Today;
                                int edad = hoy.Year - fn.Year;
                                if (new DateTime(hoy.Year, fn.Month, fn.Day) > hoy) edad--;
                                if (edad >= 0)
                                    lbEdad.Text = (edad == 1) ? "1 año" : $"{edad} años";
                            }

                            // Fecha de registro del paciente s
                            if (!reader.IsDBNull(iFRPac))
                            {
                                DateTime frp = reader.GetDateTime(iFRPac);
                                lbFechaRegistro.Text = frp.ToString("dd/MM/yyyy");
                            }
                        }
                        // Si no hay filas, no hacemos nada: los labels permanecen con su valor anterior
                    }
                }
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            // Abre el formulario para una nueva cita llamado AgendarCita
            if (this.PacienteID <= 0)
            {
                MessageBox.Show("No se ha especificado un paciente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT Nombre, FechaNacimiento, Genero, GrupoSanguineo FROM Paciente WHERE PacienteID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", this.PacienteID);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show($"Paciente con ID {this.PacienteID} no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var paciente = new sistema.PacientePreview
                        {
                            PacienteID = this.PacienteID,
                            Nombre = rd.IsDBNull(0) ? "" : rd.GetString(0),
                            Genero = rd.IsDBNull(2) ? null : rd.GetString(2),
                            GrupoSanguineo = rd.IsDBNull(3) ? null : rd.GetString(3)
                        };

                        if (!rd.IsDBNull(1))
                        {
                            DateTime fn = rd.GetDateTime(1).Date;
                            DateTime hoy = DateTime.Today;
                            int edad = hoy.Year - fn.Year;
                            if (new DateTime(hoy.Year, fn.Month, fn.Day) > hoy) edad--;
                            paciente.Edad = (edad >= 0) ? ((edad == 1) ? "1 año" : $"{edad} años") : "";
                        }

                        var frm = new sistema.AgendarCita();
                        frm.FechaSeleccionada = DateTime.Today; // puedes cambiar la fecha por defecto
                        frm.SetPaciente(paciente);
                        frm.SetFechaCita(frm.FechaSeleccionada);
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir AgendarCita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
