using System.ComponentModel.DataAnnotations;

namespace SistemaUniversitario.Models
{
    public class Docente
    {
        [Key]
        public int DocenteId { get; set; }

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
