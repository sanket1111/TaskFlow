using TaskFlow.Web.Models.Enum;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectEditViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectPriority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
