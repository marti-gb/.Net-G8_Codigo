using System.ComponentModel.DataAnnotations;

namespace LayerProject.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para el Slidr")]
        [Display(Name = "Nombre del Slider")]
        public string Name { get; set; }

        [Required]
        public bool State { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImage { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
