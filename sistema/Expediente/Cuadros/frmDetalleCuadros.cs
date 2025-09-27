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

namespace sistema.Expediente.Cuadros
{
    public partial class frmDetalleCuadros : MetroFramework.Forms.MetroForm
    {
        public frmDetalleCuadros()
        {
            InitializeComponent();
        }

        public int PacienteID { get; set; }
        public int? CuadroID { get; set; }
        private readonly string connectionString = "Server=DESKTOP-GR08655;Database=tesis;Trusted_Connection=True;";

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, completa el nombre.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (CuadroID.HasValue)
                {
                    // Actualizar registro existente
                    string updateQuery = @"
                UPDATE CuadroClinico
                SET Nombre = @Nombre, Impresiones = @Impresiones, FechaInicio = @FechaInicio, FechaFin = @FechaFin
                WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Impresiones", txtImpresiones.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaInicio", dtInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@FechaFin", dtFin.Value.Date);
                        cmd.Parameters.AddWithValue("@Id", CuadroID.Value);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cuadro clínico modificado correctamente.");
                }
                else
                {
                    // Insertar nuevo registro
                    string insertQuery = @"
                INSERT INTO CuadroClinico (PacienteID, Nombre, Impresiones, FechaInicio, FechaFin)
                VALUES (@PacienteID, @Nombre, @Impresiones, @FechaInicio, @FechaFin)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PacienteID", PacienteID);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Impresiones", txtImpresiones.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaInicio", dtInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@FechaFin", dtFin.Value.Date);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cuadro clínico guardado correctamente.");
                }
            }

            this.Close();
        }
    }
}
