using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using SocialMedia.Models.Models.GetReplies;
using SocialMedia.Models.Models.PostReplies;

namespace SocialMedia.Services.RepliesServices
{
    public interface IRepliesServices
    {
        Task<GetReplies> GetReplyByAuthorIdAsync(int AuthorId);

        Task<bool> PostReply (PostReplies model);
        

    }
}