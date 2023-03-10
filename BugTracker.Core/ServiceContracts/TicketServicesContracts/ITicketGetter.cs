using BugTracker.Core.Domain.Entities;
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
        public Task<IEnumerable<Ticket>> GetTickets(Expression<Func<Ticket, bool>>? predicate = null);
        public Task<IEnumerable<Ticket>> GetTicketsAssignedToDeveloper(string developerUsername);
        public Task<IEnumerable<Ticket>> GetUserReportedTickets(string username);
        public Task<Ticket?> GetTicket(int ID);
    }
}
