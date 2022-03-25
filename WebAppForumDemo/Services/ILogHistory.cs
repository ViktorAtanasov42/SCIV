using System.Collections.Generic;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public interface ILogHistory
    {
        LogHistory Create(string Page, string Action, System.DateTime ActionDate);
        List<LogHistory> GetAll();
        List<LogHistory> GetAllByUserId(int userId);
    }
}
