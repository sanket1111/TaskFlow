using TaskFlow.Web.Models.Enum;

namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public ProjectPriority? Priority { get; set; }
        public ProjectStatus? Status { get; set; }
        public ProjectSortField? SortBy { get; set; }
        public bool SortDescending { get; set; } = true;
    }
}
