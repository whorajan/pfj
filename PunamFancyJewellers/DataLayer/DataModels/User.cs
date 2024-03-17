using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PunamFancyJewellers.DataLayer.DataModels
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}