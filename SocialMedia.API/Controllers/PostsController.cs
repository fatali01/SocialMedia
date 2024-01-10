using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.PostPosts;
using SocialMedia.Services.Posts;


namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsServices _postsServices;
        public PostsController(IPostsServices postsServices)
        {
            _postsServices = postsServices;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllPostsByUserIdAsync(int authorId)
        {
            var posts = await _postsServices.GetAllPostsByUserIdAsync(authorId);
            return Ok(posts);
        }
    
        [HttpPost]
        public async Task<IActionResult> PostPostsAsync(PostPosts postsRequest)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _postsServices.PostPostsAsync(postsRequest);
            if(response != null)
                return Ok("Post posted successfully");
            else
                return BadRequest("An error occurred while posting the post.");
        }
    }
}