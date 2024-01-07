using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Users;

namespace SocialMedia.Services.Users
{
    public interface IUsersServices
    {
        Task<bool> RegisterUserAsync(UserRegister model)
        {
            Users entity = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                DateCreated = DateTime.Now
            };
        }
    }
}