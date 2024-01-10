using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.GetComments;
using SocialMedia.Models.Models.PostComments;

namespace SocialMedia.Services.Comments.CommentServices
{
    public class CommentsServices : ICommentsServices
    {
        private readonly AppDbContext _dbContext;

        public CommentsServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetComments>> GetAllCommentsByUserIdAsync(int authorId)
        {
            var comments = await _dbContext.Comments
                .Where(c => c.AuthorId == authorId)
                .Select(c => new GetComments
                {
                    Id = c.Id,
                    CommentContent = c.CommentContent,
                    AuthorId = c.AuthorId,
                    CommentReplyList = c.CommentReplyList.ToList()
                })
                .ToListAsync();
            return comments;
        }
    public async Task<IEnumerable<PostComments>> PostCommentsAsync(PostComments commentRequest)
    {
        SocialMedia.Data.Entities.Comments comment = new SocialMedia.Data.Entities.Comments
        {
            CommentContent = commentRequest.CommentContent,
            AuthorId = commentRequest.AuthorId,
            CommentReplyList = commentRequest.CommentReplyList.ToList()
        };
        
        _dbContext.Comments.Add(comment);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if (numberOfChanges < 1)
            return null;
        
        return new List<PostComments>
        {
            new PostComments
            {
                Id = comment.Id, 
                CommentContent = comment.CommentContent,
                AuthorId = comment.AuthorId,
                CommentReplyList = comment.CommentReplyList.ToList()
            }
        };
    }
    }
}




