using System.Data.SqlClient;

namespace sistema.Infrastructure.Sql
{
    public static class SqlSessionContext
    {
        // Establece el usuario de la app para que los TRIGGERs lo registren
        public static void SetAppUser(SqlConnection conn, string usuarioApp)
        {
            using (var cmd = new SqlCommand("EXEC sp_set_session_context @key, @val;", conn))
            {
                cmd.Parameters.AddWithValue("@key", "AppUser");
                cmd.Parameters.AddWithValue("@val", (object)(usuarioApp ?? "desconocido"));
                cmd.ExecuteNonQuery();
            }
        }
    }
}