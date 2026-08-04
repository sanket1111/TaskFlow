namespace TaskFlow.Web.ViewModels.Project
{
    public class ProjectCreateViewModel
    {
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
