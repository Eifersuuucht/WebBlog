using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlogApplication.Data;
using WebBlogApplication.Models.PostBindnViewModels;

namespace WebBlogApplication.Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<PostConciseViewModel> GetPosts()
        {
            return _context.Posts.Where(post => !post.IsDeleted).Select(post => new PostConciseViewModel
            {
                Id = post.PostId,
                Title = post.Title,
                PostText = post.PostText
            }).ToList();
        }

        public PostDetailedViewModel GetPost(int id)
        {
            return _context.Posts.Where(post => post.PostId == id).Where(post => !post.IsDeleted).Select(post => new PostDetailedViewModel
            {
                Id = post.PostId,
                Title = post.Title,
                PostText = post.PostText,
                Date = post.Date,
                Picture = post.Picture
            }).SingleOrDefault();
        }

        public int CreatePost(CreatePostBindModel bindModel)
        {
            var post = bindModel.ToPost();
            _context.Add(post);
            _context.SaveChanges();
            return post.PostId;
        }

        public UpdatePostBindModel GetPostForUpdate(int postId)
        {
            return _context.Posts.Where(post => postId == post.PostId).Where(post => !post.IsDeleted).Select(post => new UpdatePostBindModel
            {
                Title = post.Title,
                PostText = post.PostText,
                Picture = post.Picture
            }).SingleOrDefault();
        }

        public void UpdatePost(UpdatePostBindModel bindModel)
        {
            var post = _context.Posts.Find(bindModel.Id);
            if (post == null)
            {
                throw new Exception("Unable to find the post");
            }
            if (post.IsDeleted)
            {
                throw new Exception("Unable to update a deleted post");
            }

            bindModel.UpdatePost(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post == null)
            {
                throw new Exception("Unable to find the post");
            }
            if (post.IsDeleted)
            {
                throw new Exception("Unable to update a deleted post");
            }

            post.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
