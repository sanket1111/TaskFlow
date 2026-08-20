using TaskFlow.Web.Models.Enum;
using TaskFlow.Web.Models.Project;

namespace TaskFlow.Web.Data
{
    public static class DbSeeder
    {
        public static async Task SeedProjectsAsync(AppDbContext context)
        {
            if (context.Projects.Count() >= 100)
            {
                return;
            }

            var projects = new List<Project>();

            var priorities = Enum.GetValues<ProjectPriority>();
            var statuses = Enum.GetValues<ProjectStatus>();

            for (int i = 1; i <= 100; i++)
            {
                projects.Add(new Project
                {
                    ProjectName = $"Project {i}",
                    Description = $"This is the description for Project {i}.",
                    StartDate = DateTime.Today.AddDays(-i),
                    EndDate = DateTime.Today.AddDays(30 + i),
                    Priority = priorities[(i - 1) % priorities.Length],
                    Status = statuses[(i - 1) % statuses.Length],
                    IsActive = true
                });
            }

            await context.Projects.AddRangeAsync(projects);
            await context.SaveChangesAsync();
        }
    }
}