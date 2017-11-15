using System.ComponentModel.DataAnnotations;

namespace BookAndLearn.Web.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Логін")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
