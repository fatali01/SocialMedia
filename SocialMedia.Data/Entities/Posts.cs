using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Entities
{
    public class Posts
    {



        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [ForeignKey]
        public int AuthorId { get; set; }
        [ForeignKey]
        public int PostId { get; set; }
        public List<Comments> Comments = new List<Comments>();

        public int MyProperty { get; set; }

    }
}