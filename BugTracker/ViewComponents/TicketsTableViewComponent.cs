using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BugTracker.UI.ViewComponents
{
    public class TicketsTableViewComponent : ViewComponent
    {
        private readonly ITicketGetter _ticketGetter;
        public TicketsTableViewComponent(ITicketGetter ticketGetter) {
            _ticketGetter = ticketGetter;
        }
        public async Task<IViewComponentResult> InvokeAsync(
                                            int? projectId, string? developerUsername, string? username )
        {
            if(projectId is not null)
            {
                IEnumerable<TicketResponseDTO> tickets = await _ticketGetter.GetTickets(t => t.Project.ProjectId == projectId);
                return View(tickets);
            }
            if(developerUsername is not null)
            {
                IEnumerable<TicketResponseDTO>? tickets = await _ticketGetter.GetTicketsAssignedToDeveloper(developerUsername);
                return View(tickets);

            }
            if(username is not null)
            {
                IEnumerable<TicketResponseDTO>? tickets = await _ticketGetter.GetUserReportedTickets(username);
                return View(tickets);
            }
            else
            {
                //If no condition provided, return all tickets, usually this is for admin roles only
                IEnumerable<TicketResponseDTO>? tickets = await _ticketGetter.GetTickets(t => t.Project.ProjectId == projectId);
                return View(tickets);

            }
            
        }

    }
}
