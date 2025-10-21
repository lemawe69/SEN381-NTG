using Microsoft.EntityFrameworkCore;
using CampusLearnNTG.Models;

namespace CampusLearnNTG.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumReply> ForumReplies { get; set; }
        public DbSet<Messages> PrivateMessages { get; set; }

    }
}
