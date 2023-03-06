using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;

namespace BugTracker.UI.DTO.ProjectDTO
{
    public class ProjectUpdateDTO
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
