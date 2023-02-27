using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.RepositoryContracts
{
    public interface ITicketRepository
    {
        public Task<IEnumerable<Ticket>> GetAllTickets();
        public Task<Ticket?> GetTicket(int ID);
    }
}
