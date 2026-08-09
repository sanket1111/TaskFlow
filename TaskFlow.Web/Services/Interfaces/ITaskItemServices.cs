using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Services.Interfaces
{
    public interface ITaskItemServices
    {
        Task CreateAsync(TaskCreateViewModel model);
    }
}
