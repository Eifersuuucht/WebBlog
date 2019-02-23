using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlogApplication.Data;

namespace WebBlogApplication.Models.PostBindnViewModels
{
    public class UpdatePostBindModel : EditPostBase
    {
        public int Id { get; set; }

        public void UpdatePost(Post post)
        {
            post.Picture = Picture;
            post.PostText = PostText;
            post.Title = Title;
        }
    }
}
