using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Data.Entities;

namespace SocialMedia.Models.Models.GetPosts
{
    public class GetPosts
    {
        public string Text { get; set; }    

        public Comments Comments { get; set; }

    }
}