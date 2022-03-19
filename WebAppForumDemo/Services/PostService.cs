using Sciv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppForumDemo.Models;

namespace WebAppForumDemo.Services
{
    public class PostService : IPostService
    {
        private ScivDbContext dbContext;
        public PostService(ScivDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Post> GetAll()
        {
            //  return Data.Posts;
            return dbContext.Posts.ToList();
        }

        public Post GetById(int id)
        {
            // return Data.Posts.FirstOrDefault(p => p.Id == id);
            return dbContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAllByTopicId(int topicId)
        {
            return dbContext.Posts.Where(x => x.TopicId == topicId).ToList();
        }

        public Post Create(int topicId, string title, string content)
        {
            Post post = new Post(topicId, title, content);

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();        

            return post;
        }

        public Post Edit(int id, string title, string content)
        {
            Post post = GetById(id);
            post.Title = title;
            post.Content = content;
            dbContext.SaveChanges();
            return post;
        }

        public Post Delete(int id)
        {
            Post post = GetById(id);
            dbContext.Posts.Remove(post);
            dbContext.SaveChanges();

            return post;
        }
    }
}
