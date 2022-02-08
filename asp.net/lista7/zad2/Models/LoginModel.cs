using System.ComponentModel.DataAnnotations;

namespace zad2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Podaj email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło!")]
        public string Password { get; set; }
    }
}