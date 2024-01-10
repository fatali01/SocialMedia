using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.UsersModels;
using SocialMedia.Services.UsersServices;


namespace SocialMedia.Services.UsersServices
{
    public class UserServices : IUsersServices
    {

        readonly AppDbContext _Context = new AppDbContext();

        private readonly UserManager<Users> _userManager;


        public UserServices(AppDbContext context, UserManager<Users> userManager)
        {
            _Context = context;
            _userManager = userManager;
        }
        // async Task<GetUserById> GetUserByIdAsync(int id)
        // {
        //     var User = await _Context.Users.FindAsync(id);
        //     if(User is null)
        //         return null!;

        

        //     GetUserById getUser = new GetUserById()
        //     {
        //         Email = User.Email,
        //         FirstName = User.FirstName,
        //         LastName = User.LastName
        //     };
        //     if (User != null)
        //     {
        //         DisplayUsers(getUser);
        //         return getUser;
        //     }
        //     else
        //     {
        //         DisplayError($"{id} not found");
        //         return null!;
        //     }
        // }

        // async Task<bool> PostUserAsync(PostUser model)
        // {
        //     try
        //     {
        //         bool isEmailUnique = await CheckEmailAsync(model.Email);
        //         if (!isEmailUnique)
        //         {
        //             System.Console.WriteLine("Email is not uniqe");
        //             return false;
        //         }
        //         if (isEmailUnique)
        //         {
        //             Users user = new Users()
        //             {
        //                 Email = model.Email,
        //                 Password = model.Password,
        //                 FirstName = model.FirstName,
        //                 LastName = model.LastName
        //             };
        //             IdentityResult registerResult = await _userManager.CreateAsync(user, model.Password);
        //             return registerResult.Succeeded;
        //         }
        //         return false;
        //     }
        //     catch (Exception ex)
        //     {
        //         DisplayError(ex.Message);
        //         return false;
        //     }
        // }

        // Helper Methods
        void DisplayUsers(GetUserById user)
        {
            System.Console.WriteLine($"Email: {user.Email}\n + First Name: {user.FirstName}\n + Last Name: {user.LastName}");
        }

        void DisplayError(string v)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(v);
            Console.ResetColor();
        }

        private async Task<bool> CheckEmailAsync(string email)
        {
            return await _userManager.FindByNameAsync(email) == null;
        }

        async Task<GetUserById> IUsersServices.GetUserByIdAsync(int id)
        {
            var User = await _Context.Users.FindAsync(id);
            if(User is null)
                return null!;


            GetUserById getUser = new GetUserById()
            {
                Email = User.Email,
                FirstName = User.FirstName,
                LastName = User.LastName
            };
            if (User != null)
            {
                DisplayUsers(getUser);
                return getUser;
            }
            else
            {
                DisplayError($"{id} not found");
                return null!;
            }
        }

        async Task<bool> IUsersServices.PostUserAsync(PostUser model)
        {
            try
            {
                bool isEmailUnique = await CheckEmailAsync(model.Email);
                if (!isEmailUnique)
                {
                    System.Console.WriteLine("Email is not uniqe");
                    return false;
                }
                if (isEmailUnique)
                {
                    Users user = new Users()
                    {
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };
                    IdentityResult registerResult = await _userManager.CreateAsync(user, model.Password);
                    return registerResult.Succeeded;
                }
                return false;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                return false;
            }
        }
    }
}