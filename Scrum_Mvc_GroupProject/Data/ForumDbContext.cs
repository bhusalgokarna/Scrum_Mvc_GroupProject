using Microsoft.EntityFrameworkCore;
using Scrum_Mvc_GroupProject.Models;

namespace Scrum_Mvc_GroupProject.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<DiscussieThread> DiscussieThreads { get; set; }
        public DbSet<Reactie> Reacties { get; set; }
    }
}
