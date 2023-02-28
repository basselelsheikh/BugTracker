using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.TicketDTO;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.TicketServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<TicketResponseDTO?> GetTicket(int ID)
        {
            Ticket? ticket = await _ticketRepository.GetTicket(ID);
            return _mapper.Map<TicketResponseDTO>(ticket);

        }

        public async Task<IEnumerable<TicketResponseDTO>?> GetTickets(Expression<Func<Ticket,bool>>? predicate)
        {
            IEnumerable<Ticket>? result = await _ticketRepository.GetTickets(predicate);
            return result?.Select(ticket => _mapper.Map<TicketResponseDTO>(ticket));

        }

       /* public async Task<TicketResponseDTO> GetTicket(int id)
        {
            return _mapper.Map<TicketResponseDTO>(await _ticketRepository.GetTicket());
        } */

        public async Task<IEnumerable<TicketResponseDTO>?> GetTicketsAssignedToDeveloper(string developerUsername)
        {
            IEnumerable<Ticket>? result = await _ticketRepository.GetTicketsAssignedToDeveloper(developerUsername);
            return result?.Select(ticket => _mapper.Map<TicketResponseDTO>(ticket));
        }

        public async Task<IEnumerable<TicketResponseDTO>?> GetUserReportedTickets(string username)
        {
            IEnumerable<Ticket>? result = await _ticketRepository.GetUserReportedTickets(username);
            return result?.Select(ticket => _mapper.Map<TicketResponseDTO>(ticket));
        }
    }
}
