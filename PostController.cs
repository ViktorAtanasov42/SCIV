using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForumDemo.Models;
using WebAppForumDemo.Services;

namespace WebAppForumDemo.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            List<Post> posts = postService.GetAll();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Create(string title, string content)
        {
            postService.Create(title, content);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(int id, string title, string content)
        {
            postService.Edit(id, title, content);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            postService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
