using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.UI.DTO.ProjectDTO
{
    public class ProjectResponseDTO
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ApplicationUser>? Team { get; set; }
        public IEnumerable<Ticket>? Tickets { get; set; }
        public string? RepoLink { get; set; }
        public ApplicationUser? ProjectManager { get; set; }
    }
}
