using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LayerProject.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del articulo es obligatorio")]
        [Display(Name="Nombre del Articulo")]
        public string Name { get; set; }

        [Required(ErrorMessage ="La descripcion del articulo es obligatoria")]
        public string Description { get; set; }

        [Display(Name = "Fecha de creacion")]
        public string? CreatedDate { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? UrlImage { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
