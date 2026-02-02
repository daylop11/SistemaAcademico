using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }

        // Clave foránea a Estudiante
        [Required]
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        // Clave foránea a Curso
        [Required]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        // Fecha de matrícula
        [Required]
        public DateTime FechaMatricula { get; set; } = DateTime.Now;

        // Relación con calificaciones
        public ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
    }
}
