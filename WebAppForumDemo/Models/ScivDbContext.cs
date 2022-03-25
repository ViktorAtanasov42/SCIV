using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppForumDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sciv.Models
{
    public class ScivDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<LogHistory> LogHistoryAll { get; set; }

        public ScivDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}