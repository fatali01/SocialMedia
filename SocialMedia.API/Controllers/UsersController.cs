using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models.Models.UsersModels;
using SocialMedia.Services.UsersServices;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _UsersServices;

        UsersController(IUsersServices usersServices)
        {
            _UsersServices = usersServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> PostUserAsync([FromBody]PostUser model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _UsersServices.PostUserAsync(model);
            
            if (registerResult)
            {
                string response = "User was registered";
                return Ok(response);
            }

            return BadRequest("User could not be registered");
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _UsersServices.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}