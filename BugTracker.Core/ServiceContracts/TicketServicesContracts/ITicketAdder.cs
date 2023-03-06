using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketAdder
    {
        public Task<bool> AddTicket(Ticket ticket);
    }
}
