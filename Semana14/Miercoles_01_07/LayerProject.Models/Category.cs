using System.ComponentModel.DataAnnotations;

namespace LayerProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Es obligatorio ingresar un nombre para la Categoria")]
        [Display(Name="Nombre de la Categoria")]
        public string Name { get; set; }

        [Display(Name = "Orden de visualizacion")]
        [Range(1,100, ErrorMessage ="El valor debe estar entre 1 y 100")]
        public int? Order { get; set; }
    }
}
