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
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }
        /// <summary>
        /// Displays a list of all projects.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(string? searchTerm = null)
        {                     
            var model = await _projectService.GetAllAsync(searchTerm);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _projectService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool IsUpdated = await _projectService.UpdateAsync(model);
            if (!IsUpdated)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool IsDeleted = await _projectService.DeleteAsync(id);
            if (!IsDeleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _projectService.GetDetailsAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}

            

