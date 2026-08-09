using TaskFlow.Web.Data;
using TaskFlow.Web.Models.Project;
using TaskFlow.Web.Services.Interfaces;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Services
{
    public class TaskServices : ITaskItemServices
    {
        private readonly AppDbContext _context;

        public TaskServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TaskCreateViewModel model)
        {
            var Task = new TaskItem
            {
                TaskTitle = model.TaskTitle,
                Description = model.Description,
                Status = model.Status,
                Priority = model.Priority,
                DueDate = model.DueDate,
                ProjectId = model.ProjectId
            };

            _context.TaskItems.Add(Task);
            await _context.SaveChangesAsync();
        }
    }
}
