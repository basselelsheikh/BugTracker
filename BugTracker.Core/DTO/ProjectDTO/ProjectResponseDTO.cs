using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.ProjectDTO
{
    public class ProjectResponseDTO
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ApplicationUser>? Team { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public string? RepoLink { get; set; }
    }
}
