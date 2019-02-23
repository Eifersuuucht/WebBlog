using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlogApplication.Models.PostBindnViewModels
{
    public class PostDetailedViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public string Picture { get; set; }
        public DateTime Date { get; set; }
    }
}
