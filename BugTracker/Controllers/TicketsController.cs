using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using BugTracker.UI.DTO.TicketDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;

        public TicketsController(ITicketAdder ticketAdder, ITicketDeleter ticketDeleter, ITicketGetter ticketGetter, ITicketUpdater ticketUpdater, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _ticketAdder = ticketAdder;
            _ticketDeleter = ticketDeleter;
            _ticketGetter = ticketGetter;
            _ticketUpdater = ticketUpdater;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{ticketId:int}")]
        public async Task<IActionResult> Details(int ticketId)
        {
            Ticket? ticket = await _ticketGetter.GetTicket(ticketId);
            if (ticket is not null)
            {
                return View(_mapper.Map<TicketResponseDTO>(ticket));

            }
            else
            {
                return new NotFoundResult();
            }
        }
        public async Task<IActionResult> AddComment(string commentText, string username, int ticketId)
        {
            ApplicationUser commenter = await _userManager.FindByNameAsync(username);
            Comment comment = new() { Commenter = commenter, CommentText = commentText };
            await _ticketUpdater.AddCommentToTicket(ticketId, comment);
            return RedirectToAction(nameof(Details), new { id = ticketId });
        }
        [HttpGet("{ticketId:int}")]
        public async Task<IActionResult> Edit(int ticketId)
        {
            Ticket? ticket = await _ticketGetter.GetTicket(ticketId);
            if (ticket is not null)
            {
                TicketUpdateDTO model = _mapper.Map<TicketUpdateDTO>(ticket);
                List<DeveloperCheckboxItem> _checkboxItems = new();
                List<ApplicationUser> developersInProject = await 
                    _userManager.Users.Where(u => u.AssignedProjectId == ticket.ProjectId).ToListAsync();
                foreach (ApplicationUser developer in developersInProject)
                {
                    if (ticket.AssignedDevs.Contains(developer))
                    {
                        _checkboxItems.Add(new DeveloperCheckboxItem()
                        {
                            DeveloperName = developer.Name,
                            DeveloperId = developer.Id,
                            IsChecked = true
                        });
                    }
                    else
                    {
                        _checkboxItems.Add(new DeveloperCheckboxItem()
                        {
                            DeveloperName = developer.Name,
                            DeveloperId = developer.Id,
                            IsChecked = false
                        });
                    }
                }
                model.AssignedDevs = _checkboxItems;
                return View(model);
            }
            else
            {
                return new NotFoundResult();
            }

        }
        [HttpPost("{ticketId:int}")]
        public async Task<IActionResult> Edit(TicketUpdateDTO model, int ticketId)
        {
            if (!ModelState.IsValid) { return View(model); }
            Ticket ticket = _mapper.Map<Ticket>(model);
            ticket.AssignedDevs = new List<ApplicationUser>();
            foreach (DeveloperCheckboxItem temp in model.AssignedDevs)
            {
                if (temp.IsChecked)
                {
                    ApplicationUser dev = await _userManager.FindByIdAsync(temp.DeveloperId.ToString());
                    ticket.AssignedDevs.Add(dev);
                }
            }
            await _ticketUpdater.UpdateTicket(ticket);
            return RedirectToAction(nameof(Details), new { id = ticketId });
        }
        [HttpGet("{ticketId:int}")]
        public IActionResult Delete(int ticketId)
        {
            _ticketDeleter.DeleteTicket(ticketId);
            return RedirectToAction(nameof(Details), new { id = ticketId });
        }
    }
}