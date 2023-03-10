using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.RepositoryContracts
{
    public interface ITicketRepository
    {
        public Task<IEnumerable<Ticket>> GetTickets(Expression<Func<Ticket,bool>>? predicate);
        public Task<Ticket?> GetTicket(int ID);
        public Task<IEnumerable<Ticket>> GetTicketsAssignedToDeveloper(string developerUsername);
        public Task<IEnumerable<Ticket>> GetUserReportedTickets(string username);
        public Task AddCommentToTicket(int ticketId, Comment comment);
        public Task<int> UpdateTicket(Ticket ticket);
        public Task<bool> DeleteTicket(int ticketId);
        public Task<bool> AddTicket(Ticket ticket);

    }
}
