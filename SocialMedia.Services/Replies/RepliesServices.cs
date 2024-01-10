using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.GetPosts;
using SocialMedia.Models.Models.GetReplies;
using SocialMedia.Models.Models.PostReplies;

namespace SocialMedia.Services.RepliesServices
{
    public class RepliesServices : IRepliesServices 
    {
        private readonly AppDbContext _context;

        public RepliesServices(AppDbContext context)
        { _context = context; }

        void DisplayReply(GetReplies reply)
        {   
            System.Console.WriteLine($"{reply.Text} ");
        }

        async Task<GetReplies> IRepliesServices.GetReplyByAuthorIdAsync(int AuthorId)
        {
            var reply = await _context.Replies.FindAsync(AuthorId);
            if(reply == null)
                return null!;
            
            GetReplies getReplies = new GetReplies(){Text = reply.Text };
            if(reply != null)
            {
                DisplayReply(getReplies);
                return getReplies;
            }
            else
            {
                System.Console.WriteLine($"{AuthorId} not found");
                return null!;
            }
        }

        async Task<bool> IRepliesServices.PostReply(PostReplies model)
        {
            Replies reply = new Replies()
            {
                Text = model.Text
            };
            
            var result = await _context.Replies.AddAsync(reply);
            
            
            var numberOfChanges =  await _context.SaveChangesAsync();

            if(numberOfChanges == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}