using Sciv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public class TopicService : ITopicService
    {
        private ScivDbContext dbContext;
        public TopicService(ScivDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Topic> GetAll()
        {
            return dbContext.Topics.ToList(); 
        }

        public Topic GetById(int id)
        {
            return dbContext.Topics.FirstOrDefault(t => t.Id == id);
        }

        public Topic Create(string name, string imageLink)
        {
            Topic topic = new Topic(name, imageLink);

            dbContext.Topics.Add(topic);
            dbContext.SaveChanges();
            return topic;
        }

        public Topic Edit(int id, string name)
        {
            Topic topic = GetById(id);
            topic.Name = name;
            dbContext.SaveChanges();
            return topic;
        }

        public Topic Delete(int id)
        {
            Topic topic = GetById(id);
            dbContext.Topics.Remove(topic);
            dbContext.Posts.RemoveRange(GetAllPostsByTopicId(topic.Id));
            dbContext.SaveChanges();
            return topic;
        }

        public List<Post> GetAllPostsByTopicId(int id)
		{
           // return Data.Posts.FindAll(p => p.TopicId == id);
           return dbContext.Posts.Where(x => x.TopicId == id).ToList();
        }
    }
}
