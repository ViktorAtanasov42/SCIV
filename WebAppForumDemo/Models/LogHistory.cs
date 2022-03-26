using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppForumDemo.Services;

namespace WebAppForumDemo.Models
{
    public class LogHistory
    {
        public LogHistory(string page, int userId, string action, DateTime actionDate)
        {
            Page = page;
            UserId = userId;
            Action = action;
            ActionDate = actionDate;
        }

        public int Id { get; set; }
       
        public int UserId { get; set; }
        public string Page { get; set; }
#nullable enable
        public string? Action { get; set; }
#nullable disable
        [DataType(DataType.Date)]
        public System.DateTime ActionDate { get; set; }
    }
}
