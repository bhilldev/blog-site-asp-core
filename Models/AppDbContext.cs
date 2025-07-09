using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace BlogSiteAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
