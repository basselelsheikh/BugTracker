using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Enums;
using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO
{
    public class TicketAddDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SeverityOptions Severity { get; set; }
        public ICollection<ApplicationUser>? AssignedDevs { get; set; }
        public TicketTypeOptions Type { get; set; }
        public StatusOptions Status { get; set; } 
    }
}
