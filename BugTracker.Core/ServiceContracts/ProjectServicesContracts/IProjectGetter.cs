using BugTracker.Core.Domain.Entities;
using BugTracker.Core.DTO.ProjectDTO;
using BugTracker.Core.DTO.TicketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.ProjectServicesContracts
{
    public interface IProjectGetter
    {
        public Task<ProjectResponseDTO?> GetProject(int projectId);
        public Task<IEnumerable<ProjectResponseDTO>?> GetProject(Expression<Func<Project, bool>>? predicate);
    }
}
