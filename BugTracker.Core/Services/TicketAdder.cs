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
    public class TicketAdder : ITicketAdder
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public TicketAdder(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public Task<bool> AddTicket(TicketAddDTO ticketAddDTO)
        {
            Ticket ticket = _mapper.Map<Ticket>(ticketAddDTO);
            return _ticketRepository.AddTicket(ticket);
        }
    }
}
