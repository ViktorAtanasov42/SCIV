using Sciv.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppForumDemo.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebAppForumDemo.Services
{
    public class LogHistoryService : ILogHistory
    {
        private ScivDbContext dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public LogHistoryService(ScivDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public LogHistory Create(string Page, string Action, DateTime ActionDate)
        {
             // First try to get the user ID
            int userId = -1;
            ClaimsPrincipal user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                Claim claim = user.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim != null ? int.Parse(claim.Value) : -1;
            }
            LogHistory log = new LogHistory(Page, userId, Action, ActionDate);
            dbContext.LogHistoryAll.Add(log);
            dbContext.SaveChanges();

            return log;
        }

        public List<LogHistory> GetAll()
        {
            return dbContext.LogHistoryAll.ToList();
        }

        public List<LogHistory> GetAllByUserId(int userId)
        {
            return dbContext.LogHistoryAll
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.ActionDate)
                .ToList();
        }
    }
}
