using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}