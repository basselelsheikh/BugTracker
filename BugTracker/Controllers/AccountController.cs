using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        [Route("/")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
