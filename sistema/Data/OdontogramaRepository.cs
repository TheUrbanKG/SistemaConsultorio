using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sistema.Models;

namespace sistema.Data
{
    public class OdontogramaRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        private static bool _tablasAseguradas = false;

        public void AsegurarTablas()
        {
            if (_tablasAseguradas) return;

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string script = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Odontograma')
                        BEGIN
                            CREATE TABLE Odontograma (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                PacienteID INT NOT NULL,
                                Fecha DATETIME NOT NULL DEFAULT GETDATE(),
                                Tipo VARCHAR(50) NOT NULL DEFAULT 'Inicial',
                                Observaciones NVARCHAR(MAX) NULL,
                                FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
                                FechaModificacion DATETIME NULL,
                                CONSTRAINT FK_Odontograma_Paciente FOREIGN KEY (PacienteID) 
                                    REFERENCES Paciente(PacienteID) ON DELETE CASCADE
                            );
                            CREATE INDEX IX_Odontograma_PacienteID ON Odontograma(PacienteID);
                        END;

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OdontogramaDiente')
                        BEGIN
                            CREATE TABLE OdontogramaDiente (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                OdontogramaId INT NOT NULL,
                                NumeroDiente INT NOT NULL,
                                CodigoEstado VARCHAR(50) NOT NULL DEFAULT 'sincarie',
                                Categoria VARCHAR(50) NOT NULL DEFAULT 'Sano',
                                Observacion NVARCHAR(250) NULL,
                                CONSTRAINT FK_OdontogramaDiente_Odontograma FOREIGN KEY (OdontogramaId) 
                                    REFERENCES Odontograma(Id) ON DELETE CASCADE,
                                CONSTRAINT UQ_Odontograma_Diente UNIQUE (OdontogramaId, NumeroDiente)
                            );
                            CREATE INDEX IX_OdontogramaDiente_OdontogramaId ON OdontogramaDiente(OdontogramaId);
                        END;";

                    using (var cmd = new SqlCommand(script, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                _tablasAseguradas = true;
            }
            catch
            {
                // Si la BD tiene restricciones, continúa con la ejecución normal
            }
        }

        public Odontograma ObtenerPorPacienteYTipo(int pacienteId, string tipo = "Inicial")
        {
            AsegurarTablas();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 Id, PacienteID, Fecha, Tipo, Observaciones, FechaCreacion, FechaModificacion
                    FROM Odontograma
                    WHERE PacienteID = @PacienteID AND Tipo = @Tipo
                    ORDER BY Fecha DESC, Id DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", pacienteId);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var odonto = new Odontograma
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PacienteID = Convert.ToInt32(reader["PacienteID"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Tipo = reader["Tipo"].ToString(),
                            Observaciones = reader["Observaciones"] == DBNull.Value ? string.Empty : reader["Observaciones"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModificacion"])
                        };

                        reader.Close();
                        odonto.Dientes = ObtenerDientes(odonto.Id, conn);
                        return odonto;
                    }
                }
            }
        }

