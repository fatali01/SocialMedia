using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Models.Models.GetReplies
{
    public class GetReplies
    {
        public string Text { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}