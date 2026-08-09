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
        public IActionResult Create()
        {
            TaskCreateViewModel model = new TaskCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _taskItemServices.CreateAsync(model);

            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }
    }
}
