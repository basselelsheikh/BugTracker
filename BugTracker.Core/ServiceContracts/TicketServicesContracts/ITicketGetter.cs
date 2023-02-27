using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketGetter
    {
        public IEnumerable<Ticket> GetAllTickets();
        public IEnumerable<Ticket> GetTicket(int ID);
    }
}
