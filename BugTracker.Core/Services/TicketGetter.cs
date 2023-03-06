using AutoMapper;
using BugTracker.Core.Domain.Entities;
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
        private readonly ITicketRepository _TicketRepository;
        private readonly IMapper _mapper;
        public TicketGetter(ITicketRepository TicketRepository, IMapper mapper)
        {
            _TicketRepository = TicketRepository;
            _mapper = mapper;
        }

        public async Task<Ticket?> GetTicket(int ID)
        {
            Ticket? Ticket = await _TicketRepository.GetTicket(ID);
            return _mapper.Map<Ticket>(Ticket);

        }

        public async Task<IEnumerable<Ticket>> GetTickets(Expression<Func<Ticket,bool>>? predicate = null)
        {
            IEnumerable<Ticket> result = await _TicketRepository.GetTickets(predicate);
            return result.Select(Ticket => _mapper.Map<Ticket>(Ticket));

        }

        public async Task<IEnumerable<Ticket>> GetTicketsAssignedToDeveloper(string developerUsername)
        {
            IEnumerable<Ticket> result = await _TicketRepository.GetTicketsAssignedToDeveloper(developerUsername);
            return result.Select(Ticket => _mapper.Map<Ticket>(Ticket));
        }

        public async Task<IEnumerable<Ticket>> GetUserReportedTickets(string username)
        {
            IEnumerable<Ticket> result = await _TicketRepository.GetUserReportedTickets(username);
            return result.Select(Ticket => _mapper.Map<Ticket>(Ticket));
        }
    }
}
