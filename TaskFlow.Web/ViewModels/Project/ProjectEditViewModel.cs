using System.ComponentModel.DataAnnotations;
using TaskFlow.Web.Models.Enum;
using TaskFlow.Web.Validation;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectEditViewModel : IValidatableObject
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Project name cannot exceed 50 characters")]
        [Required(ErrorMessage = "Project name is required")]
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; } = ProjectStatus.New;
        public ProjectPriority Priority { get; set; } = ProjectPriority.Medium;

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } = null;

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } = null;
        public string? LastModifiedDateField { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate.HasValue
                && EndDate.HasValue
                && EndDate.Value < StartDate)
            {
                var validationField = LastModifiedDateField == nameof(StartDate)
                                        ? nameof(StartDate)
                                        : nameof(EndDate);

                yield return new ValidationResult(
                    "End date cannot be earlier than start date",
                    new[] { nameof(validationField) });
            }
        }
    }
}
