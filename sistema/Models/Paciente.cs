using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteID { get; set; }

        [Required]
        [StringLength(15)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }

        [StringLength(50)]
        public string EstadoCivil { get; set; }

        [StringLength(100)]
        public string Ocupacion { get; set; }

        [StringLength(100)]
        public string Escolaridad { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(3)]
        public string GrupoSanguineo { get; set; }

        [StringLength(20)]
        public string TipoPaciente { get; set; } // Nuevo campo

        [StringLength(500)]
        public string Detalles { get; set; } // Nuevo campo

        // Si tienes FechaRegistro, agrégalo aquí
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int EdadActual
        {
            get
            {
                int edad = DateTime.Today.Year - FechaNacimiento.Year;
                if (FechaNacimiento > DateTime.Today.AddYears(-edad)) edad--;
                return edad;
            }
        }
    }

    [Table("Datos")]
    public class Datos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        public string CodigoPaciente { get; set; }

        [StringLength(10)]
        public string TipoSangre { get; set; }

        [StringLength(200)]
        public string Alergias { get; set; }

        [StringLength(200)]
        public string EnfermedadesCronicas { get; set; }

        [StringLength(200)]
        public string MedicamentosActuales { get; set; }

        [StringLength(200)]
        public string AntecedentesFamiliares { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? UltimaActualizacion { get; set; }

        public bool Activo { get; set; }
    }
}
