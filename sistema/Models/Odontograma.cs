using System;
using System.Collections.Generic;

namespace sistema.Models
{
    public class Odontograma
    {
        public int Id { get; set; }
        public int PacienteID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = "Inicial"; // "Inicial", "Evolucion", "Tratamiento"
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        public List<OdontogramaDiente> Dientes { get; set; } = new List<OdontogramaDiente>();
    }
}
