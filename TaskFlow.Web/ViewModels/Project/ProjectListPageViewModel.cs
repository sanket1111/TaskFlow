namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectListPageViewModel
    {
        public List<ProjectListViewModel> Projects { get; set; } = new List<ProjectListViewModel>();
        public ProjectFilterViewModel Filter { get; set; } = new ProjectFilterViewModel();

    }
}
