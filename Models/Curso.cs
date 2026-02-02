using System.ComponentModel.DataAnnotations;

namespace SistemaUniversitario.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe indicar el número de créditos")]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10")]
        public int Creditos { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
