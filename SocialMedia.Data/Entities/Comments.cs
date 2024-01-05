using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Users Users { get; set; }
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Posts Posts { get; set; }
        public List<Replies> Replies { get; set; } = new List<Replies>();
    }
}