using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Replies
    {
        public int Id { get; set; }
        public string? ReplyContent { get; set; }
        [ForeignKey]
        public int ParentId { get; set; }
        [Required]
        public int AuthorId { get; set; }

    }
}