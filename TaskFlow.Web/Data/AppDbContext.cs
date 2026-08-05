using Microsoft.EntityFrameworkCore;
using TaskFlow.Web.Models.Common;
using TaskFlow.Web.Models.Project;

namespace TaskFlow.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure EF Core explicitly recognizes the CLR entity types and their relationship
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<TaskItem>();

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.ModifiedDate = DateTime.UtcNow;

                    // Temporary until authentication is added
                    entry.Entity.CreatedBy = "System";
                    entry.Entity.ModifiedBy = "System";
                }

                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.UtcNow;

                    // Temporary until authentication is added
                    entry.Entity.ModifiedBy = "System";
                }
            }
            return base.SaveChanges();
        }

    }
}
