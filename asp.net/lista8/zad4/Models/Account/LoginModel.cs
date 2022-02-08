using System.ComponentModel.DataAnnotations;

namespace zad4.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage="Podaj nazwę użytkownika!")]
        public string Username { get; set; }
        
        [Required(ErrorMessage="Podaj hasło!")]
        public string Password { get; set; }
    }
}
