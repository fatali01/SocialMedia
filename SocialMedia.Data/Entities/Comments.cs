using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Comments
    {
        public int Id { get; set;}
        public string? CommentContent { get; set; }
        [ForeignKey(nameof(PostId))]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(PostId))]
        public int PostId { get; set; }
        public List<Replies> CommentReplyList = new List<Replies>();

    }
}