using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Sciv.Models;
using System.Collections.Generic;
using System.Linq;
using WebAppForumDemo.Models;
using WebAppForumDemo.Services;

namespace Sciv.Tests
{
    public class Tests
    {
        private ScivDbContext context;
        private PostService postService;
        private TopicService topicService;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ScivDbContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this.context = new ScivDbContext(options);
            postService = new PostService(this.context);
            topicService = new TopicService(this.context);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        // POSTS

        [Test]
        public void TestGetAllPosts()
        {
            Post post1 = postService.Create(1, "Title1", "Content1");
            Post post2 = postService.Create(2, "Title2", "Content2");
            Post post3 = postService.Create(3, "Title3", "Content3");

            List<Post> posts = postService.GetAll();

            Assert.AreEqual(3, posts.Count);
            Assert.AreEqual("Title3", posts[2].Title);
        }

        [Test]
        public void TestGetPostById()
        {
            Post post = postService.Create(1, "Title1", "Content1");

            Post dbPost = postService.GetById(1);

            Assert.AreEqual(dbPost.Content, "Content1");
        }

        [Test]
        public void TestGetAllPostsByTopicId()
        {
            Topic topic1 = topicService.Create("Tema1", "goo.img");

            Post post1 = postService.Create(1, "Title1", "Content1");
            Post post2 = postService.Create(1, "Title2", "Content2");
            Post post3 = postService.Create(1, "Title3", "Content3");

            List<Post> posts = postService.GetAllByTopicId(1);

            Assert.AreEqual(3, posts.Count);
            Assert.AreEqual("Title1", posts.Where(x => x.Id == 1).First().Title);
            Assert.AreEqual("Content3", posts.Where(x => x.Id == 3).First().Content);
        }

        [Test]
        public void TestCreatePost()
        {
            Post post = postService.Create(1, "Title1", "Content1");

            Post dbPost = context.Posts.FirstOrDefault();

            Assert.NotNull(dbPost);
        }

        [Test]
        public void TestEditPost()
        {
            Post post = postService.Create(1, "Title1", "Content1");

            postService.Edit(1, "Title0", "Content0");

            Assert.AreEqual("Content0", post.Content);
        }

        [Test]
        public void TestDeletePost()
        {
            Post post = postService.Create(1, "Title1", "Content1");

            postService.Delete(1);
            List<Post> posts = postService.GetAllByTopicId(1);

            Assert.IsEmpty(posts);
        }

        // TOPICS 

        [Test]
        public void TestGetAllTopics()
        {
            Topic topic1 = topicService.Create("Topic1", "Goo.img1");
            Topic topic2 = topicService.Create("Topic2", "Goo.img2");

            List<Topic> topics = topicService.GetAll();

            Assert.AreEqual(2, topics.Count);
            Assert.AreEqual("Goo.img2", topics.Where(x => x.Id == 2).First().ImageLink);
        }

        [Test]
        public void TestGetTopicById()
        {
            Topic topic1 = topicService.Create("Topic1", "Goo.img1");

            Topic dbTopic = topicService.GetById(1);

            Assert.AreEqual(topic1.Name, dbTopic.Name);
        }

        [Test]
        public void TestCreateTopic()
        {
            Topic topic = topicService.Create("Topic1", "Goo.img1");

            Topic dbTopic = context.Topics.FirstOrDefault();

            Assert.NotNull(dbTopic);
        }

        [Test]
        public void TestEditTopic()
        {
            Topic topic = topicService.Create("Topic1", "Goo.img1");

            topicService.Edit(1, "Topic0");

            Assert.AreEqual("Topic0", topic.Name);
        }

        [Test]
        public void TestDeleteTopic ()
        {
            Topic topic = topicService.Create("Topic1", "Goo.img1");

            topicService.Delete(1);
            List<Topic> topics = topicService.GetAll();

            Assert.IsEmpty(topics);
        }
    }
}