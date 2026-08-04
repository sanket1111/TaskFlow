using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TaskFlow.Web.Models.Common
{
    //why abstract class? because we don't want to create an instance of this class, we just want to inherit from it
    public abstract class BaseEntity : DbContext    
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
