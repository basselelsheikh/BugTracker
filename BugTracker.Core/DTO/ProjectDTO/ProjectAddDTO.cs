using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Core.DTO.ProjectDTO
{
    public class ProjectAddDTO
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ApplicationUser>? Team { get; set; }
        [Url]
        public string? RepoLink { get; set; }
    }
}
