using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sciv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForumDemo.Models;
using WebAppForumDemo.Services;

namespace WebAppForumDemo.Controllers
{
    public class TopicController : Controller
    {

        private readonly TopicService topicService;
		private readonly PostService postService;
		private readonly LogHistoryService logHistoryService;

		public TopicController(PostService postService, TopicService topicService, LogHistoryService logHistoryService)
        {
			this.topicService = topicService;
			this.postService = postService;
			this.logHistoryService = logHistoryService;
		}

		public ActionResult Index()
        {
			List<Topic> topics = topicService.GetAll();
			logHistoryService.Create("Topic", "Viewed All Topics", System.DateTime.Now);
			return View(topics);
        }
		[Authorize]
        public ActionResult TopicAdministration()
        {
			List<Topic> topics = topicService.GetAll();
			return View(topics);
        }

        [HttpGet]
		public ActionResult GetById(int id)
		{
			Topic topic = topicService.GetById(id);
			return View(topic);
		}

		//[Route("Topic/{id:int}")]
		//public ActionResult IndexPosts(int id)
		//{
		//	List<Post> posts = postService.GetAllByTopicId(id);

		//	Topic currentTopic = topicService.GetById(id);

		//	ViewBag.TopicTitle = currentTopic.Name;
		//	ViewBag.TopicImageLink = currentTopic.ImageLink;
		//	ViewBag.CurrentTopicID = id;
		//	logHistoryService.Create(currentTopic.Name,"Seen Topic", System.DateTime.Now);
		//	return View(posts);
		//}

		[HttpPost]
        public ActionResult Create(string name, string imagelink)
        {
            topicService.Create(name, imagelink);

            return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Topic topic = topicService.GetById(id);
			return View(topic);
		}

		[HttpPost]
		public ActionResult Edit(int id, string name, string imageLink)
		{
			topicService.Edit(id, name, imageLink);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Topic topic = topicService.GetById(id);
			return View(topic);
		}

		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			topicService.Delete(id);

			return RedirectToAction(nameof(Index));
		}

	}
}
