using System.ComponentModel.DataAnnotations;
using TaskFlow.Web.Models.Enum;
using TaskStatus = TaskFlow.Web.Models.Enum.TaskStatus;


namespace TaskFlow.Web.ViewModels.Task
{
    public class TaskBaseViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Task title is required")]
        public string TaskTitle { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateTime? DueDate { get; set; } = null;
        public int ProjectId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DueDate < DateTime.Now.Date)
            {
                yield return new ValidationResult(
                    "Due date should be current date or future date",
                    new[] { nameof(DueDate) });
            }
        }
    }
}
