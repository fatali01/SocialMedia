using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Models.Models.GetUsers
{
    public class GetUserById
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(4)]
        public string UserName { get; set; } = string.Empty;
        [Required, MinLength(4)]
        public string Password { get; set; } = string.Empty;
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}