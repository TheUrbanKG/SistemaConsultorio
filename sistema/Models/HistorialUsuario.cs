using System;

namespace sistema.Models
{
    public class HistorialUsuario
    {
        public long Id { get; set; }                 // BIGINT
        public string Usuario { get; set; }
        public string Accion { get; set; }           // INSERT | UPDATE | DELETE
        public string Tabla { get; set; }
        public string RegistroId { get; set; }
        public DateTime Fecha { get; set; }          // UTC en BD
        public string Host { get; set; }
        public string App { get; set; }
        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
    }
}
