using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
    {
        public class Docente
        {
            [Key]
            public int DocenteId { get; set; }

            [Required]
            public string Nombre { get; set; }

            // Relación inversa
            public ICollection<Curso> Cursos { get; set; }
        }
    }
