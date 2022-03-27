using Microsoft.AspNetCore.Mvc;
using Sciv.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAppForumDemo.Models;
using WebAppForumDemo.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Sciv.Controllers
{
    public class LogHistoryController : Controller
    {
        private readonly LogHistoryService logHistoryService;
        private readonly ScivDbContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogHistoryController (LogHistoryService logHistoryService, ScivDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.logHistoryService = logHistoryService;
            this.context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        public ActionResult Index()
        {
            List<LogHistory> logs = logHistoryService.GetAll();
            ClaimsPrincipal user = _httpContextAccessor.HttpContext?.User;
                Claim claim = user.FindFirst(ClaimTypes.NameIdentifier);
           int userId = int.Parse(claim.Value);
            return View(logs.Where(x => x.UserId == userId).OrderByDescending(x => x.ActionDate).ToList());         
        }
        
        [HttpPost]
        public ActionResult Create(string Page, string Action, DateTime ActionDate)
        {
            logHistoryService.Create(Page, Action, ActionDate);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}
