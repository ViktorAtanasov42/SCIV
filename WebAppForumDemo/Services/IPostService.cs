using Sciv.Models;
using System.Collections.Generic;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public interface IPostService
    {
        Post Create(int topicId, string title, string content, User author);
        Post Delete(int id);
        Post Edit(int id, string title, string content);
        List<Post> GetAll();
        List<Post> GetAllByTopicId(int topicId);
        Post GetById(int id);
    }
}