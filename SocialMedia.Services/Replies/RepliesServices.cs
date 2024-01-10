using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Data;
using SocialMedia.Models.Models.Replies;

namespace SocialMedia.Services.Replies.RepliesServices
{
    public class RepliesService : IRepliesService
    {
        private readonly AppDbContext _dbContext;
        private readonly int _userId;


        public async Task<IEnumerable<GetReplies>> GetAllRepliesByUserI()
        {
            var comments = await _dbContext.Comments
                .Include(c => c.ReplyList) // Ensure to include the replies in the query
                .Where(c => c.AuthorId == userId)
                .Select(c => new GetComments
                {
                    Id = c.Id,
                    Title = c.Title,
                    AuthorId = c.AuthorId,
                    Replies = c.Replies.ToList()
                })
                .ToListAsync();
            return comments;
        }



        public async Task<IEnumerable<GetComments>> GetCommentsByPostIdAsync(int postId)

        {
            var comment = await _dbContext.Comments
                .Include(c => c.ReplyList)
                .FirstOrDefaultAsync(c => c.Id == postId);

            if (comment == null)
                return null;

            return new GetComments
            {
                Id = comment.Id,
                Title = comment.Title,
                AuthorId = comment.AuthorId,
                ReplyList = comment.Replies.ToList()
            };

        }
    }
}