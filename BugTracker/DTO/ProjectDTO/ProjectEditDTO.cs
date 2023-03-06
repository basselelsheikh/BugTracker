using BugTracker.Core.Domain.IdentityEntities;
using BugTracker.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.UI.DTO.ProjectDTO
{
    public class ProjectEditDTO
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Url]
        public string? RepoLink { get; set; }
    }
}
