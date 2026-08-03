using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; } = null!;
    }
}
