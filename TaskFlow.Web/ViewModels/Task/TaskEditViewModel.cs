using TaskFlow.Web.Models.Enum;
using TaskStatus = TaskFlow.Web.Models.Enum.TaskStatus;

namespace TaskFlow.Web.ViewModels.Task
{
    public class TaskEditViewModel
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; } = string.Empty;
        public string Description { get; set; } =string.Empty;
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
    }
}
