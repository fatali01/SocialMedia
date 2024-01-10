using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Data;
using SocialMedia.Models.Models.GetPosts;
using SocialMedia.Models.Models.PostPosts;

namespace SocialMedia.Services.Posts
{
    public interface IPostsServices 
    {
        Task<IEnumerable<GetPosts>> GetAllPostsByUserIdAsync(int authorId);

        Task<IEnumerable<PostPosts>> PostPostsAsync(PostPosts postsRequest);


    }
}