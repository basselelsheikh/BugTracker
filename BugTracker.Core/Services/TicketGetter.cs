using BugTracker.Core.Domain.Entities;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class TicketGetter : ITicketGetter
    {
        public IEnumerable<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Ticket> GetTicket(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
