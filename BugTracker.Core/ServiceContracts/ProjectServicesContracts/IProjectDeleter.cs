﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.ServiceContracts.ProjectServicesContracts
{
    public interface IProjectDeleter
    {
        public Task<bool> DeleteProject(int projectId);
    }
}
