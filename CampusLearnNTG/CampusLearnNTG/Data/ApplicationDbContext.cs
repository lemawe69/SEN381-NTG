using Microsoft.EntityFrameworkCore;
using CampusLearnNTG.Models;

namespace CampusLearnNTG.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
