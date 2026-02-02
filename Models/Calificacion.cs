using SistemaUniversitario.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Calificacion
    {
        [Key]
        public int CalificacionId { get; set; }

        [Required]
        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public Estudiante Estudiante { get; set; }

        [Required]
        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Nota { get; set; }
    }
}
