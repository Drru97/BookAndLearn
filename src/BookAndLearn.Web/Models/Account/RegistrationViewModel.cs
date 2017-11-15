using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookAndLearn.Common.Entities;

namespace BookAndLearn.Web.Models.Account
{
    public class RegistrationViewModel
    {
        [Display(Name = "Логін")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Підтвердження пароля")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public FullNameModel FullName { get; set; }

        public int SelectedGroupId { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
