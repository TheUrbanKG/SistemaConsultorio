using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Models
{
    [Table("HistorialNotificaciones")]
    public class HistorialNotificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CitaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Canal { get; set; } // Email, SMS, WhatsApp, Telegram

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } // Pendiente, Enviado, Error

        public DateTime? FechaEnvio { get; set; }

        public string DetallesError { get; set; }

        // Navegación (opcional dependiendo de si se usa EF full)
        // [ForeignKey("CitaID")]
        // public virtual Cita Cita { get; set; }
    }
}
