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

namespace sistema.Expediente.Alergias
{
    public partial class frmDetalleAlergias : MetroFramework.Forms.MetroForm
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int PacienteID { get; set; }
        public int? AlergiaID { get; set; }
        public frmDetalleAlergias()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cbEstado.SelectedItem == null ||
                cbTipo.SelectedItem == null ||
                cbSeveridad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                sistema.Infrastructure.Sql.SqlSessionContext.SetAppUser(conn, sistema.Infrastructure.Security.Sesion.UsuarioActual);

                // Verificar paciente
                const string checkQuery = "SELECT COUNT(1) FROM Paciente WHERE PacienteID = @PacienteID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@PacienteID", PacienteID);
                    if ((int)checkCmd.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("El paciente no existe. No se puede guardar la alergia.");
                        return;
                    }
                }

                if (AlergiaID.HasValue)
                {
                    const string updateQuery = @"
UPDATE Alergia
SET Nombre = @Nombre,
    EstadoClinico = @EstadoClinico,
    Tipo = @Tipo,
    Severidad = @Severidad,
    FechaUltimaModificacion = @FechaUltimaModificacion
WHERE Id = @Id;";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@EstadoClinico", cbEstado.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Tipo", cbTipo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Severidad", cbSeveridad.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FechaUltimaModificacion", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Id", AlergiaID.Value);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Alergia modificada correctamente.");
                }
                else
                {
                    const string insertQuery = @"
INSERT INTO Alergia (PacienteID, Nombre, EstadoClinico, Tipo, Severidad, FechaUltimaModificacion)
VALUES (@PacienteID, @Nombre, @EstadoClinico, @Tipo, @Severidad, @FechaUltimaModificacion);";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PacienteID", PacienteID);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@EstadoClinico", cbEstado.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Tipo", cbTipo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Severidad", cbSeveridad.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FechaUltimaModificacion", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Alergia guardada correctamente.");
                }
            }

            this.Close();
        }

        private void frmDetalleAlergias_Load(object sender, EventArgs e)
        {
            if (AlergiaID.HasValue)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Nombre, EstadoClinico, Tipo, Severidad FROM Alergia WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", AlergiaID.Value);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["Nombre"].ToString();
                                cbEstado.SelectedItem = reader["EstadoClinico"].ToString();
                                cbTipo.SelectedItem = reader["Tipo"].ToString();
                                cbSeveridad.SelectedItem = reader["Severidad"].ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
