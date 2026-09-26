using sistema.Infrastructure.Security;
using sistema.Infrastructure.Sql;
using sistema.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sistema.Data
{
    public class ImagenPacienteRepository
    {
        private readonly string _connectionString;

        public ImagenPacienteRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        }

        /// <summary>
        /// Obtiene el listado histórico de imágenes de un paciente con filtros opcionales.
        /// NOTA: Se cargan únicamente las miniaturas (MiniaturaData) para un rendimiento óptimo de memoria.
        /// </summary>
        public List<ImagenPaciente> ObtenerPorPaciente(int pacienteId, string categoria = "Todas", DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var lista = new List<ImagenPaciente>();

            using (var conn = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT Id, PacienteID, Titulo, Categoria, Descripcion, FechaTomada, FechaRegistro, 
                           Formato, TamanoBytes, MiniaturaData, UsuarioID
                    FROM ImagenPaciente
                    WHERE PacienteID = @PacienteID";

                if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas" && categoria != "Todos")
                {
                    query += " AND Categoria = @Categoria";
                }

                if (fechaInicio.HasValue)
                {
                    query += " AND FechaTomada >= @FechaInicio";
                }

                if (fechaFin.HasValue)
                {
                    query += " AND FechaTomada <= @FechaFin";
                }

                query += " ORDER BY FechaTomada DESC, Id DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", pacienteId);

                    if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas" && categoria != "Todos")
                        cmd.Parameters.AddWithValue("@Categoria", categoria);

                    if (fechaInicio.HasValue)
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Value.Date);

                    if (fechaFin.HasValue)
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Value.Date.AddDays(1).AddSeconds(-1));

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ImagenPaciente
                            {
                                Id = reader.GetInt32(0),
                                PacienteID = reader.GetInt32(1),
                                Titulo = reader.GetString(2),
                                Categoria = reader.GetString(3),
                                Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4),
                                FechaTomada = reader.GetDateTime(5),
                                FechaRegistro = reader.GetDateTime(6),
                                Formato = reader.GetString(7),
                                TamanoBytes = reader.GetInt32(8),
                                MiniaturaData = reader.IsDBNull(9) ? null : (byte[])reader[9],
                                UsuarioID = reader.IsDBNull(10) ? (int?)null : reader.GetInt32(10)
                            });
                        }
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtiene una imagen completa (incluyendo los bytes de resolución original) por su Id.
        /// </summary>
        public ImagenPaciente ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT Id, PacienteID, Titulo, Categoria, Descripcion, FechaTomada, FechaRegistro, 
                           Formato, TamanoBytes, ImagenData, MiniaturaData, UsuarioID
                    FROM ImagenPaciente
                    WHERE Id = @Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ImagenPaciente
                            {
                                Id = reader.GetInt32(0),
                                PacienteID = reader.GetInt32(1),
                                Titulo = reader.GetString(2),
                                Categoria = reader.GetString(3),
                                Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4),
                                FechaTomada = reader.GetDateTime(5),
                                FechaRegistro = reader.GetDateTime(6),
                                Formato = reader.GetString(7),
                                TamanoBytes = reader.GetInt32(8),
                                ImagenData = reader.IsDBNull(9) ? null : (byte[])reader[9],
                                MiniaturaData = reader.IsDBNull(10) ? null : (byte[])reader[10],
                                UsuarioID = reader.IsDBNull(11) ? (int?)null : reader.GetInt32(11)
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Inserta una nueva imagen y su miniatura con auditoría de sesión.
        /// </summary>
        public int Insertar(ImagenPaciente img)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlSessionContext.SetAppUser(conn, Sesion.UsuarioActual);

                var query = @"
                    INSERT INTO ImagenPaciente (
                        PacienteID, Titulo, Categoria, Descripcion, FechaTomada, 
                        FechaRegistro, Formato, TamanoBytes, ImagenData, MiniaturaData, UsuarioID
                    )
                    VALUES (
                        @PacienteID, @Titulo, @Categoria, @Descripcion, @FechaTomada, 
                        GETDATE(), @Formato, @TamanoBytes, @ImagenData, @MiniaturaData, @UsuarioID
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", img.PacienteID);
                    cmd.Parameters.AddWithValue("@Titulo", img.Titulo ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Categoria", img.Categoria ?? "Otro");
                    cmd.Parameters.AddWithValue("@Descripcion", (object)img.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaTomada", img.FechaTomada);
                    cmd.Parameters.AddWithValue("@Formato", img.Formato ?? "JPG");
                    cmd.Parameters.AddWithValue("@TamanoBytes", img.TamanoBytes);
                    cmd.Parameters.Add("@ImagenData", SqlDbType.VarBinary, -1).Value = (object)img.ImagenData ?? DBNull.Value;
                    cmd.Parameters.Add("@MiniaturaData", SqlDbType.VarBinary, -1).Value = (object)img.MiniaturaData ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@UsuarioID", (object)img.UsuarioID ?? DBNull.Value);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Actualiza metadatos de una imagen existente (título, categoría, notas, fecha).
        /// </summary>
        public bool Actualizar(int id, string titulo, string categoria, string descripcion, DateTime fechaTomada)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlSessionContext.SetAppUser(conn, Sesion.UsuarioActual);

                var query = @"
                    UPDATE ImagenPaciente 
                    SET Titulo = @Titulo,
                        Categoria = @Categoria,
                        Descripcion = @Descripcion,
                        FechaTomada = @FechaTomada
                    WHERE Id = @Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Titulo", titulo ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Categoria", categoria ?? "Otro");
                    cmd.Parameters.AddWithValue("@Descripcion", (object)descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaTomada", fechaTomada);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Elimina un registro de imagen de la base de datos con auditoría de sesión.
        /// </summary>
        public bool Eliminar(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlSessionContext.SetAppUser(conn, Sesion.UsuarioActual);

                var query = "DELETE FROM ImagenPaciente WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
