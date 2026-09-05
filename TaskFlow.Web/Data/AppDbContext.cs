using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Web.Models.Common;
using TaskFlow.Web.Models.Project;

namespace TaskFlow.Web.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure enum string conversion for columns stored as NVARCHAR in database
            modelBuilder.Entity<Project>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Project>()
                .Property(p => p.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasQueryFilter(p => p.IsActive);

            modelBuilder.Entity<TaskItem>()
                .HasQueryFilter(t=>t.IsActive);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public void UpdateAuditFields()
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
        }
    }
}
