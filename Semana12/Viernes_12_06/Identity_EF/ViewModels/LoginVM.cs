using System.ComponentModel.DataAnnotations;

namespace Identity_EF.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
