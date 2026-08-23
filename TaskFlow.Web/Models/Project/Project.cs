using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TaskFlow.Web.Models.Common;
using TaskFlow.Web.Models.Enum;

namespace TaskFlow.Web.Models.Project
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.New;
        public ProjectPriority Priority { get; set; } = ProjectPriority.Medium;
        public bool IsActive { get; set; } = true;
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}
