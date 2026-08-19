using Microsoft.EntityFrameworkCore;
using TaskFlow.Web.Data;
using TaskFlow.Web.Models.Project;
using TaskFlow.Web.Services.Interfaces;
using TaskFlow.Web.ViewModels.Project;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ProjectCreateViewModel model)
        {
            var project = new Project
            {
                ProjectName = model.ProjectName,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
                Priority = model.Priority
            };
            _context.Projects.Add(project);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects
                                  .Include(item => item.TaskItems)
                                  .FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                return false;

            project.IsActive = false;

            foreach (var item in project.TaskItems)
            {
                item.IsActive = false;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProjectListViewModel>> GetAllAsync(ProjectFilterViewModel filter)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                query = query.Where(p => p.ProjectName.Contains(filter.SearchTerm));
            }

            if (filter.Priority != null)
            {
                query = query.Where(p => p.Priority == filter.Priority);
            }

            if (filter.Status != null)
            {
                query = query.Where(p => p.Status == filter.Status);
            }

            return await query.Select(p => new ProjectListViewModel
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                Status = p.Status,
                Priority = p.Priority,
                StartDate = p.StartDate,
                EndDate = p.EndDate
            }).ToListAsync();

        }

        public Task<ProjectEditViewModel?> GetByIdAsync(int id)
        {
            return _context.Projects
                .Where(p => p.Id == id)
                .Select(p => new ProjectEditViewModel
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    Status = p.Status,
                    Priority = p.Priority,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProjectDetailsViewModel?> GetDetailsAsync(int id)
        {
            var projectDeatils =  _context.Projects
                                         .Where(p => p.Id == id)
                                         .Select(p => new ProjectDetailsViewModel
                                         {
                                             Id=p.Id,
                                             ProjectName = p.ProjectName,
                                             Description = p.Description,
                                             Status = p.Status,
                                             Priority = p.Priority,
                                             StartDate = p.StartDate,
                                             EndDate = p.EndDate,
                                             TaskItems = p.TaskItems.Select(t => new TaskListViewModel
                                             {
                                                 Id = t.Id,
                                                 TaskTitle = t.TaskTitle,
                                                 Description = t.Description,
                                                 Status = t.Status,
                                                 Priority = t.Priority,
                                                 DueDate = t.DueDate,                                                 
                                             }).ToList()
                                         });
            return await projectDeatils.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(ProjectEditViewModel model)
        {
            var project = await _context.Projects.FindAsync(model.Id);
            if (project == null)
            {
                return false;

            }
            project.ProjectName = model.ProjectName;
            project.Description = model.Description;
            project.Status = model.Status;
            project.Priority = model.Priority;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
