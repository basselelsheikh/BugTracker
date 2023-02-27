using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
