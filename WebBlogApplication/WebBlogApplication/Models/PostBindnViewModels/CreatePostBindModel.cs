using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlogApplication.Data;

namespace WebBlogApplication.Models.PostBindnViewModels
{
    public class CreatePostBindModel : EditPostBase
    {
        public Post ToPost()
        {
            return new Post
            {
                Title = Title,
                Picture = Picture,
                PostText = PostText,
                Date = DateTime.Now
            };
        }
    }
}
