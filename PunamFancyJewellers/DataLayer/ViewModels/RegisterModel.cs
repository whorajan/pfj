using System.ComponentModel.DataAnnotations;

namespace PunamFancyJewellers.DataLayer.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password must be between {1} and {0} characters long", MinimumLength = 5)]
        public string Password { get; set; }
    }
}