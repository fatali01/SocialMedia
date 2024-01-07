using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Models.Models.Users;

namespace SocialMedia.Services.Users
{
    public class UserServices : IUsersServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public UserServices(ApplicationDbContext context,
                            UserManager<Users> userManager,
                            SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> RegisterUserAsync(GetUserById model)
        {
            Users entity = new User()
            {
            Email = model.Email,
            UserName = model.UserName,
            DateCreated = DateTime.Now

            };
        }

        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }
}