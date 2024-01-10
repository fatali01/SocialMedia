using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models.Models.GetComments;
using SocialMedia.Models.Models.PostComments;

namespace SocialMedia.Services.Comments
{
    public interface ICommentsServices 
    {
        Task<IEnumerable<PostComments>> PostCommentsAsync(PostComments commentRequest);

        Task<IEnumerable<GetComments>> GetAllCommentsByUserIdAsync(int authorId);


    }
}