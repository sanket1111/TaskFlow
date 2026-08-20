namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectListResultViewModel
    {
        public List<ProjectListViewModel> Projects { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
