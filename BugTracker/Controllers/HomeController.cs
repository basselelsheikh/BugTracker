using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/Home")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
