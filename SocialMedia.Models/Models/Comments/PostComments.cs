using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Data.Entities;

namespace SocialMedia.Models.Models.PostComments
{
    public class PostComments
    {
        
        public int Id { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }

public List<SocialMedia.Data.Entities.Replies> CommentReplyList { get; set; } = new List<SocialMedia.Data.Entities.Replies>();
    }
}