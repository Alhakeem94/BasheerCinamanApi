using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.ViewModels.IdentityViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string UserPhoneNumber { get; set; }

    }
}
