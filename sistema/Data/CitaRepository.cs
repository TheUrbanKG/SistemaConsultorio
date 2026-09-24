using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sistema.Data
{
    public class CitaRepository
    {
        private readonly string _connectionString;

        public CitaRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        }

        public DataTable ObtenerCitasPorFecha(DateTime fecha, string filtroNombre, string statusFiltro)
        {
            DataTable dtCitas = new DataTable();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT c.CitaID, c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo, c.Status,
                           p.Nombre, p.Apellido, p.Telefono
                    FROM Cita c
                    INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
                    WHERE c.FechaCita = @FechaCita
                      AND (p.Nombre + ' ' + p.Apellido) LIKE @FiltroNombre
                      AND (@StatusFiltro = 'Todos' OR c.Status = @StatusFiltro)
                    ORDER BY c.HoraCita";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaCita", fecha);
                cmd.Parameters.AddWithValue("@FiltroNombre", string.IsNullOrWhiteSpace(filtroNombre) ? "%" : $"%{filtroNombre.Trim()}%");
                cmd.Parameters.AddWithValue("@StatusFiltro", string.IsNullOrWhiteSpace(statusFiltro) ? "Todos" : statusFiltro);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtCitas);
                }
            }
            return dtCitas;
        }

        public DataTable ObtenerCitasPorRango(DateTime fechaInicio, DateTime fechaFin, string filtroNombre, string statusFiltro)
        {
            DataTable dtCitas = new DataTable();
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT c.CitaID, c.PacienteID, c.FechaCita, c.HoraCita, c.Motivo, c.Periodo, c.Status,
                           p.Nombre, p.Apellido, p.Telefono
                    FROM Cita c
                    INNER JOIN Paciente p ON c.PacienteID = p.PacienteID
                    WHERE c.FechaCita BETWEEN @FechaInicio AND @FechaFin
                      AND (p.Nombre + ' ' + p.Apellido) LIKE @FiltroNombre
                      AND (@StatusFiltro = 'Todos' OR c.Status = @StatusFiltro)
                    ORDER BY c.FechaCita, c.HoraCita";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@FiltroNombre", string.IsNullOrWhiteSpace(filtroNombre) ? "%" : $"%{filtroNombre.Trim()}%");
                cmd.Parameters.AddWithValue("@StatusFiltro", string.IsNullOrWhiteSpace(statusFiltro) ? "Todos" : statusFiltro);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtCitas);
                }
            }
            return dtCitas;
        }

        public bool ActualizarEstado(int citaID, string nuevoStatus)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Cita SET Status = @Status WHERE CitaID = @CitaID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Status", nuevoStatus);
                cmd.Parameters.AddWithValue("@CitaID", citaID);

                conexion.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool EliminarCita(int citaID)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Cita WHERE CitaID = @CitaID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@CitaID", citaID);

                conexion.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
