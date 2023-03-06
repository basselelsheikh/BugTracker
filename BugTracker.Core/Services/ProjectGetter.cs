using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class ProjectGetter : IProjectGetter
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProjectRepository _projectRepository;
        public ProjectGetter(UserManager<ApplicationUser> userManager, IProjectRepository projectRepository)
        {
            _userManager = userManager;
            _projectRepository = projectRepository;

        }
        public async Task<IEnumerable<Project>?> GetAllProjects()
        {
            return await _projectRepository.GetAllProjects();
        }

        public async Task<Project?> GetManagedProject(string pmUsername)
        {
            var user = await _userManager.FindByNameAsync(pmUsername);
            return user.ManagedProject;
        }
        public async Task<Project?> GetProjectAssignedToDeveloper(string developerUsername)
        {
            var user = await _userManager.FindByNameAsync(developerUsername);
            return user.AssignedProject;
        }
        public async Task<Project?> GetProject(int projectId)
        {
            var project = await _projectRepository.GetProject(projectId);
            return project;
        }
    }
}
