using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class TicketsController : Controller
    {
        private readonly ITicketAdder _ticketAdder;
        private readonly ITicketDeleter _ticketDeleter;
        private readonly ITicketGetter _ticketGetter;
        private readonly ITicketUpdater _ticketUpdater;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketsController(ITicketAdder ticketAdder, ITicketDeleter ticketDeleter, ITicketGetter ticketGetter, ITicketUpdater ticketUpdater, UserManager<ApplicationUser> userManager)
        {
            _ticketAdder = ticketAdder;
            _ticketDeleter = ticketDeleter;
            _ticketGetter = ticketGetter;
            _ticketUpdater = ticketUpdater;
            _userManager = userManager;


        }
        public async Task<IActionResult> Index(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                ViewBag.isAdmin = true;
            }
            else if (await _userManager.IsInRoleAsync(user, "Developer"))
            {
                ViewBag.isDeveloper = true;
            }
            else if (await _userManager.IsInRoleAsync(user, "ProjectManager"))
            {
                ViewBag.isProjectManager = true;
            }

            return View();

        }

        //tickets related to a particular project
        //NOTE: should I add it to project or ticket controller?
        [Route("{id:int}")]
        public async Task<IActionResult> ProjectTickets(int projectId)
        {
            IEnumerable<TicketResponseDTO> Tickets = await _ticketGetter.GetTickets();
            return View(Tickets);
        }

        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            TicketResponseDTO ticket = await _ticketGetter.GetTicket(id);
            return View(ticket);
        }
        public IActionResult AddComment(string commentText)
        {


        }



    }
}
