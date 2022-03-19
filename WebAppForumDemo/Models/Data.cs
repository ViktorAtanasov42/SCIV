//using Sciv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppForumDemo.Models
{
    public static class Data
    {
        public static List<Post> Posts { get; set; }
        public static List<Topic> Topics { get; set; }

        static Data()
        {
            Posts = new List<Post>();

			Topics = new List<Topic>
		    {
			//	new Topic ("Physics", "https://www.austincc.edu/sites/default/files/sem-physics.jpg"),
			//	new Topic ("Chemistry", "https://www.thoughtco.com/thmb/EpsKarnLz-v0VXY0KKnS_fTX5-U=/2121x1414/filters:fill(auto,1)/GettyImages-545286316-433dd345105e4c6ebe4cdd8d2317fdaa.jpg"),
			//	new Topic ("Biology", "https://cdn.pixabay.com/photo/2018/07/15/10/44/dna-3539309__480.jpg"),
			//	new Topic ("Mathematics", "https://upload.wikimedia.org/wikipedia/commons/8/89/Pure-mathematics-formul%C3%A6-blackboard.jpg"),
			//	new Topic ("Music", "https://musicforchangeorg.files.wordpress.com/2020/06/pexels-photo-210764.jpeg"),
			//	new Topic ("Art", "http://gergana.net/wp-content/uploads/2013/07/art.jpg")
			};
		}

    }
}
