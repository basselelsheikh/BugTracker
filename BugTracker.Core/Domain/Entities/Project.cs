using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Domain.Entities
{
    /// <summary>
    /// Project domain model class
    /// </summary>
    public class Project
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ApplicationUser> Team { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public string? RepoLink { get; set; }
        public int ProjectManagerId { get; set; }
        public ApplicationUser ProjectManager { get; set; }
    }
}
