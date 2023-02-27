using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class TicketsController : Controller
    {
        private readonly ITicketAdder _ticketAdder;
        private readonly ITicketDeleter _ticketDeleter;
        private readonly ITicketGetter _ticketGetter;
        private readonly ITicketUpdater _ticketUpdater;

        public TicketsController(ITicketAdder ticketAdder, ITicketDeleter ticketDeleter, ITicketGetter ticketGetter, ITicketUpdater ticketUpdater)
        {
            _ticketAdder = ticketAdder;
            _ticketDeleter = ticketDeleter;
            _ticketGetter = ticketGetter;
            _ticketUpdater = ticketUpdater;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Tickets = await _ticketGetter.GetAllTickets();
            return View();
        }
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Ticket =  await _ticketGetter.GetTicket(id);
            return View();
        }


    }
}
