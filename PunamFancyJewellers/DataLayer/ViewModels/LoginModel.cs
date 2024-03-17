using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunamFancyJewellers.DataLayer.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password must be between {1} and {0} characters long", MinimumLength = 5)]
        public string Password { get; set; }

        public bool? RememberMe { get; set; }
    }
}