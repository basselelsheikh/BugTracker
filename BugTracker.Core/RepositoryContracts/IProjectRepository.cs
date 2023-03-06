using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.RepositoryContracts
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>?> GetAllProjects();
        public Task<Project?> GetProject(int projectID);
    }
}
