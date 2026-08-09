using Microsoft.EntityFrameworkCore;
using TaskFlow.Web.Data;
using TaskFlow.Web.Models.Project;
using TaskFlow.Web.Services.Interfaces;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Services
{
    public class TaskItemServices : ITaskItemServices
    {
        private readonly AppDbContext _context;

        public TaskItemServices(AppDbContext context)
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

        public async Task<List<TaskEditViewModel>> GetAllAsync()
        {            
            return await _context.TaskItems
                .Select(t => new TaskEditViewModel
                {
                    Id = t.Id,
                    TaskTitle = t.TaskTitle,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate
                }).ToListAsync();
        }

        public async Task<TaskEditViewModel?> GetByIdAsync(int id)
        {
            return await _context.TaskItems
                .Where(t => t.Id == id)
                .Select(t => new TaskEditViewModel
                {
                    Id = t.Id,
                    TaskTitle = t.TaskTitle,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate
                }).FirstOrDefaultAsync();   
        }

        public async Task<bool> UpdateAsync(TaskEditViewModel model)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.Id == model.Id);

            if (task != null)
            {
                task.TaskTitle = model.TaskTitle;
                task.Description = model.Description;
                task.Status = model.Status;
                task.Priority = model.Priority;
                task.DueDate = model.DueDate;
                task.ProjectId = model.Id;

                _context.TaskItems.Update(task);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
