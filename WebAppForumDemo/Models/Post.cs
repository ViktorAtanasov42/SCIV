using System;
using Sciv.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public class Post
    {
        private string title;
        private string content;
        public Post(int topicId, string title, string content)
        {
            TopicId = topicId;
            Title = title;
            Content = content;
        }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        [ForeignKey("User")]
        public User Author { get; set; }

        public string AuthorName { get; set; }
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
