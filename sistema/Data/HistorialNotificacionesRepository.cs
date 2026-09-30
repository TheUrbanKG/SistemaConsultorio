using sistema.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sistema.Data
{
    public class HistorialNotificacionesRepository
    {
        private readonly string _connectionString;

        public HistorialNotificacionesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        }

        public bool RegistrarNotificacion(int citaID, string canal, string estado, string detallesError = null)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO HistorialNotificaciones (CitaID, Canal, Estado, FechaEnvio, DetallesError) 
                    VALUES (@CitaID, @Canal, @Estado, @FechaEnvio, @DetallesError)";
                
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@CitaID", citaID);
                cmd.Parameters.AddWithValue("@Canal", canal);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaEnvio", estado == "Enviado" ? (object)DateTime.Now : DBNull.Value);
                cmd.Parameters.AddWithValue("@DetallesError", string.IsNullOrWhiteSpace(detallesError) ? DBNull.Value : (object)detallesError);

                try
                {
                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool YaSeEnvioNotificacion(int citaID, string canal)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM HistorialNotificaciones WHERE CitaID = @CitaID AND Canal = @Canal AND Estado = 'Enviado'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@CitaID", citaID);
                cmd.Parameters.AddWithValue("@Canal", canal);

                try
                {
                    conexion.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
