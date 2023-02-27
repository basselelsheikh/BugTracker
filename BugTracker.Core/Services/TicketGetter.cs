using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.RepositoryContracts;
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
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public TicketGetter(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TicketResponseDTO>> GetAllTickets()
        {
            IEnumerable<Ticket> result = await _ticketRepository.GetAllTickets();
            return result.Select(ticket => _mapper.Map<TicketResponseDTO>(ticket));

        }

        public async Task<TicketResponseDTO> GetTicket(int id)
        {
            return _mapper.Map<TicketResponseDTO>(await _ticketRepository.GetTicket(id));
        }
    }
}
