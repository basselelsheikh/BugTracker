using BugTracker.Core.Domain.Entities;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure.EfCoreRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.Include("AssignedDevs").Include("Project").ToListAsync();
        }
        public async Task<Ticket?> GetTicket(int id)
        {
            return await _context.Tickets.Include("AssignedDevs").Include("Project").FirstOrDefaultAsync(t => t.TicketId == id);
        }

    }
}
