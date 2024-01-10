using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Replies
    {
        public int Id { get; set; }
        public string? ReplyContent { get; set; }
        [ForeignKey(nameof(ParentId))]
        public int ParentId { get; set; }
   
        public int AuthorId { get; set; }
        public List<Replies>  = new List<Replies>();

    }
}