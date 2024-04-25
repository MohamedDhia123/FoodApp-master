using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class LoginViewModel
    {
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
