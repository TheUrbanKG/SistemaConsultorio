using System.Data.Entity;
using sistema.Models;

namespace sistema.Data
{
    public class DBContext : DbContext
    {
        // Constructor que usa la cadena de conexión del archivo de configuración
        public DBContext() : base("name=DBContext")
        {
        }

        // Un DbSet por cada entidad que quieres mapear a una tabla
        public DbSet<Paciente> Paciente { get; set; }

    }
}


