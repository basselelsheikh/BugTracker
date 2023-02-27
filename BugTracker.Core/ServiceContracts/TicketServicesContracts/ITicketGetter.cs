using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.TicketServicesContracts
{
    public interface ITicketGetter
    {
        public Task<IEnumerable<TicketResponseDTO>> GetAllTickets();
        public Task<TicketResponseDTO> GetTicket(int ID);
    }
}
