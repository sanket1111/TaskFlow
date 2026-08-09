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
            TaskCreateViewModel model = new TaskCreateViewModel();
            model.ProjectId = ProjectId;
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
    }
}
