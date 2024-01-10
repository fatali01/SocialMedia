using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Models.GetPosts;
using SocialMedia.Models.Models.PostPosts;
using Microsoft.EntityFrameworkCore;


namespace SocialMedia.Services.Posts.PostsServices
{
    public class PostsServices
    {
    
        private readonly AppDbContext _dbContext;
        private readonly int _userId;


        public async Task<IEnumerable<GetPosts>> GetAllPostsByUserIdAsync(int authorId)
        {
            var posts = await _dbContext.Posts
                .Include(c => c.CommentList) // Ensure to include the replies in the query
                .Where(c => c.AuthorId == authorId)
                .Select(c => new GetPosts
                {
                    Id = c.Id,
                    Title = c.Title,
                    AuthorId = c.AuthorId,
                    PostContent = c.PostContent,
                    CommentList = c.CommentList.ToList()
                })
                .ToListAsync();
            return posts;
        }
public async Task<PostPosts?> PostPostsAsync(PostPosts postPosts)
{
SocialMedia.Data.Entities.Posts posts = new SocialMedia.Data.Entities.Posts
    {
        Title = postPosts.Title,
        PostContent = postPosts.PostContent,
        AuthorId = postPosts.AuthorId,
        CommentList = postPosts.CommentList 
    };
    
    _dbContext.Posts.Add(posts);
    var numberOfChanges = await _dbContext.SaveChangesAsync();
    if (numberOfChanges != 1)
        return null;
    
    return new PostPosts
    {
        Id = posts.Id,
        Title = posts.Title,
        PostContent = posts.PostContent,
        AuthorId = posts.AuthorId,
        CommentList = posts.CommentList
    };
}
    }
}