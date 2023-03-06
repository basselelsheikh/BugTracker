using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using BugTracker.UI.DTO.TicketDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;

namespace BugTracker.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class ProjectsController : Controller
    {

        private readonly ITicketAdder _ticketAdder;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProjectGetter _projectGetter;
        private readonly IMapper _mapper;
        public ProjectsController(IProjectGetter projectGetter, ITicketAdder ticketAdder, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _projectGetter = projectGetter;
            _ticketAdder = ticketAdder;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("{projectID:int}")]
        public async Task<IActionResult> Details(int projectID)
        {
            Project? project = await _projectGetter.GetProject(projectID);
            if (project is not null)
            {
                return View(project);
            }
            else
            {
                //NOTE: Raise Exception: Database error: Can't retrieve project
            }
        }

        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> CreateTicket(int projectId)
        {
            List<ApplicationUser> developersInProject = await _userManager.Users.Where(u => u.AssignedProjectId == projectId).ToListAsync();
            List<DeveloperCheckboxItem> _checkboxItems = new List<DeveloperCheckboxItem>();
            foreach (ApplicationUser developer in developersInProject)
            {
                _checkboxItems.Add(new DeveloperCheckboxItem()
                {
                    DeveloperName = developer.Name,
                    DeveloperId = developer.Id,
                });
            }
            TicketAddDTO model = new()
            {
                AssignedDevs = _checkboxItems
            };
            return View(model);

        }
        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> CreateTicket(TicketAddDTO model, int projectId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Ticket ticket = _mapper.Map<Ticket>(model);
            ticket.AssignedDevs = new List<ApplicationUser>();
            foreach (DeveloperCheckboxItem temp in model.AssignedDevs)
            {
                if(temp.IsChecked)
                {
                    ApplicationUser dev = await _userManager.FindByIdAsync(temp.DeveloperId.ToString());
                    ticket.AssignedDevs.Add(dev);
                }
            }
            await _ticketAdder.AddTicket(ticket);
            return RedirectToAction(nameof(Details), new { id = projectId });
        }
    }
}
