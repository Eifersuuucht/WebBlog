using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlogApplication.Models.PostBindnViewModels
{
    public class EditPostBase
    {
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string PostText { get; set; }
        [Required]
        public string Picture { get; set; }
    }
}
