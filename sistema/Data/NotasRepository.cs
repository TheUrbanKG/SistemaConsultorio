using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sistema.Models;

namespace sistema.Data
{
    /// <summary>
    /// Repositorio encargado de las operaciones CRUD sobre la tabla `Notas`.
    /// Proporciona métodos para crear, actualizar, eliminar y listar notas asociadas
    /// a usuarios y pacientes, además de una utilidad para listar pacientes para un combo.
    /// </summary>
    public class NotasRepository
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

        public int Crear(Nota n)
        {
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(@"
INSERT INTO dbo.Notas(Usuario, Tipo, Titulo, Contenido, PacienteID, PacienteNombre)
OUTPUT INSERTED.NotaID
VALUES (@Usuario, @Tipo, @Titulo, @Contenido, @PacienteID, @PacienteNombre);", cn))
            {
                // Inserta una nueva nota y devuelve la clave primaria generada (NotaID).
                // Se usan parámetros para evitar inyección SQL.
                cmd.Parameters.AddWithValue("@Usuario", n.Usuario);
                cmd.Parameters.AddWithValue("@Tipo", n.Tipo);
                cmd.Parameters.AddWithValue("@Titulo", n.Titulo);
                cmd.Parameters.AddWithValue("@Contenido", n.Contenido);
                cmd.Parameters.AddWithValue("@PacienteID", (object)n.PacienteID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PacienteNombre", (object)n.PacienteNombre ?? DBNull.Value);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Actualizar(Nota n)
        {
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(@"
UPDATE dbo.Notas
   SET Titulo=@Titulo, Contenido=@Contenido, Tipo=@Tipo,
       PacienteID=@PacienteID, PacienteNombre=@PacienteNombre,
       ActualizadoEn=SYSUTCDATETIME()
 WHERE NotaID=@NotaID AND Usuario=@Usuario;", cn))
            {
                // Actualiza una nota existente. El WHERE incluye Usuario para asegurar
                // que solo el propietario pueda modificar su nota.
                cmd.Parameters.AddWithValue("@NotaID", n.NotaID);
                cmd.Parameters.AddWithValue("@Usuario", n.Usuario);
                cmd.Parameters.AddWithValue("@Tipo", n.Tipo);
                cmd.Parameters.AddWithValue("@Titulo", n.Titulo);
                cmd.Parameters.AddWithValue("@Contenido", n.Contenido);
                cmd.Parameters.AddWithValue("@PacienteID", (object)n.PacienteID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PacienteNombre", (object)n.PacienteNombre ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int notaId, string usuario)
        {
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("DELETE FROM dbo.Notas WHERE NotaID=@Id AND Usuario=@Usuario;", cn))
            {
                // Elimina una nota por Id pero sólo si pertenece al usuario proporcionado.
                cmd.Parameters.AddWithValue("@Id", notaId);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Nota> Listar(string usuario, string tipo = null, string search = null, int? pacienteId = null)
        {
            var result = new List<Nota>();
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(@"
SELECT NotaID, Usuario, Tipo, Titulo, Contenido, PacienteID, PacienteNombre, CreadoEn, ActualizadoEn
  FROM dbo.Notas
 WHERE Usuario=@Usuario
   AND (@Tipo IS NULL OR Tipo=@Tipo)
   AND (@PacienteID IS NULL OR PacienteID=@PacienteID)
   AND (@Search IS NULL OR (Titulo LIKE @Search OR Contenido LIKE @Search))
 ORDER BY CreadoEn DESC;", cn))
            {
                // Lista las notas del usuario aplicando filtros opcionales: tipo, paciente y búsqueda libre.
                // Si un filtro es null se transforma a DBNull.Value para que la condición del WHERE lo ignore.
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Tipo", (object)tipo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PacienteID", (object)pacienteId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Search", search != null ? $"%{search}%" : (object)DBNull.Value);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        result.Add(new Nota
                        {
                            NotaID = rd.GetInt32(0),
                            Usuario = rd.GetString(1),
                            Tipo = rd.GetString(2),
                            Titulo = rd.GetString(3),
                            Contenido = rd.GetString(4),
                            PacienteID = rd.IsDBNull(5) ? (int?)null : rd.GetInt32(5),
                            PacienteNombre = rd.IsDBNull(6) ? null : rd.GetString(6),
                            CreadoEn = rd.GetDateTime(7),
                            ActualizadoEn = rd.GetDateTime(8),
                        });
                    }
                }
            }
            return result;
        }

        // Utilidad: lista compacta de pacientes para el combo
        public List<PacientePreview> ListarPacientes()
        {
            var items = new List<PacientePreview>();
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT PacienteID AS Id, Nombre FROM Paciente ORDER BY Nombre;", cn))
            {
                // Devuelve una lista ligera de pacientes (id y nombre) para poblar combos o selects.
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        items.Add(new PacientePreview
                        {
                            PacienteID = rd.GetInt32(0),
                            Nombre = rd.GetString(1),
                            Tipo = "Conocido" // opcional, reutilizando tu DTO
                        });
                    }
                }
            }
            return items;
        }
    }
}