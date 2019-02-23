using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBlogApplication.Services;
using WebBlogApplication.Models.PostBindnViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebBlogApplication.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            var models = _service.GetPosts();
            return View(models);
        }

        public IActionResult View(int id)
        {
            var model = _service.GetPost(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View(new CreatePostBindModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePostBindModel bindModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    int id = _service.CreatePost(bindModel);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "An Error occured saving the post");
            }

            return View(bindModel);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = _service.GetPostForUpdate(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(UpdatePostBindModel bindModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdatePost(bindModel);
                    return RedirectToAction(nameof(View), new { id = bindModel.Id });
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "An Error occured saving the post");
            }

            return View(bindModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }

    }
}