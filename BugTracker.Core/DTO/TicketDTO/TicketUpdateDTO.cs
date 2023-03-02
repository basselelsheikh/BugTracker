using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.TicketDTO
{
    public class TicketUpdateDTO
    {
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Severity { get; set; }
        public IEnumerable<ApplicationUser>? AssignedDevs { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
    }
}
