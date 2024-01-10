using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Data.Entities
{
    public class Users : IdentityUser<int>
    {

        public int Id { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public string? FirstName { get; set;}
        public string? LastName { get; set;}




        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }

}