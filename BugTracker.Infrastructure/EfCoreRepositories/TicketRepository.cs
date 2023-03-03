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
using AutoMapper;

namespace BugTracker.Infrastructure.EfCoreRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public TicketRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Ticket>?> GetTickets(Expression<Func<Ticket, bool>>? predicate)
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
            return user.AssignedInTickets; ;
        }

        public async Task<IEnumerable<Ticket>?> GetUserReportedTickets(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            return user.ReportedTickets;
        }

        public async Task AddCommentToTicket(int ticketId, Comment comment)
        {
            Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);
            ticket?.Comments?.Add(comment);
            _context.SaveChanges();
        }

        public async Task<int> UpdateTicket(Ticket ticket)
        {
            Ticket? ticketToUpdate = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticket.TicketId);
            if (ticketToUpdate is not null)
            {
                _mapper.Map<Ticket, Ticket>(ticket, ticketToUpdate);
                _context.SaveChanges();
                return ticketToUpdate.TicketId;
            }
            return ticket.TicketId;
        }

        public async Task<bool> DeleteTicket(int ticketId)
        {
            _context.Tickets.Remove(_context.Tickets.Single(tic => tic.TicketId == ticketId));
            int rowsDeleted = await _context.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<bool> AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            int addedRows = await _context.SaveChangesAsync();
            return addedRows > 0;
        }
    }
}
