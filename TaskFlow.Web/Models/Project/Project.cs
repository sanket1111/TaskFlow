using System.Collections.ObjectModel;
using TaskFlow.Web.Models.Common;

public class Project : BaseEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Collection<TaskItem> TaskItems { get; set; } = new Collection<TaskItem>();
}