        public Odontograma ObtenerPorId(int odontogramaId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT Id, PacienteID, Fecha, Tipo, Observaciones, FechaCreacion, FechaModificacion
                    FROM Odontograma
                    WHERE Id = @Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", odontogramaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var odonto = new Odontograma
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PacienteID = Convert.ToInt32(reader["PacienteID"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Tipo = reader["Tipo"].ToString(),
                            Observaciones = reader["Observaciones"] == DBNull.Value ? string.Empty : reader["Observaciones"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModificacion"])
                        };

                        reader.Close();
                        odonto.Dientes = ObtenerDientes(odonto.Id, conn);
                        return odonto;
                    }
                }
            }
        }

        public List<Odontograma> ListarPorPaciente(int pacienteId)
        {
            var list = new List<Odontograma>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT Id, PacienteID, Fecha, Tipo, Observaciones, FechaCreacion, FechaModificacion
                    FROM Odontograma
                    WHERE PacienteID = @PacienteID
                    ORDER BY Fecha DESC, Id DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacienteID", pacienteId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Odontograma
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                PacienteID = Convert.ToInt32(reader["PacienteID"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Tipo = reader["Tipo"].ToString(),
                                Observaciones = reader["Observaciones"] == DBNull.Value ? string.Empty : reader["Observaciones"].ToString(),
                                FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModificacion"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<OdontogramaDiente> ObtenerDientes(int odontogramaId, SqlConnection conn = null)
        {
            bool closeConn = false;
            if (conn == null)
            {
                conn = new SqlConnection(_connectionString);
                conn.Open();
                closeConn = true;
            }

            try
            {
                var dientes = new List<OdontogramaDiente>();
                string query = @"
                    SELECT Id, OdontogramaId, NumeroDiente, CodigoEstado, Categoria, Observacion
                    FROM OdontogramaDiente
                    WHERE OdontogramaId = @OdontogramaId
                    ORDER BY NumeroDiente ASC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OdontogramaId", odontogramaId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dientes.Add(new OdontogramaDiente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                OdontogramaId = Convert.ToInt32(reader["OdontogramaId"]),
                                NumeroDiente = Convert.ToInt32(reader["NumeroDiente"]),
                                CodigoEstado = reader["CodigoEstado"].ToString(),
                                Categoria = reader["Categoria"] == DBNull.Value ? "Sano" : reader["Categoria"].ToString(),
                                Observacion = reader["Observacion"] == DBNull.Value ? string.Empty : reader["Observacion"].ToString()
                            });
                        }
                    }
                }
                return dientes;
            }
            finally
            {
                if (closeConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int Guardar(Odontograma odonto, List<OdontogramaDiente> dientes)
        {
            AsegurarTablas();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (odonto.Id <= 0)
                        {
                            string insertOdontoQuery = @"
                                INSERT INTO Odontograma (PacienteID, Fecha, Tipo, Observaciones, FechaCreacion)
                                VALUES (@PacienteID, @Fecha, @Tipo, @Observaciones, GETDATE());
                                SELECT SCOPE_IDENTITY();";

                            using (var cmd = new SqlCommand(insertOdontoQuery, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@PacienteID", odonto.PacienteID);
                                cmd.Parameters.AddWithValue("@Fecha", odonto.Fecha);
                                cmd.Parameters.AddWithValue("@Tipo", odonto.Tipo ?? "Inicial");
                                cmd.Parameters.AddWithValue("@Observaciones", (object)odonto.Observaciones ?? DBNull.Value);

                                odonto.Id = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        else
                        {
                            string updateOdontoQuery = @"
                                UPDATE Odontograma 
                                SET Fecha = @Fecha,
                                    Tipo = @Tipo,
                                    Observaciones = @Observaciones,
                                    FechaModificacion = GETDATE()
                                WHERE Id = @Id";

                            using (var cmd = new SqlCommand(updateOdontoQuery, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@Id", odonto.Id);
                                cmd.Parameters.AddWithValue("@Fecha", odonto.Fecha);
                                cmd.Parameters.AddWithValue("@Tipo", odonto.Tipo ?? "Inicial");
                                cmd.Parameters.AddWithValue("@Observaciones", (object)odonto.Observaciones ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                            }

                            // Limpiar detalle anterior para re-insertar el estado actual
                            string deleteDientesQuery = "DELETE FROM OdontogramaDiente WHERE OdontogramaId = @OdontogramaId";
                            using (var cmd = new SqlCommand(deleteDientesQuery, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@OdontogramaId", odonto.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Insertar dientes
                        if (dientes != null && dientes.Count > 0)
                        {
                            string insertDienteQuery = @"
                                INSERT INTO OdontogramaDiente (OdontogramaId, NumeroDiente, CodigoEstado, Categoria, Observacion)
                                VALUES (@OdontogramaId, @NumeroDiente, @CodigoEstado, @Categoria, @Observacion)";

                            foreach (var d in dientes)
                            {
                                using (var cmd = new SqlCommand(insertDienteQuery, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@OdontogramaId", odonto.Id);
                                    cmd.Parameters.AddWithValue("@NumeroDiente", d.NumeroDiente);
                                    cmd.Parameters.AddWithValue("@CodigoEstado", d.CodigoEstado ?? "sincarie");
                                    cmd.Parameters.AddWithValue("@Categoria", (object)d.Categoria ?? "Sano");
                                    cmd.Parameters.AddWithValue("@Observacion", (object)d.Observacion ?? DBNull.Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();
                        return odonto.Id;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
