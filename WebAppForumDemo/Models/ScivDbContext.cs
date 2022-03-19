using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppForumDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;    


namespace Sciv.Models
{
    public class ScivDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public ScivDbContext(DbContextOptions options) : base(options)
        {

        }
        

    }
}