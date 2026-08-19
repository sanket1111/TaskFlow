using TaskFlow.Web.ViewModels.Project;

namespace TaskFlow.Web.Services.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(ProjectCreateViewModel model);
        Task<List<ProjectListViewModel>> GetAllAsync(string? searchTerm = null);
        Task<ProjectEditViewModel?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(ProjectEditViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<ProjectDetailsViewModel?> GetDetailsAsync(int id);
    }
}
