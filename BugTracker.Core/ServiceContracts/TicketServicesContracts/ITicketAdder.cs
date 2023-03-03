using BugTracker.Core.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketAdder
    {
        public Task<bool> AddTicket(TicketAddDTO ticketAddDTO);
        
    }
}
