using AutoMapper;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class TicketDeleter : ITicketDeleter
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketDeleter(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<bool> DeleteTicket(int ticketId)
        {
           return _ticketRepository.DeleteTicket(ticketId);
        }
    }
}
