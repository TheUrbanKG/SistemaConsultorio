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
                string query = @"SELECT Peso, Altura, IMC, FechaNacimiento FROM Paciente WHERE PacienteID = @PacienteID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", this.PacienteID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal peso = reader["Peso"] != DBNull.Value ? Convert.ToDecimal(reader["Peso"]) : 0;
                            decimal altura = reader["Altura"] != DBNull.Value ? Convert.ToDecimal(reader["Altura"]) : 0;
                            decimal imc = reader["IMC"] != DBNull.Value ? Convert.ToDecimal(reader["IMC"]) : 0;

                            lbPeso.Text = peso > 0 ? $"{peso} kg." : "";
                            lbAltura.Text = altura > 0 ? $"{Convert.ToInt32(altura)} cm" : "";
                            lbIMC.Text = imc > 0 ? $"{Math.Round(imc, 2)}" : "";

                            // Calcular edad
                            if (reader["FechaNacimiento"] != DBNull.Value)
                            {
                                DateTime fechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                                int edad = DateTime.Today.Year - fechaNacimiento.Year;
                                if (fechaNacimiento > DateTime.Today.AddYears(-edad)) edad--;
                                lbEdad.Text = edad == 1 ? "1 año" : $"{edad} años";;
                            }
                            else
                            {
                                lbEdad.Text = "0 año";
                            }
                        }
                        else
                        {
                            lbPeso.Text = "0 kg.";
                            lbAltura.Text = "0 cm";
                            lbIMC.Text = "0.00";
                            lbEdad.Text = "0";
                        }
                    }
                }
            }
        }
    }
}
