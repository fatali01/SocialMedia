using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Posts
    {
        public int Id { get; set;}
        public string? Title { get; set; }
        public string? PostContent { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public List<Comments> CommentList = new List<Comments>();

    }
}