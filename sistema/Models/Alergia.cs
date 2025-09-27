using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema.Models
{
    public class Alergia
    {
        public int Id { get; set; }                // Id (PK, IDENTITY)
        public int PacienteID { get; set; }        // FK a Paciente
        public string Nombre { get; set; }         // Nombre de la alergia
        public string EstadoClinico { get; set; }  // Estado clínico
        public string Tipo { get; set; }           // Tipo de alergia
        public string Severidad { get; set; }
    }
}
