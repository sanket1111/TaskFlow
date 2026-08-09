using TaskFlow.Web.Models.Enum;

namespace TaskFlow.Web.ViewModels.Task
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Models.Enum.TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}
