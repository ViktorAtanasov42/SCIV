using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public static class Data
    {
        public static List<Post> Posts { get; set; }

        static Data()
        {
            Posts = new List<Post>();
        }

    }
}
