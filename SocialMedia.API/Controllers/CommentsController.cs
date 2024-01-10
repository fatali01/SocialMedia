using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.GetComments;
using SocialMedia.Models.Models.PostComments;
using SocialMedia.Services.Comments;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsServices _commentsServices;
        public CommentsController(ICommentsServices commentsServices)
        {
            _commentsServices = commentsServices;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllCommentsByUserIdAsync(int authorId)
        {
            var comments = await _commentsServices.GetAllCommentsByUserIdAsync(authorId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> PostCommentsAsync([FromBody]PostComments commentPost)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _commentsServices.PostCommentsAsync(commentPost);
            if(response != null)
                return Ok(response);    
            else
                return BadRequest("An error occurred while posting the comment.");
        }
    }
}