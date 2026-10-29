using System;

namespace sistema.Models
{
    public class OdontogramaDiente
    {
        public int Id { get; set; }
        public int OdontogramaId { get; set; }
        public int NumeroDiente { get; set; } // FDI: 11-18, 21-28, 31-38, 41-48
        public string CodigoEstado { get; set; } = "sincarie"; // Ej: sincarie, carie1..15, curada1..15, mez1..16, corona, ausente, etc.
        public string Categoria { get; set; } = "Sano"; // Sano, Caries, Curacion, Mixto, Protesis, etc.
        public string Observacion { get; set; }
    }
}
