using BugTracker.Core.Domain.Entities;
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
        public Task<Project?> GetProject(int projectId);
        public Task<IEnumerable<Project>?> GetAllProjects(); 
        public Task<Project?> GetManagedProject(string pmUsername);
        public Task<Project?> GetProjectAssignedToDeveloper(string developerUsername);
    }
}
