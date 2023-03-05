using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.DTO.ProjectDTO;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using BugTracker.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.UI.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly ITicketAdder _ticketAdder;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProjectGetter _projectGetter;
        public ProjectsController(IProjectGetter projectGetter, ITicketAdder ticketAdder, UserManager<ApplicationUser> userManager)
        {
            _projectGetter = projectGetter;
            _ticketAdder = ticketAdder;
            _userManager = userManager;
        }
        public void CheckUserRole()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.isAdmin = true;
            }
            else if (User.IsInRole("Developer"))
            {
                ViewBag.isDeveloper = true;
            }
            else if (User.IsInRole("ProjectManager"))
            {
                ViewBag.isProjectManager = true;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("{projectID:int}")]
        public async Task<IActionResult> Details(int projectID)
        {
            ProjectResponseDTO? project = await _projectGetter.GetProject(projectID);
            CheckUserRole();
            return View(project);
        }

        [HttpGet("{projectId:int}")]
        public IActionResult CreateTicket()
        {
            ViewBag.Developers = _userManager.GetUsersInRoleAsync("Developer").Result.Select(dev => new SelectListItem()
            {
                Text = dev.Name,
                Value = dev.ToString()
            });
            CheckUserRole();
            return View();
        }
        [HttpPost("{projectId:int}")]
        public IActionResult CreateTicket(TicketAddDTO ticket)
        {
            if (!ModelState.IsValid) { return View(ticket); }
            _ticketAdder.AddTicket(ticket);
            return RedirectToAction(nameof(Details), new { id = projectId });
        }
    }
}
