using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.ProjectServicesContracts
{
    public interface IProjectUpdater
    {
        public Task<int> UpdateProject(Project project);
    }
}
