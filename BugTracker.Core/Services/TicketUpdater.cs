using AutoMapper;
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
        private readonly IMapper _mapper;
        public TicketUpdater(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task AddCommentToTicket(int ticketId, Comment comment)
        {
            await _ticketRepository.AddCommentToTicket(ticketId, comment);
        }

        public async Task<int> UpdateTicket(TicketUpdateDTO ticket)
        {
            Ticket ticketUpdated = _mapper.Map<Ticket>(ticket);
           return await _ticketRepository.UpdateTicket(ticketUpdated);
        }

    }
}
