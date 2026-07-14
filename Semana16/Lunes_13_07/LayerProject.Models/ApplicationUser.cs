using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LayerProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string City { get; set; }

        [Required(ErrorMessage = "El pais es obligatorio")]
        public string Country { get; set; }
    }
}
