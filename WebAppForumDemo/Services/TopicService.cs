using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public class TopicService : ITopicService
    {
        public List<Topic> GetAll()
        {
            return Data.Topics;
        }

        public Topic GetById(int id)
        {
            return Data.Topics.FirstOrDefault(p => p.Id == id);
        }

        public Topic Create(string name, string imageLink)
        {
            Topic topic = new Topic(name, imageLink);

            Data.Topics.Add(topic);            

            return topic;
        }

        public Topic Edit(int id, string name)
        {
            Topic topic = GetById(id);
            topic.Name = name;

            return topic;
        }

        public Topic Delete(int id)
        {
            Topic topic = GetById(id);
            Data.Topics.Remove(topic);
            Data.Posts.RemoveAll(p => p.TopicId == id);
            return topic;
        }

        public List<Post> GetAllPostsByTopicId(int id)
		{
            return Data.Posts.FindAll(p => p.TopicId == id);
        }
    }
}
