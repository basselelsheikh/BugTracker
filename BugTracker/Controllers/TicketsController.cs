using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult Index(string username)
        {
            CheckUserRole();
            return View();

        }

        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            TicketResponseDTO? ticket = await _ticketGetter.GetTicket(id);
            CheckUserRole();
            return View(ticket);
        }

        public async Task<IActionResult> AddComment(string commentText, string username, int ticketId)
        {
            ApplicationUser commenter = await _userManager.FindByNameAsync(username);
            Comment comment = new Comment() { Commenter = commenter, CommentText = commentText };
            await _ticketUpdater.AddCommentToTicket(ticketId, comment);
            return RedirectToAction(nameof(Details), new { id = ticketId });
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            TicketResponseDTO? ticket = await _ticketGetter.GetTicket(id);
            ViewBag.Developers = _userManager.GetUsersInRoleAsync("Developer").Result.Select(dev => new SelectListItem()
            {
                Text = dev.Name,
                Value = dev.ToString()
            });
            return View(ticket);
        }
        [HttpPost("{id:int}")]
        public IActionResult Edit(TicketUpdateDTO ticket)
        {
            if (!ModelState.IsValid) { return View(ticket); }
            _ticketUpdater.UpdateTicket(ticket);
           
            return View();
        }
    }
}
