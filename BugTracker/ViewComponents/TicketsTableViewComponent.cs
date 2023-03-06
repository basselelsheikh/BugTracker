using BugTracker.UI.DTO.TicketDTO;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using AutoMapper;
using BugTracker.UI.DTO.ProjectDTO;

namespace BugTracker.UI.ViewComponents
{
    public class TicketsTableViewComponent : ViewComponent
    {
        private readonly ITicketGetter _ticketGetter;
        private readonly IMapper _mapper;
        public TicketsTableViewComponent(ITicketGetter ticketGetter, IMapper mapper) {
            _ticketGetter = ticketGetter;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? projectId, string? developerUsername, string? username )
        {
            if(projectId is not null)
            {
                IEnumerable<Ticket> tickets = await _ticketGetter.GetTickets(t => t.Project.ProjectId == projectId);
                return View(tickets.Select(t => _mapper.Map<TicketResponseDTO>(t)));
            }
            if(developerUsername is not null)
            {
                IEnumerable<Ticket> tickets = await _ticketGetter.GetTicketsAssignedToDeveloper(developerUsername);
                return View(tickets.Select(t => _mapper.Map<TicketResponseDTO>(t)));
            }
            if(username is not null)
            {
                IEnumerable<Ticket> tickets = await _ticketGetter.GetUserReportedTickets(username);
                return View(tickets.Select(t => _mapper.Map<TicketResponseDTO>(t)));
            }
            else
            {
                //If no condition provided, return all tickets, usually this is for admin roles only
                IEnumerable<Ticket> tickets = await _ticketGetter.GetTickets();
                return View(tickets.Select(t => _mapper.Map<TicketResponseDTO>(t)));
            }
        }
    }
}