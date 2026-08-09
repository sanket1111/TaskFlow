using TaskFlow.Web.ViewModels.Project;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Services.Interfaces
{
    public interface ITaskItemServices
    {
        Task CreateAsync(TaskCreateViewModel model);
        Task<List<TaskEditViewModel>> GetAllAsync();
        Task<TaskEditViewModel?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TaskEditViewModel model);
    }
}
