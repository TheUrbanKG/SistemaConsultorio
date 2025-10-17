using System;

namespace sistema.Models
{
    public class Nota
    {
        public int NotaID { get; set; }
        public string Usuario { get; set; }           // autor
        public string Tipo { get; set; }              // "General" | "Medica"
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int? PacienteID { get; set; }
        public string PacienteNombre { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
    }
}