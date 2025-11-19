using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sistema.Models;

namespace sistema.Data
{
    public class HistorialRepository
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        // Ajustado a las columnas reales
        private const string BaseSelect = @"
SELECT 
    Id,
    Usuario,
    Accion,
    Fecha,
    Tabla,
    RegistroId,
    Host,
    ValoresAnteriores,
    ValoresNuevos
FROM dbo.HistorialUsuarios
WHERE 1=1
  AND (@Usuario IS NULL OR Usuario = @Usuario)
  AND (@Accion  IS NULL OR Accion  = @Accion)
  AND (@Desde   IS NULL OR Fecha  >= @Desde)
  AND (@Hasta   IS NULL OR Fecha  <  @Hasta)
  AND (@Search  IS NULL OR (
        Tabla LIKE @Search OR RegistroId LIKE @Search OR Usuario LIKE @Search OR Accion LIKE @Search OR
        Host LIKE @Search OR App LIKE @Search OR ValoresAnteriores LIKE @Search OR ValoresNuevos LIKE @Search
      ))
ORDER BY Fecha DESC;";

        public List<HistorialUsuario> Listar(string usuario = null, string accion = null, DateTime? desde = null, DateTime? hasta = null, string search = null)
        {
            var list = new List<HistorialUsuario>();
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(BaseSelect, cn))
            {
                cmd.Parameters.AddWithValue("@Usuario", (object)usuario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Accion", (object)accion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Desde", (object)desde ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Hasta", (object)hasta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Search", search != null ? $"%{search}%" : (object)DBNull.Value);

                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    int iId = rd.GetOrdinal("Id");
                    int iUsuario = rd.GetOrdinal("Usuario");
                    int iAccion = rd.GetOrdinal("Accion");
                    int iFecha = rd.GetOrdinal("Fecha");
                    int iTabla = rd.GetOrdinal("Tabla");
                    int iRegistroId = rd.GetOrdinal("RegistroId");
                    int iHost = rd.GetOrdinal("Host");
                    int iValAnt = rd.GetOrdinal("ValoresAnteriores");
                    int iValNue = rd.GetOrdinal("ValoresNuevos");

                    while (rd.Read())
                    {
                        list.Add(new HistorialUsuario
                        {
                            Id = rd.GetInt64(iId),
                            Usuario = rd.IsDBNull(iUsuario) ? null : rd.GetString(iUsuario),
                            Accion = rd.IsDBNull(iAccion) ? null : rd.GetString(iAccion),
                            Fecha = rd.GetDateTime(iFecha),
                            Tabla = rd.IsDBNull(iTabla) ? null : rd.GetString(iTabla),
                            RegistroId = rd.IsDBNull(iRegistroId) ? null : rd.GetString(iRegistroId),
                            Host = rd.IsDBNull(iHost) ? null : rd.GetString(iHost),
                            ValoresAnteriores = rd.IsDBNull(iValAnt) ? null : rd.GetString(iValAnt),
                            ValoresNuevos = rd.IsDBNull(iValNue) ? null : rd.GetString(iValNue),
                        });
                    }
                }
            }
            return list;
        }

        public List<string> ListarUsuarios()
        {
            var list = new List<string>();
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT DISTINCT Usuario FROM dbo.HistorialUsuarios ORDER BY Usuario;", cn))
            {
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read()) list.Add(rd.GetString(0));
            }
            return list;
        }

        public List<string> ListarAcciones()
        {
            var list = new List<string>();
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT DISTINCT Accion FROM dbo.HistorialUsuarios ORDER BY Accion;", cn))
            {
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read()) list.Add(rd.GetString(0));
            }
            return list;
        }
    }
}