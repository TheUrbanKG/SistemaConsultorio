using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema
{
    public class PacientePreview
    {
        public int PacienteID { get; set; } 
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Edad { get; set; }
    }
}
