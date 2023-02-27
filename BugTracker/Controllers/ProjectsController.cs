using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
