using Microsoft.AspNetCore.Mvc;
using TaskFlow.Web.Data;
using TaskFlow.Web.ViewModels.Project;
using TaskFlow.Web.Models.Project;
using TaskFlow.Web.Services;
using TaskFlow.Web.Services.Interfaces;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {        
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        /// <summary>
        /// Displays a list of all projects.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var model = await _projectService.GetAllAsync();
            return View(model);
        }

        /// <summary>
        /// Displays the form to create a new project.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            ProjectCreateViewModel model = new ProjectCreateViewModel();
            return View(model);
        }

        /// <summary>
        /// Handles the submission of the new project form and creates a new project in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }

            await _projectService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _projectService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}

            

