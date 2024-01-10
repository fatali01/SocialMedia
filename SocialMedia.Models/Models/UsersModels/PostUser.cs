using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Models.Models.UsersModels
{
    public class PostUser
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8), MaxLength(30)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100), MinLength(1)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100), MinLength(1)]
        public string LastName { get; set; } = string.Empty;
    }
}