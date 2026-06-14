using System.ComponentModel.DataAnnotations;

namespace CrudAlumnos.Models
{
    public class Ciudad
    {
        [Key]
        public int CodCiudad { get; set; }

        [Required(ErrorMessage = "El nombre de la ciudad es requerido.")]
        [StringLength(100)]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Alumno>? Alumnos { get; set; }
    }
}
