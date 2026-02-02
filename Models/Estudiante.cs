using System.ComponentModel.DataAnnotations;

namespace SistemaUniversitario.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Correo { get; set; }

        [StringLength(15)]
        [Phone]
        public string Telefono { get; set; }
    }
}
