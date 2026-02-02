using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Calificacion
    {
        [Key] // Esto es obligatorio
        public int CalificacionId { get; set; }

        [Required]
        [Range(0, 100)]
        public double Nota { get; set; }

        // Relaciones
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}

