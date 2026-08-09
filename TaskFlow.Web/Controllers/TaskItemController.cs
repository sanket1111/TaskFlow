using Microsoft.AspNetCore.Mvc;
using TaskFlow.Web.Services.Interfaces;
using TaskFlow.Web.ViewModels.Task;

namespace TaskFlow.Web.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemServices _taskItemServices;

        public TaskItemController(ITaskItemServices taskItemServices)
        {
            _taskItemServices = taskItemServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int ProjectId)
        {
            TaskCreateViewModel model = new TaskCreateViewModel()
            {
                ProjectId = ProjectId
            };            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _taskItemServices.CreateAsync(model);

            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _taskItemServices.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updated = await _taskItemServices.UpdateAsync(model);
            if (!updated)
            {
                return NotFound();
            }
            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        } 
    }
}
