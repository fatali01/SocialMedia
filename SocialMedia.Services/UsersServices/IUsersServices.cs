using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Models.Models.UsersModels;

namespace SocialMedia.Services.UsersServices
{
    public interface IUsersServices
    {
        Task<GetUserById> GetUserByIdAsync(int id);
        Task<bool> PostUserAsync(PostUser model);
    }
}