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
        static private int CurrentTopicID;
        private readonly PostService postService;
        private readonly TopicService topicService;

        public PostController(PostService postService, TopicService topicService)
        {
            this.postService = postService;
            this.topicService = topicService;
        }

        [Route("Post")]
        public ActionResult Index()
        {
            CurrentTopicID = 0;
            List<Post> posts = postService.GetAll();

            ViewBag.TopicTitle = "";
            ViewBag.TopicImageLink = "";
            ViewBag.CurrentTopicID = 0;
            return View(posts);
        }


        [Route("Topic/{id:int}")]
        public ActionResult Index(int id)
        {
            CurrentTopicID = id;
            List<Post> posts = postService.GetAllByTopicId(id);

            Topic currentTopic = topicService.GetById(id);

            ViewBag.TopicTitle = currentTopic.Name;
            ViewBag.TopicImageLink = currentTopic.ImageLink;
            ViewBag.CurrentTopicID = CurrentTopicID;
            return View(posts);
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CurrentTopicID = CurrentTopicID;
            return View();
        }
         
        [HttpPost]
        public ActionResult Create(string title, string content)
        {
            postService.Create(CurrentTopicID, title, content);

            return RedirectToAction(nameof(Index), new { id = CurrentTopicID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(int id, string title, string content)
        {
            postService.Edit(id, title, content);

            return RedirectToAction(nameof(Index), new { id = CurrentTopicID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            postService.Delete(id);

            return RedirectToAction(nameof(Index), new { id = CurrentTopicID });
        }

    }
}
