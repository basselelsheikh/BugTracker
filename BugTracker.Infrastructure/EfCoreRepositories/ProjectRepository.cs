using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.DTO.ProjectDTO;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure.EfCoreRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ProjectRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Project?> GetProject(int projectID)
        {
            return await _context.Projects.Include("Team").Include("Tickets").FirstOrDefaultAsync(t => t.ProjectId == projectID);
        }

        public Task<IEnumerable<Project>?> GetProjects(Expression<Func<Project, bool>>? predicate)
        {

        }
    }
}
