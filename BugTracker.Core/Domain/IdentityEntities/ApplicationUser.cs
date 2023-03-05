using BugTracker.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public ICollection<Ticket>? ReportedTickets { get; set; }
        public ICollection<Ticket>? AssignedInTickets { get; set; }
        public Project? ManagedProject { get; set; }
        public int? AssignedProjectId { get; set; }
        public Project? AssignedProject { get; set; }
    }
}
