using System.ComponentModel.DataAnnotations;
using TaskFlow.Web.Models.Enum;
using TaskFlow.Web.Validation;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectCreateViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Project name is required")]
        [StringLength(50, ErrorMessage = "Project name cannot exceed 50 characters")]
        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        [FutureDate(ErrorMessage = "Start date should be current date or future date")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public ProjectStatus Status { get; set; } = ProjectStatus.New;
        public ProjectPriority Priority { get; set; } = ProjectPriority.Medium;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(EndDate.HasValue && EndDate.Value < StartDate)
            {
                yield return new ValidationResult(
                    "End date cannot be earlier than start date",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
