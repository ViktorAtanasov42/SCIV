using WebAppForumDemo.Models;
using System.Collections.Generic;

namespace WebAppForumDemo.Services
{
    public interface ITopicService
    {
        Topic Create(string name, string imageLink);
        Topic Delete(int id);
        Topic Edit(int id, string name);
        List<Topic> GetAll();
        Topic GetById(int id);
        List<Post> GetAllPostsByTopicId(int id);
    }
}