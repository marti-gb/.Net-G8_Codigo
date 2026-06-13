using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity_EF.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(200)]
        [MaxLength(200)]
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
    }
}
