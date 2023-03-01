using BugTracker.Core.Domain.Entities;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Core.Domain.IdentityEntities;

namespace BugTracker.Infrastructure.EfCoreRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TicketRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IEnumerable<Ticket>?> GetTickets(Expression<Func<Ticket,bool>>? predicate)
        {
            //if condition, get tickets by condition
            if (predicate is not null)
            {
                return await _context.Tickets.Include("AssignedDevs").Include("Project").Include("Reporter").Include("Comments").Where(predicate).ToListAsync();
            }
            //if no condition on ticket, return all tickets
            return await _context.Tickets.Include("AssignedDevs").Include("Project").Include("Reporter").Include("Comments").ToListAsync();
        }
        public async Task<Ticket?> GetTicket(int id)
        {
            return await _context.Tickets.Include("AssignedDevs").Include("Project").Include("Reporter").Include("Comments").FirstOrDefaultAsync(t => t.TicketId == id);
        }

        public async Task<IEnumerable<Ticket>?> GetTicketsAssignedToDeveloper(string developerUsername)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(developerUsername);
            return user.AssignedInTickets;                                                                                                                                                                ;
        }

        public async Task<IEnumerable<Ticket>?> GetUserReportedTickets(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            return user.ReportedTickets;
        }

        public async void AddCommentToTicket(int ticketId, Comment comment)
        {
            Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);
            ticket?.Comments?.Add(comment);
            _context.SaveChanges();
        }
    }
}
