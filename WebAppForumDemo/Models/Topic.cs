using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public class Topic
    {
        private static int id = 0;
        public Topic(string name, string imageLink)
        {
            Id = ++id;
            Name = name;
            ImageLink = imageLink;           
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

    }
}
