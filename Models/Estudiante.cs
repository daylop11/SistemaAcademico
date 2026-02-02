using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

        public ICollection<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
    }
}
