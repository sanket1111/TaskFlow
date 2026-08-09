using System.ComponentModel.DataAnnotations;
using TaskFlow.Web.Models.Enum;
using TaskStatus = TaskFlow.Web.Models.Enum.TaskStatus;

namespace TaskFlow.Web.ViewModels.Task
{
    public class TaskCreateViewModel
    {
        public string TaskTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; } = TaskStatus.New;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now;
        public int ProjectId { get; set; }
    }
}
