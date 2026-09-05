using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
