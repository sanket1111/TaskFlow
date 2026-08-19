using TaskFlow.Web.Models.Enum;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public ProjectPriority? Priority { get; set; }
        public ProjectStatus? Status { get; set; }
    }
}
