using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sciv.Models;
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
        private static int CurrentTopicID;
        private readonly PostService postService;
        private readonly TopicService topicService;
        private readonly LogHistoryService logHistoryService;
        private readonly UserManager<User> userManager;

        public PostController(PostService postService, TopicService topicService, LogHistoryService logHistoryService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.logHistoryService = logHistoryService;
            this.userManager = userManager;
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
        public ActionResult IndexPosts(int id)
        {
            CurrentTopicID = id;
            List<Post> posts = postService.GetAllByTopicId(id);

        	Topic currentTopic = topicService.GetById(id);

        	ViewBag.TopicTitle = currentTopic.Name;
        	ViewBag.TopicImageLink = currentTopic.ImageLink;
        	ViewBag.CurrentTopicID = id;
        	logHistoryService.Create(currentTopic.Name,"Seen Topic", System.DateTime.Now);
        	return View(posts);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpGet]
        [Authorize]
        [Route("Post/Create/{id:int}")]
        public ActionResult Create(int id)
        {
            ViewBag.CurrentTopicID = id;
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(int topicID, string title, string content)
        //{
        //    postService.Create(topicID, title, content);

        //    return RedirectToAction("IndexPosts", "Topic", new { id = topicID });
        //}

        [HttpPost]
        public async Task<ActionResult> CreateAsync(string title, string content, User author)
        {
            
            author = await userManager.GetUserAsync(User);
            postService.Create(CurrentTopicID, title, content, author);

            return RedirectToAction(nameof(IndexPosts), new { id = CurrentTopicID });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> EditAsync(int id, string title, string content)
        {
            var currentUser = await userManager.GetUserAsync(User);
            Post post = postService.GetById(id);
            if (currentUser.Id == post.Author.Id)
            {
                post = postService.Edit(id, title, content);
            }
            return RedirectToAction(nameof(IndexPosts), new { id = post.TopicId });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Post post = postService.GetById(id);
            return View(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmAsync(int id)
        {
           var currentUser = await userManager.GetUserAsync(User);
            Post post = postService.GetById(id);
            if (currentUser.Id == post.Author.Id)
            {
                postService.Delete(id);
            }
            return RedirectToAction(nameof(IndexPosts), new { id = post.TopicId });

        }
    }
}
