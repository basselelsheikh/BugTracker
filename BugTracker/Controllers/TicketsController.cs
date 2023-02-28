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
            IEnumerable<TicketResponseDTO> Tickets = await _ticketGetter.GetAllTickets();
            return View(Tickets);
        }
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            TicketResponseDTO ticket = await _ticketGetter.GetTicket(id);
            return View(ticket);
        }
        public IActionResult AddComment(string commentText) {


        }


    }
}
