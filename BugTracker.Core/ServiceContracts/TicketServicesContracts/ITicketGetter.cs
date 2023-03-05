using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketGetter
    {
        public Task<IEnumerable<TicketResponseDTO>?> GetTickets(Expression<Func<Ticket, bool>>? predicate = null);
        public Task<IEnumerable<TicketResponseDTO>?> GetTicketsAssignedToDeveloper(string developerUsername);
        public Task<IEnumerable<TicketResponseDTO>?> GetUserReportedTickets(string username);
        public Task<TicketResponseDTO?> GetTicket(int ID);
    }
}
