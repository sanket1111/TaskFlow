using TaskFlow.Web.Models.Common;

namespace TaskFlow.Web.Models.Project
{
    public class TaskItem : BaseEntity
    {
        public int Id { get; set; }

        public string TaskTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
