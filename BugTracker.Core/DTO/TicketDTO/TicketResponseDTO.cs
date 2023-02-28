using BugTracker.Core.Domain.Entities;
using BugTracker.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.TicketDTO
{
    public class TicketResponseDTO
    {
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Severity { get; set; }
        public ApplicationUser? Reporter { get; set; }
        public IEnumerable<ApplicationUser>? AssignedDevs { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public DateTime? Reported { get; set; }
        public Project? Project { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
