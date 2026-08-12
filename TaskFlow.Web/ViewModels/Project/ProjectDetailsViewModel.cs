using TaskFlow.Web.Models.Enum;
using TaskFlow.Web.Models.Project;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; }
        public ProjectPriority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<TaskListViewModel> TaskItems { get; set; } 
            = new List<TaskListViewModel>();
    }
}
