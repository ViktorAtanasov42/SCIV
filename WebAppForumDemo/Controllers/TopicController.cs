using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public TopicController(TopicService topicService)
        {
			this.topicService = topicService;
        }
		public ActionResult Index()
        {
			List<Topic> topics = topicService.GetAll();
			return View(topics);
        }

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string imagelink)
        {
            topicService.Create(name, imagelink);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
		public ActionResult Edit(int id)
		{
			Topic topic = topicService.GetById(id);
			return View(topic);
		}

		[HttpPost]
		public ActionResult Edit(int id, string name)
		{
			topicService.Edit(id, name);

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
