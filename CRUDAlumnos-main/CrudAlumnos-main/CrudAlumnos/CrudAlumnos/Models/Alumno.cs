using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAlumnos.Models
{
    public class Alumno
    {
        [Key]
        public int CodAlumno { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La edad es requerida.")]
        [Range(1, 120, ErrorMessage = "Ingrese una edad válida.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El sexo es requerido.")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es requerida.")]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }

        [ForeignKey("CodCiudad")]
        public Ciudad? Ciudad { get; set; }
    }
}
