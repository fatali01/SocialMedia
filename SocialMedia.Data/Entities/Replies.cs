using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Replies
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }= string.Empty;

        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Users Users { get; set; }

        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public Comments Comments { get; set; }
    }
}