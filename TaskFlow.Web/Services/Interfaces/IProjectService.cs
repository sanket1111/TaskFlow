using TaskFlow.Web.ViewModels.Project;

namespace TaskFlow.Web.Services.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(ProjectCreateViewModel model);
        Task<ProjectListResultViewModel> GetAllAsync(ProjectFilterViewModel filter);
        Task<ProjectEditViewModel?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(ProjectEditViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<ProjectDetailsViewModel?> GetDetailsAsync(int id);
    }
}
