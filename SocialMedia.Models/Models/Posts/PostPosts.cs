using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Data.Entities;

namespace SocialMedia.Models.Models.PostPosts
{
    public class PostPosts
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostContent { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public List<Comments> CommentList = new List<Comments>();
    }
}