using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class TicketUpdater : ITicketUpdater
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketUpdater(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;

        }
        public async Task AddCommentToTicket(int ticketId , Comment comment)
        {
            await _ticketRepository.AddCommentToTicket(ticketId, comment);
        }
    }
}
