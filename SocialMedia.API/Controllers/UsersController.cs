using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Services.Users;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }
    }
}