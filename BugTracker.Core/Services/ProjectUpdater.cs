using AutoMapper;
using BugTracker.Core.Domain.Entities;
using BugTracker.Core.RepositoryContracts;
using BugTracker.Core.ServiceContracts.ProjectServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Services
{
    public class ProjectUpdater : IProjectUpdater
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectUpdater(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
         public async Task<int> UpdateProject(Project project)
        {
            return await _projectRepository.UpdateProject(project);
        }
    }
}
