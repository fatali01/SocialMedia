using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Models.Models.PostReplies
{
    public class PostReplies
    {
        [Required,MaxLength(150)]
        public string Text { get; set; } = string.Empty;

        
    }
}