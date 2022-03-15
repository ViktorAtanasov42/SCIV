using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public class PostService : IPostService
    {
        public List<Post> GetAll()
        {
            return Data.Posts;
        }

        public Post GetById(int id)
        {
            return Data.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAllByTopicId(int topicId)
        {
            return Data.Posts.FindAll(p => p.TopicId == topicId);
        }

        public Post Create(int topicId, string title, string content)
        {
            Post post = new Post(topicId, title, content);

            Data.Posts.Add(post);            

            return post;
        }

        public Post Edit(int id, string title, string content)
        {
            Post post = GetById(id);
            post.Title = title;
            post.Content = content;

            return post;
        }

        public Post Delete(int id)
        {
            Post post = GetById(id);
            Data.Posts.Remove(post);

            return post;
        }
    }
}
