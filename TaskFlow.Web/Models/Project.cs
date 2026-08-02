namespace TaskFlow.Web.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_by  { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Modified_By { get; set; }
    }
}
