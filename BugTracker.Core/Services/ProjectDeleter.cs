using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class ProjectDeleter : IProjectDeleter
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectDeleter(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<bool> DeleteProject(int projectId)
        {
           return _projectRepository.DeleteProject(projectId);
        }
    }
}
