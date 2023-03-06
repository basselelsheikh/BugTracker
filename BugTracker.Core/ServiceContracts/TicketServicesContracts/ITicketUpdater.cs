using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketUpdater
    {
        public Task AddCommentToTicket(int ticketId,Comment comment);
        public Task<int> UpdateTicket(Ticket ticket);
    }
}
