using Sciv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public class Topic
    {
        private static int id;
        public Topic(string name, string imageLink)
        {
            Id = id;
            Name = name;
            ImageLink = imageLink;           
        }
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

    }
}
