using Microsoft.AspNetCore.Mvc;
using TaskFlow.Web.Data;
using TaskFlow.Web.ViewModels.Project;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {            
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }
            
            Project project = new Project
            {
                ProjectName = model.ProjectName,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CreatedBy = "Admin", // Replace with actual user
                CreatedDate = DateTime.Now,
                ModifiedBy = "Admin", // Replace with actual user
                ModifiedDate = DateTime.Now
            };

            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
