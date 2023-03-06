using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
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

        public async Task<bool> DeleteProject(int projectId)
        {
            _context.Projects.Remove(_context.Projects.Single(tic => tic.ProjectId== projectId));
            int rowsDeleted = await _context.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<IEnumerable<Project>?> GetAllProjects()
        {
            return await _context.Projects.Include("Team").Include("Projects").Include("ProjectManager").ToListAsync();
        }
        public async Task<Project?> GetProject(int projectID)
        {
            return await _context.Projects.Include("Team").Include("Projects").Include("ProjectManager").FirstOrDefaultAsync(t => t.ProjectId == projectID);
        }

        public async Task<int> UpdateProject(Project project)
        {
            Project? projectToUpdate = await _context.Projects.FirstOrDefaultAsync(t => t.ProjectId == project.ProjectId);
            if (projectToUpdate is not null)
            {
                _mapper.Map<Project, Project>(project, projectToUpdate);
                await _context.SaveChangesAsync();
                return projectToUpdate.ProjectId;
            }
            else
            {
                //NOTE: raise exception
            }
        }
    }
}
