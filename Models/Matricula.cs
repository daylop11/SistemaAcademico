using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaUniversitario.Models
{
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [ForeignKey("EstudianteId")]
        public Estudiante Estudiante { get; set; }

        [Required]
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }

        [Required]
        public int PeriodoId { get; set; }

        public DateTime FechaMatricula { get; set; } = DateTime.Now;
    }
}
