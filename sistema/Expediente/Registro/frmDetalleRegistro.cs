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
using System.Configuration;

namespace sistema.Expediente.Registro
{
    public partial class frmDetalleRegistro : MetroFramework.Forms.MetroForm
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; } // Asegúrate de tener esta propiedad

        public frmDetalleRegistro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal peso, altura, imc = 0;

            // Validación de entrada
            if (!decimal.TryParse(txtPeso.Text, out peso) || peso <= 0)
            {
                MessageBox.Show("Por favor, ingresa un peso válido.");
                return;
            }
            if (!decimal.TryParse(txtAltura.Text, out altura) || altura <= 0)
            {
                MessageBox.Show("Por favor, ingresa una altura válida.");
                return;
            }

            // Calcular IMC
            imc = peso / (altura * altura);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE Paciente
                    SET Peso = @Peso, Altura = @Altura, IMC = @IMC
                    WHERE PacienteID = @PacienteID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Peso", peso);
                    cmd.Parameters.AddWithValue("@Altura", altura);
                    cmd.Parameters.AddWithValue("@IMC", imc);
                    cmd.Parameters.AddWithValue("@PacienteID", this.PacienteID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Datos guardados correctamente.");
            this.Close();
        }
    }
}
