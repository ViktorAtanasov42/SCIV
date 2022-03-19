using Sciv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public class Post
    {

        private static int id = 0;
        private string title;
        private string content;        

        public Post(int topicId, string title, string content)
        {
            Id = ++id;
            TopicId = topicId;
            Title = title;
            Content = content;
        }
        public int Id { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
       // public User Author { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty");
                }
                title = value;
            } 
        }
        
        public string Content
        {
            get { return content; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Content cannot be null or empty");
                }
                content = value;
            }
        }

    }
}
