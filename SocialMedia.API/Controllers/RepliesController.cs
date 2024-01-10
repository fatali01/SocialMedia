using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.PostReplies;
using SocialMedia.Services.Comments;
using SocialMedia.Services.RepliesServices;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepliesController : ControllerBase
    {
        private readonly IRepliesServices _userReply;

        public RepliesController(IRepliesServices repliesServices)
        {
            _userReply = repliesServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetReplyByAuthorIdAsync([FromRoute] int userReplyId)
        {
            var replies = await _userReply.GetReplyByAuthorIdAsync(userReplyId);
            return Ok(replies);
        }


        [HttpPost]
        public async Task<IActionResult> PostReply(PostReplies model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reply = await _userReply.PostReply(model);

            if (!reply)
            {
                return BadRequest("Failed to post reply"); 
            }

            return Ok("Reply posted successfully");
        }
    }
}